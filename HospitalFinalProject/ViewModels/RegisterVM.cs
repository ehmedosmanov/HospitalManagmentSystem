using System.ComponentModel.DataAnnotations;
using static HospitalFinalProject.Helpers.Helper;

namespace HospitalFinalProject.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Ad tələb olunur.")]
        [MaxLength(20, ErrorMessage = "20 simboldan artıq olmamalıdır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad tələb olunur.")]
        [MaxLength(20, ErrorMessage = "20 simboldan artıq olmamalıdır.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "İstifadəçi adı tələb olunur.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mail tələb olunur.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Düzgün e-poçt ünvanı daxil edin.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifrə tələb olunur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifrəni təsdiqləyin")]
        [Compare("Password", ErrorMessage = "Şifrə eyni deyil")]
        public string CheckPassword { get; set; }

        [Required(ErrorMessage = "Cins tələb olunur.")]
        public Gender Gender { get; set; }

    }
}
