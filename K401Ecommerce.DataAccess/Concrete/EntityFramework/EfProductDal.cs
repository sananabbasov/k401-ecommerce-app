using System;
using System.Linq.Expressions;
using K401Ecommerce.Core.DataAccess.EntityFramework;
using K401Ecommerce.Core.Utilities.Results.Abstract;
using K401Ecommerce.Core.Utilities.Results.Concrete;
using K401Ecommerce.Core.Utilities.SeoHelpers;
using K401Ecommerce.DataAccess.Abstract;
using K401Ecommerce.Entities.Concrete;
using K401Ecommerce.Entities.DTOs.CartDTOs;
using K401Ecommerce.Entities.DTOs.ProductDTOs;
using Microsoft.EntityFrameworkCore;
using static K401Ecommerce.Entities.DTOs.ProductDTOs.ProductDTO;

namespace K401Ecommerce.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfRepositoryBase<Product, AppDbContext>, IProductDal
    {
        public IResult AddProduct(ProductAddDTO productAdd, string userId)
        {
            using var context = new AppDbContext();
            List<Picture> pictures = new();

            for (int i = 0; i < productAdd.photoUrls.Count; i++)
            {
                pictures.Add(new Picture { PhotoUrl = productAdd.photoUrls[i]});
            }
            Product product = new()
            {
                CategoryId = productAdd.CategoryId,
                UserId = userId,
                Price = productAdd.Price,
                Discount = productAdd.Discount,
                Quantity = productAdd.Quantity,
                IsFeatured = productAdd.IsFeatured,
                Pictures = pictures
            };

            context.Products.Add(product);
            context.SaveChanges();

            for (int i = 0; i < productAdd.Name.Count; i++)
            {
                ProductLanguage pl = new()
                {
                    ProductId = product.Id,
                    Name = productAdd.Name[i],
                    Description = productAdd.Description[i],
                    SeoUrl = SeoHelper.SeoUrlCreater(productAdd.Name[i]),
                    LangCode = i == 0 ? "az-Az" : i == 1 ? "en-Us" : "ru-Ru"
                };
                context.ProductLanguages.Add(pl);
                context.SaveChanges();
            }
            return new SuccessResult();
        }

        public IEnumerable<ProductFilterDTO> FilterProducts(string langcode, decimal minPrice, decimal maxPrice, List<int> categoryIds, int pageNo, int take)
        {
            using var context = new AppDbContext();

            int nextPage = (pageNo-1) * take;


            var result = context.Products.Where(x => x.Price >= minPrice && x.Price <= maxPrice && (categoryIds.Any() == false ? null==null : categoryIds.Contains(x.CategoryId))).Select(x=> new ProductFilterDTO
            {
                Id = x.Id,
                Name = x.ProductLanguages.FirstOrDefault(y=>y.LangCode==langcode).Name,
                SeoUrl = x.ProductLanguages.FirstOrDefault(y=>y.LangCode==langcode).SeoUrl,
                PhotoUrl = x.Pictures.FirstOrDefault().PhotoUrl,
                Price= x.Price,
                Discount = x.Discount
            }).Skip(nextPage).Take(take).ToList();

            return result;
        }

        public IDataResult<List<ProductFeaturedDTO>> GetAllFeaturedProduct(string langcode)
        {
            using var context = new AppDbContext();
            var result = context.Products.Select(x => new ProductFeaturedDTO(x.Id, x.ProductLanguages.FirstOrDefault(x => x.LangCode == langcode).Name, "asda", x.Price, x.Discount, x.ProductLanguages.FirstOrDefault(x => x.LangCode == langcode).SeoUrl)).ToList();
            return new SuccessDataResult<List<ProductFeaturedDTO>>(result);
        }

        public IDataResult<List<ProductRecentDTO>> GetAllRecentProduct(string langcode)
        {
            using var context = new AppDbContext();
            var result = context.Set<ProductRecentDTO>().FromSqlInterpolated($"EXEC GetRecentProducts {langcode}").ToList();
            return new SuccessDataResult<List<ProductRecentDTO>>(result);
        }

        public ProductDetailDTO GetProductById(string langcode, int id)
        {
            using var context = new AppDbContext();
            var result = context.Products
                .Include(x=>x.ProductLanguages)
                .Include(x => x.Pictures)
                .Where(x => x.Id == id)
                .Select(x => new ProductDetailDTO
                {
                    Id = x.Id,
                    Name = x.ProductLanguages.FirstOrDefault(z=>z.LangCode==langcode).Name,
                    Description = x.ProductLanguages.FirstOrDefault(z => z.LangCode == langcode).Description,
                    SeoUrl = x.ProductLanguages.FirstOrDefault(z => z.LangCode == langcode).SeoUrl,
                    Discount = x.Discount,
                    PhotoUrls  = x.Pictures.Where(a=>a.ProductId == x.Id).Select(x=>x.PhotoUrl).ToList(),
                    Price = x.Price
                }).FirstOrDefault();
            return result;
        }

        public int GetProductCount(double take, List<int> cats)
        {
            using var context = new AppDbContext();
            var result = context.Products.Where(x => cats.Any() == false ? null == null : cats.Contains(x.CategoryId)).Count();
            return result;
        }

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

        public List<UserCartDTO> GetUserCart(List<int> id, string langcode)
        {
            using var context = new AppDbContext();

            var result = context.Products.Where(x=>id.Contains(x.Id)).Include(x=>x.ProductLanguages).Include(x=>x.Pictures).Select(x=> new UserCartDTO
            {
                Id = x.Id,
                ProductName = x.ProductLanguages.FirstOrDefault(x=>x.LangCode == langcode).Name,
                Price =x.Price,
                PhotoUrl =x.Pictures.FirstOrDefault().PhotoUrl,
            }).ToList();
            return result;
        }
    }
}

