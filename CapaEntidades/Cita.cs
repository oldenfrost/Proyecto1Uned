using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Cita

    {
        public int Numero { get; set; }
        public DateTime FechaHoraCita { get; set; }
        public TipoConsulta TipoConsulta { get; set; }
        public Cliente Cliente { get; set; }
        public Doctor Doctor { get; set; }
    }
}
