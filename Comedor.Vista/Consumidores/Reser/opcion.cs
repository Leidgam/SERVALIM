using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comedor.Vista.Consumidores.Reservas
{
    public partial class opcion : Form
    {
        public int recibir;
        int devolver;

        public int getOpcion()
        {
            return devolver;
        }
        public opcion()
        {
            InitializeComponent();
        }

        private void opcion_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            devolver = comboBox1.SelectedIndex;
            if (recibir == devolver)
            {
                MessageBox.Show("Esta opción es la actual !!");
            }
            else
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
