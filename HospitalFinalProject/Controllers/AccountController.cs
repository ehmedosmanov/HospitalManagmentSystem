using HospitalFinalProject.Helpers;
using HospitalFinalProject.Models;
using HospitalFinalProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HospitalFinalProject.Controllers
{
    public class AccountController : Controller
    {
        #region Identity
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager,
                           RoleManager<IdentityRole> roleManager,
                             SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        #endregion

        #region Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            AppUser appUser = await _userManager.FindByNameAsync(loginVM.Username);
            if (appUser == null)
            {
                appUser = await _userManager.FindByEmailAsync(loginVM.Username);
                if (appUser == null)
                {
                    ModelState.AddModelError("", "Email və yaxud istifadəçi adı səhv qeyd edilib");
                    return View();
                }
            }

            if (appUser.IsDeactive)
            {
                ModelState.AddModelError("", "İstifadəçi Aktiv deyildir");
                return View();
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, true, true);

            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "Limiti keçmisiniz");
                return View();
            }
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "İstifadəçi adı və şifrə səhvdir!");
                return View();

            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }
            AppUser appUser = new()
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                Email = registerVM.Email,
                UserName = registerVM.Username
            };

            IdentityResult identityResult = await _userManager.CreateAsync(appUser, password: registerVM.Password); //Qeydiyyatdan Kecmek Kodu

            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerVM);
            }

            await _signInManager.SignInAsync(appUser, true);
            await _userManager.AddToRoleAsync(appUser, Helper.Roles.Doctor.ToString());
            return RedirectToAction("Index", "Home"); //Home Sehifesine yoneldir Qeydiyyatdan ugurlu kecende
        }
        #endregion

        #region LogOut
        public async Task<IActionResult> LogOut()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        #endregion

        #region ForgotPassword
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM forgotPasswordVM)
        {
            AppUser user = await _userManager.FindByEmailAsync(forgotPasswordVM.Email);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "bele email yoxdu");
                return View();
            }
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);


            string callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, Token = token }, HttpContext.Request.Scheme, "localhost:44370");

            string body = $"Zəhmət olmasa, aşağıdakı linkə klikləməklə parolunuzu sıfırlayın: <a href='{callbackUrl}'>Reset Password</a>";


            await Helper.SendMail(callbackUrl, forgotPasswordVM.Email);



            TempData["ConfirmationMessage"] = "mektub gonderildi emaile";
            return RedirectToAction(nameof(ForgotPassword));
        }
        #endregion
        #region ResetPassword
        public async Task<IActionResult> ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return NotFound();
            }

            AppUser appUser = await _userManager.FindByIdAsync(userId);

            if (appUser == null)
            {
                return BadRequest();
            }

            ResetPasswordVM model = new ResetPasswordVM
            {
                Id = userId,
                Token = token
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string userId, string token, ResetPasswordVM resetPasswordVM)
        {
            if (userId == null || token == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(resetPasswordVM);
            }

            AppUser appUser = await _userManager.FindByIdAsync(userId);

            if (appUser == null)
            {
                return BadRequest();
            }

            IdentityResult identityResult = await _userManager.ResetPasswordAsync(appUser, token, resetPasswordVM.Password);

            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(resetPasswordVM);
            }

            return RedirectToAction("Login", "Account");
        }

        #endregion
        #region CreateRole
        //public async Task CreateRoles()
        //{
        //    if (!(await _roleManager.RoleExistsAsync(Helper.Roles.Doctor.ToString())))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = Helper.Roles.Doctor.ToString() });
        //    }
        //    if (!(await _roleManager.RoleExistsAsync(Helper.Roles.Admin.ToString())))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = Helper.Roles.Admin.ToString() });
        //    }
        //    if (!(await _roleManager.RoleExistsAsync(Helper.Roles.Moderator.ToString())))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = Helper.Roles.Moderator.ToString() });
        //    }
        //}
        #endregion
    }
}
