using System;
using System.Collections.Generic;
using System.Linq;
using K401Ecommerce.Entities.Concrete;
using K401Ecommerce.Entities.DTOs.UserDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K401Ecommerce.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: /<controller>/
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO userLogin)
        {
            var user = await _userManager.FindByEmailAsync(userLogin.Email);
            if (user == null)
            {
                return View();
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user,userLogin.Password,true,true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }



        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDTO userRegister)
        {
            var user = await _userManager.FindByEmailAsync(userRegister.Email);

            if (user != null)
            {
                return View();
            }

            User newUser = new()
            {
                FirstName = userRegister.FirstName,
                LastName = userRegister.LastName,
                Address = "",
                Email = userRegister.Email,
                UserName = userRegister.Email
            };

            var result = await _userManager.CreateAsync(newUser, userRegister.Password);

            if (result.Succeeded)
            {
                await _signInManager.PasswordSignInAsync(newUser, userRegister.Password, true, true);
                return RedirectToAction("Index","Home");
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}

