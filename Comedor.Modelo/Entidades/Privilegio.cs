using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
    public class Privilegio
    {
        private String idPrivilegio;

        public String IdPrivilegio
        {
            get { return idPrivilegio; }
            set { idPrivilegio = value; }
        }
        private String titulo;

        public String Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        private Privilegio privilegioSup;

        public Privilegio PrivilegioSup
        {
            get { return privilegioSup; }
            set { privilegioSup = value; }
        }
        private int estado;

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
