using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Uned III Cuatrimestre 
 * Eduardo Cespedes miranda 
 * Descripcion: clase para verificar si se escribe un entero 
 * fecha: 14/11/2023
 */
namespace CapaPresentacion.clasesAuxiliaries
{
    public class CN_VerificacionId
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
        public long VerificarInt(string id)
        {
            try
            {
             
                long numero = Convert.ToInt64(id);
                return numero;


            }
            catch (FormatException)
            {
   
                return-1;
            }
            catch (OverflowException)
            {
               
                return-1;
            }
           
        }

        public bool VerificarNumero(string id)
        {
            try
            {

                long numero = Convert.ToInt64(id);
                return true;


            }
            catch (FormatException)
            {
                
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Error numero ingresado supera el limite permitido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        public short VerificarShort(string id)
        {
            try
            {

                short numero = Convert.ToInt16(id);
                return numero;


            }
            catch (FormatException)
            {

                return -1;
            }
            catch (OverflowException)
            {
          
                return -1;
            }

        }

    }
}
