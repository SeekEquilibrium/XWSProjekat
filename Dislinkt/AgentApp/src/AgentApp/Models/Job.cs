using Common;

namespace AgentApp.Models
{
    public class Job : IEntity
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Guid CompanyId { get; set; }

        public Job(String name, Guid companyId)
        {
            this.Name = name;
            this.CompanyId = companyId;
        }

    }
}