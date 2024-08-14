using AMVTravel.Domain.Responses;
using AMVTravel.Infrastructure.Interfaces;
using AutoMapper;
using MediatR;

namespace AMVTravel.Application.Features.Reserva.Commands
{
    public class ComandoEliminarRserva : IRequest<RespuestaBase<bool>>
    {
        public ComandoEliminarRserva(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }

    public class ComandoEliminarRservaHandler : IRequestHandler<ComandoEliminarRserva, RespuestaBase<bool>>
    {
        private readonly IReservaRepositorio _repositorio;

        public ComandoEliminarRservaHandler(IReservaRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
        }

        public async Task<RespuestaBase<bool>> Handle(ComandoEliminarRserva request, CancellationToken cancellationToken)
        {
            var entidad = await _repositorio.ObtenerPorId(request.Id);
            if (entidad == null)
            {
                return new RespuestaBase<bool>
                {
                    Codigo = 404,
                    Data = false,
                    Mensaje = $"No se encontro la reserva a eliminar por el Id = {request.Id}"
                };
            }
            var response = await _repositorio.EliminarEntidad(entidad);

            return new RespuestaBase<bool>
            {
                Codigo = 200,
                Data = response,
                Mensaje = response ? "La reserva se elimino correctamente" : "La reserva no se pudo eliminar"
            };
        }
    }
}

