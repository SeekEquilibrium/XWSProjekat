using Common;

namespace User.Service.Models
{
    public class Request : IEntity
    {
        public Guid Id { get; set; }
        public Guid Sender { get; set; }

        public Guid Reciever { get; set; }


        public Request(Guid sender, Guid reciever)
        {
            this.Sender = sender;
            this.Reciever = reciever;

        }

    }
}