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
    public class SocketMensaje<T>
    {
        public string Comando { get; set; } = string.Empty;
        public T Entidad { get; set; }
    }
}
