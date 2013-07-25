using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
    public class Grupo
    {
        private String idGrupo;

        public String IdGrupo
        {
            get { return idGrupo; }
            set { idGrupo = value; }
        }

        private String nombre;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private String descripcion;

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private int estado;

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

        public List<Grupo_Turno> turnos = new List<Grupo_Turno>();
        public List<consumidor> consumidores;
    }
}
