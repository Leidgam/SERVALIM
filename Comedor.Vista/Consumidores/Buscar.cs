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
using Comedor.Modelo;

namespace Comedor.Vista.Consumidores
{
    public partial class Buscar : Form
    {
        List<Consumidor_Periodo> ListGrupo = new List<Consumidor_Periodo>();
        List<Consumidor_Periodo> ListArea = new List<Consumidor_Periodo>();
        public List<Consumidor_Periodo> ListConsumidor = new List<Consumidor_Periodo>();
        public List<Consumidor_Periodo> ListReserva = new List<Consumidor_Periodo>();
        public Usuario usuario;

        public Buscar()
        {
            InitializeComponent();
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            cmbarea.Visible = false;
            cmbgrupo.Visible = false;
            label3.Visible = false;
            label2.Visible = false;
           m_consumidor mc = new m_consumidor();
           this.ListGrupo = mc.ListarGrupoAreaConsumidor(1,this.usuario);
           this.ListArea = mc.ListarGrupoAreaConsumidor(2, this.usuario);
          


         //  llenar();
           Listar();
        }

        private void llenar() {
            cmbarea.DataSource = null;
            cmbarea.DataSource = ListArea;
            cmbgrupo.DataSource = ListGrupo;

            cmbarea.DisplayMember = "Nombre";
        }

        private void ArreglaDataView1()
        {
            if (dgvConsumidor.Columns.Count > 1) return;
            dgvConsumidor.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgvConsumidor.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvConsumidor.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvConsumidor.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvConsumidor.AutoGenerateColumns = false;


            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = "ID";
            column.DataPropertyName = "id";
            column.Width = 50;
            column.Visible = false;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvConsumidor.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.HeaderText = "";
            column.DataPropertyName = "check";
            column.Width = 30;
            column.ReadOnly = false;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvConsumidor.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Codigo";
            column.DataPropertyName = "Codigo";
            column.Width = 80;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgvConsumidor.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Apellidos";
            column.DataPropertyName = "apellido";
            column.Width = 160;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column.ReadOnly = true;
            dgvConsumidor.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Nombres";
            column.DataPropertyName = "nombre";
            column.Width = 160;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column.ReadOnly = true;
            dgvConsumidor.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.ReadOnly = true;
            dgvConsumidor.Columns.Add(column);

            dgvConsumidor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsumidor.MultiSelect = false;
            dgvConsumidor.AllowUserToResizeColumns = true;
            dgvConsumidor.AllowUserToResizeRows = false;
            dgvConsumidor.BorderStyle = BorderStyle.FixedSingle;
            dgvConsumidor.RowHeadersVisible = false;
            dgvConsumidor.AllowUserToAddRows = false;
            dgvConsumidor.AllowUserToDeleteRows = false;
            dgvConsumidor.AllowUserToOrderColumns = false;


        }

        private void Listar()
        {
            checkDGV(dgvConsumidor);
            dgvConsumidor.Columns.Clear();
            ArreglaDataView1();
            dgvConsumidor.Rows.Clear();

            foreach (Consumidor_Periodo item in this.ListConsumidor)
            {
                if ((item.Consumidor.Persona.PrimerNombre + " " + item.Consumidor.Persona.SegundoNombre).ToUpper().Contains(txtNombreApellido.Text.ToUpper()) || (item.Consumidor.Persona.Apellidos.ToUpper().Contains(txtNombreApellido.Text.ToUpper())))
                {
                    int n = dgvConsumidor.Rows.Add();
                    dgvConsumidor.Rows[n].Cells[0].Value = item.Consumidor.IdConsumidor;
                    dgvConsumidor.Rows[n].Cells[1].Value = item.Consumidor.marcado;
                    dgvConsumidor.Rows[n].Cells[2].Value = item.Codigo;
                    dgvConsumidor.Rows[n].Cells[3].Value = item.Consumidor.Persona.Apellidos;
                    dgvConsumidor.Rows[n].Cells[4].Value = item.Consumidor.Persona.PrimerNombre + " " + item.Consumidor.Persona.SegundoNombre;
                }
            }

            dgvConsumidor.RowHeadersVisible = false;

        }

        private void checkDGV(DataGridView dgv)
        {
            foreach (DataGridViewRow item in dgv.Rows)
            {
                String idConsumidor = item.Cells[0].Value.ToString();

                foreach (Consumidor_Periodo cons in ListConsumidor)
                {
                    if (cons.Consumidor.IdConsumidor.Equals(idConsumidor))
                    {
                        if (item.Cells[1].Value == null) 
                        { 
                            cons.Consumidor.marcado = false;
                     
                        }
                        else 
                        {
                            cons.Consumidor.marcado = (bool)item.Cells[1].Value;
                        
                        }
                    }
                }
            }
        }

        private void rbnSelectTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnSelectTodo.Checked)
            {
                foreach (DataGridViewRow item in dgvConsumidor.Rows)
                {
                    item.Cells[1].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow item in dgvConsumidor.Rows)
                {
                    item.Cells[1].Value = false;
                }
            }
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            

            string message = "Enviar?";
            string caption = "Confirmación";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                
                checkDGV(dgvConsumidor);
                foreach (Consumidor_Periodo item in this.ListConsumidor)
                {
                    if (item.Consumidor.marcado)
                    {
                        Consumidor_Periodo cp = new Consumidor_Periodo();
                        cp.Codigo = item.Codigo;
                        ListReserva.Add(cp);
  
                    }
                }
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void txtNombreApellido_TextChanged(object sender, EventArgs e)
        {
            Listar();
        }

       


    }
}
