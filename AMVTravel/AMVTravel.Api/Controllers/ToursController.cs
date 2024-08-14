using AMVTravel.Application.Features.Tour.Commands;
using AMVTravel.Application.Features.Tour.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AMVTravel.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToursController : Controller
    {
        private readonly IMediator _mediator;

        public ToursController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _mediator.Send(new ObtenerTours()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            return Ok(await _mediator.Send(new ObtenerTourPorId(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]ComandoInsertarTour comandoInsertar)
        {
            return Ok(await _mediator.Send(comandoInsertar));
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody]ComandoModificarTour modificarTour)
        {
            return Ok(await _mediator.Send(modificarTour));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new ComandoEliminarTour(id)));
        }
    }
}

