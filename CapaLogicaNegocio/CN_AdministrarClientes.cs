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
    public class CN_AdministrarClientes
    {
        // atributos

        private List<Cliente> ListaCliente = new List<Cliente>();
        private CD_Clientes d_Cliente = new CD_Clientes();

        public void Registrar(long id, string nombre, string ape1, string ape2, DateTime fecha, char g)
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

            if (existe(id))
            {
                MessageBox.Show("El ID ya existe. Por favor, ingrese un ID único.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (existe(id) == false)
            {
                MessageBox.Show("El cliente fue Registrado correctamente", "Añadido Correctamente", MessageBoxButtons.OK);
                d_Cliente.insertarCliente(nuevoCliente);
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
            d_Cliente.ActualizarTipoConsulta(nuevoCliente);
        }


        public bool existe(long id)
        {
            ListaCliente = d_Cliente.GetClienteList();
            bool existe = false;
            if (ListaCliente.Count == 0)
            {
                existe = false;
            }


            foreach (Cliente cliente in ListaCliente)
            {
                if (cliente.identificacion == id)
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
        public string retornarGenero(long id)
        {

            string descripcion = "";
            foreach (Cliente cliente in ListaCliente)
            {
                if (cliente.identificacion == id)
                {
                    if (cliente.genero == 'F')
                    {
                        descripcion = "Femenino";
                    }
                    else if (cliente.genero == 'M')
                    {
                        descripcion = "Masculino";
                    }
                    else
                    {
                        descripcion = "No Especificado";
                    }

                }

            }
            return descripcion;
        }
        public DateTime retornaFecha(long id)
        {
            DateTime fecha = new DateTime();
            foreach (Cliente cliente in ListaCliente)
            {
                if (cliente.identificacion == id)
                {
                    fecha = cliente.fec_nacimiento;


                }

            }
            return fecha;

        }
        public string retornarNombre(long id)
        {
            string nombre = "";
            foreach (Cliente cliente in ListaCliente)
            {
                if (cliente.identificacion == id)
                {
                    nombre = cliente.nombre;


                }

            }
            return nombre;

        }
        public string retornarApellido1(long id)
        {
            string apellido1 = "";
            foreach (Cliente cliente in ListaCliente)
            {
                if (cliente.identificacion == id)
                {
                    apellido1 = cliente.apellido1;


                }

            }
            return apellido1;

        }
        public string retornarApellido2(long id)
        {
            string apellido2 = "";
            foreach (Cliente cliente in ListaCliente)
            {
                if (cliente.identificacion == id)
                {
                    apellido2 = cliente.apellido2;


                }

            }
            return apellido2;

        }
    }
}
