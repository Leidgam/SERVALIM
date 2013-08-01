using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comedor.Modelo;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Comedor.Modelo.Entidades;

namespace Comedor.Control
{
   public class m_consumidor
   {

       #region conexion
       conexion conexion = new conexion();
       #endregion

       #region BD

       public String AgregarConsumidor(consumidor c)
        {
            conexion.open();
            String codigoPersona;
            String idConsumidor;

            SqlDataAdapter cmdAdd = new SqlDataAdapter("agregar_consumidor", conexion.get());
            cmdAdd.SelectCommand.CommandType = CommandType.StoredProcedure;

            cmdAdd.SelectCommand.Parameters.AddWithValue("@Nombres", c.Persona.Nombres);
            cmdAdd.SelectCommand.Parameters.AddWithValue("@Paterno ", c.Persona.Paterno);
            cmdAdd.SelectCommand.Parameters.AddWithValue("@Materno", c.Persona.Materno);
            cmdAdd.SelectCommand.Parameters.AddWithValue("@TipoDNI", c.Persona.TipoDNI);
            cmdAdd.SelectCommand.Parameters.AddWithValue("@DNI", c.Persona.DNI);
            cmdAdd.SelectCommand.Parameters.AddWithValue("@FechaNac", c.Persona.FechaNac);
            cmdAdd.SelectCommand.Parameters.AddWithValue("@IdPais", c.Persona.Pais.IdPais);
            cmdAdd.SelectCommand.Parameters.AddWithValue("@IdDepartamento", c.Persona.Departamento.IdDepartamento);
            cmdAdd.SelectCommand.Parameters.AddWithValue("@Distrito", c.Persona.Distrito);
            cmdAdd.SelectCommand.Parameters.AddWithValue("@idusuario", c.IdUsuarioReg);
            cmdAdd.SelectCommand.Parameters.AddWithValue("@IdEAP", c.EAP.IdEAP);
            cmdAdd.SelectCommand.Parameters.AddWithValue("@Ciclo", c.Ciclo);
            cmdAdd.SelectCommand.Parameters.AddWithValue("@codUniversitario", c.CodUniversitario);
            cmdAdd.SelectCommand.Parameters.AddWithValue("@IdGrupo", c.Grupo.IdGrupo);
            cmdAdd.SelectCommand.Parameters.AddWithValue("@IdArea", c.Area.IdArea);
                    
            

            DataTable dt = new DataTable();
            cmdAdd.Fill(dt);
            
            DataRow row = dt.Rows[0];
            
            codigoPersona = Convert.ToString(row["IdPersona"]);
            idConsumidor = Convert.ToString(row["IdConsumidor"]);
            if (c.Persona.contacto.Count > 0)
            {
                String query = "insert into CONTACTO values ('"+codigoPersona+"',"+c.Persona.contacto[0].Tipo+",'"+c.Persona.contacto[0].Descripcion+"','"+c.Persona.contacto[0].Valor+"',1,'"+c.IdUsuarioReg+"',GETDATE(),NULL,NULL )";
                foreach (Contacto item in c.Persona.contacto)
                {
                    if (item != c.Persona.contacto[0])
                    {
                        query += ", ('" + codigoPersona + "'," + item.Tipo + ",'" + item.Descripcion + "','" + item.Valor + "',1,'" + c.IdUsuarioReg + "',GETDATE(),NULL,NULL )";
                    }
                }
                SqlCommand queryCommand2 = new SqlCommand(query, conexion.get());

                queryCommand2.ExecuteNonQuery();
            }
            bool autoasignnn = false;
            if (c.periodos.Count > 0)
            {
                String query = "insert into CONSUMIDOR_PERIODO values ";
                bool primera = true;
                foreach (Consumidor_Periodo item in c.periodos)
                {
                    if (item.AutoAsig == false)
                    {
                        autoasignnn = true;
                        if (primera == false) { query += " , "; } else { primera = false; }    
                        query += "('" + idConsumidor + "','" + item.Periodo.IdPeriodo + "','" + item.Codigo + "'," + item.Contrato+ ",1,'" + c.IdUsuarioReg + "',GETDATE(),NULL,NULL )";
                    }
                }
                if (autoasignnn)
                {
                    SqlCommand queryCommand2 = new SqlCommand(query, conexion.get());

                    queryCommand2.ExecuteNonQuery();
                }
            }
            if (c.periodos.Count > 0)
            {
                if (c.IdConsumidor == "" || c.IdConsumidor == null) { c.IdConsumidor = idConsumidor; }
                List<consumidor> lista = new List<consumidor>();
                lista.Add(c);
                foreach (Consumidor_Periodo item in c.periodos)
                {
                    if (item.AutoAsig)
                    {
                        Matricular(lista, item.Periodo.IdPeriodo);
                    }
                }

            }


            conexion.close();
            return codigoPersona;


        }

        public List<consumidor> ListarConsumidores(String idPeriodo, String idGrupo)
        {
            conexion.open();
            List<consumidor> consumidores = new List<consumidor>();
            // Create a String to hold the query.
            string query = "SELECT CONSUMIDOR.IdConsumidor, Persona.Nombres, Persona.Paterno, Persona.Materno, CONSUMIDOR_PERIODO.Codigo FROM CONSUMIDOR INNER JOIN Persona ON CONSUMIDOR.IdPersona = Persona.IdPersona INNER JOIN CONSUMIDOR_PERIODO ON CONSUMIDOR.IdConsumidor = CONSUMIDOR_PERIODO.IdConsumidor WHERE        (CONSUMIDOR.estado <> 0) AND (CONSUMIDOR_PERIODO.IdPeriodo = N'" + idPeriodo + "') AND (CONSUMIDOR.IdGrupo = N'" + idGrupo + "') AND (CONSUMIDOR_PERIODO.estado <> 0)";

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
                consumidor c = new consumidor();
                c.IdConsumidor = item[0].ToString();
                c.Persona = new Persona();
                c.Persona.Nombres = item[1].ToString();
                c.Persona.Paterno = item[2].ToString();
                c.Persona.Materno = item[3].ToString();
                Periodo periodo = new Periodo();
                periodo.IdPeriodo = idPeriodo;
                Consumidor_Periodo cp = new Consumidor_Periodo();
                cp.Periodo = periodo;
                cp.Codigo = item[4].ToString();
                c.periodos.Add(cp);

                consumidores.Add(c);

            }



            return consumidores;
        }

        public List<consumidor> ListarConsumidores(String idPeriodo)
        {
            conexion.open();
            List<consumidor> consumidores = new List<consumidor>();
            String wherePeriodo = "";
            string query = "";
            if (idPeriodo != "000")
            {
                wherePeriodo = "AND (CONSUMIDOR_PERIODO.IdPeriodo = N'" + idPeriodo + "')";
                query = "SELECT CONSUMIDOR.IdConsumidor, Persona.Nombres, Persona.Paterno, Persona.Materno, CONSUMIDOR_PERIODO.Codigo, Area.Nombre, Persona.IdPersona FROM CONSUMIDOR INNER JOIN Persona ON CONSUMIDOR.IdPersona = Persona.IdPersona INNER JOIN CONSUMIDOR_PERIODO ON CONSUMIDOR.IdConsumidor = CONSUMIDOR_PERIODO.IdConsumidor INNER JOIN Area ON CONSUMIDOR.IdArea = Area.IdArea WHERE (CONSUMIDOR.estado <> 0)  AND (CONSUMIDOR_PERIODO.estado <> 0) " + wherePeriodo;           
            }
            else
            {
                query = "SELECT CONSUMIDOR.IdConsumidor, Persona.Nombres, Persona.Paterno, Persona.Materno,'', Area.Nombre, Persona.IdPersona FROM CONSUMIDOR INNER JOIN Persona ON CONSUMIDOR.IdPersona = Persona.IdPersona INNER JOIN Area ON CONSUMIDOR.IdArea = Area.IdArea WHERE (CONSUMIDOR.estado <> 0)";
            }

            // Create a String to hold the query.
            

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
                consumidor c = new consumidor();
                c.IdConsumidor = item[0].ToString();
                c.Persona = new Persona();
                c.Persona.Nombres = item[1].ToString();
                c.Persona.Paterno = item[2].ToString();
                c.Persona.Materno = item[3].ToString();
                Periodo periodo = new Periodo();
                periodo.IdPeriodo = idPeriodo;
                Consumidor_Periodo cp = new Consumidor_Periodo();
                cp.Periodo = periodo;
                cp.Codigo = item[4].ToString();
                c.periodos.Add(cp);
                c.Area = new Area();
                c.Area.Nombre = item[5].ToString();
                c.Persona.IdPersona = item[6].ToString();
                consumidores.Add(c);

            }



            return consumidores;
        }

        public List<consumidor> ListarConsumidores(String idPeriodo, String idGrupo, String idArea)
        {
            conexion.open();
            List<consumidor> consumidores = new List<consumidor>();
            // Create a String to hold the query.
            String whereGrupo = "";
            if (idGrupo != "000") { whereGrupo = "AND (CONSUMIDOR.IdGrupo = N'" + idGrupo + "')"; }
            String whereArea = "";
            if (idArea != "000") { whereArea = " AND (CONSUMIDOR.IdArea = N'" + idArea + "')"; }

            string query = "SELECT CONSUMIDOR.IdConsumidor, Persona.Nombres, Persona.Paterno, Persona.Materno, CONSUMIDOR_PERIODO.Codigo, GRUPO.Nombre, Area.Nombre AS Expr1 FROM CONSUMIDOR INNER JOIN Persona ON CONSUMIDOR.IdPersona = Persona.IdPersona INNER JOIN CONSUMIDOR_PERIODO ON CONSUMIDOR.IdConsumidor = CONSUMIDOR_PERIODO.IdConsumidor INNER JOIN GRUPO ON CONSUMIDOR.IdGrupo = GRUPO.IdGrupo INNER JOIN Area ON CONSUMIDOR.IdArea = Area.IdArea WHERE (CONSUMIDOR.estado <> 0) AND (CONSUMIDOR_PERIODO.IdPeriodo = N'" + idPeriodo + "') AND (CONSUMIDOR_PERIODO.estado <> 0) " + whereGrupo + " " + whereArea;
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
                consumidor c = new consumidor();
                c.IdConsumidor = item[0].ToString();
                c.Persona = new Persona();
                c.Persona.Nombres = item[1].ToString();
                c.Persona.Paterno = item[2].ToString();
                c.Persona.Materno = item[3].ToString();
                Periodo periodo = new Periodo();
                periodo.IdPeriodo = idPeriodo;
                Consumidor_Periodo cp = new Consumidor_Periodo();
                cp.Periodo = periodo;
                cp.Codigo = item[4].ToString();
                c.periodos.Add(cp);
                c.Grupo = new Grupo();
                c.Grupo.Nombre = item[5].ToString();
                c.Area = new Area();
                c.Area.Nombre = item[6].ToString();

                consumidores.Add(c);

            }



            return consumidores;
        }

        public List<consumidor> ListarInscritos(List<consumidor> lookCons, String idPeriodo)
        {
            conexion.open();
            List<consumidor> consumidores = new List<consumidor>();
            string query = "SELECT IdConsumidor FROM CONSUMIDOR_PERIODO WHERE  (CONSUMIDOR_PERIODO.estado <> 0) AND ((IdConsumidor = N'" + lookCons[0].IdConsumidor + "') AND (IdPeriodo = N'" + idPeriodo + "')) ";
            foreach (consumidor item in lookCons)
            {
                if (item != lookCons[0])
                {
                    query += " or ((IdConsumidor = N'"+item.IdConsumidor+"') AND (IdPeriodo = N'"+idPeriodo+"'))";
                }
            }
            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(queryCommandReader);
            conexion.close();
            foreach (DataRow item in dataTable.Rows) { consumidor c = new consumidor(); c.IdConsumidor = item[0].ToString(); consumidores.Add(c); } 
            return consumidores;
        }

        public List<Incidencia> ListarIncidencias(String idConsumidor)
        {
            List<Incidencia> incidencias = new List<Incidencia>();
            conexion.open();
            // Create a String to hold the query.
            string query = "SELECT IdIncidencia, gravedad, Descripción, IdTurno, fechaHora, tipo, estado FROM            Incidencia WHERE        (estado <> 0) AND (IdConsumidor = N'"+idConsumidor+"')";

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
                Incidencia i = new Incidencia();
                i.IdIncidencia = item[0].ToString();
                i.Gravedad = int.Parse(item[1].ToString());
                i.Descripcion = item[2].ToString();
                i.IdTurno = item[3].ToString();
                i.FechaHora = DateTime.Parse(item[4].ToString());
                i.Tipo = int.Parse(item[5].ToString());
                incidencias.Add(i);

            }


            return incidencias;
        }

        public String getUltimoCodigo(String idConsumidor)
        {
            conexion.open();
            string query = "SELECT TOP (1) CONSUMIDOR_PERIODO.Codigo FROM CONSUMIDOR_PERIODO INNER JOIN PERIODO ON CONSUMIDOR_PERIODO.IdPeriodo = PERIODO.IdPeriodo WHERE (CONSUMIDOR_PERIODO.IdConsumidor = N'"+idConsumidor+"') AND (CONSUMIDOR_PERIODO.estado <> 0) AND (PERIODO.estado <> 0) ORDER BY PERIODO.fechaInicio DESC, PERIODO.fechaFin DESC";
            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(queryCommandReader);
            conexion.close();
            foreach (DataRow item in dataTable.Rows)
            {
                return item[0].ToString();

            }


            return null;
        }

        public consumidor AllDatos(String idConsumidor)
        {
            conexion.open();
            consumidor consumidore = new consumidor();
            // Create a String to hold the query.
            string query = "SELECT CONSUMIDOR.IdConsumidor, Persona.IdPersona, Persona.Nombres, Persona.Paterno, Persona.Materno, Persona.TipoDNI, Persona.DNI, Persona.fechaNac, Persona.IdPais, Persona.IdDepartamento, Persona.Distrito, CONSUMIDOR.estado, CONSUMIDOR.IdEAP, CONSUMIDOR.Ciclo, CONSUMIDOR.CodUniversitario, CONSUMIDOR.IdGrupo, CONSUMIDOR.IdArea FROM CONSUMIDOR INNER JOIN Persona ON CONSUMIDOR.IdPersona = Persona.IdPersona WHERE (CONSUMIDOR.estado <> 0) AND (CONSUMIDOR.IdConsumidor = N'"+idConsumidor+"') ";

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
                consumidor c = new consumidor();
                c.IdConsumidor = item[0].ToString();
                c.Persona = new Persona();
                c.Persona.IdPersona = item[1].ToString();
                c.Persona.Nombres = item[2].ToString();
                c.Persona.Paterno = item[3].ToString();
                c.Persona.Materno = item[4].ToString();
                c.Persona.TipoDNI = int.Parse(item[5].ToString());
                c.Persona.DNI = item[6].ToString();
                c.Persona.FechaNac = DateTime.Parse(item[7].ToString());
                c.Persona.Pais = new Pais();
                c.Persona.Pais.IdPais = item[8].ToString();
                c.Persona.Departamento = new Departamento();
                c.Persona.Departamento.IdDepartamento = item[9].ToString();
                c.Persona.Distrito = item[10].ToString();
                c.Estado = int.Parse(item[11].ToString());
                c.EAP = new EAP();
                c.EAP.IdEAP = item[12].ToString();
                c.Ciclo = int.Parse(item[13].ToString());
                c.CodUniversitario = item[14].ToString();
                c.Grupo = new Grupo();
                c.Grupo.IdGrupo = item[15].ToString();
                c.Area = new Area();
                c.Area.IdArea = item[16].ToString();

                string query2 = "SELECT Tipo, Descripcion, valor, estado FROM CONTACTO WHERE (IdPersona = N'"+c.Persona.IdPersona+"')";
                SqlCommand queryCommand2 = new SqlCommand(query2, conexion.get());
                SqlDataReader queryCommandReader2 = queryCommand2.ExecuteReader();
                DataTable dataTable2 = new DataTable();
                dataTable2.Load(queryCommandReader2);

                foreach (DataRow item2 in dataTable2.Rows)
                {
                    Contacto contact = new Contacto();
                    contact.Persona = c.Persona;
                    contact.Tipo = int.Parse(item2[0].ToString());
                    contact.Descripcion = item2[1].ToString();
                    contact.Valor = item2[2].ToString();
                    contact.Estado = int.Parse(item2[3].ToString());

                    c.Persona.contacto.Add(contact);
                }

                string query3 = "SELECT PERIODO.IdPeriodo, PERIODO.Descripcion, CONSUMIDOR_PERIODO.Codigo, CONSUMIDOR_PERIODO.contrato, CONSUMIDOR_PERIODO.estado FROM CONSUMIDOR_PERIODO INNER JOIN PERIODO ON CONSUMIDOR_PERIODO.IdPeriodo = PERIODO.IdPeriodo WHERE(CONSUMIDOR_PERIODO.IdConsumidor = N'" + c.IdConsumidor + "') AND (CONSUMIDOR_PERIODO.estado <> 0)";
                SqlCommand queryCommand3 = new SqlCommand(query3, conexion.get());
                SqlDataReader queryCommandReader3 = queryCommand3.ExecuteReader();
                DataTable dataTable3 = new DataTable();
                dataTable3.Load(queryCommandReader3);

                foreach (DataRow item3 in dataTable3.Rows)
                {
                    Consumidor_Periodo cp = new Consumidor_Periodo();
                    cp.Periodo = new Periodo();
                    cp.Periodo.IdPeriodo = item3[0].ToString();
                    cp.Periodo.Descripcion = item3[1].ToString();
                    cp.Codigo = item3[2].ToString();
                    cp.Contrato = int.Parse(item3[3].ToString());
                    cp.Estado = int.Parse(item3[4].ToString());

                    c.periodos.Add(cp);
                }

                return c;

            }


            return null;
        }

        public bool ValidarCodigo(String idPeriodo, String Codigo)
        {
            conexion.open();
            string query = "SELECT IdPeriodo, Codigo FROM CONSUMIDOR_PERIODO WHERE (IdPeriodo = N'"+idPeriodo+"') AND (Codigo = N'"+Codigo+"') AND (estado <> 0)";
            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(queryCommandReader);
            conexion.close();
            foreach (DataRow item in dataTable.Rows)
            {
                return false;
            }
            return true;
        }

        public void Matricular(List<consumidor> lista, String idPeriodo)
        {
            conexion.open();
            String IDS = lista[0].IdConsumidor;
            foreach (consumidor item in lista)
            {
                if (item != lista[0]) { IDS += "," + item.IdConsumidor; }
            }
            SqlCommand scmd = new SqlCommand("Matricular", conexion.get());
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.Parameters.AddWithValue("@Ids", IDS);
            scmd.Parameters.AddWithValue("@IdPerido", idPeriodo);
            scmd.Parameters.AddWithValue("@idusuario", lista[0].IdUsuarioReg);
            scmd.Parameters.AddWithValue("@contrato", 0);
            scmd.ExecuteNonQuery();
            conexion.close();
        }
           
        public void Editar(consumidor c)
        {
            conexion.open();
            string query = "update Persona set Nombres ='"+c.Persona.Nombres+"', Paterno='"+c.Persona.Paterno+"', Materno='"+c.Persona.Materno+"', TipoDNI="+c.Persona.TipoDNI+", DNI='"+c.Persona.DNI+"',fechaNac='"+c.Persona.FechaNac.ToString("dd/MM/yyyy")+"',IdPais='"+c.Persona.Pais.IdPais+"',IdDepartamento='"+c.Persona.Departamento.IdDepartamento+"',Distrito='"+c.Persona.Distrito+"',idUsuarioMod='"+c.IdUsuarioMod+"', fechaMod = GETDATE() where IdPersona ='"+c.Persona.IdPersona+"'";
            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            queryCommand.ExecuteNonQuery();

            string query2 = "update CONSUMIDOR set IdEAP ='"+c.EAP.IdEAP+"', Ciclo = "+c.Ciclo+", CodUniversitario ='"+c.CodUniversitario+"', IdGrupo='"+c.Grupo.IdGrupo+"', IdArea='"+c.Area.IdArea+"', idUsuarioMod='"+c.IdUsuarioMod+"', fechaMod=GETDATE() where IdConsumidor ='"+c.IdConsumidor+"'";
            SqlCommand queryCommand2 = new SqlCommand(query2, conexion.get());
            queryCommand2.ExecuteNonQuery();

            foreach (Comedor.Modelo.Auxiliares.cambioConsumidor item in c.cambios)
            {
                string query3 = "";
                bool ejecutar = true;
                if (item.contacto)
                {
                    if (item.agregar)
                    {
                        query3 = "insert into CONTACTO values ('" + c.Persona.IdPersona + "'," + item.contact.Tipo + ",'" + item.contact.Descripcion + "','" + item.contact.Valor + "',1,'" + c.IdUsuarioMod + "',GETDATE(),NULL,NULL )";
                    }
                    else if (item.eliminar)
                    {
                        query3 = "delete from CONTACTO where IdPersona='"+c.Persona.IdPersona+"' and Tipo= "+item.contact.Tipo+" and valor = '"+item.contact.Valor+"'";
                    }                  
                    
                }
                else if (item.periodo)
                {
                    if (item.agregar)
                    {
                        int AutoAsignarCodigo = 0;
                        if (item.cp.AutoAsig) { AutoAsignarCodigo = 1; item.cp.Codigo = " "; }
                        ejecutar = false;
                        SqlCommand scmd = new SqlCommand("re_matricular", conexion.get());
                        scmd.CommandType = CommandType.StoredProcedure;
                        scmd.Parameters.AddWithValue("@IdConsumidor", c.IdConsumidor);
                        scmd.Parameters.AddWithValue("@IdPeriodo", item.cp.Periodo.IdPeriodo);
                        scmd.Parameters.AddWithValue("@codigo", item.cp.Codigo);
                        scmd.Parameters.AddWithValue("@contrato", item.cp.Contrato);
                        scmd.Parameters.AddWithValue("@idusuario", c.IdUsuarioMod);
                        scmd.Parameters.AddWithValue("@Auto", AutoAsignarCodigo);

                        scmd.ExecuteNonQuery();
                       
                    }
                    else if (item.eliminar)
                    {
                        query3 = "update CONSUMIDOR_PERIODO set estado =0, IdUsuarioMod='"+c.IdUsuarioMod+"', fechaMod=GETDATE() where IdConsumidor='" + c.IdConsumidor + "' and IdPeriodo='" + item.cp.Periodo.IdPeriodo + "'";
                    }
                }
                if (ejecutar)
                {
                    SqlCommand queryCommand3 = new SqlCommand(query3, conexion.get());
                    queryCommand3.ExecuteNonQuery();
                }
            }
            conexion.close();
        }

        public void eliminar(String idConsumidor)
        {
            string query2 = "UPDATE CONSUMIDOR SET ESTADO=0 WHERE IdConsumidor='"+idConsumidor+"'";


            SqlCommand queryCommand2 = new SqlCommand(query2, conexion.get());

            queryCommand2.ExecuteNonQuery();
        }

        public void ReasignarGrupo(List<consumidor> consumidores, String idGrupo)
        {
            String ids = "";
            foreach (consumidor item in consumidores) { if (item.IdConsumidor != consumidores[0].IdConsumidor) { ids += " or idConsumidor='" + item.IdConsumidor + "'"; } }
            string query2 = "UPDATE CONSUMIDOR SET IdGrupo='" + idGrupo + "', idUsuarioMod='" + consumidores[0].IdUsuarioMod + "', fechaMod=GETDATE() WHERE IdConsumidor='" + consumidores[0].IdConsumidor + "' " + ids + " ";

            conexion.open();
            SqlCommand queryCommand2 = new SqlCommand(query2, conexion.get());

            queryCommand2.ExecuteNonQuery();
            conexion.close();
        }

        public List<Consumidor_Periodo> ListarGrupoAreaConsumidor(int tipo, Usuario usuario)
        {
            conexion.open();
            
            String whereUsuario = "";
            if (usuario.validarPrivilegio("PRI0000034"))
            {
             
            }
            else
            {
                whereUsuario = "where IdUsuario='" + usuario.IdUsuario +"'";
            }
            
            List<Consumidor_Periodo> ListGrupArCon = new List<Consumidor_Periodo>();
            String GrupoAreaConsumidor = "";

            if (tipo == 1) { GrupoAreaConsumidor = " c.IdGrupo, g.Nombre"; }
            if (tipo == 2) { GrupoAreaConsumidor = " f.IdArea, e.Nombre"; }
            if (tipo == 3) { GrupoAreaConsumidor = " a.Codigo,a.IdConsumidor,d.Nombres,d.Paterno,d.Materno,e.IdArea, c.IdGrupo "; }

            string query = "select DISTINCT" + GrupoAreaConsumidor + " from  CONSUMIDOR_PERIODO a, PERIODO b , CONSUMIDOR c, Persona d, Area e, PERSONA_AREA f, GRUPO g"
                     + " where a.IdPeriodo=b.IdPeriodo"
                     + " and c.IdConsumidor=a.IdConsumidor"
                     + " and c.IdPersona=d.IdPersona"
                     + " and c.IdArea=e.IdArea"
                     + " and e.IdArea=f.IdArea"
                     + " and c.IdGrupo=g.IdGrupo"
                     + " and CONVERT(date,b.fechaInicio)<=CONVERT(date,SYSDATETIME())"
                     + " and CONVERT(date, b.fechaFin)>=CONVERT(date,SYSDATETIME())"
                     + " and f.IdPersona= any(select IdPersona from USUARIO "+whereUsuario+") "
                     + " and a.estado<>0 and b.estado<>0 and c.estado<>0 and e.estado<>0 and f.estado<>0 and g.estado<>0";

            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(queryCommandReader);
            conexion.close();

            foreach (DataRow item in dataTable.Rows)
            {
                Consumidor_Periodo ga = new Consumidor_Periodo();
                if (tipo == 1)
                {
                    ga.Consumidor = new consumidor();
                    ga.Consumidor.Grupo = new Grupo();
                    ga.Consumidor.Grupo.IdGrupo = item[0].ToString();
                    ga.Consumidor.Grupo.Nombre = item[1].ToString();
                }
                if (tipo == 2)
                {
                    ga.Consumidor = new consumidor();
                    ga.Consumidor.Area = new Area();
                    ga.Consumidor.Area.IdArea = item[0].ToString();
                    ga.Consumidor.Area.Nombre = item[1].ToString();
                }
                if (tipo == 3)
                {
                    ga.Codigo = item[0].ToString();
                    ga.Consumidor = new consumidor();
                    ga.Consumidor.IdConsumidor = item[1].ToString();
                    ga.Consumidor.Persona = new Persona();
                    ga.Consumidor.Persona.Nombres = item[2].ToString();
                    ga.Consumidor.Persona.Paterno = item[3].ToString();
                    ga.Consumidor.Persona.Materno = item[4].ToString();
                    ga.Consumidor.Area = new Area();
                    ga.Consumidor.Area.IdArea = item[5].ToString();
                    ga.Consumidor.Grupo = new Grupo();
                    ga.Consumidor.Grupo.IdGrupo = item[6].ToString();

                }
                ListGrupArCon.Add(ga);
            }
            return ListGrupArCon;
        }

        public void AgregarIncidencia(Incidencia i, String idUsuario)
        {
            conexion.open();

            SqlCommand cmdEditReceta = new SqlCommand("agregar_incidencia", conexion.get());
            cmdEditReceta.CommandType = CommandType.StoredProcedure;
            cmdEditReceta.Parameters.AddWithValue("@Descripcion", i.Descripcion);
            cmdEditReceta.Parameters.AddWithValue("@IdConsumidor", i.Consumidor.IdConsumidor);
            cmdEditReceta.Parameters.AddWithValue("@tipo", i.Tipo);
            cmdEditReceta.Parameters.AddWithValue("@IdTurno", "0000");
            cmdEditReceta.Parameters.AddWithValue("@IdUsuario", idUsuario);
            cmdEditReceta.Parameters.AddWithValue("@fecha", i.FechaHora);
            cmdEditReceta.ExecuteNonQuery();
            

            conexion.close();
        }

        #endregion

       #region BD Juan

        public List<EAP> llenar_Filtro(String tabla)
        {
            conexion.open();
            List<EAP> rep = new List<EAP>();
            string query = "select * from " + tabla + " where estado<>0";

            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(queryCommandReader);

            conexion.close();
            foreach (DataRow item in dataTable.Rows)
            {
                EAP f = new EAP();

                f.IdEAP = item[0].ToString();
                f.Nombre = item[1].ToString();
                f.Facultad = new Facultad();
                if (item[3].ToString() == null || item[3].ToString() == "") { f.Facultad.IdFacultad = ""; }
                else { f.Facultad.IdFacultad = item[3].ToString(); }

                rep.Add(f);

            }

            return rep;

        }

       

       #endregion

        public List<Consumidor_Periodo> filtro_consumidor(String idperiodo, String idarea, String idgrupo, String idfacultad, String ideap, int idciclo, int tipoTurno, String idturno, String fecha)
        {
            String tablaRE = "";
            String RegistroEntra = "";
            if (tipoTurno != 0) { tablaRE = ", RegistroEntrada d"; RegistroEntra = " and a.IdConsumidor=d.IdConsumidor and d.IdTurno='" + idturno + "' and CONVERT(date,d.fechaHora)=convert(date,'" + fecha + "') "; }

            List<Consumidor_Periodo> resp = new List<Consumidor_Periodo>();
            String periodo = "";
            if (idperiodo != "000") { periodo = " and b.IdPeriodo='" + idperiodo + "'"; }
            String area = "";
            if (idarea != "000") { area = " and a.IdArea='" + idarea + "'"; }
            String grupo = "";
            if (idgrupo != "000") { grupo = " and a.IdGrupo='" + idgrupo + "'"; }
            String facultad = "";
            if (idfacultad != "000") { facultad = " and a.IdEAP=any(select IdEAP from EAP where IdFacultad='" + idfacultad + "')"; }
            String escuela = "";
            if (ideap != "000") { escuela = "and a.IdEAP='" + ideap + "'"; }
            String ciclo = "";
            if (idciclo != 0) { ciclo = " and a.Ciclo=" + idciclo; }

            conexion.open();
            string query = "select a.IdConsumidor, b.Codigo, c.Nombres, c.Paterno, c.Materno, a.CodUniversitario from Persona c, CONSUMIDOR a, CONSUMIDOR_PERIODO b " + tablaRE + " where a.IdConsumidor=b.IdConsumidor and c.IdPersona=a.IdPersona " + RegistroEntra + periodo + area + grupo + facultad + escuela + ciclo + " and  a.estado<>0  and b.estado<>0 order by c.Materno";

            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(queryCommandReader);

            conexion.close();
            foreach (DataRow item in dataTable.Rows)
            {
                Consumidor_Periodo cp = new Consumidor_Periodo();
                cp.Consumidor = new consumidor();
                cp.Consumidor.IdConsumidor = item[0].ToString();
                cp.Codigo = item[1].ToString();
                cp.Consumidor.Persona = new Persona();
                cp.Consumidor.Persona.Nombres = item[2].ToString();
                cp.Consumidor.Persona.Paterno = item[3].ToString();
                cp.Consumidor.Persona.Materno = item[4].ToString();
                cp.Consumidor.CodUniversitario = item[5].ToString();

                resp.Add(cp);
            }
            return resp;
        }


        //nuevo **
        public int CantidadConsumidores(String fecha, String idturno)
        {
            int cant = 0;
            conexion.open();
            string query = "select (SELECT count(*) FROM CONSUMIDOR_PERIODO a, PERIODO b where a.IdPeriodo=b.IdPeriodo and CONVERT(date,b.fechaInicio)<=CONVERT(date,'" + fecha + "') and convert(date,b.fechaFin)>=CONVERT(date,'" + fecha + "') and a.estado<>0 and IdConsumidor=any(SELECT c.IdConsumidor FROM  CONSUMIDOR c , GRUPO d, Grupo_Turno e where   c.IdGrupo=d.IdGrupo and d.IdGrupo=e.IdGrupo and IdTurno='" + idturno + "' and c.estado<>0 and d.estado<>0 and e.estado<>0))-(select count(*) from RESERVA where IdTurno='" + idturno + "' and tipo=2 and CONVERT(date,fecha)=CONVERT(date,'" + fecha + "') and estado<>0)-(select COUNT(*) from RESERVA where IdTurno='" + idturno + "' and tipo=1 and estado<>0 )+(select COUNT(*) from Excepcion  where IdReserva=any(select IdReserva from RESERVA where IdTurno='" + idturno + "' and tipo=1 and estado<>0 )and estado<>0 and CONVERT(date,fecha)=CONVERT(date,'" + fecha + "'))+(select count(*) from RESERVA where IdTurnoRemplazo='" + idturno + "' and tipo=2 and CONVERT(date,fecha)=CONVERT(date,'" + fecha + "') and estado<>0)+(select COUNT(*) from RESERVA where IdTurnoRemplazo='" + idturno + "' and tipo=1 and estado<>0 )-(select COUNT(*) from Excepcion  where IdReserva=any(select IdReserva from RESERVA where IdTurnoRemplazo='" + idturno + "' and tipo=1 and estado<>0 )and estado<>0 and CONVERT(date,fecha)=CONVERT(date,'" + fecha + "'))";

            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
            
            DataTable dataTable = new DataTable();
            dataTable.Load(queryCommandReader);
            conexion.close();
            DataRow item = dataTable.Rows[0];

            cant = int.Parse(item[0].ToString());

            return cant;
        }

        public Periodo IdPeriodo(String fecha)
        {

            conexion.open();
            string query = "select IdPeriodo, Descripcion  from PERIODO where CONVERT(date,fechaInicio)<=CONVERT(date,'" + fecha + "') and CONVERT(date,fechaFin)>= CONVERT(date,'" + fecha + "')";

            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(queryCommandReader);
            conexion.close();
            DataRow item = dataTable.Rows[0];
            Periodo p = new Periodo();
            p.IdPeriodo = item[0].ToString();
            p.Descripcion = item[1].ToString();

            return p;
        }

        public List<ConsumidorTurno> ConsumoXPersona(String idconsumidor, String fechaUno, String fechaInicio, String fechaFin, int tipofecha)
        {
            List<ConsumidorTurno> resp = new List<ConsumidorTurno>();

            String fecha = "";
            if (tipofecha == 1) { fecha = " and CONVERT(date,a.fechaHora)=convert(date,'" + fechaUno + "')"; }
            if (tipofecha == 2) { fecha = " and CONVERT(date,a.fechaHora)>=convert(date,'" + fechaInicio + "') and CONVERT(date,a.fechaHora)<=convert(date,'" + fechaFin + "')"; }
            conexion.open();
            string query = "select convert(date,a.fechaHora), b.DesAlmCen,  count(b.DesAlmCen), a.IdTurno, convert(time,a.fechaHora) from RegistroEntrada a, turno b"
                         + " where a.IdTurno=b.IdTurno and a.estado<>0 and b.estado<>0 "
                         + " and ( b.DesAlmCen=1 or b.DesAlmCen=2 or b.DesAlmCen=3 ) " + fecha
                         + " and IdConsumidor=" + idconsumidor
                         + " group by  convert(date,a.fechaHora), a.IdTurno, b.DesAlmCen , a.fechaHora order by convert(date,a.fechaHora), b.DesAlmCen;";

            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(queryCommandReader);

            conexion.close();
            foreach (DataRow item in dataTable.Rows)
            {
                ConsumidorTurno ct = new ConsumidorTurno();
                ct.Fecha = DateTime.Parse(item[0].ToString());
                ct.Turno = new TURNO();
                ct.Turno.DesAlmCen = int.Parse(item[1].ToString());
                ct.Estado = int.Parse(item[2].ToString());
                ct.Turno.IdTurno = item[3].ToString();
                ct.Hora = DateTime.Parse(item[4].ToString());
                resp.Add(ct);
            }
            return resp;
        }

        public String IdConsumidor(String codigo)
        {
            String id = "";
            conexion.open();
            string query = "select a.IdConsumidor from CONSUMIDOR_PERIODO a, PERIODO b where a.IdPeriodo=b.IdPeriodo and Codigo='" + codigo + "' and CONVERT(date,b.fechaInicio)<=CONVERT(date,SYSDATETIME()) and CONVERT(date,b.fechaFin)>=CONVERT(date,SYSDATETIME())";

            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(queryCommandReader);
            DataRow item = dataTable.Rows[0];
            id = item[0].ToString();

            return id;
        }

        public int existeconsumidor(String codigo)
        {
            int cant = 0;
            conexion.open();
            string query = "select COUNT(*) from CONSUMIDOR_PERIODO a, PERIODO b where a.IdPeriodo=b.IdPeriodo and Codigo='" + codigo + "' and CONVERT(date,b.fechaInicio)<=CONVERT(date,SYSDATETIME()) and CONVERT(date,b.fechaFin)>=CONVERT(date,SYSDATETIME())";

            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(queryCommandReader);
            DataRow item = dataTable.Rows[0];

            cant = int.Parse(item[0].ToString());

            return cant;
        }

        public consumidor Consumidor_reg(String idconsumidor)
        {

            consumidor ca = new consumidor();

            string query = "select a.IdPersona, b.Nombres, b.Paterno, b.Materno, b.foto, a.IdGrupo, c.Nombre, a.IdArea, d.Nombre, e.Nombre, f.Nombre, a.CodUniversitario from CONSUMIDOR a, Persona b, GRUPO c, Area d,EAP e, Facultad f where a.IdPersona=b.IdPersona and a.IdGrupo=c.IdGrupo and a.IdArea=d.IdArea and a.IdEAP=e.IdEAP and e.IdFacultad=f.IdFacultad and a.IdConsumidor='" + idconsumidor + "'";

            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(queryCommandReader);

            foreach (DataRow item in dataTable.Rows)
            {

                ca.IdConsumidor = idconsumidor;
                ca.Persona = new Persona();
                ca.Persona.IdPersona = item[0].ToString();
                ca.Persona.Nombres = item[1].ToString();
                ca.Persona.Paterno = item[2].ToString();
                ca.Persona.Materno = item[3].ToString();
                ca.Grupo = new Grupo();
                ca.Grupo.IdGrupo = item[5].ToString();
                ca.Grupo.Nombre = item[6].ToString();
                ca.Area = new Area();
                ca.Area.IdArea = item[7].ToString();
                ca.Area.Nombre = item[8].ToString();
                ca.EAP = new EAP();
                ca.EAP.Nombre = item[9].ToString();
                ca.EAP.Facultad = new Facultad();
                ca.EAP.Facultad.Nombre = item[10].ToString();
                ca.CodUniversitario = item[11].ToString();

            }
            return ca;
        }

        public void EliminarInicidencia(String idincidencia)
        {
            string query2 = "update Incidencia set estado=0 where IdIncidencia='" + idincidencia + "'";

            conexion.open();
            SqlCommand queryCommand2 = new SqlCommand(query2, conexion.get());
            queryCommand2.ExecuteNonQuery();
            conexion.close();
        }

        public List<Incidencia> ListarIncidenciaConsumidor(int tipoF, String fechaUno, String fechaDe, String fechaHasta, int tipoG, int gravedad1, int gravedad2)
        {

            List<Incidencia> incidencias = new List<Incidencia>();
            conexion.open();
            String wherefecha = "";
            if (tipoF == 1) { wherefecha = " and CONVERT(date, fechaHora)=CONVERT(date,'" + fechaUno + "')"; }
            if (tipoF == 2) { wherefecha = " and CONVERT(date, fechaHora)>=convert(date,'" + fechaDe + "') and convert(date, fechaHora)<=CONVERT(date,'" + fechaHasta + "')"; }

            String wheregravedad = "";
            if (tipoG == 1) { if (gravedad1 != 0) { wheregravedad = " and a.gravedad=" + gravedad1; } }
            if (tipoG == 2) { wheregravedad = " and a.gravedad>=" + gravedad1 + " and a.gravedad<=" + gravedad2; }

            string query = "select distinct(a.IdIncidencia),a.IdConsumidor, d.Codigo, c.Nombres, c.Paterno, c.Materno, a.gravedad, CONVERT(date ,a.fechaHora), a.IdTurno, a.Descripción, a.tipo "
                           + " from Incidencia a, CONSUMIDOR b, Persona c, CONSUMIDOR_PERIODO d , PERIODO e"
                           + " where a.IdConsumidor=b.IdConsumidor and b.IdPersona= c.IdPersona and b.IdConsumidor=d.IdConsumidor and a.estado<>0" + wherefecha + wheregravedad
                           + " and d.IdPeriodo=e.IdPeriodo and CONVERT(date,e.fechaInicio)<=CONVERT(date,SYSDATETIME()) and CONVERT(date,e.fechaFin)>=CONVERT(date,SYSDATETIME())";
            SqlCommand queryCommand = new SqlCommand(query, conexion.get());
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(queryCommandReader);

            foreach (DataRow item in dataTable.Rows)
            {
                Incidencia i = new Incidencia();
                i.IdIncidencia = item[0].ToString();
                i.Consumidor = new consumidor();
                i.Consumidor.IdConsumidor = item[1].ToString();
                i.Consumidor.CodUniversitario = item[2].ToString(); //codigo comedor
                i.Consumidor.Persona = new Persona();
                i.Consumidor.Persona.Nombres = item[3].ToString();
                i.Consumidor.Persona.Paterno = item[4].ToString();
                i.Consumidor.Persona.Materno = item[5].ToString();
                i.Gravedad = int.Parse(item[6].ToString());
                i.FechaHora = DateTime.Parse(item[7].ToString());
                i.IdTurno = item[8].ToString();
                i.Descripcion = item[9].ToString();
                i.Tipo = int.Parse(item[10].ToString());

                incidencias.Add(i);
            }
            return incidencias;
        }
   }
}
