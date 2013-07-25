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
    public class m_Area
    {

        #region conexion
        conexion conexion = new conexion();
        #endregion

        #region Base de Datos

        public List<Area> ListarAllAreas()
        {
            conexion.open();
            List<Area> areas = new List<Area>();
            // Create a String to hold the query.
            string query = "SELECT IdArea, Nombre FROM Area WHERE (estado <> 0)";

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
                Area a = new Area();
                a.IdArea = item[0].ToString();
                a.Nombre = item[1].ToString();

                areas.Add(a);
            }


            return areas;
        }   

        #endregion

        #region metodos propios



        #endregion
    }
}
