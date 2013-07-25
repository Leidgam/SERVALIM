using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo.Auxiliares
{
    public class cambioAsignacion
    {
        //Se define si el cambio es de usuario o rol
        public bool usuario = true;
        public bool rol = false;

        //Variables generales
        public bool agregar;
        public bool quitar;

        public String idRol;

        //Variables de Usuario
        public String idUsuario;

        //Variables de Rol
        public String idPrivilegio;
    }
}
