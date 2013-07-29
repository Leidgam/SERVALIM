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
        public bool conexionGuardada = false;

        //Iniciar
        public bool iniciar = false;
        public bool inicioCorrecto = false;

        #endregion

        #region eventos

        private void Loading_Load(object sender, EventArgs e)
        {
            if (guardarConn)
            {
                guardarConnexion.RunWorkerAsync();
            }
            if (iniciar)
            {
                Begin.RunWorkerAsync();
            }

        }

        private void guardarConnexion_DoWork(object sender, DoWorkEventArgs e)
        {
            if (conexion.guardar(StringConnection).Equals("ok"))
            {
                conexionGuardada = true;
            }
            else
            {
                conexionGuardada = false;
            }
        }

        
        #endregion

        private void guardarConnexion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (conexionGuardada)
            {
                Logueo form = new Logueo();
                form.Show();
                this.Hide();
            }
            else
            {
                
                Conexion form = new Conexion();
                form.Show();
                this.Hide();
            }
        }

        private void Begin_DoWork(object sender, DoWorkEventArgs e)
        {
            if (conexion.testPathAndConn())
            {
                inicioCorrecto = true;
            }
            else
            {
                inicioCorrecto = false;
            }
        }

        private void Begin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (inicioCorrecto)
            {
                Logueo form = new Logueo();
                form.Show();
                this.Hide();
            }
            else
            {
                Conexion form = new Conexion();
                form.Show();
                this.Hide();
            }
        }


    }
}
