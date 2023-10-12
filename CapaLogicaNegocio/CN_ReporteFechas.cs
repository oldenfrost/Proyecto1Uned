using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class CN_ReporteFechas
    {
        private  Cita[] arrayCitas= new Cita[20];
        private Cita[] reporteCitas = new Cita[20];

        public void SetArrya(Cita[] arrayCitas)
        {
    
            this.arrayCitas= arrayCitas;
        }

        public Cita[] ReporteFechas(string fechaSeleccionada)
        {
            string[] fechaSeprada;

            reporteCitas = new Cita[20];
            for (int i = 0; i < arrayCitas.Length; i++)
            {
                fechaSeprada= arrayCitas[i].FechaHoraCita.ToString().Split(' ');
                if (fechaSeleccionada == fechaSeprada[0])
                {
                    reporteCitas[i] = arrayCitas[i];
                }

            }
           
            return reporteCitas;

        }
    }
}
