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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClienteDTO>> GetAll()
        {
            var result = _clienteAppService.GetAll();

            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(long id)
        {
            return Ok(await _clienteAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> PostCliente(Cliente cliente)
        {
            return Ok(await _clienteAppService.PostCliente(cliente));
        }

        [HttpPut]
        public async Task<ActionResult<Response>> PutCliente(Cliente cliente)
        {
            return Ok(await _clienteAppService.PutCliente(cliente));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteCliente(int id)
        {
            return Ok(await _clienteAppService.DeleteCliente(id));
        }

    }
}
