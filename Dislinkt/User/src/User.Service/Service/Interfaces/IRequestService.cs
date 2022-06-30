using User.Service.Models;

namespace User.Service.Service.Interfaces
{
    public interface IRequestService
    {
        
        Task CreateRequest( Guid reciever);

        Task<IReadOnlyCollection<Request>> GetRequestsForUser(Guid reciever);

        Task Confirm( Guid reciever);

    }
}