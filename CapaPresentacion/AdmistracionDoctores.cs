using CapaDatos;
using CapaEntidades;
using CapaLogicaNegocio;
using CapaPresentacion.clasesAuxiliaries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Uned III Cuatrimestre 
 * Eduardo Cespedes miranda 
 * Descripcion: funcion de administrar doctor
 * fecha: 7/10/2023
 */

namespace CapaPresentacion
{
    public partial class AdmistracionDoctores : Form
    {
        private int id;
        private string nombre;
        private string apellido1;
        private string apellido2;
        private char estado;
        private int cTipoConsultasIngresadas = 0;
        private CN_AdministrarDoctores doctores = new CN_AdministrarDoctores();
        private Doctor[] arrayDoctores = new Doctor[20];
        private List<Doctor> listaDoctor = new List<Doctor>();
        private CD_Doctores d_Doctores = new CD_Doctores();
        public AdmistracionDoctores()
        {
            InitializeComponent();
            dataGridDoctores.Columns["Column1"].ReadOnly = true;
            dataGridDoctores.Columns["Column2"].ReadOnly = true;
            dataGridDoctores.Columns["Column3"].ReadOnly = true;
            dataGridDoctores.Columns["Column4"].ReadOnly = true;
            dataGridDoctores.Columns["Column5"].ReadOnly = true;
            estadoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            estadoComboBox.Items.Add("Seleccione un estado");
            estadoComboBox.SelectedItem = "Seleccione un estado";
            estadoComboBox.Items.Add("Activo");
            estadoComboBox.Items.Add("Inactivo");
            ActualizarDataGrid();
        }
        //metodos

        // estes metodo  para vaciar las cajas de textos
        private void clickText(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Text = "";
            textBox.ForeColor = Color.FromArgb(39, 76, 119);
        }
        // metodo para verificar si se escribe entero 

        private void idTextKeyPress(object sender, KeyPressEventArgs e)
        {
            CN_VerificacionId verificacion = new CN_VerificacionId();
            verificacion.idTextKeyPress(sender, e, errorProvider1);
        }

        // metodo registrar
        private void Registrar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
        
            // verificacion para determinar si los campos estan vacios o escritos o si el combo box ha sido seleccionado
            if ((idText.Text == "" || idText.Text == "Ingrese el Id de la consulta a registrar") || nombreText.Text == "" || (nombreText.Text == "Ingrese el nombre del cliente a registrar")
                || (apellido1Text.Text == "Ingrese el apellido del cliente a registrar" || apellido1Text.Text == "") || (apellido2Text.Text == "Ingrese el apellido del cliente a registrar" || apellido2Text.Text == "") ||
                (estadoComboBox.SelectedItem.ToString() == "Seleccione un estado"))
            {
                /*la funcion de estos if es solo para brindarle al usuario un mensaje que lo oriente a saber que campo 
                exacto es el que no ha sido escrito bien */
                if (idText.Text == "" || idText.Text == "Ingrese el Id de la consulta a registrar")
                {
                    mensaje += "El campo id esta vacio o no ha sido añadido. \n";
                }
                if (nombreText.Text == "" || nombreText.Text == "Ingrese la descripcion de la consulta a registrar")
                {
                    mensaje += "El campo Nombre esta vacio o no ha sido añadido. \n";
                }
                if (apellido1Text.Text == "" || apellido1Text.Text == "Ingrese la descripcion de la consulta a registrar")
                {
                    mensaje += "El campo Primer apellido esta vacio o no ha sido añadido. \n";
                }
                if (apellido2Text.Text == "" || apellido2Text.Text == "Ingrese el apellido del cliente a registrar")
                {
                    mensaje += "El campo Segundo apellido esta vacio o no ha sido añadido. \n";
                }
                if (estadoComboBox.SelectedItem.ToString() == "Seleccione un estado")
                {
                    mensaje += "El Estado no ha sido seleccionado";
                }
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // else para inicializar los valores y registrar
            else
            {
                id = int.Parse(idText.Text);
                nombre = nombreText.Text;
                apellido1 = apellido1Text.Text;
                apellido2 = apellido2Text.Text;
                if (estadoComboBox.SelectedIndex == 1)
                {
                    estado = 'A';
                }
                if (estadoComboBox.SelectedIndex == 2)
                {
                    estado = 'I';
                }
                doctores.Registrar(id, nombre, apellido1, apellido2, estado);
    

                idText.Text = "Ingrese el Id de la consulta a registrar";
                nombreText.Text = "Ingrese el nombre del cliente a registrar";
                apellido1Text.Text = "Ingrese el apellido del cliente a registrar";
                apellido2Text.Text = "Ingrese el apellido del cliente a registrar";
                idText.ForeColor = Color.DimGray;
                nombreText.ForeColor = Color.DimGray;
                apellido1Text.ForeColor = Color.DimGray;
                apellido2Text.ForeColor = Color.DimGray;
                estadoComboBox.SelectedItem = "Seleccione un estado";
                ActualizarDataGrid();
            }
        }
        //actualiza el grid
        private void ActualizarDataGrid()
        {
            listaDoctor= d_Doctores.GetDoctorList();
            dataGridDoctores.Rows.Clear();
            foreach (Doctor doctor in listaDoctor)
            {
                dataGridDoctores.Rows.Add(doctor.identificacion, doctor.nombre, doctor.apellido1, doctor.apellido2, doctor.estado);
            }
        }
    }
}
