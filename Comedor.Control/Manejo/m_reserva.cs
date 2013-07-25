using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comedor.Modelo;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;

namespace Comedor.Control
{
   public class m_reserva
    {
       conexion conexion = new conexion();

       public List<TURNO> getTurnos(String idConsumidor, String idPeriodo)
       {
           conexion.open();
           List<TURNO> turnos = new List<TURNO>();
           string query = "SELECT        TURNO.IdTurno, TURNO.IdDia, TURNO.Item, TURNO.HoraInicio, TURNO.HoraFin, TURNO.DesAlmCen, DIA.nombre FROM CONSUMIDOR INNER JOIN                         CONSUMIDOR_PERIODO ON CONSUMIDOR.IdConsumidor = CONSUMIDOR_PERIODO.IdConsumidor INNER JOIN                         PERIODO ON CONSUMIDOR_PERIODO.IdPeriodo = PERIODO.IdPeriodo INNER JOIN                         GRUPO ON CONSUMIDOR.IdGrupo = GRUPO.IdGrupo INNER JOIN                         Grupo_Turno ON GRUPO.IdGrupo = Grupo_Turno.IdGrupo INNER JOIN                         TURNO ON Grupo_Turno.IdTurno = TURNO.IdTurno INNER JOIN                         DIA ON TURNO.IdDia = DIA.IdDia WHERE        (CONSUMIDOR.estado <> 0) AND (PERIODO.estado <> 0) AND (CONSUMIDOR_PERIODO.estado <> 0) AND (GRUPO.estado <> 0) AND (Grupo_Turno.estado <> 0) AND                          (TURNO.estado <> 0) AND (CONSUMIDOR.IdConsumidor = N'"+idConsumidor+"') AND (PERIODO.IdPeriodo = N'"+idPeriodo+"') AND (DIA.estado <> 0)";
           SqlCommand queryCommand = new SqlCommand(query, conexion.get());
           SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
           DataTable dataTable = new DataTable();
           dataTable.Load(queryCommandReader);
           
           foreach (DataRow item in dataTable.Rows)
           {
               TURNO turno = new TURNO();
               turno.IdTurno = item[0].ToString();
               turno.Dia = new DIA();
               turno.Dia.IdDia = item[1].ToString();
               turno.Item = int.Parse(item[2].ToString());
               turno.HoraInicio = TimeSpan.Parse(item[3].ToString());
               turno.HoraFin = TimeSpan.Parse(item[4].ToString());
               turno.DesAlmCen = int.Parse(item[5].ToString());
               turno.Dia.Nombre = item[6].ToString();
               turnos.Add(turno);
           }
           
           List<RESERVA> reservas = new List<RESERVA>();
           string query2 = "SELECT        RESERVA.IdReserva, RESERVA.IdTurno, RESERVA.IdConsumidor, RESERVA.tipoServicio, RESERVA.tipo, TURNO.IdTurno AS Expr1, TURNO.Item, TURNO.HoraInicio,                          TURNO.HoraFin, TURNO.DesAlmCen, TURNO.estado, DIA.IdDia, DIA.nombre FROM            RESERVA INNER JOIN                         TURNO ON RESERVA.IdTurnoRemplazo = TURNO.IdTurno INNER JOIN                         DIA ON TURNO.IdDia = DIA.IdDia WHERE        (RESERVA.estado <> 0) AND (TURNO.estado <> 0) AND (DIA.estado <> 0) AND (RESERVA.IdConsumidor = N'"+idConsumidor+"')";
           SqlCommand queryCommand2 = new SqlCommand(query2, conexion.get());
           SqlDataReader queryCommandReader2 = queryCommand2.ExecuteReader();
           DataTable dataTable2 = new DataTable();
           dataTable2.Load(queryCommandReader2);
           conexion.close();
           
           foreach (DataRow item in dataTable2.Rows)
           {
               RESERVA r = new RESERVA();
               r.IdReserva = item[0].ToString();
               r.Turno = new TURNO();
               r.Turno.IdTurno = item[1].ToString();
               r.Consumidor = new consumidor();
               r.Consumidor.IdConsumidor = item[2].ToString();
               r.TipoServicio = int.Parse(item[3].ToString());
               r.Tipo = int.Parse(item[4].ToString());
               r.Remplazo = new TURNO();
               r.Remplazo.IdTurno = item[5].ToString();
               r.Remplazo.Item = int.Parse(item[6].ToString());
               r.Remplazo.HoraInicio = TimeSpan.Parse(item[7].ToString());
               r.Remplazo.HoraFin = TimeSpan.Parse(item[8].ToString());
               r.Remplazo.DesAlmCen = int.Parse(item[9].ToString());
               r.Remplazo.Estado = int.Parse(item[10].ToString());
               r.Remplazo.Dia = new DIA();
               r.Remplazo.Dia.IdDia = item[11].ToString();
               r.Remplazo.Dia.Nombre = item[12].ToString();

               reservas.Add(r);
           }
           foreach (RESERVA item in reservas)
           {
               foreach (TURNO turn in turnos)
               {
                   if (item.Turno.IdTurno.Equals(turn.IdTurno))
                   {
                       turn.TurnRemplazo = item.Remplazo;
                       turn.remplazo = true;
                       if (item.Tipo == 1) { turn.bolsa = false; } else { turn.bolsa = true; }
                   }
               }
           }
           
           return turnos;
       }

       public void confirmar(List<RESERVA> reservas)
       {
           String ids = "";
           foreach (RESERVA item in reservas) { if (item.IdReserva != reservas[0].IdReserva) { ids += " or idReserva='" + item.IdReserva + "'"; } }

           string query2 = "UPDATE RESERVA SET IdUsuarioConfirmacion='" + reservas[0].IdUsuarioConfirmacion + "' , IdUsuarioMod='" + reservas[0].IdUsuarioConfirmacion + "' , fechaMod=GETDATE() WHERE IdReserva='" + reservas[0].IdReserva + "' " + ids;

           conexion.open();
           SqlCommand queryCommand2 = new SqlCommand(query2, conexion.get());
           queryCommand2.ExecuteNonQuery();
           conexion.close();
       }

       public List<RESERVA> porConfirmar(String idUsuario)
       {
           conexion.open();
           List<RESERVA> reservas = new List<RESERVA>();
           // Create a String to hold the query.
           string query = "SELECT        Persona.PrimerNombre, Persona.SegundoNombre, Persona.Apellidos, RESERVA.tipoServicio, RESERVA.tipo, RESERVA.fecha, RESERVA.Motivo, Area.IdArea,                          Area.Nombre AS Expr1, RESERVA.IdReserva, RESERVA.IdTurnoRemplazo, RESERVA.HoraBolsa, TURNO.DesAlmCen, DIA.nombre FROM            Area INNER JOIN                         RESERVA INNER JOIN                         CONSUMIDOR ON RESERVA.IdConsumidor = CONSUMIDOR.IdConsumidor INNER JOIN                         Persona ON CONSUMIDOR.IdPersona = Persona.IdPersona ON Area.IdArea = CONSUMIDOR.IdArea INNER JOIN                         TURNO ON RESERVA.IdTurno = TURNO.IdTurno INNER JOIN                         DIA ON TURNO.IdDia = DIA.IdDia INNER JOIN                         Persona_Area ON Area.IdArea = Persona_Area.IdArea INNER JOIN                         Persona AS Persona_1 ON Persona_Area.IdPersona = Persona_1.IdPersona INNER JOIN                         USUARIO ON Persona_1.IdPersona = USUARIO.IdPersona WHERE        (CONSUMIDOR.estado <> 0) AND (RESERVA.estado <> 0) AND (RESERVA.estado <> 2) AND (RESERVA.IdUsuarioConfirmacion IS NULL) AND (RESERVA.tipo = 2) AND                          (USUARIO.IdUsuario = N'" + idUsuario + "')";

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
               RESERVA r = new RESERVA();
               r.Consumidor = new consumidor();
               r.Consumidor.Persona = new Persona();
               r.Consumidor.Persona.PrimerNombre = item[0].ToString();
               r.Consumidor.Persona.SegundoNombre = item[1].ToString();
               r.Consumidor.Persona.Apellidos = item[2].ToString();
               r.TipoServicio = int.Parse(item[3].ToString());
               r.Tipo = int.Parse(item[4].ToString());
               r.Fecha = DateTime.Parse(item[5].ToString());
               r.Motivo = item[6].ToString();
               r.Consumidor.Area = new Area();
               r.Consumidor.Area.IdArea = item[7].ToString();
               r.Consumidor.Area.Nombre = item[8].ToString();
               r.IdReserva = item[9].ToString();
               r.Remplazo = new TURNO();
               r.Remplazo.IdTurno = item[10].ToString();
               if (item[11] == null || item[11].ToString().Equals("")) { r.Horabolsa = new TimeSpan(); }
               else
               {
                   r.Horabolsa = TimeSpan.Parse(item[11].ToString());
               }
               r.Turno = new TURNO();
               r.Turno.DesAlmCen = int.Parse(item[12].ToString());
               r.Turno.Dia = new DIA();
               r.Turno.Dia.Nombre = item[13].ToString();

               if (r.Remplazo.IdTurno.Equals("") == false && r.Remplazo.IdTurno != null)
               {
                   string query2 = "SELECT HoraInicio, HoraFin FROM TURNO WHERE (IdTurno = N'" + r.Remplazo.IdTurno + "')";

                   SqlCommand queryCommand2 = new SqlCommand(query2, conexion.get());
                   SqlDataReader queryCommandReader2 = queryCommand2.ExecuteReader();
                   DataTable dataTable2 = new DataTable();
                   dataTable2.Load(queryCommandReader2);

                   foreach (DataRow item2 in dataTable2.Rows)
                   {
                       r.Remplazo.HoraInicio = TimeSpan.Parse(item2[0].ToString());
                       r.Remplazo.HoraFin = TimeSpan.Parse(item2[1].ToString());
                   }
               }


               reservas.Add(r);
           }

           conexion.close();
           return reservas;
       }

       public List<RESERVA> porConfirmar()
       {
           conexion.open();
           List<RESERVA> reservas = new List<RESERVA>();
           // Create a String to hold the query.
           string query = "SELECT        Persona.PrimerNombre, Persona.SegundoNombre, Persona.Apellidos, RESERVA.tipoServicio, RESERVA.tipo, RESERVA.fecha, RESERVA.Motivo, Area.IdArea,                          Area.Nombre AS Expr1, RESERVA.IdReserva, RESERVA.IdTurnoRemplazo, RESERVA.HoraBolsa, TURNO.DesAlmCen, DIA.nombre FROM            Area INNER JOIN                         RESERVA INNER JOIN                         CONSUMIDOR ON RESERVA.IdConsumidor = CONSUMIDOR.IdConsumidor INNER JOIN                         Persona ON CONSUMIDOR.IdPersona = Persona.IdPersona ON Area.IdArea = CONSUMIDOR.IdArea INNER JOIN                         TURNO ON RESERVA.IdTurno = TURNO.IdTurno INNER JOIN                         DIA ON TURNO.IdDia = DIA.IdDia WHERE        (CONSUMIDOR.estado <> 0) AND (RESERVA.estado <> 2)  AND (RESERVA.estado <> 0) AND (RESERVA.IdUsuarioConfirmacion IS NULL) AND (RESERVA.tipo = 2)";

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
               RESERVA r = new RESERVA();
               r.Consumidor = new consumidor();
               r.Consumidor.Persona = new Persona();
               r.Consumidor.Persona.PrimerNombre = item[0].ToString();
               r.Consumidor.Persona.SegundoNombre = item[1].ToString();
               r.Consumidor.Persona.Apellidos = item[2].ToString();
               r.TipoServicio = int.Parse(item[3].ToString());
               r.Tipo = int.Parse(item[4].ToString());
               r.Fecha = DateTime.Parse(item[5].ToString());
               r.Motivo = item[6].ToString();
               r.Consumidor.Area = new Area();
               r.Consumidor.Area.IdArea = item[7].ToString();
               r.Consumidor.Area.Nombre = item[8].ToString();
               r.IdReserva = item[9].ToString();
               r.Remplazo = new TURNO();
               r.Remplazo.IdTurno = item[10].ToString();
               if (item[11] == null || item[11].ToString().Equals("")) { r.Horabolsa = new TimeSpan(); }
               else
               {
                   r.Horabolsa = TimeSpan.Parse(item[11].ToString());
               }
               r.Turno = new TURNO();
               r.Turno.DesAlmCen = int.Parse(item[12].ToString());
               r.Turno.Dia = new DIA();
               r.Turno.Dia.Nombre = item[13].ToString();

               if (r.Remplazo.IdTurno.Equals("") == false && r.Remplazo.IdTurno != null)
               {
                   string query2 = "SELECT HoraInicio, HoraFin FROM TURNO WHERE (IdTurno = N'" + r.Remplazo.IdTurno + "')";

                   SqlCommand queryCommand2 = new SqlCommand(query2, conexion.get());
                   SqlDataReader queryCommandReader2 = queryCommand2.ExecuteReader();
                   DataTable dataTable2 = new DataTable();
                   dataTable2.Load(queryCommandReader2);

                   foreach (DataRow item2 in dataTable2.Rows)
                   {
                       r.Remplazo.HoraInicio = TimeSpan.Parse(item2[0].ToString());
                       r.Remplazo.HoraFin = TimeSpan.Parse(item2[1].ToString());
                   }
               }



               reservas.Add(r);
           }
           conexion.close();

           return reservas;
       }

       public void cancelar(String idReserva)
       {
           string query2 = "UPDATE Reserva SET ESTADO=2 WHERE IdReserva='" + idReserva + "'";


           SqlCommand queryCommand2 = new SqlCommand(query2, conexion.get());

           queryCommand2.ExecuteNonQuery();
       }

       public void rechazar(String idReserva, String Motivo, String idUsuario)
       {
           conexion.open();
           string query2 = "UPDATE Reserva SET ESTADO=2, MotivoRechazo='"+Motivo+"', idUsuarioMod='"+idUsuario+"', fechaMod=GETDATE() WHERE IdReserva='" + idReserva + "'";
           SqlCommand queryCommand2 = new SqlCommand(query2, conexion.get());
           queryCommand2.ExecuteNonQuery();
           conexion.close();
       }

       public void agregarReserva(RESERVA r, String idUsuario)
       {
           SqlCommand cmdEditReceta = new SqlCommand("agregar_Reserva", conexion.get());
           cmdEditReceta.CommandType = CommandType.StoredProcedure;
           cmdEditReceta.Parameters.AddWithValue("@IdTurno", r.Turno.IdTurno);
           cmdEditReceta.Parameters.AddWithValue("@IdConsumidor", r.Consumidor.IdConsumidor);
           cmdEditReceta.Parameters.AddWithValue("@fecha", r.Fecha);
           cmdEditReceta.Parameters.AddWithValue("@tipoServicio", r.TipoServicio);
           cmdEditReceta.Parameters.AddWithValue("@tipo", r.Tipo);
           cmdEditReceta.Parameters.AddWithValue("@IdUsuario", idUsuario);
           cmdEditReceta.ExecuteNonQuery();
           conexion.get().Close();
       }

       public RESERVA getReserva(String idReserva)
       {
           RESERVA r = new RESERVA();
           // Create a String to hold the query.
           string query = "SELECT        RESERVA.IdReserva, TURNO.IdTurno, DIA.IdDia, DIA.nombre, DIA.estado, EVENTO.IdEvento, EVENTO.nombre AS Expr1, EVENTO.estado AS Expr2,                          TURNO.HoraInicio, TURNO.HoraFin, TURNO.IdTurnoRemplazo, TURNO.estado AS Expr3, RESERVA.fecha, RESERVA.tipoServicio, RESERVA.tipo,                          RESERVA.estado AS Expr4 FROM            RESERVA INNER JOIN                          TURNO ON RESERVA.IdTurno = TURNO.IdTurno INNER JOIN                          DIA ON TURNO.IdDia = DIA.IdDia INNER JOIN                          EVENTO ON TURNO.IdEvento = EVENTO.IdEvento WHERE        (RESERVA.IdReserva = N'" + idReserva + "') AND (RESERVA.estado = 1)";

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
               
               r.IdReserva = item[0].ToString();
               r.Turno = new TURNO();
               r.Turno.IdTurno = item[1].ToString();
               r.Turno.Dia = new DIA();
               r.Turno.Dia.IdDia = item[2].ToString();
               r.Turno.Dia.Nombre = item[3].ToString();
               r.Turno.Dia.Estado = int.Parse(item[4].ToString());

               r.Turno.Estado = int.Parse(item[11].ToString());

               r.TipoServicio = int.Parse(item[13].ToString());
               r.Tipo = int.Parse(item[14].ToString());

               if (r.Tipo == 1)
               {
               }
               else if (r.Tipo == 2)
               {
                   r.Fecha = DateTime.Parse(item[12].ToString());
               }
               r.Estado = int.Parse(item[15].ToString());

               

           }


           return r;
       }

       public List<TURNO> TurnoReserva(int tipo, String fecha)
       {
           List<TURNO> turno = new List<TURNO>();
           conexion.open();
           String hora = "";
           if (tipo == 1)
           {
               hora = " and convert(time,horafin)>convert(time,SYSDATETIME())";
           }

           string query = "select IdTurno, IdDia, HoraInicio, HoraFin, DesAlmCen from TURNO where IdDia=(select IdDia from DIA  where nombre=(select LOWER(DATENAME(weekday,'" + fecha + "')))) and Item=2 and estado<>0" + hora;

           SqlCommand queryCommand = new SqlCommand(query, conexion.get());
           SqlDataReader queryCommandReader = queryCommand.ExecuteReader();

           DataTable dataTable = new DataTable();
           dataTable.Load(queryCommandReader);

           foreach (DataRow item in dataTable.Rows)
           {
               TURNO t = new TURNO();

               t.IdTurno = item[0].ToString();
               t.Dia = new DIA();
               t.Dia.IdDia = item[1].ToString();
               t.HoraInicio = TimeSpan.Parse(item[2].ToString());
               t.HoraFin = TimeSpan.Parse(item[3].ToString());
               t.DesAlmCen = int.Parse(item[4].ToString());

               turno.Add(t);
           }
           conexion.close();
           return turno;
       }

       public int RegistrarReserva(String idconsumidor, String idturno, String fecha, int tiposervicio, String idusuario, String Motivo)
       {
           conexion.open();
           int valor;
           SqlDataAdapter cmdAdd = new SqlDataAdapter("agregar_Reserva", conexion.get());
           cmdAdd.SelectCommand.CommandType = CommandType.StoredProcedure;

           cmdAdd.SelectCommand.Parameters.AddWithValue("@IdConsumidor", idconsumidor);
           cmdAdd.SelectCommand.Parameters.AddWithValue("@IdTurno", idturno);
           cmdAdd.SelectCommand.Parameters.AddWithValue("@Fecha", DateTime.Parse(fecha));
           cmdAdd.SelectCommand.Parameters.AddWithValue("@tiposervico", tiposervicio);
           cmdAdd.SelectCommand.Parameters.AddWithValue("@IdUsuario", idusuario);
           cmdAdd.SelectCommand.Parameters.AddWithValue("@Motivo", Motivo);

           DataTable dt = new DataTable();
           cmdAdd.Fill(dt);

           DataRow row = dt.Rows[0];
           valor = int.Parse(row["valor"].ToString());

           return valor;
       }

       public List<RESERVA> rptReservas(bool unica, DateTime desde, DateTime hasta, bool desayuno, bool almuerzo, bool cena, bool presencial, bool Bolsa, bool permanente, bool ocacional, String idGrupo, String idArea, String IdEAP)
       {
           conexion.open();
           List<RESERVA> reservas = new List<RESERVA>();


           //RESERVAS OCACIONALES
           if (ocacional)
           {
               String whereDate = "";
               if (unica) { whereDate = "AND (RESERVA.fecha=CONVERT(DATE,'" + desde.ToString("dd/MM/yyyy") + "'))"; } else { whereDate = " and (RESERVA.fecha>=CONVERT(DATE,'" + desde.ToString("dd/MM/yyyy") + "') and RESERVA.fecha<=CONVERT(DATE,'" + hasta.ToString("dd/MM/yyyy") + "'))"; }

               String whereDes = "";
               String whereAlm = "";
               String whereCena = "";

               String whereDAC = "AND ((TURNO.DesAlmCen <> 1) OR (TURNO.DesAlmCen = 2) OR (TURNO.DesAlmCen <>3))";

               if (desayuno) { } else { whereDes = " AND (TURNO.DesAlmCen <> 1)"; }
               if (almuerzo) { } else { whereAlm = " AND (TURNO.DesAlmCen <> 2)"; }
               if (cena) { } else { whereCena = " AND (TURNO.DesAlmCen <> 3)"; }

               String wherePresencial = "";
               String whereBolsa = "";

               if (presencial) { } else { wherePresencial = " AND (RESERVA.tipoServicio <> 1)"; }
               if (Bolsa) { } else { whereBolsa = " AND (RESERVA.tipoServicio <> 2)"; }

               String whereIdGrupo = "";
               String whereIdArea = "";
               String whereIdEAP = "";

               if (idGrupo != "0") { whereIdGrupo = " AND (GRUPO.IdGrupo = N'" + idGrupo + "')"; }
               if (idArea != "0") { whereIdArea = " AND (Area.IdArea = N'" + idArea + "')"; }
               if (IdEAP != "0") { whereIdEAP = " AND (EAP.IdEAP = N'" + IdEAP + "')"; }

               // Query ocacionales
               string query = "SELECT RESERVA.IdReserva, RESERVA.IdTurno, RESERVA.IdTurnoRemplazo, CONSUMIDOR.IdConsumidor, Persona.IdPersona, Persona.PrimerNombre, Persona.SegundoNombre, Persona.Apellidos, RESERVA.fecha, RESERVA.tipoServicio, RESERVA.tipo, RESERVA.IdUsuarioConfirmacion, RESERVA.Motivo, RESERVA.HoraBolsa, Area.IdArea, Area.Nombre, EAP.IdEAP, EAP.Nombre AS Expr1, GRUPO.IdGrupo, GRUPO.Nombre AS Expr2, TURNO.DesAlmCen, DIA.nombre AS Expr3 FROM RESERVA INNER JOIN CONSUMIDOR ON RESERVA.IdConsumidor = CONSUMIDOR.IdConsumidor INNER JOIN Persona ON CONSUMIDOR.IdPersona = Persona.IdPersona INNER JOIN Area ON CONSUMIDOR.IdArea = Area.IdArea INNER JOIN GRUPO ON CONSUMIDOR.IdGrupo = GRUPO.IdGrupo INNER JOIN EAP ON CONSUMIDOR.IdEAP = EAP.IdEAP INNER JOIN TURNO ON RESERVA.IdTurno = TURNO.IdTurno INNER JOIN DIA ON TURNO.IdDia = DIA.IdDia WHERE (RESERVA.estado <> 0) AND (RESERVA.estado <> 2)  AND (Area.estado <> 0) AND (EAP.estado <> 0) AND (GRUPO.estado <> 0) AND (CONSUMIDOR.estado <> 0) AND (RESERVA.IdUsuarioConfirmacion IS NOT NULL) AND (RESERVA.tipo = 2) AND (TURNO.estado <> 0) AND (DIA.estado <> 0) " + whereDate + whereDes + whereAlm + whereCena + wherePresencial + whereBolsa + whereIdGrupo + whereIdArea + whereIdEAP;

               SqlCommand queryCommand = new SqlCommand(query, conexion.get());
               SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
               DataTable dataTable = new DataTable();
               dataTable.Load(queryCommandReader);

               foreach (DataRow item in dataTable.Rows)
               {
                   RESERVA r = new RESERVA();
                   r.IdReserva = item[0].ToString();
                   r.Turno = new TURNO();
                   r.Turno.IdTurno = item[1].ToString();
                   r.Remplazo = new TURNO();
                   r.Remplazo.IdTurno = item[2].ToString();
                   r.Consumidor = new consumidor();
                   r.Consumidor.IdConsumidor = item[3].ToString();
                   r.Consumidor.Persona = new Persona();
                   r.Consumidor.Persona.IdPersona = item[4].ToString();
                   r.Consumidor.Persona.PrimerNombre = item[5].ToString();
                   r.Consumidor.Persona.SegundoNombre = item[6].ToString();
                   r.Consumidor.Persona.Apellidos = item[7].ToString();
                   r.Fecha = DateTime.Parse(item[8].ToString());
                   r.TipoServicio = int.Parse(item[9].ToString());
                   r.Tipo = int.Parse(item[10].ToString());
                   r.IdUsuarioConfirmacion = item[11].ToString();
                   r.Motivo = item[12].ToString();
                   if (item[13].ToString().Equals("") || item[13] == null) { r.Horabolsa = new TimeSpan(); }
                   else
                   {
                       r.Horabolsa = TimeSpan.Parse(item[13].ToString());
                   }
                   r.Consumidor.Grupo = new Grupo();
                   r.Consumidor.Grupo.IdGrupo = item[18].ToString();
                   r.Consumidor.Grupo.Nombre = item[19].ToString();
                   r.Turno.DesAlmCen = int.Parse(item[20].ToString());
                   r.Turno.Dia = new DIA();
                   r.Turno.Dia.Nombre = item[21].ToString();

                   if (r.Remplazo.IdTurno.Equals("") == false && r.Remplazo.IdTurno != null)
                   {
                       string query2 = "SELECT HoraInicio, HoraFin FROM TURNO WHERE (IdTurno = N'" + r.Remplazo.IdTurno + "')";

                       SqlCommand queryCommand2 = new SqlCommand(query2, conexion.get());
                       SqlDataReader queryCommandReader2 = queryCommand2.ExecuteReader();
                       DataTable dataTable2 = new DataTable();
                       dataTable2.Load(queryCommandReader2);

                       foreach (DataRow item2 in dataTable2.Rows)
                       {
                           r.Remplazo.HoraInicio = TimeSpan.Parse(item2[0].ToString());
                           r.Remplazo.HoraFin = TimeSpan.Parse(item2[1].ToString());
                       }
                   }

                   reservas.Add(r);
               }
           }
           if (permanente)
           {
               //RESERVAS PERMANENTES
               List<DateTime> dias = new List<DateTime>();
               List<RESERVA> permanentes = new List<RESERVA>();
               if (unica)
               {
                   dias.Add(desde);
               }
               else
               {
                   DateTime corredor = desde;
                   while (corredor <= hasta)
                   {
                       dias.Add(corredor);
                       corredor = corredor.AddDays(1);
                   }
               }
               String whereDia = " AND (DIA.nombre = N'" + dias[0].ToString("dddd", new CultureInfo("es-ES")) + "'";
               foreach (DateTime item in dias)
               {
                   if (item != dias[0])
                   {
                       whereDia += " OR DIA.nombre = N'" + item.ToString("dddd", new CultureInfo("es-ES")) + "' ";
                   }
               }
               whereDia += " )";
               String dia = desde.ToString("dddd", new CultureInfo("es-ES"));

               String whereDes = "";
               String whereAlm = "";
               String whereCena = "";


               if (desayuno) { } else { whereDes = " AND (TURNO.DesAlmCen <> 1)"; }
               if (almuerzo) { } else { whereAlm = " AND (TURNO.DesAlmCen <> 2)"; }
               if (cena) { } else { whereCena = " AND (TURNO.DesAlmCen <> 3)"; }

               String wherePresencial = "";
               String whereBolsa = "";

               if (presencial) { } else { wherePresencial = " AND (RESERVA.tipoServicio <> 1)"; }
               if (Bolsa) { } else { whereBolsa = " AND (RESERVA.tipoServicio <> 2)"; }

               String whereIdGrupo = "";
               String whereIdArea = "";
               String whereIdEAP = "";

               if (idGrupo != "0") { whereIdGrupo = " AND (GRUPO.IdGrupo = N'" + idGrupo + "')"; }
               if (idArea != "0") { whereIdArea = " AND (Area.IdArea = N'" + idArea + "')"; }
               if (IdEAP != "0") { whereIdEAP = " AND (EAP.IdEAP = N'" + IdEAP + "')"; }

               // Query Permanentes
               string query = "SELECT RESERVA.IdReserva, RESERVA.IdTurno, RESERVA.IdTurnoRemplazo, CONSUMIDOR.IdConsumidor, Persona.IdPersona, Persona.PrimerNombre, Persona.SegundoNombre, Persona.Apellidos, RESERVA.fecha, RESERVA.tipoServicio, RESERVA.tipo, RESERVA.IdUsuarioConfirmacion, RESERVA.Motivo, RESERVA.HoraBolsa, Area.IdArea, Area.Nombre, EAP.IdEAP, EAP.Nombre AS Expr1, GRUPO.IdGrupo, GRUPO.Nombre AS Expr2, TURNO.DesAlmCen, DIA.nombre AS Expr3 FROM RESERVA INNER JOIN CONSUMIDOR ON RESERVA.IdConsumidor = CONSUMIDOR.IdConsumidor INNER JOIN Persona ON CONSUMIDOR.IdPersona = Persona.IdPersona INNER JOIN Area ON CONSUMIDOR.IdArea = Area.IdArea INNER JOIN GRUPO ON CONSUMIDOR.IdGrupo = GRUPO.IdGrupo INNER JOIN EAP ON CONSUMIDOR.IdEAP = EAP.IdEAP INNER JOIN TURNO ON RESERVA.IdTurno = TURNO.IdTurno INNER JOIN DIA ON TURNO.IdDia = DIA.IdDia WHERE (RESERVA.estado <> 0) AND (RESERVA.estado <> 2) AND (Area.estado <> 0) AND (EAP.estado <> 0) AND (GRUPO.estado <> 0) AND (CONSUMIDOR.estado <> 0) AND (RESERVA.IdUsuarioConfirmacion IS NOT NULL) AND (RESERVA.tipo = 1) AND (TURNO.estado <> 0) AND (DIA.estado <> 0) AND RESERVA.IdReserva not in (select IdReserva from Excepcion where estado<>0) " + whereDia + whereDes + whereAlm + whereCena + wherePresencial + whereBolsa + whereIdGrupo + whereIdArea + whereIdEAP;


               SqlCommand queryCommand = new SqlCommand(query, conexion.get());
               SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
               DataTable dataTable = new DataTable();
               dataTable.Load(queryCommandReader);

               foreach (DataRow item in dataTable.Rows)
               {
                   RESERVA r = new RESERVA();
                   r.IdReserva = item[0].ToString();
                   r.Turno = new TURNO();
                   r.Turno.IdTurno = item[1].ToString();
                   r.Remplazo = new TURNO();
                   r.Remplazo.IdTurno = item[2].ToString();
                   r.Consumidor = new consumidor();
                   r.Consumidor.IdConsumidor = item[3].ToString();
                   r.Consumidor.Persona = new Persona();
                   r.Consumidor.Persona.IdPersona = item[4].ToString();
                   r.Consumidor.Persona.PrimerNombre = item[5].ToString();
                   r.Consumidor.Persona.SegundoNombre = item[6].ToString();
                   r.Consumidor.Persona.Apellidos = item[7].ToString();
                   r.Fecha = DateTime.Parse(item[8].ToString());
                   r.TipoServicio = int.Parse(item[9].ToString());
                   r.Tipo = int.Parse(item[10].ToString());
                   r.IdUsuarioConfirmacion = item[11].ToString();
                   r.Motivo = item[12].ToString();
                   if (item[13].ToString().Equals("") || item[13] == null) { r.Horabolsa = new TimeSpan(); }
                   else
                   {
                       r.Horabolsa = TimeSpan.Parse(item[13].ToString());
                   }
                   r.Consumidor.Grupo = new Grupo();
                   r.Consumidor.Grupo.IdGrupo = item[18].ToString();
                   r.Consumidor.Grupo.Nombre = item[19].ToString();
                   r.Turno.DesAlmCen = int.Parse(item[20].ToString());
                   r.Turno.Dia = new DIA();
                   r.Turno.Dia.Nombre = item[21].ToString();

                   if (r.Remplazo.IdTurno.Equals("") == false && r.Remplazo.IdTurno != null)
                   {
                       string query2 = "SELECT HoraInicio, HoraFin FROM TURNO WHERE (IdTurno = N'" + r.Remplazo.IdTurno + "')";

                       SqlCommand queryCommand2 = new SqlCommand(query2, conexion.get());
                       SqlDataReader queryCommandReader2 = queryCommand2.ExecuteReader();
                       DataTable dataTable2 = new DataTable();
                       dataTable2.Load(queryCommandReader2);

                       foreach (DataRow item2 in dataTable2.Rows)
                       {
                           r.Remplazo.HoraInicio = TimeSpan.Parse(item2[0].ToString());
                           r.Remplazo.HoraFin = TimeSpan.Parse(item2[1].ToString());
                       }
                   }

                   permanentes.Add(r);
               }
               foreach (DateTime item in dias)
               {
                   foreach (RESERVA res in permanentes)
                   {
                       if (res.Turno.Dia.Nombre.Equals(item.ToString("dddd", new CultureInfo("es-ES"))))
                       {

                           RESERVA rrr = new RESERVA();
                           rrr.IdReserva = res.IdReserva;
                           rrr.Consumidor = res.Consumidor;
                           rrr.Estado = res.Estado;
                           rrr.Fecha = new DateTime(item.Year, item.Month, item.Day);
                           rrr.FechaMod = res.FechaMod;
                           rrr.FechaRegistro = res.FechaRegistro;
                           rrr.Horabolsa = res.Horabolsa;
                           rrr.IdUsuario = res.IdUsuario;
                           rrr.IdUsuarioConfirmacion = res.IdUsuarioConfirmacion;
                           rrr.IdUsuarioMod = res.IdUsuarioMod;
                           rrr.marcado = res.marcado;
                           rrr.Motivo = res.Motivo;
                           rrr.Remplazo = res.Remplazo;
                           rrr.Tipo = res.Tipo;
                           rrr.TipoServicio = res.TipoServicio;
                           rrr.Turno = res.Turno;


                           reservas.Add(rrr);
                       }
                   }
               }

           }


           //Checkear Ingresos
           if (reservas.Count > 0)
           {
               string query3 = "SELECT IdConsumidor, IdTurno, fechaHora FROM RegistroEntrada WHERE ( (IdConsumidor ='"+reservas[0].Consumidor.IdConsumidor+"') AND (IdTurno = N'" + reservas[0].Remplazo.IdTurno + "') AND CONVERT(DATE,fechaHora)=CONVERT(DATE,'" + reservas[0].Fecha.ToString("yyyy-MM-dd") + "')) ";
               foreach (RESERVA item in reservas)
               {
                   if (item != reservas[0])
                   {
                       query3 += " OR ( (IdConsumidor ='" + item.Consumidor.IdConsumidor + "') AND (IdTurno = N'" + item.Remplazo.IdTurno + "') AND CONVERT(DATE,fechaHora)=CONVERT(DATE,'" + item.Fecha.ToString("yyyy-MM-dd") + "'))";
                   }
               }
             
               SqlCommand queryCommand3 = new SqlCommand(query3, conexion.get());
               SqlDataReader queryCommandReader3 = queryCommand3.ExecuteReader();
               DataTable dataTable3 = new DataTable();
               dataTable3.Load(queryCommandReader3);

               foreach (DataRow item in dataTable3.Rows)
               {
     
                   foreach (RESERVA rese in reservas)
                   {
                       if (rese.Consumidor.IdConsumidor == item[0].ToString() && rese.Remplazo.IdTurno
                           ==item[1].ToString() && (rese.Fecha.ToString("dd/MM/yyyy"))==((DateTime.Parse(item[2].ToString()).ToString("dd/MM/yyyy"))))
                       {
                           rese.marcado = true;
                      
                       }
                   }
               }
           }
           conexion.close();
           return reservas;
       }
    }
}
