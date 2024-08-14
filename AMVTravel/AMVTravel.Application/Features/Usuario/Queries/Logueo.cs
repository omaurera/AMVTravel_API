using AMVTravel.Domain.Responses;
using AMVTravel.Infrastructure.Interfaces;
using AutoMapper;
using MediatR;

namespace AMVTravel.Application.Features.Usuario.Queries
{
    public class Logueo : IRequest<RespuestaBase<RespuestaUsuario>>
    {
        public Logueo(string usuario, string contrasena)
        {
            Usuario = usuario;
            Contrasena = contrasena;
        }

        public string Usuario { get; set; }
        public string Contrasena { get; set; }
    }

    public class LogueoHandler : IRequestHandler<Logueo, RespuestaBase<RespuestaUsuario>>
    {
        private readonly IUsuarioRepositorio _repositorio;
        private readonly IMapper _mapper;

        public LogueoHandler(IUsuarioRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<RespuestaBase<RespuestaUsuario>> Handle(Logueo request, CancellationToken cancellationToken)
        {
            var usuario = await _repositorio.Loguearse(request.Usuario, request.Contrasena);
            var usuarioResponse = _mapper.Map<RespuestaUsuario>(usuario);

            if (usuarioResponse != null)
            {
                return new RespuestaBase<RespuestaUsuario>
                {
                    Codigo = 200,
                    Data = usuarioResponse,
                    Mensaje = "Ok"
                };
            }
            else
            {
                return new RespuestaBase<RespuestaUsuario>
                {
                    Codigo = 200,
                    Data = new RespuestaUsuario(),
                    Mensaje = "Usario y/o contrasena incorrecto"
                };
            }
        }
    }
}

