namespace User.Service.DTO
{
    public class RequestDTO
    {
        public Guid Sender { get; set; }

        public Guid Reciever { get; set; }

        public RequestDTO(Guid sender, Guid reciever)
        {
            Sender = sender;
            Reciever = reciever;
        }
    }
}