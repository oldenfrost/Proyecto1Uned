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
 * Descripcion: funcion para administrar cliente
 * fecha: 6/10/2023
 */

namespace CapaPresentacion
{
    public partial class AdministrarCliente : Form
    {
        //atributos
        private long id;
        private long idBuscar;
        private string nombre;
        private string apellido1;
        private string apellido2;
        private DateTime fecha;
        private char genero;
        private CN_AdministrarClientes clientes = new CN_AdministrarClientes();
        private List<Cliente> listaCliente = new List<Cliente>();
        private CD_Clientes d_Cliente = new CD_Clientes();
        private CN_VerificacionId verificacion= new CN_VerificacionId();

        public AdministrarCliente()
        {
            InitializeComponent();
            generoComboBox.Items.Add("Seleccione El genero");
            generoComboBox.SelectedItem = "Seleccione El genero";
            generoComboBox.Items.Add("Femenino");
            generoComboBox.Items.Add("Masculino");
            generoComboBox.Items.Add("No Especificado");
            ComboBoxIdEncontrado.Items.Add("Femenino");
            ComboBoxIdEncontrado.Items.Add("Masculino");
            ComboBoxIdEncontrado.Items.Add("No Especificado");
            generoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            dataGridCliente.Columns["Column1"].ReadOnly = true;
            dataGridCliente.Columns["Column2"].ReadOnly = true;
            dataGridCliente.Columns["Column3"].ReadOnly = true;
            dataGridCliente.Columns["Column4"].ReadOnly = true;
            ActualizarDataGrid();

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
            CN_VerificacionId verificacion = new CN_VerificacionId();
            verificacion.idTextKeyPress(sender, e, errorProvider1);

        }
        // metodo para registrar los datos
        private void Registrar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
          

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

        // actualiza el grid
        private void ActualizarDataGrid()
        {

            dataGridCliente.Rows.Clear();
            listaCliente = d_Cliente.GetClienteList();
            foreach (Cliente cliente in listaCliente)
            {
                dataGridCliente.Rows.Add(cliente.identificacion, cliente.nombre, cliente.apellido1, cliente.apellido2, cliente.fec_nacimiento, cliente.genero);
            }



        }

        // metodo para buscar el id y modificar
        private void buscar_Click(object sender, EventArgs e)
        {

            if (idBuscarText.Text == "" || idBuscarText.Text == "Ingrese el Id que desea modificar su estado")
            {
                MessageBox.Show("El campo de id a Buscar esta vacio o no ha sido escrito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                idBuscar = verificacion.VerificarShort(idBuscarText.Text);// este metodo tiene un  Trycatch la correccion del proyecto pasado
             
                bool existe = clientes.existe(idBuscar);
                if (existe)
                {
                    MessageBox.Show("El cliente fue Encontrado correctamente", "Encontrado", MessageBoxButtons.OK);
                    desactivar();
                    string opcionAsignada = clientes.retornarGenero(idBuscar);
                    fechaModificacion.Value = clientes.retornaFecha(idBuscar);
                    ComboBoxIdEncontrado.SelectedItem = opcionAsignada;

                }
                else
                {
                    MessageBox.Show("El Tipo de consulta No fue Encontrado correctamente", "Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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
            nombre = clientes.retornarNombre(idBuscar);
            apellido1 = clientes.retornarApellido1(idBuscar);
            apellido2 = clientes.retornarApellido2(idBuscar);
            fecha = fechaModificacion.Value;
            clientes.Modificar(idBuscar, nombre, apellido1, apellido2, fecha, genero);

            ActualizarDataGrid();
            activar();
        }
        //metodo desactiva algunas opcion
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
        //metodo activa algunas opciones
        public void activar()
        {
            idBuscarText.Enabled = true;
            buscar.Enabled = true;
            modificar.Enabled = false;
            cancelar.Enabled = false;
            ComboBoxIdEncontrado.Enabled = false;
            ComboBoxIdEncontrado.SelectedIndex = -1;
            idText.Enabled = true;
            nombreText.Enabled = true;
            apellido1Text.Enabled = true;
            apellido2Text.Enabled = true;
            fechaNacimiento.Enabled = true;
            generoComboBox.Enabled = true;
            registrar.Enabled = true;
            idBuscarText.Text = "Ingrese el Id que desea modificar su estado";
            idBuscarText.ForeColor = Color.DimGray;

        }
    }
}
