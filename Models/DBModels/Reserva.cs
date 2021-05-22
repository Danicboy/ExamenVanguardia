using System;
using System.Collections.Generic;

#nullable disable

namespace Examen1Reservas.Models.DBModels
{
    public partial class Reserva
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int EventoId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public bool Estado { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Evento Evento { get; set; }

        public sealed class Builder
        {
            private readonly Reserva _reserva;

            public Builder(int clienteId, int eventoId, TimeSpan hora)
            {
                _reserva = new Reserva
                {
                    ClienteId = clienteId,
                    EventoId = eventoId,
                    Hora = hora
                };
            }

            public Builder withMore(DateTime fecha, bool estado)
            {
                _reserva.Fecha = fecha;
                _reserva.Estado = estado;

                return this;
            }

            public Reserva Construir()
            {
                return _reserva;
            }
        }

        
    }
}
