using System;
using AutoMapper;
using K401Ecommerce.Business.Abstract;
using K401Ecommerce.Business.Constants;
using K401Ecommerce.Core.Utilities.Business;
using K401Ecommerce.Core.Utilities.Results.Abstract;
using K401Ecommerce.Core.Utilities.Results.Concrete;
using K401Ecommerce.DataAccess.Abstract;
using K401Ecommerce.Entities.Concrete;
using K401Ecommerce.Entities.DTOs.OrderDTOs;

namespace K401Ecommerce.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public OrderManager(IOrderDal orderDal, IMapper mapper, IProductService productService)
        {
            _orderDal = orderDal;
            _mapper = mapper;
            _productService = productService;
        }


        // [AspectValidation(nameof(OrderValidator))]
        public IResult CreateOrder(List<CreateOrderDTO> order)
        {
            var result = BusinessRule.Check(CheckProductQuantity(order), CheckProductQuantityLimit(order));

            if (result.Success)
            {
                var orderMap = _mapper.Map<List<Order>>(order);
                _orderDal.AddRange(orderMap);
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ProductNotFound);

        }



        private IResult CheckProductQuantity(List<CreateOrderDTO> order)
        {
            foreach (var o in order)
            {
                var result = _productService.GetProductQuantityById(o.ProductId);
                if (result.Data == 0)
                    return new ErrorResult();
            }
            return new SuccessResult();

        }

        private IResult CheckProductQuantityLimit(List<CreateOrderDTO> order)
        {
            foreach (var o in order)
            {
                if (o.ProductQuantity > 10)
                    return new ErrorResult();
            }
            return new SuccessResult();
        }


    }
}

