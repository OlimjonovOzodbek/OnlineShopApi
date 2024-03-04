using OnlineShop.Application.Abstractions;
using OnlineShop.Domain.Entities.Models;
using OnlineShop.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.BaseRepo
{
    public class KorzinkaRepository : BaseRepository<Korzinka>, IKorzinkaRepository
    {
        public KorzinkaRepository(ApplicationDbContext context) :base(context) { }
    }
}
