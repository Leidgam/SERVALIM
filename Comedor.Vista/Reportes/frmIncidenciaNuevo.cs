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

namespace Comedor.Vista
{
    public partial class frmIncidenciaNuevo : Form
    {
        public  Usuario usuario;
        KeyPressEventArgs temp;
        consumidor datosconsumidor;
        String idconsumidor = "";

        public frmIncidenciaNuevo()
        {
            InitializeComponent();
        }
        void iniciar()
        {
            m_consumidor mm = new m_consumidor();
            if (mm.existeconsumidor(txtCodigo.Text) != 1)
            {
                MessageBox.Show("Codigo invalido");
                txtCodigo.Text = "";
                return;
            }
            idconsumidor = mm.IdConsumidor(txtCodigo.Text);
            datosconsumidor = new consumidor();
            datosconsumidor = mm.Consumidor_reg(idconsumidor);
            txtnombre.Text = datosconsumidor.Persona.Materno + " " + datosconsumidor.Persona.Nombres;
        
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                return;
            }
            temp = e;
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                }
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (temp != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Lo que hará al presionarse Enter

                    iniciar();
                }
            }
        }

        private void frmIncidenciaNuevo_Load(object sender, EventArgs e)
        {
            cmbGravedad.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "" || txtnombre.Text == "")
            {
                MessageBox.Show("Por favor complete todos los espacios en blanco");
                return;
            }
            Incidencia i = new Incidencia();
            i.Descripcion = txtDescripcion.Text;
            i.Tipo = int.Parse(cmbGravedad.SelectedItem.ToString());
            i.Consumidor = new consumidor();
            i.Consumidor.IdConsumidor = idconsumidor;
            i.FechaHora = dtpFecha.Value.Date;

            m_consumidor _mConsumidor = new m_consumidor();
            _mConsumidor.AgregarIncidencia(i, usuario.IdUsuario);
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
