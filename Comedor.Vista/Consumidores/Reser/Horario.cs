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

namespace Comedor.Vista.Consumidores.Reservas
{
    public partial class Horario : Form
    {
        public Horario()
        {
            InitializeComponent();
        }

        #region declaraciones
        public Usuario usuario;
        public Periodo periodo;
        public consumidor consumidor;

        List<TURNO> turnos;
        m_reserva _mReserva = new m_reserva();
        #endregion

        #region metodos propios

        private void Iniciar()
        {
            lblNombre.Text = consumidor.Persona.PrimerNombre + " " + consumidor.Persona.SegundoNombre + " " + consumidor.Persona.Apellidos;
            cargarBD();
            ListarTurnos();
        }

        private void cargarBD()
        {
            
            turnos = _mReserva.getTurnos(consumidor.IdConsumidor, periodo.IdPeriodo);
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
            column.Width = 100;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column.ReadOnly = true;
            dgv.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "HORA INCIO";
            column.DataPropertyName = "tiempo";
            column.Width = 120;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "HORA FIN";
            column.DataPropertyName = "tiempo";
            column.Width = 120;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(column);

            column = new DataGridViewImageColumn();
            column.HeaderText = "Estado";
            column.DataPropertyName = "";
            column.Width = 120;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.ReadOnly = true;
            dgv.Columns.Add(column);

            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
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
            dgvHorarioDom.Columns.Clear();
            dgvHorarioLunes.Columns.Clear();
            dgvHorarioMartes.Columns.Clear();
            dgvHorarioMiercoles.Columns.Clear();
            dgvHorarioJueves.Columns.Clear();
            dgvHorarioViernes.Columns.Clear();
            dgvHorarioSabado.Columns.Clear();

            ArreglaDataViewTurnos(dgvHorarioDom);
            ArreglaDataViewTurnos(dgvHorarioLunes);
            ArreglaDataViewTurnos(dgvHorarioMartes);
            ArreglaDataViewTurnos(dgvHorarioMiercoles);
            ArreglaDataViewTurnos(dgvHorarioJueves);
            ArreglaDataViewTurnos(dgvHorarioViernes);
            ArreglaDataViewTurnos(dgvHorarioSabado);

            dgvHorarioDom.Rows.Clear();
            dgvHorarioLunes.Rows.Clear();
            dgvHorarioMartes.Rows.Clear();
            dgvHorarioMiercoles.Rows.Clear();
            dgvHorarioJueves.Rows.Clear();
            dgvHorarioViernes.Rows.Clear();
            dgvHorarioSabado.Rows.Clear();
        }

        private void ListarTurnos()
        {
            ArreglarAllDataGrid();
            foreach (TURNO item in this.turnos)
            {
                int tiposerv = 0;
                if (item.bolsa) { tiposerv = 2; } else { tiposerv = 1; }
                if (item.Dia.IdDia.Equals("001")) { if (item.remplazo) { AgregarFila(dgvHorarioDom, item.TurnRemplazo, tiposerv); } else { AgregarFila(dgvHorarioDom, item, 0); } }
                else if (item.Dia.IdDia.Equals("002")) { if (item.remplazo) { AgregarFila(dgvHorarioLunes, item.TurnRemplazo, tiposerv); } else { AgregarFila(dgvHorarioLunes, item, 0); } }
                else if (item.Dia.IdDia.Equals("003")) { if (item.remplazo) { AgregarFila(dgvHorarioMartes, item.TurnRemplazo, tiposerv); } else { AgregarFila(dgvHorarioMartes, item, 0); } }
                else if (item.Dia.IdDia.Equals("004")) { if (item.remplazo) { AgregarFila(dgvHorarioMiercoles, item.TurnRemplazo, tiposerv); } else { AgregarFila(dgvHorarioMiercoles, item, 0); } }
                else if (item.Dia.IdDia.Equals("005")) { if (item.remplazo) { AgregarFila(dgvHorarioJueves, item.TurnRemplazo, tiposerv); } else { AgregarFila(dgvHorarioJueves, item, 0); } }
                else if (item.Dia.IdDia.Equals("006")) { if (item.remplazo) { AgregarFila(dgvHorarioViernes, item.TurnRemplazo, tiposerv); } else { AgregarFila(dgvHorarioViernes, item, 0); } }
                else if (item.Dia.IdDia.Equals("007")) { if (item.remplazo) { AgregarFila(dgvHorarioSabado, item.TurnRemplazo, tiposerv); } else { AgregarFila(dgvHorarioSabado, item, 0); } }
            }
            

        }

        private void AgregarFila(DataGridView dgv, TURNO item, int TipoServicio)
        {
            //Determinar tiempo
            String tiempo = "";
            if (item.DesAlmCen == 1) { tiempo = "Desayuno"; } else if (item.DesAlmCen == 2) { tiempo = "Almuerzo"; } else if (item.DesAlmCen == 3) { tiempo = "Cena"; }

            int n = dgv.Rows.Add();
            dgv.Rows[n].Height = 50;
            dgv.Rows[n].Cells[0].Value = item.IdTurno;
            dgv.Rows[n].Cells[1].Value = item.Dia.Nombre;
            dgv.Rows[n].Cells[2].Value = tiempo;
            dgv.Rows[n].Cells[3].Value = DateTime.Today.Add(item.HoraInicio).ToString("hh:mm tt");
            dgv.Rows[n].Cells[4].Value = DateTime.Today.Add(item.HoraFin).ToString("hh:mm tt");
            if (TipoServicio == 0) { dgv.Rows[n].Cells[5].Value = Comedor.Vista.Properties.Resources.normal32x32; }
            else if (TipoServicio == 1) { dgv.Rows[n].Cells[5].Value = Comedor.Vista.Properties.Resources.rPresencial32x32; }
            else if (TipoServicio == 2) { dgv.Rows[n].Cells[5].Value = Comedor.Vista.Properties.Resources.bolsa32x32; }
        }

        private bool IsValidCellAddress(int rowIndex, int columnIndex, DataGridView dgv)
        {
            return rowIndex >= 0 && rowIndex < dgv.RowCount &&
                columnIndex >= 0 && columnIndex <= dgv.ColumnCount;
        }

        private void clickCelda(DataGridViewCellEventArgs e, DataGridView dgv)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex, dgv))
            {
                if (e.ColumnIndex == 5)
                {
                    String idTurno = dgv[0, e.RowIndex].Value.ToString();
                    opcion form = new opcion();
                    foreach (TURNO item in turnos)
                    {
                        if (item.IdTurno.Equals(idTurno))
                        {
                            if (item.remplazo)
                            {
                                if (item.bolsa) { form.recibir = 2; } else { form.recibir = 1; }
                                
                            }
                            else
                            {
                                form.recibir = 0;
                            }

                        }
                    }
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        int opcion = form.getOpcion();
                        int anterior = form.recibir;
                        if (anterior == 0)
                        {
                            //insertar reserva 
                        }
                        else
                        {
                            if (opcion == 0)
                            {
                                //eliminar logicamente
                            }
                            else
                            {
                                //update tipoServicio
                            }
                        }
                        
                        
                    }
                }
            }
        }


        #endregion

        #region eventos

        private void Horario_Load(object sender, EventArgs e)
        {
            
            Iniciar();
            
        }

        


        
        #endregion

        private void dgvHorarioDom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickCelda(e, dgvHorarioDom);
        }

        private void dgvHorarioLunes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickCelda(e, dgvHorarioLunes);
        }

        private void dgvHorarioMartes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickCelda(e, dgvHorarioMartes);
        }

        private void dgvHorarioMiercoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickCelda(e, dgvHorarioMiercoles);
        }

        private void dgvHorarioJueves_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickCelda(e, dgvHorarioJueves);
        }

        private void dgvHorarioViernes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickCelda(e, dgvHorarioViernes);
        }

        private void dgvHorarioSabado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickCelda(e, dgvHorarioSabado);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

    }
}
