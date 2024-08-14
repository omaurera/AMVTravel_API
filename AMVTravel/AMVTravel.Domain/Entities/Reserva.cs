using AMVTravel.Domain.Commons;

namespace AMVTravel.Domain.Entities
{
    public class Reserva : EntidadBase
	{
		public string Cliente { get; set; }
		public DateTime FechaReserva { get; set; }
		public Guid TourId { get; set; }
	}
}

