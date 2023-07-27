using System;
using K401Ecommerce.Core.DataAccess.EntityFramework;
using K401Ecommerce.Core.Utilities.SeoHelpers;
using K401Ecommerce.DataAccess.Abstract;
using K401Ecommerce.Entities.Concrete;
using K401Ecommerce.Entities.DTOs.CategoryDTOs;
using Microsoft.EntityFrameworkCore;
using static K401Ecommerce.Entities.DTOs.CategoryDTOs.CategoryDTO;

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
                        SeoUrl = SeoHelper.SeoUrlCreater(categoryAddDTO.CategoryName[i])
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

        public List<CategoryAdminListDTO> GetAdminCategoryList(string langcode)
        {
            using var context = new AppDbContext();
            var result = context.Categories
                .Include(x=>x.CategoryLanguages)
                .Select(x=> new CategoryAdminListDTO
                {
                    Id = x.Id,
                    CategoryName = x.CategoryLanguages.FirstOrDefault(y=>y.LangCode == langcode).CategoryName,
                    PhotoUrl = x.PhotoUrl,
                    ProductCount = 0,
                    IsFeatured = x.IsFeatured
                })
                .ToList();
            return result;
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

        public List<CategoryFilterDTO> GetFilterCategories(string langcode)
        {
            using var context = new AppDbContext();
            var result = context.Categories.Include(x=>x.CategoryLanguages).Select(x => new CategoryFilterDTO
            {
                Id = x.Id,
                CategoryName = x.CategoryLanguages.FirstOrDefault(x=>x.LangCode == langcode).CategoryName
            }).ToList();

            return result;
        }

        public List<CategoryFeaturedHomeDTO> GetHomeCategoryByLanguage(string langcode)
        {
            using var context = new AppDbContext();

            var result = context.CategoryLanguages
                .Include(z => z.Category)
                .Where(x => x.LangCode == langcode)
                .Select(x => new CategoryFeaturedHomeDTO(x.Category.Id, x.CategoryName,0, x.Category.PhotoUrl, x.SeoUrl)).ToList();
            return result;
        }
    }
}

