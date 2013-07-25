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
    public class m_Pais
    {
        #region conexion
        conexion conexion = new conexion();
        #endregion

        #region BD

        public List<Pais> ListarPaises()
        {
            List<Pais> paises = new List<Pais>();
            conexion.open();
            string query = "SELECT DEPARTAMENTO.IdDepartamento, DEPARTAMENTO.Nombre, PAIS.IdPais, PAIS.Nombre AS Expr1 FROM PAIS INNER JOIN DEPARTAMENTO ON PAIS.IdPais = DEPARTAMENTO.IdPais";

            SqlCommand queryCommand = new SqlCommand(query, conexion.get());

            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
            DataTable dataTable = new DataTable();

            dataTable.Load(queryCommandReader);
            conexion.close();
            foreach (DataRow item in dataTable.Rows)
            {
                Departamento depart = new Departamento();
                depart.IdDepartamento = item[0].ToString();
                depart.Nombre = item[1].ToString();

                if (existePais(paises, item[2].ToString()))
                {
                    foreach (Pais pais in paises) { if (pais.IdPais.Equals(item[2].ToString())) { pais.departamentos.Add(depart); } }
                }
                else
                {
                    Pais paisNuevo = new Pais();
                    paisNuevo.IdPais = item[2].ToString();
                    paisNuevo.Nombre = item[3].ToString();
                    paisNuevo.departamentos.Add(depart);
                    paises.Add(paisNuevo);
                }
                    
            }



            return paises;
        }

        #endregion

        #region metodos propios

        private bool existePais(List<Pais> paises, String idPais)
        {
            foreach (Pais item in paises)
            {
                if (item.IdPais.Equals(idPais))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
