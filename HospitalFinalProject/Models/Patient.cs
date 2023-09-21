using System.Collections.Generic;
using System.Reflection;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using static HospitalFinalProject.Helpers.Helper;

namespace HospitalFinalProject.Models
{
    public class Patient
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

        [DataType(DataType.Date)]
        public DateTime LastVisit { get; set; }

        [Required(ErrorMessage = "Status tələb olunur")]
        public int PatientStatusId { get; set; }
        public PatientStatus PatientStatus { get; set; }

        [Required(ErrorMessage = "Qan qrupu tələb olunur")]
        public int BloodGroupId { get; set; }
        public BloodGroup BloodGroup { get; set; }

        [MaxLength(200)]
        public string Img { get; set; }

        [NotMapped] //SQL DE bele tipde data saxlaya bilmiriy deye not mapped ediriy
        public IFormFile Photo { get; set; }

        [Required(ErrorMessage = "Cins tələb olunur..")]
        public Gender Gender { get; set; }

        public List<Appointment> Appointments { get; set; }

        public List<RoomAllotment> RoomAllotments { get; set; }
    }
}
