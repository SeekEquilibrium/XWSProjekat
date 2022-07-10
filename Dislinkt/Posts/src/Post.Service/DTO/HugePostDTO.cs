namespace Post.Service.DTO
{
    public class HugePostDTO
    {
        public Guid PostId { get; set; }
        public String Text { get; set; }
        public DateTimeOffset PostDate { get; set; }
        public Guid UserId { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public FrontInteractionsDTO interactions {get; set; }

         public HugePostDTO(Guid postId, string text, DateTimeOffset postDate, Guid userId, string firstname, string surname, string username)
        {
            PostId = postId;
            Text = text;
            PostDate = postDate;
            UserId = userId;
            Firstname = firstname;
            Surname = surname;
            Username = username;
        }
        public HugePostDTO(){

        }
    }
}