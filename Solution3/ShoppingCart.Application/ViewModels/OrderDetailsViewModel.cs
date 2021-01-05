using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        
        public Guid ProductFK { get; set; }

        public Product Product { get; set; }


        public Guid OrderFK { get; set; }
        public Order Order { get; set; }


        public int Quantity { get; set; }
    }
}
