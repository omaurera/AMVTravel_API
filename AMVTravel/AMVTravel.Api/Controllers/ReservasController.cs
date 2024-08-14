using AMVTravel.Application.Features.Reserva.Commands;
using AMVTravel.Application.Features.Reserva.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AMVTravel.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : Controller
    {
        private readonly IMediator _mediator;

        public ReservasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _mediator.Send(new ObtenerReservas()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            return Ok(await _mediator.Send(new ObtenerReservaPorId(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ComandoInsertarReserva comandoInsertar)
        {
            return Ok(await _mediator.Send(comandoInsertar));
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ComandoModificarReserva modificarTour)
        {
            return Ok(await _mediator.Send(modificarTour));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new ComandoEliminarRserva(id)));
        }
    }
}

