using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Uned III Cuatrimestre 
 * Eduardo Cespedes miranda 
 * Descripcion: crea la clase
 * fecha: 2/10/2023
 */


namespace CapaEntidades
{
    public class Cita
    {
        public int Numero { get; set; }
        public DateTime FechaHoraCita { get; set; }
        public TipoConsulta TipoConsulta { get; set; }
        public Cliente Cliente { get; set; }
        public Doctor Doctor { get; set; }
    }
}
