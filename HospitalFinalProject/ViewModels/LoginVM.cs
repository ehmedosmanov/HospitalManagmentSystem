using System.ComponentModel.DataAnnotations;

namespace HospitalFinalProject.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Zəhmət olmasa istifadəçi adınızı qeyd edin.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa parolunuzu qeyd edin.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}
