using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
    public class RESERVA
    {
        String idReserva;

        public String IdReserva
        {
            get { return idReserva; }
            set { idReserva = value; }
        }
        TURNO turno;

        public TURNO Turno
        {
            get { return turno; }
            set { turno = value; }
        }
        consumidor consumidor;

        public consumidor Consumidor
        {
            get { return consumidor; }
            set { consumidor = value; }
        }
        DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        int tipoServicio;

        public int TipoServicio
        {
            get { return tipoServicio; }
            set { tipoServicio = value; }
        }
        int tipo;

        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
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
        int estado;

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        TURNO remplazo;

        public TURNO Remplazo
        {
            get { return remplazo; }
            set { remplazo = value; }
        }
        string motivo;

        public string Motivo
        {
            get { return motivo; }
            set { motivo = value; }
        }

        TimeSpan horabolsa;

        public TimeSpan Horabolsa
        {
            get { return horabolsa; }
            set { horabolsa = value; }
        }

        string idUsuarioConfirmacion;

        public string IdUsuarioConfirmacion
        {
            get { return idUsuarioConfirmacion; }
            set { idUsuarioConfirmacion = value; }
        }

        public bool marcado;
    }
}
