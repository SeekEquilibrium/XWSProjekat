namespace Post.Service.DTO
{
    public class PostDTO
    {
        public Guid PostId { get; set; }
        public String Text { get; set; }
        public DateTimeOffset PostDate { get; set; }
        public Guid UserId { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public PostDTO(Guid postId, string text, DateTimeOffset postDate, Guid userId, string firstname, string surname, string username)
        {
            PostId = postId;
            Text = text;
            PostDate = postDate;
            UserId = userId;
            Firstname = firstname;
            Surname = surname;
            Username = username;
        }
        
    }
}