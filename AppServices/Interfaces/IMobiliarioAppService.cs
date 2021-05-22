using Examen1Reservas.Helpers;
using Examen1Reservas.Models.DBModels;
using Examen1Reservas.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen1Reservas.AppServices.Interfaces
{
    public interface IMobiliarioAppService
    {
        IEnumerable<MobiliarioDTO> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostMobiliario(Mobiliario mobiliario);
        Task<Response> PutMobiliario(Mobiliario mobiliario);
        Task<Response> DeleteMobiliario(int id);
    }
}
