using HotelBooking.DataAccessLayer.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HotelBooking.DataAccessLayer.RepositoryContracts;
using HotelBooking.DataAccessLayer.Repositories;

namespace HotelBooking.DataAccessLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IHotelRepository, HotelRepository>();
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")!);
            });
            return services;
        }
    }
}
