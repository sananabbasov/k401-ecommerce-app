using System;
using K401Ecommerce.Core.DataAccess;
using K401Ecommerce.Core.Utilities.Results.Abstract;
using K401Ecommerce.Entities.Concrete;
using K401Ecommerce.Entities.DTOs.CartDTOs;
using K401Ecommerce.Entities.DTOs.ProductDTOs;
using static K401Ecommerce.Entities.DTOs.ProductDTOs.ProductDTO;

namespace K401Ecommerce.DataAccess.Abstract
{
	public interface IProductDal : IRepositoryBase<Product>
	{
		IDataResult<List<ProductAdminListDTO>> GetProductsByUser(string userId, string langcode);
		IResult AddProduct(ProductAddDTO productAdd, string userId);
		IDataResult<List<ProductFeaturedDTO>> GetAllFeaturedProduct(string langcode);
		IDataResult<List<ProductRecentDTO>> GetAllRecentProduct(string langcode);
		ProductDetailDTO GetProductById(string langcode, int id);
		IEnumerable<ProductFilterDTO> FilterProducts(string langcode, decimal minPrice, decimal maxPrice, List<int> categoryIds, int pageNo,int take);

        List<UserCartDTO> GetUserCart(List<int> id, string langcode);

        int GetProductCount(double take, List<int> cats);
    }
}
