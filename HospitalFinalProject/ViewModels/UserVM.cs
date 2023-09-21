using System.ComponentModel.DataAnnotations;
using static HospitalFinalProject.Helpers.Helper;

namespace HospitalFinalProject.ViewModels
{
    public class UserVM
    {
        public string Id { get; set; } //String tipde olmasının səbəbi Id qarışıq hərflərdən ibarət olmasıdır
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Gender Gender { get; set; }
        public bool IsDeactive { get; set; }

    }
}
