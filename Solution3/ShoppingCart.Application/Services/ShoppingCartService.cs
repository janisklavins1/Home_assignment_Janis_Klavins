using AutoMapper;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class ShoppingCartService_ : IShoppingCartService              //logic for shopping cart, needed to add symbol "_" to class name because of error in DependencyContainer
    {
        private IMapper _mapper;
        private IProductsRepository _productsRepo;

        public ShoppingCartService_(IProductsRepository productsRepository
           , IMapper mapper
            )
        {
            _mapper = mapper;
            _productsRepo = productsRepository;
        }

        public IQueryable<ProductViewModel> GetShoppingCart(List<Guid> shoppingCart)//Data type = ProductViewModel
        {                                                                           //Argument = List of items

            if (shoppingCart == null)//if no Items return null
            {
                return null;
            }
            else
            {
                List<ProductViewModel> tempProducts = new List<ProductViewModel>();//new temp list in order to get add method in productsService
                
                foreach (Guid id in shoppingCart) 
                {
                    var item = _productsRepo.GetProduct(id);
                    tempProducts.Add(_mapper.Map<ProductViewModel>(item));//Add((ProductViewModel product)
                   
                }

                IQueryable<ProductViewModel> ShoppingCart = tempProducts.AsQueryable();//Converts an IEnumerable to an IQueryable

                return ShoppingCart;

            }

        }



    }
}
