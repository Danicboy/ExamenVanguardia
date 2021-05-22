using Examen1Reservas.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen1Reservas.Domain
{
    public class EventoDomain
    {
        public string ValidarDescripcion(string descripcion)
        {
            if (string.IsNullOrEmpty(descripcion))
            {
                return Constantes.CampoObligatorio + "Descripcion";
            }

            return Constantes.ValidacionExitosa;
        }

        public string ValidarMobiliario(int mobiliario)
        {
            if (mobiliario == 0)
            {
                return Constantes.CampoObligatorio + "Descripcion";
            }

            return Constantes.ValidacionExitosa;
        }
    }
}
