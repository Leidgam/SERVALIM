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
using Comedor.Modelo.Entidades;
using Comedor.Control;

namespace Comedor.Vista
{
    public partial class frmConsumoPersona : Form
    {

        #region variables...
        List<DateTime> ListFecha = new List<DateTime>();
        List<ConsumidorTurno> ListConsumidorTurno = new List<ConsumidorTurno>();
        List<ConsumidorTurno> ListRegistro = new List<ConsumidorTurno>();
        consumidor datosconsumidor;
        KeyPressEventArgs temp;
        String idconsumidor = "";

        
        #endregion

        public frmConsumoPersona()
        {
            InitializeComponent();
        }

        #region Metodos...

        public void ubicacion(Panel panel, bool visible)
        {
            panel2.Visible = false;
            panel1.Visible = false;
            if (visible)
            {
                panel.Visible = true;
                panel.Location = new Point(10, 52);
            }
        }
        
        public void ubicacionIcono(Button boton, bool visible)
        {
            btnRojo.Visible = false;
            btnAmarillo.Visible = false;
            btnVerde.Visible = false;
            if (visible)
            {
                boton.Visible = true;
                boton.Location = new Point(104, 247);
            }
        }      

        private void fechas(int tipo)
        {
            ListFecha.Clear();
            DateTime fu = dtpFechaUno.Value.Date;
            DateTime fi = dtpFechaInicio.Value.Date;
            DateTime ff = dtpFechaFin.Value.Date;

            if (tipo == 1)
            {
                ListFecha.Add(fu);       
            }
            if (tipo == 2)
            {
                while (fi <= ff)
                {
                    ListFecha.Add(fi);
                    fi = fi.AddDays(1);
                }
            }
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
            column.Width = 120;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgvRegistro.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "DES-ALM-CEN";
            column.DataPropertyName = "DesAlmCen";
            column.Width = 150;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgvRegistro.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "HORA";
            column.DataPropertyName = "hora";
            column.Width = 150;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgvRegistro.Columns.Add(column);

            column = new DataGridViewImageColumn();
            column.HeaderText = "";
            column.DataPropertyName = "sino";
            column.Width = 30;
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

        void iniciar()
        {
            m_consumidor mm = new m_consumidor();
            if (mm.existeconsumidor(txtCodigo.Text) != 1)
            {
                MessageBox.Show("Codigo invalido");
                txtCodigo.Text = "";
                return;
            }
            idconsumidor = mm.IdConsumidor(txtCodigo.Text);
            datosconsumidor = new consumidor();
            datosconsumidor= mm.Consumidor_reg(idconsumidor);
            txtnombre.Text = datosconsumidor.Persona.Apellidos + " " + datosconsumidor.Persona.PrimerNombre;
            txtResidencia.Text = datosconsumidor.Area.Nombre;
            txtFacultad.Text = datosconsumidor.EAP.Facultad.Nombre;
            txtEAP.Text = datosconsumidor.EAP.Nombre;
            txtCodUniv.Text = datosconsumidor.CodUniversitario;
            pbxFoto.Image = Image.FromFile("D:/Comedor2.0/Fotos/"+datosconsumidor.Persona.IdPersona+".jpg");

            //fecha FechaUno-FechaDesde/Hasta
            int tipo=0;

            String fechaUno = "";
            if (rbnUnafecha.Checked) { fechaUno = dtpFechaUno.Value.Date.ToString("d"); tipo=1; }

            String fechaInicio = "";
            String fechaFin = "";
            if (rbnDesdeHasta.Checked) 
            { 
                fechaInicio = dtpFechaInicio.Value.Date.ToString("d"); 
                fechaFin = dtpFechaFin.Value.Date.ToString("d"); 
                tipo=2;
            }
            fechas(tipo);

            ListConsumidorTurno.Clear();
            ListRegistro.Clear();

            m_consumidor mc = new m_consumidor();
            this.ListConsumidorTurno= mc.ConsumoXPersona(idconsumidor, fechaUno, fechaInicio, fechaFin, tipo);

            bool okG = false; bool ok1 = true; bool ok2 = true; bool ok3 = true;

            int DesSi = 0; int DesNo = 0;
            int AlmSi = 0; int AlmNo = 0;
            int CenSi = 0; int CenNo = 0;

            foreach (DateTime item1 in this.ListFecha)
            {
                foreach (ConsumidorTurno item2 in this.ListConsumidorTurno)
                {
                    if (item1.Date.ToString("d") == item2.Fecha.Date.ToString("d") & item2.Turno.DesAlmCen == 1) { okG = true; ok1 = false; DesSi++; }
                    if (item1.Date.ToString("d") == item2.Fecha.Date.ToString("d") & item2.Turno.DesAlmCen == 2) { okG = true; ok2 = false; AlmSi++; }
                    if (item1.Date.ToString("d") == item2.Fecha.Date.ToString("d") & item2.Turno.DesAlmCen == 3) { okG = true; ok3 = false; CenSi++; }
                    
                    if (okG)
                    {
                        ConsumidorTurno ct = new ConsumidorTurno();
                        ct.Fecha = item2.Fecha;
                        ct.Turno = new TURNO();
                        ct.Turno.DesAlmCen = item2.Turno.DesAlmCen;
                        ct.Estado = item2.Estado;
                        ct.Hora = item2.Hora;

                        ListRegistro.Add(ct);
                        okG = false;
                    }
                }

                if (ok1)
                {
                    ConsumidorTurno ct = new ConsumidorTurno();
                    ct.Fecha = item1;
                    ct.Turno = new TURNO();
                    ct.Turno.DesAlmCen = 1;
                    ct.Estado = 0;
                    ListRegistro.Add(ct);
                    DesNo++;
                }
                if (ok2) 
                {
                    ConsumidorTurno ct = new ConsumidorTurno();
                    ct.Fecha = item1;
                    ct.Turno = new TURNO();
                    ct.Turno.DesAlmCen = 2;
                    ct.Estado = 0;
                    ListRegistro.Add(ct);
                    AlmNo++;
                }
                if (ok3) 
                {
                    ConsumidorTurno ct = new ConsumidorTurno();
                    ct.Fecha = item1;
                    ct.Turno = new TURNO();
                    ct.Turno.DesAlmCen = 3;
                    ct.Estado = 0;
                    ListRegistro.Add(ct);
                    CenNo++;
                }
                ok1 = true; ok2 = true; ok3 = true; okG = false;
            }
            lblDesSi.Text = DesSi.ToString(); lblDesNo.Text = DesNo.ToString();
            lblAlmSi.Text = AlmSi.ToString(); lblAlmNo.Text = AlmNo.ToString();
            lblCenSi.Text = CenSi.ToString(); lblCenNo.Text = CenNo.ToString();
            m_consumidor mcon = new m_consumidor();
            List<Incidencia> ListInc = new List<Incidencia>();
            ListInc = mcon.ListarIncidencias(idconsumidor);
            lblIncidencia.Text = ListInc.Count().ToString();
            if (ListInc.Count() < 3) { ubicacionIcono(btnVerde, true); }
            if (ListInc.Count() == 3) { ubicacionIcono(btnAmarillo, true); }
            if (ListInc.Count() > 3) { ubicacionIcono(btnRojo, true); }
            listar();
        }

        void listar()
        {
            dgvRegistro.Columns.Clear();
            ArreglaDataView1();
            dgvRegistro.Rows.Clear();

            foreach (ConsumidorTurno item in this.ListRegistro)
            {
                int n = dgvRegistro.Rows.Add();

                dgvRegistro.Rows[n].Cells[0].Value = n + 1;
                dgvRegistro.Rows[n].Cells[1].Value = item.Fecha.Date.ToString("d");
                dgvRegistro.Rows[n].Cells[2].Value = item.Fecha.ToString("dddd", new System.Globalization.CultureInfo("es-ES"));

                if (item.Turno.DesAlmCen == 1) { dgvRegistro.Rows[n].Cells[3].Value = "Desayuno"; }
                if (item.Turno.DesAlmCen == 2) { dgvRegistro.Rows[n].Cells[3].Value = "Almuerzo"; }
                if (item.Turno.DesAlmCen == 3) { dgvRegistro.Rows[n].Cells[3].Value = "Cena"; }

                if (item.Hora.Hour.ToString() == "0") { dgvRegistro.Rows[n].Cells[4].Value = "-"; }
                else { dgvRegistro.Rows[n].Cells[4].Value = item.Hora.ToLongTimeString(); }


                if (item.Estado == 1){ dgvRegistro.Rows[n].Cells[5].Value = Comedor.Vista.Properties.Resources.accept; }
                else{ dgvRegistro.Rows[n].Cells[5].Value = Comedor.Vista.Properties.Resources.delete;}
                
            }
            dgvRegistro.RowHeadersVisible = false;
        }
        #endregion

        #region eventos...
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            iniciar();
        }

        private void frmConsumoPersona_Load(object sender, EventArgs e)
        {
            rbnUnafecha.Checked = true;
            panel1.Visible = false;
            dgvRegistro.Columns.Clear();
            ArreglaDataView1();
            dgvRegistro.Rows.Clear();
            ubicacionIcono(btnVerde, true);
            groupBox3.Visible = false;
        }

        private void rbnUnafecha_CheckedChanged(object sender, EventArgs e)
        {
            ubicacion(panel2, true);
        }

        private void rbnDesdeHasta_CheckedChanged(object sender, EventArgs e)
        {
            ubicacion(panel1, true);
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCodigo.Text == "") {
                return;
            }
            temp = e;
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                }
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (temp != null)
            {
                if (temp.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    // Lo que hará al presionarse Enter

                    iniciar();
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text == "")
            {
                MessageBox.Show("Inserte el codigo");
                return;
            }
            MessageBox.Show(datosconsumidor.Area.Nombre);
            Reportes.PrintReportConsumidorPersona from = new Reportes.PrintReportConsumidorPersona();
            from.ListConsumidor = ListRegistro;
            from.cons = datosconsumidor;
            from.ShowDialog();
        }

        private void btnSig_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox3.Visible = true;
            groupBox3.Location = new Point(3, 232);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (groupBox3.Visible) { groupBox3.Visible = false; groupBox2.Visible = true; groupBox2.Location = new Point(3, 232); }
            else { this.Size = new System.Drawing.Size(725, 627); btnDetalles.Visible = true; }
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(944, 627);
            btnDetalles.Visible = false;
        }

        #endregion

    }
}
