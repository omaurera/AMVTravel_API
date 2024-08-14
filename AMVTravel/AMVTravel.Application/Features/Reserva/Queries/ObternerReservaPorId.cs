using AMVTravel.Domain.Responses;
using AMVTravel.Infrastructure.Interfaces;
using AutoMapper;
using MediatR;

namespace AMVTravel.Application.Features.Reserva.Queries
{
    public class ObtenerReservaPorId : IRequest<RespuestaBase<RespuestaReserva>>
    {
        public ObtenerReservaPorId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }

    public class ObtenerReservaPorIdHandler : IRequestHandler<ObtenerReservaPorId, RespuestaBase<RespuestaReserva>>
    {
        private readonly IReservaRepositorio _repositorio;
        private readonly ITourRepositorio _tourRepositorio;
        private readonly IMapper _mapper;

        public ObtenerReservaPorIdHandler(IReservaRepositorio repositorio, ITourRepositorio tourRepositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _tourRepositorio = tourRepositorio;
            _mapper = mapper;
        }

        public async Task<RespuestaBase<RespuestaReserva>> Handle(ObtenerReservaPorId request, CancellationToken cancellationToken)
        {
            var reserva = await _repositorio.ObtenerPorId(request.Id);
            var respuestaReserva = _mapper.Map<RespuestaReserva>(reserva);
            var tour = await _tourRepositorio.ObtenerPorId(reserva.TourId);
            respuestaReserva.Nombre = tour.Nombre;
            respuestaReserva.Destino = tour.Destino;
            respuestaReserva.FechaInicio = tour.FechaInicio;
            respuestaReserva.FechaFin = tour.FechaFin;
            respuestaReserva.Precio = tour.Precio;

            return new RespuestaBase<RespuestaReserva>
            {
                Codigo = 200,
                Data = respuestaReserva,
                Mensaje = "Ok"
            };
        }
    }
}

