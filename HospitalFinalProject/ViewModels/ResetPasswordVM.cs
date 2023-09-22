using System.ComponentModel.DataAnnotations;

namespace HospitalFinalProject.ViewModels
{
    public class ResetPasswordVM
    {
        public string Id { get; set; }
        public string Token { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
