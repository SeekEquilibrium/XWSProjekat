using Common;
using Microsoft.AspNetCore.Mvc;
using Post.Service.Models;

namespace Post.Service.Controllers
{
    [ApiController]
    [Route("posts")]
    public class PostsController : ControllerBase
    {
        private readonly IRepository<UserPost> _postRepository;

        public PostsController(IRepository<UserPost> postRepository){
            this._postRepository = postRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPost>>> GetAsync(Guid userId){
            if(userId == Guid.Empty)
            {
                return BadRequest();
            }

            var posts = (await _postRepository.GetAllAsync(post => post.UserId == userId));
            return Ok(posts);
        }
    }
}