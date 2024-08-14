using AMVTravel.Domain.Responses;
using AMVTravel.Infrastructure.Interfaces;
using AutoMapper;
using MediatR;

namespace AMVTravel.Application.Features.Tour.Queries
{
    public class ObtenerTourPorId : IRequest<RespuestaBase<RespuestaTour>>
	{
        public ObtenerTourPorId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
	}

    public class ObtenerTourPorIdHandler : IRequestHandler<ObtenerTourPorId, RespuestaBase<RespuestaTour>>
    {
        private readonly ITourRepositorio _repositorio;
        private readonly IMapper _mapper;

        public ObtenerTourPorIdHandler(ITourRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<RespuestaBase<RespuestaTour>> Handle(ObtenerTourPorId request, CancellationToken cancellationToken)
        {
            return new RespuestaBase<RespuestaTour>
            {
                Codigo = 200,
                Data = _mapper.Map<RespuestaTour>(await _repositorio.ObtenerPorId(request.Id)),
                Mensaje = "Ok"
            };
        }
    }
}
