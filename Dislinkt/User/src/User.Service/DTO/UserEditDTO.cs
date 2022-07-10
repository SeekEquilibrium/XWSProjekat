using User.Service.Models;

namespace User.Service.DTO
{
    public class UserEditDTO
    {
        public Guid Id { get; set; }
        public String Firstname { get; set; }
        public String Surname { get; set; }
        public String Email { get; set; }
        public String Telephone { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public String Biography { get; set; }
        public String Username { get; set; }
        public String Interest { get; set; }
        public List<SkillsEnum> Skills { get; set; }
        public Boolean IsPrivate { get; set; }
        public UserEditDTO(Guid id, String firstname, String surname, String email, String telephone, GenderEnum gender, DateTime birthDate, String biography, String username, String interest, List<SkillsEnum> skills, Boolean isPrivate)
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Surname = surname;
            this.Email = email;
            this.Telephone = telephone;
            this.Gender = gender;
            this.BirthDate = birthDate;
            this.Biography = biography;
            this.Username = username;
            this.Interest = interest;
            this.Skills = skills;
            this.IsPrivate = isPrivate;
        }
    }
}