using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comedor.Vista.Consumidores.Confirmacion
{
    public partial class Rechazar : Form
    {
        public Rechazar()
        {
            InitializeComponent();
        }
        public string motivo;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("Escriba el motivo !!"); }
            else
            {
                motivo = textBox1.Text;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
