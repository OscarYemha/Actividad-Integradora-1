using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Actividad_Integradora_1
{
    public class Persona
    {
        // Datos personales
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        // Lista de autos pertenecientes a la persona
        private List<Auto> autos;

        // Constructor
        public Persona(string dni, string nombre, string apellido)
        {
            DNI = dni;
            Nombre = nombre;
            Apellido = apellido;

            autos = new List<Auto>();
        }

        // Devuelve la lista de autos de la persona
        public List<Auto> Lista_de_autos()
        {
            return autos;
        }

        // Devuelve la cantidad de autos que posee la persona
        public int Cantidad_de_autos()
        {
            return autos.Count;
        }

        // Agrega un auto y establece a esta persona como su dueño
        public void AgregarAuto(Auto auto)
        {
            if (auto.Dueño() != null)
            {
                throw new Exception("El auto ya tiene dueño");
            }
            autos.Add(auto);
            auto.AsignarDueño(this);
        }

        // Elimina un auto de la lista de la persona
        public void QuitarAuto(Auto auto)
        {
            autos.Remove(auto);
        }

        // Finalizador
        ~Persona()
        {
            MessageBox.Show($"Se liberó la persona con DNI: {DNI}");
        }
    }
}
