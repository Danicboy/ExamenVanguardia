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
    public class MobiliarioAppService : IMobiliarioAppService
    {
        private readonly MobiliarioContext _context;
        private readonly MobiliarioDomain _mobiliarioDomain;

        public MobiliarioAppService(MobiliarioContext context, MobiliarioDomain mobiliarioDomain)
        {
            _context = context;
            _mobiliarioDomain = mobiliarioDomain;
        }
        public async Task<Response> DeleteMobiliario(int id)
        {
            var mobiliario = await _context.Mobiliarios.FindAsync(id);
            if (mobiliario == null)
            {
                return new Response { Mensaje = "No existe este mobiliario" };
            }

            mobiliario.Estado = false;
            _context.Entry(mobiliario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Mobiliario {mobiliario.Descripcion} ELIMINADO!!!!" };
        }

        public IEnumerable<MobiliarioDTO> GetAll()
        {
            var mobiliario = _context.Mobiliarios.Where(x => x.Estado == Constantes.Activo);
            var mobiliarioDTO = MobiliarioDTO.ModelToDTO(mobiliario);
            return mobiliarioDTO;
        }

        public async Task<Response> GetById(long id)
        {
            var mobiliario = await _context.Mobiliarios.FirstOrDefaultAsync(x => x.Id == id);
            if (mobiliario == null)
            {
                return new Response { Mensaje = "Este mobiliario no existe" };
            }

            var data = MobiliarioDTO.ModelToDTO(mobiliario);
            return new Response { Datos = data };
        }

        public async Task<Response> PostMobiliario(Mobiliario mobiliario)
        {
            string mensaje = _mobiliarioDomain.ValidarDescripcion(mobiliario.Descripcion);
            if (!mensaje.Equals(Constantes.ValidacionExitosa))
            {
                return new Response { Mensaje = mensaje };
            }

            var guardarMobiliario = await _context.Mobiliarios.FirstOrDefaultAsync(x => x.Descripcion == mobiliario.Descripcion);
            if (guardarMobiliario != null)
            {
                return new Response { Mensaje = "Mobiliario ya existe" };
            }

            mobiliario.FechaCreacion = DateTime.Now;
            mobiliario.Estado = true;

            _context.Mobiliarios.Add(mobiliario);
            await _context.SaveChangesAsync();

            return new Response { Mensaje = "Mobiliario creado con exito" };
        }

        public async Task<Response> PutMobiliario(Mobiliario mobiliario)
        {
            mobiliario.FechaCreacion = DateTime.Now;
            _context.Entry(mobiliario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Mobiliario {mobiliario.Descripcion} actualizado" };
        }
    }
}
