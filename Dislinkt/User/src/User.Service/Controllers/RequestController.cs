using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using User.Service.Models;
using User.Service.DTO;
using Common;
using User.Service.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace User.Service.Controllers
{
    [ApiController]
    [Route("requests")]
    public class RequestController : ControllerBase
    {

        public readonly IMapper _mapper;
        private readonly IRepository<Request> _requestRepository;
        private readonly IRequestService _requestService;
        private readonly IUserService _userService;

        public RequestController(IMapper mapper, IRepository<Request> requestRepository, IRequestService requestService, IUserService userService)
        {
            _requestService = requestService;
            _mapper = mapper;
            _requestRepository = requestRepository;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Request>>> PostAsync(Guid sender, Guid reciever)
        {
            /*
            if(_userService.isPrivate(requestDTO.reciever))
            {
                await _reqestService.CreateRequest(requestDTO.Sender, requestDTO.Reciever);
            }
            else
            {
                //poslati zahtev connection endpointu da kreira konekciju
            }
            */
            await _requestService.CreateRequest(sender , reciever);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAsync(Guid id)
        {
            List<AppUser> users = new List<AppUser>();
            var requests = await _requestService.GetRequestsForUser(id);
            foreach (var i in requests){
                users.Add(_userService.GetUserById(i.Reciever).Result);
            }
            return Ok(users);
        }


        [HttpPost("confirm")]
        public async Task<ActionResult> ConfirmRequest(Guid sender , Guid reciever )
        {
            await _requestService.Confirm(sender,reciever);
            return Ok();
        }
    }
}