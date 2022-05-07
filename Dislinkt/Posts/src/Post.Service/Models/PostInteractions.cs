using Common;

namespace Post.Service.Models
{
    public class PostInteractions : IEntity
    {
        public Guid Id { get; set; }

        public IEnumerable<Guid> Likes { get; set; }

        public IEnumerable<Guid> Dislikes { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public PostInteractions(Guid id, IEnumerable<Guid> likes, IEnumerable<Guid> dislikes, IEnumerable<Comment> comments)
        {
            Id = id;
            Likes = likes;
            Dislikes = dislikes;
            Comments = comments;
        }
    }
}