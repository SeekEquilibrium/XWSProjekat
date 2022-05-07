using Common;

namespace Post.Service.Models
{
    public class Comment
    {
        public Guid UserId { get; set; }

        public String Text { get; set; }

        public DateTimeOffset Date { get; set; }

        public Comment(Guid userId, string text, DateTimeOffset date)
        {
            UserId = userId;
            Text = text;
            Date = date;
        }
    }
}