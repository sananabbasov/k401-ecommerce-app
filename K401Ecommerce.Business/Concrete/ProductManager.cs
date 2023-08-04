using System;
using System.Collections.Generic;
using K401Ecommerce.Business.Abstract;
using K401Ecommerce.Core.Utilities.Results.Abstract;
using K401Ecommerce.Core.Utilities.Results.Concrete;
using K401Ecommerce.DataAccess.Abstract;
using K401Ecommerce.Entities.DTOs.CartDTOs;
using K401Ecommerce.Entities.DTOs.ProductDTOs;
using static K401Ecommerce.Entities.DTOs.ProductDTOs.ProductDTO;

namespace K401Ecommerce.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult AddDasboardProduct(ProductAddDTO productAdd, string userId)
        {
            _productDal.AddProduct(productAdd, userId);
            return new SuccessResult();
        }

        public IDataResult<List<ProductFeaturedDTO>> GetAllFeaturedProduct(string langcode)
        {
            var result = _productDal.GetAllFeaturedProduct(langcode);
            return new SuccessDataResult<List<ProductFeaturedDTO>>(result.Data);
        }

        public IDataResult<List<ProductRecentDTO>> GetAllRecentProduct(string langcode)
        {
            try
            {
                var result = _productDal.GetAllRecentProduct(langcode);
                return new SuccessDataResult<List<ProductRecentDTO>>(result.Data);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<ProductRecentDTO>>(ex.Message);

            }
        }

        public IDataResult<List<ProductAdminListDTO>> GetDashboardProducts(string lang, string userId)
        {
            var result = _productDal.GetProductsByUser(userId, lang);
            if (result.Success)
            {
                return new SuccessDataResult<List<ProductAdminListDTO>>(result.Data);
            }
            return new ErrorDataResult<List<ProductAdminListDTO>>(result.Message);
        }

        public IDataResult<IEnumerable<ProductFilterDTO>> GetFilterProductsByLanguage(string langcode, decimal minPrice, decimal maxPrice, List<int> categoryIds, int pageNo, int take)
        {
            try
            {
                var result = _productDal.FilterProducts(langcode, minPrice, maxPrice, categoryIds, pageNo, take);
                return new SuccessDataResult<IEnumerable<ProductFilterDTO>>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<ProductFilterDTO>>(ex.Message);
            }
        }

        public IDataResult<int> GetProductCount(double take, List<int> cats)
        {

            double productCountResult = _productDal.GetProductCount(take, cats) / take;
            int productCount = (int)Math.Ceiling(productCountResult);
            return new SuccessDataResult<int>(productCount);
        }

        public IDataResult<ProductDetailDTO> GetProductDetailById(string langcode, int id)
        {
            try
            {
                var data = _productDal.GetProductById(langcode, id);
                return new SuccessDataResult<ProductDetailDTO>(data);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ProductDetailDTO>(ex.Message);
            }
        }

        public IDataResult<List<UserCartDTO>> GetProductForCart(List<int> id, string langcode, List<int> quantity)
        {
            var result = _productDal.GetUserCart(id, langcode);
            for (int i = 0; i < result.Count(); i++)
            {
                result[i].Quantity = quantity[i];
            }
            return new SuccessDataResult<List<UserCartDTO>>(result);
        }

        public IDataResult<int> GetProductQuantityById(int productId)
        {
            var productCount = _productDal.Get(x=>x.Id == productId).Quantity;

            return new SuccessDataResult<int>(productCount);
        }
    }
}

