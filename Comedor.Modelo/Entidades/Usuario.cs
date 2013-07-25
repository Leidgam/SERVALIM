using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
   public class Usuario
   {
       #region variables y encapsulamiento
       private String idUsuario;

        public String IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
       private Persona persona;

       public Persona Persona
       {
           get { return persona; }
           set { persona = value; }
       }
       private String login;

       public String Login
       {
           get { return login; }
           set { login = value; }
       }
       private String passw;

       public String Passw
       {
           get { return passw; }
           set { passw = value; }
       }

       private int estado;

       public int Estado
       {
           get { return estado; }
           set { estado = value; }
       }
       private String idUsuarioReg;

       public String IdUsuarioReg
       {
           get { return idUsuarioReg; }
           set { idUsuarioReg = value; }
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

       public List<Usuario_Rol> roles = new List<Usuario_Rol>();
       public List<Usuario_Privilegio> privilegioEspecificos = new List<Usuario_Privilegio>();
       public List<Auxiliares.cambioUsuario> cambios = new List<Auxiliares.cambioUsuario>();

       #endregion

       #region métodos

       public bool validarPrivilegio(String idPrivilegio)
       {
           foreach (Usuario_Rol item in this.roles)
           {
               foreach (Rol_Privilegio priv in item.Rol.privilegios)
               {
                   if (idPrivilegio.Equals(priv.Privilegio.IdPrivilegio))
                   {
                       return true;
                   }
               }
           }

           foreach (Usuario_Privilegio especificos in this.privilegioEspecificos)
           {
               if (especificos.Privilegio.IdPrivilegio.Equals(idPrivilegio))
               {
                   return true;
               }
           }

           return false;
       }

       #endregion
   }
}
