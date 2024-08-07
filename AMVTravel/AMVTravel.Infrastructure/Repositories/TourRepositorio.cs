using AMVTravel.Domain.Entities;
using AMVTravel.Infrastructure.Interfaces;
using AMVTravel.Infrastructure.Persistences;

namespace AMVTravel.Infrastructure.Repositories
{
    public class TourRepositorio : RepositorioBase<Tour>, ITourRepositorio
	{
		public TourRepositorio(AmvTravelDbContext context) : base(context)
		{
		}
	}
}

