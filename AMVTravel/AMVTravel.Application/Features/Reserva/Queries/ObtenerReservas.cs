using AMVTravel.Domain.Responses;
using AMVTravel.Infrastructure.Interfaces;
using AutoMapper;
using MediatR;

namespace AMVTravel.Application.Features.Reserva.Queries
{
    public class ObtenerReservas : IRequest<RespuestaBaseLista<RespuestaReserva>>
    {
    }

    public class ObtenerReservasHandler : IRequestHandler<ObtenerReservas, RespuestaBaseLista<RespuestaReserva>>
    {
        private readonly IReservaRepositorio _repositorio;
        private readonly ITourRepositorio _tourRepositorio;
        private readonly IMapper _mapper;

        public ObtenerReservasHandler(IReservaRepositorio repositorio, ITourRepositorio tourRepositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _tourRepositorio = tourRepositorio;
            _mapper = mapper;
        }

        public async Task<RespuestaBaseLista<RespuestaReserva>> Handle(ObtenerReservas request, CancellationToken cancellationToken)
        {
            var reservas = await _repositorio.ObtenerTodos();
            var respuestaReservas = new List<RespuestaReserva>();
            foreach (var reserva in reservas)
            {
                var tour = await _tourRepositorio.ObtenerPorId(reserva.TourId);
                var respuestaReserva = _mapper.Map<RespuestaReserva>(reserva);
                respuestaReserva.Nombre = tour.Nombre;
                respuestaReserva.Destino = tour.Destino;
                respuestaReserva.FechaInicio = tour.FechaInicio;
                respuestaReserva.FechaFin = tour.FechaFin;
                respuestaReserva.Precio = tour.Precio;
                respuestaReservas.Add(respuestaReserva);
            }

            return new RespuestaBaseLista<RespuestaReserva>
            {
                Codigo = 200,
                Data = respuestaReservas,
                Mensaje = "Ok"
            };
        }
    }
}

