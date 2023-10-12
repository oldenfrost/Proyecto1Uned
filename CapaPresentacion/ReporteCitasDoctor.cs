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
        private Cita[] arrayCita = new Cita[20];
        private CN_RegistrarFecha registrarFechas = new CN_RegistrarFecha();
        private CN_ReporteDoctores reportes = new CN_ReporteDoctores();
        private Cita[] reportesPorFecha;
        public ReporteCitasDoctor()
        {
            InitializeComponent();
        }
        // llena el combo bos
        public void LlenarComboBox()
        {
            dataGridCita.Rows.Clear();
            doctorComboBox.Items.Clear();
            doctorComboBox.Items.Add("Seleccione el/la dentista para consultar");
            doctorComboBox.SelectedItem = "Seleccione el/la dentista para consultar";
            arrayCita = registrarFechas.GetArray();
            foreach (Cita cita in arrayCita)
            {
                //verifica que hay datos en el el array
                if (arrayCita[0] != null)
                {
                    string nombre = "ID:" + " " + cita.Doctor.Identificacion + " " + "Nombre: " + cita.Doctor.Nombre + " " + cita.Doctor.Apellido1;
                    if (!doctorComboBox.Items.Contains(nombre))
                    {
                        doctorComboBox.Items.Add(nombre);
                    }
                }
                // muestra mensaje si no los hay
                else
                {
                    MessageBox.Show("No hay citas registradas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }
        // realiza la consulta
        private void Consultar_Click(object sender, EventArgs e)
        {
            reportes.SetArrya(arrayCita);
            string[] infoDoctorSeparada= doctorComboBox.Text.Split(' ');
            reportesPorFecha = reportes.ReporteFechas(int.Parse(infoDoctorSeparada[1]));
            dataGridCita.Rows.Clear();
            foreach (Cita cita in reportesPorFecha.Where(c => c != null))
            {
                dataGridCita.Rows.Add(cita.Numero, cita.FechaHoraCita, cita.TipoConsulta.Descripcion, cita.Cliente.Nombre + " " + cita.Cliente.Apellido1, cita.Doctor.Nombre + " " + cita.Doctor.Apellido1);
            }
        }
    }


}
