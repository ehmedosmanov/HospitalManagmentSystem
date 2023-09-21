using HospitalFinalProject.DAL;
using HospitalFinalProject.Helpers;
using HospitalFinalProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static HospitalFinalProject.Helpers.Helper;

namespace HospitalFinalProject.Controllers
{
    public class PatientController : Controller
    {
        //-----------------------------------------------//
        #region SQL
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public PatientController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        #endregion
        //-----------------------------------------------//
        #region Index
        public async Task<IActionResult> Index()
        {
            List<Patient> patients = await _db.Patients
                .Include(p => p.PatientStatus)
                .Include(p => p.BloodGroup)
                .ToListAsync();

            return View(patients);
        }
        #endregion
        //-----------------------------------------------//
        #region Create
        // GET: Patient/Create
        public async Task<IActionResult> Create()
        {
            // Database-den qan qruplarının və xəstənnin statuslarının siyahısını əldə edirem
            ViewBag.BloodGroups = await _db.BloodGroups.ToListAsync();
            ViewBag.PatientStatuses = await _db.PatientStatuses.ToListAsync();

            Patient patient = new Patient
            {              
                LastVisit = DateTime.UtcNow.AddHours(4),
                DateOfBirth = DateTime.Today
            };

            return View(patient);
        }

        // POST: Patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Patient patient, int? patientStatusId, int? bloodGroupId)
        {
            // Database-den qan qruplarının və xəstənnin statuslarının siyahısını əldə edirem
            ViewBag.BloodGroups = await _db.BloodGroups.ToListAsync();
            ViewBag.PatientStatuses = await _db.PatientStatuses.ToListAsync();

            //Eyni telefon nömrəli xəstənin olub olmadığını yoxlayır 
            #region IsExist
            bool isExist = await _db.Patients.AnyAsync(p => p.PhoneNumber == patient.PhoneNumber);

            if (isExist)
            {
                ModelState.AddModelError("PhoneNumber", "Bu telefon nömrəsi olan xəstə artıq mövcuddur.");
                return View();
            }
            #endregion

            #region SaveImg
            // Fotonun yükləndiyini və tələblərə cavab verdiyini yoxlayır
            if (patient.Photo == null)
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkil seçin");
                return View();
            }

            if (!patient.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkil file-ı seçin");
                return View();
            }

            if (patient.Photo.IsOlder1MB())
            {
                ModelState.AddModelError("Photo", "Şəkilin ölçüsü maxsimal olaraq 1mb olmalıdır");
                return View();
            }

            string folder = Path.Combine(_env.WebRootPath, "images", "people");
            string fileName = await patient.Photo.SaveFileAsync(folder);
            patient.Img = fileName;
            #endregion


            patient.LastVisit = DateTime.UtcNow.AddHours(4);
            patient.PatientStatusId = (int)patientStatusId;
            patient.BloodGroupId = (int)bloodGroupId;

            // Dataları Database-ə əlavə eləməy və yadda saxlamaq
            await _db.Patients.AddAsync(patient);
            await _db.SaveChangesAsync();

            // Bütün xəstələr siyahısın səhifəsinə yönləndirmə (Index)
            return RedirectToAction("Index");
        }

        #endregion
        //-----------------------------------------------//
        #region Update
        // GET: Patient/Update/Id
        public async Task<IActionResult> Update(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Patient dbpatient = await _db.Patients.FirstOrDefaultAsync(p => p.Id == id);

            // Database-den qan qruplarının və xəstənnin statuslarının siyahısını əldə edirem
            ViewBag.BloodGroups = await _db.BloodGroups.ToListAsync();
            ViewBag.PatientStatuses = await _db.PatientStatuses.ToListAsync();

            if (dbpatient == null)
            {
                return BadRequest();
            }

            

            return View(dbpatient);
        }

        // POST: Patient/Update/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Patient patient, int? id, int patientStatusId, int bloodGroupId)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient dbpatient = await _db.Patients.FirstOrDefaultAsync(p => p.Id == id);


            if (dbpatient == null)
            {
                return BadRequest();
            }


            // Database-den qan qruplarının və xəstənnin statuslarının siyahısını əldə edirem
            ViewBag.BloodGroups = await _db.BloodGroups.ToListAsync();
            ViewBag.PatientStatuses = await _db.PatientStatuses.ToListAsync();

            //Eyni telefon nömrəli xəstənin olub olmadığını yoxlayır 
            #region IsExistForUpdate
            bool isExist = await _db.Patients.AnyAsync(p => p.PhoneNumber == patient.PhoneNumber && p.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("PhoneNumber", "Bu telefon nömrəsi olan xəstə artıq mövcuddur.");
                return View(dbpatient);
            }
            #endregion

            if (patient.Photo != null)
            {
                if (!patient.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Please Upload a Photo");
                    return View();
                }

                if (patient.Photo.IsOlder1MB())
                {
                    ModelState.AddModelError("Photo", "Max 1Mb");
                    return View();
                }

                string folder = Path.Combine(_env.WebRootPath, "images", "people");
                string fileName = await patient.Photo.SaveFileAsync(folder);

                string fullPath = Path.Combine(folder, dbpatient.Img);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                dbpatient.Img = fileName;
            }


            dbpatient.PhoneNumber = patient.PhoneNumber;
            dbpatient.Address = patient.Address;
            dbpatient.Email = patient.Email;
            dbpatient.DateOfBirth = patient.DateOfBirth;
            dbpatient.Email = patient.Email;
            dbpatient.FirstName = patient.FirstName;
            dbpatient.LastName = patient.LastName;
            dbpatient.Gender = patient.Gender;
            dbpatient.PatientStatusId = patientStatusId;
            dbpatient.BloodGroupId = bloodGroupId;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #endregion
        //-----------------------------------------------//
        #region Detail
        // GET: Patient/Detail/Id
        public async Task<IActionResult> Detail(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Patient dbpatient = await _db.Patients
                .Include(p => p.PatientStatus)
                .Include(p => p.BloodGroup)
                .FirstOrDefaultAsync(dbpatienId => dbpatienId.Id == id);

            if (dbpatient == null)
            {
                return BadRequest();
            }

            return View(dbpatient);
        }
        #endregion
        //-----------------------------------------------//
        #region Delete
        // GET: Patient/Delete/Id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient dbpatient = await _db.Patients.FirstOrDefaultAsync(p => p.Id == id);

            if (dbpatient == null)
            {
                return NotFound();
            }

            return View(dbpatient);
        }


        // POST: Patient/Delete/Id
        [HttpPost] 
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Patient patient =  _db.Patients.Find(id);

            if (patient == null)
            {
                return NotFound();
            }

            _db.Patients.Remove(patient);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion
        //-----------------------------------------------//
    }
}
