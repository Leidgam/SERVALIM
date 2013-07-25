using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comedor.Modelo;
using System.Data;
using System.Data.SqlClient;


namespace Comedor.Control
{
   public class m_Excepcion
    {
        conexion conexion = new conexion();

        public List<excepcion> getExcXConsumidor(String idConsumidor)
        {
            List<excepcion> excepciones = new List<excepcion>();
            // Create a String to hold the query.
            string query = "SELECT        Excepcion.IdExcepcion, RESERVA.IdReserva, TURNO.IdTurno, DIA.IdDia, DIA.nombre, DIA.estado, EVENTO.IdEvento, EVENTO.nombre AS Expr1, EVENTO.estado AS Expr2, TURNO.HoraInicio, TURNO.HoraFin, TURNO.IdTurnoRemplazo, TURNO.principal, TURNO.estado AS Expr3,                          RESERVA.IdConsumidor, RESERVA.fecha, RESERVA.tipoServicio, RESERVA.tipo, RESERVA.estado AS Expr4, Excepcion.fecha AS Expr5, Excepcion.motivo,                          Excepcion.Alternativa, Excepcion.estado AS Expr6, Excepcion.IdTurno AS Expr7 FROM            Excepcion INNER JOIN                          RESERVA ON Excepcion.IdReserva = RESERVA.IdReserva INNER JOIN                          TURNO ON RESERVA.IdTurno = TURNO.IdTurno INNER JOIN                          DIA ON TURNO.IdDia = DIA.IdDia INNER JOIN                          EVENTO ON TURNO.IdEvento = EVENTO.IdEvento WHERE        (RESERVA.IdConsumidor = N'" + idConsumidor + "') AND (RESERVA.estado = 1)";

            // Create a SqlCommand object and pass the constructor the connection string and the query string.
            SqlCommand queryCommand = new SqlCommand(query, conexion.get());

            // Use the above SqlCommand object to create a SqlDataReader object.
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();

            // Create a DataTable object to hold all the data returned by the query.
            DataTable dataTable = new DataTable();

            // Use the DataTable.Load(SqlDataReader) function to put the results of the query into a DataTable.
            dataTable.Load(queryCommandReader);

            foreach (DataRow item in dataTable.Rows)
            {
                excepcion e = new excepcion();
                e.IdExcepcion = item[0].ToString();
                e.Reserva = new RESERVA();
                e.Reserva.IdReserva = item[1].ToString();
                e.Reserva.Turno = new TURNO();
                e.Reserva.Turno.IdTurno = item[2].ToString();
                e.Reserva.Turno.Dia = new DIA();
                e.Reserva.Turno.Dia.IdDia = item[3].ToString();
                e.Reserva.Turno.Dia.Nombre = item[4].ToString();
                e.Reserva.Turno.Dia.Estado = int.Parse(item[5].ToString());

                e.Reserva.Turno.Estado = int.Parse(item[13].ToString());
                e.Reserva.Consumidor = new consumidor();
                e.Reserva.Consumidor.IdConsumidor = item[14].ToString();
                e.Reserva.Fecha = DateTime.Parse(item[15].ToString());
                e.Reserva.TipoServicio = int.Parse(item[16].ToString());
                e.Reserva.Tipo = int.Parse(item[17].ToString());
                e.Reserva.Estado = int.Parse(item[18].ToString());
                e.Fecha = DateTime.Parse(item[19].ToString());
                e.Motivo = item[20].ToString();
                e.Alternativa = int.Parse(item[21].ToString());
                e.Estado = int.Parse(item[22].ToString());
                
                excepciones.Add(e);

            }


            return excepciones;
        }

        public void agregarExcepcion(excepcion ex, String idUsuario, String idTurno)
        {
            
            SqlCommand cmdEditReceta = new SqlCommand("agregar_Excepcion", conexion.get());
            cmdEditReceta.CommandType = CommandType.StoredProcedure;
            cmdEditReceta.Parameters.AddWithValue("@IdReserva", ex.Reserva.IdReserva);
            cmdEditReceta.Parameters.AddWithValue("@motivo", ex.Motivo);
            cmdEditReceta.Parameters.AddWithValue("@fecha", ex.Fecha.Date);
            cmdEditReceta.Parameters.AddWithValue("@Alternativa", ex.Alternativa);
            cmdEditReceta.Parameters.AddWithValue("@IdTurno", idTurno);
            cmdEditReceta.Parameters.AddWithValue("@IdUsuario", idUsuario);
            cmdEditReceta.ExecuteNonQuery();
            conexion.get().Close();
        }
    }
}
