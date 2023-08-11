using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage ="İsim Alanı gereklidir")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyisim Alanı gereklidir")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Alanı gereklidir")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mail Alanı gereklidir")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Şifre Alanı gereklidir")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Tekrar Alanı gereklidir")]
        [Compare("Password",ErrorMessage ="Şifreler aynı değildir")]
        public string ConfirmPassword { get; set; }
    }
}
