using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static HospitalFinalProject.Helpers.Helper;
using System.ComponentModel.DataAnnotations.Schema;
using HospitalFinalProject.Helpers;

namespace HospitalFinalProject.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Zədə tələb olunur.")]
        [MaxLength(250)]
        public string InjuryCondition { get; set; }

        [Required(ErrorMessage = "Randevu tarixi tələb olunur")]
        [DataType(DataType.Date)]
        [TimeSlotTimeValidation(ErrorMessage = "Rezerv tarixi keçmiş tarix ola bilməz.")]
        public DateTime? DateOfAppointment { get; set; }

        [Required(ErrorMessage = "Randevu tarix saatı tələb olunur")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)] // Saat vaxtı (saat ve dəqiqə)
        [TimeSlotTimeValidation(ErrorMessage = "Bitmə vaxtı Başlama vaxtı ilə uyğunlaşmır.")]
        public DateTime? From { get; set; }

        [Required(ErrorMessage = "Randevu tarix saatı tələb olunur")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)] // Saat vaxtı (saat ve dəqiqə)
        [TimeSlotTimeValidation(ErrorMessage = "Bitmə vaxtı Başlama vaxtı ilə uyğunlaşmır.")]
        public DateTime? To { get; set; }

        [Required(ErrorMessage = "Məlumat önəmlidir.")]
        public string Notes { get; set; }

        [Required(ErrorMessage = "Cins tələb olunur.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Pasiyent  tələb olunur.")]
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required(ErrorMessage = "Həkim tələb olunur.")]
        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; } 

        public bool IsDeactive { get; set; }
    }
}
