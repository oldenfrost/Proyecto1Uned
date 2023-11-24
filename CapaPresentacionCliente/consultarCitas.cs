using CapaEntidades;
using CapaLogicaNegocio;
using CapaPresentacion.clasesAuxiliaries;
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
 * Descripcion: actualizacion de la capa de negocios 
 *  fecha: 16/11/2023
 */

namespace CapaPresentacionCliente
{
    public partial class consultarCitas : Form
    {
        private Cliente cliente;
        private CN_VerificacionId verificacion;

        public consultarCitas(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
            verificacion= new CN_VerificacionId();
        }
        private void consultar_Click(object sender, EventArgs e)
        {
            List<Cita> lista = new List<Cita>();
            lista = CN_ClienteTCP.ObtenerCitas();
            dataGridCita.Rows.Clear();


            foreach (Cita cita in lista)
            {
                if (cita.id_cliente.identificacion == cliente.identificacion)
                {
                    dataGridCita.Rows.Add(cita.numero, cita.fec_hor_cita, cita.cod_tip_consulta.descripcion, cita.id_cliente.nombre + " " + cita.id_cliente.apellido1 + " " + cita.id_cliente.apellido2, cita.id_doctor.nombre + " " + cita.id_doctor.apellido1 + " " + cita.id_doctor.apellido2);
                }

            }



        }
        private void consultarConId_Click(object sender, EventArgs e)
        {


            string identificacion = idText.Text;
            dataGridCita.Rows.Clear();
            bool seEncontro=false;

            if (!(identificacion.Equals(string.Empty)))
            {
                if (verificacion.VerificarNumero(identificacion))
                {
                    short id = short.Parse(identificacion);

                    List<Cita> lista = new List<Cita>();
                    lista = CN_ClienteTCP.ObtenerCitas();
                    foreach (Cita cita in lista)
                    {
                        if (cita.numero == id&&cita.id_cliente.identificacion==cliente.identificacion)
                        {
                            dataGridCita.Rows.Add(cita.numero, cita.fec_hor_cita, cita.cod_tip_consulta.descripcion, cita.id_cliente.nombre + " " + cita.id_cliente.apellido1 + " " + cita.id_cliente.apellido2, cita.id_doctor.nombre + " " + cita.id_doctor.apellido1 + " " + cita.id_doctor.apellido2);
                            seEncontro=true;
                        }

                    }

                }
                else
                {
                    MessageBox.Show("El dato ingresado no es un numero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
  

            }
            else
            {
                MessageBox.Show("No se ha Ingresado la Identificacion del Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if(seEncontro==false) {
                MessageBox.Show("No se encontro el numero de cita ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

               


        }

    }
}
