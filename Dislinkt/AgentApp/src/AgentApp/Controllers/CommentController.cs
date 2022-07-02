using Microsoft.AspNetCore.Mvc;
using AgentApp.Models;
using AgentApp.DTO;
using AgentApp.Services;
using AutoMapper;

namespace AgentApp.Controller
{    
    [ApiController]
    [Route("comments")]
    public class CommentController : ControllerBase
    {
        public readonly CompanyService _companyService;
        public readonly UserService _userService;
        public readonly CommentService _commentService;
        public readonly IMapper _mapper;

        public CommentController(CompanyService companyService, UserService userService, CommentService commentService, IMapper mapper)
        {
            _companyService = companyService;
            _userService = userService;
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpGet("company/{id}")]
        public async Task<ActionResult<IEnumerable<CommentDTO>>> GetAllByCompany(Guid id)
        {
            var companies = (await _commentService.GetAllByCompany(id))
                        .Select(comment => _mapper.Map<CommentDTO>(comment));

            return Ok(companies);
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<CommentDTO>>> GetAllByUser(Guid id)
        {
            var companies = (await _commentService.GetAllByUser(id))
                        .Select(comment => _mapper.Map<CommentDTO>(comment));

            return Ok(companies);
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> Register(CommentDTO commentDTO)
        {
            if(await _companyService.GetCompanyById(commentDTO.CompanyId) == null)
            {
                return NotFound("Company not found.");
            }
            if(await _userService.GetUserById(commentDTO.UserId) == null)
            {
                return NotFound("User not found.");
            }

            Comment comment = _mapper.Map<Comment>(commentDTO);
            await _commentService.CreateComment(comment);

            return Ok(comment);
        }
    }
}