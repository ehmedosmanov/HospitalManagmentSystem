using System.Collections.Generic;

namespace HospitalFinalProject.Models
{
    public class DoctorStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}
