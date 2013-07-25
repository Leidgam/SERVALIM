using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comedor.Modelo;
using System.Data.SqlClient;
using System.Data;

namespace Comedor.Control
{
    public class m_roles
    {
        conexion conexion = new conexion();

        public List<ROL> ListarRoles()
        {
            conexion.open();
            // Create a String to hold the query.
            string query = "SELECT        IdRol, Titulo FROM            ROL WHERE        (estado <> 0)";
            List<ROL> roles = new List<ROL>();
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
                ROL r = new ROL();
                r.IdRol = item[0].ToString();
                r.Titulo1 = item[1].ToString();


                //Obtener privileios
                String consulta = "SELECT        PRIVILEGIO.IdPrivilegio, PRIVILEGIO.Titulo, PRIVILEGIO.IdPrivilegioSup, PRIVILEGIO.estado FROM            ROL INNER JOIN                          ROL_PRIVILEGIO ON ROL.IdRol = ROL_PRIVILEGIO.IdRol INNER JOIN                          PRIVILEGIO ON ROL_PRIVILEGIO.IdPrivilegio = PRIVILEGIO.IdPrivilegio WHERE        (ROL.IdRol = N'" + r.IdRol + "') AND (PRIVILEGIO.estado <> 0)";

                SqlCommand peticion = new SqlCommand(consulta, conexion.get());
                SqlDataReader consultacommanReader = peticion.ExecuteReader();
                DataTable privilegios = new DataTable();
                privilegios.Load(consultacommanReader);

                foreach (DataRow priv in privilegios.Rows)
                {
                    Rol_Privilegio rp = new Rol_Privilegio();
                    rp.Privilegio = new Privilegio();
                    rp.Privilegio.IdPrivilegio = priv[0].ToString();
                    rp.Privilegio.Titulo = priv[1].ToString();
                    rp.Privilegio.PrivilegioSup = new Privilegio();
                    rp.Privilegio.PrivilegioSup.IdPrivilegio = priv[2].ToString();
                    rp.Privilegio.Estado = int.Parse(priv[3].ToString());

                    r.privilegios.Add(rp);
                }
                roles.Add(r);
            }

            conexion.close();
            return roles;
        }

        public List<ROL> listarRoles()
        {
            conexion.open();
            // Create a String to hold the query.
            string query = "SELECT IdRol, Titulo FROM ROL WHERE (estado <> 0)";
            List<ROL> roles = new List<ROL>();
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
                ROL r = new ROL();
                r.IdRol = item[0].ToString();
                r.Titulo1 = item[1].ToString();
                roles.Add(r);
            }

            conexion.close();
            return roles;
        }

        public List<Privilegio> ListarPrivilegios()
        {
            conexion.open();
            // Create a String to hold the query.
            string query = "SELECT        IdPrivilegio, Titulo, IdPrivilegioSup FROM            PRIVILEGIO WHERE        (estado <> 0)";
            List<Privilegio> privilegios = new List<Privilegio>();
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
                Privilegio p = new Privilegio();
                p.IdPrivilegio = item[0].ToString();
                p.Titulo = item[1].ToString();
                p.PrivilegioSup = new Privilegio();
                p.PrivilegioSup.IdPrivilegio = item[2].ToString();
                privilegios.Add(p);
            }


            return privilegios;
        }

        public void agregarRol(ROL rol)
        {
            conexion.open();

            SqlCommand scmd = new SqlCommand("Crear_Rol", conexion.get());
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.Parameters.AddWithValue("@Titulo", rol.Titulo1);
            scmd.ExecuteNonQuery();
            conexion.close();
        }

        public void editarRol(ROL rol)
        {
            conexion.open();
            string query = "update ROL set Titulo='" + rol.Titulo1 + "' where IdRol='" + rol.IdRol + "'";
            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            queryCommand.ExecuteNonQuery();
            conexion.close();
        }

        public void eliminarRol(String Idrol)
        {
            conexion.open();
            string query = "update ROL set estado=0 where IdRol='" + Idrol + "'";
            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            queryCommand.ExecuteNonQuery();
            conexion.close();
        }
    }
}
