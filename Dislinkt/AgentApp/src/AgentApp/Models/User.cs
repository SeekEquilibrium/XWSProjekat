using Common;

namespace AgentApp.Models
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public String Firstname { get; set; }
        public String Surname { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }

        public RoleEnum Role {get; set;}

        public User(String firstname, String surname, String username, String password, String email, RoleEnum role)
        {
            this.Firstname = firstname;
            this.Surname = surname;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.Role = role;

        }

    }

}

