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

namespace Comedor.Vista.Usuarios
{
    public partial class Mantenimiento : Form
    {

        #region constructor

        public Mantenimiento()
        {
            InitializeComponent();
        }

    
        #endregion

        #region declaraciones

        public Usuario usuario;
        List<Usuario> usuarios;
        m_Usuario _mUsuario = new m_Usuario();

        #endregion

        #region metodos propios

        private void Iniciar()
        {
            cargarBD();
            ListarUsuarios();
        }

        private void cargarBD()
        {
            usuarios = _mUsuario.ListarUsuarios();
        }

        private void ArreglaDataViewGrupos()
        {
            if (dgvUsuarios.Columns.Count > 1) return;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvUsuarios.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvUsuarios.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = "ID";
            column.DataPropertyName = "id";
            column.Width = 50;
            column.Visible = false;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvUsuarios.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Usuario";
            column.DataPropertyName = "usuario";
            column.Width = 120;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvUsuarios.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Nombre";
            column.DataPropertyName = "ombre";
            column.Width = 120;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvUsuarios.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Apellidos";
            column.DataPropertyName = "Apellidos";
            column.Width = 150;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvUsuarios.Columns.Add(column);


            column = new DataGridViewImageColumn();
            column.HeaderText = "";
            column.DataPropertyName = "paswordChange";
            column.Width = 30;
            column.Visible = false;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuarios.Columns.Add(column);

            column = new DataGridViewImageColumn();
            column.HeaderText = "";
            column.DataPropertyName = "foto";
            column.Width = 30;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuarios.Columns.Add(column);

            column = new DataGridViewImageColumn();
            column.HeaderText = "";
            column.DataPropertyName = "editar";
            column.Width = 30;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuarios.Columns.Add(column);


            column = new DataGridViewImageColumn();
            column.HeaderText = "";
            column.DataPropertyName = "Eliminar";
            column.Width = 30;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuarios.Columns.Add(column);


            column = new DataGridViewTextBoxColumn();
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.ReadOnly = true;
            dgvUsuarios.Columns.Add(column);

            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.AllowUserToResizeColumns = true;
            dgvUsuarios.AllowUserToResizeRows = false;
            dgvUsuarios.BorderStyle = BorderStyle.FixedSingle;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AllowUserToOrderColumns = false;
            dgvUsuarios.ReadOnly = true;

        }

        void ListarUsuarios()
        {
            dgvUsuarios.Columns.Clear();
            ArreglaDataViewGrupos();
            dgvUsuarios.Rows.Clear();


            foreach (Usuario item in usuarios) { agregarFila(item); } 

            dgvUsuarios.RowHeadersVisible = false;

        }

        private void agregarFila(Usuario item)
        {
            int n = dgvUsuarios.Rows.Add();
            dgvUsuarios.Rows[n].Cells[0].Value = item.IdUsuario;
            dgvUsuarios.Rows[n].Cells[1].Value = item.Login;
            dgvUsuarios.Rows[n].Cells[2].Value = item.Persona.Nombres + " " + item.Persona.Paterno;
            dgvUsuarios.Rows[n].Cells[3].Value = item.Persona.Materno;
            dgvUsuarios.Rows[n].Cells[4].Value = Comedor.Vista.Properties.Resources.male_female_users;
            dgvUsuarios.Rows[n].Cells[5].Value = Comedor.Vista.Properties.Resources.search_image;
            dgvUsuarios.Rows[n].Cells[6].Value = Comedor.Vista.Properties.Resources.edit;
            dgvUsuarios.Rows[n].Cells[7].Value = Comedor.Vista.Properties.Resources.delete;
        }

        private bool IsValidCellAddress(int rowIndex, int columnIndex)
        {
            return rowIndex >= 0 && rowIndex < dgvUsuarios.RowCount &&
                columnIndex >= 0 && columnIndex <= dgvUsuarios.ColumnCount;
        }

        #endregion    

        private void Mantenimiento_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void dgvUsuarios_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex) && (e.ColumnIndex == 6 || e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 7))
            {
                dgvUsuarios.Cursor = Cursors.Hand;
            }
        }

        private void dgvUsuarios_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex) && (e.ColumnIndex == 6 || e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 7))
            {
                dgvUsuarios.Cursor = Cursors.Default;
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex))
            {
                if (e.ColumnIndex == 6)
                {
                    if (this.usuario.validarPrivilegio("PRI0000023"))
                    {
                        String idUsuario = dgvUsuarios[0, e.RowIndex].Value.ToString();
                        Usuario user = _mUsuario.AllDatos(idUsuario);
                        Consumidores.Nuevo form = new Consumidores.Nuevo();
                        form.usuario = this.usuario;
                        form._editUser = true;
                        form._userMNT = true;
                        form.persona = user.Persona;
                        form._mntUsuario = user;
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            Iniciar();
                        }
                    }
                    else { NP(); }
                }
                if (e.ColumnIndex == 5)
                {
                    Consumidores.foto form = new Consumidores.foto();
                    String idUsuario = dgvUsuarios[0, e.RowIndex].Value.ToString();

                    foreach (Usuario item in usuarios)
                    {
                        if (item.IdUsuario.Equals(idUsuario))
                        {
                            form.idPersona = item.Persona.IdPersona;
                        }
                    }
                    form.ShowDialog();

                }

                if (e.ColumnIndex == 7)
                {
                    if (this.usuario.validarPrivilegio("PRI0000024"))
                    {
                        if (MessageBox.Show("¿Desea eliminar a este Usuario?", "Eliminar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Usuario u = new Usuario();
                            u.IdUsuario = dgvUsuarios[0, e.RowIndex].Value.ToString();
                            u.IdUsuarioMod = this.usuario.IdUsuario;
                            _mUsuario.Eliminar(u);
                            Iniciar();
                        }
                    }
                    else { NP(); }
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (this.usuario.validarPrivilegio("PRI0000023"))
            {
                Comedor.Vista.Consumidores.Nuevo form = new Consumidores.Nuevo();
                form.usuario = this.usuario;
                form._userMNT = true;
                if (form.ShowDialog() == DialogResult.OK)
                {

                }
            }
            else { NP(); }
        }

        private void NP()
        {
            MessageBox.Show("Privilegios Insuficientes");
        }
      

        #region eventos


        #endregion
    }
}
