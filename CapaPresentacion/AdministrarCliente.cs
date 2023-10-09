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
 * fecha: 6/10/2023
 */

namespace CapaPresentacion
{
    public partial class AdministrarCliente : Form
    {
        private int id;
        private int idBuscar;
        private string nombre;
        private string apellido1;
        private string apellido2;
        private DateTime fecha;
        private char genero;
        private int cTipoConsultasIngresadas = 0;
        private CN_AdministrarClientes clientes = new CN_AdministrarClientes();
        private Cliente[] arrayClientes = new Cliente[20];
        public AdministrarCliente()
        {
            InitializeComponent();
            generoComboBox.Items.Add("Seleccione El genero");
            generoComboBox.SelectedItem = "Seleccione El genero";
            generoComboBox.Items.Add("Femenino");
            generoComboBox.Items.Add("Masculino");
            generoComboBox.Items.Add("No especificado");
            ComboBoxIdEncontrado.Items.Add("Femenino");
            ComboBoxIdEncontrado.Items.Add("Masculino");
            ComboBoxIdEncontrado.Items.Add("No especificado");
            generoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            dataGridCliente.Columns["Column1"].ReadOnly = true;
            dataGridCliente.Columns["Column2"].ReadOnly = true;
            dataGridCliente.Columns["Column3"].ReadOnly = true;
            dataGridCliente.Columns["Column4"].ReadOnly = true;
            dataGridCliente.Columns["Column5"].ReadOnly = true;
        }
        //metodos 
        //metodo para vaciar el texto 
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




        // metodo para registrar los datos
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
                ||(apellido1Text.Text== "Ingrese el apellido del cliente a registrar" || apellido1Text.Text == "")|| (apellido2Text.Text == "Ingrese el apellido del cliente a registrar" || apellido2Text.Text == "")||
                (generoComboBox.SelectedItem.ToString() == "Seleccione El genero"))
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
                if (generoComboBox.SelectedItem.ToString() == "Seleccione El genero")
                {
                    mensaje += "El Genero no ha sido seleccionado";
                }
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

            else
            {
                id = int.Parse(idText.Text);
                nombre = nombreText.Text;
                apellido1= apellido1Text.Text;
                apellido2= apellido2Text.Text;
                fecha = fechaNacimiento.Value;
                if (generoComboBox.SelectedIndex == 1)
                {
                   
                    genero = 'F';
                }
                if (generoComboBox.SelectedIndex == 2)
                {
             
                    genero = 'M';
                }
                if (generoComboBox.SelectedIndex == 3)
                {
                 
                    genero = 'N';
                }
     

                clientes.Registrar(id, nombre, apellido1, apellido2, fecha, genero);
                cTipoConsultasIngresadas++;
                arrayClientes = clientes.GetArray();
                idText.Text = "Ingrese el Id de la consulta a registrar";
                nombreText.Text = "Ingrese el nombre del cliente a registrar";
                apellido1Text.Text = "Ingrese el apellido del cliente a registrar";
                apellido2Text.Text = "Ingrese el apellido del cliente a registrar";
                idText.ForeColor = Color.DimGray;
                nombreText.ForeColor = Color.DimGray;
                apellido1Text.ForeColor = Color.DimGray;
                apellido2Text.ForeColor = Color.DimGray;
                generoComboBox.SelectedItem = "Seleccione El genero";
                fechaNacimiento.Value = DateTime.Now;
                ActualizarDataGrid();




            }
        }

        private void ActualizarDataGrid()
        {
            dataGridCliente.Rows.Clear();
            foreach (Cliente cliente in arrayClientes.Where(c => c != null))
            {
                dataGridCliente.Rows.Add(cliente.Identificacion, cliente.Nombre, cliente.Apellido1, cliente.Apellido2, cliente.FechaNacimiento, cliente.Genero);

            }


        }



        // metodo para buscar el id y modificar
        private void buscar_Click(object sender, EventArgs e)
        {
            // detecta si el campo esta vacio
            if (idBuscarText.Text == "" || idBuscarText.Text == "Ingrese el Id que desea modificar su estado")
            {
                MessageBox.Show("El campo de id a Buscar esta vacio o no ha sido escrito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                idBuscar = int.Parse(idBuscarText.Text);

            
                char separador = ',';
                string[] partes = clientes.Encontrar(idBuscar).Split(separador);

                fechaModificacion.Value = DateTime.Parse(partes[1]);



                // if para que el comboBox se selecciones con el ultimo estado seleccionado
                if (partes[0] == "F")
                {
                    desactivar();
                    ComboBoxIdEncontrado.SelectedItem = "Femenino";


                }
                // de la misma menera que el if de arriba pero para inactivo
                else if (partes[0] == "M")
                {
                    desactivar();
                    ComboBoxIdEncontrado.SelectedItem = "Masculino";

                }
                else
                {
                    desactivar();
                    ComboBoxIdEncontrado.SelectedItem = "No especificado";
                }
            }
        }
        // evento del boton cancelar para cancerla la modificacion del dato
        private void cancelar_Click(object sender, EventArgs e)
        {
            activar();
        }

        private void modificar_Click(object sender, EventArgs e)
        {

            if (ComboBoxIdEncontrado.SelectedIndex == 0)
            {
                genero = 'F';
            }
            if (ComboBoxIdEncontrado.SelectedIndex == 1)
            {
                genero = 'M';
            }
            if (ComboBoxIdEncontrado.SelectedIndex == 2)
            {
                genero = 'N';
            }
            fecha = fechaModificacion.Value;


            clientes.Modificar(idBuscar,genero,fecha);
            ActualizarDataGrid();
            activar();
        }
        private void desactivar()
        {
            idBuscarText.Enabled = false;
            buscar.Enabled = false;
            modificar.Enabled = true;
            cancelar.Enabled = true;
            ComboBoxIdEncontrado.Enabled = true;
            idText.Enabled = false;
            nombreText.Enabled = false;
            apellido1Text.Enabled = false;
            apellido2Text.Enabled = false;
            fechaNacimiento.Enabled = false;
            generoComboBox.Enabled = false;
            registrar.Enabled = false;
            fechaModificacion.Enabled=true;

        }
        public void activar()
        {
            idBuscarText.Enabled = true;
            buscar.Enabled = true;
            modificar.Enabled = false;
            cancelar.Enabled = false;
            ComboBoxIdEncontrado.Enabled = false;
            ComboBoxIdEncontrado.SelectedIndex = -1;
            idText.Enabled = true;
            nombreText.Enabled = false;
            apellido1Text.Enabled = false;
            apellido2Text.Enabled = false;
            fechaNacimiento.Enabled = false;
            generoComboBox.Enabled = false;
            registrar.Enabled = false;
            idBuscarText.Text = "Ingrese el Id que desea modificar su estado";
            idBuscarText.ForeColor = Color.DimGray;

        }




    }
}
