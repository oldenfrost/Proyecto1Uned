namespace CapaPresentacionCliente
{
    partial class formCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCliente));
            this.botonConexion = new FontAwesome.Sharp.IconButton();
            this.pMenu = new System.Windows.Forms.Panel();
            this.cerrar = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.RealizarCitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConsultarCitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ubicacionOpciones = new System.Windows.Forms.Panel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.usuario = new System.Windows.Forms.Label();
            this.pMenu.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // botonConexion
            // 
            this.botonConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonConexion.ForeColor = System.Drawing.Color.ForestGreen;
            this.botonConexion.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
            this.botonConexion.IconColor = System.Drawing.Color.ForestGreen;
            this.botonConexion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.botonConexion.IconSize = 32;
            this.botonConexion.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.botonConexion.Location = new System.Drawing.Point(902, 103);
            this.botonConexion.Name = "botonConexion";
            this.botonConexion.Size = new System.Drawing.Size(139, 51);
            this.botonConexion.TabIndex = 3;
            this.botonConexion.Text = "Iniciar Sesion";
            this.botonConexion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.botonConexion.UseVisualStyleBackColor = true;
            this.botonConexion.Click += new System.EventHandler(this.botonConexion_Click);
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
            this.pMenu.Location = new System.Drawing.Point(0, 0);
            this.pMenu.Name = "pMenu";
            this.pMenu.Size = new System.Drawing.Size(1054, 86);
            this.pMenu.TabIndex = 4;
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
            this.cerrar.Click += new System.EventHandler(this.cerrar_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(206)))), ((int)(((byte)(241)))));
            this.menu.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RealizarCitaToolStripMenuItem,
            this.ConsultarCitaToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menu.Size = new System.Drawing.Size(1054, 38);
            this.menu.TabIndex = 2;
            this.menu.Text = "menu";
            // 
            // RealizarCitaToolStripMenuItem
            // 
            this.RealizarCitaToolStripMenuItem.Enabled = false;
            this.RealizarCitaToolStripMenuItem.Name = "RealizarCitaToolStripMenuItem";
            this.RealizarCitaToolStripMenuItem.Size = new System.Drawing.Size(141, 34);
            this.RealizarCitaToolStripMenuItem.Text = "Realizar Cita";
            this.RealizarCitaToolStripMenuItem.Click += new System.EventHandler(this.RealizarCitaToolStripMenuItem_Click);
            // 
            // ConsultarCitaToolStripMenuItem
            // 
            this.ConsultarCitaToolStripMenuItem.Enabled = false;
            this.ConsultarCitaToolStripMenuItem.Name = "ConsultarCitaToolStripMenuItem";
            this.ConsultarCitaToolStripMenuItem.Size = new System.Drawing.Size(159, 34);
            this.ConsultarCitaToolStripMenuItem.Text = "Consultar Cita";
            this.ConsultarCitaToolStripMenuItem.Click += new System.EventHandler(this.ConsultarCitaToolStripMenuItem_Click);
            // 
            // ubicacionOpciones
            // 
            this.ubicacionOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ubicacionOpciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.ubicacionOpciones.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ubicacionOpciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.ubicacionOpciones.Location = new System.Drawing.Point(0, 171);
            this.ubicacionOpciones.Name = "ubicacionOpciones";
            this.ubicacionOpciones.Size = new System.Drawing.Size(1054, 492);
            this.ubicacionOpciones.TabIndex = 5;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.iconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.iconPictureBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 54;
            this.iconPictureBox1.Location = new System.Drawing.Point(12, 100);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(64, 54);
            this.iconPictureBox1.TabIndex = 2;
            this.iconPictureBox1.TabStop = false;
            // 
            // usuario
            // 
            this.usuario.AutoSize = true;
            this.usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.usuario.Location = new System.Drawing.Point(82, 114);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(0, 29);
            this.usuario.TabIndex = 6;
            // 
            // formCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 658);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.ubicacionOpciones);
            this.Controls.Add(this.pMenu);
            this.Controls.Add(this.botonConexion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formCliente_FormClosed);
            this.pMenu.ResumeLayout(false);
            this.pMenu.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton botonConexion;
        private System.Windows.Forms.Panel pMenu;
        private System.Windows.Forms.Button cerrar;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem RealizarCitaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConsultarCitaToolStripMenuItem;
        private System.Windows.Forms.Panel ubicacionOpciones;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label usuario;
    }
}