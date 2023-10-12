using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Uned III Cuatrimestre 
 * Eduardo Cespedes miranda 
 * Descripcion: funcion del menu Registrar consulta
 * fecha: 8/10/2023
 */

namespace CapaLogicaNegocio
{

    public class CN_RegistrarFecha
    {
        private static Cita[] arrayCitas = new Cita[20];
        private static List<Cita> auxListaCitas = new List<Cita>();




        public void Registrar(int numero, DateTime fechaHoraCita, TipoConsulta tipoConsulta, Cliente cliente, Doctor doctor)
        {
           
    



            Cita Nuevacita = new Cita
            {
                Numero = numero,
                FechaHoraCita = fechaHoraCita,
                TipoConsulta = tipoConsulta,
                Cliente = cliente,
                Doctor = doctor


            };

            if (auxListaCitas.Any(c => c.Numero == Nuevacita.Numero))
            {
                MessageBox.Show("El ID ya existe. Por favor, ingrese un ID único.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    
            }
            else
            {
                if(auxListaCitas.Any(c => c.Cliente.Identificacion == Nuevacita.Cliente.Identificacion && c.FechaHoraCita == Nuevacita.FechaHoraCita))
                {
                    MessageBox.Show("El cliente ya fue asignado a esa cita", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
                }
                else if(auxListaCitas.Any(c => c.Doctor.Identificacion == Nuevacita.Doctor.Identificacion && c.FechaHoraCita == Nuevacita.FechaHoraCita))
                {
                    MessageBox.Show("El Doctor ya fue asignado a esa cita", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                }
                else
                {
                    MessageBox.Show("La cita fue registrada correctamente", "Añadido Correctamente", MessageBoxButtons.OK);
                    auxListaCitas.Add(Nuevacita);
                
                }
              
            }
            arrayCitas = auxListaCitas.ToArray();



        }

        public Cita[] GetArray()
        {
            return arrayCitas;
        }
    

       
    }
}
