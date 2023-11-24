using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* Uned III Cuatrimestre 
 * Eduardo Cespedes miranda 
 * Descripcion: actualizacion de la capa de negocios 
 * fecha: 14/11/2023
 */
namespace CapaLogicaNegocio
{
    public class CN_AdministrarDoctores
    {
        //atributos
  
        private List<Doctor> ListaDoctor = new List<Doctor>();
        private CD_Doctores d_Doctores = new CD_Doctores();

        public void Registrar(long id, string nombre, string ape1, string ape2, char e)
        {
            Doctor nuevoDoctores = new Doctor
            {
                identificacion = id,
                nombre = nombre,
                apellido1 = ape1,
                apellido2 = ape2,
                estado = e
            };

            if (existe(id))
            {
                MessageBox.Show("El ID ya existe. Por favor, ingrese un ID único.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (existe(id) == false)
            {
                MessageBox.Show("El cliente fue Registrado correctamente", "Añadido Correctamente", MessageBoxButtons.OK);
                d_Doctores.insertarDoctores(nuevoDoctores);
            }




        }
        public void Modificar(long id, string nombre, string ape1, string ape2, DateTime fecha, char g)
        {
            Cliente nuevoCliente = new Cliente
            {
                identificacion = id,
                nombre = nombre,
                apellido1 = ape1,
                apellido2 = ape2,
                fec_nacimiento = fecha,
                genero = g
            };
           // d_Doctores.ActualizarTipoConsulta(nuevoCliente);
        }


        public bool existe(long id)
        {
            ListaDoctor = d_Doctores.GetDoctorList();
            bool existe = false;
            if (ListaDoctor.Count == 0)
            {
                existe = false;
            }


            foreach (Doctor doctor in  ListaDoctor)
            {
                if (doctor.identificacion == id)
                {
                    return true;
                }
                else
                {
                    existe = false;
                }
            }
            return existe;
        }

      

    }
}
