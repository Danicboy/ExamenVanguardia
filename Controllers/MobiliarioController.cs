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
    public class MobiliarioController : ControllerBase
    {
        private readonly IMobiliarioAppService _mobiliarioAppService;

        public MobiliarioController(IMobiliarioAppService mobiliarioAppService)
        {
            _mobiliarioAppService = mobiliarioAppService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MobiliarioDTO>> GetAll()
        {
            var result = _mobiliarioAppService.GetAll();

            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(long id)
        {
            return Ok(await _mobiliarioAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> PostMobiliario(Mobiliario mobiliario)
        {
            return Ok(await _mobiliarioAppService.PostMobiliario(mobiliario));
        }

        [HttpPut]
        public async Task<ActionResult<Response>> PutMobiliario(Mobiliario mobiliario)
        {
            return Ok(await _mobiliarioAppService.PutMobiliario(mobiliario));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteMobiliario(int id)
        {
            return Ok(await _mobiliarioAppService.DeleteMobiliario(id));
        }
    }
}
