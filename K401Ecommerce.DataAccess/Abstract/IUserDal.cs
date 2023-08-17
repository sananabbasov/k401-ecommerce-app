using System;
using K401Ecommerce.Core.DataAccess;
using K401Ecommerce.Entities.Concrete;

namespace K401Ecommerce.DataAccess.Abstract
{
	public interface IUserDal : IRepositoryBase<User>
	{
	}
}

