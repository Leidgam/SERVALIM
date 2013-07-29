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
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }
        #region declaraciones
        conexion conexion = new conexion();

        //Guradar conexion
        public bool guardarConn = false;
        public string StringConnection;
        
        #endregion

        #region eventos

        private void Loading_Load(object sender, EventArgs e)
        {
            if (guardarConn)
            {
                guardarConnexion.RunWorkerAsync();
            }
        }

        private void guardarConnexion_DoWork(object sender, DoWorkEventArgs e)
        {
            if (conexion.guardar(StringConnection).Equals("ok"))
            {

            }
        }
        #endregion


    }
}
