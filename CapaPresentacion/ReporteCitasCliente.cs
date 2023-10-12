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

namespace CapaPresentacion
{
    public partial class ReporteCitasCliente : Form
    {
        private Cita[] arrayCita = new Cita[20];
        private CN_RegistrarFecha registrarFechas = new CN_RegistrarFecha();
        private CN_ReporteCliente reportes = new CN_ReporteCliente();
        private Cita[] reportesPorFecha;
        public ReporteCitasCliente()
        {
            InitializeComponent();
        }
        public void LlenarComboBox()
        {

            dataGridCita.Rows.Clear();
           clienteComboBox.Items.Clear();
           clienteComboBox.Items.Add("Seleccione el/la dentista para consultar");
           clienteComboBox.SelectedItem = "Seleccione el/la dentista para consultar";
            arrayCita = registrarFechas.GetArray();
            foreach (Cita cita in arrayCita)
            {
                string nombre = "ID:" + " " + cita.Cliente.Identificacion + " " + "Nombre: " + cita.Cliente.Nombre + " " + cita.Cliente.Apellido1; 

                if (!clienteComboBox.Items.Contains(nombre))
                {
                   clienteComboBox.Items.Add(nombre);
                }
            }


        }

        private void Consultar_Click(object sender, EventArgs e)
        {

            reportes.SetArrya(arrayCita);
            string[] infoDoctorSeparada =clienteComboBox.Text.Split(' ');
            reportesPorFecha = reportes.ReporteFechas(int.Parse(infoDoctorSeparada[1]));
            dataGridCita.Rows.Clear();



            foreach (Cita cita in reportesPorFecha.Where(c => c != null))
            {

                dataGridCita.Rows.Add(cita.Numero, cita.FechaHoraCita, cita.TipoConsulta.Descripcion, cita.Cliente.Nombre + " " + cita.Cliente.Apellido1, cita.Doctor.Nombre + " " + cita.Doctor.Apellido1);

            }
        }
    }
}
