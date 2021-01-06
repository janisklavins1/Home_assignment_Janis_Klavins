using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class MemberViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(1000)]
        public string LastName { get; set; }
    }
}
