using Examen1Reservas.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen1Reservas.Models.DTOs
{
    public class MobiliarioDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }

        public static MobiliarioDTO ModelToDTO(Mobiliario mobiliario)
        {
            return mobiliario != null ? new MobiliarioDTO
            {
                Id = mobiliario.Id,
                Descripcion = mobiliario.Descripcion,
                FechaCreacion = mobiliario.FechaCreacion,
                Estado = mobiliario.Estado
            } : null;
        }

        public static IEnumerable<MobiliarioDTO> ModelToDTO(IEnumerable<Mobiliario> mobiliario)
        {
            if (mobiliario == null)
            {
                return new List<MobiliarioDTO>();
            }

            List<MobiliarioDTO> mobiliarioData = new List<MobiliarioDTO>();

            foreach (var item in mobiliario)
            {
                mobiliarioData.Add(ModelToDTO(item));
            }

            return mobiliarioData;
        }

        public static Mobiliario DTOToModel(MobiliarioDTO mobiliarioDTO)
        {
            return mobiliarioDTO != null ? new Mobiliario.Builder(mobiliarioDTO.Descripcion).withMore(mobiliarioDTO.FechaCreacion, mobiliarioDTO.Estado).Construir() : null;
        }
    }
}
