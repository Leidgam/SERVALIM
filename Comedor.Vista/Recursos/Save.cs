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

namespace Comedor.Vista.Recursos
{
    public partial class Save : Form
    {
        public List<consumidor> guardar;
        m_consumidor _mConsumidor = new m_consumidor();
        public String idPeriodo;
        public Save()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _mConsumidor.Matricular(guardar, idPeriodo);
            for (int f = 0; f == guardar.Count; f++)
            {
                backgroundWorker1.ReportProgress(f);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Save_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = guardar.Count;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;

            lblPorcentaje.Text = e.ProgressPercentage.ToString();
        }
    }
}
