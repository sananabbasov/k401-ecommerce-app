using System;
using AutoMapper;
using K401Ecommerce.Entities.Concrete;
using K401Ecommerce.Entities.DTOs.OrderDTOs;

namespace K401Ecommerce.Business.AutoMapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<CreateOrderDTO, Order>();
		}
	}
}

