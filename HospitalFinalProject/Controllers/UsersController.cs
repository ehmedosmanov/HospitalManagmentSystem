using HospitalFinalProject.DAL;
using HospitalFinalProject.Models;
using HospitalFinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalFinalProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _db;
        public UsersController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, AppDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<AppUser> users = await _userManager.Users.ToListAsync();
            List<UserVM> userVMs = new List<UserVM>();

            foreach (AppUser user in users)
            {
                UserVM userVM = new UserVM()
                {
                    Id = user.Id,
                    Name = user.UserName,
                    Surname = user.Surname,
                    Username = user.UserName,
                    Email = user.Email,
                    Gender = user.Gender,
                    IsDeactive = user.IsDeactive,
                    Role = (await _userManager.GetRolesAsync(user))[0]
                };
                userVMs.Add(userVM);
            }

            return View(userVMs);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
