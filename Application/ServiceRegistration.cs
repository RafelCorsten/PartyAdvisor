using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Mappings;
using AutoMapper;
using MediatR;

namespace DataBase
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
