using HotelBooking.BusinessLogicLayer.ServiceContracts;
using HotelBooking.BusinessLogicLayer.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.BusinessLogicLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBLL(this IServiceCollection services)
        {
             services.AddTransient<IHotelService, HotelService>();
            return services;
        }
    }
}
