using HospitalFinalProject.DAL;
using HospitalFinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalFinalProject.Controllers
{

    public class AppointmentController : Controller
    {
        //-----------------------------------------------//
        #region AppDbContext
        private readonly AppDbContext _db;
        public AppointmentController(AppDbContext db)
        {
            _db = db;
        }
        #endregion
        //-----------------------------------------------//
        #region Index
        public async Task<IActionResult> Index()
        {
            List<Appointment> appointments = await _db.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .ToListAsync();

            return View(appointments);
        }
        #endregion
        //-----------------------------------------------//
        #region Create
        public async Task<IActionResult> Create()
        {

            ViewBag.Doctors = await _db.Doctors.Where(d => d.DoctorStatus.Id == 1).ToListAsync();
            ViewBag.Patients = await _db.Patients.Where(d => d.PatientStatus.Id == 1).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment, int? patientId, int? doctorId)
        {
            ViewBag.Doctors = await _db.Doctors.Where(d => d.DoctorStatus.Id == 1).ToListAsync();
            ViewBag.Patients = await _db.Patients.Where(d => d.PatientStatus.Id == 1).ToListAsync();

            #region IsExist
            bool isExist = await _db.Appointments.AnyAsync(a => a.DateOfAppointment == appointment.DateOfAppointment && a.From == appointment.From && a.To == appointment.To);

            if (isExist)
            {
                ModelState.AddModelError("DateOfAppointment", "Bu tarix artıq rezervdədir");
                return View();
            }
            #endregion


            if (patientId.HasValue && doctorId.HasValue)
            {
                Doctor doctor = await _db.Doctors.FindAsync(doctorId);
                Patient patient = await _db.Patients.FindAsync(patientId);
                if (patient != null && doctor != null)
                {
                    patient.PatientStatusId = 2;

                    doctor.DoctorStatusId = 2;
                }
            }

            appointment.DoctorId = doctorId;
            appointment.PatientId = patientId;

            if(ModelState.IsValid)
            {
                await _db.Appointments.AddAsync(appointment);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(appointment);


        }
        #endregion
        //-----------------------------------------------//
        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Appointment dbappointment = await _db.Appointments.Include(d => d.Doctor).Include(d => d.Patient).FirstOrDefaultAsync(d => d.Id == id);

            ViewBag.Doctors = await _db.Doctors
                    .Where(d => d.DoctorStatus.Id == 1 || (d.Appointments.Any(a => a.Id == dbappointment.Id)))
                    .ToListAsync();

            ViewBag.Patients = await _db.Patients
                     .Where(d => d.PatientStatus.Id == 1 || (d.Appointments.Any(a => a.Id == dbappointment.Id)))
                     .ToListAsync();

            if (dbappointment == null)
            {
                return BadRequest();
            }


            return View(dbappointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Appointment appointment, int? patientId, int? doctorId)
        {
            if (id == null)
            {
                return NotFound();
            }

            Appointment dbappointment = await _db.Appointments.Include(d => d.Doctor).Include(d => d.Patient).FirstOrDefaultAsync(d => d.Id == id);


            if (dbappointment == null)
            {
                return BadRequest();
            }

            ViewBag.Doctors = await _db.Doctors
                   .Where(d => d.DoctorStatus.Id == 1 || (d.Appointments.Any(a => a.Id == dbappointment.Id)))
                   .ToListAsync();

            ViewBag.Patients = await _db.Patients
                     .Where(d => d.PatientStatus.Id == 1 || (d.Appointments.Any(a => a.Id == dbappointment.Id)))
                     .ToListAsync();

            #region IsExistForUpdate
            bool isExist = await _db.Appointments.AnyAsync(a => a.DateOfAppointment == appointment.DateOfAppointment && a.From == appointment.From && a.To == appointment.To && a.Id != id);

            if (isExist)
            {
                ModelState.AddModelError("DateOfAppointment", "Bu tarix artıq rezervdədir");
                return View();
            }
            #endregion


            #region StatusUpdate
            if (patientId.HasValue)
            {

                if (dbappointment.PatientId.HasValue && dbappointment.PatientId != patientId)
                {
                    Patient oldPatient = await _db.Patients.FindAsync(dbappointment.PatientId);
                    if (oldPatient != null)
                    {
                        oldPatient.PatientStatusId = 1;
                    }
                }

                Patient newPatient = await _db.Patients.FindAsync(patientId);
                if (newPatient != null)
                {
                    newPatient.PatientStatusId = 2;
                }
            }

            if (doctorId.HasValue)
            {
                if (dbappointment.DoctorId.HasValue && dbappointment.DoctorId != doctorId)
                {
                    Doctor oldDoctor = await _db.Doctors.FindAsync(dbappointment.DoctorId);
                    if (oldDoctor != null)
                    {
                        oldDoctor.DoctorStatusId = 1;
                    }
                }

                Doctor newDoctor = await _db.Doctors.FindAsync(doctorId);
                if (newDoctor != null)
                {
                    newDoctor.DoctorStatusId = 2;
                }
            }
            #endregion

            dbappointment.DoctorId = doctorId;
            dbappointment.PatientId = patientId;
            dbappointment.InjuryCondition = appointment.InjuryCondition;
            dbappointment.DateOfAppointment = appointment.DateOfAppointment;
            dbappointment.From = appointment.From;
            dbappointment.To = appointment.To;
            dbappointment.Notes = appointment.Notes;
            if (ModelState.IsValid)
            {
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(appointment);
        }
        #endregion
        //-----------------------------------------------//
    }
}
