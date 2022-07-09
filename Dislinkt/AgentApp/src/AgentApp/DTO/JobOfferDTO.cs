namespace AgentApp.DTO
{
    public class JobOfferDTO
    {
        public String Job { get; set; }
        public String CompanyName { get; set; }
        public String Description { get; set; }
        public String Requirements { get; set; }

        public JobOfferDTO(String job, String companyName, String description, String requirements)
        {
            this.Job = job;
            this.CompanyName = companyName;
            this.Description = description;
            this.Requirements = requirements;

        }
    }
}