using System;
using K401Ecommerce.DataAccess.Abstract.DataSeeding;
using K401Ecommerce.DataAccess.Concrete.EntityFramework;
using K401Ecommerce.Entities.Concrete;

namespace K401Ecommerce.DataAccess.Concrete.DataSeeding
{
    public class EfDataSeeder : IDataSeeder
    {

        public void AddDatas()
        {
            using var context = new AppDbContext();

            List<Category> categories = new();

            if (!context.Categories.Any())
            {
                categories.Add(new Category { IsFeatured = true, PhotoUrl = "sdfjklas"});
                categories.Add(new Category { IsFeatured = true, PhotoUrl = "sdfjklas"});

                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

            if (!context.CategoryLanguages.Any())
            {
                List<CategoryLanguage> categoryLanguages = new()
                {
                    new CategoryLanguage { CategoryName = "Telefon",LangCode ="az-Az", SeoUrl = "telefon",CategoryId = categories[0].Id},
                    new CategoryLanguage { CategoryName = "Telefon",LangCode ="en-Us", SeoUrl = "telefon",CategoryId = categories[0].Id},
                    new CategoryLanguage { CategoryName = "Telefon",LangCode ="ru-Ru", SeoUrl = "telefon",CategoryId = categories[0].Id},
                };

                context.CategoryLanguages.AddRange(categoryLanguages);
                context.SaveChanges();
            }


            List<Product> products = new();

            if (!context.Products.Any())
            {
                products.Add(
                    new Product {
                        Price = 234.3M, Discount = 100,Raiting = 0, Views = 0, Quantity = 12,CategoryId = categories[0].Id,UserId = "addssad", IsFeatured = true
                    }
                );
                products.Add(
                    new Product {
                        Price = 2342, Discount = 60,Raiting = 9, Views = 123, Quantity = 5453,CategoryId = categories[1].Id,
                        UserId = "addssad", IsFeatured = false
                    }
                );
            }


            if (!context.ProductLanguages.Any())
            {
                List<ProductLanguage> productLanguages = new()
                {
                    new ProductLanguage { Name = "Product 1",Description  = "adasd", LangCode = "az-Az",SeoUrl = "product-1", ProductId  = products[0].Id},
                    new ProductLanguage { Name = "Product 1",Description  = "adasd", LangCode = "en-Us",SeoUrl = "product-1", ProductId  = products[0].Id},
                    new ProductLanguage { Name = "Product 1",Description  = "adasd", LangCode = "ru-Ru",SeoUrl = "product-1", ProductId  = products[0].Id},
                };

                context.ProductLanguages.AddRange(productLanguages);
                context.SaveChanges();
            }
        }
    }
}

