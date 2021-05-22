using Examen1Reservas.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen1Reservas.Domain
{
    public class ReservaDomain
    {
        public string ValidarCliente(int cliente)
        {
            if (cliente == 0)
            {
                return Constantes.CampoObligatorio + "Cliente";
            }

            return Constantes.ValidacionExitosa;
        }

        public string ValidarEvento(int evento)
        {
            if (evento == 0)
            {
                return Constantes.CampoObligatorio + "Evento";
            }

            return Constantes.ValidacionExitosa;
        }

        public string ValidarHora(string hora)
        {
            if (string.IsNullOrEmpty(hora))
            {
                return Constantes.CampoObligatorio + "Descripcion";
            }

            return Constantes.ValidacionExitosa;
        }
    }
}
