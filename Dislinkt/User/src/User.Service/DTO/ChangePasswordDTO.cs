using System.ComponentModel.DataAnnotations;

namespace User.Service.DTO
{
    public class ChangePasswordDTO
    {
        //Minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character:
        [Required, MinLength(8), RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$")]
        public String NewPassword { get; set; }
        [Required, Compare("NewPassword")]
        public String NewPasswordRepeat { get; set; }
        [Required, MinLength(8)]
        public String OldPassword { get; set; }

        public ChangePasswordDTO(String newPassword, String newPasswordRepeat, String oldPassword)
        {
            NewPassword = newPassword;
            NewPasswordRepeat = newPasswordRepeat;
            OldPassword = oldPassword;
        }
    }
}