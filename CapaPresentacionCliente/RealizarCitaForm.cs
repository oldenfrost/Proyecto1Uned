using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaLogicaNegocio;
/* Uned III Cuatrimestre 
 * Eduardo Cespedes miranda 
 * Descripcion: actualizacion de la capa de negocios 
 *  fecha: 16/11/2023
 */

namespace CapaPresentacionCliente
{
    public partial class RealizarCitaForm : Form
    {
        private DateTime fechaHoraCita;
        private Cliente cliente;
        private static short idCita;
        public RealizarCitaForm(Cliente cliente)
        {
            InitializeComponent();
            
            doctorComboB.Items.Add("Seleccione el/la Dentista");
            doctorComboB.SelectedItem = "Seleccione el/la Dentista";
            tipoConsultaComboB.Items.Add("Seleccione el tipo de consulta");
            tipoConsultaComboB.SelectedItem = "Seleccione el tipo de consulta";
    
            this.cliente = cliente;
            llenarComboBox();
            llenarComboHoras();
        }

        private void llenarComboBox()
        {
            List<Doctor> doctores= new List<Doctor> ();
            doctores = CN_ClienteTCP.ObtenerDoctotes();
            List<Tipo_Consulta> consultas = new List<Tipo_Consulta>();
            doctores = CN_ClienteTCP.ObtenerDoctotes();
            consultas=CN_ClienteTCP.ObtenerConsultas();
            foreach (Doctor doctor in doctores)
            {
                if (doctor.estado == 'A')
                {
     
                    doctorComboB.Items.Add(doctor.identificacion + "." + ' ' + doctor.nombre + "." + " " + doctor.apellido1);

                }

            }
            foreach (Tipo_Consulta consulta in consultas)
            {
                if (consulta.estado == 'A')
                {

                    tipoConsultaComboB.Items.Add(consulta.numero + "." + ' ' + consulta.descripcion);

                }

            }

        }
        private void llenarComboHoras()
        {
            for (int i = 6; i < 21; i++)
            {
                horaCitasComboB.Items.Add(i.ToString("0") + ":00");
            }
        }

        private void registrar_Click(object sender, EventArgs e)
        {
            string mensaje = "";

            // verificacion para determinar si los campos estan vacios o escritos o si el combo box ha sido seleccionado
            if (  doctorComboB.SelectedItem.ToString() == "Seleccione el/la Dentista" || horaCitasComboB.SelectedItem.ToString() == "Seleccione la hora para la cita del paciente" || tipoConsultaComboB.SelectedItem.ToString() == "Seleccione el tipo de consulta")
            {
                /*la funcion de estos if es solo para brindarle al usuario un mensaje que lo oriente a saber que campo 
                exacto es el que no ha sido escrito bien */

              
                if (tipoConsultaComboB.SelectedItem.ToString() == "Seleccione el tipo de consulta")
                {
                    mensaje += "No ha sido seleccionado el tipo de consulta. \n ";
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
            

                idCita=0;
              
                fechaHoraCita = DateTime.ParseExact(horaCitasComboB.SelectedItem.ToString(), "H:mm", CultureInfo.InvariantCulture);
                fechaHoraCita = fechaCitaDatePicker.Value.Date.AddHours(fechaHoraCita.Hour).AddMinutes(fechaHoraCita.Minute);
                // el valor del indice seleccionado del comboBox se le resta para obtener el mismo indice del elemento en el array con los mismo valores del combo
                string[] infoSeparado = tipoConsultaComboB.Text.Split('.');
                short numeroConsulta = short.Parse(infoSeparado[0]);
         
                long numeroCliente = long.Parse(infoSeparado[0]);
                infoSeparado = doctorComboB.Text.Split('.');
                long numeroDoctor = long.Parse(infoSeparado[0]);

                Cita citaNueva = new Cita
                {
                    numero = 0,
                    fec_hor_cita = fechaHoraCita,
                    cod_tip_consulta = new Tipo_Consulta
                    {
                        numero = numeroConsulta,
                        descripcion = "",
                        estado = 'X'
                    },
                    id_cliente = new Cliente
                    {
                        identificacion = cliente.identificacion,
                        nombre = "",
                        apellido1 = "",
                        apellido2 = "",
                        fec_nacimiento = new DateTime(),
                        genero = 'x'
                    },
                    id_doctor = new Doctor
                    {
                        identificacion= numeroDoctor,
                        nombre = "",
                        apellido1 = "",
                        apellido2 = "",
                        estado = 'x'
                    }


                };


                if (CN_ClienteTCP.insertarCita(citaNueva))
                {
                    MessageBox.Show("La Cita fue Registrado correctamente", "Añadido Correctamente", MessageBoxButtons.OK);
                }
                else
                {

                    MessageBox.Show("Hubo un error en insertar la cita por favor verifique los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
        }
    }
}
