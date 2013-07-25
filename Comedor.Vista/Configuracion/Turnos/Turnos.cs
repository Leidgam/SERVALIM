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
    public partial class Turnos : Form
    {
        #region constructor
        public Turnos()
        {
            InitializeComponent();
        }
        #endregion

        #region declaraciones

        public Usuario usuario;

        m_Dia _mDia = new m_Dia();
        List<DIA> dias;

        m_Turno _mTurno = new m_Turno();
        List<TURNO> turnos;

        #endregion

        #region metodos propios

        private void Iniciar()
        {
            cmbTiempo.SelectedIndex = 3;     
            cargarBD();
            cargarDias();
            
        }

        private void cargarDias()
        {
            cmbDia.DataSource = this.dias;
            cmbDia.DisplayMember = "Nombre";
        }

        private void cargarBD()
        {
            turnos = _mTurno.ListarTurnos();

            dias = _mDia.ListarAllDias();
            DIA dia = new DIA();
            dia.IdDia = "008";
            dia.Nombre = "Todos los dias";
            dia.Estado = 1;
            dias.Add(dia);
        }

        private void ArreglaDataViewTurnos()
        {
            if (dgvTurnos.Columns.Count > 1) return;
            dgvTurnos.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgvTurnos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTurnos.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvTurnos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvTurnos.AutoGenerateColumns = false;
           

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = "ID";
            column.DataPropertyName = "id";
            column.Width = 50;
            column.Visible = false;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvTurnos.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.HeaderText = "";
            column.DataPropertyName = "check";
            column.Width = 30;
            column.ReadOnly = false;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTurnos.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "DIA";
            column.DataPropertyName = "dia";
            column.Width = 80;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column.ReadOnly = true;
            dgvTurnos.Columns.Add(column);
            

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "";
            column.DataPropertyName = "tiempo";
            column.Width = 80;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column.ReadOnly = true;
            dgvTurnos.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "TURNO";
            column.DataPropertyName = "turno";
            column.Width = 80;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column.ReadOnly = true;
            dgvTurnos.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "HORA INCIO";
            column.DataPropertyName = "tiempo";
            column.Width = 80;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvTurnos.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "HORA FIN";
            column.DataPropertyName = "tiempo";
            column.Width = 80;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvTurnos.Columns.Add(column);


            column = new DataGridViewImageColumn();
            column.HeaderText = "";
            column.DataPropertyName = "editar";
            column.Width = 30;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTurnos.Columns.Add(column);


            column = new DataGridViewImageColumn();
            column.HeaderText = "";
            column.DataPropertyName = "Eliminar";
            column.Width = 30;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTurnos.Columns.Add(column);


            column = new DataGridViewTextBoxColumn();
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.ReadOnly = true;
            dgvTurnos.Columns.Add(column);

            dgvTurnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTurnos.MultiSelect = false;
            dgvTurnos.AllowUserToResizeColumns = true;
            dgvTurnos.AllowUserToResizeRows = false;
            dgvTurnos.BorderStyle = BorderStyle.FixedSingle;
            dgvTurnos.RowHeadersVisible = false;
            dgvTurnos.AllowUserToAddRows = false;
            dgvTurnos.AllowUserToDeleteRows = false;
            dgvTurnos.AllowUserToOrderColumns = false;
            

        }

        void ListarTurnos()
        {
            dgvTurnos.Columns.Clear();
            ArreglaDataViewTurnos();
            dgvTurnos.Rows.Clear();

            DIA dia = (DIA)cmbDia.SelectedItem;
            foreach (TURNO item in this.turnos)
            {

                if ((item.Dia.IdDia.Equals(dia.IdDia) && (cmbTiempo.SelectedIndex + 1) == item.DesAlmCen) || (cmbTiempo.SelectedIndex == 3 && item.Dia.IdDia.Equals(dia.IdDia)) || ((((DIA)cmbDia.SelectedItem).IdDia.Equals("008")) && (cmbTiempo.SelectedIndex + 1) == item.DesAlmCen) || ((((DIA)cmbDia.SelectedItem).IdDia.Equals("008")) && cmbTiempo.SelectedIndex == 3))
                {
                    //Determinar tiempo
                    String tiempo = "";
                    if (item.DesAlmCen == 1) { tiempo = "Desayuno"; } else if (item.DesAlmCen == 2) { tiempo = "Almuerzo"; } else if (item.DesAlmCen == 3) { tiempo = "Cena"; }
                    //

                    int n = dgvTurnos.Rows.Add();
                    dgvTurnos.Rows[n].Cells[0].Value = item.IdTurno;
                   
                    dgvTurnos.Rows[n].Cells[2].Value = item.Dia.Nombre;
                    dgvTurnos.Rows[n].Cells[3].Value = tiempo;
                    dgvTurnos.Rows[n].Cells[4].Value = "Turno "+ item.Item;
                    dgvTurnos.Rows[n].Cells[5].Value = DateTime.Today.Add(item.HoraInicio).ToString("hh:mm tt");
                    dgvTurnos.Rows[n].Cells[6].Value = DateTime.Today.Add(item.HoraFin).ToString("hh:mm tt");
                    dgvTurnos.Rows[n].Cells[7].Value = Comedor.Vista.Properties.Resources.edit;
                    dgvTurnos.Rows[n].Cells[8].Value = Comedor.Vista.Properties.Resources.delete;
                }
            }
            dgvTurnos.RowHeadersVisible = false;

        }

        private bool IsValidCellAddress(int rowIndex, int columnIndex)
        {
            return rowIndex >= 0 && rowIndex < dgvTurnos.RowCount &&
                columnIndex >= 0 && columnIndex <= dgvTurnos.ColumnCount;
        }
        
        #endregion

        #region eventos

        private void Turnos_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void cmbDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarTurnos();
        }

        private void cmbTiempo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.turnos != null)
            {
                ListarTurnos();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                foreach (DataGridViewRow item in dgvTurnos.Rows)
                {
                    item.Cells[1].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow item in dgvTurnos.Rows)
                {
                    item.Cells[1].Value = false;
                }
            }
        }

        private void btnNuevoTurno_Click(object sender, EventArgs e)
        {
            NuevoTurno form = new NuevoTurno();
            form.usuario = this.usuario;
            form.dias = this.dias;
            var show = form.ShowDialog();
            if (show == DialogResult.OK)
            {
                Iniciar();
            }
        }

        private void dgvTurnos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex) && (e.ColumnIndex == 7 || e.ColumnIndex == 8))
            {
                dgvTurnos.Cursor = Cursors.Hand;
            }
        }

        private void dgvTurnos_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex) && (e.ColumnIndex == 8 || e.ColumnIndex == 7))
            {
                dgvTurnos.Cursor = Cursors.Default;
            }
        }

        private void dgvTurnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex))
            {
                if (e.ColumnIndex == 7)
                {
                    NuevoTurno form = new NuevoTurno();
                    form.editar = true;
                    form.dias = this.dias;
                    foreach (TURNO item in this.turnos)
                    {
                        if (item.IdTurno.Equals(dgvTurnos[0, e.RowIndex].Value.ToString()))
                        {
                            form.editTurno = item;
                        }
                    }
                    form.usuario = this.usuario;
                    DialogResult show = form.ShowDialog();

                    if (show == DialogResult.OK)
                    {
                        Iniciar();
                    }

                }
                else if (e.ColumnIndex == 8)
                {
                    if (MessageBox.Show("Desea eliminar este turno ?", "Eliminar Turno", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_mTurno.cantidadGrupos(dgvTurnos[0, e.RowIndex].Value.ToString()) > 0)
                        {
                            MessageBox.Show("Existen grupos asignados a este turno, REASIGNELOS antes de eliminar");
                            return;
                        }
                        else
                        {
                            TURNO turno = new TURNO();
                            turno.IdUsuarioMod = this.usuario.IdUsuario;
                            turno.IdTurno = dgvTurnos[0, e.RowIndex].Value.ToString();

                            _mTurno.EliminarTurno(turno);
                            Iniciar();
                        }
                    }
                    
                }
            }

        }

        #endregion
  
       
    }
}
