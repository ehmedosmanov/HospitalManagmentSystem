using HospitalFinalProject.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalFinalProject.Models
{
    public class RoomAllotment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pasiyent tələb olunur.")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required(ErrorMessage = "Otağın tipi tələb olunur.")]
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }

        [Required(ErrorMessage = "Otağın nömrəsi tələb olunur.")]
        [MaxLength(10, ErrorMessage = "Otaq nömrəsi 10 simvoldan çox ola bilməz")]
        public string RoomNo { get; set; }

        [Required(ErrorMessage = "Qeydiyyat tarixini daxil edin")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AllotmentDate { get; set; }

        [Required(ErrorMessage = "Buraxılış tarixini daxil edin")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DischargeDate { get; set; }

        public bool IsDeactive { get; set; }
    }
}
