using OnlineShop.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Abstractions
{
    public interface IAuthService
    {
        public Task<Tokenn> GenerateToken(RequestLogin requestLogin);
    }
}
