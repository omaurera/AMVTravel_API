using AMVTravel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AMVTravel.Infrastructure.Persistences
{
    public class AmvTravelDbContext : DbContext
	{
		public AmvTravelDbContext(DbContextOptions<AmvTravelDbContext> options) : base(options)
		{
		}

		public DbSet<Usuario> Usuario { get; set; }
		public DbSet<Tour> Tour { get; set; }
		public DbSet<Reserva> Reserva { get; set; }
	}
}

