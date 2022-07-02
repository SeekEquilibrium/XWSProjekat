using Common;

namespace AgentApp.Models
{
    public class Company : IEntity
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Guid OwnerId { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String Description { get; set; }
        public Boolean Confirmed {get; set; }

        public Company(String name, Guid ownerId, String email, String phoneNumber, String description)
        {
            this.Name = name;
            this.OwnerId = ownerId;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Description = description;
            this.Confirmed = false;
        }
    }
}