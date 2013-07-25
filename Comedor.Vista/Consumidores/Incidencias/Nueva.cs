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

namespace Comedor.Vista.Consumidores.Incidencias
{
    public partial class Nueva : Form
    {
        public Nueva()
        {
            InitializeComponent();
        }

        public void setTitulo(String titulo)
        {
            this.Text = titulo;
        }
        public Usuario usuario;
        public string idConsumidor;

        private void button1_Click(object sender, EventArgs e)
        {
            Incidencia i = new Incidencia();
            i.Descripcion = textBox1.Text;
            i.Tipo = comboBox1.SelectedIndex;
            i.Consumidor = new consumidor();
            i.Consumidor.IdConsumidor = idConsumidor;
            i.FechaHora = dateTimePicker1.Value.Date;

            m_consumidor _mConsumidor = new m_consumidor();
            _mConsumidor.AgregarIncidencia(i, usuario.IdUsuario);
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
