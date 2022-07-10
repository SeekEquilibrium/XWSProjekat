namespace Post.Service.DTO
{
    public class UserDetailCommentDTO
    {
        public Guid UserId { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        
        public string Text { get; set; }
        public DateTimeOffset Date { get; set; }

        public UserDetailCommentDTO(Guid id, string firstname, string surname, string username, Guid postId, string text,DateTimeOffset postDate)
        {
            UserId = id;
            Firstname = firstname;
            Surname = surname;
            Username = username;
            Text = text;
            Date = postDate;
        }
        public UserDetailCommentDTO (){

        }
    }
}