using CapaDatos;
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
 * Descripcion: funcion para reportar clientes
 * fecha: 11/10/2023
 */

namespace CapaPresentacion
{
    public partial class ReporteCitasCliente : Form
    {


        private List<Cita>citasLista= new List<Cita>();
        private CN_ReporteCliente n_ReporteCliente = new CN_ReporteCliente();

        public ReporteCitasCliente()
        {
            InitializeComponent();
            LlenarComboBox();



        }
        //metodos
        public void LlenarComboBox()
        {

           dataGridCita.Rows.Clear();
           clienteComboBox.Items.Clear();
           clienteComboBox.Items.Add("Seleccione el/la Cliente para consultar");
           clienteComboBox.SelectedItem = "Seleccione el/la Cliente para consultar";
           citasLista = n_ReporteCliente.retornarCitaClientesLista();
            
            if (citasLista.Count == 0)
            {
                MessageBox.Show("No hay citas registradas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                foreach (Cita cita in citasLista)
                {
                    clienteComboBox.Items.Add(cita.id_cliente.identificacion+"."+" "+ cita.id_cliente.nombre+" "+ cita.id_cliente.apellido1+" "+cita.id_cliente.apellido2);


                }
            }
        



        }
        // realiza la consulta
        private void Consultar_Click(object sender, EventArgs e)
        {
            citasLista.Clear();
            citasLista = n_ReporteCliente.retornarCita();
            dataGridCita.Rows.Clear();
           if( clienteComboBox.SelectedItem.ToString() == "Seleccione el/la Cliente para consultar")
            {
                MessageBox.Show("No ha seleccionado una opcion para el reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else
            {
                string[] infoSeparado = clienteComboBox.Text.Split('.');
                short idCliente = short.Parse(infoSeparado[0]);
                foreach (Cita cita in citasLista)
                {
                    if (cita.id_cliente.identificacion == idCliente)
                    {
                        dataGridCita.Rows.Add(cita.numero, cita.fec_hor_cita, cita.cod_tip_consulta.descripcion, cita.id_cliente.nombre + " " + cita.id_cliente.apellido1 + " " + cita.id_cliente.apellido2, cita.id_doctor.nombre + " " + cita.id_doctor.apellido1 + " " + cita.id_doctor.apellido2);
                    }

                }

            }
            

           
        }
    }
}
