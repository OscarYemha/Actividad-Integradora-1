using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Integradora_1
{
    public class AutoVista
    {
        // Datos del auto que se mostrarán en la grilla de vista general
        public string Marca { get; set; }
        public string Año { get; set; }
        public string Modelo { get; set; }
        public string Patente { get; set; }

        // Datos del dueño del auto
        public string DNI { get; set; }
        public string ApellidoNombre { get; set; }
    }
}
