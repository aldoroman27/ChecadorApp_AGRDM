using Npgsql.TypeMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChecadorApp_AGRDM.Entidades
{
    public class AsistenciaDiaria
    {
        public int ZkUserId { get; set; }
        public string NoEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Turno { get; set; }
        public DateTime Fecha { get; set; }

        //El signo de interrogación significa que si vino nulo o no
        public TimeSpan? Entrada { get; set; }
        public TimeSpan? SalidaComida {  get; set; }
        public TimeSpan? RegresoComida {  get; set; }
        public TimeSpan? Salida { get; set; }

        public string HorasTrabajadas { get; set; }
        public double RetardoMinutos { get; set; }
        public string Estatus {  get; set; }    
    }
}
