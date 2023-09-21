using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalFinalProject.Models
{
    public class Salary
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Maaş tələb olunur.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Maaş sıfırdan çox olmalıdır.")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Ödəmə tarixi tələb olunur.")]
        [DataType(DataType.Date)]
        public DateTime PaymentDay { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int StaffId { get; set; }
        public Staff Staff { get; set; }
        
    }
}
