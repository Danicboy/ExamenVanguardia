using Examen1Reservas.AppServices.Interfaces;
using Examen1Reservas.Context;
using Examen1Reservas.Domain;
using Examen1Reservas.Helpers;
using Examen1Reservas.Models.DBModels;
using Examen1Reservas.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen1Reservas.AppServices
{
    public class ClienteAppService : IClienteAppService
    {

        private readonly MobiliarioContext _context;
        private readonly ClienteDomain _clienteDomain;

        public ClienteAppService(MobiliarioContext context, ClienteDomain clienteDomain)
        {
            _context = context;
            _clienteDomain = clienteDomain;
        }

        public async Task<Response> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return new Response { Mensaje = "No existe este cliente" };
            }

            cliente.Estado = false;
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Cliente {cliente.Nombre + cliente.Apellido} ELIMINADO!!!!" };
        }

        public IEnumerable<ClienteDTO> GetAll()
        {
            var cliente = _context.Clientes.Where(x => x.Estado == Constantes.Activo);
            var clienteDTO = ClienteDTO.ModelToDTO(cliente);
            return clienteDTO;
        }

        public async Task<Response> GetById(long id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if (cliente == null)
            {
                return new Response { Mensaje = "Este cliente no existe" };
            }

            var data = ClienteDTO.ModelToDTO(cliente);
            return new Response { Datos = data };
        }

        public async Task<Response> PostCliente(Cliente cliente)
        {
            string mensaje = _clienteDomain.ValidarNombre(cliente.Nombre);
            if (!mensaje.Equals(Constantes.ValidacionExitosa))
            {
                return new Response { Mensaje = mensaje };
            }

            string mensaje2 = _clienteDomain.ValidarApellido(cliente.Apellido);
            if (!mensaje2.Equals(Constantes.ValidacionExitosa))
            {
                return new Response { Mensaje = mensaje2 };
            }

            string mensaje3 = _clienteDomain.ValidarEdad(cliente.Edad);
            if (!mensaje3.Equals(Constantes.ValidacionExitosa))
            {
                return new Response { Mensaje = mensaje3 };
            }

            var guardarCliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Nombre == cliente.Nombre && x.Apellido == cliente.Apellido);
            if (guardarCliente != null)
            {
                return new Response { Mensaje = "Cliente ya existe" };
            }

            cliente.FechaRegistro = DateTime.Now;
            cliente.Estado = true;

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return new Response { Mensaje = "Cliente creado con exito" };

        }

        public async Task<Response> PutCliente(Cliente cliente)
        {
            cliente.FechaRegistro = DateTime.Now;
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Cliente {cliente.Nombre + cliente.Apellido} actualizado" };
        }
    }
}
