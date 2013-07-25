using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo.Entidades
{
    public class ConsumidorTurno
    {
        
        TURNO turno;

        public TURNO Turno
        {
            get { return turno; }
            set { turno = value; }
        }
        DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        DateTime hora;

        public DateTime Hora
        {
            get { return hora; }
            set { hora = value; }
        }
        
        int estado;

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
