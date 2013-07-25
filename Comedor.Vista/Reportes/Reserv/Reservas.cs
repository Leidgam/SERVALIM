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

namespace Comedor.Vista.Reportes
{
    public partial class Reservas : Form
    {
        public Reservas()
        {
            InitializeComponent();
        }

        #region declaraciones

        public Usuario usuario;

        List<RESERVA> reservas;
        m_reserva _mReservas = new m_reserva();

        List<Grupo> grupos;
        m_Grupo _mGrupo = new m_Grupo();

        List<Area> areas;
        m_Area _mArea = new m_Area();

        List<EAP> eap = new List<EAP>();
        m_EAP _mEAP = new m_EAP();
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
        private void Buscar()
        {
            reservas = _mReservas.rptReservas(rdbUnica.Checked, dtpDesde.Value.Date, dtpHasta.Value.Date, chbDesayuno.Checked, chbAlmuerzo.Checked, chbCena.Checked, chbPresencial.Checked, chbBolsa.Checked, chbPermanente.Checked, chbOcacional.Checked, ((Grupo)cmbGrupos.SelectedItem).IdGrupo, ((Area)cmbAreas.SelectedItem).IdArea, ((EAP)cmbEAP.SelectedItem).IdEAP);
            Listar();
            
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
            column.HeaderText = "Id";
            column.DataPropertyName = "id";
            column.Width = 30;
            column.Visible = false;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvReservas.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "No.";
            column.DataPropertyName = "no";
            column.Width = 30;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvReservas.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Nombre";
            column.DataPropertyName = "nombre";
            column.Width = 130;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvReservas.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Apellidos";
            column.DataPropertyName = "apellidos";
            column.Width = 150;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvReservas.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Grupo";
            column.DataPropertyName = "grupo";
            column.Width = 100;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvReservas.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Fecha";
            column.DataPropertyName = "fecha";
            column.Width = 100;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReservas.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Dia";
            column.DataPropertyName = "Dia";
            column.Width = 100;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReservas.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Comida";
            column.DataPropertyName = "comida";
            column.Width = 100;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReservas.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Servicio";
            column.DataPropertyName = "servicio";
            column.Width = 100;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReservas.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Tipo";
            column.DataPropertyName = "tipo";
            column.Width = 100;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReservas.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Horario";
            column.DataPropertyName = "horario";
            column.Width = 150;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            dgvReservas.ReadOnly = true;

        }

        void Listar()
        {

            /*  try
              {*/
            dgvReservas.Columns.Clear();
            ArreglaDataView();
            dgvReservas.Rows.Clear();

            foreach (RESERVA item in this.reservas)
            {

                if (filtroSencible(item.Consumidor))
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
                    dgvReservas.Rows[n].Cells[1].Value = n+1;
                    dgvReservas.Rows[n].Cells[2].Value = item.Consumidor.Persona.PrimerNombre + " " + item.Consumidor.Persona.SegundoNombre;
                    dgvReservas.Rows[n].Cells[3].Value = item.Consumidor.Persona.Apellidos;
                    dgvReservas.Rows[n].Cells[4].Value = item.Consumidor.Grupo.Nombre;
                    dgvReservas.Rows[n].Cells[5].Value = item.Fecha.ToString("dd/MM/yyyy");
                    dgvReservas.Rows[n].Cells[6].Value = item.Turno.Dia.Nombre;
                    dgvReservas.Rows[n].Cells[7].Value = comida;
                    dgvReservas.Rows[n].Cells[8].Value = servicio;
                    dgvReservas.Rows[n].Cells[9].Value = tipo;
                    dgvReservas.Rows[n].Cells[10].Value = horario;
                }
            }
            dgvReservas.RowHeadersVisible = false;
            /*}
            catch (Exception ex)
            {
                this.Close();
            }*/


        }

        private bool filtroSencible(consumidor item)
        {
            return ((item.Persona.PrimerNombre + " " + item.Persona.SegundoNombre).ToUpper().Contains(txtNombre.Text.ToUpper()) || item.Persona.Apellidos.ToUpper().Contains(txtNombre.Text.ToUpper()));
        }

        #endregion

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

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            Listar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Print_Reservas form = new Print_Reservas();
            form.lista = dgvReservas;
            form.Show();
        }

        private void Reservas_Load(object sender, EventArgs e)
        {
            try
            {
                rdbUnica.Checked = true;
                Iniciar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #region eventos


        #endregion
    }
}
