using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comedor.Modelo;
using Comedor.Control;

namespace Comedor.Vista.Configuracion
{
    public partial class SelectGrupo : Form
    {
        #region constructor
        public SelectGrupo()
        {
            InitializeComponent();
        }
      

        #endregion

        #region declaraciones
        List<Grupo> grupos;
        m_Grupo _mGrupo = new m_Grupo();

        Grupo eleccion;
        #endregion

        #region metodos propios

        private void Iniciar()
        {
            cargarBD();
            cargarGrupos();
        }

        private void cargarBD()
        {
            grupos = _mGrupo.ListarAllGrupos();
        }

        private void cargarGrupos()
        {
            cmbGrupos.DataSource = this.grupos;
            cmbGrupos.DisplayMember = "Nombre";
        }

        #endregion

        #region metodos externos
        public Grupo getEleccion()
        {
            return eleccion;
        }
        #endregion     

        #region eventos

        private void button1_Click(object sender, EventArgs e)
        {
            eleccion = (Grupo)cmbGrupos.SelectedItem;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SelectGrupo_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        #endregion

        
    }
}
