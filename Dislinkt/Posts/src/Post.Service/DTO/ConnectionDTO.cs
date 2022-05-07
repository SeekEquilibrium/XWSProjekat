namespace Post.Service.DTO
{
    public class ConnectionDTO
    {
        public Guid Id { get; set; }

        public ConnectionDTO(Guid id)
        {
            Id = id;
        }
    }
}