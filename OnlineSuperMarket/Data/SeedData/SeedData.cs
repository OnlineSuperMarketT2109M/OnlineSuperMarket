using Microsoft.EntityFrameworkCore;
using System.Data;
using System;
using OnlineSuperMarket.Models;

namespace OnlineSuperMarket.Data.SeedData
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceprovider)
        {
            using (var context = new OnlineSuperMarketDbContext(
            serviceprovider.GetRequiredService<
                DbContextOptions<OnlineSuperMarketDbContext>>()))
            {
                if (context.Categories.Any())
                {
                    return;
                }

                // Category 
                var categories = new Category[]
                {
                    new Category { categoryName = "Houseware"},
                    new Category { categoryName = "Clothes" },
                    new Category { categoryName = "Footwear" },
                    new Category { categoryName = "Laptops & Computers" },
                    new Category { categoryName = "Mobilephones & Tablets" },
                    new Category { categoryName = "Cameras" },
                    new Category { categoryName = "Televisions" },
                    new Category { categoryName = "Refrigerator" },
                    new Category { categoryName = "Furniture" },
                    new Category { categoryName = "Gaming & Accessories" },
                    new Category { categoryName = "Audio & Video" },
                    new Category { categoryName = "Phone Accessories" },
                };
                foreach (var category in categories)
                {
                    context.Add(category);
                }
                context.SaveChanges();


                // Brand
                var brands = new Brand[]
                {
                    new Brand { brandName = "Canon" },
                    new Brand { brandName = "Kodak" },
                    new Brand { brandName = "Toshiba" },
                    new Brand { brandName = "Dell" },
                    new Brand { brandName = "HP"},
                    new Brand { brandName = "ASUS" },
                    new Brand { brandName = "Sony" },
                    new Brand { brandName = "Apple" },
                    new Brand { brandName = "Samsung" },
                    new Brand { brandName = "Levi's" },
                    new Brand { brandName = "Adidas" },
                    new Brand { brandName = "Nike" },
                    new Brand { brandName = "New Balance" },
                    new Brand { brandName = "Converse" },
                    new Brand { brandName = "Louis Vuiton" },
                    new Brand { brandName = "GUCCI" },
                    new Brand { brandName = "Chanel" },
                    new Brand { brandName = "Chefman"},
                    new Brand { brandName = "Visual Comfort & Co"},
                    new Brand { brandName = "Intro Lifestyle Products Pvt Ltd"},
                    new Brand { brandName = "Sunhouse"},
                    new Brand { brandName = "Goldsun"},
                    new Brand { brandName = "Philips"}
                };
                foreach (var brand in brands)
                {
                    context.Add(brand);
                }
                context.SaveChanges();

                // Product
                var products = new Product[]
                {
                    // Houseware
                    new Product
                    {
                        productName = "Stainless steel kitchen stand",
                        unitCost = 50000,
                        quantity = 186,
                        
                        status = "sale 10%",
                        
                        brandId = brands.Single(brand => brand.brandName == "Chefman").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Houseware").categoryId
                    },
                    new Product
                    {
                        productName = "WOODEN TABLE BRUSH",
                        unitCost = 20000,
                        quantity = 186,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Goldsun").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Houseware").categoryId
                    },
                    new Product
                    {
                        productName = "STAINLESS ALUMINIUM 3-LAYER STEEL SAUCEPOT",
                        unitCost = 160000,
                        quantity = 186,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Sunhouse").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Houseware").categoryId
                    },
                    // Footwear
                        // Adidas
                    new Product
                    {
                        productName = "ULTRABOOST LIGHT SHOES",
                        unitCost = 1990000,
                        quantity = 53,  
                        status = "sale 10%",
                         size = "42",
                        color = "White",
                        brandId = brands.Single(brand => brand.brandName == "Adidas").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                    new Product
                    {
                        productName = "ULTRA ADIDAS 4D SHOES",
                        unitCost = 1990000,
                        quantity = 53,
        
                         size = "44",
                        color = "White",
                        brandId = brands.Single(brand => brand.brandName == "Adidas").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId,
                    },
                    new Product
                    {
                        productName = "STAN SMITH SHOES",
                        unitCost = 1990000,
                        quantity = 53,
                        status = "sale 10%",
                         size = "48",
                        color = "Black",
                        brandId = brands.Single(brand => brand.brandName == "Adidas").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                        // Nike
                    new Product
                    {
                        productName = "Air Jordan 1 Elevate Low",
                        unitCost = 1990000,
                        quantity = 53,
                        status = "sale 10%",
                         size = "43",
                        color = "White",
                        brandId = brands.Single(brand => brand.brandName == "Nike").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                    new Product
                    {
                        productName = "Nike Dunk Low Retro SE",
                        unitCost = 1990000,
                        quantity = 53,
                        status = "sale 10%",
                         size = "42",
                        color = "Blue",
                        brandId = brands.Single(brand => brand.brandName == "Nike").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                    new Product
                    {
                        productName = "Nike Free Metcon 4 Premium",
                        unitCost = 1990000,
                        quantity = 53,
                        status = "sale 10%",
                         size = "41",
                        color = "White",
                        brandId = brands.Single(brand => brand.brandName == "Nike").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                        // New Balance
                    new Product
                    {
                        productName = "574 Core",
                        unitCost = 1990000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "41",
                        color = "White",
                        brandId = brands.Single(brand => brand.brandName == "New Balance").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                    new Product
                    {
                        productName = "Fresh Foam X 1080v12",
                        unitCost = 1990000,
                        quantity = 53,  
                        status = "sale 10%",
                        size = "41",
                        color = "White",
                        brandId = brands.Single(brand => brand.brandName == "New Balance").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                    new Product
                    {
                        productName = "MX608V5",
                        unitCost = 1990000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "41",
                        color = "White",
                        brandId = brands.Single(brand => brand.brandName == "New Balance").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                        // Converse
                    new Product
                    {
                        productName = "Converse Chuck Taylor All Star Low Top",
                        unitCost = 1990000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "41",
                        color = "White",
                        brandId = brands.Single(brand => brand.brandName == "Converse").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                    new Product
                    {
                        productName = "Converse Chuck Taylor All Star High Top",
                        unitCost = 1990000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "41",
                        color = "Black",
                        brandId = brands.Single(brand => brand.brandName == "Converse").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                    new Product
                    {
                        productName = "Chuck 70",
                        unitCost = 1990000,
                        quantity = 53,  
                        status = "sale 10%",
                        size = "41",
                        color = "Blue",
                        brandId = brands.Single(brand => brand.brandName == "Converse").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                    // Laptops & Computers
                        // Dell
                    new Product
                    {
                        productName = "New Latitude 7640",
                        unitCost = 19900000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "512GB",
                        color = "White",
                        brandId = brands.Single(brand => brand.brandName == "Dell").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                    new Product
                    {
                        productName = "New Latitude 7340 Laptop or 2-in-1",
                        unitCost = 19900000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "512GB",
                        color = "Black",
                        brandId = brands.Single(brand => brand.brandName == "Dell").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                    new Product
                    {
                        productName = "New Latitude 5340 Laptop or 2-in-1",
                        unitCost = 19900000,
                        quantity = 53,
                        size = "512GB",
                        color = "Black",
                        brandId = brands.Single(brand => brand.brandName == "Dell").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                        // ASUS
                    new Product
                    {
                        productName = "Asus TUF Gaming FX506LHB-HN188W i5 10300H",
                        unitCost = 9500000,
                        quantity = 53,
        
                        status = "sale 10%",
                        size = "512GB",
                        color = "Gray",
                        brandId = brands.Single(brand => brand.brandName == "ASUS").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                    new Product
                    {
                        productName = "Asus TUF Gaming FX506HC-HN144W i5 11400H",
                        unitCost = 9990000,
                        quantity = 53,
    
                        status = "sale 10%",
                        size = "512GB",
                        color = "Black",
                        brandId = brands.Single(brand => brand.brandName == "ASUS").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                    new Product
                    {
                        productName = "Asus Vivobook M1403QA-LY022W R5 5600H",
                        unitCost = 75900000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "1TB",
                        color = "Black",
                        brandId = brands.Single(brand => brand.brandName == "ASUS").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                        // HP
                    new Product
                    {
                        productName = "HP Pavilion 14-dv2035TU i5 1235U/6K771PA",
                        unitCost = 65000000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "512GB",
                        color = "Gray",
                        brandId = brands.Single(brand => brand.brandName == "HP").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                    new Product
                    {
                        productName = "Laptop HP Gaming Victus 16-e1107AX R5-6600H",
                        unitCost = 7690000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "512GB",
                        color = "White",
                        brandId = brands.Single(brand => brand.brandName == "HP").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                        // Apple (Macbook)
                    new Product
                    {
                        productName = "MacBook Pro M2 2022 13 inch 8CPU 10GPU 8GB 256GB",
                        unitCost = 12990000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "256GB",
                        color = "White",
                        brandId = brands.Single(brand => brand.brandName == "Apple").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                    new Product
                    {
                        productName = "MacBook Pro 14 2023 M2 Pro 10CPU 16GPU 16GB/512GB",
                        unitCost = 2500,
                        quantity = 53,
                        status = "sale 10%",
                        size = "512GB",
                        color = "White",
                        brandId = brands.Single(brand => brand.brandName == "Apple").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                    new Product
                    {
                        productName = "MacBook Pro 14 2023 M2 Pro 12CPU 19GPU 16GB/1TB",
                        unitCost = 29990000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "1TB",
                        color = "White",
                        brandId = brands.Single(brand => brand.brandName == "Apple").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                    // Mobilephones & Tablets
                        // Appple (iPhone)
                    new Product
                    {
                        productName = "iPhone 14 Pro Max 128GB",
                        unitCost = 12000000,
                        quantity = 53,
                        size = "128GB",
                        color = "White",
                        brandId = brands.Single(brand => brand.brandName == "Apple").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Mobilephones & Tablets").categoryId
                    },
                    new Product
                    {
                        productName = "iPhone 14 Pro Max 256GB",
                        unitCost = 13500000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "256GB",
                        color = "White",
                        brandId = brands.Single(brand => brand.brandName == "Apple").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Mobilephones & Tablets").categoryId
                    },
                    new Product
                    {
                        productName = "iPhone 13 Pro 1TB",
                        unitCost = 12500000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "1TB",
                        color = "White",
                        brandId = brands.Single(brand => brand.brandName == "Apple").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Mobilephones & Tablets").categoryId
                    },
                        // Samsung
                    new Product
                    {
                        productName = "Samsung Galaxy S23 Ultra 5G",
                        unitCost = 12500000,
                        quantity = 53,
                        size = "128GB",
                        color = "White",
                        brandId = brands.Single(brand => brand.brandName == "Samsung").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Mobilephones & Tablets").categoryId
                    },
                    new Product
                    {
                        productName = "Samsung Galaxy S23 5G",
                        unitCost = 95000000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "128GB",
                        color = "Black",
                        brandId = brands.Single(brand => brand.brandName == "Samsung").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Mobilephones & Tablets").categoryId
                    },
                    new Product
                    {
                        productName = "Samsung Galaxy Z Fold4 5G",
                        unitCost = 15500000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "128GB",
                        color = "White",
                        brandId = brands.Single(brand => brand.brandName == "Samsung").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Mobilephones & Tablets").categoryId
                    },
                    // Cameras
                        // Canon
                    new Product
                    {
                        productName = "PowerShot G5 X Mark II",
                        unitCost = 15500000,
                        quantity = 53,
         
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Canon").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Cameras").categoryId
                    },
                    new Product
                    {
                        productName = "PowerShot G9 X Mark II",
                        unitCost = 17500000,
                        quantity = 53,
    
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Canon").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Cameras").categoryId
                    },
                        // Kodak
                    new Product
                    {
                        productName = "KODAK PIXPRO WPZ2 Digital Camera",
                        unitCost = 11500000,
                        quantity = 53,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Kodak").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Cameras").categoryId
                    },
                    new Product
                    {
                        productName = "KODAK PIXPRO ORBIT360 4K VR Camera",
                        unitCost = 13500000,
                        quantity = 53,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Kodak").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Cameras").categoryId
                    },
                    // Televisions
                        // Toshiba
                    new Product
                    {
                        productName = "Ultra HD Smart TV",
                        unitCost = 9500000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "58 inches",
                        color = "Black",
                        brandId = brands.Single(brand => brand.brandName == "Toshiba").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Televisions").categoryId
                    },
                    new Product
                    {
                        productName = "Ultra HD Android TV",
                        unitCost = 12500000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "58 inches",
                        color = "Black",
                        brandId = brands.Single(brand => brand.brandName == "Toshiba").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Televisions").categoryId
                    },
                        // Sony
                    new Product
                    {
                        productName = "Z9J Series",
                        unitCost = 25500000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "58 inches",
                        color = "Black",
                        brandId = brands.Single(brand => brand.brandName == "Sony").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Televisions").categoryId
                    },
                    new Product
                    {
                        productName = "X95K Series",
                        unitCost = 15500000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "65 inches",
                        color = "Black",
                        brandId = brands.Single(brand => brand.brandName == "Sony").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Televisions").categoryId
                    },
                        // Samsung
                    new Product
                    {
                        productName = "65 inch Neo QLED 8K QN800C",
                        unitCost = 37500000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "65 inches",
                        color = "Black",
                        brandId = brands.Single(brand => brand.brandName == "Samsung").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Televisions").categoryId
                    },
                    // Refrigerator
                        // Toshiba
                    new Product
                    {
                        productName = "GR-RS508WE-PMI",
                        unitCost = 37500000,
                        quantity = 53,
                        size = "220l",
                        color = "Black",
                        brandId = brands.Single(brand => brand.brandName == "Toshiba").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Refrigerator").categoryId
                    },
                    new Product
                    {
                        productName = "GR-AG66INA(GG)",
                        unitCost = 42500000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "280l",
                        color = "Black",
                        brandId = brands.Single(brand => brand.brandName == "Toshiba").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Refrigerator").categoryId
                    },
                        // Sony
                    new Product
                    {
                        productName = "SER-240TS",
                        unitCost = 22500000,
                        quantity = 53,
                        size = "210l",
                        color = "Black",
                        brandId = brands.Single(brand => brand.brandName == "Sony").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Refrigerator").categoryId
                    },
                    new Product
                    {
                        productName = "SER-305TS",
                        unitCost = 32500000,
                        quantity = 53,
                        size = "240l",
                        color = "Black",
                        brandId = brands.Single(brand => brand.brandName == "Sony").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Refrigerator").categoryId
                    },
                        // Samsung
                    new Product
                    {
                        productName = "Bespoke 4-Door French Door Refrigerator (29 cu. ft.) with Beverage Center™ in White Glass",
                        unitCost = 32500000,
                        quantity = 53,
                        status = "sale 10%",
                        size = "280l",
                        color = "Black",
                        brandId = brands.Single(brand => brand.brandName == "Samsung").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Refrigerator").categoryId
                    },
                    new Product
                    {
                        productName = "Bespoke 4-Door French Door Refrigerator (23 cu. ft.) with Beverage Center™ in Stainless Steel",
                        unitCost = 42500000,
                        quantity = 53,
                        size = "280l",
                        color = "Black",
                        brandId = brands.Single(brand => brand.brandName == "Samsung").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Refrigerator").categoryId
                    },
                };
                foreach (var product in products)
                {
                    context.Add(product);
                }
                context.SaveChanges();

                var productsImages = new ProductImage[]
               {
                   //Housewear
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "STAINLESS ALUMINIUM 3-LAYER STEEL SAUCEPOT").productId,
                       productImage = "wh1.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "WOODEN TABLE BRUSH").productId,
                       productImage = "wh2.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Stainless steel kitchen stand").productId,
                       productImage = "wh3.webp",
                   },
                   //Converse
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Chuck 70").productId,
                       productImage = "cv1.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Converse Chuck Taylor All Star High Top").productId,
                       productImage = "cv2.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Converse Chuck Taylor All Star Low Top").productId,
                       productImage = "cv3.webp",
                   },
                   //NewBalance
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "MX608V5").productId,
                       productImage = "nb1.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Fresh Foam X 1080v12").productId,
                       productImage = "nb2.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "574 Core").productId,
                       productImage = "nb3.webp",
                   },
                   //Nike
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Nike Free Metcon 4 Premium").productId,
                       productImage = "nk1.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Nike Dunk Low Retro SE").productId,
                       productImage = "nk2.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Air Jordan 1 Elevate Low").productId,
                       productImage = "nk3.webp",
                   },
                   //Adidas
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "ULTRABOOST LIGHT SHOES").productId,
                       productImage = "ad1.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "ULTRA ADIDAS 4D SHOES").productId,
                       productImage = "ad2.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "STAN SMITH SHOES").productId,
                       productImage = "ad3.webp",
                   },
                   //MacBook
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "MacBook Pro 14 2023 M2 Pro 12CPU 19GPU 16GB/1TB").productId,
                       productImage = "phone21.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "MacBook Pro 14 2023 M2 Pro 10CPU 16GPU 16GB/512GB").productId,
                       productImage = "phone27.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "MacBook Pro M2 2022 13 inch 8CPU 10GPU 8GB 256GB").productId,
                       productImage = "phone29.webp",
                   },
                   //HP
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "HP Pavilion 14-dv2035TU i5 1235U/6K771PA").productId,
                       productImage = "phone13.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Laptop HP Gaming Victus 16-e1107AX R5-6600H").productId,
                       productImage = "phone14.webp",
                   },
                   //Asus
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Asus TUF Gaming FX506LHB-HN188W i5 10300H").productId,
                       productImage = "phone26.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Asus TUF Gaming FX506HC-HN144W i5 11400H").productId,
                       productImage = "phone11.webp",
                   },
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Asus Vivobook M1403QA-LY022W R5 5600H").productId,
                       productImage = "phone12.webp",
                   },
                   //Dell
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "New Latitude 7640").productId,
                       productImage = "phone23.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "New Latitude 7340 Laptop or 2-in-1").productId,
                       productImage = "phone24.webp",
                   },
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "New Latitude 5340 Laptop or 2-in-1").productId,
                       productImage = "phone30.webp",
                   },
                   //iphone
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "iPhone 13 Pro 1TB").productId,
                       productImage = "phone1.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "iPhone 14 Pro Max 256GB").productId,
                       productImage = "phone2.webp",
                   },
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "iPhone 14 Pro Max 128GB").productId,
                       productImage = "phone4.webp",
                   },
                    //samsungphone
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Samsung Galaxy S23 Ultra 5G").productId,
                       productImage = "phone3.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Samsung Galaxy S23 5G").productId,
                       productImage = "phone8.webp",
                   },
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Samsung Galaxy Z Fold4 5G").productId,
                       productImage = "phone7.webp",
                   },
                    //samsung refrigerator
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Bespoke 4-Door French Door Refrigerator (23 cu. ft.) with Beverage Center™ in Stainless Steel").productId,
                       productImage = "tl1.webp",
                   },
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Bespoke 4-Door French Door Refrigerator (29 cu. ft.) with Beverage Center™ in White Glass").productId,
                       productImage = "tl2.webp",
                   },
                    //sony refrigerator
                     new ProductImage
                   {
                       productId= products.Single(product => product.productName == "SER-305TS").productId,
                       productImage = "tl3.webp",
                   },
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "SER-240TS").productId,
                       productImage = "tl4.webp",
                   },
                    //Toshiba refrigerator
                     new ProductImage
                   {
                       productId= products.Single(product => product.productName == "GR-RS508WE-PMI").productId,
                       productImage = "tl5.webp",
                   },
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "GR-AG66INA(GG)").productId,
                       productImage = "tl6.webp",
                   },
                    //Samsung television
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "65 inch Neo QLED 8K QN800C").productId,
                       productImage = "phone51.webp",
                   },
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "65 inch Neo QLED 8K QN800C").productId,
                       productImage = "phone52.webp",
                   },
                    //Sony television
                     new ProductImage
                   {
                       productId= products.Single(product => product.productName == "X95K Series").productId,
                       productImage = "phone53.webp",
                   },
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Z9J Series").productId,
                       productImage = "phone54.webp",
                   },
                    //Toshiba televesion
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Ultra HD Smart TV").productId,
                       productImage = "phone55.webp",
                   },
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Ultra HD Android TV").productId,
                       productImage = "phone56.webp",
                   },
                    //Canon cameras
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "PowerShot G5 X Mark II").productId,
                       productImage = "cn1.webp",
                   },
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "PowerShot G9 X Mark II").productId,
                       productImage = "cn2.webp",
                   },
                    //Kodak cameras
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "KODAK PIXPRO WPZ2 Digital Camera").productId,
                       productImage = "cn3.webp",
                   },
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "KODAK PIXPRO ORBIT360 4K VR Camera").productId,
                       productImage = "cn4.webp",
                   },

               };
                foreach (var productImage in productsImages)
                {
                    context.Add(productImage);
                }
                context.SaveChanges();
            }
        }
    }
}
