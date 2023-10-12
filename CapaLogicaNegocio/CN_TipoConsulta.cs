using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
/* Uned III Cuatrimestre 
 * Eduardo Cespedes miranda 
 * Descripcion: clase para registrar y modificar los tipos de consultas
 * fecha: 6/10/2023
 */


namespace CapaLogicaNegocio
{
    public class CN_TipoConsulta
    {
        // atributos de la clase
        private  List <TipoConsulta> auxListaTiposConsulta=new List<TipoConsulta>();
        private static TipoConsulta[] arrayTipoConsulta=new TipoConsulta[10];
        // metodo para registrar
       public void Registrar( int id, string descripcion, char estado, int tipoConsultasIngresadas)
        {
            TipoConsulta nuevaTipoConsulta= new TipoConsulta { 
            Numero=id,
            Descripcion=descripcion,
            Estado=estado
            };


            if (auxListaTiposConsulta.Any(c => c.Numero == nuevaTipoConsulta.Numero))
            {
                MessageBox.Show("El ID ya existe. Por favor, ingrese un ID único.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("La consulta fue Registrada correctamente", "Añadido Correctamente", MessageBoxButtons.OK);
                auxListaTiposConsulta.Add(nuevaTipoConsulta);
            }
            arrayTipoConsulta = auxListaTiposConsulta.ToArray();
        }

        // metodo get para retornar el array
        public  TipoConsulta[] GetArray()
        {
            return arrayTipoConsulta;
        }
        // metodo para encontrar el dato
        public char Encontrar(int idBuscar)
        {
          
            char estado='n';
            if (arrayTipoConsulta.Any(c => c != null && c.Numero == idBuscar))
            {
                var consultaParaActualizar = arrayTipoConsulta.FirstOrDefault(c =>  c.Numero == idBuscar);
                estado = consultaParaActualizar.Estado;
                MessageBox.Show("El dato fue Encontrado correctamente", "Encontrado", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("El Id no existe por favor verifique en la tabla para visualizar los datos insertados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return estado;
        }
        // metodo para modificar
        public void Modificar(int idBuscar, char estado)
        {
            if (arrayTipoConsulta.Any(c => c != null && c.Numero == idBuscar))
            {
                var consultaParaActualizar = arrayTipoConsulta.FirstOrDefault(c => c.Numero == idBuscar);
                consultaParaActualizar.Estado= estado;
                MessageBox.Show("El dato fue Actualizado correctamente", "Actualizado", MessageBoxButtons.OK);
            }
        }
    }
}
