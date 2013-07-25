using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
    public class EAP
    {
        String idEAP;

        public String IdEAP
        {
            get { return idEAP; }
            set { idEAP = value; }
        }
        String nombre;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        String telefono;

        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        Facultad facultad;

        public Facultad Facultad
        {
            get { return facultad; }
            set { facultad = value; }
        }
        int estado;

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        String idUsuario;

        public String IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        DateTime fechaRegistro;

        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }
        String idUsuarioMod;

        public String IdUsuarioMod
        {
            get { return idUsuarioMod; }
            set { idUsuarioMod = value; }
        }
        DateTime fechaMod;

        public DateTime FechaMod
        {
            get { return fechaMod; }
            set { fechaMod = value; }
        }
    }
}
