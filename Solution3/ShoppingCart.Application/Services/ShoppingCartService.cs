using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
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

        public ShoppingCartService(IProductsRepository productsRepository
           , IMapper mapper
            )
        {
            _mapper = mapper;
            _productsRepo = productsRepository;
        }

        public IQueryable<ProductViewModel> GetShoppingCart(List<Guid> shoppingCart)//Items are being store in cookie
        {                                                                           

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
