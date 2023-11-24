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
        public short numero { get; set; }
        public DateTime fec_hor_cita { get; set; }
        public Tipo_Consulta cod_tip_consulta { get; set; }
        public Cliente id_cliente { get; set; }
        public Doctor id_doctor { get; set; }
    }
}
