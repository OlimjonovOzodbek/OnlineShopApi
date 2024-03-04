using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.Attributes;
using OnlineShop.Application.Abstractions;
using OnlineShop.Application.Services;
using OnlineShop.Domain.Entities.DTOs;
using OnlineShop.Domain.Entities.Enums;
using OnlineShop.Domain.Entities.Models;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class KorzinkaController : ControllerBase
    {
        private readonly IKorzinkaService _korzina;

        public KorzinkaController(IKorzinkaService korzina)
        {
            _korzina = korzina;
        }
        [HttpPost]
        [IdentityFilter(Permissions.CreataKorzinka)]
        public async Task<ActionResult<Korzinka>> CreateProduct([FromForm] KorzinkaDTO model)
        {
            var result = await _korzina.Create(model);

            return Ok(result);
        }
        [HttpGet]
        [IdentityFilter(Permissions.GetKorzinka)]
        public async Task<ActionResult<IEnumerable<Korzinka>>> Getall()
        {
            var result = await _korzina.Get();

            return Ok(result);
        }
        [HttpDelete]
        [IdentityFilter(Permissions.DeleteKorzinka)]
        public async Task<ActionResult<string>> Delete([FromForm] string name)
        {
            var result = await _korzina.Delete(name);
            return Ok("Succesfully deleted");
        }
        [HttpPut]
        [IdentityFilter(Permissions.UpdateKorzinka)]
        public async Task<ActionResult<KorzinkaDTO>> Update([FromForm]string Name_Change, [FromForm] KorzinkaDTO productDTO)
        {
            var product = await _korzina.UpdateByName(Name_Change, productDTO);
            return Ok(product);
        }
    }
}
