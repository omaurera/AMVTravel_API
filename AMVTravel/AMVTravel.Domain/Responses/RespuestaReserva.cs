namespace AMVTravel.Domain.Responses
{
    public class RespuestaReserva
	{
        public Guid Id { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaReserva { get; set; }
        public string Nombre { get; set; }
        public string Destino { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Precio { get; set; }
    }
}

