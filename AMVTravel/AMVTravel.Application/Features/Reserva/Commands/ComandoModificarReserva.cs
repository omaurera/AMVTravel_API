using AMVTravel.Domain.Responses;
using AMVTravel.Infrastructure.Interfaces;
using AutoMapper;
using MediatR;

namespace AMVTravel.Application.Features.Reserva.Commands
{
    public class ComandoModificarReserva : IRequest<RespuestaBase<bool>>
    {
        public Guid Id { get; set; }
        public string Cliente { get; set; }
        public Guid TourId { get; set; }
    }

    public class ComandoModificarReservaHandler : IRequestHandler<ComandoModificarReserva, RespuestaBase<bool>>
    {
        private readonly IReservaRepositorio _repositorio;
        private readonly IMapper _mapper;

        public ComandoModificarReservaHandler(IReservaRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<RespuestaBase<bool>> Handle(ComandoModificarReserva request, CancellationToken cancellationToken)
        {
            var entidad = await _repositorio.ObtenerPorId(request.Id);
            if (entidad == null)
            {
                return new RespuestaBase<bool>
                {
                    Codigo = 404,
                    Data = false,
                    Mensaje = $"No se encontro la reserva a modificar por el Id = {request.Id}"
                };
            }
            entidad = _mapper.Map<Domain.Entities.Reserva>(request);
            var response = await _repositorio.ModificarEntidad(entidad);

            return new RespuestaBase<bool>
            {
                Codigo = 200,
                Data = response,
                Mensaje = response ? "La reserva se modifico correctamente" : "La reserva no se pudo modificar"
            };
        }
    }
}

