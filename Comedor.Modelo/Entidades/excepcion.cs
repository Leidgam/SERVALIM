using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
   public class excepcion
    {
        String idExcepcion;

        public String IdExcepcion
        {
            get { return idExcepcion; }
            set { idExcepcion = value; }
        }
       RESERVA reserva;

       public RESERVA Reserva
       {
           get { return reserva; }
           set { reserva = value; }
       }
       

       DateTime fecha;

       public DateTime Fecha
       {
           get { return fecha; }
           set { fecha = value; }
       }
       String motivo;

       public String Motivo
       {
           get { return motivo; }
           set { motivo = value; }
       }

       int alternativa;

       public int Alternativa
       {
           get { return alternativa; }
           set { alternativa = value; }
       }
       String idUsuario;

       public String IdUsuario
       {
           get { return idUsuario; }
           set { idUsuario = value; }
       }
       DateTime fechaRegistro;

       public DateTime FechaRegistro
       {
           get { return fechaRegistro; }
           set { fechaRegistro = value; }
       }
       String idUsuarioMod;

       public String IdUsuarioMod
       {
           get { return idUsuarioMod; }
           set { idUsuarioMod = value; }
       }
       DateTime fechaMod;

       public DateTime FechaMod
       {
           get { return fechaMod; }
           set { fechaMod = value; }
       }
       int estado;

       public int Estado
       {
           get { return estado; }
           set { estado = value; }
       }
    }
}
