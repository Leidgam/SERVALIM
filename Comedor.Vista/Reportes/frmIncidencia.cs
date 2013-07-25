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
    public partial class frmIncidencia : Form
    {
        List<Incidencia> ListIncidencia = new List<Incidencia>();
        public Usuario usuario;

        public frmIncidencia()
        {
            InitializeComponent();
        }

        public void ubicacion(Panel panelx,Panel panely, bool visiblex,bool visibley, int x, int y)
        {
            panelx.Visible = false;
            panely.Visible = false;
            if (visiblex)
            {
                panelx.Visible = true;
                panelx.Location = new Point(x, y);
            }
            if (visibley)
            {
                panely.Visible = true;
                panely.Location = new Point(x, y);
            }
        }

        private void rbnUnafecha_CheckedChanged(object sender, EventArgs e)
        {
            ubicacion(panel2, panel1, true, false, 15, 53);
        }

        private void rbnDesdeHasta_CheckedChanged(object sender, EventArgs e)
        {
            ubicacion(panel1, panel2, true, false, 15, 53);
        }

        private void rbnGravedadHasta_CheckedChanged(object sender, EventArgs e)
        {
            ubicacion(panel3, panel5, true, false, 523, 53);
        }

        private void rbmGravedadDe_CheckedChanged(object sender, EventArgs e)
        {
            ubicacion(panel5, panel3, true, false, 523, 53);
        }

        private void frmIncidencia_Load(object sender, EventArgs e)
        {

            ubicacion(panel2, panel1, true, false, 15, 53);
            ubicacion(panel5, panel3, true, false, 523, 53);
            cmbGravedadUno.SelectedIndex = 0;
            cmbGravedadDe.SelectedIndex = 0;
            cmbGravedadDe.SelectedIndex = 0;
            iniciar();

        }

        void iniciar()
        {
            int tipo = 0;

            String fechaUno = "";
            if (rbnUnafecha.Checked) { fechaUno = dtpFechaUno.Value.Date.ToString("d"); tipo = 1; }

            String fechaInicio = "";
            String fechaFin = "";
            if (rbnDesdeHasta.Checked)
            {
                fechaInicio = dtpFechaInicio.Value.Date.ToString("d");
                fechaFin = dtpFechaFin.Value.Date.ToString("d");
                tipo = 2;
            }

            int tipoG=0;
            int gravedad1=0;
            int gravedad2=0;

            if(rbmGravedadDe.Checked){gravedad1=cmbGravedadUno.SelectedIndex; tipoG=1;}
            if(rbnGravedadHasta.Checked){gravedad1=int.Parse(cmbGravedadDe.SelectedItem.ToString()); gravedad2=int.Parse(cmbGravedadHasta.SelectedItem.ToString());tipoG=2;}
            
            m_consumidor mc= new m_consumidor();
            this.ListIncidencia = mc.ListarIncidenciaConsumidor(tipo, fechaUno,fechaInicio,fechaFin,tipoG,gravedad1,gravedad2);


            listar();
        }

        void listar()
        {
            dgvRegistro.Columns.Clear();
            ArreglaDataView1();
            dgvRegistro.Rows.Clear();

            foreach (Incidencia item in this.ListIncidencia)
            {
                if (filtroSencible(item))
                {

                    int n = dgvRegistro.Rows.Add();

                    dgvRegistro.Rows[n].Cells[0].Value = item.IdIncidencia;
                    dgvRegistro.Rows[n].Cells[1].Value = item.Consumidor.IdConsumidor;
                    dgvRegistro.Rows[n].Cells[2].Value = item.Consumidor.CodUniversitario;
                    dgvRegistro.Rows[n].Cells[3].Value = item.Consumidor.Persona.PrimerNombre + " " + item.Consumidor.Persona.SegundoNombre;
                    dgvRegistro.Rows[n].Cells[4].Value = item.Consumidor.Persona.Apellidos;
                    dgvRegistro.Rows[n].Cells[5].Value = item.FechaHora.Date.ToString("d");
                    dgvRegistro.Rows[n].Cells[6].Value = item.FechaHora.ToString("dddd", new System.Globalization.CultureInfo("es-ES"));
                    dgvRegistro.Rows[n].Cells[7].Value = item.IdTurno;
                    dgvRegistro.Rows[n].Cells[8].Value = item.Gravedad;
                    dgvRegistro.Rows[n].Cells[9].Value = item.Descripcion;

                }
            }
            dgvRegistro.RowHeadersVisible = false;
        }

        private bool filtroSencible(Incidencia item)
        {
            return (item.Consumidor.CodUniversitario).ToUpper().Contains(txtCodigo.Text.ToUpper()) && ((item.Consumidor.Persona.PrimerNombre + " " + item.Consumidor.Persona.SegundoNombre).ToUpper().Contains(txtnombre.Text.ToUpper()) || item.Consumidor.Persona.Apellidos.ToUpper().Contains(txtnombre.Text.ToUpper()));
        }

        private void ArreglaDataView1()
        {
            if (dgvRegistro.Columns.Count > 1) return;
            dgvRegistro.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
            dgvRegistro.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRegistro.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvRegistro.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvRegistro.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = "No.";
            column.DataPropertyName = "no";
            column.Width = 50;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRegistro.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "idconsumidor";
            column.DataPropertyName = "idconsumidor";
            column.Width = 120;
            column.Visible = false;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgvRegistro.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Codigo";
            column.DataPropertyName = "codigo";
            column.Width = 80;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgvRegistro.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Nombres";
            column.DataPropertyName = "nombres";
            column.Width = 120;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgvRegistro.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Apellidos";
            column.DataPropertyName = "Apellidos";
            column.Width = 150;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgvRegistro.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Fecha";
            column.DataPropertyName = "fecha";
            column.Width = 120;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgvRegistro.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Dia";
            column.DataPropertyName = "dia";
            column.Width = 120;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgvRegistro.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Turno";
            column.DataPropertyName = "turno";
            column.Width = 100;
            column.Visible = false;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRegistro.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Gravedad";
            column.DataPropertyName = "gravedad";
            column.Width = 80;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRegistro.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "descripcion";
            column.DataPropertyName = "descripcion";
            column.Width = 30;
            column.Visible = false;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRegistro.Columns.Add(column);
 
            column = new DataGridViewTextBoxColumn();
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.ReadOnly = true;
            dgvRegistro.Columns.Add(column);

            dgvRegistro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegistro.MultiSelect = false;
            dgvRegistro.AllowUserToResizeColumns = true;
            dgvRegistro.AllowUserToResizeRows = false;
            dgvRegistro.BorderStyle = BorderStyle.FixedSingle;
            dgvRegistro.RowHeadersVisible = false;
            dgvRegistro.AllowUserToAddRows = false;
            dgvRegistro.AllowUserToDeleteRows = false;
            dgvRegistro.AllowUserToOrderColumns = false;


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            iniciar(); 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRegistro.Rows.Count > 0)
            {
                int f = Convert.ToInt32(this.dgvRegistro.CurrentRow.Index);
                String idincidecia = dgvRegistro[0, f].Value.ToString();

                m_consumidor mc = new m_consumidor();
                mc.EliminarInicidencia(idincidecia);
                iniciar();
            }

        }

        private void dgvRegistro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex))
            {
                   txtdescripcion.Text= dgvRegistro[9, e.RowIndex].Value.ToString();
            }
        }

        private bool IsValidCellAddress(int rowIndex, int columnIndex)
        {
            return rowIndex >= 0 && rowIndex < dgvRegistro.RowCount &&
                columnIndex >= 0 && columnIndex <= dgvRegistro.ColumnCount;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmIncidenciaNuevo form = new frmIncidenciaNuevo();
            form.usuario = this.usuario;
            if (form.ShowDialog() == DialogResult.OK)
            {
                iniciar();
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            listar();
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {
            listar();
        }

    }
}
