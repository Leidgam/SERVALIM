using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
    public class Grupo_Turno
    {
        private Grupo grupo;

        public Grupo Grupo
        {
            get { return grupo; }
            set { grupo = value; }
        }
        private TURNO turno;

        public TURNO Turno
        {
            get { return turno; }
            set { turno = value; }
        }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        private int tipo;

        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
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
    }
}
