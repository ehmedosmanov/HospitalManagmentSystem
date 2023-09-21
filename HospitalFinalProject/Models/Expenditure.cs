using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace HospitalFinalProject.Models
{
    public class Expenditure
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tələb olunur.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Xərcin məbləği sıfırdan çox olmalıdır.")]
        public double Amount { get; set; }
        [Required(ErrorMessage = "Xərc haqqında məlumat tələb olunur.")]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        
    }
}
