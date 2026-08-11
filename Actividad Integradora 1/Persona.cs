using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Actividad_Integradora_1.Form1;

namespace Actividad_Integradora_1
{
    public class Persona
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        private List<Auto> autos;

        public Persona(string dni, string nombre, string apellido)
        {
            DNI = dni;
            Nombre = nombre;
            Apellido = apellido;

            autos = new List<Auto>();
        }

        public List<Auto> Lista_de_autos()
        {
            return autos;
        }

        public int Cantidad_de_autos()
        {
            return autos.Count;
        }

        public void AgregarAuto(Auto auto)
        {
            if (auto.Dueño() != null)
            {
                throw new Exception("El auto ya tiene dueño");
            }
            autos.Add(auto);
            auto.AsignarDueño(this);
        }

        public void QuitarAuto(Auto auto)
        {
            autos.Remove(auto);
        }

        ~Persona()
        {
            MessageBox.Show($"Se liberó la persona con DNI: {DNI}");
        }
    }
}
