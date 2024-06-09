using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.MvcWebUI.Identity;
using TestProject.MvcWebUI.Models.Security;

namespace TestProject.MvcWebUI.Controllers
{
    public class SecurityController : Controller
    {
        private UserManager<AppIdentityUser> _userManager;
        private RoleManager<AppIdentityRole> _roleManager;
        private SignInManager<AppIdentityUser> _signInManager;

        public SecurityController(UserManager<AppIdentityUser> userManager, RoleManager<AppIdentityRole> roleManager, SignInManager<AppIdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (user !=null)
                {
                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError(string.Empty, "Confirm your email please!");
                        return View(loginViewModel);
                    }
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, true);
                    if (result.Succeeded)
                    {
                        if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);

                        }
                        else
                        {
                            return View(loginViewModel);
                        }
                    }
                    ModelState.AddModelError(String.Empty, "Login failed!");
                    return View(loginViewModel);
                }
                return View(loginViewModel);
            }
            return View(loginViewModel);
        }
    }
}
