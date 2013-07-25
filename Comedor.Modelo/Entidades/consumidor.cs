using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
   public class consumidor
    {
       public bool marcado;

        private String idConsumidor;

        public String IdConsumidor
        {
            get { return idConsumidor; }
            set { idConsumidor = value; }
        }
       private Persona persona;

       public Persona Persona
       {
           get { return persona; }
           set { persona = value; }
       }
       private int contrato;

       public int Contrato
       {
           get { return contrato; }
           set { contrato = value; }
       }
       private int estado;

       public int Estado
       {
           get { return estado; }
           set { estado = value; }
       }


       private EAP eAP;

       public EAP EAP
       {
           get { return eAP; }
           set { eAP = value; }
       }

       private int ciclo;

       public int Ciclo
       {
           get { return ciclo; }
           set { ciclo = value; }
       }

       private Grupo grupo;

       public Grupo Grupo
       {
           get { return grupo; }
           set { grupo = value; }
       }

       private Area area;

       public Area Area
       {
           get { return area; }
           set { area = value; }
       }



       private String codUniversitario;

       public String CodUniversitario
       {
           get { return codUniversitario; }
           set { codUniversitario = value; }
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

       public List<RESERVA> reservas = new List<RESERVA>();
       public List<excepcion> excepciones = new List<excepcion>();
       public List<Consumidor_Periodo> periodos = new List<Consumidor_Periodo>();


       public String codigo(String idPeriodo)
       {
           foreach (Consumidor_Periodo item in this.periodos)
           {
               if (item.Periodo.IdPeriodo.Equals(idPeriodo))
               {
                   return item.Codigo;
               }
           }
           return null;
       }

       public List<Auxiliares.cambioConsumidor> cambios = new List<Auxiliares.cambioConsumidor>();
       public List<Incidencia> incidencias = new List<Incidencia>();
    }
}
