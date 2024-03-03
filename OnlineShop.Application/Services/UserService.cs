using OnlineShop.Application.Abstractions;
using OnlineShop.Domain.Entities.DTOs;
using OnlineShop.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository; 
        public UserService(IUserRepository userRepository)
        {

            _userRepository = userRepository;

        }
        public async Task<string> Create(UserDTO userDTO)
        {
            if (_userRepository.GetByAny(x => x.Email == userDTO.Email).Result == null && 
                _userRepository.GetByAny(x => x.Login == userDTO.Login).Result == null) 
            { 
            var user = new User()
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Login = userDTO.Login,
                Password = userDTO.Password,
                Role = userDTO.Role,
            };
            var result = await _userRepository.Create(user);

            return "Succesfully added!✅";
            }
            return "User already exists😐";
        }

        public async Task<User> GetByAny(Expression<Func<User, bool>> expression)
        {
            var result = await _userRepository.GetByAny(expression);
            return result;
        }
    }
}
