using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PresentationWebApp.Helpers;

namespace PresentationWebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Guid>>(HttpContext.Session, "shoppingCart");



            return View();
        }
    }
}
