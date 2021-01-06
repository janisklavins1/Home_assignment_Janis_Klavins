using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class OrderDetailsViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Guid ProductFK { get; set; }

        public Product Product { get; set; }

        [Required]
        public Guid OrderFK { get; set; }
        public Order Order { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Item count cannot be 0")]
        public int Quantity { get; set; }
    }
}
