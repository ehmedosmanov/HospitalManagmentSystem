using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalFinalProject.Models
{
    public class Income
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Gəlir məbləği tələb olunur.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Gəlir məbləği sıfırdan çox olmalıdır.")]
        public double Amount { get; set; }
        [Required(ErrorMessage = "Gəlir haqqında məlumat tələb olunur.")]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
