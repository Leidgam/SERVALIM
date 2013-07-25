using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
    public class Facultad
    {
        String idFacultad;

        public String IdFacultad
        {
            get { return idFacultad; }
            set { idFacultad = value; }
        }
        String nombre;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        String abreviatura;

        public String Abreviatura
        {
            get { return abreviatura; }
            set { abreviatura = value; }
        }
        String descripcion;

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
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
        String idusuarioMod;

        public String IdusuarioMod
        {
            get { return idusuarioMod; }
            set { idusuarioMod = value; }
        }
        DateTime fechaMod;

        public DateTime FechaMod
        {
            get { return fechaMod; }
            set { fechaMod = value; }
        }
        public List<EAP> escuelas = new List<EAP>();
    }
}
