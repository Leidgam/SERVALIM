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
   public class m_EAP
    {
        conexion conexion = new conexion();

        public List<EAP> ListarAllEAP()
        {
            conexion.open();
            List<EAP> Escuelas = new List<EAP>();
            // Create a String to hold the query.
            string query = "SELECT EAP.IdEAP, EAP.Nombre, EAP.Telefono, Facultad.IdFacultad, Facultad.Nombre AS Expr1, Facultad.Abreviatura, Facultad.Descripcion, Facultad.estado, EAP.estado AS Expr2 FROM EAP INNER JOIN Facultad ON EAP.IdFacultad = Facultad.IdFacultad";

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
                EAP e = new EAP();
                e.IdEAP = item[0].ToString();
                e.Nombre = item[1].ToString();
                e.Telefono = item[2].ToString();
                e.Facultad = new Facultad();
                e.Facultad.IdFacultad  = item[3].ToString();
                e.Facultad.Nombre = item[4].ToString();
                e.Facultad.Abreviatura = item[5].ToString();
                e.Facultad.Descripcion = item[6].ToString();
                e.Facultad.Estado = int.Parse(item[7].ToString());
                e.Estado = int.Parse(item[8].ToString());
                Escuelas.Add(e);

            }


            return Escuelas;
        }
    }
}
