using AMVTravel.Domain.Responses;
using AMVTravel.Infrastructure.Interfaces;
using AutoMapper;
using MediatR;

namespace AMVTravel.Application.Features.Tour.Commands
{
    public class ComandoEliminarTour : IRequest<RespuestaBase<bool>>
    {
        public ComandoEliminarTour(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }

    public class ComandoEliminarTourHandler : IRequestHandler<ComandoEliminarTour, RespuestaBase<bool>>
    {
        private readonly ITourRepositorio _repositorio;

        public ComandoEliminarTourHandler(ITourRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
        }

        public async Task<RespuestaBase<bool>> Handle(ComandoEliminarTour request, CancellationToken cancellationToken)
        {
            var entidad = await _repositorio.ObtenerPorId(request.Id);
            if (entidad == null)
            {
                return new RespuestaBase<bool>
                {
                    Codigo = 404,
                    Data = false,
                    Mensaje = $"No se encontro el tour a eliminar por el Id = {request.Id}"
                };
            }
            var response = await _repositorio.EliminarEntidad(entidad);

            return new RespuestaBase<bool>
            {
                Codigo = 200,
                Data = response,
                Mensaje = response ? "El tour se elimino correctamente" : "El tour no se pudo eliminar"
            };
        }
    }
}

