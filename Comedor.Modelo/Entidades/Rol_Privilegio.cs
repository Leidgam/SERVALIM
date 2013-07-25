using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
    public class Rol_Privilegio
    {
        ROL rol;

        public ROL Rol
        {
            get { return rol; }
            set { rol = value; }
        }
        Privilegio privilegio;

        public Privilegio Privilegio
        {
            get { return privilegio; }
            set { privilegio = value; }
        }
    }
}
