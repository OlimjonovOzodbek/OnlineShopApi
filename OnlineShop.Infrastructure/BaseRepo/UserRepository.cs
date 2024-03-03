using OnlineShop.Application.Abstractions;
using OnlineShop.Domain.Entities.Models;
using OnlineShop.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineShop.Application.Abstractions.IBaseRepository;

namespace OnlineShop.Infrastructure.BaseRepo
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
