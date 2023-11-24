using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaEntidades;
/* Uned III Cuatrimestre 
 * Eduardo Cespedes miranda 
 * Descripcion: mejoras realizadas clase para registrar y modificar los tipos de consultas
 * fecha: 12/11/2023
 */


namespace CapaLogicaNegocio
{
    public class CN_TipoConsulta
    {
        // atributos de la clase
        private  List <Tipo_Consulta> ListaTiposConsulta=new List<Tipo_Consulta>();
        private CD_TiposConsultas d_TiposConsultas = new CD_TiposConsultas();

        // metodo para registrar
       public void Registrar( short id, string descripcion, char estado)
        {
            Tipo_Consulta nuevaTipoConsulta= new Tipo_Consulta { 
            numero=id,
            descripcion=descripcion,
            estado=estado
            };

            if(existe(id))
            {
                MessageBox.Show("El ID ya existe. Por favor, ingrese un ID único.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if(existe(id)==false)
            {
                MessageBox.Show("El Tipo de consulta fue Registrado correctamente", "Añadido Correctamente", MessageBoxButtons.OK);
                d_TiposConsultas.insertarTipoConsulta(nuevaTipoConsulta);
            }




        }
        public void Modificar(short id, string descripcion, char estado)
        {
            Tipo_Consulta nuevaTipoConsulta = new Tipo_Consulta
            {
                numero = id,
                descripcion = descripcion,
                estado = estado
            };
            d_TiposConsultas.ActualizarTipoConsulta(nuevaTipoConsulta);
        }


        public bool existe(short id)
        {
            ListaTiposConsulta = d_TiposConsultas.GetTipoConsultaList();
            bool existe = false;
            if (ListaTiposConsulta.Count == 0)
            {
                existe = false;
            }


            foreach (Tipo_Consulta tipoConsulta in ListaTiposConsulta)
            {
                if (tipoConsulta.numero == id)
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
        public string retornarEstado(short id)
        {
            char estado='A';
            string descripcion="";
            foreach (Tipo_Consulta tipoConsulta in ListaTiposConsulta)
            {
                if (tipoConsulta.numero == id)
                {
                     descripcion = (estado == 'A') ? "Activo" : "Inactivo";
                }
             
            }
            return descripcion;
        }
        public string retornarDescripcion(short id)
        {
            string descripcion = "";
            foreach (Tipo_Consulta tipoConsulta in ListaTiposConsulta)
            {
                if (tipoConsulta.numero == id)
                {
                    descripcion = tipoConsulta.descripcion;
                }

            }
            return descripcion;
        }
    }
}
