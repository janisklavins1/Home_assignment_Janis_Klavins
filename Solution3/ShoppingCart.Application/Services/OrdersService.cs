using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    class OrdersService : IOrdersService
    {

        private IOrdersRepository _ordersRepo;

        public IQueryable<OrderViewModel> GetOrders()
        {
            var list = from c in _ordersRepo.GetOrders()
                       select new OrderViewModel()
                       {
                           Id = c.Id,
                           Name = c.Name
                       };
            return list;
        }

    }
}
