using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
    public class Area
    {
        private String idArea;

        public String IdArea
        {
            get { return idArea; }
            set { idArea = value; }
        }
        private String nombre;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private String siglas;

        public String Siglas
        {
            get { return siglas; }
            set { siglas = value; }
        }
        private Persona persona;

        public Persona Persona
        {
            get { return persona; }
            set { persona = value; }
        }
        private String direccion;

        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
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

    }
}
