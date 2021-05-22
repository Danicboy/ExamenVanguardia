using Examen1Reservas.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen1Reservas.Models.DTOs
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int EventoId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public bool Estado { get; set; }

        public static ReservaDTO ModelToDTO(Reserva reserva)
        {
            return reserva != null ? new ReservaDTO
            {
                Id = reserva.Id,
                ClienteId = reserva.ClienteId,
                EventoId = reserva.EventoId,
                Fecha = reserva.Fecha,
                Hora = reserva.Hora,
                Estado = reserva.Estado
            } : null;
        }

        public static IEnumerable<ReservaDTO> ModelToDTO(IEnumerable<Reserva> reserva)
        {
            if (reserva == null)
            {
                return new List<ReservaDTO>();
            }

            List<ReservaDTO> reservaData = new List<ReservaDTO>();

            foreach (var item in reserva)
            {
                reservaData.Add(ModelToDTO(item));
            }

            return reservaData;
        }

        public static Mobiliario DTOToModel(MobiliarioDTO mobiliarioDTO)
        {
            return mobiliarioDTO != null ? new Mobiliario.Builder(mobiliarioDTO.Descripcion).withMore(mobiliarioDTO.FechaCreacion, mobiliarioDTO.Estado).Construir() : null;
        }
    }
}
