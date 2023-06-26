using System;
using K401Ecommerce.Core.DataAccess.EntityFramework;
using K401Ecommerce.DataAccess.Abstract;
using K401Ecommerce.Entities.Concrete;

namespace K401Ecommerce.DataAccess.Concrete.EntityFramework
{
	public class EfProductDal : EfRepositoryBase<Product, AppDbContext>, IProductDal
	{
		
	}
}

