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
    public partial class Reserva : Form
    {
        #region variables...
        public Usuario usuario;
        List<Consumidor_Periodo> ListConsumidor = new List<Consumidor_Periodo>();
        List<Consumidor_Periodo> ListReserva = new List<Consumidor_Periodo>();
        List<Consumidor_Periodo> ListTemporanea = new List<Consumidor_Periodo>();
        List<Consumidor_Periodo> ListBuscarConsumidor = new List<Consumidor_Periodo>();
        
        bool ok = true;
        bool ok2 = false;
        KeyPressEventArgs temp;
        int fila;
        #endregion

        public Reserva()
        {
            InitializeComponent();
        }

        #region evento...

        private void Reserva_Load(object sender, EventArgs e)
        {
            m_consumidor mc = new m_consumidor();
            this.ListConsumidor = mc.ListarGrupoAreaConsumidor(3, this.usuario);
            ListarReserva();

        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void txtcodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (temp != null)
            {
                if (temp.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    // Lo que hará al presionarse Enter
                    
                    List<Consumidor_Periodo> con = new List<Consumidor_Periodo>();
                    Consumidor_Periodo cp = new Consumidor_Periodo();
                    cp.Codigo = txtcodigo.Text;
                    con.Add(cp);
                    InsertarReserva(con);
                    con.Clear();
                }
            }
        }

        #endregion

        #region metodos...

        private bool buscarConsumidor(String codigo) {
            bool ok1=true;
            foreach (Consumidor_Periodo item1 in this.ListConsumidor)
            {
                if (codigo == item1.Codigo)
                {
                    return ok1 = false;
                }
            }
            return ok1;
        }

        private void ConsumidorReserva()
        {
            ListTemporanea.Clear();

            foreach (Consumidor_Periodo item1 in this.ListConsumidor)
            {
                ok = true;
                foreach(Consumidor_Periodo item2 in this.ListReserva)
                {
                    if (item1.Codigo==item2.Codigo) {
                        ok = false;
                    }
                }
                if (ok) {

                    Consumidor_Periodo cp = new Consumidor_Periodo();

                    cp.Consumidor = new consumidor();
                    cp.Consumidor.IdConsumidor = item1.Consumidor.IdConsumidor;
                    cp.Codigo = item1.Codigo;
                    cp.Consumidor.Persona = new Persona();
                    cp.Consumidor.Persona.PrimerNombre = item1.Consumidor.Persona.PrimerNombre;
                    cp.Consumidor.Persona.SegundoNombre = item1.Consumidor.Persona.SegundoNombre;
                    cp.Consumidor.Persona.Apellidos = item1.Consumidor.Persona.Apellidos;
                    cp.Consumidor.Area = new Area();
                    cp.Consumidor.Area.IdArea = item1.Consumidor.Area.IdArea;
                    cp.Consumidor.Grupo = new Grupo();
                    cp.Consumidor.Grupo.IdGrupo = item1.Consumidor.Grupo.IdGrupo;

                    ListTemporanea.Add(cp);
                }
            }
        }

        private void InsertarReserva(List<Consumidor_Periodo> consumidor) {

            foreach (Consumidor_Periodo item in consumidor)
            {

                if (buscarConsumidor(item.Codigo))
                {
                    MessageBox.Show("No pertenece a esta Recidencia");
                    return;
                }
                ConsumidorReserva();
                foreach (Consumidor_Periodo item3 in this.ListTemporanea)
                {
                    if (item.Codigo == item3.Codigo)
                    {
                        Consumidor_Periodo cp = new Consumidor_Periodo();

                        cp.Consumidor = new consumidor();
                        cp.Consumidor.IdConsumidor = item3.Consumidor.IdConsumidor;
                        cp.Codigo = item3.Codigo;
                        cp.Consumidor.Persona = new Persona();
                        cp.Consumidor.Persona.PrimerNombre = item3.Consumidor.Persona.PrimerNombre;
                        cp.Consumidor.Persona.SegundoNombre = item3.Consumidor.Persona.SegundoNombre;
                        cp.Consumidor.Persona.Apellidos = item3.Consumidor.Persona.Apellidos;
                        ListReserva.Add(cp);
                    }
                }
            }
            txtcodigo.Text = "";
            ListarReserva();
        }

        private void ListarReserva()
        {
            dgvReserva.Columns.Clear();
            ArreglaDataView1();
            dgvReserva.Rows.Clear();

            foreach (Consumidor_Periodo item in this.ListReserva)
            {
                int n = dgvReserva.Rows.Add();
                dgvReserva.Rows[n].Cells[0].Value = item.Consumidor.IdConsumidor;
                dgvReserva.Rows[n].Cells[1].Value = item.Codigo;
                dgvReserva.Rows[n].Cells[2].Value = item.Consumidor.Persona.Apellidos;
                dgvReserva.Rows[n].Cells[3].Value = item.Consumidor.Persona.PrimerNombre + " " + item.Consumidor.Persona.SegundoNombre;
            }
            dgvReserva.RowHeadersVisible = false;
        }

        private void ArreglaDataView1()
        {
            if (dgvReserva.Columns.Count > 1) return;
            dgvReserva.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgvReserva.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReserva.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvReserva.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvReserva.AutoGenerateColumns = false;


            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = "ID";
            column.DataPropertyName = "id";
            column.Width = 50;
            column.Visible = false;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReserva.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Codigo";
            column.DataPropertyName = "Codigo";
            column.Width = 80;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgvReserva.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Apellidos";
            column.DataPropertyName = "apellido";
            column.Width = 160;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column.ReadOnly = true;
            dgvReserva.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Nombres";
            column.DataPropertyName = "nombre";
            column.Width = 160;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column.ReadOnly = true;
            dgvReserva.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.ReadOnly = true;
            dgvReserva.Columns.Add(column);

            dgvReserva.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReserva.MultiSelect = false;
            dgvReserva.AllowUserToResizeColumns = true;
            dgvReserva.AllowUserToResizeRows = false;
            dgvReserva.BorderStyle = BorderStyle.FixedSingle;
            dgvReserva.RowHeadersVisible = false;
            dgvReserva.AllowUserToAddRows = false;
            dgvReserva.AllowUserToDeleteRows = false;
            dgvReserva.AllowUserToOrderColumns = false;


        }

        #endregion

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            ConsumidorReserva();
            Consumidores.Buscar form = new Consumidores.Buscar();
            form.ListConsumidor = this.ListTemporanea;
            form.usuario = usuario;
            var show = form.ShowDialog();
            if (show == DialogResult.OK)
            {
                this.ListBuscarConsumidor = form.ListReserva;
                InsertarReserva(ListBuscarConsumidor);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dgvReserva.Rows.Count > 0)
            {
                int f = Convert.ToInt32(this.dgvReserva.CurrentRow.Index);
                String idConsumidor = dgvReserva[0, f].Value.ToString();
                List<int> index = new List<int>();
                int contador = 0;
                foreach (Consumidor_Periodo item in ListReserva)
                {
                    if (item.Consumidor.IdConsumidor.Equals(idConsumidor))
                    {
                        index.Add(contador);

                    }
                    contador++;
                }
                foreach (int num in index)
                {
                    ListReserva.RemoveAt(num);
                }
                ListarReserva();
            }
        }

        private void dgvReserva_SelectionChanged(object sender, EventArgs e)
        {
            fila = Convert.ToInt32(this.dgvReserva.CurrentRow.Index);
            
        }

        private void rbnotros_CheckedChanged(object sender, EventArgs e)
        {
            ok2 = true;
            if (ok2) {
                txtotros.Visible = true;
            }
        }

        private void btnenviar_Click(object sender, EventArgs e)
        {
            if (ListReserva.Count <= 0) { return; }
            List<TURNO> listTurno = new List<TURNO>();
            List<TURNO> ListTurnoRes = new List<TURNO>();
            List<TURNO> contador = new List<TURNO>();
            int tipoServicio=0;
            String motivos="";
            if (rbnsalud.Checked || rbnestudio.Checked || rbntrabajo.Checked || (rbnotros.Checked && txtotros.Text.Equals("") == false))
            {

                if (rbnsalud.Checked) { motivos = "Salud"; }
                if (rbnestudio.Checked) { motivos = "Estudio"; }
                if (rbntrabajo.Checked) { motivos = "Trabajo"; }
                if (rbnotros.Checked) { motivos = "Otros: " + txtotros.Text; }

                if (rbnreserva.Checked || rbnbolsa.Checked)
                {
                    if (rbnreserva.Checked) { tipoServicio = 1; }
                    if (rbnbolsa.Checked) { tipoServicio = 2; }

                    if (rbndesayuno.Checked || rbnalmuerzo.Checked || rbncena.Checked)
                    {
                        if (rbndesayuno.Checked)
                        {
                            TURNO t = new TURNO();
                            t.DesAlmCen = 1;
                            listTurno.Add(t);
                        }
                        if (rbnalmuerzo.Checked)
                        {
                            TURNO t = new TURNO();
                            t.DesAlmCen = 2;
                            listTurno.Add(t);
                        }
                        if (rbncena.Checked)
                        {
                            TURNO t = new TURNO();
                            t.DesAlmCen = 3;
                            listTurno.Add(t);
                        }
                        m_reserva mr = new m_reserva();
                        if (dtpfecha.Value.Date.ToString("d") == DateTime.Now.ToString("d"))
                        {

                            ListTurnoRes = mr.TurnoReserva(1, dtpfecha.Value.Date.ToString("d"));
                        }
                        else
                        {
                            ListTurnoRes = mr.TurnoReserva(0, dtpfecha.Value.Date.ToString("d"));
                        }
                        int cont = 0;
                        foreach (TURNO item1 in ListTurnoRes)
                        {

                            foreach (TURNO item2 in listTurno)
                            {

                                if (item1.DesAlmCen == item2.DesAlmCen)
                                {

                                    foreach (Consumidor_Periodo item3 in ListReserva)
                                    {
                                        m_reserva mrt = new m_reserva();

                                        cont = mrt.RegistrarReserva(item3.Consumidor.IdConsumidor, item1.IdTurno, dtpfecha.Value.Date.ToString(), tipoServicio, usuario.IdUsuario, motivos) + cont;

                                    }
                                    TURNO tr = new TURNO();
                                    tr.Item = cont;
                                    tr.DesAlmCen = item1.DesAlmCen;
                                    contador.Add(tr);
                                    cont = 0;
                                }
                            }
                        }
                        foreach (TURNO i in contador)
                        {
                            String tiempo = "";
                            if (i.DesAlmCen == 1) { tiempo = "Desayuno"; } else if (i.DesAlmCen == 2) { tiempo = "Almuerzo"; } else if (i.DesAlmCen == 3) { tiempo = "Cena"; }
                            MessageBox.Show(tiempo + ": " + i.Item);
                        }
                        txtcodigo.Text = "";
                        ListReserva.Clear();
                        ListarReserva();

                    }
                }
            }
            else
            {
                MessageBox.Show("Ingrese el motivo");
            }
        }

    }
}
