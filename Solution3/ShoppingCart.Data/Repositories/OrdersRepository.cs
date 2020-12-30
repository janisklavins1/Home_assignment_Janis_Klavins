using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class OrdersRepository : IOrdersRepository
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

        public Guid AddOrder(Order order)
        {
           
            _context.Orders.Add(order);
            _context.SaveChanges();

            return order.Id;
           
        }

        //public void DeleteOrder(Order order)
        //{           
        //    _context.Orders.Remove(order);
        //    _context.SaveChanges(); //this will save permanently into the db
        //}





    }
}
