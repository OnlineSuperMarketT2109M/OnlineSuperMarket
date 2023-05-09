using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using OnlineSuperMarket.Areas.Admin.Models.ViewModel;
//using OnlineSuperMarket.Components;
using OnlineSuperMarket.Data;
using OnlineSuperMarket.Models;
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

                           
            var pageNumber = page ?? 1;
            var pageSize = 5;
            var models = _context.Products
                        .Include(p => p.Category)
                        .Include(p => p.Brand)
                        .AsNoTracking();

            return View(models.Where(p => p.productName.Contains(search) || search == null)
                           .ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var categories = _context.Categories.ToList();
            SelectList categoryList = new SelectList(categories, "categoryId", "categoryName");
            ViewBag.Categories = categoryList;
            var brands = _context.Brands.ToList();
            SelectList brandList = new SelectList(brands, "brandId", "brandName");
            ViewBag.Brands = brandList;
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM model)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product()
                {
                    productName = model.Name,
                    unitCost = model.unitCost,
                    description= model.description,
                    quantity= model.quantity,
                    categoryId= model.categoryId,
                    brandId= model.brandId,
                    size= model.size,
                    color= model.color,
                };
                _context.Add(product);
                _context.SaveChanges();
                
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.formFile.FileName);
                string extension = Path.GetExtension(model.formFile.FileName);
                string path = Path.Combine(wwwRootPath + "/ClientAssets/img/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await model.formFile.CopyToAsync(fileStream);
                }
                ProductImage productImage = new ProductImage()
                {
                    productId = product.productId,
                    productImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension
                };
                _context.Add(productImage);

                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.productImage = _context.ProductImages.Where(t => t.productId== product.productId).First();
            ViewBag.product = product;
            var categories = _context.Categories.ToList();
            SelectList categoryList = new SelectList(categories, "categoryId", "categoryName");
            ViewBag.Categories = categoryList;
            var brands = _context.Brands.ToList();
            SelectList brandList = new SelectList(brands, "brandId", "brandName");
            ViewBag.Brands = brandList;

            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditVM model, int id)
        {
            if (ModelState.IsValid)
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                product.productId = model.ID;
                product.productName = model.Name ?? product.productName;
                product.description = model.description ?? product.description;
                product.quantity = model.quantity ?? product.quantity;
                product.unitCost = model.unitCost ?? product.unitCost;
                product.brandId = model.brandId ?? product.brandId;
                product.categoryId = model.categoryId?? product.categoryId;
                product.color = model.color ?? product.color;
                product.size = model.size ?? product.size;
                _context.Update(product);
                _context.SaveChanges();

                var productImage = _context.ProductImages.Where(i => i.productId == id).First();
                if (model.formFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(model.formFile.FileName);
                    string extension = Path.GetExtension(model.formFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/ClientAssets/img/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await model.formFile.CopyToAsync(fileStream);
                    }
                    productImage.productImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                }
                else
                {
                    productImage.productImage = productImage.productImage;
                }
                _context.Update(productImage);
                _context.SaveChanges();
                return RedirectToAction("Index"); 
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.Products.Count() == 0)
            {
                return NotFound();
            }
            var product = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Where(p => p.productId == id).FirstOrDefault();

            var productImage = _context.ProductImages.Where(i => i.productId == id).Select(i => i.productImage).FirstOrDefault();

            ViewBag.ProductImage = productImage;

            return View(product);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            
            var product = _context.Products.Where(p => p.productId == id).FirstOrDefault();
            var productImage = _context.ProductImages.Where(s => s.productId == id).FirstOrDefault();


            _context.ProductImages.Remove(productImage);
;
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
