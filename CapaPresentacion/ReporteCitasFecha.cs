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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

/* Uned III Cuatrimestre 
 * Eduardo Cespedes miranda 
 * Descripcion: funcion del menu Registrar consulta
 * fecha: 11/10/2023
 */

namespace CapaPresentacion
{
    public partial class ReporteCitasFecha : Form
    {

        private Cita[] arrayCita = new Cita[20];
        private CN_RegistrarFecha registrarFechas = new CN_RegistrarFecha();
        private CN_ReporteFechas reportes = new CN_ReporteFechas();
        private Cita[] reportesPorFecha;

        public ReporteCitasFecha()
        {
            InitializeComponent();

        }

        public void LlenarComboBox()
        {

            dataGridCita.Rows.Clear();
            fechasComboBox.Items.Clear();
            fechasComboBox.Items.Add("Seleccione La fecha para consultar");
            fechasComboBox.SelectedItem = "Seleccione La fecha para consultar";
            arrayCita = registrarFechas.GetArray();
            foreach (Cita cita in arrayCita)
            {
                DateTime fecha = cita.FechaHoraCita.Date;

  
                if (!fechasComboBox.Items.Contains(fecha))
                {
                    fechasComboBox.Items.Add(fecha);
                }
            }


        }

        private void Consultar_Click(object sender, EventArgs e)
        {

            reportes.SetArrya(arrayCita);
            reportesPorFecha = reportes.ReporteFechas(fechasComboBox.Text);
            dataGridCita.Rows.Clear();

            foreach (Cita cita in reportesPorFecha.Where(c => c != null))
            {
     
                dataGridCita.Rows.Add(cita.Numero, cita.FechaHoraCita, cita.TipoConsulta.Descripcion, cita.Cliente.Nombre + " " + cita.Cliente.Apellido1, cita.Doctor.Nombre + " " + cita.Doctor.Apellido1);

            }
        }
    }
}

