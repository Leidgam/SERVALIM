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

namespace Comedor.Vista.Consumidores.Bolsas
{
    public partial class Entrega : Form
    {
        public Entrega()
        {
            InitializeComponent();
        }
        public RegistroBolsa datos = new RegistroBolsa();
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            datos.Persona = textBox1.Text;
            datos.Motivo = textBox2.Text;
            datos.FechaHora = dateTimePicker1.Value.Date;
            datos.Hora = dtpHora.Value.TimeOfDay;
            this.Close();
        }
    }
}
