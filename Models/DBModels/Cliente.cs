using System;
using System.Collections.Generic;

#nullable disable

namespace Examen1Reservas.Models.DBModels
{
    public partial class Cliente
    {
        public Cliente()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Edad { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }

        public sealed class Builder
        {
            private readonly Cliente _cliente;

            public Builder(string nombre, string apellido, int edad)
            {
                _cliente = new Cliente
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Edad = edad
                };
            }

            public Builder withMore(DateTime fechaRegistro, bool estado)
            {
                _cliente.FechaRegistro = fechaRegistro;
                _cliente.Estado = estado;

                return this;
            }

            public Cliente Construir()
            {
                return _cliente;
            }
        }
    }
}
