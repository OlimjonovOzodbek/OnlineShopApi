using OnlineShop.Application.Abstractions;
using OnlineShop.Domain.Entities.DTOs;
using OnlineShop.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services
{
    public class KorzinkaService : IKorzinkaService
    {
        private readonly IKorzinkaRepository _korzina;

        public KorzinkaService(IKorzinkaRepository korzina)
        {
            _korzina = korzina;
        }
        public async Task<string> Create(KorzinkaDTO korzinka)
        {
            if (_korzina.GetByAny(x => x.Name == korzinka.Name).Result == null)
            {
                var user = new Korzinka()
                {
                    Name = korzinka.Name,

                };
                var result = await _korzina.Create(user);

                return "Succesfully added!✅";
            }
            return "Product already exists😐";
        }

        public async Task<string> Delete(string name)
        {
            var res = await _korzina.Delete(x => x.Name == name);
            return "Product Has Been Deleted";
        }

        public async Task<IEnumerable<Korzinka>> Get()
        {
            return await _korzina.GetAll();
        }

        public async Task<Korzinka> UpdateByName(string name, KorzinkaDTO korzinka)
        {
            var result = await _korzina.GetByAny(x => x.Name == name);
            if (result != null)
            {
                result.Name = korzinka.Name;
            }
            return null;
        }
    }
}
