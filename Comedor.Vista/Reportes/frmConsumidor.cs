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
    public partial class frmConsumidor : Form
    {
        #region variables...
        List<EAP> ListPeriodo = new List<EAP>();
        List<EAP> ListArea = new List<EAP>();
        List<EAP> ListGrupo = new List<EAP>();
        List<EAP> ListFacultad = new List<EAP>();
        List<EAP> ListEAP = new List<EAP>();
        List<Consumidor_Periodo> ListConsumidor = new List<Consumidor_Periodo>();
        int CantidadTotal = 0;
        String periodo = "";
        String grupo = "";
        String area = "";
        String facultad = "";
        String escuela = "";
        String Nomciclo = "";
        int ciclo = 0;


        //consumidores -registro de entrada
        public int tipoturno;
        public String idturno;
        public String fecha;

        #endregion

        public frmConsumidor()
        {
            InitializeComponent();
        }

        public void cargarBD()
        {
            m_consumidor mc = new m_consumidor();

            this.ListPeriodo = mc.llenar_Filtro("Periodo");
            this.ListArea = mc.llenar_Filtro("Area");
            this.ListGrupo = mc.llenar_Filtro("Grupo");
            this.ListFacultad = mc.llenar_Filtro("Facultad");
            this.ListEAP = mc.llenar_Filtro("EAP");

            EAP p = new EAP();
            p.IdEAP = "000";
            p.Nombre = "Todos";
            p.Facultad = new Facultad();
            p.Facultad.IdFacultad = "000";

            ListArea.Add(p);
            ListGrupo.Add(p);
            ListFacultad.Add(p);
            ListEAP.Add(p);
        }

        #region metodos...

        private void frmConsumidor_Load(object sender, EventArgs e)
        {
            lblperiodo.Visible = false;
            llenarCombo();
            llenarconsumidor();
            if(tipoturno != 0)
            {
                m_consumidor mc= new m_consumidor();
                Periodo per = mc.IdPeriodo(fecha);
                cmbPeriodo.SelectedItem = per.IdPeriodo;
                cmbPeriodo.Visible = false;
                lblperiodo.Visible = true;
                lblperiodo.Text = per.Descripcion;
            }
            Listar();
        }

        public void llenarCombo()
        {
            cargarBD();
            

            cmbPeriodo.DataSource = ListPeriodo;
            cmbArea.DataSource = ListArea;
            cmbGrupo.DataSource = ListGrupo;
            cmbFacultad.DataSource = ListFacultad;
            
            cmbPeriodo.DisplayMember = "Nombre";
            cmbArea.DisplayMember = "Nombre";
            cmbGrupo.DisplayMember = "Nombre";
            cmbFacultad.DisplayMember = "Nombre";

            cmbArea.SelectedItem = "000";
            cmbArea.SelectedIndex = ListArea.Count()-1;
            cmbGrupo.SelectedItem = "000";
            cmbGrupo.SelectedIndex = ListGrupo.Count()-1;
            cmbFacultad.SelectedItem = "000";
            cmbFacultad.SelectedIndex = ListFacultad.Count()-1;
            cmbCiclo.SelectedIndex = 0;
            
        }

        private void cargarEscuelas()
        {

            List<EAP> ListTemp = new List<EAP>();

            if (((EAP)cmbFacultad.SelectedItem).IdEAP=="000") {
                cmbEAP.DataSource = ListEAP;
                cmbEAP.DisplayMember = "Nombre";
                cmbEAP.SelectedIndex = ListEAP.Count() - 1;
                return;
            }
           
            foreach (EAP item1 in this.ListEAP)
            {
                
                if (((EAP)cmbFacultad.SelectedItem).IdEAP == item1.Facultad.IdFacultad)
                {
                    EAP t = new EAP();
                    t.IdEAP = item1.IdEAP;
                    t.Nombre = item1.Nombre;
                    ListTemp.Add(t);
                } 
            }

            EAP tm = new EAP();
            tm.IdEAP = "000";
            tm.Nombre = "Todos";
            ListTemp.Add(tm);

            cmbEAP.DataSource = ListTemp;
            cmbEAP.DisplayMember = "Nombre";
            cmbEAP.SelectedIndex = ListTemp.Count() - 1;
            return;
        }

        public void llenarconsumidor()
        {
            m_consumidor ctrlmc = new m_consumidor();
            periodo = ((EAP)cmbPeriodo.SelectedItem).IdEAP;
            area = ((EAP)cmbArea.SelectedItem).IdEAP;
            grupo = ((EAP)cmbGrupo.SelectedItem).IdEAP;
            facultad = ((EAP)cmbFacultad.SelectedItem).IdEAP;
            escuela = ((EAP)cmbEAP.SelectedItem).IdEAP;
            ciclo = cmbCiclo.SelectedIndex;
            Nomciclo = cmbCiclo.SelectedItem.ToString();

           
            m_consumidor mc = new m_consumidor();
            this.ListConsumidor = ctrlmc.filtro_consumidor(periodo, area, grupo, facultad, escuela, ciclo, tipoturno,idturno,fecha);//3 ultimas variables para REG-ENTR
        }

        private void Listar()
        {
            dgvConsumidor.Columns.Clear();
            ArreglaDataView();
            dgvConsumidor.Rows.Clear();
            CantidadTotal = 0;
            foreach (Consumidor_Periodo item in this.ListConsumidor)
            {
                if ((item.Consumidor.Persona.Nombres + " " + item.Consumidor.Persona.Paterno).ToUpper().Contains(txtNombre.Text.ToUpper()) || (item.Consumidor.Persona.Materno.ToUpper().Contains(txtNombre.Text.ToUpper())))
                {
                    int n = dgvConsumidor.Rows.Add();
                    dgvConsumidor.Rows[n].Cells[0].Value = item.Consumidor.IdConsumidor;
                    dgvConsumidor.Rows[n].Cells[1].Value = item.Codigo;
                    dgvConsumidor.Rows[n].Cells[2].Value = item.Consumidor.Persona.Nombres;
                    dgvConsumidor.Rows[n].Cells[3].Value = item.Consumidor.Persona.Paterno+ " "+item.Consumidor.Persona.Materno;
                    if (item.Consumidor.CodUniversitario == " " || item.Consumidor.CodUniversitario == "" || item.Consumidor.CodUniversitario == null)
                    {
                        dgvConsumidor.Rows[n].Cells[4].Value = "-";
                    }
                    else
                    {
                        dgvConsumidor.Rows[n].Cells[4].Value = item.Consumidor.CodUniversitario;
                    }
                    
                }
                
                CantidadTotal = CantidadTotal + 1;
            }
            dgvConsumidor.RowHeadersVisible = false;
            txtTotal.Text = CantidadTotal.ToString();

        }

        private void ArreglaDataView()
        {
            if (dgvConsumidor.Columns.Count > 1) return;
            dgvConsumidor.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
            dgvConsumidor.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvConsumidor.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvConsumidor.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvConsumidor.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = "ID";
            column.DataPropertyName = "id";
            column.Width = 50;
            column.Visible = false;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvConsumidor.Columns.Add(column);


            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "CODIGO";
            column.DataPropertyName = "codigo";
            column.Width = 120;
            column.Visible = true;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvConsumidor.Columns.Add(column);


            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "NOMBRES";
            column.DataPropertyName = "nombre";
            column.Width = 210;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgvConsumidor.Columns.Add(column);


            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Apellidos";
            column.DataPropertyName = "apellido";
            column.Width = 220;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgvConsumidor.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "COD. UNIV";
            column.DataPropertyName = "coduniv";
            column.Width = 180;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgvConsumidor.Columns.Add(column);


            column = new DataGridViewTextBoxColumn();
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.ReadOnly = true;
            dgvConsumidor.Columns.Add(column);

            dgvConsumidor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsumidor.MultiSelect = false;
            dgvConsumidor.AllowUserToResizeColumns = true;
            dgvConsumidor.AllowUserToResizeRows = false;
            dgvConsumidor.BorderStyle = BorderStyle.FixedSingle;
            dgvConsumidor.RowHeadersVisible = false;
            dgvConsumidor.AllowUserToAddRows = false;
            dgvConsumidor.AllowUserToDeleteRows = false;
            dgvConsumidor.AllowUserToOrderColumns = false;


        }

        #endregion

        #region eventos...

        

        private void cmbFacultad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarEscuelas();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            llenarconsumidor();
            Listar();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            Listar();
        }

        #endregion

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reportes.PrintReportConsumidor from = new Reportes.PrintReportConsumidor();
            from.ListConsumidor = ListConsumidor;
            from.CantidadTotal = CantidadTotal;
            from.periodo = ((EAP)cmbPeriodo.SelectedItem).Nombre;
            if (area == "000") { from.area = " -"; } else { from.area = ((EAP)cmbArea.SelectedItem).Nombre; }
            if (grupo == "000") { from.grupo = " -"; } else { from.grupo = ((EAP)cmbGrupo.SelectedItem).Nombre; }
            if (facultad == "000") { from.facultad = " -"; } else { from.facultad = ((EAP)cmbFacultad.SelectedItem).Nombre; }
            if (escuela == "000") { from.escuela = " -"; } else { from.escuela = ((EAP)cmbEAP.SelectedItem).Nombre; }
            if (ciclo == 0) { from.ciclo = " -"; } else { from.ciclo =  cmbCiclo.SelectedItem.ToString() ; }

            from.ShowDialog();
        }

        private void dgvConsumidor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
