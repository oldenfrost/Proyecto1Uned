using CapaEntidades;
using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Uned III Cuatrimestre 
 * Eduardo Cespedes miranda 
 * Descripcion: la interface grafica del menu principal 
 * fecha: 2/10/2023
 */

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        private Inicio inicio;
        private RegistrarTiposConsulta tiposConsultaP;
        private RegistroCitas registroCitasP;
        private AdministrarCliente administrarClienteP;
        private AdmistracionDoctores admistracionDoctoresP;
        private ReporteCitasFecha reporteCitasFechaP;
        private ReporteCitasDoctor reporteCitasDoctorP;
        private ReporteCitasCliente reporteCitasClienteP;






        public Form1()
        {
        
            InitializeComponent();
            inicio = new Inicio();
            tiposConsultaP= new RegistrarTiposConsulta();
           
            administrarClienteP= new AdministrarCliente();
            admistracionDoctoresP= new AdmistracionDoctores();
            reporteCitasFechaP = new ReporteCitasFecha();
            reporteCitasDoctorP= new ReporteCitasDoctor();
            reporteCitasClienteP= new ReporteCitasCliente();
            registroCitasP = new RegistroCitas();
          


            mostrarMenus(inicio);





        }


        // metodos 

        public void mostrarMenus(Form formulario)
        {
 
           if(this.ubicacionOpciones.Controls.Count > 0)
            {
                this.ubicacionOpciones.Controls.RemoveAt(0);


            }
            formulario.TopLevel = false;
            formulario.Dock=DockStyle.Fill;
            this.ubicacionOpciones.Controls.Add(formulario);
            this.ubicacionOpciones.Tag = formulario;
            formulario.Show();

        }


   


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdministracion_Click(object sender, EventArgs e)
        {

        }

        private void registrarTiposDeConsultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mostrarMenus(tiposConsultaP);

        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mostrarMenus(inicio);

        }

        private void registrarCitasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            mostrarMenus(registroCitasP);
            registroCitasP.LlenarComboBox();
            registroCitasP.ActualizarDataGrid();

        }

        private void administrarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mostrarMenus(administrarClienteP);
        }

        private void administracionDeDoctoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mostrarMenus(admistracionDoctoresP);
        }

        private void reporteCitasPorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reporteCitasFechaP.LlenarComboBox();
            mostrarMenus(reporteCitasFechaP);
        }

        private void reporteCitasPorDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reporteCitasDoctorP.LlenarComboBox();
            mostrarMenus(reporteCitasDoctorP);

        }


          
        

        private void reporteCitasPorClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reporteCitasClienteP.LlenarComboBox();
            mostrarMenus(reporteCitasClienteP);
        }

   
    }

  
}
