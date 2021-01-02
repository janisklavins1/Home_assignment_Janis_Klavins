﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingCart.Application.AutoMapper;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Data.Repositories;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class ProductsService : IProductsService
    {
        private IMapper _mapper;
        private IProductsRepository _productsRepo;
        public ProductsService(IProductsRepository productsRepository
           ,  IMapper mapper
            )
        {
            _mapper = mapper;
            _productsRepo = productsRepository;
        }

        public void AddProduct(ProductViewModel product)
        {
            //changing this using automapper later on

            //Converting from
            //ProductViewModel >> Product
            /*     Product newProduct = new Product()
                 {
                     Description = product.Description,
                     Name = product.Name,
                     Price = product.Price,
                     CategoryId = product.Category.Id,
                     ImageUrl = product.ImageUrl
                 };

                 _productsRepo.AddProduct(newProduct);
            */

            var myProduct = _mapper.Map<Product>(product);
            myProduct.Category = null;

            _productsRepo.AddProduct(myProduct);

        }

        public void DeleteProduct(Guid id)
        {
            var pToDelete = _productsRepo.GetProduct(id);

            if (pToDelete != null)
            {
                _productsRepo.DeleteProduct(pToDelete);
            }
            
        }
        

        public ProductViewModel GetProduct(Guid id)
        {
            


            var myProduct = _productsRepo.GetProduct(id);
            var result = _mapper.Map<ProductViewModel>(myProduct);
            return result;



        }

        public IQueryable<ProductViewModel> GetProducts()
        {
           

            var products = _productsRepo.GetProducts().ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);

            return products;
                            

        }
        
        public IQueryable<ProductViewModel> GetProducts(string keyword)
        {  //Iqueryable and list

            var products = _productsRepo.GetProducts().Where(x=>x.Description.Contains(keyword) || x.Name.Contains(keyword))
                .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);
            return products;
        }
        public IQueryable<ProductViewModel> GetProducts(int category)
        {
            //var list = from p in _productsRepo.GetProducts().Where(x => x.Category.Id == category)
            //           select new ProductViewModel()
            //           {
            //               Id = p.Id,
            //               Description = p.Description,
            //               Name = p.Name,
            //               Price = p.Price,
            //               Category = new CategoryViewModel() { Id = p.Category.Id, Name = p.Category.Name },
            //               ImageUrl = p.ImageUrl
            //           };
            var list  = _productsRepo.GetProducts().Where(x => x.Category.Id.Equals(category))
                .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);


            return list;
        }

        




    }
}
