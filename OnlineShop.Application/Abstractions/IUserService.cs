using OnlineShop.Domain.Entities.DTOs;
using OnlineShop.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Abstractions
{
    public interface IUserService
    {
        public Task<string> Create(UserDTO userDTO);
        public Task<User> GetByAny(Expression<Func<User, bool>> expression);

        public Task <IEnumerable<User>> GetAll();
    }
}
