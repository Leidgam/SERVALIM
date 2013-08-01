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
    public partial class Registro : Form
    {

        #region constructor

        public Registro()
        {
            InitializeComponent();
        }

        #endregion

        #region declaraciones

        List<consumidor> consumidores;
        m_consumidor _mConsumidor;
        public Usuario usuario;
        public Periodo periodo;
        #endregion

        #region metodos propios

        private void Iniciar()
        {
            _mConsumidor = new m_consumidor();
            
            consumidores = _mConsumidor.ListarConsumidores(periodo.IdPeriodo);
            
            Listar();
        }

        private void ArreglaDataViewConsumidores()
        {
            if (dgvConsumidores.Columns.Count > 1) return;
            dgvConsumidores.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgvConsumidores.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvConsumidores.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvConsumidores.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvConsumidores.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = "idConsumidor";
            column.DataPropertyName = "id";
            column.Width = 50;
            column.Visible = false;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvConsumidores.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "COD";
            column.DataPropertyName = "cod";
            column.Width = 50;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvConsumidores.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Nombres";
            column.DataPropertyName = "nombres";
            column.Width = 150;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvConsumidores.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Apellidos";
            column.DataPropertyName = "apellidos";
            column.Width = 160;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvConsumidores.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Area";
            column.DataPropertyName = "area";
            column.Width = 200;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvConsumidores.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.ReadOnly = true;
            dgvConsumidores.Columns.Add(column);

            dgvConsumidores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsumidores.MultiSelect = false;
            dgvConsumidores.AllowUserToResizeColumns = true;
            dgvConsumidores.AllowUserToResizeRows = false;
            dgvConsumidores.BorderStyle = BorderStyle.FixedSingle;
            dgvConsumidores.RowHeadersVisible = false;
            dgvConsumidores.AllowUserToAddRows = false;
            dgvConsumidores.AllowUserToDeleteRows = false;
            dgvConsumidores.AllowUserToOrderColumns = false;
            dgvConsumidores.ReadOnly = true;

        }

        void Listar()
        {
            dgvConsumidores.Columns.Clear();
            ArreglaDataViewConsumidores();
            dgvConsumidores.Rows.Clear();

            if (consumidores == null) { this.consumidores = new List<consumidor>(); }
            foreach (consumidor item in this.consumidores)
            {
                if (filtroSencible(item))
                {
                    int n = dgvConsumidores.Rows.Add();
                    dgvConsumidores.Rows[n].Cells[0].Value = item.IdConsumidor;
                    dgvConsumidores.Rows[n].Cells[1].Value = item.codigo(periodo.IdPeriodo);
                    dgvConsumidores.Rows[n].Cells[2].Value = item.Persona.Nombres;
                    dgvConsumidores.Rows[n].Cells[3].Value = item.Persona.Paterno+ " "+item.Persona.Materno ;
                    dgvConsumidores.Rows[n].Cells[4].Value = item.Area.Nombre;

                }
            }
            dgvConsumidores.RowHeadersVisible = false;

        }

        private bool filtroSencible(consumidor item)
        {
            return item.codigo(periodo.IdPeriodo).ToUpper().Contains(txtCodigo.Text.ToUpper()) && ((item.Persona.Nombres + " " + item.Persona.Paterno).ToUpper().Contains(txtNombre.Text.ToUpper()) || item.Persona.Materno.ToUpper().Contains(txtNombre.Text.ToUpper()));
        }

        #endregion

        #region eventos


        private void Registro_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            Listar();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (this.usuario.validarPrivilegio("PRI0000015"))
            {
                Nuevo form = new Nuevo();
                form.usuario = this.usuario;
                var show = form.ShowDialog();
                if (show == DialogResult.OK)
                {
                    Iniciar();
                }
            }
            else
            {
                MessageBox.Show("Privilegios Insuficientes");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvConsumidores.Rows.Count > 0)
            {
                if (this.usuario.validarPrivilegio("PRI0000017"))
                {
                    Nuevo form = new Nuevo();
                    form.usuario = this.usuario;
                    form.editando = true;
                    foreach (consumidor item in this.consumidores)
                    {
                        if (item.IdConsumidor.Equals(dgvConsumidores[0, dgvConsumidores.CurrentRow.Index].Value.ToString()))
                        {
                            consumidor c = _mConsumidor.AllDatos(item.IdConsumidor);

                            form.persona = c.Persona;
                            form.consumidor = c;
                        }
                    }
                    var show = form.ShowDialog();
                    if (show == DialogResult.OK)
                    {
                        Iniciar();
                    }
                }
                else
                {
                    MessageBox.Show("Privilegios Insuficientes");
                }
            }
        }

        #endregion

        private void btnReservas_Click(object sender, EventArgs e)
        {
            if (dgvConsumidores.Rows.Count > 0)
            {
                if (this.usuario.validarPrivilegio("PRI0000018"))
                {
                    Reservas.Horario form = new Reservas.Horario();
                    form.usuario = this.usuario;
                    form.periodo = this.periodo;
                    foreach (consumidor item in this.consumidores)
                    {
                        if (item.IdConsumidor.Equals(dgvConsumidores[0, dgvConsumidores.CurrentRow.Index].Value.ToString()))
                        {
                            consumidor c = _mConsumidor.AllDatos(item.IdConsumidor);
                            form.consumidor = c;
                        }
                    }
                    if (form.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Privilegios Insuficientes");
                }
            }
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            if (dgvConsumidores.Rows.Count > 0)
            {
                foto form = new foto();
                foreach (consumidor item in this.consumidores)
                {
                    if (item.IdConsumidor.Equals(dgvConsumidores[0, dgvConsumidores.CurrentRow.Index].Value.ToString()))
                    {
                        form.idPersona = item.Persona.IdPersona;
                    }
                }
                form.ShowDialog();
            }
        }

        private void dgvConsumidores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                Incidencias.Incidencias form = new Incidencias.Incidencias();
                form.usuario = this.usuario;
                foreach (consumidor item in consumidores)
                {
                    if (item.IdConsumidor.Equals(dgvConsumidores[0, e.RowIndex].Value.ToString()))
                    {
                        form.consumidor = item;
                    }
                }
                form.ShowDialog();
            }
        }

        


        

       
    }
}
