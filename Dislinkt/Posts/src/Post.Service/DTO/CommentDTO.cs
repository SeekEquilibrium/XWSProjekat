namespace Post.Service.DTO
{
    public class CommentDTO
    {
        public Guid PostId { get; set; }

        public Guid UserId { get; set; }

        public string Text { get; set; }

        public CommentDTO(Guid postId, Guid userId, string text)
        {
            PostId = postId;
            UserId = userId;
            Text = text;
        }
    }
}