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
 * Descripcion: Actualizacion con base de datos funcion del menu para reportar por fechas
 * fecha: 14/10/2023
 */

namespace CapaPresentacion
{
    public partial class ReporteCitasFecha : Form
    {
        private List<Cita> citasListas = new List<Cita> ();
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
            citasListas = reportes.retornarCita();
            arrayCita = new Cita[citasListas.Count];
            arrayCita = citasListas.ToArray();
            dataGridCita.Rows.Clear();
            fechasComboBox.Items.Clear();
            fechasComboBox.Items.Add("Seleccione La fecha para consultar");
            fechasComboBox.SelectedItem = "Seleccione La fecha para consultar";
            //arrayCita = registrarFechas.GetArray();
            foreach (Cita cita in arrayCita)
            {
                //verifica si hay datos en el array
                if (arrayCita[0] != null)
                {
                    DateTime fecha = cita.fec_hor_cita.Date;
                    if (!fechasComboBox.Items.Contains(fecha))
                    {
                        fechasComboBox.Items.Add(fecha);
                    }
                }
                // si no muesra mensaje
                else
                {
                    MessageBox.Show("No hay citas registradas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }
        // realiza el reporte
        private void Consultar_Click(object sender, EventArgs e)
        {
            dataGridCita.Rows.Clear();
            citasListas = reportes.retornarCita();
            arrayCita = new Cita[citasListas.Count];
            arrayCita = citasListas.ToArray();
            if (fechasComboBox.SelectedItem.ToString() == "Seleccione La fecha para consultar")
            {
                MessageBox.Show("No ha seleccionado una opcion para el reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else
            {
                string fechaSeleccionada = fechasComboBox.SelectedItem.ToString();
                if (DateTime.TryParse(fechaSeleccionada, out DateTime fechaConvertida))
                {
                    var datosFiltrados = citasListas.Where(dato => dato.fec_hor_cita.Date == fechaConvertida.Date);
                    foreach (var dato in datosFiltrados)
                    {
                        dataGridCita.Rows.Add(dato.numero, dato.fec_hor_cita, dato.cod_tip_consulta.descripcion, dato.id_cliente.nombre + " " + dato.id_cliente.apellido1 + " " + dato.id_cliente.apellido2, dato.id_doctor.nombre + " " + dato.id_doctor.apellido1 + " " + dato.id_doctor.apellido2);
                    }
                }
            }

            
            



          

         
        }
    }
}

