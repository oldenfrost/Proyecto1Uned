namespace CapaPresentacionCliente
{
    partial class RealizarCitaForm
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
            this.tipoConsultaComboB = new System.Windows.Forms.ComboBox();
            this.registrar = new System.Windows.Forms.Button();
            this.horaCitasComboB = new System.Windows.Forms.ComboBox();
            this.fechaCitaDatePicker = new System.Windows.Forms.DateTimePicker();
            this.doctorComboB = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tipoConsultaComboB
            // 
            this.tipoConsultaComboB.FormattingEnabled = true;
            this.tipoConsultaComboB.Location = new System.Drawing.Point(416, 76);
            this.tipoConsultaComboB.Name = "tipoConsultaComboB";
            this.tipoConsultaComboB.Size = new System.Drawing.Size(262, 21);
            this.tipoConsultaComboB.TabIndex = 47;
            // 
            // registrar
            // 
            this.registrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(206)))), ((int)(((byte)(241)))));
            this.registrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.registrar.Location = new System.Drawing.Point(416, 314);
            this.registrar.Name = "registrar";
            this.registrar.Size = new System.Drawing.Size(266, 28);
            this.registrar.TabIndex = 46;
            this.registrar.Text = "Registrar";
            this.registrar.UseVisualStyleBackColor = false;
            this.registrar.Click += new System.EventHandler(this.registrar_Click);
            // 
            // horaCitasComboB
            // 
            this.horaCitasComboB.FormattingEnabled = true;
            this.horaCitasComboB.Location = new System.Drawing.Point(416, 266);
            this.horaCitasComboB.Name = "horaCitasComboB";
            this.horaCitasComboB.Size = new System.Drawing.Size(262, 21);
            this.horaCitasComboB.TabIndex = 45;
            // 
            // fechaCitaDatePicker
            // 
            this.fechaCitaDatePicker.Location = new System.Drawing.Point(416, 199);
            this.fechaCitaDatePicker.Name = "fechaCitaDatePicker";
            this.fechaCitaDatePicker.Size = new System.Drawing.Size(262, 20);
            this.fechaCitaDatePicker.TabIndex = 44;
            // 
            // doctorComboB
            // 
            this.doctorComboB.FormattingEnabled = true;
            this.doctorComboB.Location = new System.Drawing.Point(416, 137);
            this.doctorComboB.Name = "doctorComboB";
            this.doctorComboB.Size = new System.Drawing.Size(262, 21);
            this.doctorComboB.TabIndex = 43;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(412, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 20);
            this.label10.TabIndex = 51;
            this.label10.Text = "Tipo de Consulta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(415, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 20);
            this.label5.TabIndex = 50;
            this.label5.Text = "Hora para la cita:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(412, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 20);
            this.label4.TabIndex = 49;
            this.label4.Text = "Fecha para la cita:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(412, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 48;
            this.label3.Text = "Doctor:";
            // 
            // RealizarCitaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 446);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tipoConsultaComboB);
            this.Controls.Add(this.registrar);
            this.Controls.Add(this.horaCitasComboB);
            this.Controls.Add(this.fechaCitaDatePicker);
            this.Controls.Add(this.doctorComboB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RealizarCitaForm";
            this.Text = "RealizarCitaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox tipoConsultaComboB;
        private System.Windows.Forms.Button registrar;
        private System.Windows.Forms.ComboBox horaCitasComboB;
        private System.Windows.Forms.DateTimePicker fechaCitaDatePicker;
        private System.Windows.Forms.ComboBox doctorComboB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}