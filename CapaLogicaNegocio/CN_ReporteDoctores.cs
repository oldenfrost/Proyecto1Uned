using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Uned III Cuatrimestre 
 * Eduardo Cespedes miranda 
 * Descripcion: actualizacion de la capa de negocios 
 *  fecha: 14/11/2023
 */
namespace CapaLogicaNegocio
{
    public  class CN_ReporteDoctores
    {
        private CD_Citas d_citas = new CD_Citas();

        public List<Cita> retornarCita()
        {
            List<Cita> citaLista = new List<Cita>();
            citaLista = d_citas.GetCitasList();
            return citaLista;
        }
        public List<Cita> retornarCitaDoctoresLista()
        {
            List<Cita> citaLista = new List<Cita>();
            citaLista = d_citas.GetCitasDoctores();
            return citaLista;
        }
    }
}
