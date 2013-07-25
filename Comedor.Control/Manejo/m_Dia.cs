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
    public class m_Dia
    {
        #region conexion
        conexion conexion = new conexion();
        #endregion

        #region BD

        public List<DIA> ListarAllDias()
        {
            conexion.open();
            List<DIA> dias = new List<DIA>();
            // Create a String to hold the query.
            string query = "select * from DIA where estado<>0";

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
                DIA dia = new DIA();
                dia.IdDia = item[0].ToString();
                dia.Nombre = item[1].ToString();
                dia.Estado = int.Parse(item[2].ToString());

                dias.Add(dia);
            }


            return dias;
        }


        #endregion
    }
}
