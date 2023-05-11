using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineSuperMarket.Data;
using OnlineSuperMarket.Data.SeedData;
using OnlineSuperMarket.Mail;
using OnlineSuperMarket.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(cfg => {
    cfg.Cookie.Name = "CartSession";
    cfg.IdleTimeout = new TimeSpan(0, 30, 0);
    cfg.Cookie.IsEssential= true;
});

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("OnlineSuperMarketDbContext") ?? throw new InvalidOperationException("Connection string 'OnlineSuperMarketDbContext.");
builder.Services.AddDbContext<OnlineSuperMarketDbContext>(options =>
    options.UseSqlServer(connectionString));



builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true; // Xác minh email = true
})
    .AddEntityFrameworkStores<OnlineSuperMarketDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin",
            policy => policy.RequireClaim(claimType: System.Security.Claims.ClaimTypes.Role, "Admin"));
    options.AddPolicy("Customer",
            policy => policy.RequireClaim(claimType: System.Security.Claims.ClaimTypes.Role, "Customer"));
});
            


builder.Services.AddControllersWithViews();
builder.Services.AddNotyf(config => { config.DurationInSeconds = 1; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<ISendMailService, SendMailService>();


var app = builder.Build();

//Seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

//// Mail
//builder.Services.AddOptions();                                        // Kích hoạt Options
//var mailsettings = Configuration.GetSection("MailSettings");            // đọc config
//builder.Services.Configure<MailSettings>(mailsettings);               // đăng ký để Inject
//builder.Services.AddTransient<IEmailSender, SendMailService>();        // Đăng ký dịch vụ Mail

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
 
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.Use(async (context, next) =>
{
    var user = context.User;
    if (user.Identity.IsAuthenticated && user.IsInRole("Admin") && context.Request.Path.StartsWithSegments("/"))
    {
        context.Response.Redirect("/Admin"); // redirect to admin area
        return;
    }

    await next.Invoke(); // Cho phép request tiếp tục được xử lý bởi middleware khác trong pipeline.
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "admin",
        pattern: "admin/{controller=Home}/{action=Index}/{id?}",
        defaults: new { area = "Admin" },
        constraints: new { role = "Admin" }
    );

    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//       name: "areas",
//       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//     );
//    endpoints.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//    endpoints.MapAreaControllerRoute(
//                         name: "Admin",
//                         areaName: "Admin",
//                         pattern: "Admin/{controller=Home}/{action=Index}"
//                     );
//});

app.Run();