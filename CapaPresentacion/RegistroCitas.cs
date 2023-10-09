using CapaEntidades;
using CapaLogicaNegocio;
using System;
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
 * Descripcion: funcion del menu Registrar consulta
 * fecha: 8/10/2023
 */

namespace CapaPresentacion
{
    public partial class RegistroCitas : Form
    {

        private Cliente[] arrayCliente=new Cliente[20];
        private Doctor[] arrayDoctor;
        private TipoConsulta[] arrayConsulta;
        private Cita[] arrayCita;
        private CN_AdministrarClientes AdministrarClientes = new CN_AdministrarClientes();
        private CN_AdministrarDoctores AdministrarDoctores= new CN_AdministrarDoctores();
        private CN_TipoConsulta TipoConsulta = new CN_TipoConsulta();
        private CN_RegistrarFecha registrarFechas= new CN_RegistrarFecha();
        private int cTipoConsultasIngresadas = 0;
        private int numero;
        private DateTime fechaHoraCita;
        private TipoConsulta tipoConsulta= new TipoConsulta();
        private Cliente cliente = new Cliente();
        private Doctor doctor= new Doctor();

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
   


            arrayCliente = AdministrarClientes.GetArray();
            arrayDoctor=AdministrarDoctores.GetArray();
            arrayConsulta = TipoConsulta.GetArray();
            arrayCita = registrarFechas.GetArray();
            //VerificacionDeRegistros();
            ActualizarDataGrid();
            LlenarComboBox();
            llenarComboHoras();







        }

        // metodos 

        // verificacion de registros tanto de clientes como de doctores para activar el formulario
        private void VerificacionDeRegistros()
        {
            if (arrayCliente[0] == null || arrayDoctor[0] == null)
            {
                idText.Enabled= false;
                pacienteComboB.Enabled= false;
                doctorComboB.Enabled= false;
                horaCitasComboB.Enabled = false;
                fechaCitaDatePicker.Enabled= false;
                MessageBox.Show("no hay registros de clientes o de doctores por favor ingresar antes los registros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                idText.Enabled = true;
                pacienteComboB.Enabled = true;
                doctorComboB.Enabled = true;
                horaCitasComboB.Enabled = true;
                fechaCitaDatePicker.Enabled = true;

            }
        }

        // actualizar la dataGrid de doctores 
        private void ActualizarDataGrid()
        {
            dataGridDoctores.Rows.Clear();
            foreach (Doctor doctor in arrayDoctor.Where(c => c != null && c.Estado=='A'))
            {
                dataGridDoctores.Rows.Add(doctor.Identificacion, doctor.Nombre, doctor.Apellido1, doctor.Apellido2);

            }
            dataGridCliente.Rows.Clear();
            foreach (Cliente cliente in arrayCliente.Where(c => c != null))
            {
                dataGridCliente.Rows.Add(cliente.Identificacion, cliente.Nombre, cliente.Apellido1, cliente.Apellido2);

            }

            dataGridCita.Rows.Clear();
            foreach (Cita cita in arrayCita.Where(c => c != null))
            {
     
                dataGridCita.Rows.Add(cita.Numero, cita.FechaHoraCita, cita.TipoConsulta.Descripcion, cita.Cliente.Nombre+" "+cita.Cliente.Apellido1, cita.Doctor.Nombre+" "+cita.Doctor.Apellido1);

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
        private void LlenarComboBox()
        {

            foreach (Cliente cliente in arrayCliente.Where(c => c != null))
            {
                pacienteComboB.Items.Add(cliente.Identificacion+"."+' '+ cliente.Nombre + " " + cliente.Apellido1);

            }
            foreach (Doctor doctor in arrayDoctor.Where(c => c != null && c.Estado == 'A'))
            {
                doctorComboB.Items.Add(doctor.Identificacion + "." + ' ' + doctor.Nombre +"."+ " " + doctor.Apellido1);

            }
            foreach (TipoConsulta tipoConsulta in arrayConsulta.Where(c => c != null && c.Estado == 'A'))
            {
                tipoConsultaComboB.Items.Add(tipoConsulta.Numero + "." + ' ' + tipoConsulta.Descripcion);

            }

        }

        private void llenarComboHoras()
        {
            for (int i = 6; i < 21; i++)
            {
                horaCitasComboB.Items.Add(i.ToString("00") + ":00");
            }

        }

        private void idTextKeyPress(object sender, KeyPressEventArgs e)
        {
            // expresion regular
            Regex regex = new Regex("[^0-9]+");
            TextBox textBox = sender as TextBox;
            /* se declara una variable de tipoo textBox sender es el que desencadeno el evento 
             * con el as se realiza la conversion a TextBox para poder usarse en el provider para cualquier
             * textbox que desencadena la accion 
             */

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


        private void Registrar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            if (cTipoConsultasIngresadas > 19)
            {
                MessageBox.Show("Ya se ha insertado 20 tipos de consultas el sistema no permite añdir mas de 10 tipos de consultas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // verificacion para determinar si los campos estan vacios o escritos o si el combo box ha sido seleccionado
            if ((idText.Text == "" || idText.Text == "Ingrese el numero de la cita") ||  pacienteComboB.SelectedItem.ToString() == "Seleccione la/el Paciente" || doctorComboB.SelectedItem.ToString() == "Seleccione el/la Dentista" || horaCitasComboB.SelectedItem.ToString() == "Seleccione la hora para la cita del paciente"||tipoConsultaComboB.SelectedItem.ToString()== "Seleccione el tipo de consulta")
            {
                /*la funcion de estos if es solo para brindarle al usuario un mensaje que lo oriente a saber que campo 
                exacto es el que no ha sido escrito bien */

                if (idText.Text == "" || idText.Text == "Ingrese el numero de la cita")
                {
                    mensaje += "El campo id esta vacio o no ha sido añadido. \n";
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

            else
            {
                this.numero = int.Parse(idText.Text);
                string[] valorComboTipoC = tipoConsultaComboB.Text.Split('.');
                string[]valorComboPaciente  = pacienteComboB.Text.Split('.');
                string[] valorComboDoctor = doctorComboB.Text.Split('.');
                fechaHoraCita = DateTime.ParseExact(horaCitasComboB.SelectedItem.ToString(), "HH:mm", CultureInfo.InvariantCulture);
                fechaHoraCita= fechaCitaDatePicker.Value.Date.AddHours(fechaHoraCita.Hour).AddMinutes(fechaHoraCita.Minute);

                foreach (TipoConsulta tipoConsulta in arrayConsulta.Where(c => c.Numero == int.Parse(valorComboTipoC[0])))
                {

                    this.tipoConsulta.Numero = tipoConsulta.Numero;
                    this.tipoConsulta.Descripcion = tipoConsulta.Descripcion;
                    this.tipoConsulta.Estado = tipoConsulta.Estado;
                }

                foreach (Cliente cliente in arrayCliente.Where(c => c.Identificacion== int.Parse(valorComboPaciente[0])))
                {

                    this.cliente.Identificacion = cliente.Identificacion;
                    this.cliente.Nombre = cliente.Nombre;
                    this.cliente.Apellido1= cliente.Apellido1;
                    this.cliente.Apellido2= cliente.Apellido2;
                    this.cliente.FechaNacimiento=cliente.FechaNacimiento;
                    this.cliente.Genero= cliente.Genero;
                }
                foreach (Doctor doctor in arrayDoctor.Where(c => c.Identificacion == int.Parse(valorComboDoctor[0])))
                {

                    this.doctor.Identificacion = doctor.Identificacion;
                    this.doctor.Nombre = doctor.Nombre;
                    this.doctor.Apellido1 = doctor.Apellido1;
                    this.doctor.Apellido2 = doctor.Apellido2;
                    this.doctor.Estado = doctor.Estado;
                }

                registrarFechas.Registrar(numero, fechaHoraCita, this.tipoConsulta, this.cliente, this.doctor);




                arrayCita = registrarFechas.GetArray();

                ActualizarDataGrid();




            }
        }






    }
}
