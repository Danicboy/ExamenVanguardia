using System;
using System.Collections.Generic;

#nullable disable

namespace Examen1Reservas.Models.DBModels
{
    public partial class Evento
    {
        public Evento()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int MobiliarioId { get; set; }
        public bool Estado { get; set; }

        public virtual Mobiliario Mobiliario { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }

        public sealed class Builder
        {
            private readonly Evento _evento;

            public Builder(string descripcion, int mobiliarioId)
            {
                _evento = new Evento
                {
                    Descripcion = descripcion,
                    MobiliarioId = mobiliarioId
                };
            }

            public Builder withMore(DateTime fechaCreacion, bool estado)
            {
                _evento.FechaCreacion = fechaCreacion;
                _evento.Estado = estado;

                return this;
            }

            public Evento Construir()
            {
                return _evento;
            }
        }
    }
}
