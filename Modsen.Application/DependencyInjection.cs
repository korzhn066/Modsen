using Microsoft.Extensions.DependencyInjection;
using Modsen.Application.Features.Book.Queries;
using Modsen.Application.Mapper;
using System.Reflection;

namespace Modsen.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());   

            return services;
        }
    };
}
