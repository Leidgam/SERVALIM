using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
    public class RegistroBolsa
    {
        RESERVA reserva;

        public RESERVA Reserva
        {
            get { return reserva; }
            set { reserva = value; }
        }
        String persona;

        public String Persona
        {
            get { return persona; }
            set { persona = value; }
        }
        String motivo;

        public String Motivo
        {
            get { return motivo; }
            set { motivo = value; }
        }
        DateTime fechaHora;

        public DateTime FechaHora
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }
        String idUsuario;

        public String IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        TimeSpan hora;

        public TimeSpan Hora
        {
            get { return hora; }
            set { hora = value; }
        }

    }
}
