using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Comedor.Modelo;

namespace Comedor.Control
{
    public class m_Periodo
    {
        #region conexion
        conexion conexion = new conexion();
        #endregion

        #region BD

        public List<Periodo> ListarPeriodos()
        {
            List<Periodo> periodos = new List<Periodo>();
            conexion.open();
            string query = "SELECT IdPeriodo, Descripcion, fechaInicio, fechaFin FROM PERIODO WHERE (estado <> 0) and (convert(date,GETDATE())<=convert(date,fechaFin))";

            SqlCommand queryCommand = new SqlCommand(query, conexion.get());

            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
            DataTable dataTable = new DataTable();

            dataTable.Load(queryCommandReader);
            conexion.close();

            foreach (DataRow item in dataTable.Rows)
            {
                Periodo periodo = new Periodo();
                periodo.IdPeriodo = item[0].ToString();
                periodo.Descripcion = item[1].ToString();
                periodo.FechaInicio = DateTime.Parse(item[2].ToString());
                periodo.FechaFin = DateTime.Parse(item[3].ToString());

                periodos.Add(periodo);
            }



            return periodos;
        }

        public List<Periodo> ListarTodosLosPeriodos()
        {
            List<Periodo> periodos = new List<Periodo>();
            conexion.open();
            string query = "SELECT IdPeriodo, Descripcion, fechaInicio, fechaFin FROM PERIODO WHERE (estado <> 0)";

            SqlCommand queryCommand = new SqlCommand(query, conexion.get());

            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
            DataTable dataTable = new DataTable();

            dataTable.Load(queryCommandReader);
            conexion.close();

            foreach (DataRow item in dataTable.Rows)
            {
                Periodo periodo = new Periodo();
                periodo.IdPeriodo = item[0].ToString();
                periodo.Descripcion = item[1].ToString();
                periodo.FechaInicio = DateTime.Parse(item[2].ToString());
                periodo.FechaFin = DateTime.Parse(item[3].ToString());

                periodos.Add(periodo);
            }



            return periodos;
        }

        public Periodo getActual()
        {
            conexion.open();

            string query = "SELECT IdPeriodo, Descripcion, fechaInicio, fechaFin, estado FROM PERIODO WHERE (estado <> 0) AND (fechaInicio <= GETDATE()) AND (fechaFin >= GETDATE())";

            // string query = "SELECT IdPeriodo, Descripcion, fechaInicio, fechaFin, estado FROM PERIODO WHERE (estado <> 0) AND IdPeriodo='003'";
            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(queryCommandReader);
            conexion.close();
            foreach (DataRow item in dataTable.Rows)
            {
                Periodo p = new Periodo();
                p.IdPeriodo = item[0].ToString();
                p.Descripcion = item[1].ToString();
                p.FechaInicio = DateTime.Parse(item[2].ToString());
                p.FechaFin = DateTime.Parse(item[3].ToString());
                p.Estado = int.Parse(item[4].ToString());
                return p;
            }


            return null;
        }

        #endregion



 
    }
}
