using OnlineShop.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities.Models
{
    public class Product : BaseEntity
    {
        public string Name  {  get; set; }
        public decimal Price { get; set; }
        public string GuaranteeDuration { get; set; }
        public string MadeIn {  get; set; }
        public string Path { get; set; }
    }
}
