using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using OnlineSuperMarket.Areas.Admin.Models.ViewModel;
using OnlineSuperMarket.Data;
using OnlineSuperMarket.Models;
using System;

namespace OnlineSuperMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly OnlineSuperMarketDbContext _context;
        private UserManager<User> _userManager;
        private INotyfService _notifyService;
        private readonly IWebHostEnvironment _hostEnvironment;
        private RoleManager<IdentityRole> _roleManager;
        public UserController(UserManager<User> userManager,
            INotyfService notyfService,
            OnlineSuperMarketDbContext context,
            IWebHostEnvironment hostEnvironment,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _notifyService = notyfService;
            _context = context;
            _hostEnvironment = hostEnvironment;
            _roleManager= roleManager;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(_userManager.Users);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(string id) 
        {
            if(id == null || _context.Users.Count() == 0)
            {
                return NotFound();
            }
            
            var user = _context.Users.Where(u => u.Id == id).FirstOrDefault();
            var userrole = _context.UserRoles.Where(u => u.UserId == user.Id).FirstOrDefault();
            var role = _context.Roles.Where(n => n.Id ==    userrole.RoleId).FirstOrDefault();
            ViewData["roleName"] = role.Name;

            if(user == null)
            {
                _notifyService.Warning("Can not find this user!!");
                return RedirectToAction("Index");
            }

            return View(user);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Create() => View();

        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateVM model)
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
                    UserName= model.UserName,
                    NormalizedUserName = model.UserName.Normalize(),
                    PasswordHash = hasher.HashPassword(null, model.Password),
                    Address= model.Address,
                    PhoneNumber = model.PhoneNumber,
                    LockoutEnabled = false,
                    EmailConfirmed = true
                    
                };
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                user.Avatar = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/ClientAssets/img/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(fileStream);
                }
                IdentityResult result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");

                    _notifyService.Success("Successfully Added an admin account");
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        TempData["mess"] = error.Description.ToString();
                    }
                    return View(model);
                }
            }

            return View(model);
        
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Update(string? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var user = _context.Users.Where(u => u.Id == Id).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }

            var userrole = _context.UserRoles.Where(r => r.UserId == user.Id).FirstOrDefault();
            var role = _context.Roles.Where(n => n.Id == userrole.RoleId).FirstOrDefault();
            ViewBag.user = user;

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Update(string id, UserUpdateVM model)
        {
            var hasher = new PasswordHasher<User>();
            User user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                user.FirstName = model.FirstName;
                user.MiddleName = model.MiddleName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.NormalizedEmail = model.Email.Normalize();
                user.UserName= model.UserName;
                user.NormalizedUserName = model.UserName.Normalize();
                user.PasswordHash = hasher.HashPassword(user, model.Password);
                user.Address= model.Address;
                user.PhoneNumber = model.PhoneNumber;
                user.LockoutEnabled = model.IsLockedOut;
            };
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            string extension = Path.GetExtension(model.ImageFile.FileName);
            user.Avatar = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/ClientAssets/img/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await model.ImageFile.CopyToAsync(fileStream);
            }
            IdentityResult result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                _notifyService.Success("Successfully Added an admin account");
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    TempData["mess"] = error.Description.ToString();
                }
                return View(model);
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
               
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View("Index", _userManager.Users);
        }
    }
}
