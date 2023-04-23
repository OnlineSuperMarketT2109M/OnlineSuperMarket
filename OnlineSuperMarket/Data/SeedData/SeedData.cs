﻿using Microsoft.EntityFrameworkCore;
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
                        unitCost = 5,
                        quantity = 186,
                        totalAmount = 2320,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Chefman").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Houseware").categoryId
                    },
                    new Product
                    {
                        productName = "WOODEN TABLE BRUSH",
                        unitCost = 2,
                        quantity = 186,
                        totalAmount = 2320,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Goldsun").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Houseware").categoryId
                    },
                    new Product
                    {
                        productName = "STAINLESS ALUMINIUM 3-LAYER STEEL SAUCEPOT",
                        unitCost = 15.99,
                        quantity = 186,
                        totalAmount = 2320,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Sunhouse").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Houseware").categoryId
                    },
                    
                    // Clothes
                        // GUCCI Clothes
                    new Product
                    {
                        productName = "Gucci Web and Interlocking G",
                        unitCost = 266,
                        quantity = 78,
                        totalAmount = 800,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "GUCCI").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Clothes").categoryId
                    },
                    new Product
                    {
                        productName = "Gucci Jacquard Striped Cotton",
                        unitCost = 322,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "GUCCI").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Clothes").categoryId
                    },
                    new Product
                    {
                        productName = "Gucci Cream GG-striped Cotton Polo Shirt",
                        unitCost = 342,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "GUCCI").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Clothes").categoryId
                    },

                        // Louis Vuiton Clothes
                    new Product
                    {
                        productName = "LV Printed Leaf Regular Shirt",
                        unitCost = 389,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Louis Vuiton").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Clothes").categoryId
                    },
                    new Product
                    {
                        productName = "Monogram Hoodie",
                        unitCost = 509,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Louis Vuiton").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Clothes").categoryId
                    },
                    new Product
                    {
                        productName = "DNA Leaf Denim Jacket",
                        unitCost = 599,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Louis Vuiton").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Clothes").categoryId
                    },
                    new Product
                    {
                        productName = "Evening Blouson",
                        unitCost = 599,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Louis Vuiton").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Clothes").categoryId
                    },
                        // Adidas clothes
                    new Product
                    {
                        productName = "ADIDAS ADVENTURE MOUNTAIN BACK TEE",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Adidas").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Clothes").categoryId
                    },
                    new Product
                    {
                        productName = "OWN THE RUN TEE",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Adidas").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Clothes").categoryId
                    },
                    new Product
                    {
                        productName = "CLUB 3-STRIPES TENNIS TEE",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Adidas").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Clothes").categoryId
                    },
                        // Nike Clothes
                    new Product
                    {
                        productName = "Nike Dri-FIT UV Hyverse",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Nike").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Clothes").categoryId
                    },
                    new Product
                    {
                        productName = "Nike Culture of Basketball",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Nike").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Clothes").categoryId
                    },
                    new Product
                    {
                        productName = "Nike Sportswear",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Nike").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Clothes").categoryId
                    },
                        // Levi's
                    new Product
                    {
                        productName = "Barstow Western Denim Shirt",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Levi's").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Clothes").categoryId
                    },
                    new Product
                    {
                        productName = "Relaxed Fit Short Sleeve T-Shirt",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Levi's").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Clothes").categoryId
                    },
                    new Product
                    {
                        productName = "Housemark Polo Shirt",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Levi's").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Clothes").categoryId
                    },

                    // Footwear
                        // Adidas
                    new Product
                    {
                        productName = "ULTRABOOST LIGHT SHOES",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Adidas").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                    new Product
                    {
                        productName = "ULTRA ADIDAS 4D SHOES",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        brandId = brands.Single(brand => brand.brandName == "Adidas").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId,
                    },
                    new Product
                    {
                        productName = "STAN SMITH SHOES",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Adidas").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                        // Nike
                    new Product
                    {
                        productName = "Air Jordan 1 Elevate Low",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Nike").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                    new Product
                    {
                        productName = "Nike Dunk Low Retro SE",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Nike").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                    new Product
                    {
                        productName = "Nike Free Metcon 4 Premium",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Nike").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                        // New Balance
                    new Product
                    {
                        productName = "574 Core",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "New Balance").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                    new Product
                    {
                        productName = "Fresh Foam X 1080v12",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "New Balance").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                    new Product
                    {
                        productName = "MX608V5",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "New Balance").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                        // Converse
                    new Product
                    {
                        productName = "Converse Chuck Taylor All Star Low Top",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Converse").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                    new Product
                    {
                        productName = "Converse Chuck Taylor All Star High Top",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Converse").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                    new Product
                    {
                        productName = "Chuck 70",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Converse").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Footwear").categoryId
                    },
                    // Laptops & Computers
                        // Dell
                    new Product
                    {
                        productName = "New Latitude 7640",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Dell").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                    new Product
                    {
                        productName = "New Latitude 7340 Laptop or 2-in-1",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Dell").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                    new Product
                    {
                        productName = "New Latitude 5340 Laptop or 2-in-1",
                        unitCost = 199,
                        quantity = 53,
                        totalAmount = 890,
                        brandId = brands.Single(brand => brand.brandName == "Dell").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                        // ASUS
                    new Product
                    {
                        productName = "Asus TUF Gaming FX506LHB-HN188W i5 10300H",
                        unitCost = 950,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "ASUS").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                    new Product
                    {
                        productName = "Asus TUF Gaming FX506HC-HN144W i5 11400H",
                        unitCost = 999,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "ASUS").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                    new Product
                    {
                        productName = "Asus Vivobook M1403QA-LY022W R5 5600H",
                        unitCost = 759,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "ASUS").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                        // HP
                    new Product
                    {
                        productName = "HP Pavilion 14-dv2035TU i5 1235U/6K771PA",
                        unitCost = 650,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "HP").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                    new Product
                    {
                        productName = "Laptop HP Gaming Victus 16-e1107AX R5-6600H",
                        unitCost = 769,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "HP").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                        // Apple (Macbook)
                    new Product
                    {
                        productName = "MacBook Pro M2 2022 13 inch 8CPU 10GPU 8GB 256GB",
                        unitCost = 1299,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Apple").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                    new Product
                    {
                        productName = "MacBook Pro 14 2023 M2 Pro 10CPU 16GPU 16GB/512GB",
                        unitCost = 2500,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Apple").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                    new Product
                    {
                        productName = "MacBook Pro 14 2023 M2 Pro 12CPU 19GPU 16GB/1TB",
                        unitCost = 2999,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Apple").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Laptops & Computers").categoryId
                    },
                    // Mobilephones & Tablets
                        // Appple (iPhone)
                    new Product
                    {
                        productName = "iPhone 14 Pro Max 128GB",
                        unitCost = 1200,
                        quantity = 53,
                        totalAmount = 890,
                        brandId = brands.Single(brand => brand.brandName == "Apple").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Mobilephones & Tablets").categoryId
                    },
                    new Product
                    {
                        productName = "iPhone 14 Pro Max 256GB",
                        unitCost = 1350,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Apple").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Mobilephones & Tablets").categoryId
                    },
                    new Product
                    {
                        productName = "iPhone 13 Pro 1TB",
                        unitCost = 1250,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Apple").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Mobilephones & Tablets").categoryId
                    },
                        // Samsung
                    new Product
                    {
                        productName = "Samsung Galaxy S23 Ultra 5G",
                        unitCost = 1250,
                        quantity = 53,
                        totalAmount = 890,
                        brandId = brands.Single(brand => brand.brandName == "Samsung").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Mobilephones & Tablets").categoryId
                    },
                    new Product
                    {
                        productName = "Samsung Galaxy S23 5G",
                        unitCost = 950,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Samsung").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Mobilephones & Tablets").categoryId
                    },
                    new Product
                    {
                        productName = "Samsung Galaxy Z Fold4 5G",
                        unitCost = 1550,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Samsung").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Mobilephones & Tablets").categoryId
                    },
                    // Cameras
                        // Canon
                    new Product
                    {
                        productName = "PowerShot G5 X Mark II",
                        unitCost = 1550,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Canon").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Cameras").categoryId
                    },
                    new Product
                    {
                        productName = "PowerShot G9 X Mark II",
                        unitCost = 1750,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Canon").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Cameras").categoryId
                    },
                        // Kodak
                    new Product
                    {
                        productName = "KODAK PIXPRO WPZ2 Digital Camera",
                        unitCost = 1150,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Kodak").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Cameras").categoryId
                    },
                    new Product
                    {
                        productName = "KODAK PIXPRO ORBIT360 4K VR Camera",
                        unitCost = 1350,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Kodak").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Cameras").categoryId
                    },
                    // Televisions
                        // Toshiba
                    new Product
                    {
                        productName = "Ultra HD Smart TV",
                        unitCost = 950,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Toshiba").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Televisions").categoryId
                    },
                    new Product
                    {
                        productName = "Ultra HD Android TV",
                        unitCost = 1250,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Toshiba").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Televisions").categoryId
                    },
                        // Sony
                    new Product
                    {
                        productName = "Z9J Series",
                        unitCost = 2550,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Sony").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Televisions").categoryId
                    },
                    new Product
                    {
                        productName = "X95K Series",
                        unitCost = 1550,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Sony").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Televisions").categoryId
                    },
                        // Samsung
                    new Product
                    {
                        productName = "55 inch Neo QLED 4K QN85C",
                        unitCost = 2150,
                        quantity = 53,
                        totalAmount = 890,
                        brandId = brands.Single(brand => brand.brandName == "Samsung").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Televisions").categoryId
                    },
                    new Product
                    {
                        productName = "65 inch Neo QLED 8K QN800C",
                        unitCost = 3750,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Samsung").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Televisions").categoryId
                    },
                    // Refrigerator
                        // Toshiba
                    new Product
                    {
                        productName = "GR-RS508WE-PMI",
                        unitCost = 3750,
                        quantity = 53,
                        totalAmount = 890,
                        brandId = brands.Single(brand => brand.brandName == "Toshiba").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Refrigerator").categoryId
                    },
                    new Product
                    {
                        productName = "GR-AG66INA(GG)",
                        unitCost = 4250,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Toshiba").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Refrigerator").categoryId
                    },
                        // Sony
                    new Product
                    {
                        productName = "SER-240TS",
                        unitCost = 2250,
                        quantity = 53,
                        totalAmount = 890,
                        brandId = brands.Single(brand => brand.brandName == "Sony").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Refrigerator").categoryId
                    },
                    new Product
                    {
                        productName = "SER-305TS",
                        unitCost = 3250,
                        quantity = 53,
                        totalAmount = 890,
                        brandId = brands.Single(brand => brand.brandName == "Sony").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Refrigerator").categoryId
                    },
                        // Samsung
                    new Product
                    {
                        productName = "Bespoke 4-Door French Door Refrigerator (29 cu. ft.) with Beverage Center™ in White Glass",
                        unitCost = 3250,
                        quantity = 53,
                        totalAmount = 890,
                        status = "sale 10%",
                        brandId = brands.Single(brand => brand.brandName == "Samsung").brandId,
                        categoryId = categories.Single(category => category.categoryName == "Refrigerator").categoryId
                    },
                    new Product
                    {
                        productName = "Bespoke 4-Door French Door Refrigerator (23 cu. ft.) with Beverage Center™ in Stainless Steel",
                        unitCost = 4250,
                        quantity = 53,
                        totalAmount = 890,
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
                   //Levis
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Housemark Polo Shirt").productId,
                       productImage = "qa14.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Relaxed Fit Short Sleeve T-Shirt").productId,
                       productImage = "qa15.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Barstow Western Denim Shirt").productId,
                       productImage = "qa1.webp",
                   },
                   //NikeClothes
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Nike Dri-FIT UV Hyverse").productId,
                       productImage = "qa11.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Nike Culture of Basketball").productId,
                       productImage = "qa12.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Nike Sportswear").productId,
                       productImage = "qa13.webp",
                   },
                   //AddCl
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "ADIDAS ADVENTURE MOUNTAIN BACK TEE").productId,
                       productImage = "qa8.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "OWN THE RUN TEE").productId,
                       productImage = "qa9.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "CLUB 3-STRIPES TENNIS TEE").productId,
                       productImage = "qa10.webp",
                   },
                   //LV
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "LV Printed Leaf Regular Shirt").productId,
                       productImage = "qa4.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Monogram Hoodie").productId,
                       productImage = "qa5.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "DNA Leaf Denim Jacket").productId,
                       productImage = "qa6.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Evening Blouson").productId,
                       productImage = "qa7.webp",
                   },
                   //Gucci
                    new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Gucci Web and Interlocking G").productId,
                       productImage = "qa1.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Gucci Jacquard Striped Cotton").productId,
                       productImage = "qa2.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == "Gucci Cream GG-striped Cotton Polo Shirt").productId,
                       productImage = "qa3.webp",
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
                       productId= products.Single(product => product.productName == " ULTRABOOST LIGHT SHOES").productId,
                       productImage = "ad1.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == " ULTRA ADIDAS 4D SHOES").productId,
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
                       productId= products.Single(product => product.productName == " MacBook Pro 14 2023 M2 Pro 12CPU 19GPU 16GB/1TB").productId,
                       productImage = "phone21.webp",
                   },
                   new ProductImage
                   {
                       productId= products.Single(product => product.productName == " MacBook Pro 14 2023 M2 Pro 10CPU 16GPU 16GB/512GB").productId,
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
                       productId= products.Single(product => product.productName == " HP Pavilion 14-dv2035TU i5 1235U/6K771PA").productId,
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
                       productId= products.Single(product => product.productName == "KODAK PIXPRO ORBIT360 4K VR Camer").productId,
                       productImage = "cn4.webp",
                   },

               };
                foreach (var productImage in productsImages)
                {
                    context.Add(productImage);
                }

                var ProductSizes = new ProductSize[]
                {
                    //Housewear
                    new ProductSize
                    {
                        productId= products.Single(product => product.productName == "STAINLESS ALUMINIUM 3-LAYER STEEL SAUCEPOT").productId,
                        size = "Medium",
                    },
                    new ProductSize
                    {
                        productId= products.Single(product => product.productName == "WOODEN TABLE BRUSH").productId,
                        size = "Large",
                    },
                    new ProductSize
                    {
                        productId= products.Single(product => product.productName == "Stainless steel kitchen stand").productId,
                        size = "Small",
                    },
                    //Levis
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Housemark Polo Shirt").productId,
                       size = "XL",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Housemark Polo Shirt").productId,
                       size = "XXL",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Relaxed Fit Short Sleeve T-Shirt").productId,
                       size = "M",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Barstow Western Denim Shirt").productId,
                       size = "L",
                   },
                   //NikeClothes
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Nike Dri-FIT UV Hyverse").productId,
                       size = "L",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Nike Culture of Basketball").productId,
                       size = "XXL",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Nike Sportswear").productId,
                       size = "SM",
                   },
                   //AddCl
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "ADIDAS ADVENTURE MOUNTAIN BACK TEE").productId,
                       size = "XL",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "OWN THE RUN TEE").productId,
                       size = "XXL",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "CLUB 3-STRIPES TENNIS TEE").productId,
                       size = "SM",
                   },
                   //LV
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "LV Printed Leaf Regular Shirt").productId,
                       size = "L",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Monogram Hoodie").productId,
                       size = "M",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "DNA Leaf Denim Jacket").productId,
                       size = "SM",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Evening Blouson").productId,
                       size = "L",
                   },
                   //Gucci
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Gucci Web and Interlocking G").productId,
                       size = "XL",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Gucci Jacquard Striped Cotton").productId,
                       size = "XXL",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Gucci Cream GG-striped Cotton Polo Shirt").productId,
                       size = "M",
                   },
                   //Converse
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Chuck 70").productId,
                       size = "42",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Converse Chuck Taylor All Star High Top").productId,
                       size = "43",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Converse Chuck Taylor All Star Low Top").productId,
                       size = "44",
                   },
                   //NewBalance
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "MX608V5").productId,
                       size = "46",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Fresh Foam X 1080v12").productId,
                       size = "41",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "574 Core").productId,
                       size = "42",
                   },
                   //Nike
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Nike Free Metcon 4 Premium").productId,
                       size = "43",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Nike Dunk Low Retro SE").productId,
                       size = "43",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Air Jordan 1 Elevate Low").productId,
                       size = "43",
                   },
                   //Adidas
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == " ULTRABOOST LIGHT SHOES").productId,
                       size = "42",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == " ULTRA ADIDAS 4D SHOES").productId,
                       size = "41",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "STAN SMITH SHOES").productId,
                       size = "42",
                   },
                   //MacBook
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == " MacBook Pro 14 2023 M2 Pro 12CPU 19GPU 16GB/1TB").productId,
                       size = "14 inches, 16GB/1TB",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == " MacBook Pro 14 2023 M2 Pro 10CPU 16GPU 16GB/512GB").productId,
                       size = "14 inches, 16GB/1TB",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "MacBook Pro M2 2022 13 inch 8CPU 10GPU 8GB 256GB").productId,
                       size = "13 inches, 8GB/256GB",
                   },
                   //HP
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == " HP Pavilion 14-dv2035TU i5 1235U/6K771PA").productId,
                       size = "15.6 inches",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Laptop HP Gaming Victus 16-e1107AX R5-6600H").productId,
                       size = "15.6 inches",
                   },
                   //Asus
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Asus TUF Gaming FX506LHB-HN188W i5 10300H").productId,
                       size = "15.6 inches",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Asus TUF Gaming FX506HC-HN144W i5 11400H").productId,
                       size = "14 inches",
                   },
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Asus Vivobook M1403QA-LY022W R5 5600H").productId,
                       size = "15.6 inches",
                   },
                   //Dell
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "New Latitude 7640").productId,
                       size = "15.6 inches",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "New Latitude 7340 Laptop or 2-in-1").productId,
                       size = "14 inches",
                   },
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "New Latitude 5340 Laptop or 2-in-1").productId,
                       size = "15.6 inches",
                   },
                   //iphone
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "iPhone 13 Pro 1TB").productId,
                       size = "1TB",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "iPhone 14 Pro Max 256GB").productId,
                       size = "256GB",
                   },
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "iPhone 14 Pro Max 128GB").productId,
                       size = "128GB",
                   },
                    //samsungphone
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Samsung Galaxy S23 Ultra 5G").productId,
                       size = "128Gb",
                   },
                   new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Samsung Galaxy S23 5G").productId,
                       size = "64GB",
                   },
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Samsung Galaxy Z Fold4 5G").productId,
                       size = "256GB",
                   },
                    //samsung refrigerator
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Bespoke 4-Door French Door Refrigerator (23 cu. ft.) with Beverage Center™ in Stainless Steel").productId,
                       size = "250l",
                   },
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Bespoke 4-Door French Door Refrigerator (29 cu. ft.) with Beverage Center™ in White Glass").productId,
                       size = "280l",
                   },
                    //sony refrigerator
                     new ProductSize
                   {
                       productId= products.Single(product => product.productName == "SER-305TS").productId,
                       size = "180l",
                   },
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "SER-240TS").productId,
                       size = "220l",
                   },
                    //Toshiba refrigerator
                     new ProductSize
                   {
                       productId= products.Single(product => product.productName == "GR-RS508WE-PMI").productId,
                       size = "220l",
                   },
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "GR-AG66INA(GG)").productId,
                       size = "180l",
                   },
                    //Samsung television
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "65 inch Neo QLED 8K QN800C").productId,
                       size = "65 inches",
                   },
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "65 inch Neo QLED 8K QN800C").productId,
                       size = "65 inches",
                   },
                    //Sony television
                     new ProductSize
                   {
                       productId= products.Single(product => product.productName == "X95K Series").productId,
                       size = "65 inches",
                   },
                       new ProductSize
                   {
                       productId= products.Single(product => product.productName == "X95K Series").productId,
                       size = "52 inches",
                   },
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Z9J Series").productId,
                       size = "65 inches",
                   },
                    //Toshiba televesion
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Ultra HD Smart TV").productId,
                       size = "65 inches",
                   },
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "Ultra HD Android TV").productId,
                       size = "52 inches",
                   },
                    //Canon cameras
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "PowerShot G5 X Mark II").productId,
                       size = "no size",
                   },
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "PowerShot G9 X Mark II").productId,
                       size = "no size",
                   },
                    //Kodak cameras
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "KODAK PIXPRO WPZ2 Digital Camera").productId,
                       size = "no size",
                   },
                    new ProductSize
                   {
                       productId= products.Single(product => product.productName == "KODAK PIXPRO ORBIT360 4K VR Camer").productId,
                       size = "no size",
                   },
                };
                foreach (var productSize in ProductSizes)
                {
                    context.Add(productSize);
                }
                context.SaveChanges();
            }
        }
    }
}
