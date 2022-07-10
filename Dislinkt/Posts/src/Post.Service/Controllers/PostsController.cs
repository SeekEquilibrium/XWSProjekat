using Common;
using Microsoft.AspNetCore.Mvc;
using Post.Service.Clients;
using Post.Service.DTO;
using Post.Service.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace Post.Service.Controllers
{
    [ApiController]
    [Route("posts")]
    public class PostsController : ControllerBase
    {
        public readonly IMapper _mapper;

        private readonly IRepository<UserPost> _postRepository;

        private readonly IRepository<PostInteractions> _interactionRepository;

        private readonly UserClient _userClient;

        private readonly ConnectionClient _connectionClient;
        public PostsController(IMapper mapper, IRepository<UserPost> postRepository, IRepository<PostInteractions> interactionRepository, UserClient userClient, ConnectionClient connectionClient)
        {
            this._mapper = mapper;
            this._postRepository = postRepository;
            this._interactionRepository = interactionRepository;
            this._userClient = userClient;
            this._connectionClient = connectionClient;
        }

        [HttpGet]
        public async Task<ActionResult<PostDTO>> GetAsync(Guid postId, Guid userId)
        {
            if (postId == Guid.Empty) return BadRequest();

            var post = await _postRepository.GetAsync(postId);

            if (post == null) return BadRequest();

            UserDTO userDto = await _userClient.GetUserAsync(userId);
            PostDTO postDto = new PostDTO(
                post.Id, post.Text, post.PostDate,
                userDto.Id, userDto.Firstname, userDto.Surname, userDto.Username
            );

            return Ok(postDto);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<UserPost>>> PostAsync(CreatePostDTO createPostDTO)
        {
            if (createPostDTO.Text == null) return BadRequest();

            var post = _mapper.Map<UserPost>(createPostDTO);
            post.Id = Guid.NewGuid();
            post.PostDate = DateTime.Now;
            PostInteractions postInteractions = new PostInteractions(post.Id, Enumerable.Empty<Guid>(), Enumerable.Empty<Guid>(), Enumerable.Empty<Comment>());
            await _postRepository.CreateAsync(post);
            await _interactionRepository.CreateAsync(postInteractions);
            return Ok();
        }

        [HttpGet("feed")]
        public async Task<ActionResult<IEnumerable<HugePostDTO>>> GetFeedAsync(Guid userId)      //id iz tokena
        {
            var users = await _connectionClient.GetConnectedAsync(userId);
            IEnumerable<UserPost> feed = Enumerable.Empty<UserPost>();

            foreach (ConnectionDTO user in users)
            {
                feed = feed.Concat<UserPost>(await _postRepository.GetAllAsync(post => post.UserId.Equals(user.Id)));
            }
            List<HugePostDTO> hugePostDTOs = new List<HugePostDTO>();
            foreach (var i in feed)
            {
                var interaction = await _interactionRepository.GetAsync(i.Id);
                HugePostDTO postDTO = new HugePostDTO();
                postDTO.PostId = i.Id;
                postDTO.Text = i.Text;
                postDTO.PostDate = i.PostDate;
                postDTO.UserId = i.UserId;

                UserDTO user = new UserDTO();
                user = await _userClient.GetUserAsync(i.UserId);
                postDTO.Firstname = user.Firstname;
                postDTO.Surname = user.Surname;
                postDTO.Username = user.Username;

                FrontInteractionsDTO frontDTO = new FrontInteractionsDTO();
                frontDTO.Likes = interaction.Likes.Count();
                frontDTO.Dislikes = interaction.Dislikes.Count();
                frontDTO.Id = interaction.Id;
                List<UserDetailCommentDTO> listakomentara = new List<UserDetailCommentDTO>();

                foreach (var j in interaction.Comments)
                {
                    UserDetailCommentDTO commentDTO = new UserDetailCommentDTO();
                    commentDTO.UserId = j.UserId;
                    commentDTO.Date = j.Date;
                    commentDTO.Text = j.Text;

                    UserDTO user1 = new UserDTO();
                    user1 = await _userClient.GetUserAsync(j.UserId);
                    commentDTO.Firstname = user1.Firstname;
                    commentDTO.Surname = user1.Surname;
                    commentDTO.Username = user1.Username;
                    listakomentara.Add(commentDTO);
                }
                frontDTO.Comments = listakomentara;
                postDTO.interactions = frontDTO;

                hugePostDTOs.Add(postDTO);

            }
            return Ok(hugePostDTOs);
        }

        [HttpGet("userPosts")]
        public async Task<ActionResult<IEnumerable<HugePostDTO>>> GetByUserAsync(Guid userId)        //provere pracenje i private user
        {
            List<HugePostDTO> hugePostDTOs = new List<HugePostDTO>();

            var posts = await _postRepository.GetAllAsync(post => post.UserId.Equals(userId));
            foreach (var i in posts)
            {
                var interaction = await _interactionRepository.GetAsync(i.Id);
                HugePostDTO postDTO = new HugePostDTO();
                postDTO.PostId = i.Id;
                postDTO.Text = i.Text;
                postDTO.PostDate = i.PostDate;
                postDTO.UserId = i.UserId;

                UserDTO user = new UserDTO();
                user = await _userClient.GetUserAsync(i.UserId);
                postDTO.Firstname = user.Firstname;
                postDTO.Surname = user.Surname;
                postDTO.Username = user.Username;

                FrontInteractionsDTO frontDTO = new FrontInteractionsDTO();
                frontDTO.Likes = interaction.Likes.Count();
                frontDTO.Dislikes = interaction.Dislikes.Count();
                frontDTO.Id = interaction.Id;
                List<UserDetailCommentDTO> listakomentara = new List<UserDetailCommentDTO>();

                foreach (var j in interaction.Comments)
                {
                    UserDetailCommentDTO commentDTO = new UserDetailCommentDTO();
                    commentDTO.UserId = j.UserId;
                    commentDTO.Date = j.Date;
                    commentDTO.Text = j.Text;

                    UserDTO user1 = new UserDTO();
                    user1 = await _userClient.GetUserAsync(j.UserId);
                    commentDTO.Firstname = user1.Firstname;
                    commentDTO.Surname = user1.Surname;
                    commentDTO.Username = user1.Username;
                    listakomentara.Add(commentDTO);
                }
                frontDTO.Comments = listakomentara;
                postDTO.interactions = frontDTO;

                hugePostDTOs.Add(postDTO);

            }

            return Ok(hugePostDTOs);
        }

        [HttpPost("likePost")]
        public async Task<ActionResult<IEnumerable<UserPost>>> LikePostAsync(InteractionDTO interactionDTO)
        {
            var postInteraction = await _interactionRepository.GetAsync(interactionDTO.PostId);   //TO DO: dodati provere jel vec like/dislike
            if (!postInteraction.Likes.Contains(interactionDTO.UserId))
            {
                if (postInteraction.Dislikes.Contains(interactionDTO.UserId))
                {
                    postInteraction.Dislikes = postInteraction.Dislikes.Where(x => x != interactionDTO.UserId);
                }

                postInteraction.Likes = postInteraction.Likes.Append<Guid>(interactionDTO.UserId);
                await _interactionRepository.UpdateAsync(postInteraction);
            }
            return Ok();
        }

        [HttpPost("dislikePost")]
        public async Task<ActionResult<IEnumerable<UserPost>>> DislikePostAsync(InteractionDTO interactionDTO)
        {
            var postInteraction = await _interactionRepository.GetAsync(interactionDTO.PostId);      //TO DO: dodati provere jel vec like/dislike
            if (!postInteraction.Dislikes.Contains(interactionDTO.UserId))
            {
                if (postInteraction.Likes.Contains(interactionDTO.UserId))
                {
                    postInteraction.Likes = postInteraction.Likes.Where(x => x != interactionDTO.UserId);
                }

                postInteraction.Dislikes = postInteraction.Dislikes.Append<Guid>(interactionDTO.UserId);
                await _interactionRepository.UpdateAsync(postInteraction);
            }
            return Ok();
        }

        [HttpPost("comment")]
        public async Task<ActionResult<IEnumerable<UserPost>>> CommentAsync(CommentDTO commentDTO)
        {
            var postInteraction = await _interactionRepository.GetAsync(commentDTO.PostId);
            Comment comment = new Comment(commentDTO.UserId, commentDTO.Text, DateTimeOffset.Now);
            postInteraction.Comments = postInteraction.Comments.Append<Comment>(comment);
            await _interactionRepository.UpdateAsync(postInteraction);

            return Ok();
        }


    }
}