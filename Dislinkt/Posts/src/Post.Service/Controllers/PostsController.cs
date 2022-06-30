using Common;
using Microsoft.AspNetCore.Mvc;
using Post.Service.Clients;
using Post.Service.DTO;
using Post.Service.Models;
using Microsoft.AspNetCore.Authorization;

namespace Post.Service.Controllers
{
    [ApiController]
    [Route("posts")]
    public class PostsController : ControllerBase
    {
        private readonly IRepository<UserPost> _postRepository;

        private readonly IRepository<PostInteractions> _interactionRepository;

        private readonly UserClient _userClient;

        private readonly ConnectionClient _connectionClient;
        public PostsController(IRepository<UserPost> postRepository, IRepository<PostInteractions> interactionRepository, UserClient userClient, ConnectionClient connectionClient)
        {
            this._postRepository = postRepository;
            this._interactionRepository = interactionRepository;
            this._userClient = userClient;
            this._connectionClient = connectionClient;
        }

        [HttpGet]
        public async Task<ActionResult<PostDTO>> GetAsync(Guid postId)
        {
            if(postId == Guid.Empty) return BadRequest();
            
            var post = await _postRepository.GetAsync(postId);

            if(post == null) return BadRequest();
             
            UserDTO userDto = await _userClient.GetUserAsync(_userClient.GetUserId().Result);
            PostDTO postDto = new PostDTO(
                post.Id, post.Text, post.PostDate,
                userDto.Id, userDto.Firstname, userDto.Surname, userDto.Username
            );

            return Ok(postDto);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<UserPost>>> PostAsync(UserPost userPost)
        {
            if(userPost.Text == null) return BadRequest();

            PostInteractions postInteractions = new PostInteractions(userPost.Id, Enumerable.Empty<Guid>(), Enumerable.Empty<Guid>(), Enumerable.Empty<Comment>());

            await _postRepository.CreateAsync(userPost);
            await _interactionRepository.CreateAsync(postInteractions);
            return Ok();
        }

        [HttpGet("feed")]
        public async Task<ActionResult<IEnumerable<UserPost>>> GetFeedAsync(Guid userId)      //id iz tokena
        {
            var users = await _connectionClient.GetConnectedAsync(userId);
            IEnumerable<UserPost> feed = Enumerable.Empty<UserPost>();

            foreach(ConnectionDTO user in users)
            {
                feed = feed.Concat<UserPost>(await _postRepository.GetAllAsync(post => post.UserId.Equals(user.Id)));
            }

            return Ok(feed);
        }

        [HttpGet("userPosts")]
        public async Task<ActionResult<IEnumerable<UserPost>>> GetByUserAsync()        //provere pracenje i private user
        {
        
            var posts = await _postRepository.GetAllAsync(post => post.UserId.Equals(_userClient.GetUserId().Result));

            return Ok(posts);
        }

        [HttpPost("likePost")]
        public async Task<ActionResult<IEnumerable<UserPost>>> LikePostAsync(InteractionDTO interactionDTO)
        {
            var postInteraction = await _interactionRepository.GetAsync(interactionDTO.PostId);   //TO DO: dodati provere jel vec like/dislike
            if(!postInteraction.Likes.Contains(_userClient.GetUserId().Result))
            {
                postInteraction.Likes = postInteraction.Likes.Append<Guid>(_userClient.GetUserId().Result);
                await _interactionRepository.UpdateAsync(postInteraction);
            }
            return Ok();
        }

        [HttpPost("dislikePost")]
        public async Task<ActionResult<IEnumerable<UserPost>>> DislikePostAsync(InteractionDTO interactionDTO)
        {
            var postInteraction = await _interactionRepository.GetAsync(interactionDTO.PostId);      //TO DO: dodati provere jel vec like/dislike
            if(!postInteraction.Likes.Contains(_userClient.GetUserId().Result))
            {
                postInteraction.Dislikes = postInteraction.Dislikes.Append<Guid>(_userClient.GetUserId().Result);
                await _interactionRepository.UpdateAsync(postInteraction);
      
            }        
            return Ok();
        }

        [HttpPost("comment")]
        public async Task<ActionResult<IEnumerable<UserPost>>> CommentAsync(CommentDTO commentDTO)
        {
            var postInteraction = await _interactionRepository.GetAsync(commentDTO.PostId);
            Comment comment = new Comment(_userClient.GetUserId().Result, commentDTO.Text, DateTimeOffset.Now);
            postInteraction.Comments = postInteraction.Comments.Append<Comment>(comment);
            await _interactionRepository.UpdateAsync(postInteraction);

            return Ok();
        }

    }
}