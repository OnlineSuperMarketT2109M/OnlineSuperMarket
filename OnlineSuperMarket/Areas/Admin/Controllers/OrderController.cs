using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineSuperMarket.Data;
using X.PagedList;

namespace OnlineSuperMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly OnlineSuperMarketDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private INotyfService _notifyService;

        public OrderController(OnlineSuperMarketDbContext context, IWebHostEnvironment hostEnvironment, INotyfService notyfService)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _notifyService = notyfService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index(string search, int? page, string currentFilter)
        {
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
            var pageSize = 10;

            var model = _context.Orders
                        .Include(o => o.User)
                        .Include(o => o.OrderDetails)
                        .AsNoTracking();
            return View(model.Where(m => m.orderStatus.Contains(search) || search == null).ToPagedList(pageNumber, pageSize));
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id)
        {
            var isorderexist = _context.Orders.FirstOrDefault(o => o.orderId == id);
            if (isorderexist == null)
            {
                return NotFound();
            } 

            var orders = _context.Orders
                        .Include(o => o.User)
                        .Include(o => o.OrderDetails)
                            .ThenInclude(o => o.Product)
                                .ThenInclude(o => o.productImages)
                        .Include(o => o.OrderDetails)
                            .ThenInclude(o => o.Product)
                                .ThenInclude(o => o.Brand)
                        .Include(o => o.OrderDetails)
                            .ThenInclude(o => o.Product)
                                .ThenInclude(o => o.Category)
                        .Where(o => o.orderId == id)
                        .AsNoTracking()
                        .FirstOrDefault();

            return View(orders);
        }

        [HttpPost]
        [Route("Order/ChangeOrderStatus")]
        public IActionResult ChangeOrderStatus(int orderId, string status)
        {
            var order = _context.Orders.Where(o => o.orderId == orderId).FirstOrDefault();
            if (order == null)
            {
                return NotFound();
            }
            order.orderStatus= status;
            _context.Update(order);
            _context.SaveChanges();
            return Ok();
        }
    }
}
