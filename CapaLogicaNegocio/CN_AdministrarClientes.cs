using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaLogicaNegocio
{
    public class CN_AdministrarClientes
    {

        private static Cliente[] arrayCliente = new Cliente[20];
        private List<Cliente> auxListaCliente = new List<Cliente>();
        public void Registrar(int id, string nombre, string apellido1, string apellido2, DateTime fecha, char genero)
        {
            Cliente nuevoCliente = new Cliente
            {
                Identificacion = id,
                Nombre = nombre,
                Apellido1 = apellido1,
                Apellido2=apellido2,
                FechaNacimiento=fecha,
                Genero = genero
            };
          
            if (auxListaCliente.Any(c => c.Identificacion == nuevoCliente.Identificacion))
            {
                MessageBox.Show("El ID ya existe. Por favor, ingrese un ID único.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("El cliente fue Registrado correctamente", "Añadido Correctamente", MessageBoxButtons.OK);
                auxListaCliente.Add(nuevoCliente);
            }
            arrayCliente = auxListaCliente.ToArray();

        }

        public Cliente[] GetArray()
        {
           
            return arrayCliente;
        }


        public string Encontrar(int idBuscar)
        {

 
            
            string datoCompleto = "";
            if (arrayCliente.Any(c => c != null && c.Identificacion == idBuscar))
            {

                var consultaParaActualizar = arrayCliente.FirstOrDefault(c => c.Identificacion == idBuscar);

                datoCompleto = consultaParaActualizar.Genero.ToString();
                datoCompleto += "," + consultaParaActualizar.FechaNacimiento.ToString();
                MessageBox.Show("El dato fue Encontrado correctamente", "Encontrado", MessageBoxButtons.OK);


            }
            else
            {
                MessageBox.Show("El Id no existe por favor verifique en la tabla para visualizar los datos insertados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            return datoCompleto;

        }


        // metodo para modificar
        public void Modificar(int idBuscar, char genero, DateTime fecha)
        {
            if (arrayCliente.Any(c => c != null && c.Identificacion == idBuscar))
            {

                var consultaParaActualizar = arrayCliente.FirstOrDefault(c => c.Identificacion == idBuscar);
                consultaParaActualizar.Genero = genero;
                consultaParaActualizar.FechaNacimiento = fecha;
                MessageBox.Show("El dato fue Actualizado correctamente", "Actualizado", MessageBoxButtons.OK);


            }


        }


    }
}
