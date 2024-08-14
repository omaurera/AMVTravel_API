using AMVTravel.Domain.Responses;
using AMVTravel.Infrastructure.Interfaces;
using AutoMapper;
using MediatR;

namespace AMVTravel.Application.Features.Tour.Commands
{
    public class ComandoInsertarTour : IRequest<RespuestaBase<bool>>
	{
        public string Nombre { get; set; }
        public string Destino { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Precio { get; set; }
    }

    public class ComandoInsertarTourHandler : IRequestHandler<ComandoInsertarTour, RespuestaBase<bool>>
    {
        private readonly ITourRepositorio _repositorio;
        private readonly IMapper _mapper;

        public ComandoInsertarTourHandler(ITourRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<RespuestaBase<bool>> Handle(ComandoInsertarTour request, CancellationToken cancellationToken)
        {
            var entidad = _mapper.Map<Domain.Entities.Tour>(request);
            entidad.Id = Guid.NewGuid();
            var response = await _repositorio.InsertarEntidad(entidad);

            return new RespuestaBase<bool>
            {
                Codigo = 200,
                Data = response,
                Mensaje = response ? "El tour se inserto correctamente" : "El tour no se pudo insertar"
            };
        }
    }
}

