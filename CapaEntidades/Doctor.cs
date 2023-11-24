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
    public class Doctor

    {
        public long identificacion { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public char estado { get; set; }
    }
}
