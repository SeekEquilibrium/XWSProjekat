namespace User.Service.DTO
{
    public class UserEditDTO
    {
        public String Firstname { get; set; }
        public String Surname { get; set; }
        public String Username { get; set; }
        public Boolean IsPrivate { get; set; }
        public UserEditDTO(string firstname, string surname, string username, bool isPrivate)
        {
            Firstname = firstname;
            Surname = surname;
            Username = username;
            IsPrivate = isPrivate;
        }
    }
}