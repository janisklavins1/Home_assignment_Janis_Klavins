using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class ShoppingCartService : IShoppingCartService
    {

        private IMapper _mapper;
        private readonly IProductsRepository _productsRepo;
        private IOrderDetailsRepository _ordersDetailsRepo;
        private IOrdersRepository _ordersRepo;

        public ShoppingCartService(IProductsRepository productsRepository
           , IMapper mapper, IOrderDetailsRepository orderDetailsRepository, IOrdersRepository ordersRepo
            )
        {
            _mapper = mapper;
            _productsRepo = productsRepository;
            _ordersDetailsRepo = orderDetailsRepository;
            _ordersRepo = ordersRepo;
        }

        public IQueryable<ProductViewModel> GetShoppingCart(List<Guid> shoppingCart)//Items are being store in cookie
        {

            if (shoppingCart != null)//null Exception
            {
                List<ProductViewModel> products = new List<ProductViewModel>();//new temp list in order to get add method in productsService
                IQueryable<ProductViewModel> ShoppingCart;
                foreach (Guid id in shoppingCart)
                {
                    var item = _productsRepo.GetProduct(id);
                    products.Add(_mapper.Map<ProductViewModel>(item));//Add((ProductViewModel product)

                }

                ShoppingCart = products.AsQueryable();//Converts an IEnumerable to an IQueryable

                
                return ShoppingCart;
            }
            else
            {
                return null;//if no Items return null
            }



        }

        public void SaveOrderDetails(List<Guid> shoppingList, string userEmail)
        {
            DateTime currentDate = DateTime.Now;


            ///-----------Adds order-------------------
            Order order = new Order
            {
                DatePlaced = currentDate,
                UserEmail = userEmail
            };

            Guid orderId = _ordersRepo.AddOrder(order);//saves orders Primary Key
            ///-----------Adds order-------------------


            ///-----------Adds order details-------------------
            foreach (var item in shoppingList.GroupBy(x => x).Select(y => y.First()).ToList())//removes dublicates
            {
                int itemCount = shoppingList.Count(x => x == item);
                Guid productFk = item;//gets each item PK, resets every time when it loops
                Guid orderFk = orderId;//gets already saved order PK, checks for new order PK, if there is new order it resets

                OrderDetails orderDetails = new OrderDetails
                {
                    OrderFK = orderFk,
                    ProductFK = productFk,
                    Quantity = itemCount
                };


                _ordersDetailsRepo.AddOrderDetails(orderDetails);
            }
            ///-----------Adds order details-------------------

        }


    }
}
