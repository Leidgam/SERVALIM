using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
    public class Periodo
    {
        private String idPeriodo;

        public String IdPeriodo
        {
            get { return idPeriodo; }
            set { idPeriodo = value; }
        }
        private String descripcion;

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private DateTime fechaInicio;

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }
        private DateTime fechaFin;

        public DateTime FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }
        private int estado;

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
