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
    public partial class Consumidores : Form
    {
        #region constructor
        public Consumidores()
        {
            InitializeComponent();
        }
        #endregion

        #region declaraciones

        public Usuario usuario;
        public Grupo grupo;
        Periodo periodo;
        m_consumidor _mConsumidor = new m_consumidor();
        m_Periodo _mPeriodo = new m_Periodo();
        #endregion

        #region metodos propios

        private void Iniciar()
        {

            cargarBD();
            ListarConsumidores();
        }

        private void cargarBD()
        {
            periodo = _mPeriodo.getActual();
            grupo.consumidores = _mConsumidor.ListarConsumidores(periodo.IdPeriodo, grupo.IdGrupo);

        }

        private void ArreglaDataViewCons(DataGridView dgv)
        {
            if (dgv.Columns.Count > 1) return;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.AutoGenerateColumns = false;


            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = "ID";
            column.DataPropertyName = "id";
            column.Width = 50;
            column.Visible = false;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "No";
            column.DataPropertyName = "no";
            column.Width = 30;
            column.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.HeaderText = "";
            column.DataPropertyName = "check";
            column.Width = 30;
            column.ReadOnly = false;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Cod";
            column.DataPropertyName = "cod";
            column.Width = 80;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgv.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Nombres";
            column.DataPropertyName = "nombre";
            column.Width = 200;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column.ReadOnly = true;
            dgv.Columns.Add(column);


            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Apellidos";
            column.DataPropertyName = "Apellidos";
            column.Width = 200;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column.ReadOnly = true;
            dgv.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.ReadOnly = true;
            dgv.Columns.Add(column);

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.AllowUserToResizeRows = false;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;

        }

        void ListarConsumidores()
        {
            try
            {
                checkDGV(dgvConsumidores);
                dgvConsumidores.Columns.Clear();
                ArreglaDataViewCons(dgvConsumidores);
                dgvConsumidores.Rows.Clear();


                foreach (consumidor item in grupo.consumidores) { if (filtroSencible(item)) { agregarFila(item); } }

                dgvConsumidores.RowHeadersVisible = false;
            }
            catch (Exception ex)
            {
                this.Close();
            }

        }

        private bool filtroSencible(consumidor item)
        {
            return item.codigo(periodo.IdPeriodo).ToUpper().Contains(txtCodigo.Text.ToUpper()) && ((item.Persona.Nombres+" "+item.Persona.Paterno).ToUpper().Contains(txtNombre.Text.ToUpper()) || item.Persona.Materno.ToUpper().Contains(txtNombre.Text.ToUpper()));
        }

        private void agregarFila(consumidor item)
        {
            int n = dgvConsumidores.Rows.Add();
            dgvConsumidores.Rows[n].Cells[0].Value = item.IdConsumidor;
            dgvConsumidores.Rows[n].Cells[1].Value = n+1;
            if (item.marcado) { dgvConsumidores.Rows[n].Cells[2].Value = true; }
            dgvConsumidores.Rows[n].Cells[3].Value = item.codigo(periodo.IdPeriodo);
            dgvConsumidores.Rows[n].Cells[4].Value = item.Persona.Nombres ;
            dgvConsumidores.Rows[n].Cells[5].Value = item.Persona.Paterno + " " + item.Persona.Materno;

        }

        private void checkDGV(DataGridView dgv)
        {
            foreach (DataGridViewRow item in dgv.Rows)
            {
                String idConsumidor = item.Cells[0].Value.ToString();

                foreach (consumidor cons in grupo.consumidores)
                {
                    if (cons.IdConsumidor.Equals(idConsumidor))
                    {
                        if (item.Cells[2].Value == null) { cons.marcado = false; }
                        else { cons.marcado = (bool)item.Cells[2].Value; }
                    }
                }
            }
        }

        #endregion  

        #region eventos

        private void Consumidores_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            ListarConsumidores();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            ListarConsumidores();
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked) { foreach (DataGridViewRow item in dgvConsumidores.Rows) { item.Cells[2].Value = true; } }
            else { foreach (DataGridViewRow item in dgvConsumidores.Rows) { item.Cells[2].Value = false; } }
        }

        private void btnReasignar_Click(object sender, EventArgs e)
        {
            SelectGrupo form = new SelectGrupo();
            var show = form.ShowDialog();
            if (show == DialogResult.OK)
            {
                Grupo asignar = form.getEleccion();
                if (asignar.IdGrupo.Equals(this.grupo.IdGrupo)) { MessageBox.Show("No se puede reasignar al mismo grupo"); }
                else { Reasignar(asignar.IdGrupo); }
            }
        }

        private void Reasignar(String idGrupo)
        {
            checkDGV(dgvConsumidores);
            List<consumidor> consum = new List<consumidor>();
            foreach (consumidor item in grupo.consumidores)
            {
                if (item.marcado) { consum.Add(item); }
            }
            if (consum.Count == 0) { MessageBox.Show("Ningun consumidor seleccionado"); return; }
            consum[0].IdUsuarioMod = this.usuario.IdUsuario;
            
            _mConsumidor.ReasignarGrupo(consum, idGrupo);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion

        

        

       
    }
}
