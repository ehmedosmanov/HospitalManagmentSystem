using System.ComponentModel.DataAnnotations;
using static HospitalFinalProject.Helpers.Helper;

namespace HospitalFinalProject.ViewModels
{
    public class UpdateVM
    {
        [Required(ErrorMessage = "Ad tələb olunur.")]
        [MaxLength(20, ErrorMessage = "20 simboldan artıq olmamalıdır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad tələb olunur.")]
        [MaxLength(20, ErrorMessage = "20 simboldan artıq olmamalıdır.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "İstifadəçi adı tələb olunur.")]
        [MaxLength(20, ErrorMessage = "20 simboldan artıq olmamalıdır.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email tələb olunur")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Düzgün Email daxil edin.")]
        public string Email { get; set; }
        public string Role { get; set; }
        [Required(ErrorMessage = "Cins tələb olunur.")]
        public Gender Gender { get; set; }
    }
}
