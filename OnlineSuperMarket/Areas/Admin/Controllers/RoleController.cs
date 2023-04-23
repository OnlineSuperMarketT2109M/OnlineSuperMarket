using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineSuperMarket.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineSuperMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private INotyfService _notifyService;
        public RoleController (RoleManager<IdentityRole> roleManager, INotyfService notyfService)
        {
            _roleManager = roleManager;
            _notifyService = notyfService;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            
            return View(_roleManager.Roles);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create() => View();

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([Required] string Name)
        {
            
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(Name));
                if (result.Succeeded) { 
                   
                    return RedirectToAction("Index");
                }
                else { 
                   
                    _notifyService.Error("Failed!!");
                    return View();
                }
            }
            
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    _notifyService.Error("Failed!!");
                    return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Index", _roleManager.Roles);
        }
    }
}
