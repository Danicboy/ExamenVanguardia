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
    public class ReservaController : ControllerBase
    {
        private readonly IReservaAppService _reservaAppService;

        public ReservaController(IReservaAppService reservaAppService)
        {
            _reservaAppService = reservaAppService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReservaDTO>> GetAll()
        {
            var result = _reservaAppService.GetAll();

            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(long id)
        {
            return Ok(await _reservaAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> PostReserva(Reserva reserva)
        {
            return Ok(await _reservaAppService.PostReserva(reserva));
        }

        [HttpPut]
        public async Task<ActionResult<Response>> PutReserva(Reserva reserva)
        {
            return Ok(await _reservaAppService.PutReserva(reserva));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteReserva(int id)
        {
            return Ok(await _reservaAppService.DeleteReserva(id));
        }
    }
}
