namespace CapaPresentacion
{
    partial class AdministrarCliente
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
            this.components = new System.ComponentModel.Container();
            this.registrar = new System.Windows.Forms.Button();
            this.generoComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nombreText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.apellido1Text = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.apellido2Text = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridCliente = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.idBuscarText = new System.Windows.Forms.TextBox();
            this.cancelar = new System.Windows.Forms.Button();
            this.modificar = new System.Windows.Forms.Button();
            this.ComboBoxIdEncontrado = new System.Windows.Forms.ComboBox();
            this.buscar = new System.Windows.Forms.Button();
            this.fechaModificacion = new System.Windows.Forms.DateTimePicker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.fechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // registrar
            // 
            this.registrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(206)))), ((int)(((byte)(241)))));
            this.registrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.registrar.Location = new System.Drawing.Point(13, 335);
            this.registrar.Name = "registrar";
            this.registrar.Size = new System.Drawing.Size(262, 28);
            this.registrar.TabIndex = 14;
            this.registrar.Text = "Registrar";
            this.registrar.UseVisualStyleBackColor = false;
            this.registrar.Click += new System.EventHandler(this.Registrar_Click);
            this.registrar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.idTextKeyPress);
            // 
            // generoComboBox
            // 
            this.generoComboBox.FormattingEnabled = true;
            this.generoComboBox.Location = new System.Drawing.Point(12, 308);
            this.generoComboBox.Name = "generoComboBox";
            this.generoComboBox.Size = new System.Drawing.Size(262, 21);
            this.generoComboBox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Género:";
            // 
            // nombreText
            // 
            this.nombreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreText.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.nombreText.Location = new System.Drawing.Point(12, 111);
            this.nombreText.Name = "nombreText";
            this.nombreText.Size = new System.Drawing.Size(262, 22);
            this.nombreText.TabIndex = 11;
            this.nombreText.Text = "Ingrese el nombre del cliente a registrar\r\n";
            this.nombreText.Click += new System.EventHandler(this.clickText);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombre:";
            // 
            // idText
            // 
            this.idText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idText.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.idText.Location = new System.Drawing.Point(12, 63);
            this.idText.Name = "idText";
            this.idText.Size = new System.Drawing.Size(262, 22);
            this.idText.TabIndex = 9;
            this.idText.Text = "Ingrese el Id del cliente a registrar";
            this.idText.Click += new System.EventHandler(this.clickText);
            this.idText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.idTextKeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Id:";
            // 
            // apellido1Text
            // 
            this.apellido1Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apellido1Text.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.apellido1Text.Location = new System.Drawing.Point(12, 159);
            this.apellido1Text.Name = "apellido1Text";
            this.apellido1Text.Size = new System.Drawing.Size(262, 22);
            this.apellido1Text.TabIndex = 16;
            this.apellido1Text.Text = "Ingrese el apellido del cliente a registrar\r\n";
            this.apellido1Text.Click += new System.EventHandler(this.clickText);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Primer Apellido:";
            // 
            // apellido2Text
            // 
            this.apellido2Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apellido2Text.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.apellido2Text.Location = new System.Drawing.Point(12, 207);
            this.apellido2Text.Name = "apellido2Text";
            this.apellido2Text.Size = new System.Drawing.Size(262, 22);
            this.apellido2Text.TabIndex = 18;
            this.apellido2Text.Text = "Ingrese el apellido del cliente a registrar\r\n";
            this.apellido2Text.Click += new System.EventHandler(this.clickText);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Segundo Apellido:";
            // 
            // dataGridCliente
            // 
            this.dataGridCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column5});
            this.dataGridCliente.Location = new System.Drawing.Point(306, 63);
            this.dataGridCliente.Name = "dataGridCliente";
            this.dataGridCliente.Size = new System.Drawing.Size(736, 257);
            this.dataGridCliente.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.panel1.Location = new System.Drawing.Point(45, 369);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(997, 10);
            this.panel1.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Registrar Datos:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(521, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(213, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Lista de registros de Clientes\r\n";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 389);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "Modificar Datos:";
            // 
            // idBuscarText
            // 
            this.idBuscarText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idBuscarText.ForeColor = System.Drawing.Color.DimGray;
            this.idBuscarText.Location = new System.Drawing.Point(12, 412);
            this.idBuscarText.Name = "idBuscarText";
            this.idBuscarText.Size = new System.Drawing.Size(276, 22);
            this.idBuscarText.TabIndex = 25;
            this.idBuscarText.Text = "Ingrese el Id que desea modificar su estado";
            this.idBuscarText.Click += new System.EventHandler(this.clickText);
            this.idBuscarText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.idTextKeyPress);
            // 
            // cancelar
            // 
            this.cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(206)))), ((int)(((byte)(241)))));
            this.cancelar.Enabled = false;
            this.cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.cancelar.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.cancelar.Location = new System.Drawing.Point(854, 403);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(119, 31);
            this.cancelar.TabIndex = 29;
            this.cancelar.Text = "Cancelar";
            this.cancelar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cancelar.UseVisualStyleBackColor = false;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // modificar
            // 
            this.modificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(206)))), ((int)(((byte)(241)))));
            this.modificar.Enabled = false;
            this.modificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.modificar.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.modificar.Location = new System.Drawing.Point(729, 403);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(119, 31);
            this.modificar.TabIndex = 28;
            this.modificar.Text = "Modificar";
            this.modificar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.modificar.UseVisualStyleBackColor = false;
            this.modificar.Click += new System.EventHandler(this.modificar_Click);
            // 
            // ComboBoxIdEncontrado
            // 
            this.ComboBoxIdEncontrado.Enabled = false;
            this.ComboBoxIdEncontrado.FormattingEnabled = true;
            this.ComboBoxIdEncontrado.Location = new System.Drawing.Point(479, 385);
            this.ComboBoxIdEncontrado.Name = "ComboBoxIdEncontrado";
            this.ComboBoxIdEncontrado.Size = new System.Drawing.Size(244, 21);
            this.ComboBoxIdEncontrado.TabIndex = 27;
            // 
            // buscar
            // 
            this.buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(206)))), ((int)(((byte)(241)))));
            this.buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.buscar.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.buscar.Location = new System.Drawing.Point(306, 403);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(119, 31);
            this.buscar.TabIndex = 26;
            this.buscar.Text = "Buscar";
            this.buscar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buscar.UseVisualStyleBackColor = false;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // fechaModificacion
            // 
            this.fechaModificacion.Enabled = false;
            this.fechaModificacion.Location = new System.Drawing.Point(479, 412);
            this.fechaModificacion.Name = "fechaModificacion";
            this.fechaModificacion.Size = new System.Drawing.Size(244, 20);
            this.fechaModificacion.TabIndex = 30;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // fechaNacimiento
            // 
            this.fechaNacimiento.Location = new System.Drawing.Point(12, 262);
            this.fechaNacimiento.Name = "fechaNacimiento";
            this.fechaNacimiento.Size = new System.Drawing.Size(262, 20);
            this.fechaNacimiento.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 239);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 20);
            this.label9.TabIndex = 32;
            this.label9.Text = "Fecha Nacimiento:";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.Width = 122;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nombre";
            this.Column2.Name = "Column2";
            this.Column2.Width = 122;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Primer Apellido";
            this.Column3.Name = "Column3";
            this.Column3.Width = 122;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Segundo Apellido";
            this.Column4.Name = "Column4";
            this.Column4.Width = 122;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Fecha de nacimiento";
            this.Column6.Name = "Column6";
            this.Column6.Width = 122;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Genero";
            this.Column5.Name = "Column5";
            this.Column5.Width = 122;
            // 
            // AdministrarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 446);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.fechaNacimiento);
            this.Controls.Add(this.fechaModificacion);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.modificar);
            this.Controls.Add(this.ComboBoxIdEncontrado);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.idBuscarText);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridCliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.apellido2Text);
            this.Controls.Add(this.apellido1Text);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.registrar);
            this.Controls.Add(this.generoComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nombreText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idText);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdministrarCliente";
            this.Text = "AdministrarCliente";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registrar;
        private System.Windows.Forms.ComboBox generoComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nombreText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox idText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox apellido1Text;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox apellido2Text;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridCliente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox idBuscarText;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.ComboBox ComboBoxIdEncontrado;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.DateTimePicker fechaModificacion;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DateTimePicker fechaNacimiento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}