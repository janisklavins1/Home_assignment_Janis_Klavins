using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {

        ShoppingCartDbContext _context;

        public OrderDetailsRepository(ShoppingCartDbContext context)
        {
            _context = context;

        }

        public IQueryable<OrderDetails> GetOrderDetails()
        {
            return _context.OrderDetails;
        }

        //public Guid AddOrderDetails(OrderDetails orderDetails)
        //{

        //    _context.OrderDetails.Add(orderDetails);
        //    _context.SaveChanges();

        //    return orderDetails.Id;
        //}

        public void AddOrderDetails(OrderDetails orderDetails)
        {

            _context.OrderDetails.Add(orderDetails);
            _context.SaveChanges();
   
        }

    }
}
