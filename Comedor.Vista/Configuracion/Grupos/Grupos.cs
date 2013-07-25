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

namespace Comedor.Vista.Configuracion
{
    public partial class Grupos : Form
    {

        #region constructor

        public Grupos()
        {
            InitializeComponent();
        }

        #endregion

        #region declaraciones

        public Usuario usuario;
        List<Grupo> grupos;
        m_Grupo _mGrupo = new m_Grupo();

        #endregion

        #region metodos propios

        private void Iniciar()
        {
            cargarBD();
            ListarGrupos();
        }

        private void cargarBD()
        {
            grupos = _mGrupo.ListarAllGrupos();
        }

        private void ArreglaDataViewGrupos()
        {
            if (dgvGrupos.Columns.Count > 1) return;
            dgvGrupos.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgvGrupos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrupos.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvGrupos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvGrupos.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = "ID";
            column.DataPropertyName = "id";
            column.Width = 50;
            column.Visible = false;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvGrupos.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Nombre";
            column.DataPropertyName = "nombre";
            column.Width = 180;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvGrupos.Columns.Add(column);


            column = new DataGridViewImageColumn();
            column.HeaderText = "";
            column.DataPropertyName = "consumidores";
            column.Width = 30;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrupos.Columns.Add(column);

            column = new DataGridViewImageColumn();
            column.HeaderText = "";
            column.DataPropertyName = "turnos";
            column.Width = 30;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrupos.Columns.Add(column);

            column = new DataGridViewImageColumn();
            column.HeaderText = "";
            column.DataPropertyName = "editar";
            column.Width = 30;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrupos.Columns.Add(column);


            column = new DataGridViewImageColumn();
            column.HeaderText = "";
            column.DataPropertyName = "Eliminar";
            column.Width = 30;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrupos.Columns.Add(column);


            column = new DataGridViewTextBoxColumn();
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.ReadOnly = true;
            dgvGrupos.Columns.Add(column);

            dgvGrupos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGrupos.MultiSelect = false;
            dgvGrupos.AllowUserToResizeColumns = true;
            dgvGrupos.AllowUserToResizeRows = false;
            dgvGrupos.BorderStyle = BorderStyle.FixedSingle;
            dgvGrupos.RowHeadersVisible = false;
            dgvGrupos.AllowUserToAddRows = false;
            dgvGrupos.AllowUserToDeleteRows = false;
            dgvGrupos.AllowUserToOrderColumns = false;
            dgvGrupos.ReadOnly = true;

        }

        void ListarGrupos()
        {
            dgvGrupos.Columns.Clear();
            ArreglaDataViewGrupos();
            dgvGrupos.Rows.Clear();


            foreach (Grupo item in grupos) { agregarFila(item); } 

            dgvGrupos.RowHeadersVisible = false;

        }

        private void agregarFila(Grupo item)
        {
            int n = dgvGrupos.Rows.Add();
            dgvGrupos.Rows[n].Cells[0].Value = item.IdGrupo;
            dgvGrupos.Rows[n].Cells[1].Value = item.Nombre;
            dgvGrupos.Rows[n].Cells[2].Value = Comedor.Vista.Properties.Resources.male_female_users;
            dgvGrupos.Rows[n].Cells[3].Value = Comedor.Vista.Properties.Resources.book;
            dgvGrupos.Rows[n].Cells[4].Value = Comedor.Vista.Properties.Resources.edit;
            dgvGrupos.Rows[n].Cells[5].Value = Comedor.Vista.Properties.Resources.delete;
        }

        private bool IsValidCellAddress(int rowIndex, int columnIndex)
        {
            return rowIndex >= 0 && rowIndex < dgvGrupos.RowCount &&
                columnIndex >= 0 && columnIndex <= dgvGrupos.ColumnCount;
        }

        #endregion    

        #region eventos

        private void Grupos_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void cmbAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarGrupos();
        }

        private void btnNuevoGrupo_Click(object sender, EventArgs e)
        {
            NuevoGrupo form = new NuevoGrupo();
            form.usuario = this.usuario;
            var show = form.ShowDialog();
            if (show == DialogResult.OK)
            {
                Iniciar();
            }
        }

        private void dgvGrupos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex) && (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 2))
            {
                dgvGrupos.Cursor = Cursors.Hand;
            }
        }

        private void dgvGrupos_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex) && (e.ColumnIndex == 3 || e.ColumnIndex == 3 || e.ColumnIndex == 5 || e.ColumnIndex == 2))
            {
                dgvGrupos.Cursor = Cursors.Default;
            }
        }

        private void dgvGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex))
            {
                if (e.ColumnIndex == 2)
                {
                    Consumidores form = new Consumidores();
                    form.grupo = new Grupo();
                    form.grupo.IdGrupo = dgvGrupos[0, e.RowIndex].Value.ToString();
                    form.usuario = this.usuario;
                    var show = form.ShowDialog();

                }
                else if (e.ColumnIndex == 3)
                {
                    AsigTurnos form = new AsigTurnos();
                    form.usuario = this.usuario;

                    //Seleccionar Grupo
                    
                        foreach (Grupo item in this.grupos)
                        {
                            if (item.IdGrupo.Equals(dgvGrupos[0, e.RowIndex].Value.ToString()))
                            {                            
                                form.grupo = item;
                            }
                        }
                    

                    var show = form.ShowDialog();
                    if (show == DialogResult.OK)
                    {

                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    NuevoGrupo form = new NuevoGrupo();
                    form.usuario = this.usuario;


                    foreach (Grupo item in this.grupos)
                    {
                        if (item.IdGrupo.Equals(dgvGrupos[0, e.RowIndex].Value.ToString()))
                        {
                            form.grupoEdit = item;
                        }
                    }
                    

                    form.editar = true;
                    var show = form.ShowDialog();
                    if (show == DialogResult.OK)
                    {
                        Iniciar();
                    }
                }
                else if (e.ColumnIndex == 5)
                {
                    int consumidores = _mGrupo.cantidadConsumidores(dgvGrupos[0, e.RowIndex].Value.ToString());
                    if (consumidores > 0)
                    {
                        MessageBox.Show("El grupo contiene consumidores, reasignelos a otros grupos");
                        return;
                    }
                    else if (consumidores == 0)
                    {
                        Grupo g = new Grupo();
                        g.IdUsuarioMod = this.usuario.IdUsuario;
                        g.IdGrupo = dgvGrupos[0, e.RowIndex].Value.ToString();
                        _mGrupo.eliminarGrupo(g);
                        Iniciar();
                    }
                }
            }
        }

        #endregion



        

        

        
    }
}
