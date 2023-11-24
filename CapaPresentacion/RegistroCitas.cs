using CapaDatos;
using CapaEntidades;
using CapaLogicaNegocio;
using CapaPresentacion.clasesAuxiliaries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using System.Windows.Forms;




/* Uned III Cuatrimestre 
 * Eduardo Cespedes miranda 
 * Descripcion: funcion del menu para registrar cita 
 * fecha: 8/10/2023
 */

namespace CapaPresentacion
{
    public partial class RegistroCitas : Form
    {
        private CN_RegistrarFecha registrarFechas= new CN_RegistrarFecha();
        private List<Cliente> clienteLista = new List<Cliente>();
        private List<Doctor> listaDoctores = new List<Doctor>();
        private List<long> idDoctoresActivos = new List<long>();
        private List<Tipo_Consulta> listaconsultas = new List<Tipo_Consulta>();
        private CD_Doctores d_Doctores = new CD_Doctores();
        private CD_Clientes d_Clientes = new CD_Clientes();
        private CD_TiposConsultas d_Consultas= new CD_TiposConsultas();

        private short numero;
        private DateTime fechaHoraCita;
        public RegistroCitas()
        {
            InitializeComponent();
            fechaCitaDatePicker.Format = DateTimePickerFormat.Short;
            pacienteComboB.DropDownStyle = ComboBoxStyle.DropDownList;
            doctorComboB.DropDownStyle = ComboBoxStyle.DropDownList;
            horaCitasComboB.DropDownStyle = ComboBoxStyle.DropDownList;
            tipoConsultaComboB.DropDownStyle = ComboBoxStyle.DropDownList;
            doctorComboB.Items.Add("Seleccione el/la Dentista");
            doctorComboB.SelectedItem = "Seleccione el/la Dentista";
            pacienteComboB.Items.Add("Seleccione la/el Paciente");
            pacienteComboB.SelectedItem = "Seleccione la/el Paciente";
            tipoConsultaComboB.Items.Add("Seleccione el tipo de consulta");
            tipoConsultaComboB.SelectedItem = "Seleccione el tipo de consulta";
            horaCitasComboB.Items.Add("Seleccione la hora para la cita del paciente");
            horaCitasComboB.SelectedItem = "Seleccione la hora para la cita del paciente";
            llenarComboHoras();
        }
        // metodos 

        // actualizar la dataGrid de doctores 
        public void ActualizarDataGrid()
        {
           
           
         
            dataGridDoctores.Rows.Clear();
            dataGridCliente.Rows.Clear();
            clienteLista = d_Clientes.GetClienteList();
            listaDoctores= d_Doctores.GetDoctorList();
            if (listaDoctores != null && listaDoctores.Count > 0)
            {
                foreach (Doctor doctor in listaDoctores)
                {
                    if (doctor.estado == 'A')
                    {
                        dataGridDoctores.Rows.Add(doctor.identificacion, doctor.nombre, doctor.apellido1, doctor.apellido2);
                    }

                }

            }
            if (clienteLista != null && clienteLista.Count > 0)
            {
                foreach (Cliente cliente in clienteLista)
                {
                    dataGridCliente.Rows.Add(cliente.identificacion, cliente.nombre, cliente.apellido1, cliente.apellido2);
                }

            }
          
        }
        // limpiar el texto
        private void clickText(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Text = "";
            textBox.ForeColor = Color.FromArgb(39, 76, 119);
        }

        // llenar el combo box
        public void LlenarComboBox()
        {

            idDoctoresActivos.Clear();
            clienteLista = d_Clientes.GetClienteList();
            listaDoctores = d_Doctores.GetDoctorList();
            listaconsultas = d_Consultas.GetTipoConsultaList();

            pacienteComboB.Items.Clear();
            doctorComboB.Items.Clear();
            tipoConsultaComboB.Items.Clear();
            doctorComboB.Items.Add("Seleccione el/la Dentista");
            doctorComboB.SelectedItem = "Seleccione el/la Dentista";
            pacienteComboB.Items.Add("Seleccione la/el Paciente");
            pacienteComboB.SelectedItem = "Seleccione la/el Paciente";
            tipoConsultaComboB.Items.Add("Seleccione el tipo de consulta");
            tipoConsultaComboB.SelectedItem = "Seleccione el tipo de consulta";
   

            if ((listaDoctores != null && listaDoctores.Count > 0) && (clienteLista != null && clienteLista.Count > 0))
            {
                foreach (Cliente cliente in clienteLista)
                {
                    pacienteComboB.Items.Add(cliente.identificacion + "." + ' ' + cliente.nombre + " " + cliente.apellido1);
         
                }
  
                foreach (Doctor doctor in listaDoctores)
                {
                    if (doctor.estado == 'A')
                    {
                     
                        doctorComboB.Items.Add(doctor.identificacion + "." + ' ' + doctor.nombre + "." + " " + doctor.apellido1);
              
                    }
                  
                }
      



                foreach (Tipo_Consulta tipoConsulta in listaconsultas)
                {
                    if (tipoConsulta.estado == 'A')
                    {
                        tipoConsultaComboB.Items.Add(tipoConsulta.numero + "." + ' ' + tipoConsulta.descripcion);
            
                    }
                        
                }
            }
            else
            {
                MessageBox.Show("Algunos de los datos clientes, doctores o consulta no han sido llenados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

        }
        // asigna las horas disponbles al comboBox
        private void llenarComboHoras()
        {
            for (int i = 6; i < 21; i++)
            {
                horaCitasComboB.Items.Add(i.ToString("0") + ":00");
            }
        }

         // determina si se inserta un entero o no 

        private void idTextKeyPress(object sender, KeyPressEventArgs e)
        {
          CN_VerificacionId verificacion =new CN_VerificacionId();
            verificacion.idTextKeyPress(sender, e, errorProvider1);

        }


        private void Registrar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
      
            // verificacion para determinar si los campos estan vacios o escritos o si el combo box ha sido seleccionado
            if ((idText.Text == "" || idText.Text == "Ingrese el numero de la cita") ||  pacienteComboB.SelectedItem.ToString() == "Seleccione la/el Paciente" || doctorComboB.SelectedItem.ToString() == "Seleccione el/la Dentista" || horaCitasComboB.SelectedItem.ToString() == "Seleccione la hora para la cita del paciente"||tipoConsultaComboB.SelectedItem.ToString()== "Seleccione el tipo de consulta")
            {
                /*la funcion de estos if es solo para brindarle al usuario un mensaje que lo oriente a saber que campo 
                exacto es el que no ha sido escrito bien */

                if (idText.Text == "" || idText.Text == "Ingrese el numero de la cita")
                {
                    mensaje += "El campo id esta vacio o no ha sido añadido. \n";
                }
                if (tipoConsultaComboB.SelectedItem.ToString() == "Seleccione el tipo de consulta")
                {
                    mensaje += "No ha sido seleccionado el tipo de consulta. \n ";
                }
                if (pacienteComboB.SelectedItem.ToString() == "Seleccione la/el Paciente")
                {
                    mensaje += "No ha sido seleccionado Paciente. \n ";
                }
                if (doctorComboB.SelectedItem.ToString() == "Seleccione el/la Dentista")
                {
                    mensaje += "No ha sido seleccionado Dentista. \n ";
                }
                if (horaCitasComboB.SelectedItem.ToString() == "Seleccione la hora para la cita del paciente")
                {
                    mensaje += "No ha sido seleccionado la hora de la cita. \n ";
                }
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // llena los valores para realizar los registros
            else
            {
                
                this.numero = short.Parse(idText.Text);
                fechaHoraCita = DateTime.ParseExact(horaCitasComboB.SelectedItem.ToString(), "H:mm", CultureInfo.InvariantCulture);
                fechaHoraCita= fechaCitaDatePicker.Value.Date.AddHours(fechaHoraCita.Hour).AddMinutes(fechaHoraCita.Minute);
                // el valor del indice seleccionado del comboBox se le resta para obtener el mismo indice del elemento en el array con los mismo valores del combo
                string[] infoSeparado = tipoConsultaComboB.Text.Split('.');
                short numeroConsulta = short.Parse(infoSeparado[0]);
                infoSeparado = pacienteComboB.Text.Split('.');
                long numeroCliente = long.Parse(infoSeparado[0]);
                infoSeparado = doctorComboB.Text.Split('.');
                long numeroDoctor = long.Parse(infoSeparado[0]);

                registrarFechas.Registrar(numero, fechaHoraCita, numeroConsulta, numeroCliente, numeroDoctor);


            }
        }
    }
}
