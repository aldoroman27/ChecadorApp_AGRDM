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
            if(inicio > fin)
            {
                throw new Exception("!La fecha de inicio no puede ser mayor a la fecha de fin!");
            }
            
            return _repo.ObtenerPorRango(inicio, fin);
        }
    }
}
