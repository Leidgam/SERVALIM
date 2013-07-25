using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
    public class Contacto
    {
        Persona persona;

        public Persona Persona
        {
            get { return persona; }
            set { persona = value; }
        }
        int tipo;

        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        String descripcion;

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        String valor;

        public String Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        int estado;

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
    }
}
