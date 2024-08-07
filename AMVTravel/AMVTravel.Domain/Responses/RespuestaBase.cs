namespace AMVTravel.Domain.Responses
{
    public class RespuestaBase<T>
	{
		public int Codigo { get; set; }
		public T Data { get; set; }
		public string Mensaje { get; set; }
	}
}

