using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface IOrdersService
    {

        IQueryable<OrderViewModel> GetOrders();

        //void CheckOut(List<Product> productsInCart);

        void AddOrder(OrderViewModel order);

        //void DeleteOrder(Guid id);

    }
}
