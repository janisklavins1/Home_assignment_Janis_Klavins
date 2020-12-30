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
    public class OrdersService : IOrdersService
    {
        private IMapper _mapper;
        private IOrdersRepository _ordersRepo;

        public OrdersService(IOrdersRepository ordersRepository
           , IMapper mapper
            )
        {
            _mapper = mapper;
            _ordersRepo = ordersRepository;
        }

        
        public IQueryable<OrderViewModel> GetOrders()
        {       
            var products = _ordersRepo.GetOrders().ProjectTo<OrderViewModel>(_mapper.ConfigurationProvider);
            return products;
        }

        public void AddOrder(OrderViewModel o)
        {
            var myOrder = _mapper.Map<Order>(o);
            

            _ordersRepo.AddOrder(myOrder);
        }

        //public void DeleteOrder(Guid id)
        //{
        //    var orderToDelete = _ordersRepo.GetOrder(id);<---------- make GetOrder(id) method

        //    if (pToDelete != null)
        //    {
        //        _productsRepo.DeleteProduct(pToDelete);
        //    }

        //}

        //public void CheckOut(List<Product> productsInCart)
        //{
        //    throw new NotImplementedException();
        //}



    }
}
