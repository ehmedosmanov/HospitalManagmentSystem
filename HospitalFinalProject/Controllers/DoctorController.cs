using HospitalFinalProject.DAL;
using HospitalFinalProject.Helpers;
using HospitalFinalProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalFinalProject.Controllers
{
    public class DoctorController : Controller
    {
        //-----------------------------------------------//
        #region SQL
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public DoctorController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        #endregion
        //-----------------------------------------------//
        #region Index
        public async Task<IActionResult> Index()
        {
            List<Doctor> doctors = await _db.Doctors
                .Include(d => d.DoctorStatus)
                .Include(d => d.Department)
                .Include(d => d.Subordinates)
                .Include(d => d.Supervisor)
                .ToListAsync();

            ViewBag.Departments = await _db.Departments.ToListAsync();

            return View(doctors);
        }
        #endregion
        //-----------------------------------------------//
        #region Create
        public async Task<IActionResult> Create()
        {
            ViewBag.DoctorStatuses = await _db.DoctorStatuses.ToListAsync();
            ViewBag.Departments = await _db.Departments.ToListAsync();
            ViewBag.Doctors = await _db.Doctors.Include(d => d.Department).Where(d => d.IsHead == true).ToListAsync();
            ViewBag.IsHeadDepartments = await _db.Departments.AnyAsync(d => d.HeadDoctorId == null);
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Doctor doctor, int? doctorStatusId, int? departmentId, bool isHead)
        {

            ViewBag.DoctorStatuses = await _db.DoctorStatuses.ToListAsync();            
            ViewBag.Doctors = await _db.Doctors.Include(d => d.Department).Where(d => d.IsHead == true).ToListAsync();
            ViewBag.Departments = await _db.Departments.ToListAsync();
            ViewBag.IsHeadDepartments = await _db.Departments.AnyAsync(d => d.HeadDoctorId == null);

            //Eyni telefon nömrəli həkimin olub olmadığını yoxlayır 
            #region IsExist
            bool isExist = await _db.Doctors.AnyAsync(d => d.PhoneNumber == doctor.PhoneNumber);

            if (isExist)
            {
                ModelState.AddModelError("PhoneNumber", "Bu telefon nömrəsi olan həkim artıq mövcuddur.");
                return View();
            }
            #endregion

            #region SaveImg
            // Fotonun yükləndiyini və tələblərə cavab verdiyini yoxlayır
            if (doctor.Photo == null)
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkil seçin");
                return View();
            }

            if (!doctor.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkil file-ı seçin");
                return View();
            }

            if (doctor.Photo.IsOlder1MB())
            {
                ModelState.AddModelError("Photo", "Şəkilin ölçüsü maxsimal olaraq 1mb olmalıdır");
                return View();
            }

            string folder = Path.Combine(_env.WebRootPath, "images", "people");
            string fileName = await doctor.Photo.SaveFileAsync(folder);
            doctor.Img = fileName;
            #endregion

            if (doctor.Education == null)
            {
                ModelState.AddModelError("Education", "Təhsil tələb olunur");
                return View();
            }

            doctor.IsHead = isHead;
            doctor.DoctorStatusId = doctorStatusId;
            doctor.DepartmentId = departmentId;
            await _db.Doctors.AddAsync(doctor);
            await _db.SaveChangesAsync();
            if (isHead)
            {

                Department department = await _db.Departments.FindAsync(departmentId);
                if (department != null)
                {
                    department.HeadDoctorId = doctor.Id;
                    await _db.SaveChangesAsync();
                }
            }

            return RedirectToAction("Index");
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

            Doctor dbdoctor = await _db.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            ViewBag.Doctor = dbdoctor;
            if (dbdoctor == null)
            {
                return BadRequest();
            }

            ViewBag.DoctorStatuses = await _db.DoctorStatuses.ToListAsync();
            if (dbdoctor.IsHead)
            {
                ViewBag.Departments = await _db.Departments.Where(d => d.HeadDoctorId == dbdoctor.Id).ToListAsync();

            }
            else
            {
                ViewBag.Departments = await _db.Departments.ToListAsync();
            }
            ViewBag.HeadDoctor = await _db.Doctors.Where(d => d.IsHead == true).ToListAsync();
            ViewBag.Doctors = await _db.Doctors.Where(d => d.IsHead == true).ToListAsync();
            ViewBag.IsHeadDepartments = await _db.Departments.AnyAsync(d => d.HeadDoctorId == null);

            return View(dbdoctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Doctor doctor, int? doctorStatusId, int? departmentId, bool isHead, int? supervisorId)
        {
            if (id == null)
            {
                return NotFound();
            }


            Doctor dbdoctor = await _db.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            

            if (dbdoctor == null)
            {
                return BadRequest();
            }
            //Sonradan istifadə üçün saxlanılmış deyerler
            bool wasHeadDoctor = dbdoctor.IsHead;
            int? previousDepartmentId = dbdoctor.DepartmentId;
            bool hasAvailableDepartments = await _db.Departments.AnyAsync(d => d.HeadDoctorId == null);

            //Lazımlı datalar
            ViewBag.Doctors = await _db.Doctors.Where(d => d.IsHead == true).ToListAsync();
            ViewBag.DoctorStatuses = await _db.DoctorStatuses.ToListAsync();
            ViewBag.IsHeadDepartments = await _db.Departments.AnyAsync(d => d.HeadDoctorId == null);
            ViewBag.Doctor = dbdoctor;


            // ViewBag.Departments-ı statusundan asılı olaraq doldurulması
            if (dbdoctor.IsHead)
            {
                ViewBag.Departments = await _db.Departments.Where(d => d.HeadDoctorId == dbdoctor.Id).ToListAsync();

            }
            else
            {
                ViewBag.Departments = await _db.Departments.ToListAsync();
            }

            #region IsExistForUpdate
            bool isExist = await _db.Doctors.AnyAsync(d => d.PhoneNumber == doctor.PhoneNumber && d.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("PhoneNumber", "Bu telefon nömrəsi olan həkim artıq mövcuddur.");
                return View(dbdoctor);
            }
            #endregion

            #region SaveImgForUpdate
            if (doctor.Photo != null)
            {
                if (!doctor.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Please Upload a Photo");
                    return View(dbdoctor);
                }

                if (doctor.Photo.IsOlder1MB())
                {
                    ModelState.AddModelError("Photo", "Max 1Mb");
                    return View(dbdoctor);
                }

                string folder = Path.Combine(_env.WebRootPath, "images", "people");
                string fileName = await doctor.Photo.SaveFileAsync(folder);

                string fullPath = Path.Combine(folder, dbdoctor.Img);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                dbdoctor.Img = fileName;
            }
            #endregion

            //Təhsili yoxlamaq 
            if (doctor.Education == null)
            {
                ModelState.AddModelError("Education", "Təhsil tələb olunur");
                return View(dbdoctor);
            }

            if (!hasAvailableDepartments && isHead && departmentId != null)
            {
                if (departmentId != dbdoctor.DepartmentId)
                {
                    ModelState.AddModelError("DepartmentId", "Yeni baş direktor yaratmaq üçün boş bölmə yoxdur.");
                    return View(dbdoctor);
                }
            }

            //Datalar yenilənir
            dbdoctor.IsHead = isHead;
            dbdoctor.SupervisorId = supervisorId;
            dbdoctor.FirstName = doctor.FirstName;
            dbdoctor.LastName = doctor.LastName;
            dbdoctor.PhoneNumber = doctor.PhoneNumber;
            dbdoctor.Email = doctor.Email;
            dbdoctor.Specialization = doctor.Specialization;
            dbdoctor.Education = doctor.Education;
            dbdoctor.Experience = doctor.Experience;
            dbdoctor.DateOfBirth = doctor.DateOfBirth;
            dbdoctor.Address = doctor.Address;
            dbdoctor.Amount = doctor.Amount;
            dbdoctor.Gender = doctor.Gender;
            dbdoctor.DoctorStatusId = doctorStatusId;
            dbdoctor.DepartmentId = departmentId;
            await _db.SaveChangesAsync();

            //Əgər həkim şöbə müdiri olubdursa amma artıq deyil
            if (wasHeadDoctor && !isHead)
            {
                //department-den hekimin idsini silirik
                Department previousDepartment = await _db.Departments.FindAsync(previousDepartmentId);
                if (previousDepartment != null)
                {
                    previousDepartment.HeadDoctorId = null;
                    await _db.SaveChangesAsync();
                }
            }
            //Əgər həkim şöbə müdiri oldursa
            else if (!wasHeadDoctor && isHead)
            {
                //Department-ə həkimin id-sini əlavə edirik
                Department currentDepartment = await _db.Departments.FindAsync(departmentId);
                if (currentDepartment != null)
                {
                    currentDepartment.HeadDoctorId = id;
                    await _db.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index");
        }
        #endregion
        //-----------------------------------------------//
        #region Filter
        public IActionResult Filter(int? departmentId)
        {
            List<Doctor> filteredDoctors = _db.Doctors
                .Include(d => d.DoctorStatus)
                .Include(d => d.Department)
                .Where(d => !departmentId.HasValue || d.DepartmentId == departmentId).
                ToList();

            return PartialView("_DoctorListPartial", filteredDoctors);
        }
        #endregion
        //-----------------------------------------------//
        #region IsHeadCheckDepartments
        public async Task<IActionResult> UpdateDepartments(bool isHeadChecked)
        {
            List<Department> departments;

            if (isHeadChecked)
            {
                departments = await _db.Departments.Where(d => d.HeadDoctorId == null).ToListAsync();
            }
            else
            {
                departments = await _db.Departments.Where(d => d.HeadDoctorId != null).ToListAsync();
            }


            ViewBag.Departments = departments;
            return PartialView("_GetDepartmentsPartial");
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

            Doctor dbdoctor = await _db.Doctors.FirstOrDefaultAsync(p => p.Id == id);

            if (dbdoctor == null)
            {
                return NotFound();
            }

            return View(dbdoctor);
        }


        // POST: Patient/Delete/Id
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = _db.Doctors.Find(id);

            if (doctor == null)
            {
                return NotFound();
            }

            _db.Doctors.Remove(doctor);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion
        //-----------------------------------------------//
        #region GetRegularDoctors
        public async Task<IActionResult> GetRegularDoctors(int departmentId)
        {
            ViewBag.Doctors = await _db.Doctors.Where(d => d.DepartmentId == departmentId && d.IsHead).ToListAsync();
            return PartialView("_GetRegularDoctors");
        }
        #endregion
        //-----------------------------------------------//

    }
}
