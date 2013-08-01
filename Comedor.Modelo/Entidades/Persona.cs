using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Comedor.Modelo
{
   public class Persona
    {
        private String idPersona;

        public String IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }
       private String nombres;

       public String Nombres
       {
           get { return nombres; }
           set { nombres = value; }
       }
       private String paterno;

       public String Paterno
       {
           get { return paterno; }
           set { paterno = value; }
       }
       private String materno;

       public String Materno
       {
           get { return materno; }
           set { materno = value; }
       }
       private int tipoDNI;

       public int TipoDNI
       {
           get { return tipoDNI; }
           set { tipoDNI = value; }
       }
       private String dNI;

       public String DNI
       {
           get { return dNI; }
           set { dNI = value; }
       }
       private DateTime fechaNac;

       public DateTime FechaNac
       {
           get { return fechaNac; }
           set { fechaNac = value; }
       }

       private Pais pais;

       public Pais Pais
       {
           get { return pais; }
           set { pais = value; }
       }

       private Departamento departamento;

       public Departamento Departamento
       {
           get { return departamento; }
           set { departamento = value; }
       }
       private String distrito;

       public String Distrito
       {
           get { return distrito; }
           set { distrito = value; }
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
       public List<Contacto> contacto = new List<Contacto>();

    }
}
