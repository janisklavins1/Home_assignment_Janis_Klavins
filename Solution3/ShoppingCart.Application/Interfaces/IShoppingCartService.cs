﻿using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface IShoppingCartService
    {
        IQueryable<ProductViewModel> GetShoppingCart(List<Guid> shoppingCartItems);

    }
}