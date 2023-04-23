using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineSuperMarket.Data;
using OnlineSuperMarket.Models;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace OnlineSuperMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly OnlineSuperMarketDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private INotyfService _notifyService;
        public BrandController(OnlineSuperMarketDbContext context, IWebHostEnvironment hostEnvironment, INotyfService notyfService)
        { 
            _context = context;
            _hostEnvironment = hostEnvironment;
            _notifyService = notyfService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index(string search, int? page, string sortOrder, string currentFilter)
        {
            ViewData["CurrentSort"] = sortOrder;
            if(search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }

            ViewData["CurrentFilter"] = search;

            var models = from b in _context.Brands select b;
            var pageNumber = page ?? 1;
            var pageSize = 5;

            return View(models.Where(s =>
                s.brandName.Contains(search) ||
                search == null).ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create() => View();

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("brandId, brandName")] Brand brand, [Required] string Name)
        {
            brand.brandName = Name;
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();

            _notifyService.Success("Added 1 Brand!");
            return RedirectToAction("Index");
        }

        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Brands == null)
            {
                return Problem("Entity set 'OnlineSuperMarketDbContext.Brands'  is null.");
            }
            var brand = await _context.Brands.FindAsync(id);
           
            if (brand != null)
            {
                _context.Brands.Remove(brand);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool BrandExists(int id)
        {
            return (_context.Brands?.Any(e => e.brandId == id)).GetValueOrDefault();
        }
    }
}
