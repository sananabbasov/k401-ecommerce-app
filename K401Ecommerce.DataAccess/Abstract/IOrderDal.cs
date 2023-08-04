using System;
using K401Ecommerce.Core.DataAccess;
using K401Ecommerce.Entities.Concrete;
using K401Ecommerce.Entities.DTOs.OrderDTOs;

namespace K401Ecommerce.DataAccess.Abstract
{
	public interface IOrderDal : IRepositoryBase<Order>
	{
		void AddRange(List<Order> order);
	}
}

