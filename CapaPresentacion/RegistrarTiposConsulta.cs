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
        private int id;
        private int idBuscar;
        private string descripcion;
        private char estado;
        private int cTipoConsultasIngresadas = 0;
        private CN_TipoConsulta tipoConsulta = new CN_TipoConsulta();
        private TipoConsulta[] arrayTipConsultas= new TipoConsulta[10];
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
            VerificacionId verificacion = new VerificacionId();
            verificacion.idTextKeyPress(sender, e, errorProvider1);

        }
        // metodo para registrar los datos
        private void Registrar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            if (cTipoConsultasIngresadas >9)
            {
                MessageBox.Show("Ya se ha insertado 10 tipos de consultas el sistema no permite añdir mas de 10 tipos de consultas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
         
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
                id = int.Parse(idText.Text);
                descripcion = descripcionText.Text;
                if(estadoComboBox.SelectedIndex==1)
                {
                    estado ='A';
                }
                if (estadoComboBox.SelectedIndex == 2)
                {
                    estado = 'I';
                }

                tipoConsulta.Registrar(id, descripcion, estado, cTipoConsultasIngresadas);
                cTipoConsultasIngresadas++;
                arrayTipConsultas = tipoConsulta.GetArray();
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
            foreach (TipoConsulta consulta in arrayTipConsultas.Where(c => c != null)) {
                dataGridTiposCitas.Rows.Add(consulta.Numero, consulta.Descripcion, consulta.Estado);

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
                idBuscar=int.Parse(idBuscarText.Text);
               
                char estado=tipoConsulta.Encontrar(idBuscar);
            
   
         
                // if para que el comboBox se selecciones con el ultimo estado seleccionado
                if (estado == 'A')
                {
                    desactivar();
                    ComboBoxIdEncontrado.SelectedItem = "Activo";
                

                }
                // de la misma menera que el if de arriba pero para inactivo
                else if(estado == 'I')
                {
                    desactivar();
                    ComboBoxIdEncontrado.SelectedItem = "Inactivo";
              
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
                estado = 'A';
            }
            if (ComboBoxIdEncontrado.SelectedIndex == 1)
            {
                estado = 'I';
            }
            tipoConsulta.Modificar(idBuscar, estado);
           
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
