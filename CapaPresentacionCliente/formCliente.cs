using CapaEntidades;
using CapaLogicaNegocio;
using CapaPresentacion.clasesAuxiliaries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
/* Uned III Cuatrimestre 
 * Eduardo Cespedes miranda 
 * Descripcion: actualizacion de la capa de negocios 
 *  fecha: 16/11/2023
 */


namespace CapaPresentacionCliente
{
    public partial class formCliente : Form
    {

        private bool estadoConexion;
        private string identificacion;
        private CN_ClienteTCP tcpClient;
        private CN_VerificacionId verificacionId;
        private CN_servidor servidor;
        private bool conexionPosible;
        private RealizarCitaForm realizarCita;
        private consultarCitas consultarCitas;
        private Cliente cliente;



        public formCliente()
        {
            InitializeComponent();
            estadoConexion = false;
            tcpClient = new CN_ClienteTCP();
            verificacionId= new CN_VerificacionId();
            cliente=new Cliente();





        }

        private void RealizarCitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cliente = CN_ClienteTCP.ObtenerCliente(identificacion);
            mostrarMenus(realizarCita = new RealizarCitaForm(cliente));
        }

        private void ConsultarCitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cliente = CN_ClienteTCP.ObtenerCliente(identificacion);
            mostrarMenus(consultarCitas = new consultarCitas(cliente));

        }

        private void botonConexion_Click(object sender, EventArgs e)
        {
            if (estadoConexion == false)
            {


                    identificacion = InputBox("Ingrese la Identificacion para iniciar secion:", "Identificacion del Usuario");
            
                    
                if (!(identificacion.Equals(string.Empty)))
                {
                    if (CN_ClienteTCP.VerificarConexion())
                    {
                        
                            conexionPosible = true;
                       
                       


                    }
                    else
                    {
                        MessageBox.Show("No se ha Logrado la conexion con el servidor ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    if (conexionPosible)

                    {
                       if (verificacionId.VerificarNumero(identificacion))
                        {

                            if (CN_ClienteTCP.SolicitarVerificacion(identificacion))
                            {
                                Cliente cliente = new Cliente();
                                cliente = CN_ClienteTCP.ObtenerCliente(identificacion);
                                usuario.Text = cliente.identificacion.ToString() + ":" + " " + cliente.nombre.ToString() + " " + cliente.apellido1.ToString() + " " + cliente.apellido2.ToString();
                                botonConexion.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
                                botonConexion.IconColor = System.Drawing.Color.Brown;
                                botonConexion.ForeColor = System.Drawing.Color.Brown;
                                botonConexion.Text = "Cerrar Sesion";
                                estadoConexion = true;
                                RealizarCitaToolStripMenuItem.Enabled = true;
                                ConsultarCitaToolStripMenuItem.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("El Usuario no fue encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                CN_ClienteTCP.Cerrar();

                            }

                        }
                        else
                        {
                            MessageBox.Show("El dato ingresado no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                       
                    }




                }
                else
                {
                    MessageBox.Show("No se ha Ingresado la Identificacion del Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

           




            }
            else
            {
                DialogResult resultado = MessageBox.Show("¿Desea Cerrar Sesion?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    botonConexion.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
                    botonConexion.IconColor = System.Drawing.Color.ForestGreen;
                    botonConexion.ForeColor = System.Drawing.Color.ForestGreen;
                    botonConexion.Text = "Iniciar Secion";
                    estadoConexion = false;
                    usuario.Text = "";
                    RealizarCitaToolStripMenuItem.Enabled = false;
                    ConsultarCitaToolStripMenuItem.Enabled = false;
                    removerFormulario();

                    CN_ClienteTCP.Desconectar();
                    conexionPosible = false;

                }
                else
                {
                    return;
                }

            }
        }

        static string InputBox(string prompt, string title)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = prompt;

            buttonOk.Text = "Aceptar";
            buttonCancel.Text = "Cancelar";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new System.Drawing.Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new System.Drawing.Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            return (dialogResult == DialogResult.OK) ? textBox.Text : "";
        }

        private void cerrar_Click(object sender, EventArgs e)
        {

            this.Close();
        }


 

        public void mostrarMenus(Form formulario)
        {
            if (this.ubicacionOpciones.Controls.Count > 0)
            {
                this.ubicacionOpciones.Controls.RemoveAt(0);
            }
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;
            this.ubicacionOpciones.Controls.Add(formulario);
            this.ubicacionOpciones.Tag = formulario;
            formulario.Show();
        }
        public void removerFormulario()
        {
            if (this.ubicacionOpciones.Controls.Count > 0)
            {
                Form formulario = (Form)this.ubicacionOpciones.Controls[0];
                formulario.Hide();
                this.ubicacionOpciones.Controls.RemoveAt(0);
                formulario.Dispose(); 
            }
        }

        private void formCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conexionPosible)
            {
                CN_ClienteTCP.Desconectar();
            }
            else
            {
                CN_ClienteTCP.Cerrar();
            }

          

        }
    }
}
