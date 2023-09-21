using Microsoft.AspNetCore.Identity;
using static HospitalFinalProject.Helpers.Helper;

namespace HospitalFinalProject.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Gender Gender { get; set; }
        public bool IsDeactive { get; set; }
    }
}
