namespace AgentApp.DTO
{
    public class CommentDTO
    {
        public Guid CompanyId { get; set; }
        public Guid UserId { get; set; }
        public String Text { get; set; }

        public CommentDTO(Guid companyId, Guid userId, String text)
        {
            this.CompanyId = companyId;
            this.UserId = userId;
            this.Text = text;
        }
    }
}