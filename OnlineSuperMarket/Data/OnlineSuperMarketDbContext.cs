using OnlineSuperMarket.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace OnlineSuperMarket.Data
{
    public class OnlineSuperMarketDbContext : IdentityDbContext<User>
    {
        public OnlineSuperMarketDbContext(DbContextOptions<OnlineSuperMarketDbContext> options)
            : base(options)
        {
        }



        public virtual DbSet<Blog> Blogs { get; set; }

        public virtual DbSet<BlogComment> BlogComments { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }

        public virtual DbSet<ProductComment> ProductComments { get; set; }

        public virtual DbSet<ProductDetail> ProductDetails { get; set; }

        public virtual DbSet<ProductImage> ProductImages { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedRoles(builder);
            this.SeedUsers(builder);
            this.SeedUserRoles(builder);
        }


        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole() { Id = "2", Name = "Customer", NormalizedName = "CUSTOMER" }
                );
        }
        private void SeedUsers(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<User>();
            builder.Entity<User>().HasData(
                new User
                {
                    Id = "1",
                    FirstName = "Dinh",
                    MiddleName = "Quang",
                    LastName = "Anh",
                    UserName = "AnhDinh",
                    NormalizedUserName = "anhdinh",
                    Email = "anhdqth2109005@fpt.edu.vn",
                    NormalizedEmail ="anhdqth2109005@fpt.edu.vn",
                    EmailConfirmed = true,
                    PasswordHash= hasher.HashPassword(null, "123456"),
                    PhoneNumber = "0395100761",
                    Address = "Ninh Binh",
                    Avatar = "default.png",
                    LockoutEnabled = false,
                },

                new User
                {
                    Id = "2",
                    FirstName = "Nguyen",
                    MiddleName = "Ba",
                    LastName = "Khanh",
                    UserName = "KhanhNguyen",
                    NormalizedUserName = "khanhnguyen",
                    Email = "khanhnb08112003@gmail.com",
                    NormalizedEmail ="khanhnb08112003@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash= hasher.HashPassword(null, "123456"),
                    PhoneNumber = "0123456789",
                    Address = "Ha Noi",
                    Avatar = "default.png",
                    LockoutEnabled = false,
                },

                new User
                {
                    Id = "3",
                    FirstName = "Luong",
                    MiddleName = "Viet",
                    LastName = "Hoang",
                    UserName = "HoangLuong",
                    NormalizedUserName = "hoangluong",
                    Email = "hoanglt123@gmail.com",
                    NormalizedEmail ="hoanglt123@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash= hasher.HashPassword(null, "123456"),
                    PhoneNumber = "1234567890",
                    Address = "Ha Long",
                    Avatar = "default.png",
                    LockoutEnabled = false,
                }
            );
        }
        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "1", UserId = "2" },
                new IdentityUserRole<string>() { RoleId = "1", UserId = "3" },
                new IdentityUserRole<string>() { RoleId = "2", UserId = "1" }
                );
        }
    }
}