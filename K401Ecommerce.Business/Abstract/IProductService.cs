using System;
using K401Ecommerce.Core.Utilities.Results.Abstract;
using K401Ecommerce.Entities.Concrete;
using K401Ecommerce.Entities.DTOs.CartDTOs;
using K401Ecommerce.Entities.DTOs.ProductDTOs;
using static K401Ecommerce.Entities.DTOs.ProductDTOs.ProductDTO;

namespace K401Ecommerce.Business.Abstract
{
	public interface IProductService
	{
		IDataResult<List<ProductAdminListDTO>> GetDashboardProducts(string lang,string userId);
        IResult AddDasboardProduct(ProductAddDTO productAdd, string userId);
        IDataResult<List<ProductFeaturedDTO>> GetAllFeaturedProduct(string langcode);
        IDataResult<List<ProductRecentDTO>> GetAllRecentProduct(string langcode);
        IDataResult<ProductDetailDTO> GetProductDetailById(string langcode, int id);

        // Get product count 
        IDataResult<int> GetProductCount(double take, List<int> cats);

        IDataResult<List<UserCartDTO>> GetProductForCart(List<int> id, string langcode, List<int> quantity);

        IDataResult<IEnumerable<ProductFilterDTO>> GetFilterProductsByLanguage(string langcode, decimal minPrice, decimal maxPrice, List<int> categoryIds, int pageNo, int take);


        IDataResult<int> GetProductQuantityById(int productId);
    }
}

