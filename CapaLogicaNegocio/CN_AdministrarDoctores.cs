using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaLogicaNegocio
{
    public class CN_AdministrarDoctores
    {

        private static Doctor[] arrayDoctor = new Doctor[20];
        private List<Doctor> auxListaDoctor = new List<Doctor>();

        public void Registrar(int id, string nombre, string apellido1, string apellido2, char estado)
        {
            Doctor nuevoDoctor = new Doctor
            {
                Identificacion = id,
                Nombre = nombre,
                Apellido1 = apellido1,
                Apellido2 = apellido2,
                Estado = estado
            };

            if (auxListaDoctor.Any(c => c.Identificacion == nuevoDoctor.Identificacion))
            {
                MessageBox.Show("El ID ya existe. Por favor, ingrese un ID único.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("El doctor  Registrado correctamente", "Añadido Correctamente", MessageBoxButtons.OK);
                auxListaDoctor.Add(nuevoDoctor);
            }
            arrayDoctor = auxListaDoctor.ToArray();

        }

        public Doctor[] GetArray()
        {
            return arrayDoctor;
        }

    }
}
