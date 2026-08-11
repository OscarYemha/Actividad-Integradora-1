namespace Actividad_Integradora_1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPersonas = new System.Windows.Forms.DataGridView();
            this.dgvAutos = new System.Windows.Forms.DataGridView();
            this.dgvAutosDePersonas = new System.Windows.Forms.DataGridView();
            this.dgvVistaGeneral = new System.Windows.Forms.DataGridView();
            this.btnAgregarPersona = new System.Windows.Forms.Button();
            this.btnAgregarAuto = new System.Windows.Forms.Button();
            this.btnModificarPersona = new System.Windows.Forms.Button();
            this.btnModificarAuto = new System.Windows.Forms.Button();
            this.btnBorrarPersona = new System.Windows.Forms.Button();
            this.btnBorrarAuto = new System.Windows.Forms.Button();
            this.btnAsignarAuto = new System.Windows.Forms.Button();
            this.lblTotalAutos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutosDePersonas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVistaGeneral)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPersonas
            // 
            this.dgvPersonas.AllowUserToAddRows = false;
            this.dgvPersonas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonas.Location = new System.Drawing.Point(83, 12);
            this.dgvPersonas.MultiSelect = false;
            this.dgvPersonas.Name = "dgvPersonas";
            this.dgvPersonas.ReadOnly = true;
            this.dgvPersonas.RowHeadersVisible = false;
            this.dgvPersonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonas.Size = new System.Drawing.Size(300, 150);
            this.dgvPersonas.TabIndex = 0;
            this.dgvPersonas.SelectionChanged += new System.EventHandler(this.dgvPersonas_SelectionChanged);
            // 
            // dgvAutos
            // 
            this.dgvAutos.AllowUserToAddRows = false;
            this.dgvAutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutos.Location = new System.Drawing.Point(389, 12);
            this.dgvAutos.MultiSelect = false;
            this.dgvAutos.Name = "dgvAutos";
            this.dgvAutos.ReadOnly = true;
            this.dgvAutos.RowHeadersVisible = false;
            this.dgvAutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAutos.Size = new System.Drawing.Size(300, 150);
            this.dgvAutos.TabIndex = 1;
            // 
            // dgvAutosDePersonas
            // 
            this.dgvAutosDePersonas.AllowUserToAddRows = false;
            this.dgvAutosDePersonas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAutosDePersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutosDePersonas.Location = new System.Drawing.Point(83, 168);
            this.dgvAutosDePersonas.MultiSelect = false;
            this.dgvAutosDePersonas.Name = "dgvAutosDePersonas";
            this.dgvAutosDePersonas.ReadOnly = true;
            this.dgvAutosDePersonas.RowHeadersVisible = false;
            this.dgvAutosDePersonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAutosDePersonas.Size = new System.Drawing.Size(300, 150);
            this.dgvAutosDePersonas.TabIndex = 2;
            // 
            // dgvVistaGeneral
            // 
            this.dgvVistaGeneral.AllowUserToAddRows = false;
            this.dgvVistaGeneral.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVistaGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVistaGeneral.Location = new System.Drawing.Point(389, 168);
            this.dgvVistaGeneral.MultiSelect = false;
            this.dgvVistaGeneral.Name = "dgvVistaGeneral";
            this.dgvVistaGeneral.ReadOnly = true;
            this.dgvVistaGeneral.RowHeadersVisible = false;
            this.dgvVistaGeneral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVistaGeneral.Size = new System.Drawing.Size(300, 150);
            this.dgvVistaGeneral.TabIndex = 3;
            // 
            // btnAgregarPersona
            // 
            this.btnAgregarPersona.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPersona.Location = new System.Drawing.Point(104, 359);
            this.btnAgregarPersona.Name = "btnAgregarPersona";
            this.btnAgregarPersona.Size = new System.Drawing.Size(75, 40);
            this.btnAgregarPersona.TabIndex = 4;
            this.btnAgregarPersona.Text = "Agregar persona";
            this.btnAgregarPersona.UseVisualStyleBackColor = true;
            this.btnAgregarPersona.Click += new System.EventHandler(this.btnAgregarPersona_Click);
            // 
            // btnAgregarAuto
            // 
            this.btnAgregarAuto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarAuto.Location = new System.Drawing.Point(185, 359);
            this.btnAgregarAuto.Name = "btnAgregarAuto";
            this.btnAgregarAuto.Size = new System.Drawing.Size(75, 40);
            this.btnAgregarAuto.TabIndex = 5;
            this.btnAgregarAuto.Text = "Agregar auto";
            this.btnAgregarAuto.UseVisualStyleBackColor = true;
            this.btnAgregarAuto.Click += new System.EventHandler(this.btnAgregarAuto_Click);
            // 
            // btnModificarPersona
            // 
            this.btnModificarPersona.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarPersona.Location = new System.Drawing.Point(266, 359);
            this.btnModificarPersona.Name = "btnModificarPersona";
            this.btnModificarPersona.Size = new System.Drawing.Size(75, 40);
            this.btnModificarPersona.TabIndex = 6;
            this.btnModificarPersona.Text = "Modificar persona";
            this.btnModificarPersona.UseVisualStyleBackColor = true;
            this.btnModificarPersona.Click += new System.EventHandler(this.btnModificarPersona_Click);
            // 
            // btnModificarAuto
            // 
            this.btnModificarAuto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarAuto.Location = new System.Drawing.Point(347, 359);
            this.btnModificarAuto.Name = "btnModificarAuto";
            this.btnModificarAuto.Size = new System.Drawing.Size(75, 40);
            this.btnModificarAuto.TabIndex = 7;
            this.btnModificarAuto.Text = "Modificar auto";
            this.btnModificarAuto.UseVisualStyleBackColor = true;
            this.btnModificarAuto.Click += new System.EventHandler(this.btnModificarAuto_Click);
            // 
            // btnBorrarPersona
            // 
            this.btnBorrarPersona.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarPersona.Location = new System.Drawing.Point(428, 359);
            this.btnBorrarPersona.Name = "btnBorrarPersona";
            this.btnBorrarPersona.Size = new System.Drawing.Size(75, 40);
            this.btnBorrarPersona.TabIndex = 8;
            this.btnBorrarPersona.Text = "Borrar persona";
            this.btnBorrarPersona.UseVisualStyleBackColor = true;
            this.btnBorrarPersona.Click += new System.EventHandler(this.btnBorrarPersona_Click);
            // 
            // btnBorrarAuto
            // 
            this.btnBorrarAuto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarAuto.Location = new System.Drawing.Point(509, 359);
            this.btnBorrarAuto.Name = "btnBorrarAuto";
            this.btnBorrarAuto.Size = new System.Drawing.Size(75, 40);
            this.btnBorrarAuto.TabIndex = 9;
            this.btnBorrarAuto.Text = "Borrar auto";
            this.btnBorrarAuto.UseVisualStyleBackColor = true;
            this.btnBorrarAuto.Click += new System.EventHandler(this.btnBorrarAuto_Click);
            // 
            // btnAsignarAuto
            // 
            this.btnAsignarAuto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarAuto.Location = new System.Drawing.Point(590, 359);
            this.btnAsignarAuto.Name = "btnAsignarAuto";
            this.btnAsignarAuto.Size = new System.Drawing.Size(75, 40);
            this.btnAsignarAuto.TabIndex = 10;
            this.btnAsignarAuto.Text = "Asignar auto";
            this.btnAsignarAuto.UseVisualStyleBackColor = true;
            this.btnAsignarAuto.Click += new System.EventHandler(this.btnAsignarAuto_Click);
            // 
            // lblTotalAutos
            // 
            this.lblTotalAutos.AutoSize = true;
            this.lblTotalAutos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAutos.Location = new System.Drawing.Point(188, 330);
            this.lblTotalAutos.Name = "lblTotalAutos";
            this.lblTotalAutos.Size = new System.Drawing.Size(195, 16);
            this.lblTotalAutos.TabIndex = 11;
            this.lblTotalAutos.Text = "Valor total de los autos de... $";
            this.lblTotalAutos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTotalAutos);
            this.Controls.Add(this.btnAsignarAuto);
            this.Controls.Add(this.btnBorrarAuto);
            this.Controls.Add(this.btnBorrarPersona);
            this.Controls.Add(this.btnModificarAuto);
            this.Controls.Add(this.btnModificarPersona);
            this.Controls.Add(this.btnAgregarAuto);
            this.Controls.Add(this.btnAgregarPersona);
            this.Controls.Add(this.dgvVistaGeneral);
            this.Controls.Add(this.dgvAutosDePersonas);
            this.Controls.Add(this.dgvAutos);
            this.Controls.Add(this.dgvPersonas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutosDePersonas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVistaGeneral)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPersonas;
        private System.Windows.Forms.DataGridView dgvAutos;
        private System.Windows.Forms.DataGridView dgvAutosDePersonas;
        private System.Windows.Forms.DataGridView dgvVistaGeneral;
        private System.Windows.Forms.Button btnAgregarPersona;
        private System.Windows.Forms.Button btnAgregarAuto;
        private System.Windows.Forms.Button btnModificarPersona;
        private System.Windows.Forms.Button btnModificarAuto;
        private System.Windows.Forms.Button btnBorrarPersona;
        private System.Windows.Forms.Button btnBorrarAuto;
        private System.Windows.Forms.Button btnAsignarAuto;
        private System.Windows.Forms.Label lblTotalAutos;
    }
}

