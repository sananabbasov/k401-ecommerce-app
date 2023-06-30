using System;
using K401Ecommerce.Core.DataAccess.EntityFramework;
using K401Ecommerce.DataAccess.Abstract;
using K401Ecommerce.Entities.Concrete;
using K401Ecommerce.Entities.DTOs.CategoryDTOs;
using Microsoft.EntityFrameworkCore;

namespace K401Ecommerce.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfRepositoryBase<Category, AppDbContext>, ICategoryDal
    {
        public async Task<bool> AddCategory(CategoryAddDTO categoryAddDTO)
        {
            try
            {
                using var context = new AppDbContext();

                var category = new Category()
                {
                    PhotoUrl = categoryAddDTO.PhotoUrl,
                    IsFeatured = false
                };

                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();

                for (int i = 0; i < categoryAddDTO.CategoryName.Count; i++)
                {
                    CategoryLanguage cl = new()
                    {
                        CategoryName = categoryAddDTO.CategoryName[i],
                        LangCode = categoryAddDTO.LangCode[i],
                        CategoryId = category.Id,
                        SeoUrl = "asdad"
                    };
                    await context.CategoryLanguages.AddAsync(cl);
                }
                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<CategoryHomeListDTO> GetCategorieByLanguage(string langcode)
        {
            using var context = new AppDbContext();

            var result = context.CategoryLanguages
                .Include(z=>z.Category)
                .Where(x=>x.LangCode == langcode)
                .Select(x=> new CategoryHomeListDTO {
                    Id = x.Category.Id,
                    CategoryName = x.CategoryName,
                    SeoUrl = x.SeoUrl,
                    PhotoUrl = x.Category.PhotoUrl,
                    ProductCount = 0
                }).ToList();

            return result;
            
        }
    }
}

