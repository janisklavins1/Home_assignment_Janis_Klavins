﻿using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Domain.Interfaces
{
    public interface IOrderDetailsRepository
    {
        IQueryable<OrderDetails> GetOrderDetails();

        //Guid AddOrderDetails(OrderDetails orderDetails);
        void AddOrderDetails(OrderDetails orderDetails);
    }
}
