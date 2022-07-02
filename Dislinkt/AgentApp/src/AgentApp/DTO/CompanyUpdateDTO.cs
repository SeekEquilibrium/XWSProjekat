namespace AgentApp.DTO
{
    public class CompanyUpdateDTO
    {
        public String Name { get; set; }
        public String Description { get; set; }

        public CompanyUpdateDTO(String name, String description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}