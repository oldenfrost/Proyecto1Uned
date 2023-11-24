using CapaEntidades;
using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Uned III Cuatrimestre 
 * Eduardo Cespedes miranda 
 * Descripcion: funcion del menu para reportar citas por doctor
 * fecha: 11/10/2023
 */

namespace CapaPresentacion
{
    public partial class ReporteCitasDoctor : Form
    {
       
        private CN_ReporteDoctores reportes = new CN_ReporteDoctores();
        private List<Cita> citaLista= new List<Cita>(); 

        public ReporteCitasDoctor()
        {
            InitializeComponent();
        }
        // llena el combo bos
        public void LlenarComboBox()
        {

            dataGridCita.Rows.Clear();
            doctorComboBox.Items.Clear();
            doctorComboBox.Items.Add("Seleccione el/la Doctor para consultar");
            doctorComboBox.SelectedItem = "Seleccione el/la Doctor para consultar";
            citaLista = reportes.retornarCitaDoctoresLista();

            if (citaLista.Count == 0)
            {
                MessageBox.Show("No hay citas registradas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                foreach (Cita cita in citaLista)
                {
                    doctorComboBox.Items.Add(cita.id_doctor.identificacion + "." + " " + cita.id_doctor.nombre + " " + cita.id_doctor.apellido1 + " " + cita.id_doctor.apellido2);


                }
            }




        }
        // realiza la consulta
        private void Consultar_Click(object sender, EventArgs e)
        {
            citaLista.Clear();
            citaLista = reportes.retornarCita();
            dataGridCita.Rows.Clear();
            if (doctorComboBox.SelectedItem.ToString() == "Seleccione el/la Doctor para consultar")
            {
                MessageBox.Show("No ha seleccionado una opcion para el reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else{
                string[] infoSeparado = doctorComboBox.Text.Split('.');
                short idDoctor = short.Parse(infoSeparado[0]);

                foreach (Cita cita in citaLista)
                {
                    if (cita.id_doctor.identificacion == idDoctor)
                    {
                        dataGridCita.Rows.Add(cita.numero, cita.fec_hor_cita, cita.cod_tip_consulta.descripcion, cita.id_cliente.nombre + " " + cita.id_cliente.apellido1 + " " + cita.id_cliente.apellido2, cita.id_doctor.nombre + " " + cita.id_doctor.apellido1 + " " + cita.id_doctor.apellido2);
                    }

                }
            }
        }
    }


}
