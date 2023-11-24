namespace CapaPresentacion
{
    partial class AdministradorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministradorForm));
            this.pMenu = new System.Windows.Forms.Panel();
            this.cerrar = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.registrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarTiposDeConsultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarCitasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administracionDeDoctoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteCitasPorFechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteCitasPorDoctorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteCitasPorClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ubicacionOpciones = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.mensajeConexion = new System.Windows.Forms.Label();
            this.botonConexion = new FontAwesome.Sharp.IconButton();
            this.pMenu.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pMenu
            // 
            this.pMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(206)))), ((int)(((byte)(241)))));
            this.pMenu.Controls.Add(this.cerrar);
            this.pMenu.Controls.Add(this.menu);
            this.pMenu.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pMenu.Location = new System.Drawing.Point(-2, 0);
            this.pMenu.Name = "pMenu";
            this.pMenu.Size = new System.Drawing.Size(1054, 86);
            this.pMenu.TabIndex = 0;
            this.pMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.pMenu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.pMenu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // cerrar
            // 
            this.cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cerrar.CausesValidation = false;
            this.cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(206)))), ((int)(((byte)(241)))));
            this.cerrar.FlatAppearance.BorderSize = 0;
            this.cerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(150)))), ((int)(((byte)(186)))));
            this.cerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(150)))), ((int)(((byte)(186)))));
            this.cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cerrar.Image = ((System.Drawing.Image)(resources.GetObject("cerrar.Image")));
            this.cerrar.Location = new System.Drawing.Point(1010, 0);
            this.cerrar.Name = "cerrar";
            this.cerrar.Size = new System.Drawing.Size(44, 44);
            this.cerrar.TabIndex = 1;
            this.cerrar.UseMnemonic = false;
            this.cerrar.UseVisualStyleBackColor = false;
            this.cerrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(206)))), ((int)(((byte)(241)))));
            this.menu.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarToolStripMenuItem,
            this.administrarToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.inicioToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menu.Size = new System.Drawing.Size(1054, 38);
            this.menu.TabIndex = 2;
            this.menu.Text = "menu";
            this.menu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.menu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.menu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // registrarToolStripMenuItem
            // 
            this.registrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarTiposDeConsultaToolStripMenuItem,
            this.registrarCitasToolStripMenuItem});
          
            this.registrarToolStripMenuItem.Name = "registrarToolStripMenuItem";
            this.registrarToolStripMenuItem.Size = new System.Drawing.Size(110, 34);
            this.registrarToolStripMenuItem.Text = "Registrar";

            // 
            // registrarTiposDeConsultaToolStripMenuItem
            // 
            this.registrarTiposDeConsultaToolStripMenuItem.Name = "registrarTiposDeConsultaToolStripMenuItem";
            this.registrarTiposDeConsultaToolStripMenuItem.Size = new System.Drawing.Size(341, 34);
            this.registrarTiposDeConsultaToolStripMenuItem.Text = "Registrar tipos de consulta";
            this.registrarTiposDeConsultaToolStripMenuItem.Click += new System.EventHandler(this.registrarTiposDeConsultaToolStripMenuItem_Click);
            // 
            // registrarCitasToolStripMenuItem
            // 
            this.registrarCitasToolStripMenuItem.Name = "registrarCitasToolStripMenuItem";
            this.registrarCitasToolStripMenuItem.Size = new System.Drawing.Size(341, 34);
            this.registrarCitasToolStripMenuItem.Text = "Registro de Citas";
            this.registrarCitasToolStripMenuItem.Click += new System.EventHandler(this.registrarCitasToolStripMenuItem_Click);
            // 
            // administrarToolStripMenuItem
            // 
            this.administrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarClientesToolStripMenuItem,
            this.administracionDeDoctoresToolStripMenuItem});
            this.administrarToolStripMenuItem.Name = "administrarToolStripMenuItem";
            this.administrarToolStripMenuItem.Size = new System.Drawing.Size(169, 34);
            this.administrarToolStripMenuItem.Text = "Administracion";
            // 
            // administrarClientesToolStripMenuItem
            // 
            this.administrarClientesToolStripMenuItem.Name = "administrarClientesToolStripMenuItem";
            this.administrarClientesToolStripMenuItem.Size = new System.Drawing.Size(353, 34);
            this.administrarClientesToolStripMenuItem.Text = "Administracion de Clientes";
            this.administrarClientesToolStripMenuItem.Click += new System.EventHandler(this.administrarClientesToolStripMenuItem_Click);
            // 
            // administracionDeDoctoresToolStripMenuItem
            // 
            this.administracionDeDoctoresToolStripMenuItem.Name = "administracionDeDoctoresToolStripMenuItem";
            this.administracionDeDoctoresToolStripMenuItem.Size = new System.Drawing.Size(353, 34);
            this.administracionDeDoctoresToolStripMenuItem.Text = "Administracion de Doctores";
            this.administracionDeDoctoresToolStripMenuItem.Click += new System.EventHandler(this.administracionDeDoctoresToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteCitasPorFechaToolStripMenuItem,
            this.reporteCitasPorDoctorToolStripMenuItem,
            this.reporteCitasPorClienteToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(111, 34);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // reporteCitasPorFechaToolStripMenuItem
            // 
            this.reporteCitasPorFechaToolStripMenuItem.Name = "reporteCitasPorFechaToolStripMenuItem";
            this.reporteCitasPorFechaToolStripMenuItem.Size = new System.Drawing.Size(328, 34);
            this.reporteCitasPorFechaToolStripMenuItem.Text = "Reporte Citas por Fecha";
            this.reporteCitasPorFechaToolStripMenuItem.Click += new System.EventHandler(this.reporteCitasPorFechaToolStripMenuItem_Click);
            // 
            // reporteCitasPorDoctorToolStripMenuItem
            // 
            this.reporteCitasPorDoctorToolStripMenuItem.Name = "reporteCitasPorDoctorToolStripMenuItem";
            this.reporteCitasPorDoctorToolStripMenuItem.Size = new System.Drawing.Size(328, 34);
            this.reporteCitasPorDoctorToolStripMenuItem.Text = "Reporte Citas por Doctor";
            this.reporteCitasPorDoctorToolStripMenuItem.Click += new System.EventHandler(this.reporteCitasPorDoctorToolStripMenuItem_Click);
            // 
            // reporteCitasPorClienteToolStripMenuItem
            // 
            this.reporteCitasPorClienteToolStripMenuItem.Name = "reporteCitasPorClienteToolStripMenuItem";
            this.reporteCitasPorClienteToolStripMenuItem.Size = new System.Drawing.Size(328, 34);
            this.reporteCitasPorClienteToolStripMenuItem.Text = "Reporte Citas por Cliente";
            this.reporteCitasPorClienteToolStripMenuItem.Click += new System.EventHandler(this.reporteCitasPorClienteToolStripMenuItem_Click);
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(104, 34);
            this.inicioToolStripMenuItem.Text = "Bitacora";
            this.inicioToolStripMenuItem.Click += new System.EventHandler(this.inicioToolStripMenuItem_Click);
            // 
            // ubicacionOpciones
            // 
            this.ubicacionOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ubicacionOpciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.ubicacionOpciones.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ubicacionOpciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.ubicacionOpciones.Location = new System.Drawing.Point(-2, 165);
            this.ubicacionOpciones.Name = "ubicacionOpciones";
            this.ubicacionOpciones.Size = new System.Drawing.Size(1054, 492);
            this.ubicacionOpciones.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Estado del servidor:";
            // 
            // mensajeConexion
            // 
            this.mensajeConexion.AutoSize = true;
            this.mensajeConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mensajeConexion.ForeColor = System.Drawing.Color.Brown;
            this.mensajeConexion.Location = new System.Drawing.Point(214, 116);
            this.mensajeConexion.Name = "mensajeConexion";
            this.mensajeConexion.Size = new System.Drawing.Size(91, 24);
            this.mensajeConexion.TabIndex = 5;
            this.mensajeConexion.Text = "Sin Iniciar";
            // 
            // botonConexion
            // 
            this.botonConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonConexion.ForeColor = System.Drawing.Color.ForestGreen;
            this.botonConexion.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.botonConexion.IconColor = System.Drawing.Color.ForestGreen;
            this.botonConexion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.botonConexion.IconSize = 32;
            this.botonConexion.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.botonConexion.Location = new System.Drawing.Point(931, 92);
            this.botonConexion.Name = "botonConexion";
            this.botonConexion.Size = new System.Drawing.Size(110, 51);
            this.botonConexion.TabIndex = 2;
            this.botonConexion.Text = "Encender";
            this.botonConexion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.botonConexion.UseVisualStyleBackColor = true;
            this.botonConexion.Click += new System.EventHandler(this.botonConexion_Click);
            // 
            // AdministradorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1053, 658);
            this.Controls.Add(this.mensajeConexion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botonConexion);
            this.Controls.Add(this.ubicacionOpciones);
            this.Controls.Add(this.pMenu);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdministradorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.pMenu.ResumeLayout(false);
            this.pMenu.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pMenu;
        private System.Windows.Forms.Button cerrar;
        private System.Windows.Forms.Panel ubicacionOpciones;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem registrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarTiposDeConsultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarCitasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administracionDeDoctoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteCitasPorFechaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteCitasPorDoctorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteCitasPorClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label mensajeConexion;
        private FontAwesome.Sharp.IconButton botonConexion;
    }
}

