using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
   public class RegistroEntrada
    {
        consumidor consumidor;

        public consumidor Consumidor
        {
            get { return consumidor; }
            set { consumidor = value; }
        }
       TURNO turno;

       public TURNO Turno
       {
           get { return turno; }
           set { turno = value; }
       }
       DateTime fechaHora;

       public DateTime FechaHora
       {
           get { return fechaHora; }
           set { fechaHora = value; }
       }
       int estado;

       public int Estado
       {
           get { return estado; }
           set { estado = value; }
       }
    }
}
