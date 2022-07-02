namespace AgentApp.DTO
{
    public class JobDTO
    {
        public String Name { get; set; }
        public Guid CompanyId { get; set; }

        public JobDTO(String name, Guid companyId)
        {
            this.Name = name;
            this.CompanyId = companyId;
        }
    }
}