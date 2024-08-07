using AMVTravel.Domain.Entities;
using AMVTravel.Infrastructure.Interfaces;
using AMVTravel.Infrastructure.Persistences;

namespace AMVTravel.Infrastructure.Repositories
{
    public class ReservaRepositorio : RepositorioBase<Reserva>, IReservaRepositorio
    {
		public ReservaRepositorio(AmvTravelDbContext context) : base(context)
		{
		}
	}
}

