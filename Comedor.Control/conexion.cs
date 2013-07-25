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
               string cad = "Data Source=JMGDIEL\\MYSERVER;Initial Catalog=SERV-ALIM;Persist Security Info=True;User ID=sa; Password=sa";
               conex = new SqlConnection(cad);

               conex.Open();
           }
           catch (Exception e)
           {
               MessageBox.Show("Erro al intentar conectar con Base de Datos");
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
