using System;
using K401Ecommerce.Core.DataAccess.EntityFramework;
using K401Ecommerce.Core.Utilities.Results.Abstract;
using K401Ecommerce.Core.Utilities.Results.Concrete;
using K401Ecommerce.DataAccess.Abstract;
using K401Ecommerce.Entities.Concrete;
using K401Ecommerce.Entities.DTOs.ProductDTOs;
using Microsoft.EntityFrameworkCore;

namespace K401Ecommerce.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfRepositoryBase<Product, AppDbContext>, IProductDal
    {
        public IDataResult<List<ProductAdminListDTO>> GetProductsByUser(string userId, string langcode)
        {
            try
            {
                using var context = new AppDbContext();
                var products = context.Products
                    .Include(x => x.Category)
                    .ThenInclude(y => y.CategoryLanguages)
                    .Include(x => x.Pictures)
                    .Include(x => x.ProductLanguages)
                    .Select(data => new ProductAdminListDTO
                    {
                        Id = data.Id,
                        Name = data.ProductLanguages.FirstOrDefault(x => x.LangCode == langcode).Name,
                        PhotoUrl = data.Pictures.FirstOrDefault().PhotoUrl,
                        Discount = data.Discount,
                        Price = data.Price,
                        View = data.Views,
                        CategoryName = data.Category.CategoryLanguages.FirstOrDefault(x => x.LangCode == langcode).CategoryName
                    }).ToList();


                return new SuccessDataResult<List<ProductAdminListDTO>>(products);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<ProductAdminListDTO>>(ex.Message);
            }
        }
    }
}

