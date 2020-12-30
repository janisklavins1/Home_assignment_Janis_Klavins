using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface IOrderDetailsService
    {

        IQueryable<OrderDetailsViewModel> GetOrdersDetails();

        void AddOrderDetails(OrderDetailsViewModel orderDetails);

    }
}
