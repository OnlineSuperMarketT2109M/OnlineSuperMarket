﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineSuperMarket.Data;
using OnlineSuperMarket.Migrations;
using OnlineSuperMarket.Models;
using OnlineSuperMarket.Models.ViewModel;
using System.Data;
using System.Web.Helpers;

namespace OnlineSuperMarket.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
        }
        
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            bool isPersistent = true; // Lưu cookie = true
            bool lockoutOnFailure = true; //  Khóa tk nếu đăng nhập sai nhiều lần = false


            var user = await _userManager.FindByEmailAsync(model.email.ToUpper());
            
            if (user == null)
            {
                TempData["mess"] = "Sai email";
                return RedirectToAction("Index", "Home");
            }



            var result = await _signInManager.PasswordSignInAsync(user, model.password, isPersistent, lockoutOnFailure);

            var role = await _userManager.GetRolesAsync(user);

            if (result.Succeeded)
            {
                TempData["mess"] = "Dang nhap thanh cong";
                if (role.FirstOrDefault() == "Admin")
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else if (result.IsLockedOut)
            {
                // user is locked out
                TempData["mess"] = "Tai khoan bi khoa";
            }
            else if (result.IsNotAllowed)
            {
                TempData["mess"] = "Tai khoan chua xac minh";
            }
            else
            {
                Console.WriteLine(result.ToString());
                // authentication failed
                TempData["mess"] = "Sai tk hoac mk";
            }
            return RedirectToAction("Index", "Home");
        }


        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var hasher = new PasswordHasher<User>();
                User user = new User()
                {
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Email = model.Email,
                    NormalizedEmail = model.Email.Normalize(),
                    UserName = model.Username,
                    NormalizedUserName = model.Username.Normalize(),
                    PhoneNumber = model.PhoneNumber,
                    PasswordHash = hasher.HashPassword(null, model.Password),
                    Address = model.Address,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user);
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                /*string confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token }, Request.Scheme);*/

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Customer");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        TempData["mess"] = error.Description.ToString();
                    }
                    return View();
                }
                
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                TempData["mess"] = "Xác minh email thành công";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["mess"] = "Xác minh email thất bại";
                return RedirectToAction("Index");
            }
        }

        public string AccessDenied(string ReturnUrl)
        {
            return $"Bạn không có quyền truy cập vào đường dẫn {ReturnUrl}";
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
