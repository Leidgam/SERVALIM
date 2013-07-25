using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
   public class TURNO
    {
        String idTurno;

        public String IdTurno
        {
            get { return idTurno; }
            set { idTurno = value; }
        }
       DIA dia;

       public DIA Dia
       {
           get { return dia; }
           set { dia = value; }
       }

       int item;

       public int Item
       {
           get { return item; }
           set { item = value; }
       }
     
       TimeSpan horaInicio;

       public TimeSpan HoraInicio
       {
           get { return horaInicio; }
           set { horaInicio = value; }
       }
       TimeSpan horaFin;

       public TimeSpan HoraFin
       {
           get { return horaFin; }
           set { horaFin = value; }
       }

       //Desayuno=1, alumerzo=2 o cena=3
       int desAlmCen;

       public int DesAlmCen
       {
           get { return desAlmCen; }
           set { desAlmCen = value; }
       }
       int estado;

       public int Estado
       {
           get { return estado; }
           set { estado = value; }
       }
       private String idUsuario;

       public String IdUsuario
       {
           get { return idUsuario; }
           set { idUsuario = value; }
       }
       private DateTime fechaRegistro;

       public DateTime FechaRegistro
       {
           get { return fechaRegistro; }
           set { fechaRegistro = value; }
       }
       private String idUsuarioMod;

       public String IdUsuarioMod
       {
           get { return idUsuarioMod; }
           set { idUsuarioMod = value; }
       }
       private DateTime fechaMod;

       public DateTime FechaMod
       {
           get { return fechaMod; }
           set { fechaMod = value; }
       }


       //Reservas
       public bool remplazo;
       public TURNO TurnRemplazo;

       public bool bolsa;
    }
}
