using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
    public class Consumidor_Periodo
    {
        consumidor consumidor;

        public consumidor Consumidor
        {
            get { return consumidor; }
            set { consumidor = value; }
        }
        Periodo periodo;

        public Periodo Periodo
        {
            get { return periodo; }
            set { periodo = value; }
        }
        String codigo;

        public String Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        int contrato;

        public int Contrato
        {
            get { return contrato; }
            set { contrato = value; }
        }
        int estado;

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
        List<EAP> escuelas = new List<EAP>();

        private bool autoAsig;

        public bool AutoAsig
        {
            get { return autoAsig; }
            set { autoAsig = value; }
        }
        

    }
}
