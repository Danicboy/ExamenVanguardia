using Examen1Reservas.Helpers;
using Examen1Reservas.Models.DBModels;
using Examen1Reservas.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen1Reservas.AppServices.Interfaces
{
    public interface IEventoAppService
    {
        IEnumerable<EventoDTO> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostEvento(Evento evento);
        Task<Response> PutEvento(Evento evento);
        Task<Response> DeleteEvento(int id);
    }
}
