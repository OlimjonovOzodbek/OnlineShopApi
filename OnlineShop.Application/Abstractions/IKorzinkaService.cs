using OnlineShop.Domain.Entities.DTOs;
using OnlineShop.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Abstractions
{
    public interface IKorzinkaService
    {
        public Task<string> Create(KorzinkaDTO korzinka);
        public Task<IEnumerable<Korzinka>> Get();
        public Task<string> Delete(string name);
        public Task<Korzinka> UpdateByName(string name, KorzinkaDTO productDTO);
    }
}
