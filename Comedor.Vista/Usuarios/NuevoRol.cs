using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comedor.Vista.Usuarios
{
    public partial class NuevoRol : Form
    {

        #region constructor
        public NuevoRol()
        {
            InitializeComponent();
        }
        #endregion

        #region declaraciones

        public String Titulo;
        public bool edit;


        #endregion

        private void NuevoRol_Load(object sender, EventArgs e)
        {
            if (edit)
            {
                txtTitulo.Text = Titulo;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Titulo = txtTitulo.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
