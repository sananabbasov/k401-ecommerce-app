using System;
using K401Ecommerce.Core.Utilities.Results.Abstract;
using K401Ecommerce.Entities.DTOs.OrderDTOs;

namespace K401Ecommerce.Business.Abstract
{
	public interface IOrderService
	{
		IResult CreateOrder(List<CreateOrderDTO> order);
	}
}

