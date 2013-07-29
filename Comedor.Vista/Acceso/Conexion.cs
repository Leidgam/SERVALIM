using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comedor.Control;

namespace Comedor.Vista.Acceso
{
    public partial class Conexion : Form
    {
        public Conexion()
        {
            InitializeComponent();
        }
        conexion conexion = new conexion();
        private void btnGuardar_Click(object sender, EventArgs e)
        {
             String server = txtServer.Text;
            String user = txtUser.Text;
            String passw = txtPasswd.Text;
            String bd = txtDataBase.Text;
            String StringConnection = "Data Source=" + server + ";Initial Catalog=" + bd + ";Persist Security Info=True;User ID=" + user + "; Password=" + passw;

            if (MessageBox.Show("Está seguro que desea Cambiar los Datos de Conexion???", "Confirmar Camibar a " + bd, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Loading form = new Loading();
                form.guardarConn = true;
                form.StringConnection = StringConnection;
                form.Show();
                this.Hide();

            }
        }
    }
}
