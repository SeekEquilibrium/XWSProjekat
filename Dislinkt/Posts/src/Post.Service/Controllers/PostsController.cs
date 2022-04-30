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
        public PostsController(IRepository<UserPost> postRepository, UserClient userClient){
            this._postRepository = postRepository;
            this._userClient = userClient;
        }

        [HttpGet]
        public async Task<ActionResult<PostDTO>> GetAsync(Guid postId){
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
        public async Task<ActionResult<IEnumerable<UserPost>>> PostAsync(UserPost userPost){
            if(userPost.Text == null){
                return BadRequest();
            }

            await _postRepository.CreateAsync(userPost);
            return Ok();
        }
    }
}