namespace Post.Service.DTO
{
    public class FrontInteractionsDTO
    {
       public Guid Id { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public IEnumerable<UserDetailCommentDTO> Comments { get; set; }

        public FrontInteractionsDTO(Guid id, int likes, int dislikes, IEnumerable<UserDetailCommentDTO> comments)
        {
            Id = id;
            Likes = likes;
            Dislikes = dislikes;
            Comments = comments;
        }
        public FrontInteractionsDTO(){
            
        }
    }
}