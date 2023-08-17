using System;
using K401Ecommerce.Core.Utilities.Results.Abstract;
using K401Ecommerce.Entities.Concrete;

namespace K401Ecommerce.Business.Abstract
{
	public interface IUserService
	{
		IDataResult<User> GetUserById(string id);
	}
}

