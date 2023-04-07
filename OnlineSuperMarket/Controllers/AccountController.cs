using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineSuperMarket.Models;
using OnlineSuperMarket.Models.ViewModel;
using System.Data;

namespace OnlineSuperMarket.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;
        private SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            bool isPersistent = true; // Lưu cookie = true
            bool lockoutOnFailure = false; //  Khóa tk nếu đăng nhập sai nhiều lần = false

            var user = await userManager.FindByEmailAsync(model.email);

            if (user == null)
            {
                TempData["mess"] = "Incorrect Email Address!";
                return RedirectToAction("Index", "Home");
            }

            var result = await signInManager.PasswordSignInAsync(user, model.password, isPersistent, lockoutOnFailure);

            if (result.Succeeded)
            {
                TempData["mess"] = "Dang nhap thanh cong";
            }
            else if (result.IsLockedOut)
            {
                // user is locked out
                TempData["mess"] = "Tai khoan bi khoa";
            }
            else if (result.IsNotAllowed)
            {
                TempData["mess"] = "Tai khoan chua xac minh";
            }
            else
            {
                Console.WriteLine(result.ToString());
                // authentication failed
                TempData["mess"] = "Sai tk hoac mk";
            }
            return PartialView("_LoginPartialView");
        }


        //public async Task<ActionResult> Register()
        //{
        //    string password = "Acn@2003";
        //    User user = new User()
        //    {
        //        Email = "vuvietquyacn@gmail.com",
        //        UserName = "vuvietquyacn"
        //    };

        //    var result = await userManager.CreateAsync(user, password);

        //    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

        //    string confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token }, Request.Scheme);

        //    Console.WriteLine(confirmationLink);



        //    if (result.Succeeded)
        //    {
        //        await userManager.AddToRoleAsync(user, "User");
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            TempData["mess"] = error.Description.ToString();
        //        }
        //    }

        //    return RedirectToAction("Index");

        //}

        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<IActionResult> ConfirmEmail(string userId, string token)
        //{
        //    if (userId == null || token == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    var user = await userManager.FindByIdAsync(userId);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    var result = await userManager.ConfirmEmailAsync(user, token);
        //    if (result.Succeeded)
        //    {
        //        TempData["mess"] = "Xác minh email thành công";
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        TempData["mess"] = "Xác minh email thất bại";
        //        return RedirectToAction("Index");
        //    }
        //}

        //public string AccessDenied(string ReturnUrl)
        //{
        //    return $"Bạn không có quyền truy cập vào đường dẫn {ReturnUrl}";
        //}
    }
}
