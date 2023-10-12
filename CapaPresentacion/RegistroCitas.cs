using CapaEntidades;
using CapaLogicaNegocio;
using CapaPresentacion.clasesAuxiliaries;
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
 * Descripcion: funcion del menu para registrar cita 
 * fecha: 8/10/2023
 */

namespace CapaPresentacion
{
    public partial class RegistroCitas : Form
    {
        private Cliente[] arrayCliente=new Cliente[20];
        private Doctor[] arrayDoctor;
        private TipoConsulta[] arrayConsulta;
        private Cita[] arrayCita= new Cita[20];
        private CN_AdministrarClientes AdministrarClientes = new CN_AdministrarClientes();
        private CN_AdministrarDoctores AdministrarDoctores= new CN_AdministrarDoctores();
        private CN_TipoConsulta TipoConsulta = new CN_TipoConsulta();
        private CN_RegistrarFecha registrarFechas= new CN_RegistrarFecha();
        private int cTipoConsultasIngresadas = 0;
        private int numero;
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
            arrayCliente = AdministrarClientes.GetArray();
            arrayDoctor = AdministrarDoctores.GetArray();
            arrayConsulta = TipoConsulta.GetArray();
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
            arrayCliente = AdministrarClientes.GetArray();
            arrayDoctor = AdministrarDoctores.GetArray();
            arrayConsulta = TipoConsulta.GetArray();
            pacienteComboB.Items.Clear();
            doctorComboB.Items.Clear();
            tipoConsultaComboB.Items.Clear();
            doctorComboB.Items.Add("Seleccione el/la Dentista");
            doctorComboB.SelectedItem = "Seleccione el/la Dentista";
            pacienteComboB.Items.Add("Seleccione la/el Paciente");
            pacienteComboB.SelectedItem = "Seleccione la/el Paciente";
            tipoConsultaComboB.Items.Add("Seleccione el tipo de consulta");
            tipoConsultaComboB.SelectedItem = "Seleccione el tipo de consulta";
            int i=1;
            if (arrayCliente[0]!=null && arrayDoctor[0]!=null && arrayConsulta[0]!= null)
            {
                foreach (Cliente cliente in arrayCliente.Where(c => c != null))
                {
                    pacienteComboB.Items.Add(i + "." + ' ' + cliente.Nombre + " " + cliente.Apellido1);
                    i++;
                }
                i = 1;
                foreach (Doctor doctor in arrayDoctor.Where(c => c != null && c.Estado == 'A'))
                {
                    doctorComboB.Items.Add(i + "." + ' ' + doctor.Nombre + "." + " " + doctor.Apellido1);
                    i++;
                }
                i = 1;
                foreach (TipoConsulta tipoConsulta in arrayConsulta.Where(c => c != null && c.Estado == 'A'))
                {
                    tipoConsultaComboB.Items.Add(i + "." + ' ' + tipoConsulta.Descripcion);
                    i++;
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
          VerificacionId verificacion =new VerificacionId();
            verificacion.idTextKeyPress(sender, e, errorProvider1);

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
                this.numero = int.Parse(idText.Text);
                fechaHoraCita = DateTime.ParseExact(horaCitasComboB.SelectedItem.ToString(), "H:mm", CultureInfo.InvariantCulture);
                fechaHoraCita= fechaCitaDatePicker.Value.Date.AddHours(fechaHoraCita.Hour).AddMinutes(fechaHoraCita.Minute);
                // el valor del indice seleccionado del comboBox se le resta para obtener el mismo indice del elemento en el array con los mismo valores del combo
                int i;
                i = tipoConsultaComboB.SelectedIndex - 1;
                TipoConsulta consultaAsignar = new TipoConsulta
                {
                    Numero = arrayConsulta[i].Numero,
                    Descripcion = arrayConsulta[i].Descripcion,
                    Estado = arrayConsulta[i].Estado
                };
                i = pacienteComboB.SelectedIndex - 1;
                Cliente clienteAsignar = new Cliente
                {
                    Identificacion = arrayCliente[i].Identificacion,
                    Nombre = arrayCliente[i].Nombre,
                    Apellido1 = arrayCliente[i].Apellido1,
                    Apellido2 = arrayCliente[i].Apellido2,
                    FechaNacimiento = arrayCliente[i].FechaNacimiento,
                    Genero = arrayCliente[i].Genero
                };
                i = doctorComboB.SelectedIndex - 1;
                Doctor doctorAsignar = new Doctor
                {
                    Identificacion = arrayDoctor[i].Identificacion,
                    Nombre = arrayDoctor[i].Nombre,
                    Apellido1 = arrayDoctor[i].Apellido1,
                    Apellido2 = arrayDoctor[i].Apellido1,
                    Estado = arrayDoctor[i].Estado
                };
                    registrarFechas.Registrar(numero, fechaHoraCita, consultaAsignar, clienteAsignar, doctorAsignar);
                    arrayCita = registrarFechas.GetArray();
            }
        }
    }
}
