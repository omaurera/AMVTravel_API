using AMVTravel.Domain.Commons;

namespace AMVTravel.Domain.Entities
{
    public class Tour : EntidadBase
	{
		public string Nombre { get; set; }
		public string Destino { get; set; }
		public DateTime FechaInicio { get; set; }
		public DateTime FechaFin { get; set; }
		public decimal Precio { get; set; }
	}
}

