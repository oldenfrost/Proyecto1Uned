using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
/* Uned III Cuatrimestre 
 * Eduardo Cespedes miranda 
 * Descripcion: actualizacion de la capa de negocios 
 * fecha: 14/11/2023
 */

namespace CapaLogicaNegocio
{
    public class CN_ReporteCliente
    {
      private CD_Citas d_citas= new CD_Citas();
        
        public List<Cita> retornarCita()
        {
            List<Cita> citaLista = new List<Cita>();
            citaLista= d_citas.GetCitasList();
            return citaLista;
        }
        public List<Cita> retornarCitaClientesLista()
        {
            List<Cita> citaLista = new List<Cita>();
            citaLista = d_citas.GetCitasClientes();
            return citaLista;
        }

    }
}
