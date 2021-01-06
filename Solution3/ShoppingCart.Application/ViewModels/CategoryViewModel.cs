using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class CategoryViewModel
    {
        [Required]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
    }
}
