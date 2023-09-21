using System.Collections.Generic;

namespace HospitalFinalProject.Models
{
    public class PatientStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
