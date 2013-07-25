using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
   public class ROL
    {
        private String idRol;

        public String IdRol
        {
            get { return idRol; }
            set { idRol = value; }
        }
       private String Titulo;

       public String Titulo1
       {
           get { return Titulo; }
           set { Titulo = value; }
       }
       private int estado;

       public int Estado
       {
           get { return estado; }
           set { estado = value; }
       }

       public List<Rol_Privilegio> privilegios = new List<Rol_Privilegio>();
    }
}
