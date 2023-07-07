using System;
using K401Ecommerce.Core.Utilities.Results.Abstract;
using K401Ecommerce.Entities.DTOs.ProductDTOs;

namespace K401Ecommerce.Business.Abstract
{
	public interface IProductService
	{
		IDataResult<List<ProductAdminListDTO>> GetDashboardProducts(string lang,string userId);
	}
}

