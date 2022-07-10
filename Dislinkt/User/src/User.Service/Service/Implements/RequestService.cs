using Common;
using Microsoft.AspNetCore.Mvc;
using User.Service.Clients;
using User.Service.Models;
using User.Service.Service.Interfaces;

namespace User.Service.Service.Implements
{
    public class RequestSevice : IRequestService
    {
        private readonly IRepository<Request> _requestRepository;

        private readonly ConnectionClient _connectclient;
        private readonly IUserService _userService;

        public RequestSevice(IRepository<Request> requestRepository, ConnectionClient connectclient , IUserService userService)
        {
            _requestRepository = requestRepository;
            _connectclient = connectclient;
            _userService = userService;
        }

        public async Task CreateRequest(Guid sender ,Guid reciever){
            
            Request request = new Request(sender, reciever);
            /*if(GetRequest(sender, reciever) == null)
            {
            await _requestRepository.CreateAsync(request);
            }*/
            await _requestRepository.CreateAsync(request);
        }

        public async Task<IReadOnlyCollection<Request>> GetRequestsForUser(Guid reciever){
            IReadOnlyCollection<Request> requests = await _requestRepository.GetAllAsync(request => request.Reciever.Equals(reciever));
            return requests;            
        }

        public async Task Confirm(Guid sender,  Guid reciever)
        {
        
            Request request = await GetRequest(sender, reciever);
            if(request != null){
                await _connectclient.ConnectAsync(sender, reciever);
            }
            
        }

        private async Task<Request> GetRequest(Guid sender, Guid reciever)
        {
            IReadOnlyCollection<Request> request = await _requestRepository.GetAllAsync(request => request.Sender.Equals(sender) && request.Reciever.Equals(reciever));
            return request.First();
        }
    }
}