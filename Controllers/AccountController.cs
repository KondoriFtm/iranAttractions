﻿using iranAttractions.data;
using iranAttractions.Models;
using iranAttractions.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace iranAttractions.Controllers
{
    public class AccountController : Controller
    {
        private MyDbContext _dbContext;

        public AccountController(MyDbContext context)
        {
            _dbContext = context;

        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return View();
            }

            var user = _dbContext.User.SingleOrDefault(u => u.Phonenumber == model.phonenumber);
            if (user == null) //means no usr with such a UserID Is available
            {

                ModelState.AddModelError("phonenumber", "شما قبلا ثبت نام نکرده اید");
                return View(model);

            }

            //the user has been registered so can login
            if (user.password == model.password)
            {
                //save the user informations in cookies
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Phonenumber.ToString()),
                        new Claim(ClaimTypes.MobilePhone, user.Phonenumber),
                                                new Claim("Role", user.Role),


                    };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var properties = new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe
                };

                HttpContext.SignInAsync(principal, properties);
                if(user.Role == "Admin")
                {
                    return RedirectToAction("Admin", "Admin");

                }
                return RedirectToAction("Privacy", "Home");
            }
            else
            {
                ModelState.AddModelError("Password", "رمز عبور اشتباه است");
                return View(model);
            }


        }


        public IActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel Register)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            //see if a user with the entered phonenumber is available in database
            var user = _dbContext.User.SingleOrDefault(u => u.Phonenumber == Register.phonenumber);

            
            if (user != null) 
            {
                ModelState.AddModelError("", "شما قبلا ثبت نام کرده اید لطفا وارد شوید ");
                return View();
            }
            if (Register.password != Register.Repeatpassword)
            {
                ModelState.AddModelError("", "رمز عبور با تکرار رمز مطابقت ندارد");
                return View();

            }

            //if there was not a user with phonenumber enterd by user 
            //and the paasword is equal to repeatPasword 
            //then a new user instance is made
            User newuser = new User
            {
                UserName = Register.username,
                Phonenumber = Register.phonenumber,
                password = Register.password,
                Role = "User"
            };

            _dbContext.User.Add(newuser);
            _dbContext.SaveChanges();

            //save the user informations in cookies
            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, newuser.Phonenumber.ToString()),
                        new Claim(ClaimTypes.MobilePhone, newuser.Phonenumber),
                        new Claim(ClaimTypes.Role, newuser.Role),


                    };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent =true
            };

            HttpContext.SignInAsync(principal, properties);

            return RedirectToAction("privacy", "home");
        }

        public IActionResult Register()
        {
            return View();

        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Account/Login");
        }
         
    }
}
