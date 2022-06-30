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

        public RequestController(IMapper mapper, IRepository<Request> requestRepository, IRequestService requestService)
        {
            _requestService = requestService;
            _mapper = mapper;
            _requestRepository = requestRepository;
        }

        [HttpPost, Authorize]
        public async Task<ActionResult<IEnumerable<Request>>> PostAsync(Guid reciever)
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
            await _requestService.CreateRequest(reciever);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<RequestDTO>>> GetAsync(Guid id)
        {
            var requests = await _requestService.GetRequestsForUser(id);
            return Ok(requests);
        }


        [HttpPost("confirm"), Authorize]
        public async Task<ActionResult> ConfirmRequest(Guid reciever )
        {
            await _requestService.Confirm(reciever);
            return Ok();
        }
    }
}