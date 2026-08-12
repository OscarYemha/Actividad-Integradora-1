using System.Windows.Forms;

namespace Actividad_Integradora_1
{
    public class Auto
    {
        // Datos del auto
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Año { get; set; }
        public decimal Precio { get; set; }

        // Persona propietaria del auto
        private Persona dueño;
        
        // Contructor
        public Auto(string patente, string marca, string modelo, string año, decimal precio)
        {
            Patente = patente;
            Marca = marca;
            Modelo = modelo;
            Año = año;
            Precio = precio;

            dueño = null;
        }

        // Devuelve el dueño actual del auto
        public Persona Dueño()
        {
            return dueño;
        }

        // Asigna una persona como dueño
        public void AsignarDueño(Persona persona)
        {
            dueño = persona;
        }

        // Deja el auto sin dueño
        public void QuitarDueño()
        {
            dueño = null;
        }

        // Finalizador
        ~Auto() 
        {
            MessageBox.Show($"Se liberó el auto con patente: {Patente}");
        }
    }
}
