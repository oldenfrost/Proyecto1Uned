using CapaEntidades;
using CapaLogicaNegocio;
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
 * Descripcion: funcion del menu Registrar consulta
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
            // expresion regular
            Regex regex = new Regex("[^0-9]+");
            TextBox textBox = sender as TextBox;


            if (!char.IsControl(e.KeyChar) && regex.IsMatch(e.KeyChar.ToString()))
            {

                errorProvider1.SetError(textBox, "Por favor, ingrese solo números.");
                e.Handled = true;
            }
            else
            {
                errorProvider1.SetError(textBox, "");

            }

        }

        // metodo registrar
        private void Registrar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            if (cTipoConsultasIngresadas > 19)
            {
                MessageBox.Show("Ya se ha insertado 10 tipos de consultas el sistema no permite añdir mas de 10 tipos de consultas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                cTipoConsultasIngresadas++;
                arrayDoctores = doctores.GetArray();
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

        private void ActualizarDataGrid()
        {
            dataGridDoctores.Rows.Clear();
            foreach (Doctor doctor in arrayDoctores.Where(c => c != null))
            {
                dataGridDoctores.Rows.Add(doctor.Identificacion, doctor.Nombre, doctor.Apellido1, doctor.Apellido2, doctor.Estado);

            }


        }



    }
}
