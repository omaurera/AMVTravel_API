namespace AMVTravel.Infrastructure.Interfaces
{
    public interface IRepositorioBase<T>
	{
		Task<IEnumerable<T>> ObtenerTodos();
		Task<T> ObtenerPorId(Guid id);
		Task<bool> GuardarEntidad(T entidad);
		Task<bool> ModificarEntidad(T entidad);
		Task<bool> EliminarEntidad(T entidad);
	}
}

