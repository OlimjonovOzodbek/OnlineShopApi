using OnlineShop.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineShop.Application.Abstractions.IBaseRepository;

namespace OnlineShop.Application.Abstractions
{
    public interface IKorzinkaRepository : IBaseRepository<Korzinka>
    {
    }
}
