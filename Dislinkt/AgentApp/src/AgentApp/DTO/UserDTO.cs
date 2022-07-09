namespace AgentApp.DTO
{
    public class UserDTO
    {
        public String Firstname { get; set; }
        public String Surname { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }

        public UserDTO(String firstname, String surname, String username, String password, String email)
        {
            this.Firstname = firstname;
            this.Surname = surname;
            this.Username = username;
            this.Password = password;
            this.Email = email;
        }
    }
}