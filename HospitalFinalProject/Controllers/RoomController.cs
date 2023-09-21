using HospitalFinalProject.DAL;
using HospitalFinalProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalFinalProject.Controllers
{
    public class RoomController : Controller
    {

        //-----------------------------------------------//
        #region SQL
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public RoomController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        #endregion
        //-----------------------------------------------//
        #region Index
        public async Task<IActionResult> Index()
        {
            List<RoomAllotment> roomAllotment = await _db.RoomAllotments
                .Include(r => r.RoomType)
                .Include(r => r.Patient)
                .Where(r => !r.IsDeactive)
                .ToListAsync();
            return View(roomAllotment);
        }
        #endregion
        //-----------------------------------------------//
        #region Create
        public async Task<IActionResult> Create()
        {
            ViewBag.RoomTypes = await _db.RoomTypes.ToListAsync();
            ViewBag.Patients = await _db.Patients.Where(p => p.PatientStatusId == 2).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomAllotment roomAllotment, int? typeId, int? patientId)
        {
            ViewBag.RoomTypes = await _db.RoomTypes.ToListAsync();
            ViewBag.Patients = await _db.Patients.Where(p => p.PatientStatusId == 2).ToListAsync();

            #region IsExist
            bool isExist = await _db.RoomAllotments.AnyAsync(a => a.RoomNo == roomAllotment.RoomNo);

            if (isExist)
            {
                ModelState.AddModelError("RoomNo", "Bu nömrəli otaq artıq doludur");
                return View();
            }
            #endregion

            roomAllotment.RoomTypeId = (int)typeId;
            roomAllotment.PatientId = (int)patientId;

            await _db.RoomAllotments.AddAsync(roomAllotment);
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

            RoomAllotment dbroom = await _db.RoomAllotments.Include(d => d.Patient).Include(d => d.RoomType).FirstOrDefaultAsync(d => d.Id == id);

            if (dbroom == null)
            {
                return BadRequest();
            }

            ViewBag.RoomTypes = await _db.RoomTypes.ToListAsync();
            ViewBag.Patients = await _db.Patients.Where(p => p.PatientStatusId == 2).ToListAsync();

            return View(dbroom);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, RoomAllotment roomAllotment, int? typeId, int? patientId)
        {
            if (id == null)
            {
                return NotFound();
            }

            RoomAllotment dbroom = await _db.RoomAllotments.Include(d => d.Patient).Include(d => d.RoomType).FirstOrDefaultAsync(d => d.Id == id);

            if (dbroom == null)
            {
                return BadRequest();
            }

            ViewBag.RoomTypes = await _db.RoomTypes.ToListAsync();
            ViewBag.Patients = await _db.Patients.Where(p => p.PatientStatusId == 2).ToListAsync();

            
            #region IsExist
            bool isExist = await _db.RoomAllotments.AnyAsync(a => a.RoomNo == roomAllotment.RoomNo && a.Id != id);

            if (isExist)
            {
                ModelState.AddModelError("RoomNo", "Bu nömrəli otaq artıq doludur");
                return View();
            }
            #endregion

            dbroom.DischargeDate = roomAllotment.DischargeDate;
            dbroom.AllotmentDate = roomAllotment.AllotmentDate;
            dbroom.RoomNo = roomAllotment.RoomNo;
            dbroom.PatientId = (int)patientId;
            dbroom.RoomTypeId = (int)typeId;
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
            RoomAllotment dbroom = await _db.RoomAllotments.FirstOrDefaultAsync(x => x.Id == id);
            if (dbroom == null)
            {
                return BadRequest();
            }
            if (dbroom.IsDeactive)
            {
                dbroom.IsDeactive = false;
            }
            else
            {
                dbroom.IsDeactive = true;
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
        //-----------------------------------------------//
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RoomAllotment roomAllotment = await _db.RoomAllotments
                .Include(ra => ra.Patient)
                .Include(ra => ra.RoomType)
                .FirstOrDefaultAsync(ra => ra.Id == id);

            if (roomAllotment == null)
            {
                return NotFound();
            }

            return View(roomAllotment);
        }
        //-----------------------------------------------//



    }
}
