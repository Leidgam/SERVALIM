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

namespace Comedor.Vista.Consumidores.Bolsas
{
    public partial class Control_Bolsas : Form
    {
        #region constructor
                public Control_Bolsas()
                {
                    InitializeComponent();
                }
        #endregion

        #region declaraciones

        public Usuario usuario;
        List<RESERVA> bolsas;
        List<Grupo> grupos;
        List<Area> areas;
        List<EAP> eap;
        List<RegistroBolsa> entregas;

        m_Grupo _mGrupo = new m_Grupo();
        m_Area _mArea = new m_Area();
        m_EAP _mEAP = new m_EAP();
        m_reserva _mReserva = new m_reserva();

        #endregion

        #region metodos

        private void Iniciar()
        {
            grupos = _mGrupo.ListarAllGrupos();
            areas = _mArea.ListarAllAreas();
            eap = _mEAP.ListarAllEAP();

            Grupo g = new Grupo();
            Area a = new Area();
            EAP e = new EAP();

            g.IdGrupo = "0";
            g.Nombre = "Todos";

            a.IdArea = "0";
            a.Nombre = "Todas";

            e.IdEAP = "0";
            e.Nombre = "Todas";
            grupos.Add(g);
            areas.Add(a);
            eap.Add(e);

            cmbGrupos.DataSource = grupos;
            cmbGrupos.DisplayMember = "Nombre";

            cmbAreas.DataSource = areas;
            cmbAreas.DisplayMember = "Nombre";

            cmbEAP.DataSource = eap;
            cmbEAP.DisplayMember = "Nombre";

            cmbGrupos.SelectedIndex = cmbGrupos.Items.Count - 1;
            cmbAreas.SelectedIndex = cmbAreas.Items.Count - 1;
            cmbEAP.SelectedIndex = cmbEAP.Items.Count - 1;
        }

        private void ArreglaDataView()
            {
                if (dgvReservas.Columns.Count > 1) return;
                dgvReservas.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                dgvReservas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservas.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
                dgvReservas.CellBorderStyle = DataGridViewCellBorderStyle.None;
                dgvReservas.AutoGenerateColumns = false;


                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                column.HeaderText = "ID";
                column.DataPropertyName = "id";
                column.Width = 50;
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvReservas.Columns.Add(column);

                column = new DataGridViewTextBoxColumn();
                column.HeaderText = "No.";
                column.DataPropertyName = "no";
                column.Width = 50;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvReservas.Columns.Add(column);

                column = new DataGridViewCheckBoxColumn();
                column.HeaderText = "";
                column.DataPropertyName = "check";
                column.Width = 30;
                column.ReadOnly = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservas.Columns.Add(column);

                column = new DataGridViewTextBoxColumn();
                column.HeaderText = "Nombre";
                column.DataPropertyName = "nombre";
                column.Width = 150;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                column.ReadOnly = true;
                dgvReservas.Columns.Add(column);


                column = new DataGridViewTextBoxColumn();
                column.HeaderText = "Apellido";
                column.DataPropertyName = "apellido";
                column.Width = 150;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                column.ReadOnly = true;
                dgvReservas.Columns.Add(column);


                column = new DataGridViewTextBoxColumn();
                column.HeaderText = "Fecha";
                column.DataPropertyName = "fecha";
                column.Width = 150;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.ReadOnly = true;
                dgvReservas.Columns.Add(column);

                column = new DataGridViewTextBoxColumn();
                column.HeaderText = "Estado";
                column.DataPropertyName = "estado";
                column.Width = 150;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.ReadOnly = true;
                dgvReservas.Columns.Add(column);  

                column = new DataGridViewTextBoxColumn();
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                column.ReadOnly = true;
                dgvReservas.Columns.Add(column);

                dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvReservas.MultiSelect = false;
                dgvReservas.AllowUserToResizeColumns = true;
                dgvReservas.AllowUserToResizeRows = false;
                dgvReservas.BorderStyle = BorderStyle.FixedSingle;
                dgvReservas.RowHeadersVisible = false;
                dgvReservas.AllowUserToAddRows = false;
                dgvReservas.AllowUserToDeleteRows = false;
                dgvReservas.AllowUserToOrderColumns = false;


            }
        #endregion

        private void Control_Bolsas_Load(object sender, EventArgs e)
        {
            rdbUnica.Checked = true;
            Iniciar();
        }

        private void Buscar()
        {
            bolsas = _mReserva.rptReservas(rdbUnica.Checked, dtpDesde.Value.Date, dtpHasta.Value.Date, chbDesayuno.Checked, chbAlmuerzo.Checked, chbCena.Checked, false, true, chbPermanente.Checked, chbOcacional.Checked, ((Grupo)cmbGrupos.SelectedItem).IdGrupo, ((Area)cmbAreas.SelectedItem).IdArea, ((EAP)cmbEAP.SelectedItem).IdEAP);
            entregas = _mReserva.getREgistroBolsas(rdbUnica.Checked, dtpDesde.Value.Date, dtpHasta.Value.Date);
      
            foreach (RegistroBolsa item in entregas)
            {
                foreach (RESERVA res in bolsas)
                {
                    if (res.IdReserva == item.Reserva.IdReserva)
                    {
                        res.Stado = "Entregada";
                    }
                }
            }
            Listar();

        }

        void Listar()
        {

            /*  try
              {*/
            dgvReservas.Columns.Clear();
            ArreglaDataView();
            dgvReservas.Rows.Clear();

            foreach (RESERVA item in this.bolsas)
            {


                String comida = "";

                if (item.Turno.DesAlmCen == 1) { comida = "Desayuno"; } else if (item.Turno.DesAlmCen == 2) { comida = "Almuerzo"; } else if (item.Turno.DesAlmCen == 3) { comida = "Cena"; }

                String servicio = "";
                String horario = "";
                String tipo = "";
                if (item.TipoServicio == 1) { servicio = "Presencial"; horario = item.Remplazo.HoraInicio + " - " + item.Remplazo.HoraFin; } else if (item.TipoServicio == 2) { servicio = "Bolsa"; horario = item.Horabolsa + ""; }

                if (item.Tipo == 1) { tipo = "Permanente"; } else { tipo = "Ocacional"; }


                int n = dgvReservas.Rows.Add();
                dgvReservas.Rows[n].Cells[0].Value = item.IdReserva;
                dgvReservas.Rows[n].Cells[1].Value = n + 1;
                dgvReservas.Rows[n].Cells[2].Value = true; 
                dgvReservas.Rows[n].Cells[3].Value = item.Consumidor.Persona.Nombres;
                dgvReservas.Rows[n].Cells[4].Value = item.Consumidor.Persona.Paterno + " " + item.Consumidor.Persona.Materno;
                dgvReservas.Rows[n].Cells[5].Value = item.Fecha.ToString("dd/MM/yyyy");
                dgvReservas.Rows[n].Cells[6].Value = item.Stado;
            }
            dgvReservas.RowHeadersVisible = false;
            /*}
            catch (Exception ex)
            {
                this.Close();
            }*/


        }

        private void rdbUnica_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbUnica.Checked)
            {
                dtpHasta.Visible = false;
                lblDesde.Text = "Fecha:";
                lblHasta.Visible = false;
            }
            else
            {
                dtpHasta.Visible = true;
                lblDesde.Text = "Desde:";
                lblHasta.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void chbTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTodo.Checked)
            {
                foreach (DataGridViewRow item in dgvReservas.Rows)
                {
                    item.Cells[2].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow item in dgvReservas.Rows)
                {
                    item.Cells[2].Value = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            List<RESERVA> confirmar = new List<RESERVA>();
            checkDGV(dgvReservas);
            foreach (RESERVA item in bolsas)
            {
                if (item.marcado)
                {
                    confirmar.Add(item);
                }
            }
            if (confirmar.Count > 0)
            {
                Entrega form = new Entrega();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    foreach (RESERVA item in confirmar)
                    {
                        _mReserva.insertarEntrega(item, form.datos, this.usuario.IdUsuario);
                    }
                    Buscar();
                    this.Cursor = Cursors.Default;

                }
            }
            else
            {

            }

        }

        private void checkDGV(DataGridView dgv)
        {
            foreach (DataGridViewRow item in dgv.Rows)
            {
                String idConsumidor = item.Cells[0].Value.ToString();

                foreach (RESERVA cons in bolsas)
                {
                    if (cons.IdReserva.Equals(idConsumidor))
                    {
                        if (item.Cells[2].Value == null) { cons.marcado = false; }
                        else { cons.marcado = (bool)item.Cells[2].Value; }
                    }
                }
            }
        }
    }
}
