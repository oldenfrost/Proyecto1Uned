using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* Uned III Cuatrimestre 
 * Eduardo Cespedes miranda 
 * Descripcion: creacion de la capa datos para la conexion con la base de datos 
 * fecha: 14/11/2023
 */

namespace CapaDatos
{
   public class CD_Citas
    {
        private string cadenaConexion;

        public CD_Citas()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["conexionServidor"].ConnectionString;
        }

        public void insertarCitas(Cita cita)
        {
            SqlConnection conexion = null;
            SqlCommand cmd;
            string query;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                query = "INSERT INTO Cita (numero, fec_hor_cita, cod_tip_consulta, id_cliente, id_doctor) VALUES (@numero, @fec_hor_cita, @cod_tip_consulta, @id_cliente, @id_doctor)";
                cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@numero", cita.numero);
                cmd.Parameters.AddWithValue("@fec_hor_cita", cita.fec_hor_cita);
                cmd.Parameters.AddWithValue("@cod_tip_consulta", cita.cod_tip_consulta.numero);
                cmd.Parameters.AddWithValue("@id_cliente", cita.id_cliente.identificacion);
                cmd.Parameters.AddWithValue("@id_doctor", cita.id_doctor.identificacion);
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de SQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public List<Cita> GetCitasList()
        {
            SqlConnection conexion = null;
            SqlCommand cmd;
            SqlDataReader dr = null;
            List<Cita> citaLista = new List<Cita>();
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                string query = @"
SELECT 
    Cita.numero AS NumeroCita, 
    Cita.fec_hor_cita AS FechaCita, 
    Cita.cod_tip_consulta AS CodigoTipoConsulta,
    Tipo_Consulta.descripcion AS DescripcionTipoConsulta,
    Tipo_Consulta.estado AS EstadoTipoConsulta,
    Cliente.identificacion AS IdentificacionCliente,
    Cliente.nombre AS NombreCliente,
    Cliente.apellido1 AS Apellido1Cliente,
    Cliente.apellido2 AS Apellido2Cliente,
    Cliente.fec_nacimiento AS FechaCliente,
    Cliente.genero AS GeneroCliente,
    Cita.id_doctor AS IdentificacionDoctor,
    Doctor.nombre AS NombreDoctor,
    Doctor.apellido1 AS Apellido1Doctor,
    Doctor.apellido2 AS Apellido2Doctor,
    Doctor.estado AS GeneroDoctor
FROM Cita
INNER JOIN Tipo_Consulta ON Cita.cod_tip_consulta = Tipo_Consulta.numero
INNER JOIN Cliente ON Cita.id_cliente = Cliente.identificacion
INNER JOIN Doctor ON Cita.id_doctor = Doctor.identificacion";
                cmd = new SqlCommand(query, conexion);
  
                conexion.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    citaLista.Add(new Cita
                    {
                        numero = Convert.ToInt16(dr["NumeroCita"]),
                        fec_hor_cita = Convert.ToDateTime(dr["FechaCita"]),
                        cod_tip_consulta = new Tipo_Consulta
                        {
                            numero = Convert.ToInt16(dr["CodigoTipoConsulta"]),
                            descripcion = dr["DescripcionTipoConsulta"].ToString(),
                            estado = Convert.ToChar(dr["EstadoTipoConsulta"])
                        },
                        id_cliente = new Cliente
                        {
                            identificacion = Convert.ToInt64(dr["IdentificacionCliente"]),
                            nombre = dr["NombreCliente"].ToString(),
                            apellido1 = dr["Apellido1Cliente"].ToString(),
                            apellido2 = dr["Apellido2Cliente"].ToString(),
                            fec_nacimiento = Convert.ToDateTime(dr["FechaCliente"]),
                            genero = Convert.ToChar(dr["GeneroCliente"])
                        },
                        id_doctor = new Doctor
                        {
                            identificacion = Convert.ToInt64(dr["IdentificacionDoctor"]),
                            nombre = dr["NombreDoctor"].ToString(),
                            apellido1 = dr["Apellido1Doctor"].ToString(),
                            apellido2 = dr["Apellido2Doctor"].ToString(),
                            estado = Convert.ToChar(dr["GeneroDoctor"])
                        }
                    });
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine($"Error de SQL: {ex.Message}");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {

                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }

                if (dr != null && !dr.IsClosed)
                {
                    dr.Close();
                }
            }
            return citaLista;

        }


        public List<Cita> GetCitasClientes()
        {
            SqlConnection conexion = null;
            SqlCommand cmd;
            SqlDataReader dr = null;
            List<Cita> citaLista = new List<Cita>();
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                string query = @"SELECT 
                               MIN(Cita.numero) AS NumeroCita, 
                               MIN(Cita.fec_hor_cita) AS FechaCita, 
                               MIN(Cita.cod_tip_consulta) AS CodigoTipoConsulta,
                               MIN(Tipo_Consulta.descripcion) AS DescripcionTipoConsulta,
                               MIN(Tipo_Consulta.estado) AS EstadoTipoConsulta,
                               Cliente.identificacion AS IdentificacionCliente,
                               MIN(Cliente.nombre) AS NombreCliente,
                               MIN(Cliente.apellido1) AS Apellido1Cliente,
                               MIN(Cliente.apellido2) AS Apellido2Cliente,
                               MIN(Cliente.fec_nacimiento) AS FechaCliente,
                               MIN(Cliente.genero) AS GeneroCliente,
                               MIN(Cita.id_doctor) AS IdentificacionDoctor,
                               MIN(Doctor.nombre) AS NombreDoctor,
                               MIN(Doctor.apellido1) AS Apellido1Doctor,
                               MIN(Doctor.apellido2) AS Apellido2Doctor,
                               MIN(Doctor.estado) AS GeneroDoctor
                               FROM Cita
                               INNER JOIN Tipo_Consulta ON Cita.cod_tip_consulta = Tipo_Consulta.numero
                               INNER JOIN Cliente ON Cita.id_cliente = Cliente.identificacion
                               INNER JOIN Doctor ON Cita.id_doctor = Doctor.identificacion
                               GROUP BY Cliente.identificacion
                               ORDER BY Apellido1Cliente ASC;";
                cmd = new SqlCommand(query, conexion);

                conexion.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    citaLista.Add(new Cita
                    {
                        numero = Convert.ToInt16(dr["NumeroCita"]),
                        fec_hor_cita = Convert.ToDateTime(dr["FechaCita"]),
                        cod_tip_consulta = new Tipo_Consulta
                        {
                            numero = Convert.ToInt16(dr["CodigoTipoConsulta"]),
                            descripcion = dr["DescripcionTipoConsulta"].ToString(),
                            estado = Convert.ToChar(dr["EstadoTipoConsulta"])
                        },
                        id_cliente = new Cliente
                        {
                            identificacion = Convert.ToInt64(dr["IdentificacionCliente"]),
                            nombre = dr["NombreCliente"].ToString(),
                            apellido1 = dr["Apellido1Cliente"].ToString(),
                            apellido2 = dr["Apellido2Cliente"].ToString(),
                            fec_nacimiento = Convert.ToDateTime(dr["FechaCliente"]),
                            genero = Convert.ToChar(dr["GeneroCliente"])
                        },
                        id_doctor = new Doctor
                        {
                            identificacion = Convert.ToInt64(dr["IdentificacionDoctor"]),
                            nombre = dr["NombreDoctor"].ToString(),
                            apellido1 = dr["Apellido1Doctor"].ToString(),
                            apellido2 = dr["Apellido2Doctor"].ToString(),
                            estado = Convert.ToChar(dr["GeneroDoctor"])
                        }
                    });
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine($"Error de SQL: {ex.Message}");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {

                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }

                if (dr != null && !dr.IsClosed)
                {
                    dr.Close();
                }
            }
            return citaLista;

        }


        public List<Cita> GetCitasDoctores()
        {
            SqlConnection conexion = null;
            SqlCommand cmd;
            SqlDataReader dr = null;
            List<Cita> citaLista = new List<Cita>();
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                string query = @"SELECT 
                               MIN(Cita.numero) AS NumeroCita, 
                               MIN(Cita.fec_hor_cita) AS FechaCita, 
                               MIN(Cita.cod_tip_consulta) AS CodigoTipoConsulta,
                               MIN(Tipo_Consulta.descripcion) AS DescripcionTipoConsulta,
                               MIN(Tipo_Consulta.estado) AS EstadoTipoConsulta,
                               MIN(Cliente.identificacion) AS IdentificacionCliente,
                               MIN(Cliente.nombre) AS NombreCliente,
                               MIN(Cliente.apellido1) AS Apellido1Cliente,
                               MIN(Cliente.apellido2) AS Apellido2Cliente,
                               MIN(Cliente.fec_nacimiento) AS FechaCliente,
                               MIN(Cliente.genero) AS GeneroCliente,
                               Cita.id_doctor AS IdentificacionDoctor,
                               MIN(Doctor.nombre) AS NombreDoctor,
                               MIN(Doctor.apellido1) AS Apellido1Doctor,
                               MIN(Doctor.apellido2) AS Apellido2Doctor,
                               MIN(Doctor.estado) AS GeneroDoctor
                               FROM Cita
                               INNER JOIN Tipo_Consulta ON Cita.cod_tip_consulta = Tipo_Consulta.numero
                               INNER JOIN Cliente ON Cita.id_cliente = Cliente.identificacion
                               INNER JOIN Doctor ON Cita.id_doctor = Doctor.identificacion
                               GROUP BY Cita.id_doctor
                               ORDER BY Apellido1Cliente ASC;";
                cmd = new SqlCommand(query, conexion);

                conexion.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    citaLista.Add(new Cita
                    {
                        numero = Convert.ToInt16(dr["NumeroCita"]),
                        fec_hor_cita = Convert.ToDateTime(dr["FechaCita"]),
                        cod_tip_consulta = new Tipo_Consulta
                        {
                            numero = Convert.ToInt16(dr["CodigoTipoConsulta"]),
                            descripcion = dr["DescripcionTipoConsulta"].ToString(),
                            estado = Convert.ToChar(dr["EstadoTipoConsulta"])
                        },
                        id_cliente = new Cliente
                        {
                            identificacion = Convert.ToInt64(dr["IdentificacionCliente"]),
                            nombre = dr["NombreCliente"].ToString(),
                            apellido1 = dr["Apellido1Cliente"].ToString(),
                            apellido2 = dr["Apellido2Cliente"].ToString(),
                            fec_nacimiento = Convert.ToDateTime(dr["FechaCliente"]),
                            genero = Convert.ToChar(dr["GeneroCliente"])
                        },
                        id_doctor = new Doctor
                        {
                            identificacion = Convert.ToInt64(dr["IdentificacionDoctor"]),
                            nombre = dr["NombreDoctor"].ToString(),
                            apellido1 = dr["Apellido1Doctor"].ToString(),
                            apellido2 = dr["Apellido2Doctor"].ToString(),
                            estado = Convert.ToChar(dr["GeneroDoctor"])
                        }
                    });
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine($"Error de SQL: {ex.Message}");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {

                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }

                if (dr != null && !dr.IsClosed)
                {
                    dr.Close();
                }
            }
            return citaLista;

        }

    }
}
