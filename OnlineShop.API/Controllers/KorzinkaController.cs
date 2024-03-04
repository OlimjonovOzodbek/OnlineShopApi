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
    public class KorzinkaController : ControllerBase
    {
        private readonly IKorzinkaService _korzina;

        public KorzinkaController(IKorzinkaService korzina)
        {
            _korzina = korzina;
        }
        [HttpPost]
        public async Task<ActionResult<Korzinka>> CreateProduct([FromForm] KorzinkaDTO model)
        {
            var result = await _korzina.Create(model);

            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Korzinka>>> Getall()
        {
            var result = await _korzina.Get();

            return Ok(result);
        }
    }
}
