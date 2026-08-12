using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Actividad_Integradora_1
{
    public partial class FormPersona : Form
    {

        // Lista de persona existentes, utilizada para validar que el DNI no se repita
        private List<Persona> personas;
        // Persona que se está modificando
        // Es null cuando el formulario se utiliza par agregar una persona nueva
        private Persona personaActual;

        // Constructor utilizara para agregar una persona nueva
        public FormPersona(List<Persona> personas)
        {
            InitializeComponent();

            this.personas = personas;
            this.personaActual = null;
        }

        // Constructor utilizado para modificar una persona existente.
        // Carga en los TextBox los datos actuales de la persona.
        public FormPersona(List<Persona> personas, Persona personaActual)
        {
            InitializeComponent();

            this.personas = personas;
            this.personaActual = personaActual;

            txtDNI.Text = personaActual.DNI;
            txtNombre.Text = personaActual.Nombre;
            txtApellido.Text = personaActual.Apellido;
        }

        // Devuelve el DNI ingresado sin espacios al principio o al final
        public string DNI
        {
            get { return txtDNI.Text.Trim(); }
        }

        // Devuelve el nombre con el formato de letra capital
        public string Nombre
        {
            get { return FormatearNombre(txtNombre.Text); }
        }

        // Devuelve el apellido con el formato de letra capital
        public string Apellido
        {
            get { return FormatearNombre(txtApellido.Text); }
        }

        // Elimina espacios innecesarios y coloca en mayúscula
        // la primera letra de cada palabra
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
            {  //Validación de campos obligatorios, formatos y de no duplicación de DNI
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
                {   // Se excluye persona actual para permitir conservar su propio DNI al modificar
                    if(persona != personaActual && persona.DNI == DNI)
                    {
                        throw new Exception("Ya existe una persona con ese DNI.");
                    }
                }
                // Si todas las validaciones fueron correctas, se cierra el formulario
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
