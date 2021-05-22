using Examen1Reservas.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen1Reservas.Models.DTOs
{
    public class EventoDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int MobiliarioId { get; set; }
        public bool Estado { get; set; }

        public static EventoDTO ModelToDTO(Evento evento)
        {
            return evento != null ? new EventoDTO
            {
                Id = evento.Id,
                Descripcion = evento.Descripcion,
                FechaCreacion = evento.FechaCreacion,
                MobiliarioId = evento.MobiliarioId,
                Estado = evento.Estado
            } : null;
        }

        public static IEnumerable<EventoDTO> ModelToDTO(IEnumerable<Evento> evento)
        {
            if (evento == null)
            {
                return new List<EventoDTO>();
            }

            List<EventoDTO> eventoData = new List<EventoDTO>();

            foreach (var item in evento)
            {
                eventoData.Add(ModelToDTO(item));
            }

            return eventoData;
        }

        public static Evento DTOToModel(EventoDTO eventoDTO)
        {
            return eventoDTO != null ? new Evento.Builder(eventoDTO.Descripcion, eventoDTO.MobiliarioId).withMore(eventoDTO.FechaCreacion, eventoDTO.Estado).Construir() : null;
        }
    }
}
