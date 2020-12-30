using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {

        private IMapper _mapper;
        private IOrderDetailsRepository _orderDetailsRepo;

        public OrderDetailsService(IOrderDetailsRepository ordersDetailsRepository
           , IMapper mapper
            )
        {
            _mapper = mapper;
            _orderDetailsRepo = ordersDetailsRepository;
        }


        public IQueryable<OrderDetailsViewModel> GetOrdersDetails()
        {
            var orderDetails = _orderDetailsRepo.GetOrderDetails().ProjectTo<OrderDetailsViewModel>(_mapper.ConfigurationProvider);
            return orderDetails;
        }

        public void AddOrderDetails(OrderDetailsViewModel oD)
        {
            var myOrder = _mapper.Map<OrderDetails>(oD);


            _orderDetailsRepo.AddOrderDetails(myOrder);
        }

    }
}
