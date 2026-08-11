using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actividad_Integradora_1
{
    public class Auto
    {
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Año { get; set; }
        public decimal Precio { get; set; }

        private Persona dueño;

        public Auto(string patente, string marca, string modelo, string año, decimal precio)
        {
            Patente = patente;
            Marca = marca;
            Modelo = modelo;
            Año = año;
            Precio = precio;

            dueño = null;
        }

        public Persona Dueño()
        {
            return dueño;
        }

        public void AsignarDueño(Persona persona)
        {
            dueño = persona;
        }

        public void QuitarDueño()
        {
            dueño = null;
        }

        ~Auto() 
        {
            MessageBox.Show($"Se liberó el auto con patente: {Patente}");
        }
    }
}
