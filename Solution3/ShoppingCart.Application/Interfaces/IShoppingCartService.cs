using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface IShoppingCartService
    {
        List<ProductViewModel> GetShoppingCart(List<Guid> itemIds);
        void SaveOrderDetails(List<Guid> shoppingList, string userEmail);

    }
}
