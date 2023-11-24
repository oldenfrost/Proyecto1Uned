using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CapaLogicaNegocio;
using CapaEntidades;
using CapaPresentacion.clasesAuxiliaries;
using CapaDatos;




/* Uned III Cuatrimestre 
 * Eduardo Cespedes miranda 
 * Descripcion: funcion del menu Registrar consulta
 * fecha: 6/10/2023
 */
namespace CapaPresentacion
{
    public partial class RegistrarTiposConsulta : Form
    {
        // atributos de la clase
        private short id;
        private short idBuscar;
        private string descripcion;
        private char estado;

        private CN_TipoConsulta tipoConsulta = new CN_TipoConsulta();
        private List<Tipo_Consulta>  tipConsultasLista= new List<Tipo_Consulta>();
        private CN_VerificacionId verificacion;
        private CD_TiposConsultas d_TiposConsultas = new CD_TiposConsultas();
        public RegistrarTiposConsulta()
        {
            InitializeComponent();
            estadoComboBox.Items.Add("Selecciones un estado");
            estadoComboBox.SelectedItem = "Selecciones un estado";
            estadoComboBox.Items.Add("Activo");
            estadoComboBox.Items.Add("Inactivo");
            ComboBoxIdEncontrado.Items.Add("Activo");
            ComboBoxIdEncontrado.Items.Add("Inactivo");
            estadoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxIdEncontrado.DropDownStyle = ComboBoxStyle.DropDownList;
            dataGridTiposCitas.Columns["Column1"].ReadOnly = true;
            dataGridTiposCitas.Columns["Column2"].ReadOnly = true;
            dataGridTiposCitas.Columns["Column3"].ReadOnly = true;
            verificacion = new CN_VerificacionId();
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
       

        /*un evento que llama a un metodo ce la clase VerificacionId para verificar si se presiona un entero
         con una expresion regular */
        private void idTextKeyPress(object sender, KeyPressEventArgs e)
        {
            verificacion.idTextKeyPress(sender, e, errorProvider1);
        }
        // metodo para registrar los datos
        private void Registrar_Click(object sender, EventArgs e)
        {
            string mensaje = "";

         
            // verificacion para determinar si los campos estan vacios o escritos o si el combo box ha sido seleccionado
            if((idText.Text=="" || idText.Text == "Ingrese el Id de la consulta a registrar")|| descripcionText.Text == "" || (descripcionText.Text == "Ingrese la descripcion de la consulta a registrar")|| estadoComboBox.SelectedItem.ToString() == "Selecciones un estado")
            {
                /*la funcion de estos if es solo para brindarle al usuario un mensaje que lo oriente a saber que campo 
                exacto es el que no ha sido escrito bien */
              
                if (idText.Text == "" || idText.Text == "Ingrese el Id de la consulta a registrar")
                {
                    mensaje += "El campo id esta vacio o no ha sido añadido. \n";
                }
                if (descripcionText.Text == "" || descripcionText.Text == "Ingrese la descripcion de la consulta a registrar")
                {
                    mensaje += "El campo Descripcion esta vacio o no ha sido añadido. \n";
                }
                if (estadoComboBox.SelectedItem.ToString() == "Selecciones un estado")
                {
                    mensaje += "El estado no ha sido seleccionado";
                }
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            else
            {
                id =verificacion.VerificarShort(idText.Text);// este metodo tiene un  Trycatch la correccion del proyecto pasado
                if (id <0 && id > 9999)
                    {
                    MessageBox.Show("Id Incorrecto por favor ingrese un id correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                descripcion = descripcionText.Text;
                estado = (estadoComboBox.Text == "Activo" ? 'A' : 'I');

                tipoConsulta.Registrar(id, descripcion, estado);
                idText.Text= "Ingrese el Id de la consulta a registrar";
                idText.ForeColor= Color.DimGray;
                descripcionText.Text= "Ingrese la descripcion de la consulta a registrar";
                descripcionText.ForeColor = Color.DimGray;
                estadoComboBox.SelectedItem = "Selecciones un estado";
                ActualizarDataGrid();
            }
        }


        // metodo que actualiza la dataGrid
        private void ActualizarDataGrid()

        {
            dataGridTiposCitas.Rows.Clear();
            tipConsultasLista = d_TiposConsultas.GetTipoConsultaList();
            foreach (Tipo_Consulta consulta in tipConsultasLista) {
                dataGridTiposCitas.Rows.Add(consulta.numero, consulta.descripcion, consulta.estado);
            }
        }

        // metodo para buscar el id y modificar
        private void buscar_Click(object sender, EventArgs e)
        {
            // detecta si el campo esta vacio
            if(idBuscarText.Text == "" || idBuscarText.Text == "Ingrese el Id que desea modificar su estado")
            {
                MessageBox.Show("El campo de id a Buscar esta vacio o no ha sido escrito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                idBuscar = verificacion.VerificarShort(idBuscarText.Text);// este metodo tiene un  Trycatch la correccion del proyecto pasado
                if (idBuscar < 0 && idBuscar > 9999)
                {
                    MessageBox.Show("Id Incorrecto por favor ingrese un id correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool existe=tipoConsulta.existe(idBuscar);
                if (existe)
                {
                    MessageBox.Show("El cliente fue Encontrado correctamente", "Encontrado", MessageBoxButtons.OK);
                    desactivar();
                    string opcionAsignada= tipoConsulta.retornarEstado(idBuscar);
                    ComboBoxIdEncontrado.SelectedItem= opcionAsignada;

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
  
            estado = (ComboBoxIdEncontrado.Text=="Activo" ? 'A' : 'I');
            descripcion = tipoConsulta.retornarDescripcion(idBuscar);
            tipoConsulta.Modificar(idBuscar, descripcion, estado);
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
            descripcionText.Enabled = false;
            estadoComboBox.Enabled = false;
            registrar.Enabled = false;

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
            descripcionText.Enabled = true;
            estadoComboBox.Enabled = true;
            registrar.Enabled = true;
            idBuscarText.Text = "Ingrese el Id que desea modificar su estado";
            idBuscarText.ForeColor = Color.DimGray;

        }
    }
}
