using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Talabat.APIs.Dtos;
using Talabat.Core.Entities.Identity;

namespace AdminDashboard.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AdminController(UserManager<AppUser>userManager,SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Login(LoginDto login)
        //{
        //    var user = await userManager.FindByEmailAsync(login.Email);
        //    if(user ==null)
        //    {
        //        ModelState.AddModelError("Email", "Email Is Invalid");
        //        return RedirectToAction(nameof(Login));
        //    }
        //    var result = await signInManager.CheckPasswordSignInAsync(user, login.Password, false);
        //    if (!result.Succeeded || !await userManager.IsInRoleAsync(user, "Admin"))
        //    {
        //        ModelState.AddModelError(string.Empty, "you Are Not Authorized");
        //        return RedirectToAction(nameof(Login));
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(loginViewModel.Email);
                if (user is not null)
                {
                    var password = await userManager.CheckPasswordAsync(user, loginViewModel.Password);
                    if (password)
                    {
                        var result = await signInManager.CheckPasswordSignInAsync(user, loginViewModel.Password, false);
                        if (!result.Succeeded || !await userManager.IsInRoleAsync(user, "Admin"))
                        {
                            ModelState.AddModelError(string.Empty, "you Are Not Authorized");
                            return RedirectToAction(nameof(Login));
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Password");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Email");
                }
            }
            return View(loginViewModel);

        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
