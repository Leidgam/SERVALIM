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
    public partial class frmRegistroTurno : Form
    {
        #region variables...

        List<RegistroEntrada> ListaRegEnt = new List<RegistroEntrada>();
        List<String> ListItemTurno = new List<String>();
        int SumaCantidad = 0;
        int SumaNormal = 0;
        int SumaReserva = 0;

        #endregion

        public frmRegistroTurno()
        {
            InitializeComponent();
        }

        #region metodos...

        public void ubicacion(Panel panel, bool visible)
        {
            panelfecha.Visible = false;
            panelperiodo.Visible = false;
            if (visible)
            {
                panel.Visible = true;
                panel.Location = new Point(9, 59);
            }
        }

        void Iniciar()
        {
            //fecha FechaUno-FechaDesde/Hasta
            int tipo=0;

            String fechaUno = "";
            if (rbnUnafecha.Checked) { fechaUno = dtpfecha.Value.Date.ToString("d"); tipo=1; }

            String fechaInicio = "";
            String fechaFin = "";
            if (rbnDesdeHasta.Checked) 
            { 
                fechaInicio = dtpfechaInicio.Value.Date.ToString("d"); 
                fechaFin = dtpfechafin.Value.Date.ToString("d"); 
                tipo=2;
            }

            // tipo Des-Alm-Cen
            int desayuno = 0;
            if(rbndesayuno.Checked){ desayuno=1; }

            int almuerzo = 0;
            if (rbnalmuerzo.Checked) { almuerzo = 2; }

            int cena = 0;
            if (rbncena.Checked) { cena = 3; }

            //Turno...
            int turno=cmbTurno.SelectedIndex;

            m_Turno mt = new m_Turno();
            this.ListaRegEnt = mt.registroXturno(fechaUno, fechaInicio, fechaFin, tipo, desayuno, almuerzo, cena, turno);

            Listar();
        }

        void Listar()
        {
            SumaCantidad = 0;
            SumaNormal = 0;
            SumaReserva = 0;
            dgvRegistro.Columns.Clear();
            ArreglaDataView1();
            dgvRegistro.Rows.Clear();

            foreach (RegistroEntrada item in this.ListaRegEnt)
            {
                int n = dgvRegistro.Rows.Add();

                dgvRegistro.Rows[n].Cells[0].Value = n + 1;
                dgvRegistro.Rows[n].Cells[1].Value = item.FechaHora.Date.ToString("d");
                dgvRegistro.Rows[n].Cells[2].Value = item.FechaHora.ToString("dddd",new System.Globalization.CultureInfo("es-ES"));

                if (item.Turno.DesAlmCen == 1) { dgvRegistro.Rows[n].Cells[3].Value = "Desayuno"; }
                if (item.Turno.DesAlmCen == 2) { dgvRegistro.Rows[n].Cells[3].Value = "Almuerzo"; }
                if (item.Turno.DesAlmCen == 3) { dgvRegistro.Rows[n].Cells[3].Value = "Cena"; }

                dgvRegistro.Rows[n].Cells[4].Value = item.Turno.Item;
                dgvRegistro.Rows[n].Cells[5].Value = item.Estado; //atendidos
                dgvRegistro.Rows[n].Cells[6].Value = item.Turno.IdTurno;

                m_consumidor mc = new m_consumidor();
                int total = mc.CantidadConsumidores(item.FechaHora.Date.ToString("d"), item.Turno.IdTurno);
                dgvRegistro.Rows[n].Cells[7].Value = (total - item.Estado).ToString(); //ausentes
                dgvRegistro.Rows[n].Cells[8].Value = total.ToString(); //total

                SumaCantidad = SumaCantidad + item.Estado;
            }
            dgvRegistro.RowHeadersVisible = false;

            txttotal.Text = SumaCantidad.ToString();

        }

        void llenarCombo()
        {
            ListItemTurno.Add("Todos");
            m_Turno mt = new m_Turno();
            int max=mt.MaxItemTurno();
            for (int i = 1; i <= max; i++)
            {
                ListItemTurno.Add(i.ToString());
            }
            cmbTurno.DataSource = ListItemTurno;
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
            column.HeaderText = "FECHA";
            column.DataPropertyName = "fecha";
            column.Width = 120;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgvRegistro.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "DIA";
            column.DataPropertyName = "dia";
            column.Width = 100;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgvRegistro.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "COMIDA";
            column.DataPropertyName = "DesAlmCen";
            column.Width = 120;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgvRegistro.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "TURNO";
            column.DataPropertyName = "turno";
            column.Width = 80;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgvRegistro.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Atend.";
            column.DataPropertyName = "cantidad";
            column.Width = 100;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgvRegistro.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "ID";
            column.DataPropertyName = "id";
            column.Width = 50;
            column.Visible = false;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRegistro.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Faltas";
            column.DataPropertyName = "faltan";
            column.Width = 100;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgvRegistro.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "TOTAL";
            column.DataPropertyName = "total";
            column.Width = 100;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
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

        #endregion

        #region eventos...

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            Iniciar();
            this.Cursor = Cursors.Default;
        }

        private void rbnUnafecha_CheckedChanged(object sender, EventArgs e)
        {
            ubicacion(panelfecha, true);
        }

        private void rbnDesdeHasta_CheckedChanged(object sender, EventArgs e)
        {
            ubicacion(panelperiodo, true);
        }

        private void frmRegistroTurno_Load(object sender, EventArgs e)
        {
            ubicacion(panelfecha, true);
            llenarCombo();
            Iniciar();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintRegTurno from = new PrintRegTurno();
            from.ListRE = this.ListaRegEnt;
            from.SumaCantidad = SumaCantidad;
            if (rbnUnafecha.Checked) { from.fechaInicio = dtpfecha.Value.Date.ToString("d"); from.fechaFin = " "; }
            if (rbnDesdeHasta.Checked)
            {
                from.fechaInicio = dtpfechaInicio.Value.Date.ToString("d");
                from.fechaFin = dtpfechafin.Value.Date.ToString("d");
            }
            from.ShowDialog();
        }

        #endregion

        private void dgvRegistro_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int fila = Convert.ToInt32(this.dgvRegistro.CurrentRow.Index);

            frmConsumidor from = new frmConsumidor();
            from.fecha = dgvRegistro.Rows[fila].Cells[1].Value.ToString();
            from.idturno = dgvRegistro.Rows[fila].Cells[6].Value.ToString();
            from.tipoturno = 1;
            from.ShowDialog();
        }

       
    }
}
