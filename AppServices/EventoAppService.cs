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
    public class EventoAppService: IEventoAppService
    {
        private readonly MobiliarioContext _context;
        private readonly EventoDomain _eventoDomain;

        public EventoAppService(MobiliarioContext context, EventoDomain eventoDomain)
        {
            _context = context;
            _eventoDomain = eventoDomain;
        }

        public async Task<Response> DeleteEvento(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return new Response { Mensaje = "No existe este evento" };
            }

            evento.Estado = false;
            _context.Entry(evento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Evento {evento.Descripcion} ELIMINADO!!!!" };
        }

        public IEnumerable<EventoDTO> GetAll()
        {
            var evento = _context.Eventos.Where(x => x.Estado == Constantes.Activo);
            var eventoDTO = EventoDTO.ModelToDTO(evento);
            return eventoDTO;
        }

        public async Task<Response> GetById(long id)
        {
            var evento = await _context.Eventos.FirstOrDefaultAsync(x => x.Id == id);
            if (evento == null)
            {
                return new Response { Mensaje = "Este evento  no existe" };
            }

            var data = EventoDTO.ModelToDTO(evento);
            return new Response { Datos = data };
        }

        public async Task<Response> PostEvento(Evento evento)
        {
            string mensaje = _eventoDomain.ValidarDescripcion(evento.Descripcion);
            if (!mensaje.Equals(Constantes.ValidacionExitosa))
            {
                return new Response { Mensaje = mensaje };
            }

            string mensaje2 = _eventoDomain.ValidarMobiliario(evento.MobiliarioId);
            if (!mensaje2.Equals(Constantes.ValidacionExitosa))
            {
                return new Response { Mensaje = mensaje2 };
            }

            var guardarEvento = await _context.Eventos.CountAsync(x => x.Descripcion == evento.Descripcion);
            if (guardarEvento >= 10)
            {
                return new Response { Mensaje = "Evento no puede guardar mas inmobiliario" };
            }

            evento.FechaCreacion = DateTime.Now;
            evento.Estado = true;

            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();

            return new Response { Mensaje = "Evento creado con exito" };
        }

        public async Task<Response> PutEvento(Evento evento)
        {
            evento.FechaCreacion = DateTime.Now;
            _context.Entry(evento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Evento {evento.Descripcion} actualizado" };
        }
    }
}
