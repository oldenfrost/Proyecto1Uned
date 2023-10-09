using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaLogicaNegocio
{
 
    public class CN_RegistrarFecha
    {
        private static Cita[] arrayCitas=new Cita[20];
        private List<Cita> auxListaCitas = new List<Cita>();


      

        public void Registrar(int numero, DateTime fechaHoraCita, TipoConsulta tipoConsulta, Cliente cliente, Doctor doctor)
        {


        

        Cita Nuevacita = new Cita
            {
                Numero = numero,
                FechaHoraCita= fechaHoraCita,
                TipoConsulta= tipoConsulta,
                Cliente=cliente,
                Doctor=doctor

           
            };

            if (auxListaCitas.Any(c => c.Numero == Nuevacita.Numero))
            {
                MessageBox.Show("El ID ya existe. Por favor, ingrese un ID único.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                auxListaCitas.Add(Nuevacita);
            }
            arrayCitas = auxListaCitas.ToArray();

        }

        public Cita[] GetArray()
        {
            return arrayCitas;
        }

        public DateTime fechaAsignada()
        {
            string[] fechas = new string[arrayCitas.Length];
            int i = 0;
            foreach (Cita cita in arrayCitas.Where(c => c != null))
            {
                fechas[0] = cita.FechaHoraCita.ToString();
                i++;
            }
                

        }
    }
}
