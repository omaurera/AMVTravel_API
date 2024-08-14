namespace AMVTravel.Domain.Responses
{
    public class RespuestaBaseLista<T>
	{
        public int Codigo { get; set; }
        public IEnumerable<T> Data { get; set; }
        public string Mensaje { get; set; }
    }
}

