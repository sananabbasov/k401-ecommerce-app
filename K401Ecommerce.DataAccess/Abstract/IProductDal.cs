using System;
using K401Ecommerce.Core.DataAccess;
using K401Ecommerce.Core.Utilities.Results.Abstract;
using K401Ecommerce.Entities.Concrete;
using K401Ecommerce.Entities.DTOs.ProductDTOs;

namespace K401Ecommerce.DataAccess.Abstract
{
	public interface IProductDal : IRepositoryBase<Product>
	{
		IDataResult<List<ProductAdminListDTO>> GetProductsByUser(string userId, string langcode);
	}
}
