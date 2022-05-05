using User.Service.Models;

namespace User.Service.Service.Interfaces
{
    public interface IRequestService
    {
        
        Task CreateRequest(Guid sender, Guid reciever);

        Task<IReadOnlyCollection<Request>> GetRequestsForUser(Guid reciever);

        Task<Request> Confirm(Guid sender, Guid reciever);

    }
}