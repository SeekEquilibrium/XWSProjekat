using System.ComponentModel.DataAnnotations;
using User.Service.Models;

namespace User.Service.DTO
{
    public class RegisterRequestDTO
    {
        [Required]
        public String Firstname { get; set; }
        [Required]
        public String Surname { get; set; }
        [Required, EmailAddress]
        public String Email { get; set; }
        public String Telephone { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public String Biography { get; set; }
        [Required, MinLength(5)]
        public String Username { get; set; }
        public String Interest { get; set; }
        public List<SkillsEnum> Skills { get; set; }
        //Minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character:
        [Required, MinLength(8), RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$")]
        public String Password { get; set; }
        [Required, Compare("Password")]
        public String RepeatPassword { get; set; }
        public Boolean IsPrivate { get; set; } = true;

        public RegisterRequestDTO(String firstname, String surname, String email, String telephone, GenderEnum gender, DateTime birthDate, String biography, String username, String interest, List<SkillsEnum> skills, Boolean isPrivate, String password)
        {
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
            this.Password = password;
        }

    }
}