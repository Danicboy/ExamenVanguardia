using Examen1Reservas.Helpers;
using Examen1Reservas.Models.DBModels;
using Examen1Reservas.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen1Reservas.AppServices.Interfaces
{
    public interface IClienteAppService
    {
        IEnumerable<ClienteDTO> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostCliente(Cliente cliente);
        Task<Response> PutCliente(Cliente cliente);
        Task<Response> DeleteCliente(int id);

    }
}
