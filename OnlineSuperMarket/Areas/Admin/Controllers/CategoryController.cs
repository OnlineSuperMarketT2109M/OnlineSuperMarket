using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineSuperMarket.Data;
using OnlineSuperMarket.Models;
using System.ComponentModel.DataAnnotations;
using System.Data;
using X.PagedList;

namespace OnlineSuperMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly OnlineSuperMarketDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private INotyfService _notifyService;

        public CategoryController(OnlineSuperMarketDbContext context, IWebHostEnvironment hostEnvironment, INotyfService notyfService)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _notifyService = notyfService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index(string search, int? page, string sortOrder, string currentFilter)
        {
            ViewData["CurrentSort"] = sortOrder;
            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }

            ViewData["CurrentFilter"] = search;

            var models = from b in _context.Categories select b;
            var pageNumber = page ?? 1;
            var pageSize = 5;

            return View(models.Where(s =>
                s.categoryName.Contains(search) ||
                search == null).ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create() => View();

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("categoryId, categoryName")] Category category, [Required] string Name)
        {
            category.categoryName = Name;
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            _notifyService.Success("Added 1 Category!");
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'OnlineSuperMarketDbContext.Categories'  is null.");
            }
            var category = await _context.Categories.FindAsync(id);

            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool CategoryExists(int id)
        {
            return (_context.Categories?.Any(e => e.categoryId == id)).GetValueOrDefault();
        }
    }
}
