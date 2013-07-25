using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
   public class DIA
    {
        String idDia;

        public String IdDia
        {
            get { return idDia; }
            set { idDia = value; }
        }
       String nombre;

       public String Nombre
       {
           get { return nombre; }
           set { nombre = value; }
       }
       int estado;

       public int Estado
       {
           get { return estado; }
           set { estado = value; }
       }
    }
}
