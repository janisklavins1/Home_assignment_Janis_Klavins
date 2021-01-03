using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PresentationWebApp.Helpers;
using ShoppingCart.Application.Interfaces;

namespace PresentationWebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IProductsService _productsService;

        public ShoppingCartController(IShoppingCartService shoppingCartService, IProductsService productsService)//constr
        {
            _shoppingCartService = shoppingCartService;
            _productsService = productsService;
        }


        public IActionResult Index()//Items are being store in cookie
        {
            var cart = SessionHelper.GetObjectFromJson<List<Guid>>(HttpContext.Session, "shoppingCart");
            var list = _shoppingCartService.GetShoppingCart(cart);
            ViewBag.cart = list;
            
            return View(list);
        }

        public IActionResult AddItemToShoppingCart(Guid id)
        {

            _productsService.UpdateStock(id, 1);

            if (SessionHelper.GetObjectFromJson<List<Guid>>(HttpContext.Session, "shoppingCart") == null)
            {//if you dont get anything from Session object then initialize new cart item of type Guid

                List<Guid> ShoppingCart = new List<Guid>();
                
                ShoppingCart.Add(id);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "shoppingCart", ShoppingCart);
                


            }
            else
            {
                List<Guid> ShoppingCart = SessionHelper.GetObjectFromJson<List<Guid>>(HttpContext.Session, "shoppingCart");              
                ShoppingCart.Add(id);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "shoppingCart", ShoppingCart);

            }
            
            return RedirectToAction("Index", "Products");//RedirectToAction("Index");
        }

        public IActionResult RemoveItem(Guid id)
        {
            
            if (id != null)//System.NullReferenceException
            {
                _productsService.UpdateStock(id, -1);

                List<Guid> ShoppingCart = SessionHelper.GetObjectFromJson<List<Guid>>(HttpContext.Session, "shoppingCart");

                ShoppingCart.Remove(id);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "shoppingCart", ShoppingCart);
            }
            
            

            return RedirectToAction("Index");
        }

        //public IActionResult UpdateStock()
        //{ 
            
        //}
        

        

    }
}
