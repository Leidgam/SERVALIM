using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
   public class Incidencia
    {
        String idIncidencia;

        public String IdIncidencia
        {
            get { return idIncidencia; }
            set { idIncidencia = value; }
        }
       int gravedad;

       public int Gravedad
       {
           get { return gravedad; }
           set { gravedad = value; }
       }
       String descripcion;

       public String Descripcion
       {
           get { return descripcion; }
           set { descripcion = value; }
       }
       consumidor consumidor;

       public consumidor Consumidor
       {
           get { return consumidor; }
           set { consumidor = value; }
       }
       int tipo;

       public int Tipo
       {
           get { return tipo; }
           set { tipo = value; }
       }
       int estado;

       public int Estado
       {
           get { return estado; }
           set { estado = value; }
       }

       String idTurno;

       public String IdTurno
       {
           get { return idTurno; }
           set { idTurno = value; }
       }
       DateTime fechaHora;

       public DateTime FechaHora
       {
           get { return fechaHora; }
           set { fechaHora = value; }
       }
    }
}
