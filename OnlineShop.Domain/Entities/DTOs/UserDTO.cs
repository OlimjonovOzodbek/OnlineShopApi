using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities.DTOs
{
    public class UserDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string Login {  get; set; }
        public string Password { get; set; }
        public string Role {  get; set; }   
    }
}
