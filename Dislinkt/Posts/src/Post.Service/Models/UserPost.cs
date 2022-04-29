using Common;

namespace Post.Service.Models
{
    public class UserPost : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public String Text { get; set; }
        public DateTimeOffset PostDate { get; set; }
    }
}