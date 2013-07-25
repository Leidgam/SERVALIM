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
    public class m_Turno
    {
        #region conexion
        conexion conexion = new conexion();
        #endregion

        #region BD

        public void crearTurno(TURNO turno)
        {
            conexion.open();

            SqlCommand scmdTurno = new SqlCommand("Crear_Turno", conexion.get());
            scmdTurno.CommandType = CommandType.StoredProcedure;

            scmdTurno.Parameters.AddWithValue("@idDia", turno.Dia.IdDia);
            scmdTurno.Parameters.AddWithValue("@HoraInicio", turno.HoraInicio);
            scmdTurno.Parameters.AddWithValue("@HoraFin", turno.HoraFin);
            scmdTurno.Parameters.AddWithValue("@DesAlmCen", turno.DesAlmCen);
            scmdTurno.Parameters.AddWithValue("@idusuario", turno.IdUsuario);

            scmdTurno.ExecuteNonQuery();
            conexion.close();
        }

        public void ModificarTurno(TURNO turno)
        {
            conexion.open();
            string query = "update Turno set HoraInicio='" + turno.HoraInicio + "', HoraFin='" + turno.HoraFin + "', IdUsuarioMod='" + turno.IdUsuarioMod + "', fechaMod=GETDATE() where IdTurno='" + turno.IdTurno+ "'";
            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            queryCommand.ExecuteNonQuery();
            conexion.close();
        }

        public void EliminarTurno(TURNO turno)
        {
            conexion.open();
            string query = "update Turno set IdUsuarioMod='" + turno.IdUsuarioMod + "', fechaMod=GETDATE(), estado=0 where IdTurno='" + turno.IdTurno + "'";
            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            queryCommand.ExecuteNonQuery();
            conexion.close(); 
        }

        public List<TURNO> ListarTurnos()
        {
            List<TURNO> turnos = new List<TURNO>();
            conexion.open();
            string query = "SELECT TURNO.IdTurno, DIA.IdDia, DIA.nombre, DIA.estado, TURNO.HoraInicio, TURNO.HoraFin, TURNO.DesAlmCen, TURNO.estado AS Expr1, TURNO.item FROM TURNO INNER JOIN DIA ON TURNO.IdDia = DIA.IdDia WHERE (TURNO.estado <> 0) AND (DIA.estado <> 0) ORDER BY DIA.IdDia, TURNO.DesAlmCen, TURNO.HoraInicio";

            SqlCommand queryCommand = new SqlCommand(query, conexion.get());

            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
            DataTable dataTable = new DataTable();

            dataTable.Load(queryCommandReader);
            conexion.close();
            foreach (DataRow item in dataTable.Rows)
            {
                TURNO turno = new TURNO();
                turno.IdTurno = item[0].ToString();
                turno.Dia = new DIA();
                turno.Dia.IdDia = item[1].ToString();
                turno.Dia.Nombre = item[2].ToString();
                turno.Dia.Estado = int.Parse(item[3].ToString());
                turno.HoraInicio = TimeSpan.Parse(item[4].ToString());
                turno.HoraFin = TimeSpan.Parse(item[5].ToString());
                turno.DesAlmCen = int.Parse(item[6].ToString());
                turno.Estado = int.Parse(item[7].ToString());
                turno.Item = int.Parse(item[8].ToString());
                turnos.Add(turno);
            }
            


            return turnos;
        }
     

        public int cantidadGrupos(String idTurno)
        {
            conexion.open();
            List<Area> areas = new List<Area>();
            string query = "select COUNT(IdGrupo) from Grupo_Turno where IdTurno='"+idTurno+"'";

            SqlCommand queryCommand = new SqlCommand(query, conexion.get());

            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
            DataTable dataTable = new DataTable();

            dataTable.Load(queryCommandReader);
            conexion.close();
            foreach (DataRow item in dataTable.Rows)
            {
                if (item[0] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(item[0].ToString());
                }
            }
            return 0;
        }

        #endregion

        public List<RegistroEntrada> registroXturno(String fechaUno, String fechaInicio, String fechaFin, int tipofecha, int desayuno, int almuerzo, int cena, int turno)
        {

            /*    String idconsumidor = "";
                if (codigo = "") { idconsumidor = ""; }*/

            String fecha = "";
            if (tipofecha == 1) { fecha = " and CONVERT(date,a.fechaHora)=convert(date,'" + fechaUno + "')"; }
            if (tipofecha == 2) { fecha = " and CONVERT(date,a.fechaHora)>=convert(date,'" + fechaInicio + "') and CONVERT(date,a.fechaHora)<=convert(date,'" + fechaFin + "')"; }

            String Desayuno = "''";
            if (desayuno == 1) { Desayuno = "1"; }

            String Almuerzo = "''";
            if (almuerzo == 2) { Almuerzo = "2"; }

            String Cena = "''";
            if (cena == 3) { Cena = "3"; }

            String Turno = " ";
            if (turno != 0) { Turno = " and b.item=" + turno; }

            List<RegistroEntrada> reg = new List<RegistroEntrada>();
            conexion.open();

            string query = "select convert(date,a.fechaHora), b.DesAlmCen, b.Item, count(b.DesAlmCen), a.IdTurno from RegistroEntrada a, turno b "
                            + "where a.IdTurno=b.IdTurno and a.estado<>0 and b.estado<>0 "
                            + " and ( b.DesAlmCen=" + Desayuno + " or b.DesAlmCen=" + Almuerzo + " or b.DesAlmCen=" + Cena + " )"
                            + Turno + fecha + " group by b.Item, convert(date,a.fechaHora), a.IdTurno, b.DesAlmCen order by convert(date,a.fechaHora), b.DesAlmCen";

            SqlCommand queryCommand = new SqlCommand(query, conexion.get());

            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
            DataTable dataTable = new DataTable();

            dataTable.Load(queryCommandReader);
            conexion.close();
            foreach (DataRow item in dataTable.Rows)
            {
                RegistroEntrada re = new RegistroEntrada();
                re.FechaHora = DateTime.Parse(item[0].ToString());
                re.Turno = new TURNO();
                re.Turno.DesAlmCen = int.Parse(item[1].ToString());
                re.Turno.Item = int.Parse(item[2].ToString());
                re.Estado = int.Parse(item[3].ToString());
                re.Turno.IdTurno = item[4].ToString();

                reg.Add(re);
            }
            return reg;
        }

        public int MaxItemTurno()
        {
            int cant = 0;
            conexion.open();
            string query = "select MAX(item) from TURNO where estado<>0";

            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(queryCommandReader);
            DataRow item = dataTable.Rows[0];

            cant = int.Parse(item[0].ToString());

            return cant;
        }
    }
}
