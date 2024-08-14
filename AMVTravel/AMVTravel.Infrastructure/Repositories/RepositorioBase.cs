using AMVTravel.Domain.Commons;
using AMVTravel.Infrastructure.Interfaces;
using AMVTravel.Infrastructure.Persistences;
using Microsoft.EntityFrameworkCore;

namespace AMVTravel.Infrastructure.Repositories
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : EntidadBase
	{
        protected readonly AmvTravelDbContext _context;

		public RepositorioBase(AmvTravelDbContext context)
		{
            _context = context;
		}

        public async Task<bool> EliminarEntidad(T entidad)
        {
            _context.Set<T>().Remove(entidad);
            return await GuardarCambios();
        }

        public async Task<bool> InsertarEntidad(T entidad)
        {
            await _context.Set<T>().AddAsync(entidad);
            return await GuardarCambios();
        }

        public async Task<bool> ModificarEntidad(T entidad)
        {
            _context.Set<T>().Update(entidad);
            return await GuardarCambios();
        }

        public async Task<T> ObtenerPorId(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> ObtenerTodos()
        {
            return await _context.Set<T>().ToListAsync();
        }

        private async Task<bool> GuardarCambios()
        {
            return await _context.SaveChangesAsync() != 0 ? true : false;
        }
    }
}

