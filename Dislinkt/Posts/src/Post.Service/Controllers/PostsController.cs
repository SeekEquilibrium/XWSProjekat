using Common;
using Microsoft.AspNetCore.Mvc;
using Post.Service.Clients;
using Post.Service.DTO;
using Post.Service.Models;

namespace Post.Service.Controllers
{
    [ApiController]
    [Route("posts")]
    public class PostsController : ControllerBase
    {
        private readonly IRepository<UserPost> _postRepository;
        private readonly UserClient _userClient;

        private readonly ConnectionClient _connectionClient;
        public PostsController(IRepository<UserPost> postRepository, UserClient userClient, ConnectionClient connectionClient)
        {
            this._postRepository = postRepository;
            this._userClient = userClient;
            this._connectionClient = connectionClient;
        }

        [HttpGet]
        public async Task<ActionResult<PostDTO>> GetAsync(Guid postId)
        {
            if(postId == Guid.Empty)
            {
                return BadRequest();
            }
            var post = await _postRepository.GetAsync(postId);
            if(post == null) return BadRequest();
             
            UserDTO userDto = await _userClient.GetUserAsync(post.UserId);
            PostDTO postDto = new PostDTO(
                post.Id, post.Text, post.PostDate,
                userDto.Id, userDto.Firstname, userDto.Surname, userDto.Username
            );
            return Ok(postDto);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<UserPost>>> PostAsync(UserPost userPost)
        {
            if(userPost.Text == null)
            {
                return BadRequest();
            }

            await _postRepository.CreateAsync(userPost);
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
        public async Task<ActionResult<IEnumerable<UserPost>>> GetByUserAsync(Guid userId)        //porvere pracenje i private user
        {
            if(userId == Guid.Empty) return BadRequest();

            var posts = await _postRepository.GetAllAsync(post => post.UserId.Equals(userId));

            return Ok(posts);
        }
    }
}