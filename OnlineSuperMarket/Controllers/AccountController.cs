using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MimeKit;
using OnlineSuperMarket.Areas.Admin.Models.ViewModel;
using OnlineSuperMarket.Data;
using OnlineSuperMarket.Models;
using OnlineSuperMarket.Models.ViewModel;
using System.Data;
using System.Web.Helpers;

namespace OnlineSuperMarket.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<User> _signInManager;
        private INotyfService _notifyService;
        private readonly OnlineSuperMarketDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AccountController(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManager,
            INotyfService notyfService,
            OnlineSuperMarketDbContext context,
            IWebHostEnvironment hostEnvironment)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
            this._notifyService= notyfService;
            _context= context;
            _hostEnvironment=hostEnvironment;
        }

        public async Task<ActionResult> Login([FromForm] string email, string password)
        {
            bool isPersistent = true; // Lưu cookie = true
            bool lockoutOnFailure = false; //  Khóa tk nếu đăng nhập sai nhiều lần = false


            var user = await _userManager.FindByEmailAsync(email);
            
            if (user == null)
            {
                _notifyService.Error("Incorrect email!");
                return RedirectToAction("Index", "Home");
            }

            var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);

            var role = await _userManager.GetRolesAsync(user);

            if (result.Succeeded)
            {
                if (role.FirstOrDefault() == "Admin")
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else if (result.IsLockedOut)
            {
                // user is locked out
                _notifyService.Error("Your account is locked out!");
            }
            else if (result.IsNotAllowed)
            {
                _notifyService.Error("Your account is not verified!");
            }
            else
            {
                // authentication failed
                _notifyService.Error("Incorrect Email or Password!");
            }
            return RedirectToAction("Index", "Home");
        }


        public async Task<ActionResult> Register(RegisterViewModel model)
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
                    UserName = model.Username,
                    NormalizedUserName = model.Username.Normalize(),
                    PhoneNumber = model.PhoneNumber,
                    PasswordHash = hasher.HashPassword(null, model.Password),
                    Address = model.Address,
                    EmailConfirmed = true,
                    Avatar = "default-avatar.webp"
                };

                var result = await _userManager.CreateAsync(user);
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                /*string confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token }, Request.Scheme);*/

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Customer");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _notifyService.Success("Successfully! Welcome to OnlineSuperMarket!");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        TempData["mess"] = error.Description.ToString();
                    }
                    return View();
                }
                
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                TempData["mess"] = "Xác minh email thành công";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["mess"] = "Xác minh email thất bại";
                return RedirectToAction("Index");
            }
        }

        public string AccessDenied(string ReturnUrl)
        {
            return $"Bạn không có quyền truy cập vào đường dẫn {ReturnUrl}";
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return NotFound();
            }

            UserViewModel model = new UserViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                Avatar = user.Avatar,
                UserName = user.UserName
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserInfo([FromBody] UserViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            user.UserName = model.UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.EmailConfirmed = true;
            user.PhoneNumber = model.PhoneNumber;
            user.Address = model.Address;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(string currentPassword, string newPassword, string newPasswordConfirm)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            // Kiểm tra xem currentPassword có giống với password của user không
            var passwordCheck = await _userManager.CheckPasswordAsync(user, currentPassword);
            if (!passwordCheck)
            {
                return BadRequest(new { Errors = "Current password is incorrect." });
            }

            // Kiểm tra xem newPassword có giống newPasswordConfirm không
            if (newPassword != newPasswordConfirm)
            {
                return BadRequest(new { Errors = "New password and confirm password do not match." });
            }

            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new { Errors = errors });
            }

            await _signInManager.RefreshSignInAsync(user);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeAvatar(IFormFile ImageFile)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            if (ImageFile == null || ImageFile.Length == 0)
            {
                return BadRequest("No file selected");
            }

            if (!ImageFile.ContentType.Contains("image"))
            {
                return BadRequest("File is not an image");
            }

            if (ImageFile.Length > 1 * 1024 * 1024)
            {
                return BadRequest("File is too large");
            }

            // Save the image to the wwwroot folder
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            string extension = Path.GetExtension(ImageFile.FileName);
            user.Avatar = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/ClientAssets/img/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await ImageFile.CopyToAsync(fileStream);
            }


            // Update the user's avatar
            user.Avatar = fileName;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest("Unable to update user's avatar");
            }

            return Ok("Avatar updated successfully");
        }

        public async Task<IActionResult> MyOrder()
        {
            var userId = _userManager.GetUserId(User);
            if(userId == null)
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
                        .Where(o => o.User.Id == userId)
                        .ToList();
           
            var orderPending = orders.Where(o => o.orderStatus == "Pending").ToList();
            var orderProcessing = orders.Where(o => o.orderStatus == "Processing").ToList();
            var orderCompleted = orders.Where(o => o.orderStatus == "Completed").ToList();
            var orderCanceled = orders.Where(o => o.orderStatus == "Canceled").ToList();

            MyOrderViewModel model = new MyOrderViewModel()
            {
                orders= orders,
                orderPending= orderPending,
                orderProcessing= orderProcessing,
                orderCompleted= orderCompleted,
                orderCanceled= orderCanceled,
            };

            return View(model);
        }
    }
}
