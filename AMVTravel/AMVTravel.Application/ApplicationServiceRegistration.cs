using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AMVTravel.Application
{
    public static class ApplicationServiceRegistration
	{
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
	}
}

