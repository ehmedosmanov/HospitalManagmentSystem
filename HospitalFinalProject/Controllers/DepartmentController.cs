using HospitalFinalProject.DAL;
using HospitalFinalProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalFinalProject.Controllers
{
    public class DepartmentController : Controller
    {
        //-----------------------------------------------//
        #region AppDbContext
        private readonly AppDbContext _db;
        public DepartmentController(AppDbContext db)
        {
            _db = db;
        }
        #endregion
        //-----------------------------------------------//
        #region Index
        public async Task<IActionResult> Index()
        {
            List<Department> department = await _db.Departments.Include(d => d.HeadDoctor).ToListAsync();

            return View(department);
        }
        #endregion
        //-----------------------------------------------//
        #region Create
        // GET: Department/Create
        public async Task<IActionResult> Create()
        {

            // Database-den həkimlərin siyahısını əldə edirem
            ViewBag.Doctors = await _db.Doctors.ToListAsync();

            Department department = new Department
            {
                DepartmentDate = DateTime.UtcNow.AddHours(4)
            };

            return View(department);
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            // Database-den həkimlərin siyahısını əldə edirem
            ViewBag.Doctors = await _db.Doctors.ToListAsync();

            //Eyni telefon nömrəli xəstənin olub olmadığını yoxlayır 
            #region IsExist
            bool isExist = await _db.Departments.AnyAsync(d => d.Name == department.Name);

            if (isExist)
            {
                ModelState.AddModelError("Name", "Şöbə artıq mövcuddur.");
                return View();
            }
            #endregion

            if (department.Description == null)
            {
                ModelState.AddModelError("Description", "Məlumat önəmlidir.");
                return View();
            }

            await _db.Departments.AddAsync(department);
            await _db.SaveChangesAsync();
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
            // Database-den həkimlərin siyahısını əldə edirem
            ViewBag.Doctors = await _db.Doctors.ToListAsync();

            Department dbdepartment = await _db.Departments.FirstOrDefaultAsync(d => d.Id == id);

            if(dbdepartment == null)
            {
                return BadRequest();
            }

            return View(dbdepartment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Department department)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Database-den həkimlərin siyahısını əldə edirem
            ViewBag.Doctors = await _db.Doctors.ToListAsync();

            Department dbdepartment = await _db.Departments.FirstOrDefaultAsync(d => d.Id == id);

            if (dbdepartment == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(department); 
            }

            //Eyni adlı şöbənin olub olmadığını yoxlayır 
            #region IsExistForUpdate
            bool isExist = await _db.Departments.AnyAsync(d => d.Name == department.Name && d.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu telefon nömrəsi olan xəstə artıq mövcuddur.");
                return View(dbdepartment);
            }
            #endregion

            if (department.Description == null)
            {
                ModelState.AddModelError("Description", "Məlumat önəmlidir.");
                return View();
            }

            dbdepartment.Name = department.Name;
            dbdepartment.DepartmentDate = department.DepartmentDate;
            dbdepartment.Description = department.Description;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
        //-----------------------------------------------//
        #region Activity
        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department dbdepartment = await _db.Departments.Where(d => d.Id == id).FirstOrDefaultAsync();

            if (dbdepartment.IsDeactive) // atkiv deyil true
            {
                dbdepartment.IsDeactive = false; // aktiv ele
            }
            else
            {
                dbdepartment.IsDeactive = true;
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
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

            Department dbdepartment = await _db.Departments.FirstOrDefaultAsync(d => d.Id == id);

            if (dbdepartment == null)
            {
                return NotFound();
            }

            return View(dbdepartment);
        }


        // POST: Patient/Delete/Id
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Department department = _db.Departments.Find(id);

            if (department == null)
            {
                return NotFound();
            }

            _db.Departments.Remove(department);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion
        //-----------------------------------------------//

    }
}
