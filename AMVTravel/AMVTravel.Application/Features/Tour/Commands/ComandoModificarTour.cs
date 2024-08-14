using AMVTravel.Domain.Responses;
using AMVTravel.Infrastructure.Interfaces;
using AutoMapper;
using MediatR;

namespace AMVTravel.Application.Features.Tour.Commands
{
    public class ComandoModificarTour : IRequest<RespuestaBase<bool>>
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Destino { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Precio { get; set; }
    }

    public class ComandoModificarTourHandler : IRequestHandler<ComandoModificarTour, RespuestaBase<bool>>
    {
        private readonly ITourRepositorio _repositorio;
        private readonly IMapper _mapper;

        public ComandoModificarTourHandler(ITourRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<RespuestaBase<bool>> Handle(ComandoModificarTour request, CancellationToken cancellationToken)
        {
            var entidad = await _repositorio.ObtenerPorId(request.Id);
            if (entidad == null)
            {
                return new RespuestaBase<bool>
                {
                    Codigo = 404,
                    Data = false,
                    Mensaje = $"No se encontro el tour a modificar por el Id = {request.Id}"
                };
            }
            entidad = _mapper.Map<Domain.Entities.Tour>(request);
            var response = await _repositorio.ModificarEntidad(entidad);

            return new RespuestaBase<bool>
            {
                Codigo = 200,
                Data = response,
                Mensaje = response ? "El tour se modifico correctamente" : "El tour no se pudo modificar"
            };
        }
    }
}

