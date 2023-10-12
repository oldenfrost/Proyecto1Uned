using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Uned III Cuatrimestre 
 * Eduardo Cespedes miranda 
 * Descripcion: clase para verificar si se escribe un entero 
 * fecha: 12/10/2023
 */
namespace CapaPresentacion.clasesAuxiliaries
{
    public class VerificacionId
    {

        public void idTextKeyPress(object sender, KeyPressEventArgs e, ErrorProvider error)
        {
            // expresion regular
            Regex regex = new Regex("[^0-9]+");
            TextBox textBox = sender as TextBox;
            /* se declara una variable de tipoo textBox sender es el que desencadeno el evento 
             * con el as se realiza la conversion a TextBox para poder usarse en el provider para cualquier
             * textbox que desencadena la accion 
             */
            if (!char.IsControl(e.KeyChar) && regex.IsMatch(e.KeyChar.ToString()))
            {
                error.SetError(textBox, "Por favor, ingrese solo números.");
                e.Handled = true;
            }
            else
            {
                error.SetError(textBox, "");
            }
        }
    }
}
