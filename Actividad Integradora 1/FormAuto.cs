using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Actividad_Integradora_1
{
    public partial class FormAuto : Form
    {   // Lista de autos existentes, utilizada para validar qe la patente no se repita
        private List<Auto> autos;
        // Auto que se está modificando.
        // Es null cuando el formulario se utiliza para agregar un auto nuevo
        private Auto autoActual;

        // Constructor utilizado para agregar un auto nuevo
        public FormAuto(List<Auto> autos)
        {
            InitializeComponent();
            this.autos = autos;
            autoActual = null;
        }

        // Constructor utilizado para modificar un auto existente
        // Carga en los TextBox los datos acutales del auto
        public FormAuto(List<Auto> autos, Auto autoActual)
        {
            InitializeComponent();

            this.autos = autos;
            this.autoActual = autoActual;

            txtPatente.Text = autoActual.Patente;
            txtMarca.Text = autoActual.Marca;
            txtModelo.Text = autoActual.Modelo;
            txtAño.Text = autoActual.Año;
            txtPrecio.Text = autoActual.Precio.ToString();
        }

        // Devuelve la patente sin espacios en los extremos y en mayúsculas
        public string Patente
        {
            get { return txtPatente.Text.Trim().ToUpper(); }
        }

        // Devuelve la marca con formato de letra capital
        public string Marca
        {
            get { return FormatearTexto(txtMarca.Text); }
        }

        // Devuelve el modelo con formato de letra capital
        public string Modelo
        {
            get { return FormatearTexto(txtModelo.Text); }
        }

        public string Año
        {
            get { return txtAño.Text; }
        }

        public decimal Precio
        {
            get { return decimal.Parse(txtPrecio.Text); }
        }

        // Elimina espacios innecesarios y coloca en mayúscula
        // la primera letra de cada palabra
        private string FormatearTexto(string texto)
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

                    resultado += $"{char.ToUpper(palabra[0])}{palabra.Substring(1)}";
                }
            }
            return resultado;
        }

        // Verifica los dos formatos de patentes admitidos:
        // ABC123 y AB123CD
        private bool PatenteValida(string patente)
        {
            patente = patente.Trim().ToUpper();

            if(patente.Length == 6)
            {   // Formato ABC123
                return char.IsLetter(patente[0]) &&
                       char.IsLetter(patente[1]) &&
                       char.IsLetter(patente[2]) &&
                       char.IsDigit(patente[3]) &&
                       char.IsDigit(patente[4]) &&
                       char.IsDigit(patente[5]);
            }

            if(patente.Length == 7)
            {   // Formato AB123CD
                return char.IsLetter(patente[0]) &&
                       char.IsLetter(patente[1]) &&
                       char.IsDigit(patente[2]) &&
                       char.IsDigit(patente[3]) &&
                       char.IsDigit(patente[4]) &&
                       char.IsLetter(patente[5]) &&
                       char.IsLetter(patente[6]);
            }
            return false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {   // Validación de campos obligatorios, formatos y que no haya patentes duplicadas
                if(string.IsNullOrWhiteSpace(txtPatente.Text))
                {
                    throw new Exception("Debe ingresar una patente.");
                }

                if(!PatenteValida(txtPatente.Text))
                {
                    throw new Exception("La patente debe tener formato ABC123 ó AB123CD");
                }

                if (string.IsNullOrWhiteSpace(txtMarca.Text))
                {
                    throw new Exception("Debe ingresar una marca.");
                }

                if (string.IsNullOrWhiteSpace(txtModelo.Text))
                {
                    throw new Exception("Debe ingresar un modelo.");
                }

                if (string.IsNullOrWhiteSpace(txtAño.Text))
                {
                    throw new Exception("Debe ingresar un año.");
                }

                int año;
                if(!int.TryParse(txtAño.Text, out año))
                {
                    throw new Exception("El año debe contener solamente números.");
                }

                if(año < 1885 || año > DateTime.Now.Year)
                {
                    throw new Exception("El año ingresado no es válido.");
                }

                decimal precio;
                if (!decimal.TryParse(txtPrecio.Text, out precio))
                {
                    throw new Exception("El precio debe ser un número válido.");
                }

                if (precio <= 0)
                {
                    throw new Exception("El precio debe ser mayor que cero.");
                }

                foreach(Auto auto in autos)
                {
                    if(auto != autoActual && auto.Patente == Patente)
                    {
                        throw new Exception("Ya existe un auto con esa patente.");
                    }
                }
                // Si todas las validaciones fueron correctas, cierra el formulario
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
