using CapaEntidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.Net.Http;
/* Uned III Cuatrimestre 
* Eduardo Cespedes miranda 
* Descripcion: creacion del tcp Cliente
 * fecha: 15/11/2023
*/

namespace CapaLogicaNegocio
{
    public  class CN_ClienteTCP : IDisposable

    {
        private static IPAddress ip;

        private static TcpClient cliente;
        private static IPEndPoint serverEndPoint;
        private static StreamWriter clienteStreamWriter;
        private static StreamReader clienteStreamReader;

        private static bool _conectado = false;

        public static bool Conectado
        {
            get { return _conectado; }
            set { _conectado = value; }
        }
        public void Dispose()
        {
            clienteStreamWriter?.Dispose();
            clienteStreamReader?.Dispose();
            cliente?.Close();
        }
        public static bool VerificarConexion()
        {
            try
            {
                ip = IPAddress.Parse("127.0.0.1");
                cliente = new TcpClient();
                serverEndPoint = new IPEndPoint(ip, 14100);
                cliente.Connect(serverEndPoint);


                clienteStreamReader = new StreamReader(cliente.GetStream());
                clienteStreamWriter = new StreamWriter(cliente.GetStream());



            }
            catch (SocketException)
            {

                return false;
            }

            return true;
        }
       

        public static bool SolicitarVerificacion(string identificacion)
        {
            try
            {
                SocketMensaje<string> mensajeVerificar = new SocketMensaje<string>
                {
                    Comando = "VerificarIdentificacion",
                    Entidad = identificacion
                };

                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeVerificar));
                clienteStreamWriter.Flush();
                var respuesta = clienteStreamReader.ReadLine();
           

                Conectado = respuesta.Contains("1");
                






      

                return Conectado; 
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Error al analizar JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Desconocido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static Cliente ObtenerCliente(string id)
        {

            try
            {
                Cliente cliente = new Cliente();
                SocketMensaje<string> mensajeObtenerCLiente = new SocketMensaje<string> { Comando = "ObtenerCliente", Entidad=id };
                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeObtenerCLiente));
                clienteStreamWriter.Flush();
                var mensaje = clienteStreamReader.ReadLine();
                cliente = JsonConvert.DeserializeObject<Cliente> (mensaje);
                return cliente;
            }
        
            catch (JsonException ex)
            {
                MessageBox.Show($"Error al analizar JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; ;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Desconocido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }



        }
  

        public static  List<Doctor> ObtenerDoctotes()
        {

            try
            {
                List<Doctor> listaDoctores = new List<Doctor>();
                SocketMensaje<string> mensajeObtenerDoctores = 
                    new SocketMensaje<string> {
                        Comando = "ObtenerDoctores"
                       };
                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeObtenerDoctores));
                clienteStreamWriter.Flush();
                var mensaje = clienteStreamReader.ReadLine();
                listaDoctores = JsonConvert.DeserializeObject<List<Doctor>>(mensaje);
                return listaDoctores;
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Error al analizar JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; ;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Desconocido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }



        }
        public static List<Tipo_Consulta> ObtenerConsultas()
        {

            try
            {
                List<Tipo_Consulta> listaConsultas = new List<Tipo_Consulta>();

                SocketMensaje<string> mensajeObtenerConsultas =
                    new SocketMensaje<string>
                    {
                        Comando = "ObtenerTipoConsultas"
                    };
                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeObtenerConsultas));
                clienteStreamWriter.Flush();
                var mensaje = clienteStreamReader.ReadLine();
                listaConsultas = JsonConvert.DeserializeObject<List<Tipo_Consulta>>(mensaje);
                return listaConsultas;
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Error al analizar JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; ;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Desconocido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }



        }

        public static List<Cita> ObtenerCitas()
        {

            try
            {
                List<Cita> listaCitas = new List<Cita>();

                SocketMensaje<string> mensajeObtenerConsultas =
                    new SocketMensaje<string>
                    {
                        Comando = "ObtenerCitas"
                    };
                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeObtenerConsultas));
                clienteStreamWriter.Flush();
                var mensaje = clienteStreamReader.ReadLine();
                listaCitas = JsonConvert.DeserializeObject<List<Cita>>(mensaje);
                return listaCitas;
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Error al analizar JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; ;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Desconocido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }



        }

        public static bool insertarCita(Cita cita)
        {

            try
            {
                
                SocketMensaje<Cita> mensajeInsertarCita = new SocketMensaje<Cita> 
                { Comando = "InsertarCita",
                  Entidad = cita };
                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeInsertarCita));
                clienteStreamWriter.Flush();
                var respuesta = clienteStreamReader.ReadLine();


                Conectado = respuesta.Contains("1");

                return Conectado;
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Error al analizar JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; ;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Desconocido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }



        }

        public static void Desconectar()
        {
            SocketMensaje<string> mensajeDesconectar = new SocketMensaje<string> { Comando = "Desconectar"};

            clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeDesconectar));
            clienteStreamWriter.Flush();
            //Se cierra la conexión del cliente
            cliente.Close();
        }
        public static void Cerrar()
        {
            cliente.Close();
        }
    }
}
