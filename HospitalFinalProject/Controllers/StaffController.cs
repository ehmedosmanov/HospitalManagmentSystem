using HospitalFinalProject.DAL;
using HospitalFinalProject.Helpers;
using HospitalFinalProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Threading.Tasks;

namespace HospitalFinalProject.Controllers
{
    public class StaffController : Controller
    {
        //-----------------------------------------------//
        #region SQL
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public StaffController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
            
        }
        #endregion
        //-----------------------------------------------//
        #region Index
        public async Task<IActionResult> Index()
        {
            List<Staff> staff = await _db.Staffs.Include(d => d.Department).ToListAsync();

            return View(staff);
        }
        #endregion
        //-----------------------------------------------//
        #region Create
        // GET: Staff/Create
        public async Task<IActionResult> Create()
        {
            // Database-den şöbələrin siyahısını əldə edirem
            ViewBag.Departments = await _db.Departments.ToListAsync();

            return View();
        }

        //POST: Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Staff staff, int? departmentId)
        {
            // Database-den şöbələrin siyahısını əldə edirem
            ViewBag.Departments = await _db.Departments.ToListAsync();

            //Eyni telefon nömrəli işçinin olub olmadığını yoxlayır 
            #region IsExist
            bool isExist = await _db.Staffs.AnyAsync(p => p.PhoneNumber == staff.PhoneNumber);

            if (isExist)
            {
                ModelState.AddModelError("PhoneNumber", "Bu telefon nömrəsi olan işçi artıq mövcuddur.");
                return View();
            }
            #endregion

            if (staff.Education == null)
            {
                ModelState.AddModelError("Education", "Təhsil tələb olunur");
                return View();
            }

            #region SaveImg
            // Fotonun yükləndiyini və tələblərə cavab verdiyini yoxlayır
            if (staff.Photo == null)
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkil seçin");
                return View();
            }

            if (!staff.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkil file-ı seçin");
                return View();
            }

            if (staff.Photo.IsOlder1MB())
            {
                ModelState.AddModelError("Photo", "Şəkilin ölçüsü maxsimal olaraq 1mb olmalıdır");
                return View();
            }

            string folder = Path.Combine(_env.WebRootPath, "images", "people");
            string fileName = await staff.Photo.SaveFileAsync(folder);
            staff.Img = fileName;
            #endregion

            staff.DepartmentId = (int)departmentId;

            // Dataları Database-ə əlavə eləməy və yadda saxlamaq
            await _db.Staffs.AddAsync(staff);
            await _db.SaveChangesAsync();

            //Əlavə edildikdən sonra Index səhifəsinə yönləndirmə
            return RedirectToAction("Index");
        }

        #endregion
        //-----------------------------------------------//
        #region Update
        // GET: staff/Update/Id
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Staff dbstaff = await _db.Staffs.FirstOrDefaultAsync(p => p.Id == id);


            // Database-den şöbələrin siyahısını əldə edirem
            ViewBag.Departments = await _db.Departments.ToListAsync();

            if (dbstaff == null)
            {
                return BadRequest();
            }



            return View(dbstaff);
        }

        // POST: Staff/Update/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Staff staff, int? id, int departmentId)
        {
            if (id == null)
            {
                return NotFound();
            }

            Staff dbstaff = await _db.Staffs.FirstOrDefaultAsync(p => p.Id == id);


            if (dbstaff == null)
            {
                return BadRequest();
            }


            // Database-den şöbələrin siyahısını əldə edirem
            ViewBag.Departments = await _db.Departments.ToListAsync();

            //Eyni telefon nömrəli işçinin olub olmadığını yoxlayır 
            #region IsExistForUpdate
            bool isExist = await _db.Staffs.AnyAsync(p => p.PhoneNumber == staff.PhoneNumber && p.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("PhoneNumber", "Bu telefon nömrəsi olan işçi artıq mövcuddur.");
                return View(dbstaff);
            }
            #endregion

            if (staff.Education == null)
            {
                ModelState.AddModelError("Education", "Təhsil tələb olunur");
                return View(dbstaff);
            }

            if (staff.Photo != null)
            {
                if (!staff.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Please Upload a Photo");
                    return View();
                }

                if (staff.Photo.IsOlder1MB())
                {
                    ModelState.AddModelError("Photo", "Max 1Mb");
                    return View();
                }

                string folder = Path.Combine(_env.WebRootPath, "images", "people");
                string fileName = await staff.Photo.SaveFileAsync(folder);

                string fullPath = Path.Combine(folder, dbstaff.Img);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                dbstaff.Img = fileName;
            }


            dbstaff.PhoneNumber = staff.PhoneNumber;
            dbstaff.Education = staff.Education;
            dbstaff.Designation = staff.Designation;
            dbstaff.Address = staff.Address;
            dbstaff.Email = staff.Email;
            dbstaff.DateOfBirth = staff.DateOfBirth;
            dbstaff.Email = staff.Email;
            dbstaff.FirstName = staff.FirstName;
            dbstaff.LastName = staff.LastName;
            dbstaff.Gender = staff.Gender;
            dbstaff.Amount = staff.Amount;
            dbstaff.DepartmentId = departmentId;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #endregion
    }
}
