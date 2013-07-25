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

namespace Comedor.Vista.Usuarios
{
    public partial class Roles : Form
    {

        #region constructor
        public Roles()
        {
            InitializeComponent();
        }
        #endregion

        #region declaraciones
        List<ROL> roles;
        m_roles _mRoles = new m_roles();

        public Usuario usuario;
        #endregion

        #region metodos propios

        private void Iniciar()
        {
            cargarBD();
            ListarRoles();
        }

        private void cargarBD()
        {
            roles = _mRoles.listarRoles();
        }

        private void ArreglaDataViewRoles()
        {
            if (dgvRoles.Columns.Count > 1) return;
            dgvRoles.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgvRoles.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRoles.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvRoles.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvRoles.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = "ID";
            column.DataPropertyName = "id";
            column.Width = 50;
            column.Visible = false;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRoles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Nombre";
            column.DataPropertyName = "nombre";
            column.Width = 250;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRoles.Columns.Add(column);      

            column = new DataGridViewImageColumn();
            column.HeaderText = "";
            column.DataPropertyName = "editar";
            column.Width = 30;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRoles.Columns.Add(column);


            column = new DataGridViewImageColumn();
            column.HeaderText = "";
            column.DataPropertyName = "Eliminar";
            column.Width = 30;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRoles.Columns.Add(column);


            column = new DataGridViewTextBoxColumn();
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.ReadOnly = true;
            dgvRoles.Columns.Add(column);

            dgvRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoles.MultiSelect = false;
            dgvRoles.AllowUserToResizeColumns = true;
            dgvRoles.AllowUserToResizeRows = false;
            dgvRoles.BorderStyle = BorderStyle.FixedSingle;
            dgvRoles.RowHeadersVisible = false;
            dgvRoles.AllowUserToAddRows = false;
            dgvRoles.AllowUserToDeleteRows = false;
            dgvRoles.AllowUserToOrderColumns = false;
            dgvRoles.ReadOnly = true;

        }

        void ListarRoles()
        {
            dgvRoles.Columns.Clear();
            ArreglaDataViewRoles();
            dgvRoles.Rows.Clear();


            foreach (ROL item in roles) { agregarFila(item); }

            dgvRoles.RowHeadersVisible = false;

        }

        private void agregarFila(ROL item)
        {
            int n = dgvRoles.Rows.Add();
            dgvRoles.Rows[n].Cells[0].Value = item.IdRol;
            dgvRoles.Rows[n].Cells[1].Value = item.Titulo1;
            dgvRoles.Rows[n].Cells[2].Value = Comedor.Vista.Properties.Resources.edit;
            dgvRoles.Rows[n].Cells[3].Value = Comedor.Vista.Properties.Resources.delete;
        }

        private bool IsValidCellAddress(int rowIndex, int columnIndex)
        {
            return rowIndex >= 0 && rowIndex < dgvRoles.RowCount &&
                columnIndex >= 0 && columnIndex <= dgvRoles.ColumnCount;
        }

        #endregion

        #region eventos

        private void Roles_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        #endregion

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (this.usuario.validarPrivilegio("PRI0000025"))
            {
                NuevoRol form = new NuevoRol();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ROL r = new ROL();
                    r.Titulo1 = form.Titulo;
                    _mRoles.agregarRol(r);
                    Iniciar();
                }
            }
            else { NP(); }
        }

        private void dgvRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex))
            {
                if (e.ColumnIndex == 2)
                {
                    if (this.usuario.validarPrivilegio("PRI0000026"))
                    {
                        NuevoRol form = new NuevoRol();
                        form.Titulo = dgvRoles[1, e.RowIndex].Value.ToString();
                        form.edit = true;
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            ROL r = new ROL();
                            r.IdRol = dgvRoles[0, e.RowIndex].Value.ToString();
                            r.Titulo1 = form.Titulo;
                            _mRoles.editarRol(r);
                            Iniciar();
                        }
                    }
                    else { NP(); }
                }
                if (e.ColumnIndex == 3)
                {
                    if (this.usuario.validarPrivilegio("PRI0000027"))
                    {
                        if (MessageBox.Show("¿Desea eliminar este Rol?", "Eliminar Rol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _mRoles.eliminarRol(dgvRoles[0, e.RowIndex].Value.ToString());
                            Iniciar();
                        }
                    }
                    else { NP(); }
                }
                
            }
        }

        private void NP()
        {
            MessageBox.Show("Privilegios Insuficientes");
        }

        private void dgvRoles_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex) && (e.ColumnIndex == 2 || e.ColumnIndex == 3))
            {
                dgvRoles.Cursor = Cursors.Hand;
            }
        }

        private void dgvRoles_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex) && (e.ColumnIndex == 2 || e.ColumnIndex == 3))
            {
                dgvRoles.Cursor = Cursors.Default;
            }
        }


    }
}
