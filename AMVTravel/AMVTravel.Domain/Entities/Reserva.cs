using AMVTravel.Domain.Commons;

namespace AMVTravel.Domain.Entities
{
    public class Reserva : EntidadBase
	{
		public string Cliente { get; set; }
		public DateOnly FechaReserva { get; set; }
		public Guid TourId { get; set; }
	}
}

