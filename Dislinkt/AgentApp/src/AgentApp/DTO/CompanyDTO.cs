namespace AgentApp.DTO
{
    public class CompanyDTO
    {
        public String Name { get; set; }
        public Guid OwnerId { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String Description { get; set; }

        public CompanyDTO(String name, Guid ownerId, String email, String phoneNumber, String description)
        {
            this.Name = name;
            this.OwnerId = ownerId;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Description = description;
        }
    }
}