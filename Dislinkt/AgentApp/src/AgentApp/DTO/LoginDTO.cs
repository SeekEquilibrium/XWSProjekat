namespace AgentApp.DTO
{
    public class LoginDTO
    {
        public String Username { get; set; }
        public String Password { get; set; }

        public LoginDTO(String username, String password)
        {
            this.Username = username;
            this.Password = password;

        }
    }
}