using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HospitalFinalProject.Helpers.Helper;

namespace HospitalFinalProject.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad tələb olunur.")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyadı tələb olunur.")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Doğum tarixi tələb olunur.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Ünvan tələb olunur.")]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Maaş tələb olunur.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Maaş sıfırdan çox olmalıdır.")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Telefon nömrəsi tələb olunur.")]
        [Phone(ErrorMessage = "Yanlış telefon nömrəsi.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "E-poçt tələb olunur.")]
        [EmailAddress(ErrorMessage = "Yanlış e-poçt ünvanı.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "İxtisas tələb olunur.")]
        [MaxLength(100)]
        public string Specialization { get; set; }

        [Required(ErrorMessage = "Təcrübə ili tələb olunur.")]
        public int Experience { get; set; }

        [Required(ErrorMessage = "Cins tələb olunur.")]
        public Gender Gender { get; set; }

        [MaxLength(200)]
        public string Img { get; set; }

        [Required(ErrorMessage = "Təhsil önəmlidir")]
        public string Education { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
        
        public bool IsHead { get; set; } 

        public bool IsDeactive { get; set; }

        [Required(ErrorMessage = "Status tələb olunur")]
        public int? DoctorStatusId { get; set; }
        public DoctorStatus DoctorStatus { get; set; }

        public List<Appointment> Appointments { get; set; }

        public int? DepartmentId { get; set; }

        public Department Department { get; set; }
        //self join
        public int? SupervisorId { get; set; } 

        public Doctor Supervisor { get; set; } 

        public List<Doctor> Subordinates { get; set; }

        public List<Salary> Salaries { get; set; }
    }
}
