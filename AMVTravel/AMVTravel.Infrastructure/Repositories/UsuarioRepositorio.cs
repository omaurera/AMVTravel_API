using AMVTravel.Domain.Entities;
using AMVTravel.Infrastructure.Interfaces;
using AMVTravel.Infrastructure.Persistences;
using Microsoft.EntityFrameworkCore;

namespace AMVTravel.Infrastructure.Repositories
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
	{
		public UsuarioRepositorio(AmvTravelDbContext context) : base(context)
		{
		}

        public async Task<Usuario> Loguearse(string nombreUsuario, string contrasena)
        {
            return await _context.Set<Usuario>().FirstOrDefaultAsync(x => x.NombreUsuario == nombreUsuario && x.Contrasena == contrasena);
        }
    }
}

