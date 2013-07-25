using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Comedor.Control
{
   public class conexion
    {
       SqlConnection conex;

       public void open()
       {
           
           try
           {
               string cad = "Data Source=UPG_INGENIERIA\\UPGINGENIERIA;Initial Catalog=SERV-ALIM;Persist Security Info=True;User ID=sa; Password=guille123456";
               conex = new SqlConnection(cad);

               conex.Open();
           }
           catch (Exception e)
           {

               MessageBox.Show("Salir");

               MessageBox.Show("Error al intentar conectar con Base de Datos");

               Application.Exit();
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
    }
}
