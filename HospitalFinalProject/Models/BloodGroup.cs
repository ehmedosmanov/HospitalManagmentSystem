using System.Collections.Generic;

namespace HospitalFinalProject.Models
{
    public class BloodGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
