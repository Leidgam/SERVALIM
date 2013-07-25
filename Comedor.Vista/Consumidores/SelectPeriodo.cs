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

namespace Comedor.Vista.Consumidores
{
    public partial class SelectPeriodo : Form
    {
        public SelectPeriodo()
        {
            InitializeComponent();
        }
        #region declaraciones
        List<Periodo> periodos;
        m_Periodo _mPeriodo = new m_Periodo();

        Periodo periodo;
        public bool todos = false;
        #endregion

        #region metodos

        private void Iniciar()
        {
            periodos = _mPeriodo.ListarTodosLosPeriodos();
            if (todos)
            {
                Periodo p = new Periodo();
                p.IdPeriodo = "000";
                p.Descripcion = "Todos";

                periodos.Add(p);
            }
            comboBox1.DataSource = periodos;
            comboBox1.DisplayMember = "Descripcion";
        }

        public Periodo getPeriodo()
        {
            return this.periodo;
        }

        #endregion

        

        #region eventos

        private void SelectPeriodo_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            periodo = (Periodo)comboBox1.SelectedItem;
            DialogResult = DialogResult.OK;
        }

        #endregion

        
    }
}
