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
    public class ReservaAppService : IReservaAppService
    {
        private readonly MobiliarioContext _context;
        private readonly ReservaDomain _reservaDomain;

        public ReservaAppService(MobiliarioContext context, ReservaDomain reservaDomain)
        {
            _context = context;
            _reservaDomain = reservaDomain;
        }
        public async Task<Response> DeleteReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return new Response { Mensaje = "No existe esta reserva" };
            }

            reserva.Estado = false;
            _context.Entry(reserva).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Reserva ELIMINADO!!!!" };
        }

        public IEnumerable<ReservaDTO> GetAll()
        {
            var reserva = _context.Reservas.Where(x => x.Estado == Constantes.Activo);
            var reservaDTO = ReservaDTO.ModelToDTO(reserva);
            return reservaDTO;
        }

        public async Task<Response> GetById(long id)
        {
            var reserva = await _context.Reservas.FirstOrDefaultAsync(x => x.Id == id);
            if (reserva == null)
            {
                return new Response { Mensaje = "Esta reserva  no existe" };
            }

            var data = ReservaDTO.ModelToDTO(reserva);
            return new Response { Datos = data };
        }

        public async Task<Response> PostReserva(Reserva reserva)
        {
            string mensaje = _reservaDomain.ValidarCliente(reserva.ClienteId);
            if (!mensaje.Equals(Constantes.ValidacionExitosa))
            {
                return new Response { Mensaje = mensaje };
            }

            string mensaje2 = _reservaDomain.ValidarEvento(reserva.EventoId);
            if (!mensaje2.Equals(Constantes.ValidacionExitosa))
            {
                return new Response { Mensaje = mensaje2 };
            }

            string mensaje3 = _reservaDomain.ValidarHora(reserva.Hora.ToString());
            if (!mensaje3.Equals(Constantes.ValidacionExitosa))
            {
                return new Response { Mensaje = mensaje3 };
            }

            var validarEdad = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == reserva.ClienteId);

            if (validarEdad.Edad < 21 )
            {
                return new Response { Mensaje = "Cliente menor de 21 anios " };
            }

            if (reserva.Hora < TimeSpan.Parse("15:00:00") || reserva.Hora > TimeSpan.Parse("23:00:00"))
            {
                return new Response { Mensaje = "Reserva no valida por hora" };
            }

            var guardarReserva = await _context.Reservas.FirstOrDefaultAsync(x => x.Id == reserva.Id);
            if (guardarReserva != null)
            {
                return new Response { Mensaje = "Reserva ya existe" };
            }

            reserva.Estado = true;
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return new Response { Mensaje = "Reserva creado con exito" };
        }

        public async Task<Response> PutReserva(Reserva reserva)
        {
            _context.Entry(reserva).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Rserva actualizado" };
        }
    }
}
