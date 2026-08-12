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
    public partial class Form1 : Form
    {
        private bool actualizandoGrillaPersonas;
        private List<Persona> personas;
        private List<Auto> autos;

        public Form1()
        {
            InitializeComponent();

            personas = new List<Persona>();
            autos = new List<Auto>();
        }

        private void ActualizarGrillaPersonas()
        {
            actualizandoGrillaPersonas = true;

            dgvPersonas.DataSource = null;
            dgvPersonas.DataSource = personas;

            dgvPersonas.ClearSelection();
            dgvPersonas.CurrentCell = null;

            actualizandoGrillaPersonas = false;
        }

        private void ActualizarGrillaAutos()
        {
            dgvAutos.DataSource = null;
            dgvAutos.DataSource = autos;

            dgvAutos.ClearSelection();
            dgvAutos.CurrentCell = null;
        }

        private void ActualizarGrillaAutosDePersonas()
        {
            if (dgvPersonas.CurrentRow == null)
            {
                dgvAutosDePersonas.DataSource = null;
                lblTotalAutos.Text = "El valor total de los autos es de: $0.00";
                return;
            }

            Persona personaSeleccionada = (Persona)dgvPersonas.CurrentRow.DataBoundItem;

            dgvAutosDePersonas.DataSource = null;

            if(personaSeleccionada.Cantidad_de_autos() > 0)
            {
                dgvAutosDePersonas.DataSource = personaSeleccionada.Lista_de_autos();
            }

            dgvAutosDePersonas.ClearSelection();
            dgvAutosDePersonas.CurrentCell = null;

            decimal total = 0;
            foreach (Auto auto in personaSeleccionada.Lista_de_autos())
            {
                total = total + auto.Precio;
            }
             lblTotalAutos.Text = $"Valor total de los autos de {personaSeleccionada.Apellido}, {personaSeleccionada.Nombre}: ${total.ToString("N2")}";
        }

        private void ActualizarGrillaVistaGeneral()
        {
            List<AutoVista> listaVista = new List<AutoVista>();

            foreach (Auto auto in autos)
            {
                AutoVista autoVista = new AutoVista();

                autoVista.Marca = auto.Marca;
                autoVista.Año = auto.Año;
                autoVista.Modelo = auto.Modelo;
                autoVista.Patente = auto.Patente;

                if(auto.Dueño() != null)
                {
                    autoVista.DNI = auto.Dueño().DNI;
                    autoVista.ApellidoNombre = $"{auto.Dueño().Apellido}, {auto.Dueño().Nombre} ";
                }
                else
                {
                    autoVista.DNI = "--------";
                    autoVista.ApellidoNombre = "Sin dueño";
                }

                listaVista.Add(autoVista);
            }

            dgvVistaGeneral.DataSource = null;
            dgvVistaGeneral.DataSource = listaVista;
                
            dgvVistaGeneral.ClearSelection();
            dgvVistaGeneral.CurrentCell = null;
        }

        private void btnAgregarPersona_Click(object sender, EventArgs e)
        {
            FormPersona formulario = new FormPersona(personas);

            if(formulario.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Persona persona = new Persona(
                        formulario.DNI,
                        formulario.Nombre,
                        formulario.Apellido
                    );

                    personas.Add( persona );

                    ActualizarGrillaPersonas();
                }
                catch( Exception ex )
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnAgregarAuto_Click(object sender, EventArgs e)
        {
            FormAuto formulario = new FormAuto(autos);

            if(formulario.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Auto auto = new Auto(
                        formulario.Patente,
                        formulario.Marca,
                        formulario.Modelo,
                        formulario.Año,
                        formulario.Precio
                    );

                    autos.Add(auto);

                    ActualizarGrillaAutos();

                    ActualizarGrillaVistaGeneral();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnAsignarAuto_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvPersonas.CurrentRow == null)
                {
                    throw new Exception("Debe seleccionar una persona.");
                }

                if(dgvAutos.CurrentRow == null)
                {
                    throw new Exception("Debe seleccionar un auto.");
                }

                Persona personaSeleccionada = (Persona)dgvPersonas.CurrentRow.DataBoundItem;
                Auto autoSeleccionado = (Auto)dgvAutos.CurrentRow.DataBoundItem;

                personaSeleccionada.AgregarAuto(autoSeleccionado);

                ActualizarGrillaAutosDePersonas();

                ActualizarGrillaVistaGeneral();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvPersonas_SelectionChanged(object sender, EventArgs e)
        {
            if(actualizandoGrillaPersonas)
            {
                return;
            }

            ActualizarGrillaAutosDePersonas();
        }

        private void btnModificarPersona_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvPersonas.CurrentRow == null)
                {
                    throw new Exception("Debe seleccionar una persona.");
                }

                Persona personaSeleccionada = (Persona)dgvPersonas.CurrentRow.DataBoundItem;

                FormPersona formulario = new FormPersona(personas, personaSeleccionada);

                if(formulario.ShowDialog() == DialogResult.OK)
                {
                    personaSeleccionada.DNI = formulario.DNI;
                    personaSeleccionada.Nombre = formulario.Nombre;
                    personaSeleccionada.Apellido = formulario.Apellido;

                    ActualizarGrillaPersonas();
                    ActualizarGrillaVistaGeneral();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificarAuto_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvAutos.CurrentRow == null)
                {
                    throw new Exception("Debe seleccionar un auto.");
                }

                Auto autoSeleccionado = (Auto)dgvAutos.CurrentRow.DataBoundItem;

                FormAuto formulario = new FormAuto(autos, autoSeleccionado);

                if(formulario.ShowDialog() == DialogResult.OK)
                {
                    autoSeleccionado.Patente = formulario.Patente;
                    autoSeleccionado.Marca = formulario.Marca;
                    autoSeleccionado.Modelo = formulario.Modelo;
                    autoSeleccionado.Año = formulario.Año;
                    autoSeleccionado.Precio = formulario.Precio;

                    ActualizarGrillaAutos();
                    ActualizarGrillaAutosDePersonas();
                    ActualizarGrillaVistaGeneral();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBorrarPersona_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPersonas.CurrentRow == null)
                {
                    throw new Exception("Debe seleccionar una persona.");
                }

                Persona personaSeleccionada = (Persona)dgvPersonas.CurrentRow.DataBoundItem;

                DialogResult respuesta = MessageBox.Show(
                        "¿Seguro que desea borrar la persona seleccionada?",
                        "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                if(respuesta == DialogResult.Yes)
                {
                    foreach(Auto auto in personaSeleccionada.Lista_de_autos())
                    {
                        auto.QuitarDueño();
                    }

                    personas.Remove(personaSeleccionada);

                    ActualizarGrillaPersonas();
                    ActualizarGrillaAutosDePersonas();
                    ActualizarGrillaVistaGeneral();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBorrarAuto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAutos.CurrentRow == null)
                {
                    throw new Exception("Debe seleccionar un auto.");
                }

                Auto autoSeleccionado = (Auto)dgvAutos.CurrentRow.DataBoundItem;

                DialogResult respuesta = MessageBox.Show(
                        "¿Seguro que desea borrar el auto seleccionado?",
                        "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                if(respuesta == DialogResult.Yes)
                {
                    if(autoSeleccionado.Dueño() != null)
                    {
                        Persona dueño = autoSeleccionado.Dueño();

                        dueño.QuitarAuto(autoSeleccionado);
                        autoSeleccionado.QuitarDueño();
                    }

                    autos.Remove(autoSeleccionado);

                    ActualizarGrillaAutos();
                    ActualizarGrillaAutosDePersonas();
                    ActualizarGrillaVistaGeneral();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
