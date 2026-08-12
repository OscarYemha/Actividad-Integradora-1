using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Actividad_Integradora_1
{
    public partial class Form1 : Form
    {
        // Listas principales donde se almacenan las personas y los autos
        private List<Persona> personas;
        private List<Auto> autos;
        // Evita ejecutar SelectionChanged mientras se está actualizando
        // el origen de datos de la grilla de personas
        private bool actualizandoGrillaPersonas;

        public Form1()
        {
            InitializeComponent();
            // Iniciliza las listas principales de la aplicación
            personas = new List<Persona>();
            autos = new List<Auto>();
        }

        // Actualiza la grilla principal de personas
        private void ActualizarGrillaPersonas()
        {   // Evita que SelectionChanged se ejecute durante la recarga
            actualizandoGrillaPersonas = true;

            dgvPersonas.DataSource = null;

            if(personas.Count > 0 )
            {
                dgvPersonas.DataSource = personas;
            }
            else
            {
                dgvPersonas.Columns.Clear();
            }

            // Deja la grilla sin una fila seleccionada automáticamente
            dgvPersonas.ClearSelection();
            dgvPersonas.CurrentCell = null;

            actualizandoGrillaPersonas = false;
        }

        // Actualiza la grilla principal de autos
        private void ActualizarGrillaAutos()
        {
            dgvAutos.DataSource = null;

            if (autos.Count > 0)
            {
                dgvAutos.DataSource = autos;
            }
            else
            {
                dgvAutos.Columns.Clear();
            }

                // Deja la grilla sin una fila seleccionada auutomáticamente
            dgvAutos.ClearSelection();
            dgvAutos.CurrentCell = null;
        }

        // Muestra los autos pertenecientes a la persona seleccionada
        // y calcula el valor total de los mismos.
        private void ActualizarGrillaAutosDePersonas()
        {
            // Si no hay una persona seleccionada, limpia la grilla y el total
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

            // Calcula la suma de los precios de todos los autos de la persona
            decimal total = 0;
            foreach (Auto auto in personaSeleccionada.Lista_de_autos())
            {
                total = total + auto.Precio;
            }
             lblTotalAutos.Text = $"Valor total de los autos de {personaSeleccionada.Apellido}, {personaSeleccionada.Nombre}: ${total.ToString("N2")}";
        }

        // Genera la vista general de autos combinando los datos
        // de cada auto con los datos de su dueño.
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

                // Si el auto tiene dueño, agrega sus datos a la vista
                if(auto.Dueño() != null)
                {
                    autoVista.DNI = auto.Dueño().DNI;
                    autoVista.ApellidoNombre = $"{auto.Dueño().Apellido}, {auto.Dueño().Nombre} ";
                }
                else
                {
                    // Permite mostrar también los autos que todavía no tiene dueño
                    autoVista.DNI = "--------";
                    autoVista.ApellidoNombre = "Sin dueño";
                }

                listaVista.Add(autoVista);
            }

            dgvVistaGeneral.DataSource = null;

            if (listaVista.Count > 0 )
            {
                dgvVistaGeneral.DataSource = listaVista;

                // Modifica únicamente los textos visibles de los encabezados
                dgvVistaGeneral.Columns["DNI"].HeaderText = "DNI del dueño";
                dgvVistaGeneral.Columns["ApellidoNombre"].HeaderText = "Apellido, nombre";
            }
            else
            {
                dgvVistaGeneral.Columns.Clear();
            }

                
            dgvVistaGeneral.ClearSelection();
            dgvVistaGeneral.CurrentCell = null;
        }

        private void btnAgregarPersona_Click(object sender, EventArgs e)
        {
            // Abre el formulario y le pasa la lista para validar DNIs duplicados
            FormPersona formulario = new FormPersona(personas);

            if(formulario.ShowDialog() == DialogResult.OK)
            {
                try
                {   // Crea y agrega la nueva persona con los datos ya validados
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
            // Abre el formulario y le pasa la lista para validar patentes duplicadas
            FormAuto formulario = new FormAuto(autos);

            if(formulario.ShowDialog() == DialogResult.OK)
            {
                try
                {   // Crea y agrega el nuevo auto con los datos ya validados
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

                // Obtiene los objetos asociados a las filas seleccionadas
                Persona personaSeleccionada = (Persona)dgvPersonas.CurrentRow.DataBoundItem;
                Auto autoSeleccionado = (Auto)dgvAutos.CurrentRow.DataBoundItem;

                // Agrega el auto seleccionado a la persona y establece a esa persona como su dueño
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
            // No actualiza la grilla secundaria mientras la grilla
            // de personas se encuentra en proceso de recarga
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

                // Abre el formulario cargando los datos actuales de la persona
                FormPersona formulario = new FormPersona(personas, personaSeleccionada);

                if(formulario.ShowDialog() == DialogResult.OK)
                {  
                    // Modifica el mismo objeto Persona con los nuevos datos
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

                // Abre el formulario cargando los datos actuales del auto
                FormAuto formulario = new FormAuto(autos, autoSeleccionado);

                if(formulario.ShowDialog() == DialogResult.OK)
                {
                    // Modifica el mismo objeto Auto con los nuevos datos
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
                    // Los autos de la persona siguen existiendo,
                    // pero quedan sin dueño
                    foreach(Auto auto in personaSeleccionada.Lista_de_autos())
                    {
                        auto.QuitarDueño();
                    }

                    // Elimina la persona de la lista principal
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
                    // Si el auto tiene dueño, primero se elimina
                    // de la lista de autos de esa persona.
                    if(autoSeleccionado.Dueño() != null)
                    {
                        Persona dueño = autoSeleccionado.Dueño();

                        dueño.QuitarAuto(autoSeleccionado);
                        autoSeleccionado.QuitarDueño();
                    }

                    // Elimina el auto de la lista principal
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
