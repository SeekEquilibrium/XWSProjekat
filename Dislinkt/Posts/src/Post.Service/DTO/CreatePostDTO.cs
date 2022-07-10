namespace Post.Service.DTO
{
    public class CreatePostDTO
    {
        public Guid UserId { get; set; }
        public String Text { get; set; }
        public CreatePostDTO(Guid userId, string text)
        {
            UserId = userId;
            Text = text;
        }
    }
}