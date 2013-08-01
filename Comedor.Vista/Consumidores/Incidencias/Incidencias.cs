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

namespace Comedor.Vista.Consumidores.Incidencias
{
    public partial class Incidencias : Form
    {
        #region constructor
        public Incidencias()
        {
            InitializeComponent();
        }
        #endregion

        #region declaraciones

        public Usuario usuario;
        public consumidor consumidor;
        m_consumidor _mConsumidor = new m_consumidor();
        #endregion

        #region metodos propios

        private void iniciar()
        {
            lblNombre.Text = consumidor.Persona.Nombres + " " + consumidor.Persona.Paterno + " " + consumidor.Persona.Materno;

            consumidor.incidencias = _mConsumidor.ListarIncidencias(consumidor.IdConsumidor);
            Listar();
        }

        private void ArreglaDataView()
        {
            if (dgvIncidencias.Columns.Count > 1) return;
            dgvIncidencias.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgvIncidencias.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIncidencias.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvIncidencias.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvIncidencias.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = "COD";
            column.DataPropertyName = "cod";
            column.Width = 50;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvIncidencias.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Gravedad";
            column.DataPropertyName = "gravedad";
            column.Width = 150;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvIncidencias.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Fecha";
            column.DataPropertyName = "fecha";
            column.Width = 160;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvIncidencias.Columns.Add(column);


            column = new DataGridViewTextBoxColumn();
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.ReadOnly = true;
            dgvIncidencias.Columns.Add(column);

            dgvIncidencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIncidencias.MultiSelect = false;
            dgvIncidencias.AllowUserToResizeColumns = true;
            dgvIncidencias.AllowUserToResizeRows = false;
            dgvIncidencias.BorderStyle = BorderStyle.FixedSingle;
            dgvIncidencias.RowHeadersVisible = false;
            dgvIncidencias.AllowUserToAddRows = false;
            dgvIncidencias.AllowUserToDeleteRows = false;
            dgvIncidencias.AllowUserToOrderColumns = false;
            dgvIncidencias.ReadOnly = true;

        }

        void Listar()
        {
            dgvIncidencias.Columns.Clear();
            ArreglaDataView();
            dgvIncidencias.Rows.Clear();
            foreach (Incidencia item in this.consumidor.incidencias)
            {

                int n = dgvIncidencias.Rows.Add();
                dgvIncidencias.Rows[n].Cells[0].Value = item.IdIncidencia;
                dgvIncidencias.Rows[n].Cells[1].Value = item.Gravedad;
                dgvIncidencias.Rows[n].Cells[2].Value = item.FechaHora.ToString();

            }
            dgvIncidencias.RowHeadersVisible = false;

        }

        #endregion

        private void Incidencias_Load(object sender, EventArgs e)
        {
            iniciar();
        }

        private void dgvIncidencias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex))
            {
                foreach (Incidencia item in consumidor.incidencias)
                {
                    if (item.IdIncidencia.Equals(dgvIncidencias[0, e.RowIndex].Value.ToString()))
                    {
                        txtMotivo.Text = item.Descripcion;
                    }
                }
            }
        }

        private bool IsValidCellAddress(int rowIndex, int columnIndex)
        {
            return rowIndex >= 0 && rowIndex < dgvIncidencias.RowCount &&
                columnIndex >= 0 && columnIndex <= dgvIncidencias.ColumnCount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nueva form = new Nueva();
            form.usuario = this.usuario;
            form.idConsumidor = this.consumidor.IdConsumidor;
            form.setTitulo(lblNombre.Text);
            if (form.ShowDialog() == DialogResult.OK)
            {
                iniciar();
            }
        }

        #region eventos
        #endregion
    }
}
