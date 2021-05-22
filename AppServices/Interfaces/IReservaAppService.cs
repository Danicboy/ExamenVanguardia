using Examen1Reservas.Helpers;
using Examen1Reservas.Models.DBModels;
using Examen1Reservas.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen1Reservas.AppServices.Interfaces
{
    public interface IReservaAppService
    {
        IEnumerable<ReservaDTO> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostReserva(Reserva reserva);
        Task<Response> PutReserva(Reserva reserva);
        Task<Response> DeleteReserva(int id);
    }
}
