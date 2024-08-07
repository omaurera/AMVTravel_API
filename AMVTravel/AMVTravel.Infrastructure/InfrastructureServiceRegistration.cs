using AMVTravel.Infrastructure.Interfaces;
using AMVTravel.Infrastructure.Persistences;
using AMVTravel.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AMVTravel.Infrastructure
{
    public static class InfrastructureServiceRegistration
	{
		public static IServiceCollection AddInfrastructureService(IServiceCollection services, IConfiguration configuration)
		{
            services.AddDbContext<AmvTravelDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AmvTravelDatabase"))
                       .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            );
            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<ITourRepositorio, TourRepositorio>();
            services.AddScoped<IReservaRepositorio, ReservaRepositorio>();
            return services;
        }
	}
}

