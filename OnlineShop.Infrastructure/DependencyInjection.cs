using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Abstractions;
using OnlineShop.Domain.Entities.Models;
using OnlineShop.Infrastructure.BaseRepo;
using OnlineShop.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(conf.GetConnectionString("Con"));
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IKorzinkaRepository, KorzinkaRepository>();
            //services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            return services;
        }
    }
}
