using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OnlineSuperMarket.Data;
using OnlineSuperMarket.Models;
using OnlineSuperMarket.Models.ViewModel;
using OnlineSuperMarket.Services.VnPay;

namespace OnlineSuperMarket.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        private readonly OnlineSuperMarketDbContext _context;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private readonly IConfiguration config;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProductController(ILogger<ProductController> logger, OnlineSuperMarketDbContext context, UserManager<User> userManager, SignInManager<User> signInManager,
            IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            this.config = config;
            this.httpContextAccessor = httpContextAccessor;
        }
        public const string CARTKEY = "cart";

        // Lấy cart từ Session (danh sách CartItem)
        List<CartItem> GetCartItems()
        {

            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }

        // Xóa cart khỏi session
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        // Lưu Cart (Danh sách CartItem) vào session
        void SaveCartSession(List<CartItem> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
            session.SetString(CARTKEY, jsoncart);
        }

        public IActionResult Index()
        {
            return View();
        }


        /// Thêm sản phẩm vào cart
        [Route("addcart/{productid:int}", Name = "addcart")]
        public IActionResult AddToCart([FromRoute] int productid)
        {

            var product = _context.Products
                
                .Include(p => p.Brand)
                .FirstOrDefault(p => p.productId == productid);
            var productImage = _context.ProductImages.FirstOrDefault(p => p.productId == productid);
            if (product == null)
                return NotFound("No product");

            // Xử lý đưa vào Cart ...
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.productId == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cartitem.quantity++;
            }
            else
            {
                //  Thêm mới
                cart.Add(new CartItem() { quantity = 1, product = product, productImage = productImage });
            }

            // Lưu cart vào Session
            SaveCartSession(cart);
            // Chuyển đến trang hiện thị Cart
            return RedirectToAction(nameof(Cart));
        }

        // Hiện thị giỏ hàng
        [Route("/cart", Name = "cart")]
        public IActionResult Cart()
        {
            return View(GetCartItems());
        }

        /// Cập nhật
        [Route("/updatecart", Name = "updatecart")]
        [HttpPost]
        public IActionResult UpdateCart([FromForm] int productid, [FromForm] int quantity)
        {
            // Cập nhật Cart thay đổi số lượng quantity ...
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.productId == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cartitem.quantity = quantity;
            }
            SaveCartSession(cart);
            Console.WriteLine($"Product ID: {productid}, Quantity: {quantity}");
            // Trả về mã thành công (không có nội dung gì - chỉ để Ajax gọi)
            return Ok();
        }

        /// xóa item trong cart
        [Route("/removecart/{productid:int}", Name = "removecart")]
        public IActionResult RemoveCart([FromRoute] int productid)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.productId == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cart.Remove(cartitem);
            }

            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }

        public IActionResult CreateOrder()
        {
            var cart = GetCartItems();
            ViewBag.Cart = cart;

            return View();
        }
        [HttpPost]
        public IActionResult CreateOrder(CheckoutViewModel model)
        {
            if(ModelState.IsValid)
            {
                var cart = GetCartItems();
                var user = _userManager.GetUserAsync(User);
                if (user != null)
                {
                    Order order = new Order()
                    {
                        userId = user.Id,
                        Address= model.Address,
                        total = cart.Sum(x => x.TotalMoney),
                        orderStatus = "No process",
                        purchaseDate= DateTime.Now,
                    };
                    _context.Add(order);
                    _context.SaveChanges();

                    foreach (var item in cart)
                    {
                        OrderDetails orderDetails = new OrderDetails()
                        {
                            OrderId = order.orderId,
                            ProductId = item.product.productId,
                            Amount = item.quantity,
                            TotalMoney = item.TotalMoney,
                            Price = item.product.unitCost,
                            CreateDate = DateTime.Now,
                        };
                        _context.Add(orderDetails);
                        _context.SaveChanges();
                    }

                    var Payment = new VnPayService(config, httpContextAccessor);

                    string paymentVnPayUrl = Payment.getPaymentUrl(order);

                    return Redirect(paymentVnPayUrl);
                }

            }

            return View();
        }

        [HttpGet]
        public string CheckOut()
        {
            string Message = null;
            var Request = HttpContext.Request;


            string hashSecret = config["VnPay:HashSecret"]; //Chuỗi bí mật

            var vnpayData = Request.Query.ToDictionary(x => x.Key, x => x.Value.ToString());
            PayLib pay = new PayLib();

            if (vnpayData.Count()<1)
            {
                return "Đơn hàng chưa được khởi tạo";
            };

            //lấy toàn bộ dữ liệu được trả về
            foreach (KeyValuePair<string, string> pair in vnpayData)
            {
                string key = pair.Key;
                string value = pair.Value;

                if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                {
                    pay.AddResponseData(key, value);
                }
            }

            long orderId = Convert.ToInt64(pay.GetResponseData("vnp_TxnRef")); //mã hóa đơn
            long vnpayTranId = Convert.ToInt64(pay.GetResponseData("vnp_TransactionNo")); //mã giao dịch tại hệ thống VNPAY
            string vnp_ResponseCode = pay.GetResponseData("vnp_ResponseCode"); //response code: 00 - thành công, khác 00 - xem thêm https://sandbox.vnpayment.vn/apis/docs/bang-ma-loi/
            string vnp_SecureHash = Request.Query["vnp_SecureHash"]; //hash của dữ liệu trả về

            bool checkSignature = pay.ValidateSignature(vnp_SecureHash, hashSecret); //check chữ ký đúng hay không?

            if (checkSignature)
            {
                if (vnp_ResponseCode == "00")
                {
                    //Thanh toán thành công
                    Message = "Thanh toán thành công hóa đơn " + orderId + " | Mã giao dịch: " + vnpayTranId;
                }
                else
                {
                    //Thanh toán không thành công. Mã lỗi: vnp_ResponseCode
                    Message = "Có lỗi xảy ra trong quá trình xử lý hóa đơn " + orderId + " | Mã giao dịch: " + vnpayTranId + " | Mã lỗi: " + vnp_ResponseCode;
                }
            }
            else
            {
                Message = "Có lỗi xảy ra trong quá trình xử lý";
            }

            return Message;
        }

    }
}
