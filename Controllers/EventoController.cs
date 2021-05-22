using Examen1Reservas.AppServices.Interfaces;
using Examen1Reservas.Helpers;
using Examen1Reservas.Models.DBModels;
using Examen1Reservas.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen1Reservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoAppService _eventoAppService;

        public EventoController(IEventoAppService eventoAppService)
        {
            _eventoAppService = eventoAppService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventoDTO>> GetAll()
        {
            var result = _eventoAppService.GetAll();

            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(long id)
        {
            return Ok(await _eventoAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> PostEvento(Evento evento)
        {
            return Ok(await _eventoAppService.PostEvento(evento));
        }

        [HttpPut]
        public async Task<ActionResult<Response>> PutEvento(Evento evento)
        {
            return Ok(await _eventoAppService.PutEvento(evento));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteEvento(int id)
        {
            return Ok(await _eventoAppService.DeleteEvento(id));
        }
    }
}
