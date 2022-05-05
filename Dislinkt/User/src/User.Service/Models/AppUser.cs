using Common;

namespace User.Service.Models
{
    public class AppUser : IEntity
    {
        public Guid Id { get; set; }
        public String Firstname { get; set; }
        public String Surname { get; set; }
        public String Email {get; set;}
        public String Telephone { get; set; }
        public GenderEnum Gender {get; set;}
        public DateTime BirthDate {get; set;}
        public String Biography { get; set; }
        public String Username { get; set; }
        public Boolean IsPrivate { get; set; } = true;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; } 

        public AppUser(String firstname, String surname, String username, Boolean isPrivate, byte[] passwordHash, byte[] passwordSalt)
        {
            this.Firstname = firstname;
            this.Surname = surname;
            this.Username = username;
            this.IsPrivate = isPrivate;
            this.PasswordHash = passwordHash;
            this.PasswordSalt = passwordSalt;
        }

        

        public AppUser(Guid id, String firstname, String surname, String username)
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Surname = surname;
            this.Username = username;
        }

        public AppUser(String firstname, String surname, String username)
        {
            this.Firstname = firstname;
            this.Surname = surname;
            this.Username = username;

        }

        public AppUser() { }

    }
}
