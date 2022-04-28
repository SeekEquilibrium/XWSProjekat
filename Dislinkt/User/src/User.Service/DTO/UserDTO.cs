namespace User.Service.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public String Firstname { get; set; }
        public String Surname { get; set; }
        public String Username { get; set; }

        public UserDTO(Guid id, String firstname, String surname, String username)
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Surname = surname;
            this.Username = username;

        }

        public UserDTO()
        {}
    }
}