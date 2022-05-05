namespace User.Service.DTO
{
    public class ClientDTO
    {
        public Guid Id { get; set; }

        public ClientDTO(Guid id)
        {
            this.Id = id;

        }
    }
}