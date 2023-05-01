using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineSuperMarket.Data;
using OnlineSuperMarket.Models;
using OnlineSuperMarket.Models.ViewModel;
using System.Diagnostics;
using System.Linq;

namespace OnlineSuperMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OnlineSuperMarketDbContext _context;

        public HomeController(ILogger<HomeController> logger, OnlineSuperMarketDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {

            dynamic productsOnSale = _context.Products
                                    .Where(p => p.status.Contains("sale"))
                                    .Include(p => p.productImages)
                                    .Select(p => new ProductViewModel
                                    {
                                        productId = p.productId,
                                        productName = p.productName,
                                        productImage = p.productImages.FirstOrDefault().productImage,
                                        unitCost = p.unitCost * 90 / 100,
                                        brandName = p.Brand.brandName,
                                        categoryName = p.Category.categoryName
                                    })
                                    .Take(5)
                                    .OrderByDescending(p => p.productId)
                                    .ToList();
            ViewBag.productOnSaleSlides = productsOnSale;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}