using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;
using static HospitalFinalProject.Helpers.Helper;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace HospitalFinalProject.Models
{
    public class Staff
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

        [Required(ErrorMessage = "Telefon nömrəsi tələb olunur.")]
        [Phone(ErrorMessage = "Yanlış telefon nömrəsi.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "E-poçt tələb olunur.")]
        [EmailAddress(ErrorMessage = "Yanlış e-poçt ünvanı.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Təyin olunacaq iş tələb olunur.")]
        [MaxLength(100)]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Maaş tələb olunur.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Maaş sıfırdan çox olmalıdır.")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Cins tələb olunur.")]
        public Gender Gender { get; set; }

        public string Img { get; set; }

        [Required(ErrorMessage = "Təhsil tələb olunur")]
        public string Education { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public bool IsDeactive { get; set; }

        public List<Salary> Salaries { get; set; }
    }
}
