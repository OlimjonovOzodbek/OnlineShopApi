﻿using OnlineShop.Application.Abstractions;
using OnlineShop.Domain.Entities.DTOs;
using OnlineShop.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _product;

        public ProductService(IProductRepository product)
        {
            _product = product;
        }
        public async Task<string> Create(ProductDTO productDTO)
        {
            if (_product.GetByAny(x => x.Name == productDTO.Name).Result == null) 
            {
                var user = new Product()
                {
                    Name = productDTO.Name,
                    Price = productDTO.Price,
                    GuaranteeDuration = productDTO.GuaranteeDuration,
                    MadeIn = productDTO.MadeIn,
                    
                };
                var result = await _product.Create(user);

                return "Succesfully added!✅";
            }
            return "Product already exists😐";
        }
    }
}