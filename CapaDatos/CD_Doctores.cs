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
/*  Uned III Cuatrimestre 
 * Eduardo Cespedes miranda 
 * Descripcion: creacion de la capa datos para la conexion con la base de datos 
 * fecha: 14/11/2023
 */

namespace CapaDatos
{
    public class CD_Doctores
    {
        private string cadenaConexion;
        public CD_Doctores()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["conexionServidor"].ConnectionString;
        }

        public void insertarDoctores(Doctor doctor)
        {
            SqlConnection conexion = null;
            SqlCommand cmd;
            string query;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                query = "Insert Into Doctor (identificacion,nombre, apellido1, apellido2, estado) Values(@identificacion, @nombre, @apellido1,@apellido2, @estado )";
                cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@identificacion", doctor.identificacion);
                cmd.Parameters.AddWithValue("@nombre", doctor.nombre);
                cmd.Parameters.AddWithValue("@apellido1", doctor.apellido1);
                cmd.Parameters.AddWithValue("@apellido2", doctor.apellido2);
                cmd.Parameters.AddWithValue("@estado", doctor.estado);
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    if (error.Number == 2628) // Este número específico está asociado con desbordamiento de longitud de cualquier columna
                    {
                        MessageBox.Show($"Error: Valor ingresado supera la longitud máxima permitida para la columna", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                        break;
                    }
                }
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

        public List<Doctor> GetDoctorList()
        {
            SqlConnection conexion = null;
            SqlCommand cmd;
            SqlDataReader dr = null;
            List<Doctor> doctorLista = new List<Doctor>();
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                string query = "SELECT identificacion, nombre,apellido1, apellido2,estado FROM Doctor";
                cmd = new SqlCommand(query, conexion);
                cmd.CommandType = CommandType.Text;
                conexion.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    doctorLista.Add(new Doctor
                    {
                        identificacion = Convert.ToInt64(dr["identificacion"]),
                        nombre = dr["nombre"].ToString(),
                        apellido1 = dr["apellido1"].ToString(),
                        apellido2 = dr["apellido2"].ToString(),
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
            return doctorLista;

        }


       /* public void ActualizarTipoConsulta(Cliente cliente)
        {
            SqlConnection conexion = null;
            SqlCommand cmd;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                string query = "UPDATE Cliente SET genero = @genero, fec_nacimiento = @fec_nacimiento WHERE identificacion = @identificacion";
                cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@identificacion", cliente.identificacion);
                cmd.Parameters.AddWithValue("@genero", cliente.genero);
                cmd.Parameters.AddWithValue("@fec_nacimiento", cliente.fec_nacimiento);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    if (error.Number == 2628) // Este número específico está asociado con desbordamiento de longitud de columna VARCHAR
                    {
                        MessageBox.Show($"Error: Valor ingresado supera la longitud máxima permitida para la columna", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
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
        }*/


    }
}
