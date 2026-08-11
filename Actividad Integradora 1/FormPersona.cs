using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actividad_Integradora_1
{
    public partial class FormPersona : Form
    {

        private List<Persona> personas;
        private Persona personaActual;

        public FormPersona(List<Persona> personas)
        {
            InitializeComponent();

            this.personas = personas;
            this.personaActual = null;
        }

        public FormPersona(List<Persona> personas, Persona personaActual)
        {
            InitializeComponent();

            this.personas = personas;
            this.personaActual = personaActual;

            txtDNI.Text = personaActual.DNI;
            txtNombre.Text = personaActual.Nombre;
            txtApellido.Text = personaActual.Apellido;
        }

        public string DNI
        {
            get { return txtDNI.Text.Trim(); }
        }

        public string Nombre
        {
            get { return FormatearNombre(txtNombre.Text); }
        }

        public string Apellido
        {
            get { return FormatearNombre(txtApellido.Text); }
        }

        private string FormatearNombre(string texto)
        {
            string[] palabras = texto.Trim().ToLower().Split(' ');

            string resultado = "";

            foreach(string palabra in palabras)
            {
                if(palabra.Length > 0)
                {
                    if(resultado != "")
                    {
                        resultado += " ";
                    }

                    resultado += char.ToUpper(palabra[0]) + palabra.Substring(1);
                }
            }

            return resultado;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDNI.Text))
                {
                    throw new Exception("Debe ingresar un DNI.");
                }

                if(txtDNI.Text.Length < 7 || txtDNI.Text.Length > 8)
                {
                    throw new Exception("El DNI debe tener entre 7 y 8 números.");
                }

                long dni;
                if(!long.TryParse(txtDNI.Text, out dni))
                {
                    throw new Exception("El DNI debe contener solamente números.");
                }

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    throw new Exception("Debe ingresar un nombre.");
                }

                foreach(char caracter in txtNombre.Text)
                {
                    if(!char.IsLetter(caracter) && caracter != ' ')
                    {
                        throw new Exception("El nombre sólo puede contener letras y espacios.");
                    }
                }

                if (string.IsNullOrWhiteSpace(txtApellido.Text))
                {
                    throw new Exception("Debe ingresar un apellido.");
                }

                foreach (char caracter in txtApellido.Text)
                {
                    if (!char.IsLetter(caracter) && caracter != ' ')
                    {
                        throw new Exception("El apellido sólo puede contener letras y espacios.");
                    }
                }

                foreach(Persona persona in personas)
                {
                    if(persona != personaActual && persona.DNI == DNI)
                    {
                        throw new Exception("Ya existe una persona con ese DNI.");
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
