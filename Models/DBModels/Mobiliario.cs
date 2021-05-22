using System;
using System.Collections.Generic;

#nullable disable

namespace Examen1Reservas.Models.DBModels
{
    public partial class Mobiliario
    {
        public Mobiliario()
        {
            Eventos = new HashSet<Evento>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }

        public sealed class Builder
        {
            private readonly Mobiliario _mobiliario;

            public Builder(string descripcion)
            {
                _mobiliario = new Mobiliario
                {
                    Descripcion = descripcion
                };
            }

            public Builder withMore(DateTime fechaCreacion, bool estado)
            {
                _mobiliario.FechaCreacion = fechaCreacion;
                _mobiliario.Estado = estado;

                return this;
            }

            public Mobiliario Construir()
            {
                return _mobiliario;
            }
        }
    }
}
