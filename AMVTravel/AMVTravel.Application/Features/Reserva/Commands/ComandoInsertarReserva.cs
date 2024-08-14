using AMVTravel.Domain.Responses;
using AMVTravel.Infrastructure.Interfaces;
using AutoMapper;
using MediatR;

namespace AMVTravel.Application.Features.Reserva.Commands
{
    public class ComandoInsertarReserva : IRequest<RespuestaBase<bool>>
    {
        public string Cliente { get; set; }
        public Guid TourId { get; set; }
    }

    public class ComandoInsertarReservaHandler : IRequestHandler<ComandoInsertarReserva, RespuestaBase<bool>>
    {
        private readonly IReservaRepositorio _repositorio;
        private readonly IMapper _mapper;

        public ComandoInsertarReservaHandler(IReservaRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<RespuestaBase<bool>> Handle(ComandoInsertarReserva request, CancellationToken cancellationToken)
        {
            var entidad = _mapper.Map<Domain.Entities.Reserva>(request);
            entidad.Id = Guid.NewGuid();
            entidad.FechaReserva = DateTime.Now;
            var response = await _repositorio.InsertarEntidad(entidad);

            return new RespuestaBase<bool>
            {
                Codigo = 200,
                Data = response,
                Mensaje = response ? "La reserva se inserto correctamente" : "La reserva no se pudo insertar"
            };
        }
    }
}

