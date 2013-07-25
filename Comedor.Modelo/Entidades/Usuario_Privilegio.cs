using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
    public class Usuario_Privilegio
    {
        Usuario usuario;

        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        Privilegio privilegio;

        public Privilegio Privilegio
        {
            get { return privilegio; }
            set { privilegio = value; }
        }
    }
}
