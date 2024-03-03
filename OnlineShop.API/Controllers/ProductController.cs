using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Abstractions;
using OnlineShop.Application.Services;
using OnlineShop.Domain.Entities.DTOs;
using OnlineShop.Domain.Entities.Models;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromForm] ProductDTO model)
        {
            var result = await _productService.Create(model);

            return Ok(result);
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<Product>>> Getall()
        {
            var result = await _productService.Get();

            return Ok(result);
        }
    }
}
