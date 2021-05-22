using Examen1Reservas.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen1Reservas.Models.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Edad { get; set; }
        public bool Estado { get; set; }

        public static ClienteDTO ModelToDTO(Cliente cliente)
        {
            return cliente != null ? new ClienteDTO
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                FechaRegistro = cliente.FechaRegistro,
                Edad = cliente.Edad,
                Estado = cliente.Estado
            } : null;
        }

        public static IEnumerable<ClienteDTO> ModelToDTO(IEnumerable<Cliente> cliente)
        {
            if (cliente == null)
            {
                return new List<ClienteDTO>();
            }

            List<ClienteDTO> clienteData = new List<ClienteDTO>();

            foreach (var item in cliente)
            {
                clienteData.Add(ModelToDTO(item));
            }

            return clienteData;
        }

        public static Cliente DTOToModel(ClienteDTO clienteDTO)
        {
            return clienteDTO != null ? new Cliente.Builder(clienteDTO.Nombre, clienteDTO.Apellido, clienteDTO.Edad).withMore(clienteDTO.FechaRegistro, clienteDTO.Estado).Construir() : null;
        }
    }
}
