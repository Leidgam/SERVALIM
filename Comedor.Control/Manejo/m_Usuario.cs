using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comedor.Modelo;
using System.Data;
using System.Data.SqlClient;
using Comedor.Modelo.Auxiliares;

namespace Comedor.Control
{
   public class m_Usuario
   {
       #region conexion
       conexion conexion = new conexion();
       #endregion

       #region Base de Datos

       public Usuario Logeo(Usuario user)
        {
            conexion.open();
            // Create a String to hold the query.
            string query = "SELECT        Persona.Nombres, Persona.Paterno, Persona.Materno, USUARIO.IdUsuario FROM            USUARIO INNER JOIN                         Persona ON USUARIO.IdPersona = Persona.IdPersona WHERE        (USUARIO.estado <> 0) AND (USUARIO.login = N'"+user.Login+"') AND (USUARIO.passw = N'"+user.Passw+"')";

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
                Usuario u = new Usuario();
                u.Login = user.Login;
                u.Persona = new Persona();
                u.Persona.Nombres = item[0].ToString();
                u.Persona.Paterno = item[1].ToString();
                u.Persona.Materno = item[2].ToString();
                u.IdUsuario = item[3].ToString();

                //Obtener privileios
                String consulta = "SELECT        USUARIO.IdUsuario, ROL.IdRol, ROL.Titulo, PRIVILEGIO.IdPrivilegio, PRIVILEGIO.Titulo AS Expr1, PRIVILEGIO.IdPrivilegioSup, PRIVILEGIO.estado AS Expr2,                          Persona.Nombres, Persona.Paterno, Persona.Materno FROM            PRIVILEGIO INNER JOIN                         ROL_PRIVILEGIO ON PRIVILEGIO.IdPrivilegio = ROL_PRIVILEGIO.IdPrivilegio INNER JOIN                         ROL ON ROL_PRIVILEGIO.IdRol = ROL.IdRol INNER JOIN                         USUARIO_ROL ON ROL.IdRol = USUARIO_ROL.IdRol INNER JOIN                         USUARIO ON USUARIO_ROL.IdUsuario = USUARIO.IdUsuario INNER JOIN                         Persona ON USUARIO.IdPersona = Persona.IdPersona WHERE        (USUARIO.IdUsuario = N'"+u.IdUsuario+"') AND (ROL.estado <> 0) AND (PRIVILEGIO.estado <> 0)";

                SqlCommand peticion = new SqlCommand(consulta, conexion.get());
                SqlDataReader consultacommanReader = peticion.ExecuteReader();
                DataTable privilegios = new DataTable();
                privilegios.Load(consultacommanReader);

                foreach (DataRow priv in privilegios.Rows)
                {
                    Privilegio NuevoPivilegio = new Privilegio();
                    NuevoPivilegio.IdPrivilegio = priv[3].ToString();
                    NuevoPivilegio.Titulo = priv[4].ToString();
                    NuevoPivilegio.PrivilegioSup = new Privilegio();
                    NuevoPivilegio.PrivilegioSup.IdPrivilegio = priv[5].ToString();
                    NuevoPivilegio.Estado = int.Parse(priv[6].ToString());

                    Rol_Privilegio rolPRiv = new Rol_Privilegio();
                    rolPRiv.Privilegio = NuevoPivilegio;

                    if (existeRol(u.roles, priv[1].ToString()))
                    {
                        foreach (Usuario_Rol rols in u.roles)
                        {
                            if (rols.Rol.IdRol.Equals(priv[1].ToString()))
                            {
                                rols.Rol.privilegios.Add(rolPRiv);
                            }
                        }
                    }
                    else
                    {
                        Usuario_Rol UsuRol = new Usuario_Rol();
                        UsuRol.Rol = new ROL();
                        UsuRol.Rol.IdRol = priv[1].ToString();
                        UsuRol.Rol.Titulo1 = priv[2].ToString();
                        UsuRol.Rol.privilegios.Add(rolPRiv);

                        u.roles.Add(UsuRol);
                    }

                }
                conexion.close();
                return u;

            }


            return null;
        }

       public List<Usuario> ListarUsuarios()
       {
           conexion.open();
           // Create a String to hold the query.
           string query = "SELECT USUARIO.IdUsuario, USUARIO.login, Persona.IdPersona, Persona.Nombres, Persona.Paterno, Persona.Materno FROM            USUARIO INNER JOIN                          Persona ON USUARIO.IdPersona = Persona.IdPersona WHERE        (USUARIO.estado <> 0)";
           List<Usuario> usuarios = new List<Usuario>();
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
               Usuario u = new Usuario();
               u.IdUsuario = item[0].ToString();
               u.Login = item[1].ToString();
               u.Persona = new Persona();
               u.Persona.IdPersona = item[2].ToString();
               u.Persona.Nombres = item[3].ToString();
               u.Persona.Paterno = item[4].ToString();
               u.Persona.Materno = item[5].ToString();

               //Obtener privileios
               String consulta = "SELECT ROL.IdRol, ROL.Titulo FROM  USUARIO_ROL INNER JOIN ROL ON USUARIO_ROL.IdRol = ROL.IdRol WHERE        (USUARIO_ROL.IdUsuario = N'"+u.IdUsuario+"') AND (ROL.estado <> 0)";

               SqlCommand peticion = new SqlCommand(consulta, conexion.get());
               SqlDataReader consultacommanReader = peticion.ExecuteReader();
               DataTable roles = new DataTable();
               roles.Load(consultacommanReader);

               foreach (DataRow priv in roles.Rows)
               {
                   Usuario_Rol ur = new Usuario_Rol();
                   ur.Rol = new ROL();
                   ur.Rol.IdRol = priv[0].ToString();
                   ur.Rol.Titulo1 = priv[1].ToString();

                   u.roles.Add(ur);
               }
               usuarios.Add(u);
           }

           conexion.close();
           return usuarios;
       }

       public void Asignar(List<cambioAsignacion> cambios)
       {
           conexion.open();
           foreach (cambioAsignacion item in cambios)
           {
               
               string query2 = "";
               if (item.usuario)
               {
                   if (item.agregar)
                   {
                       query2 = "insert into USUARIO_ROL values('"+item.idUsuario+"','"+item.idRol+"')";
                     
                   }
                   else if (item.quitar)
                   {
                       query2 = "delete from USUARIO_ROL where IdUsuario='"+item.idUsuario+"' and IdRol='"+item.idRol+"'";
                   }
                   
               }
               else if (item.rol)
               {
                   if (item.agregar)
                   {
                       query2 = "insert into ROL_PRIVILEGIO values('"+item.idRol+"','"+item.idPrivilegio+"')";
                   }
                   else if (item.quitar)
                   {
                       query2 = "delete from ROL_PRIVILEGIO where IdRol='"+item.idRol+"' and IdPrivilegio='"+item.idPrivilegio+"'";
                   }
               }

               SqlCommand queryCommand2;
               queryCommand2 = new SqlCommand(query2, conexion.get());
               queryCommand2.ExecuteNonQuery();
              
           }

           conexion.close();
       
       }

       public String AgregarUsuario(Usuario u)
       {
           conexion.open();
           String codigoPersona;
           String idUsuario;

           SqlDataAdapter cmdAdd = new SqlDataAdapter("agregar_usuario", conexion.get());
           cmdAdd.SelectCommand.CommandType = CommandType.StoredProcedure;

           cmdAdd.SelectCommand.Parameters.AddWithValue("@Nombres", u.Persona.Nombres);
           cmdAdd.SelectCommand.Parameters.AddWithValue("@Paterno ", u.Persona.Paterno);
           cmdAdd.SelectCommand.Parameters.AddWithValue("@apellido", u.Persona.Materno);
           cmdAdd.SelectCommand.Parameters.AddWithValue("@TipoDNI", u.Persona.TipoDNI);
           cmdAdd.SelectCommand.Parameters.AddWithValue("@DNI", u.Persona.DNI);
           cmdAdd.SelectCommand.Parameters.AddWithValue("@FechaNac", u.Persona.FechaNac);
           cmdAdd.SelectCommand.Parameters.AddWithValue("@IdPais", u.Persona.Pais.IdPais);
           cmdAdd.SelectCommand.Parameters.AddWithValue("@IdDepartamento", u.Persona.Departamento.IdDepartamento);
           cmdAdd.SelectCommand.Parameters.AddWithValue("@Distrito", u.Persona.Distrito);
           cmdAdd.SelectCommand.Parameters.AddWithValue("@idusuario", u.IdUsuarioReg);
           cmdAdd.SelectCommand.Parameters.AddWithValue("@login", u.Login);
           cmdAdd.SelectCommand.Parameters.AddWithValue("@passw", u.Passw);




           DataTable dt = new DataTable();
           cmdAdd.Fill(dt);

           DataRow row = dt.Rows[0];

           codigoPersona = Convert.ToString(row["IdPersona"]);
           idUsuario = Convert.ToString(row["IdUsuario"]);
           if (u.Persona.contacto.Count > 0)
           {
               String query = "insert into CONTACTO values ('" + codigoPersona + "'," + u.Persona.contacto[0].Tipo + ",'" + u.Persona.contacto[0].Descripcion + "','" + u.Persona.contacto[0].Valor + "',1,'" + u.IdUsuarioReg + "',GETDATE(),NULL,NULL )";
               foreach (Contacto item in u.Persona.contacto)
               {
                   if (item != u.Persona.contacto[0])
                   {
                       query += ", ('" + codigoPersona + "'," + item.Tipo + ",'" + item.Descripcion + "','" + item.Valor + "',1,'" + u.IdUsuarioReg + "',GETDATE(),NULL,NULL )";
                   }
               }
               SqlCommand queryCommand2 = new SqlCommand(query, conexion.get());

               queryCommand2.ExecuteNonQuery();
           }

           conexion.close();
           return codigoPersona;


       }

       public void Editar(Usuario u)
       {
           conexion.open();
           string query = "update Persona set Nombres ='" + u.Persona.Nombres + "', Paterno='" + u.Persona.Paterno + "', Materno='" + u.Persona.Materno + "', TipoDNI=" + u.Persona.TipoDNI + ", DNI='" + u.Persona.DNI + "',fechaNac='" + u.Persona.FechaNac.ToString("dd/MM/yyyy") + "',IdPais='" + u.Persona.Pais.IdPais + "',IdDepartamento='" + u.Persona.Departamento.IdDepartamento + "',Distrito='" + u.Persona.Distrito + "',idUsuarioMod='" + u.IdUsuarioMod + "', fechaMod = GETDATE() where IdPersona ='" + u.Persona.IdPersona + "'";
           SqlCommand queryCommand = new SqlCommand(query, conexion.get());
           queryCommand.ExecuteNonQuery();

           string query2 = "update USUARIO set login ='" + u.Login + "', passw = '" + u.Passw + "', idUsuarioMod='" + u.IdUsuarioMod + "', fechaMod=GETDATE() where IdUsuario ='" + u.IdUsuario + "'";
           SqlCommand queryCommand2 = new SqlCommand(query2, conexion.get());
           queryCommand2.ExecuteNonQuery();

           foreach (Comedor.Modelo.Auxiliares.cambioUsuario item in u.cambios)
           {
               string query3 = "";

               if (item.agregar)
               {
                   query3 = "insert into CONTACTO values ('" + u.Persona.IdPersona + "'," + item.contact.Tipo + ",'" + item.contact.Descripcion + "','" + item.contact.Valor + "',1,'" + u.IdUsuarioMod + "',GETDATE(),NULL,NULL )";
               }
               else if (item.eliminar)
               {
                   query3 = "delete from CONTACTO where IdPersona='" + u.Persona.IdPersona + "' and Tipo= " + item.contact.Tipo + " and valor = '" + item.contact.Valor + "'";
               }


               SqlCommand queryCommand3 = new SqlCommand(query3, conexion.get());
               queryCommand3.ExecuteNonQuery();

           }
           conexion.close();
       }

       public void Eliminar(Usuario u)
       {
           conexion.open();
           string query = "update Usuario set estado=0, IdUsuarioMod='"+u.IdUsuarioMod+"',fechaMod=GETDATE()  where IdUsuario='"+u.IdUsuario+"'";
           SqlCommand queryCommand = new SqlCommand(query, conexion.get());
           queryCommand.ExecuteNonQuery();          
           conexion.close();
       }

       public Usuario AllDatos(String idUsuario)
       {
           conexion.open();
           
           // Create a String to hold the query.
           string query = "SELECT Persona.IdPersona, Persona.Nombres, Persona.Paterno, Persona.Materno, Persona.TipoDNI, Persona.DNI, Persona.fechaNac, Persona.IdPais, Persona.IdDepartamento, Persona.Distrito, USUARIO.IdUsuario, USUARIO.login, USUARIO.passw, USUARIO.estado FROM Persona INNER JOIN USUARIO ON Persona.IdPersona = USUARIO.IdPersona WHERE (USUARIO.IdUsuario = N'"+idUsuario+"') ";

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
               Usuario u = new Usuario();
               u.Persona = new Persona();
               u.Persona.IdPersona = item[0].ToString();
               u.Persona.Nombres = item[1].ToString();
               u.Persona.Paterno = item[2].ToString();
               u.Persona.Materno = item[3].ToString();
               u.Persona.TipoDNI = int.Parse(item[4].ToString());
               u.Persona.DNI = item[5].ToString();
               u.Persona.FechaNac = DateTime.Parse(item[6].ToString());
               u.Persona.Pais = new Pais();
               u.Persona.Pais.IdPais = item[7].ToString();
               u.Persona.Departamento = new Departamento();
               u.Persona.Departamento.IdDepartamento = item[8].ToString();
               u.Persona.Distrito = item[9].ToString();
               u.IdUsuario = item[10].ToString();
               u.Login = item[11].ToString();
               u.Passw = item[12].ToString();
               u.Estado = int.Parse(item[13].ToString());

               string query2 = "SELECT Tipo, Descripcion, valor, estado FROM CONTACTO WHERE (IdPersona = N'" + u.Persona.IdPersona + "')";
               SqlCommand queryCommand2 = new SqlCommand(query2, conexion.get());
               SqlDataReader queryCommandReader2 = queryCommand2.ExecuteReader();
               DataTable dataTable2 = new DataTable();
               dataTable2.Load(queryCommandReader2);

               foreach (DataRow item2 in dataTable2.Rows)
               {
                   Contacto contact = new Contacto();
                   contact.Persona = u.Persona;
                   contact.Tipo = int.Parse(item2[0].ToString());
                   contact.Descripcion = item2[1].ToString();
                   contact.Valor = item2[2].ToString();
                   contact.Estado = int.Parse(item2[3].ToString());

                   u.Persona.contacto.Add(contact);
               }

               

               return u;

           }


           return null;
       }

       #endregion

       #region metodos propios

       private bool existeRol(List<Usuario_Rol> roles, String idRol)
       {
           foreach (Usuario_Rol rol in roles)
           {
               if (rol.Rol.IdRol.Equals(idRol))
               {
                   return true;
               }
           }
           return false;
       }

       #endregion

   }
}
