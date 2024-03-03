using OnlineShop.Domain.Entities.Models;
using static OnlineShop.Application.Abstractions.IBaseRepository;

namespace OnlineShop.Application.Abstractions
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
