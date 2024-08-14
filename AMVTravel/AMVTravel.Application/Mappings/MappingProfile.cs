using AMVTravel.Application.Features.Reserva.Commands;
using AMVTravel.Application.Features.Tour.Commands;
using AMVTravel.Domain.Entities;
using AMVTravel.Domain.Responses;
using AutoMapper;

namespace AMVTravel.Application.Mappings
{
    public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<ComandoInsertarTour, Tour>().ReverseMap();
            CreateMap<ComandoModificarTour, Tour>().ReverseMap();
			CreateMap<RespuestaTour, Tour>().ReverseMap();
			CreateMap<ComandoInsertarReserva, Reserva>().ReverseMap();
			CreateMap<ComandoModificarReserva, Reserva>().ReverseMap();
            CreateMap<RespuestaReserva, Reserva>().ReverseMap();
			CreateMap<RespuestaUsuario, Usuario>().ReverseMap();
        }
	}
}

