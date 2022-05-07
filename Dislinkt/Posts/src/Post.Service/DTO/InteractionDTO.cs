namespace Post.Service.DTO
{
        public class InteractionDTO
    {
        public Guid PostId { get; set; }

        public Guid UserId { get; set; }

        public InteractionDTO(Guid postId, Guid userId)
        {
            PostId = postId;
            UserId = userId;
        }
    }
}