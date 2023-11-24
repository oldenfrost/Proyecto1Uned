using CapaEntidades;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;
using CapaDatos;
using CapaPresentacion.clasesAuxiliaries;
/* Uned III Cuatrimestre 
* Eduardo Cespedes miranda 
* Descripcion: creacion del servidor
* fecha: 12/11/2023
*/

namespace CapaLogicaNegocio
{
    public class CN_servidor
    {
        TcpListener tcpListener;
        Thread threadEscuchaCliente;
        bool servidorConectado;
        private string ip;
        private int port;
        private static List<string> query= new List<string>();
        private string bitacora;
        private DateTime fechaHoraActual;
        private static StreamWriter clienteStreamWriter;
        private static bool encontrado=false;
        public static Form formPrincipal;
        private CD_Clientes clientes;
        private CD_Citas d_Citas;
        private Cliente usuario;
        private static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        private CN_RegistrarFecha CN_RegistrarFecha;

        public CN_servidor(Form formPrincipal)
        {
            CN_servidor.formPrincipal = formPrincipal;
        }

        public CN_servidor()
        {
            usuario = new Cliente();


        }

        /* codigo analisaso, usado y modificado de los proyectos ejemplos de servidor cliente brindados por la uned
         * y compartidos por el tutor 
          JUAN PABLO NAVARRO FENNEL*/


        public bool  EscucharSolicitud()
        {
          
            try
            {
                servidorConectado = true;
                tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"),14100);
                threadEscuchaCliente = new Thread(new ThreadStart(EscucharClientes));
                threadEscuchaCliente.Start();
                threadEscuchaCliente.IsBackground = true;

                return servidorConectado;
             
            }
            catch (SocketException ex)
            {
                servidorConectado = false;
                MessageBox.Show($"Error de socket: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return servidorConectado;
       
            }
            catch (FormatException ex)
            {
                servidorConectado = false;
                MessageBox.Show($"Error de formato de dirección IP: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return servidorConectado;
            }
            catch (Exception ex)

            {
                servidorConectado = false;
                MessageBox.Show($"Error desconocido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return servidorConectado;

            }
        }



        private void EscucharClientes()
        {
            tcpListener.Start();
            try
            {
                while (servidorConectado)
                {
                    TcpClient cliente = tcpListener.AcceptTcpClient();
                    Thread clientThread = new Thread(new ParameterizedThreadStart(ConexionConCliente));
                    clientThread.Start(cliente);
                }
            }
            catch (SocketException)
            {
                return;
            }
            catch (Exception)
            {
                return;
            }

        }

        private void ConexionConCliente(object cliente)
        {
            TcpClient tcpClient = (TcpClient)cliente;
            StreamReader reader = new StreamReader(tcpClient.GetStream());
            StreamWriter servidorStreamWriter = new StreamWriter(tcpClient.GetStream());

            while (servidorConectado)
            {
                try
                {
                 
                    var mensaje = reader.ReadLine();
                    SocketMensaje<object> mensajeRecibido = JsonConvert.DeserializeObject<SocketMensaje<object>>(mensaje);
                    SeleccionarComando(mensajeRecibido.Comando, mensaje, ref servidorStreamWriter);
                }
                catch (JsonReaderException jsonEx)
                {

                    MessageBox.Show($"Error al analizar JSON: {jsonEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }
               catch (IOException ioEx)
                {

                    return;
                }
                catch (SocketException socketEx)
                {

                    MessageBox.Show($"Error de socket: {socketEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (Exception ex)
                {

                    return;
                }
                finally
                {

                
                }
            }
        }

        public void DetenerSolicitudes()
        {
            servidorConectado = false;
            tcpListener.Stop();

        }

        private void SeleccionarComando(string comando, string mensaje, ref StreamWriter servidorStreamWriter)
        {

            switch (comando)
            {
                

     
                case "VerificarIdentificacion":
                    SocketMensaje<string> mensajeVerificacion = JsonConvert.DeserializeObject<SocketMensaje<string>>(mensaje);
                    bool autenticado = VerificarAutenticacionCliente(mensajeVerificacion.Entidad);

                    if (autenticado)
                    {

                        fechaHoraActual = DateTime.Now;
                        bitacora = $"El Clienta {usuario.identificacion}: {usuario.nombre} {usuario.apellido1} {usuario.apellido2} se ha conectado en el servidor el {fechaHoraActual:MM/dd/yyyy} a las {fechaHoraActual:HH:mm}";
                        query.Add(bitacora);
                        servidorStreamWriter.WriteLine(JsonConvert.SerializeObject("1"));
                        servidorStreamWriter.Flush();

                    }
                    else
                    {
                        servidorStreamWriter.WriteLine(JsonConvert.SerializeObject("0"));
                        servidorStreamWriter.Flush();

                    }

                    // Enviar la respuesta al cliente
               
                    break;
             


                case "Desconectar":
                    fechaHoraActual = DateTime.Now;
                    bitacora = $"El Clienta {usuario.identificacion}: {usuario.nombre} {usuario.apellido1} {usuario.apellido2} se ha desconectado en el servidor el {fechaHoraActual:MM/dd/yyyy} a las {fechaHoraActual:HH:mm}";
                    query.Add(bitacora);
                    SocketMensaje<string> mensajeDesconectar = JsonConvert.DeserializeObject<SocketMensaje<string>>(mensaje);
                break;

                case "ObtenerCliente":
                    SocketMensaje<string> mensajeObtenerCliente = JsonConvert.DeserializeObject<SocketMensaje<string>>(mensaje);
                    semaphore.Wait();
                    ObtenerCliente(ref servidorStreamWriter,mensajeObtenerCliente.Entidad);
                    semaphore.Release();
                    break;

                case "ObtenerDoctores":
                    SocketMensaje<string> mensajeObtenerDoctores = JsonConvert.DeserializeObject<SocketMensaje<string>>(mensaje);
                    semaphore.Wait();
                    ObtenerDoctores(ref servidorStreamWriter);
                    semaphore.Release();
                    break;
                case "ObtenerTipoConsultas":
                    SocketMensaje<string> mensajeObtenerConsultas = JsonConvert.DeserializeObject<SocketMensaje<string>>(mensaje);
                    semaphore.Wait();
                    ObtenerConsultas(ref servidorStreamWriter);
                    semaphore.Release();
                    break;
                case "ObtenerCitas":
                    SocketMensaje<string> mensajeObtenerCitas = JsonConvert.DeserializeObject<SocketMensaje<string>>(mensaje);
                    semaphore.Wait();
                    ObtenerCitas(ref servidorStreamWriter);
                    semaphore.Release();
                    break;
                case "InsertarCita":
                    semaphore.Wait();
                    SocketMensaje<Cita> mensajeInsertar = JsonConvert.DeserializeObject<SocketMensaje<Cita>>(mensaje);
                    if (IngresarCitas(mensajeInsertar.Entidad))
                    {

                        fechaHoraActual = DateTime.Now;
                        bitacora = $"El Clienta {usuario.identificacion}: {usuario.nombre} {usuario.apellido1} {usuario.apellido2} ha ingresado una cita el {fechaHoraActual:MM/dd/yyyy} a las {fechaHoraActual:HH:mm}";
                        query.Add(bitacora);
                        servidorStreamWriter.WriteLine(JsonConvert.SerializeObject("1"));
                        servidorStreamWriter.Flush();

                    }
                    else
                    {
                        servidorStreamWriter.WriteLine(JsonConvert.SerializeObject("0"));
                        servidorStreamWriter.Flush();

                    }
                 
                    semaphore.Release();
                    break;

             

            }
        }

        public List<string> ObtenerLosComandosRealizados()
        {
            
         
            
                return query;
            
        

        }

        public bool VerificarAutenticacionCliente(string identificacion)
        {
            // Lógica para verificar la identificación en la base de datos
            CD_Clientes d_Clientes = new CD_Clientes();
            List<Cliente> clientesLista = d_Clientes.GetClienteList();
            long id = Convert.ToInt64(identificacion);


            foreach (Cliente cliente in clientesLista)
            {
                if (id == cliente.identificacion)
                {
                    usuario = new Cliente
                    {
                        identificacion = cliente.identificacion,
                        nombre = cliente.nombre,
                        apellido1 = cliente.nombre,
                        apellido2 = cliente.nombre,
                        fec_nacimiento = cliente.fec_nacimiento,
                        genero = cliente.genero,

                    };
                    return true;
                }
            }

            return false;
        }

        private void ObtenerCliente(ref StreamWriter servidorStreamWriter, string identificacion)
        {
           


            CD_Clientes d_Clientes = new CD_Clientes();
            List<Cliente> clientesLista = d_Clientes.GetClienteList();
            long id = Convert.ToInt64(identificacion);
            foreach (Cliente cliente in clientesLista)
            {
                if (id == cliente.identificacion)
                {
                    usuario = new Cliente
                    {
                        identificacion = cliente.identificacion,
                        nombre = cliente.nombre,
                        apellido1 = cliente.apellido1,
                        apellido2 = cliente.apellido2,
                        fec_nacimiento = cliente.fec_nacimiento,
                        genero = cliente.genero,

                    };
                }
            }


            servidorStreamWriter.WriteLine(JsonConvert.SerializeObject(usuario));
            servidorStreamWriter.Flush();
        }

        private void ObtenerDoctores(ref StreamWriter servidorStreamWriter)
        {
       


            CD_Doctores d_Doctores = new CD_Doctores();
            List<Doctor> doctoresLista= new List<Doctor>();
            doctoresLista= d_Doctores.GetDoctorList();

            servidorStreamWriter.WriteLine(JsonConvert.SerializeObject(doctoresLista));
            servidorStreamWriter.Flush();
        }
        private void ObtenerConsultas(ref StreamWriter servidorStreamWriter)
        {



            CD_TiposConsultas d_Consultas= new CD_TiposConsultas();
            List<Tipo_Consulta> doctoresLista = new List<Tipo_Consulta>();
            doctoresLista = d_Consultas.GetTipoConsultaList();
            servidorStreamWriter.WriteLine(JsonConvert.SerializeObject(doctoresLista));
            servidorStreamWriter.Flush();
        }
        private short ObtenerIdCita()
        {

            Cita ultimaCita = new Cita();
            short i = 1;


            CD_Citas d_Citas = new CD_Citas();
            List<Cita> citaLista = d_Citas.GetCitasList();
            foreach (Cita cita in citaLista)
            {
                i = 1;
                i += cita.numero;
            }

            return i;
   
          

        }
        private void ObtenerCitas(ref StreamWriter servidorStreamWriter)
        {


            fechaHoraActual = DateTime.Now;
            bitacora = $"El Clienta {usuario.identificacion}: {usuario.nombre} {usuario.apellido1} {usuario.apellido2} ha realizado una consulta {fechaHoraActual:MM/dd/yyyy} a las {fechaHoraActual:HH:mm}";
            query.Add(bitacora);
            CD_Citas d_Citas = new CD_Citas();
            List<Cita> CitaLista = new List<Cita>();
            CitaLista = d_Citas.GetCitasList();
            servidorStreamWriter.WriteLine(JsonConvert.SerializeObject(CitaLista));
            servidorStreamWriter.Flush();
        }


        private bool IngresarCitas(Cita cita)
        {
           
            CN_RegistrarFecha =new CN_RegistrarFecha();
            return CN_RegistrarFecha.RegistrarEnElCliente(ObtenerIdCita(), cita.fec_hor_cita, cita.cod_tip_consulta.numero, cita.id_cliente.identificacion, cita.id_doctor.identificacion);
        }

    }
}
