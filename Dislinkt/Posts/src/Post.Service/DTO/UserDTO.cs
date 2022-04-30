namespace Post.Service.DTO
{
    public class UserDTO
    {

        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public UserDTO()
        {
        }
        public UserDTO(Guid id, string firstname, string surname, string username)
        {
            Id = id;
            Firstname = firstname;
            Surname = surname;
            Username = username;
        }

        public UserDTO(UserDTO userDTO){
            Id = userDTO.Id;
            Firstname = userDTO.Firstname;
            Surname = userDTO.Surname;
            Username = userDTO.Username;
        }
    }
}