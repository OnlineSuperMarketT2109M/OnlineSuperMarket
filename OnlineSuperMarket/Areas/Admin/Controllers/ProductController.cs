using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineSuperMarket.Data;
using X.PagedList;

namespace OnlineSuperMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly OnlineSuperMarketDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private INotyfService _notifyService;

        public ProductController(OnlineSuperMarketDbContext context, IWebHostEnvironment hostEnvironment, INotyfService notyfService)
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

            var models = from b in _context.Products select b;
            var pageNumber = page ?? 1;
            var pageSize = 5;

            return View(models.Where(s =>
                s.productName.Contains(search) ||
                search == null).ToPagedList(pageNumber, pageSize));

            return View();
        }
    }
}
