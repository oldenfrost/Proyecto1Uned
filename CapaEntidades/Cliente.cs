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
    public class Cliente

    {
        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public char Genero { get; set; }
    }
}
