using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalFinalProject.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Şöbənin adı tələb olunur.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Şöbə haqqında məlumat tələb olunur.")]
        public string Description { get; set; }

        public bool IsDeactive { get; set; }

        [Required(ErrorMessage = "Yaranma tarixi tələb olunur.")]
        [DataType(DataType.Date)]
        public DateTime DepartmentDate { get; set; }

        // One-to-one elaqe
        [ForeignKey("HeadDoctor")]
        public int? HeadDoctorId { get; set; }
        public Doctor HeadDoctor { get; set; }

        // One-to-many elaqe
        public List<Doctor> Doctors { get; set; }

        public List<Staff> Staffs { get; set; }
    }
}
