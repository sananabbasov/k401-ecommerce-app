using System;
using K401Ecommerce.Business.Abstract;
using K401Ecommerce.Core.Utilities.Results.Abstract;
using K401Ecommerce.Core.Utilities.Results.Concrete;
using K401Ecommerce.DataAccess.Abstract;
using K401Ecommerce.Entities.DTOs.ProductDTOs;

namespace K401Ecommerce.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IDataResult<List<ProductAdminListDTO>> GetDashboardProducts(string lang, string userId)
        {
            var result =  _productDal.GetProductsByUser(userId, lang);
            if (result.Success)
            {
                return new SuccessDataResult<List<ProductAdminListDTO>>(result.Data);
            }
            return new ErrorDataResult<List<ProductAdminListDTO>>(result.Message);
        }
    }
}

