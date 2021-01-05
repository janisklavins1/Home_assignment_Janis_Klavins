using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationWebApp.Helpers;
using ShoppingCart.Application.Interfaces;

namespace PresentationWebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IProductsService _productsService;
        

        public ShoppingCartController(IShoppingCartService shoppingCartService, IProductsService productsService)
        {
            _shoppingCartService = shoppingCartService;
            _productsService = productsService;
            
        }


        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Guid>>(HttpContext.Session, "shoppingCart");//Cookie
            var list = _shoppingCartService.GetShoppingCart(cart);
            ViewBag.cart = list;
           
            //Calculates total price
            double itemPrice, totalPrice, cartPrice = 0;
            int itemCount, itemsStock = 0;
            bool inStock = true;
            
            try
            {
                foreach (var item in list.GroupBy(x => x.Id).Select(y => y.First()).ToList())
                {
                    
                    itemCount = list.Count(x => x.Id == item.Id);//Gets item count
                    itemPrice = item.Price;//Gets item price
                    totalPrice = itemCount * itemPrice;//Calculates total item cost
                    cartPrice = cartPrice + totalPrice;//Adds to total Cart price

                    
                    itemsStock = item.Stock - itemCount;

                    if (itemsStock >= 1)
                    {

                    }
                    else
                    {
                        inStock = false;
                    }
                    ViewBag.inStock = inStock;

                }

            }
            catch (Exception)
            {
                
            }
            
            ViewBag.TotalPrice = cartPrice;


            return View(list);
        }

        public IActionResult AddItemToShoppingCart(Guid id)
        {

            //_productsService.UpdateStock(id, 1);

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
            try
            {
                if (id != null)//System.NullReferenceException
                {
                    //_productsService.UpdateStock(id, -1);

                    List<Guid> ShoppingCart = SessionHelper.GetObjectFromJson<List<Guid>>(HttpContext.Session, "shoppingCart");

                    ShoppingCart.Remove(id);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "shoppingCart", ShoppingCart);
                }

            }
            catch (Exception)
            {

                
            }
            
            
            

            return RedirectToAction("Index");
        }
        
         
        [Authorize(Roles = "User, Admin")]
        public IActionResult CheckOut()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Guid>>(HttpContext.Session, "shoppingCart");
            string userEmail = User.FindFirstValue(ClaimTypes.Name);
            var list = _shoppingCartService.GetShoppingCart(cart);

            foreach (var item in list)
            {
                if (_productsService.GetProduct(item.Id).Stock >= 1)
                {
                    _shoppingCartService.SaveOrderDetails(cart, userEmail);//saves data into db
                    _productsService.UpdateStock(item.Id, list.Count(x => x == item));//updates stock value in db
                }
                else
                {
                    return View("DeniedCheckOutPartial");
                    
                }
            }
            


            return View("CheckOutPartial");
        }




    }
}
