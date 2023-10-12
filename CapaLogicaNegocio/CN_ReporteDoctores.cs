using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public  class CN_ReporteDoctores
    {
        private Cita[] arrayCitas = new Cita[20];
        private Cita[] reporteCitas = new Cita[20];

        public void SetArrya(Cita[] arrayCitas)
        {

            this.arrayCitas = arrayCitas;
        }

        public Cita[] ReporteFechas(int id)
        {
           

            reporteCitas = new Cita[20];
            for (int i = 0; i < arrayCitas.Length; i++)
            {
       
                if (arrayCitas[i].Doctor.Identificacion == id)
                {
                    reporteCitas[i] = arrayCitas[i];
                }

            }

            return reporteCitas;

        }
    }
}
