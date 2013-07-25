using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
    public class Usuario_Rol
    {
        Usuario usuario;

        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        ROL rol;

        public ROL Rol
        {
            get { return rol; }
            set { rol = value; }
        }
    }
}
