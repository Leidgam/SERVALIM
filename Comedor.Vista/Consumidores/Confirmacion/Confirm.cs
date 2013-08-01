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

namespace Comedor.Vista.Consumidores.Confirmacion
{
    public partial class Confirm : Form
    {

        #region constructor
        public Confirm()
        {
            InitializeComponent();
        }
        #endregion

        #region declaraciones
        public Usuario usuario;

        List<RESERVA> reservas;
        m_reserva _mReservas = new m_reserva();

        bool todos = false;
        #endregion

        #region metodos

        private void Iniciar()
        {
            todos = usuario.validarPrivilegio("PRI0000032");
            CargarBD();
            Listar();
        }

        private void CargarBD()
        {
            if (todos)
            {
                reservas = _mReservas.porConfirmar();
            }
            else
            {
                reservas = _mReservas.porConfirmar(usuario.IdUsuario);
            }
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
            column.HeaderText = "idReserva";
            column.DataPropertyName = "id";
            column.Width = 50;
            column.Visible = false;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvConsumidores.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.HeaderText = "";
            column.DataPropertyName = "check";
            column.Width = 30;
            column.ReadOnly = false;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvConsumidores.Columns.Add(column);


            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Nombre";
            column.DataPropertyName = "nombre";
            column.Width = 130;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvConsumidores.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Apellidos";
            column.DataPropertyName = "Apellidos";
            column.Width = 150;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvConsumidores.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Area";
            column.DataPropertyName = "area";
            column.Width = 100;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvConsumidores.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Fecha";
            column.DataPropertyName = "fecha";
            column.Width = 100;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvConsumidores.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Dia";
            column.DataPropertyName = "Dia";
            column.Width = 100;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvConsumidores.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Comida";
            column.DataPropertyName = "comida";
            column.Width = 100;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvConsumidores.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Servicio";
            column.DataPropertyName = "servicio";
            column.Width = 100;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvConsumidores.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Horario";
            column.DataPropertyName = "horario";
            column.Width = 150;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvConsumidores.Columns.Add(column);

            

            column = new DataGridViewImageColumn();
            column.HeaderText = "";
            column.DataPropertyName = "rechazar";
            column.Width = 30;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            
        }

        void Listar()
        {

          /*  try
            {*/
                checkDGV(dgvConsumidores);
                dgvConsumidores.Columns.Clear();
                ArreglaDataViewConsumidores();
                dgvConsumidores.Rows.Clear();

                foreach (RESERVA item in this.reservas)
                {

                    if (filtroSencible(item.Consumidor))
                    {
                        String comida = "";

                        if (item.Turno.DesAlmCen == 1) { comida = "Desayuno"; } else if (item.Turno.DesAlmCen == 2) { comida = "Almuerzo"; } else if (item.Turno.DesAlmCen == 3) { comida = "Cena"; }

                        String servicio = "";
                        String horario = "";
                        if (item.TipoServicio == 1) { servicio = "Presencial"; horario = item.Remplazo.HoraInicio + " - " + item.Remplazo.HoraFin; } else if (item.TipoServicio == 2) { servicio = "Bolsa"; horario = item.Horabolsa + ""; }
                        

                       

                        int n = dgvConsumidores.Rows.Add();
                        dgvConsumidores.Rows[n].Cells[0].Value = item.IdReserva;
                        dgvConsumidores.Rows[n].Cells[1].Value = item.marcado;
                        dgvConsumidores.Rows[n].Cells[2].Value = item.Consumidor.Persona.Nombres ;
                        dgvConsumidores.Rows[n].Cells[3].Value = item.Consumidor.Persona.Paterno + " " + item.Consumidor.Persona.Materno;
                        dgvConsumidores.Rows[n].Cells[4].Value = item.Consumidor.Area.Nombre;
                        dgvConsumidores.Rows[n].Cells[5].Value = item.Fecha.ToString("dd/MM/yyyy");
                        dgvConsumidores.Rows[n].Cells[6].Value = item.Turno.Dia.Nombre;
                        dgvConsumidores.Rows[n].Cells[7].Value = comida;
                        dgvConsumidores.Rows[n].Cells[8].Value = servicio;
                        dgvConsumidores.Rows[n].Cells[9].Value = horario;
                        dgvConsumidores.Rows[n].Cells[10].Value = Comedor.Vista.Properties.Resources.delete;
                    }
                }
                dgvConsumidores.RowHeadersVisible = false;
            /*}
            catch (Exception ex)
            {
                this.Close();
            }*/
           

        }

        private bool filtroSencible(consumidor item)
        {
            return((item.Persona.Nombres + " " + item.Persona.Paterno).ToUpper().Contains(txtNombre.Text.ToUpper()) || item.Persona.Materno.ToUpper().Contains(txtNombre.Text.ToUpper()));
        }

        private void checkDGV(DataGridView dgv)
        {
            foreach (DataGridViewRow item in dgv.Rows)
            {
                String idReserva = item.Cells[0].Value.ToString();

                foreach (RESERVA cons in reservas)
                {
                    if (cons.IdReserva.Equals(idReserva))
                    {
                        if (item.Cells[1].Value == null) { cons.marcado = false; }
                        else { cons.marcado = (bool)item.Cells[1].Value; }
                    }
                }
            }
        }

        private bool IsValidCellAddress(int rowIndex, int columnIndex)
        {
            return rowIndex >= 0 && rowIndex < dgvConsumidores.RowCount &&
                columnIndex >= 0 && columnIndex <= dgvConsumidores.ColumnCount;
        }

        #endregion

        #region eventos


        private void Confirm_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            Listar();
        }

        private void chbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAll.Checked) { foreach (DataGridViewRow item in dgvConsumidores.Rows) { item.Cells[1].Value = true; } }
            else { foreach (DataGridViewRow item in dgvConsumidores.Rows) { item.Cells[1].Value = false; } }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            checkDGV(dgvConsumidores);
            List<RESERVA> guardar = new List<RESERVA>();
            foreach (RESERVA item in reservas)
            {
                if (item.marcado)
                {
                    guardar.Add(item);
                }
            }
            if (guardar.Count > 0)
            {
                guardar[0].IdUsuarioConfirmacion = usuario.IdUsuario;
                _mReservas.confirmar(guardar);
                MessageBox.Show(guardar.Count + " Reservas Confirmadas!!");
                this.Close();
            }
            else { MessageBox.Show("Ninguna Reserva Seleccionada"); }
        }

        #endregion

        private void dgvConsumidores_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex) && (e.ColumnIndex == 10))
            {
                dgvConsumidores.Cursor = Cursors.Hand;
            }
        }

        private void dgvConsumidores_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex) && (e.ColumnIndex == 10))
            {
                dgvConsumidores.Cursor = Cursors.Default;
            }
        }

        private void dgvConsumidores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex))
            {
                if (e.ColumnIndex == 10)
                {
                    Rechazar form = new Rechazar();
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        String motivo = form.motivo;
                        _mReservas.rechazar(dgvConsumidores[0, e.RowIndex].Value.ToString(), motivo, this.usuario.IdUsuario);
                        Iniciar();
                    }
                }
            }
        }
    }
}
