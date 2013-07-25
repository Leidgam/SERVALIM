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
    public class m_Facultad
    {
        #region conexion
        conexion conexion = new conexion();
        #endregion

        #region BD

        public List<Facultad> ListarFacultades()
        {
            List<Facultad> facultades = new List<Facultad>();
            conexion.open();
            string query = "SELECT EAP.IdEAP, EAP.Nombre, Facultad.IdFacultad, Facultad.Nombre AS Expr1 FROM Facultad INNER JOIN EAP ON Facultad.IdFacultad = EAP.IdFacultad WHERE (Facultad.estado <> 0) AND (EAP.estado <> 0)";

            SqlCommand queryCommand = new SqlCommand(query, conexion.get());

            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
            DataTable dataTable = new DataTable();

            dataTable.Load(queryCommandReader);
            conexion.close();
            foreach (DataRow item in dataTable.Rows)
            {
                EAP escuela = new EAP();
                escuela.IdEAP = item[0].ToString();
                escuela.Nombre = item[1].ToString();

                if (existeFacultad(facultades, item[2].ToString()))
                {
                    foreach (Facultad facultad in facultades) { if (facultad.IdFacultad.Equals(item[2].ToString())) { facultad.escuelas.Add(escuela); } }
                }
                else
                {
                    Facultad FacuNueva = new Facultad();
                    FacuNueva.IdFacultad = item[2].ToString();
                    FacuNueva.Nombre = item[3].ToString();
                    FacuNueva.escuelas.Add(escuela);
                    facultades.Add(FacuNueva);
                }

            }



            return facultades;
        }

        #endregion

        #region metodos propios

        private bool existeFacultad(List<Facultad> facultades, String idFacultad)
        {
            foreach (Facultad item in facultades)
            {
                if (item.IdFacultad.Equals(idFacultad))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
