using AMVTravel.Domain.Entities;

namespace AMVTravel.Infrastructure.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
	{
		Task<Usuario> Loguearse(string nombreUsuario, string contrasena);
	}
}

