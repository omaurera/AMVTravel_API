namespace AMVTravel.Domain.Responses
{
    public class RespuestaTour
	{
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Destino { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Precio { get; set; }
    }
}

