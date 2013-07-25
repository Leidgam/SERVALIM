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
    public partial class AsigTurnos : Form
    {

        #region constructor
        public AsigTurnos()
        {
            InitializeComponent();
        }
        #endregion

        #region declaraciones

        public Usuario usuario;
        List<TURNO> turnos;

        m_Turno _mTurno = new m_Turno();
        m_Grupo _mGrupo = new m_Grupo();

        public Grupo grupo;

        //Lista de Cambios
        List<cambioAsigTurno> cambios = new List<cambioAsigTurno>();

        #endregion

        #region metodos propios

        private void Iniciar()
        {
            cargarBD();
            ListarTurnos();
            marcarAsignados();
        }

        private void cargarBD()
        {
            this.turnos = _mTurno.ListarTurnos();
            this.grupo.turnos = _mGrupo.ListarAsignaciones(grupo.IdGrupo);
        }

        private void ArreglaDataViewTurnos(DataGridView dgv)
        {
            if (dgv.Columns.Count > 1) return;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.AutoGenerateColumns = false;


            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = "ID";
            column.DataPropertyName = "id";
            column.Width = 50;
            column.Visible = false;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.HeaderText = "";
            column.DataPropertyName = "check";
            column.Width = 30;
            column.ReadOnly = false;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "DIA";
            column.DataPropertyName = "dia";
            column.Width = 80;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column.ReadOnly = true;
            dgv.Columns.Add(column);


            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "";
            column.DataPropertyName = "tiempo";
            column.Width = 80;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column.ReadOnly = true;
            dgv.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "HORA INCIO";
            column.DataPropertyName = "tiempo";
            column.Width = 80;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "HORA FIN";
            column.DataPropertyName = "tiempo";
            column.Width = 80;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(column);



            column = new DataGridViewTextBoxColumn();
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.ReadOnly = true;
            dgv.Columns.Add(column);

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.AllowUserToResizeRows = false;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;

        }

        private void ArreglarAllDataGrid()
        {
            dgvTurnDom.Columns.Clear();
            dgvTurnLun.Columns.Clear();
            dgvTurnMart.Columns.Clear();
            dgvTurnMier.Columns.Clear();
            dgvTurnJue.Columns.Clear();
            dgvTurnVier.Columns.Clear();
            dgvTurnSab.Columns.Clear();

            ArreglaDataViewTurnos(dgvTurnDom);
            ArreglaDataViewTurnos(dgvTurnLun);
            ArreglaDataViewTurnos(dgvTurnMart);
            ArreglaDataViewTurnos(dgvTurnMier);
            ArreglaDataViewTurnos(dgvTurnJue);
            ArreglaDataViewTurnos(dgvTurnVier);
            ArreglaDataViewTurnos(dgvTurnSab);

            dgvTurnDom.Rows.Clear();
            dgvTurnLun.Rows.Clear();
            dgvTurnMart.Rows.Clear();
            dgvTurnMier.Rows.Clear();
            dgvTurnJue.Rows.Clear();
            dgvTurnVier.Rows.Clear();
            dgvTurnSab.Rows.Clear();
        }

        private void ListarTurnos()
        {
            ArreglarAllDataGrid();

            foreach (TURNO item in this.turnos)
            {
                if (item.Dia.IdDia.Equals("001")) { AgregarFila(dgvTurnDom, item); }
                else if (item.Dia.IdDia.Equals("002")) { AgregarFila(dgvTurnLun, item); }
                else if (item.Dia.IdDia.Equals("003")) { AgregarFila(dgvTurnMart, item); }
                else if (item.Dia.IdDia.Equals("004")) { AgregarFila(dgvTurnMier, item); }
                else if (item.Dia.IdDia.Equals("005")) { AgregarFila(dgvTurnJue, item); }
                else if (item.Dia.IdDia.Equals("006")) { AgregarFila(dgvTurnVier, item); }
                else if (item.Dia.IdDia.Equals("007")) { AgregarFila(dgvTurnSab, item); }  
            }
            dgvTurnDom.RowHeadersVisible = false;

        }

        private void AgregarFila(DataGridView dgv, TURNO item)
        {
            //Determinar tiempo
            String tiempo = "";
            if (item.DesAlmCen == 1) { tiempo = "Desayuno"; } else if (item.DesAlmCen == 2) { tiempo = "Almuerzo"; } else if (item.DesAlmCen == 3) { tiempo = "Cena"; }

            int n = dgv.Rows.Add();
            dgv.Rows[n].Cells[0].Value = item.IdTurno;

            dgv.Rows[n].Cells[2].Value = item.Dia.Nombre;
            dgv.Rows[n].Cells[3].Value = tiempo;
            dgv.Rows[n].Cells[4].Value = DateTime.Today.Add(item.HoraInicio).ToString("hh:mm tt");
            dgv.Rows[n].Cells[5].Value = DateTime.Today.Add(item.HoraFin).ToString("hh:mm tt");

        }

        private void marcarAsignados()
        {
            foreach (Grupo_Turno item in this.grupo.turnos)
            {
                if (item.Turno.Dia.IdDia.Equals("001")) { marcar(dgvTurnDom, item); }
                if (item.Turno.Dia.IdDia.Equals("002")) { marcar(dgvTurnLun, item); }
                if (item.Turno.Dia.IdDia.Equals("003")) { marcar(dgvTurnMart, item); }
                if (item.Turno.Dia.IdDia.Equals("004")) { marcar(dgvTurnMier, item); }
                if (item.Turno.Dia.IdDia.Equals("005")) { marcar(dgvTurnJue, item); }
                if (item.Turno.Dia.IdDia.Equals("006")) { marcar(dgvTurnVier, item); }
                if (item.Turno.Dia.IdDia.Equals("007")) { marcar(dgvTurnSab, item); }
            }
        }

        public void marcar(DataGridView dgv, Grupo_Turno item)
        {
            foreach (DataGridViewRow fila in dgv.Rows)
            {
                if (fila.Cells[0].Value.ToString().Equals(item.Turno.IdTurno))
                {
                    fila.Cells[1].Value = true;
                }
            }
        }

        private void NuevoCambio(DataGridView dgv, bool agregar, String idTurno)
        {
            cambioAsigTurno cambio = new cambioAsigTurno();
            cambio.Agregar = agregar;
            cambio.idGrupo = this.grupo.IdGrupo;
            cambio.idTurno = idTurno;

            cambios.Add(cambio);
        }

        private void checkDGV(DataGridView dgv)
        {
            foreach (DataGridViewRow item in dgv.Rows)
            {
                String idTurno = item.Cells[0].Value.ToString();

                if (estaba(idTurno))
                {
                    if ((bool)item.Cells[1].Value == false) { cambioAsigTurno cat = new cambioAsigTurno(); cat.Agregar = false; cat.idTurno = idTurno; cat.idGrupo = this.grupo.IdGrupo; cambios.Add(cat); }

                }
                else
                {
                    if (item.Cells[1].Value != null)
                    {
                        if ((bool)item.Cells[1].Value) { cambioAsigTurno cat = new cambioAsigTurno(); cat.Agregar = true; cat.idTurno = idTurno; cat.idGrupo = this.grupo.IdGrupo; cambios.Add(cat); }
                    }
                }
            }
        }

        private void CrearCambios()
        {
            checkDGV(dgvTurnDom);
            checkDGV(dgvTurnLun);
            checkDGV(dgvTurnMart);
            checkDGV(dgvTurnMier);
            checkDGV(dgvTurnJue);
            checkDGV(dgvTurnVier);
            checkDGV(dgvTurnSab);
        }

        private bool estaba(String idTurno)
        {
            foreach (Grupo_Turno item in this.grupo.turnos)
            {
                if (item.Turno.IdTurno.Equals(idTurno))
                {
                    return true;
                }
            }
            return false;
        }

        private void Guardar()
        {
            CrearCambios();
            if (cambios.Count > 0) { _mGrupo.AsignarTurnos(cambios, this.usuario.IdUsuario); }
        }

        #endregion

        #region eventos

        private void AsigTurnos_Load(object sender, EventArgs e)
        {
            Iniciar();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion

        

       







    }
}
