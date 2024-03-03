using OnlineShop.Domain.Entities.DTOs;
using OnlineShop.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineShop.Application.Abstractions.IBaseRepository;

namespace OnlineShop.Application.Abstractions
{
    public interface IProductService
    {
        public Task<string> Create(ProductDTO productDTO);
    }
}
