using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.Attributes;
using OnlineShop.API.ExternalService;
using OnlineShop.Application.Abstractions;
using OnlineShop.Domain.Entities.DTOs;
using OnlineShop.Domain.Entities.Enums;
using OnlineShop.Domain.Entities.Models;
using System.IO;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _evn;

        public ProductController(IProductService productService, IWebHostEnvironment evn)
        {
            _productService = productService;
            _evn = evn;
        }

        [HttpPost]
        [IdentityFilter(Permissions.Create)]
        public async Task<ActionResult<Product>> CreateProduct([FromForm] ProductDTO model, IFormFile path)
        {
            ProductExternalService productExternalService = new ProductExternalService(_evn);

            var picturePath = await productExternalService.AddGetPath(path);

            var result = await _productService.Create(model, picturePath);

            return Ok(result);
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetAll)]

        public async Task<ActionResult<IEnumerable<Product>>> Getall()
        {
            var result = await _productService.Get();

            return Ok(result);
        }

        [HttpDelete]
        [IdentityFilter(Permissions.Delete)]

        public async Task<ActionResult<string>> Delete([FromForm] string name)
        {
            var result = await _productService.Delete(name);
            return Ok("Succesfully deleted");
        }
        [HttpPut]
        [IdentityFilter(Permissions.Update)]

        public async Task<ActionResult<ProductDTO>> Update([FromForm]int id,[FromForm]ProductDTO productDTO, IFormFile path)
        {
            ProductExternalService productExternalService = new ProductExternalService(_evn);

            var picturePath = await productExternalService.AddGetPath(path);

            var product = await _productService.UpdateById(id, productDTO, picturePath);
            return Ok(product);
        }
    }
}
