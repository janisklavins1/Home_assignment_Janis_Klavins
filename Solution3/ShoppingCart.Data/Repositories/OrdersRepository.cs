using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class OrdersRepository
    {
        ShoppingCartDbContext _context;

        public OrdersRepository(ShoppingCartDbContext context)
        {
            _context = context;

        }

        public IQueryable<Order> GetOrders()
        {
            return _context.Orders;
        }


    }
}
