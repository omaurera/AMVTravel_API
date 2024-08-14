using AMVTravel.Domain.Commons;

namespace AMVTravel.Domain.Entities
{
    public class Usuario : EntidadBase
	{
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string NombreUsuario { get; set; }
		public string Contrasena { get; set; }
	}
}

