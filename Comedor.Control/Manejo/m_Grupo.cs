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
    public class m_Grupo
    {
        #region conexion
        conexion conexion = new conexion();
        #endregion

        #region BD

        public void agregarGrupo(Grupo grupo)
        {
            conexion.open();

            SqlCommand scmdAgregarGrupo = new SqlCommand("Crear_Grupo", conexion.get());
            scmdAgregarGrupo.CommandType = CommandType.StoredProcedure;

            scmdAgregarGrupo.Parameters.AddWithValue("@Nombre", grupo.Nombre);
            scmdAgregarGrupo.Parameters.AddWithValue("@Descripcion", grupo.Descripcion);
            scmdAgregarGrupo.Parameters.AddWithValue("@idusuario", grupo.IdUsuario);

            scmdAgregarGrupo.ExecuteNonQuery();
            conexion.close();
        }

        public void editarGrupo(Grupo grupo)
        {
            conexion.open();
            string query = "update Grupo set nombre='"+grupo.Nombre+"', descripcion='"+grupo.Descripcion+"', IdUsuarioMod='"+grupo.IdUsuarioMod+"', fechaMod=GETDATE() where idGrupo='"+grupo.IdGrupo+"'";
            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            queryCommand.ExecuteNonQuery();
            conexion.close();
        }

        public void eliminarGrupo(Grupo grupo)
        {
            conexion.open();
            string query = "update Grupo set IdUsuarioMod='" + grupo.IdUsuarioMod + "', fechaMod=GETDATE(), estado=0 where idGrupo='" + grupo.IdGrupo + "'";
            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            queryCommand.ExecuteNonQuery();
            conexion.close(); 
        }

        public int cantidadConsumidores(String idGrupo)
        {
            conexion.open();
            string query = "SELECT COUNT(CONSUMIDOR.IdConsumidor) AS Expr1 FROM            CONSUMIDOR INNER JOIN                          GRUPO ON CONSUMIDOR.IdGrupo = GRUPO.IdGrupo GROUP BY GRUPO.IdGrupo HAVING        (GRUPO.IdGrupo = N'"+idGrupo+"')";

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

        public List<Grupo_Turno> ListarAsignaciones(String idGrupo)
        {
            List<Grupo_Turno> turnos = new List<Grupo_Turno>();
            conexion.open();
            string query = "SELECT Grupo_Turno.IdTurno, Grupo_Turno.tipo, TURNO.IdDia FROM Grupo_Turno INNER JOIN TURNO ON Grupo_Turno.IdTurno = TURNO.IdTurno WHERE (Grupo_Turno.IdGrupo = N'"+idGrupo+"') AND (Grupo_Turno.estado <> 0)";

            SqlCommand queryCommand = new SqlCommand(query, conexion.get());

            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
            DataTable dataTable = new DataTable();

            dataTable.Load(queryCommandReader);
            conexion.close();
            foreach (DataRow item in dataTable.Rows)
            {
                Grupo_Turno gt = new Grupo_Turno();
                gt.Turno = new TURNO();
                gt.Turno.IdTurno = item[0].ToString();
                gt.Tipo = int.Parse(item[1].ToString());
                gt.Turno.Dia = new DIA();
                gt.Turno.Dia.IdDia = item[2].ToString();
                turnos.Add(gt);
            }
            return turnos;
        }

        public void AsignarTurnos(List<cambioAsigTurno> cambios, String idUsuario)
        {
            conexion.open();
            foreach (cambioAsigTurno item in cambios)
            {
                string query = "";
                if (item.Agregar) { query = "insert into Grupo_Turno values ('"+item.idGrupo+"', '"+item.idTurno+"', GETDATE(), 1, 1, '"+idUsuario+"', GETDATE(), null, null)"; }
                else { query = "update Grupo_Turno set estado =0 where IdGrupo='"+item.idGrupo+"' and IdTurno='"+item.idTurno+"'"; }
                SqlCommand queryCommand = new SqlCommand(query, conexion.get());
                queryCommand.ExecuteNonQuery();
            }
            conexion.close(); 
        }

        public List<Grupo> ListarAllGrupos()
        {
            conexion.open();
            List<Grupo> grupos = new List<Grupo>();
            // Create a String to hold the query.
            string query = "SELECT IdGrupo, Nombre AS Expr2, estado AS Expr1, Descripcion FROM GRUPO WHERE (estado <> 0)";

            // Create a SqlCommand object and pass the constructor the connection string and the query string.
            SqlCommand queryCommand = new SqlCommand(query, conexion.get());

            // Use the above SqlCommand object to create a SqlDataReader object.
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();

            // Create a DataTable object to hold all the data returned by the query.
            DataTable dataTable = new DataTable();

            // Use the DataTable.Load(SqlDataReader) function to put the results of the query into a DataTable.
            dataTable.Load(queryCommandReader);
            conexion.close();
            foreach (DataRow item in dataTable.Rows)
            {
                Grupo g = new Grupo();
                g.IdGrupo = item[0].ToString();
                g.Nombre = item[1].ToString();
                g.Estado = int.Parse(item[2].ToString());
                g.Descripcion = item[3].ToString();

                grupos.Add(g);
            }


            return grupos;
        }


        #endregion


    }
}
