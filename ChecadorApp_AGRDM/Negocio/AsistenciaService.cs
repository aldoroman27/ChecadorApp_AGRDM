using System;
using System.Collections.Generic;
using ChecadorApp_AGRDM.Datos;
using ChecadorApp_AGRDM.Entidades;

namespace ChecadorApp_AGRDM.Negocio
{
    public class AsistenciaService
    {
        private AsistenciaRepository _repo = new AsistenciaRepository();

        public List<AsistenciaDiaria> ConsultarReporte(DateTime inicio, DateTime fin)
        {
            if(inicio.Date > fin.Date)
            {
                throw new Exception("!La fecha de inicio no puede ser mayor a la fecha de fin!");
            }

            DateTime inicioAjustado = inicio.Date;
            
            DateTime finAjustado = fin.Date.AddDays(1).AddTicks(-1);

            return _repo.ObtenerPorRango(inicioAjustado, finAjustado);
        }
    }
}
