using AMVTravel.Domain.Responses;
using AMVTravel.Infrastructure.Interfaces;
using AutoMapper;
using MediatR;

namespace AMVTravel.Application.Features.Tour.Queries
{
    public class ObtenerTours : IRequest<RespuestaBaseLista<RespuestaTour>>
	{
	}

    public class ObtenerToursHandler : IRequestHandler<ObtenerTours, RespuestaBaseLista<RespuestaTour>>
    {
        private readonly ITourRepositorio _repositorio;
        private readonly IMapper _mapper;

        public ObtenerToursHandler(ITourRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<RespuestaBaseLista<RespuestaTour>> Handle(ObtenerTours request, CancellationToken cancellationToken)
        {
            var tours = await _repositorio.ObtenerTodos();
            return new RespuestaBaseLista<RespuestaTour>
            {
                Codigo = 200,
                Data = _mapper.Map< IEnumerable<RespuestaTour>>(tours),
                Mensaje = "Ok"
            };
        }
    }
}

