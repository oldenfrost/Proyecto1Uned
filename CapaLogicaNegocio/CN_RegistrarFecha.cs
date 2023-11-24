using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* Uned III Cuatrimestre 
 * Eduardo Cespedes miranda 
 * Descripcion: actualizacion de la capa de negocios 
 * fecha: 14/11/2023
 */
namespace CapaLogicaNegocio
{
    public class CN_RegistrarFecha
    {
        //atributos
        private static Cita[] arrayCitas = new Cita[20];
        private static List<Cita> ListaCitas = new List<Cita>();
        private CD_Citas citas = new CD_Citas();
        private CD_Clientes d_Cliente = new CD_Clientes();
        // metodos
        public void Registrar(short numero, DateTime fechaHoraCita, short tipoConsulta, long cliente, long doctor)
        {

            Cita Nuevacita = new Cita
            {
                numero = numero,
                fec_hor_cita = fechaHoraCita,
                cod_tip_consulta = new Tipo_Consulta{ numero= tipoConsulta, descripcion="", estado='X' },
                id_cliente = new Cliente { identificacion= cliente, nombre="", apellido1="",apellido2="", fec_nacimiento= new DateTime(), genero='x'},
                id_doctor = new Doctor { identificacion=doctor, nombre="", apellido1="", apellido2="", estado='x'}
            };

            if (existe(numero))
            {
                MessageBox.Show("El ID ya existe. Por favor, ingrese un ID único.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }
            if (existe(numero) == false)
            {
           
                if(fechaDoctorRegistrado(fechaHoraCita, doctor) == true)
                {
                    MessageBox.Show("La fecha y el doctor ya ha sido ingresado", "Añadido Correctamente", MessageBoxButtons.OK);
                    return;

                }
                else if (fechaMenorCliente(fechaHoraCita, cliente) == true)
                {
                    MessageBox.Show("La fecha ingresada es menor que la fecha de nacimiento del cliente", "Añadido Correctamente", MessageBoxButtons.OK);
                    return;

                }
                else
                {
                    MessageBox.Show("La Cita fue Registrado correctamente", "Añadido Correctamente", MessageBoxButtons.OK);
                    citas.insertarCitas(Nuevacita);
                }


           
            }
       

        }
        public bool existe(long id)
        {
            ListaCitas = citas.GetCitasList();
            bool existe = false;
            if (ListaCitas.Count == 0)
            {
                existe = false;
            }


            foreach (Cita cita in ListaCitas)
            {
                if (cita.numero == id)
                {
                    existe = true;
                }
                else
                {
                    existe = false;
                }
            }
            return existe;
        }
        public bool fechaDoctorRegistrado(DateTime fechaHoraCita, long doctor)
        {
           List<Cita> ListaCitas = new List<Cita>();
            ListaCitas = citas.GetCitasList();
            bool existe = false;
            if (ListaCitas.Count == 0)
            {
                existe = false;
            }


            foreach (Cita cita in ListaCitas)
            {
                if (cita.id_doctor.identificacion == doctor && cita.fec_hor_cita==fechaHoraCita)
                {
                    existe= true;
                }
                else
                {
                    existe=false;
                }
            }
            return existe;
        }

        public bool fechaMenorCliente(DateTime fechaHoraCita, long Cliente)
        {

            List<Cliente> ListaClientes = new List<Cliente>();
            ListaClientes = d_Cliente.GetClienteList();

            bool existe = false;
            if (ListaCitas.Count == 0)
            {
                existe = false;
            }


            foreach (Cliente cliente in ListaClientes)
            {
                if (cliente.fec_nacimiento > fechaHoraCita && cliente.identificacion == Cliente)
                {
                    existe = true;
                }
                else
                {
                    existe = false;
                }
            }
            return existe;
        }
        public bool RegistrarEnElCliente(short numero, DateTime fechaHoraCita, short tipoConsulta, long cliente, long doctor)
        {

            Cita Nuevacita = new Cita
            {
                numero = numero,
                fec_hor_cita = fechaHoraCita,
                cod_tip_consulta = new Tipo_Consulta { numero = tipoConsulta, descripcion = "", estado = 'X' },
                id_cliente = new Cliente { identificacion = cliente, nombre = "", apellido1 = "", apellido2 = "", fec_nacimiento = new DateTime(), genero = 'x' },
                id_doctor = new Doctor { identificacion = doctor, nombre = "", apellido1 = "", apellido2 = "", estado = 'x' }
            };

            if (existe(numero))
            {
            

                return false;

            }
            if (existe(numero) == false)
            {

                if (fechaDoctorRegistrado(fechaHoraCita, doctor) == true)
                {
                    
                    return false;

                }
                else if (fechaMenorCliente(fechaHoraCita, cliente) == true)
                {
                   
                    return false;

                }
                else
                {
                  
                    citas.insertarCitas(Nuevacita);
                    return true;
                }



            }
            return false;


        }

    }
        
}
