using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Comedor.Control
{
   public class conexion
    {
       SqlConnection conex;
       Encryp en = new Encryp();
       public string open()
       {
           String path = Application.StartupPath;
           string carpeta = System.IO.Path.Combine(path, "conections");
           string connStrintext = System.IO.Path.Combine(carpeta, "CNX-SA-" + Dns.GetHostName() + ".txt");
           try
           {
               string cad = File.ReadAllText(connStrintext);
               string cadena = en.Desencriptar(cad);
               conex = new SqlConnection(cadena);

               conex.Open();
               return "ok";
           }
           catch (Exception e)
           {
               return "error";

           }
          
       }

       public SqlConnection get()
       {
           return conex;
       }

       public void close()
       {
           conex.Close();
       }


       public string guardar(String cadenadeConexion)
       {
           String connCrip = en.Encriptar(cadenadeConexion);

           if (testConn(cadenadeConexion))
               {
                   String path = Application.StartupPath;
                   string carpeta = System.IO.Path.Combine(path, "conections");
                   string connStrintext = System.IO.Path.Combine(carpeta, "CNX-SA-" + Dns.GetHostName() + ".txt");

                   if (System.IO.Directory.Exists(carpeta) == false)
                   {
                       System.IO.Directory.CreateDirectory(carpeta);
                   }

                   System.IO.StreamWriter sw = new System.IO.StreamWriter(connStrintext);
                   sw.WriteLine(connCrip);
                   sw.Close();
                   return "ok";
               }
               else
               {
                   return "No Conn";
               }


       }

       public bool testPathAndConn()
       {

           String path = Application.StartupPath;
           string carpeta = System.IO.Path.Combine(path, "conections");
           string connStrintext = System.IO.Path.Combine(carpeta, "CNX-SA-" + Dns.GetHostName() + ".txt");
           try
           {
               string cad = File.ReadAllText(connStrintext);
               string cadena = en.Desencriptar(cad);
               SqlConnection conex = new SqlConnection(cadena);
               conex.Open();
               return true;
           }
           catch (Exception p)
           {
               return false;
           }
       }

       public bool testConn(String conexi)
       {
           bool ok = false;

           try
           {
               SqlConnection conex = new SqlConnection(conexi);
               conex.Open();
               return true;
           }
           catch (Exception p)
           {

           }

           return ok;
       }
    }
}
