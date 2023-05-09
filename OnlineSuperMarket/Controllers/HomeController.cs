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
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OnlineSuperMarketDbContext _context;

        public HomeController(ILogger<HomeController> logger, OnlineSuperMarketDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Authorize(Policy = "Customer")]
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
                                        categoryName = p.Category.categoryName,
                                        status= p.status,
                                        size= p.size,
                                        color= p.color,
                                        quantity= p.quantity,
    
                                    })
                                    .Take(10)
                                    .OrderByDescending(p => p.productId)
                                    .ToList();
            dynamic topTelevisions = _context.Products
                                    .Where(p => p.Category.categoryName == "Televisions")
                                    .Include(p => p.productImages)
                                    .Select(p => new ProductViewModel
                                    {
                                        productId = p.productId,
                                        productName = p.productName,
                                        productImage = p.productImages.FirstOrDefault().productImage,
                                        unitCost = p.unitCost * 90 / 100,
                                        brandName = p.Brand.brandName,
                                        categoryName = p.Category.categoryName,
                                        status= p.status,
                                        size= p.size,
                                        color= p.color,
                                        quantity= p.quantity
                                    })
                                    .Take(10)
                                    .OrderByDescending(p => p.productId)
                                    .ToList();
            ViewBag.productOnSaleSlides = productsOnSale;
            ViewBag.topTelevisions = topTelevisions;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult ContactUs()
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