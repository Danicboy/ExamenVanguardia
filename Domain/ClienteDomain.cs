using Examen1Reservas.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen1Reservas.Domain
{
    public class ClienteDomain
    {
        public string ValidarNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return Constantes.CampoObligatorio + "Nombre";
            }

            return Constantes.ValidacionExitosa;
        }

        public string ValidarApellido(string apellido)
        {
            if (string.IsNullOrEmpty(apellido))
            {
                return Constantes.CampoObligatorio + "Apellido";
            }

            return Constantes.ValidacionExitosa;
        }

        public string ValidarEdad(int edad)
        {
            if (edad == 0)
            {
                return Constantes.CampoObligatorio + "Nombre";
            }

            return Constantes.ValidacionExitosa;
        }
    }
}
