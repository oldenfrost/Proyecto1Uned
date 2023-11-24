using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Bitacora : Form
    {
        private List<string> textoBitacora;
        private CN_servidor servidor;
        private Thread hiloActualizacion;

        public Bitacora()
        {
            InitializeComponent();
            servidor = new CN_servidor();
            bitacoraTextoBox.ReadOnly = true;


          hiloActualizacion = new Thread(ActualizarBitacora);
          hiloActualizacion.Start();
        }

        private void ActualizarBitacora()
        {
            while (true) 
            {
               
                if (bitacoraTextoBox.InvokeRequired)
                {
                    bitacoraTextoBox.Invoke(new Action(EscribirBitacora));
                }
                else
                {
               
                    EscribirBitacora();
                }

                Thread.Sleep(2000);
            }
        }

        private void EscribirBitacora()
        {
            textoBitacora = new List<string>();
            textoBitacora = servidor.ObtenerLosComandosRealizados();

            bitacoraTextoBox.Clear();
            string textoImprimir = "";
            foreach (string str in textoBitacora)
            {
                textoImprimir += $"\n{str}{Environment.NewLine}";
            }
            bitacoraTextoBox.Text = textoImprimir;
        }

    
    }
}

