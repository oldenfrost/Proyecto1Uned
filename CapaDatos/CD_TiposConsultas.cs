using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidades;
using System.Windows.Forms;
/* Uned III Cuatrimestre 
 * Eduardo Cespedes miranda 
 * Descripcion: creacion de la capa datos para la conexion con la base de datos 
 * fecha: 14/11/2023
 */

namespace CapaDatos
{

    public class CD_TiposConsultas
    {
        private string cadenaConexion;
     
        public CD_TiposConsultas() {
            cadenaConexion = ConfigurationManager.ConnectionStrings["conexionServidor"].ConnectionString;
        }

        public void insertarTipoConsulta(Tipo_Consulta tipoConsulta)
        {
            SqlConnection conexion=null;
            SqlCommand cmd;
            string query;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                query = "Insert Into Tipo_Consulta (numero,descripcion, estado) Values(@numero, @descripcion, @estado)";
                cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@numero", tipoConsulta.numero);
                cmd.Parameters.AddWithValue("@descripcion", tipoConsulta.descripcion);
                cmd.Parameters.AddWithValue("@estado", tipoConsulta.estado);
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

        public List<Tipo_Consulta> GetTipoConsultaList()
        {
       
            SqlConnection conexion=null;
            SqlCommand cmd;
            SqlDataReader dr = null;
            List<Tipo_Consulta> tipo_ConsultasLista = new List<Tipo_Consulta>();

            try
            {
                conexion = new SqlConnection(cadenaConexion);

                string query = "SELECT numero, descripcion, estado FROM Tipo_Consulta";

                cmd = new SqlCommand(query, conexion);
                cmd.CommandType = CommandType.Text;

                conexion.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tipo_ConsultasLista.Add(new Tipo_Consulta
                    {
                        numero = Convert.ToInt16(dr["numero"]),
                        descripcion = dr["descripcion"].ToString(),
                        estado = Convert.ToChar(dr["estado"])
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
            return tipo_ConsultasLista;
           
        }


        public void ActualizarTipoConsulta(Tipo_Consulta tipoConsulta)
        {
            SqlConnection conexion = null;
            SqlCommand cmd;

            try
            {
                conexion = new SqlConnection(cadenaConexion);
                string query = "UPDATE Tipo_Consulta SET descripcion = @descripcion, estado = @estado WHERE numero = @numero";
                cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@numero", tipoConsulta.numero);
                cmd.Parameters.AddWithValue("@descripcion", tipoConsulta.descripcion);
                cmd.Parameters.AddWithValue("@estado", tipoConsulta.estado);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    if (error.Number == 2628) // Este número específico está asociado con desbordamiento de longitud de columna VARCHAR
                    {
                        MessageBox.Show ( $"Error: Valor ingresado supera la longitud máxima permitida para la columna", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                        break;
                    }
                }
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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


    }
}
