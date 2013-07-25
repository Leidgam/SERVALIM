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

namespace Comedor.Vista.Consumidores
{
    public partial class Matricular : Form
    {
        public Matricular()
        {
            InitializeComponent();
        }

        #region declaraciones
        public Usuario usuario;
        public Periodo periodo;

        List<Periodo> periodos;
        m_Periodo _mPeriodo = new m_Periodo();

        List<Grupo> grupos;
        m_Grupo _mGrupo = new m_Grupo();

        List<Area> areas;
        m_Area _mArea = new m_Area();

        List<consumidor> consumidores;
        m_consumidor _mConsumidor = new m_consumidor();

        #endregion

        #region metodos

        private void Iniciar()
        {
            cargarBD();
            cargarCombos();
        }

        private void cargarBD()
        {
            periodos = _mPeriodo.ListarTodosLosPeriodos();
            grupos = _mGrupo.ListarAllGrupos();
            Grupo g = new Grupo();
            g.IdGrupo = "000";
            g.Nombre = "Todos";
            grupos.Add(g);
            areas = _mArea.ListarAllAreas();
            Area a = new Area();
            a.IdArea = "000";
            a.Nombre = "Todas";
            areas.Add(a);
        }

        private void cargarCombos()
        {
            cmbPeriodos.DataSource = periodos;
            cmbGrupos.DataSource = grupos;
            cmbAreas.DataSource = areas;

            cmbPeriodos.DisplayMember = "Descripcion";
            cmbGrupos.DisplayMember = "Nombre";
            cmbAreas.DisplayMember = "Nombre";
        }

        private void ArreglaDataView()
        {
            if (dgvConsumidores.Columns.Count > 1) return;
            dgvConsumidores.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgvConsumidores.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvConsumidores.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvConsumidores.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvConsumidores.AutoGenerateColumns = false;


            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = "ID";
            column.DataPropertyName = "id";
            column.Width = 50;
            column.Visible = false;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvConsumidores.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "No.";
            column.DataPropertyName = "no";
            column.Width = 50;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvConsumidores.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.HeaderText = "";
            column.DataPropertyName = "check";
            column.Width = 30;
            column.ReadOnly = false;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvConsumidores.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Nombre";
            column.DataPropertyName = "nombre";
            column.Width = 150;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column.ReadOnly = true;
            dgvConsumidores.Columns.Add(column);


            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Apellido";
            column.DataPropertyName = "apellido";
            column.Width = 150;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column.ReadOnly = true;
            dgvConsumidores.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Grupo";
            column.DataPropertyName = "grupo";
            column.Width = 250;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            dgvConsumidores.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Area";
            column.DataPropertyName = "area";
            column.Width = 300;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
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
            checkDGV(dgvConsumidores);
            dgvConsumidores.Columns.Clear();
            ArreglaDataView();
            dgvConsumidores.Rows.Clear();

            foreach (consumidor item in this.consumidores)
            {
                if ((item.Persona.PrimerNombre+" "+item.Persona.SegundoNombre).ToUpper().Contains(txtNombre.Text.ToUpper()) || (item.Persona.Apellidos.ToUpper().Contains(txtNombre.Text.ToUpper())))
                {
                    int n = dgvConsumidores.Rows.Add();
                    dgvConsumidores.Rows[n].Cells[0].Value = item.IdConsumidor;
                    dgvConsumidores.Rows[n].Cells[1].Value = n+1;
                    dgvConsumidores.Rows[n].Cells[2].Value = item.marcado;
                    dgvConsumidores.Rows[n].Cells[3].Value = item.Persona.PrimerNombre + " " + item.Persona.SegundoNombre;
                    dgvConsumidores.Rows[n].Cells[4].Value = item.Persona.Apellidos;
                    dgvConsumidores.Rows[n].Cells[5].Value = item.Grupo.Nombre;
                    dgvConsumidores.Rows[n].Cells[6].Value = item.Area.Nombre;
                }
            }
            
            dgvConsumidores.RowHeadersVisible = false;

        }

        #endregion


        #region eventos
        private void Matricular_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            consumidores = _mConsumidor.ListarConsumidores(((Periodo)cmbPeriodos.SelectedItem).IdPeriodo, ((Grupo)cmbGrupos.SelectedItem).IdGrupo, ((Area)cmbAreas.SelectedItem).IdArea);
            Listar();
        }

        private void chbTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTodo.Checked)
            {
                foreach (DataGridViewRow item in dgvConsumidores.Rows)
                {
                    item.Cells[2].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow item in dgvConsumidores.Rows)
                {
                    item.Cells[2].Value = false;
                }
            }
        }

        private void checkDGV(DataGridView dgv)
        {
            foreach (DataGridViewRow item in dgv.Rows)
            {
                String idConsumidor = item.Cells[0].Value.ToString();

                foreach (consumidor cons in consumidores)
                {
                    if (cons.IdConsumidor.Equals(idConsumidor))
                    {
                        if (item.Cells[2].Value == null) { cons.marcado = false; }
                        else { cons.marcado = (bool)item.Cells[2].Value; }
                    }
                }
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            Listar();
        }

        private bool buscar(List<consumidor> lista, consumidor item)
        {
            foreach (consumidor ite in lista)
            {
                if (ite.IdConsumidor.Equals(item.IdConsumidor))
                {
                    return true;
                }
            }
            return false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Los Codigos Se Auto-Asignaran, desea continuar?", "Matricular", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SelectPeriodo form = new SelectPeriodo();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Periodo periodo = form.getPeriodo();
                    List<consumidor> marcados = new List<consumidor>();
                    checkDGV(dgvConsumidores);
                    foreach (consumidor item in consumidores)
                    {
                        if (item.marcado) { marcados.Add(item); }
                    }
                    List<consumidor> matriculados = _mConsumidor.ListarInscritos(marcados, periodo.IdPeriodo);
                    List<consumidor> guardar = new List<consumidor>();
                    foreach (consumidor item in marcados)
                    {
                        if (buscar(matriculados, item)==false)
                        {
                            guardar.Add(item);
                        }                        
                    }
                    if (guardar.Count > 400) { MessageBox.Show("El limite de matriculas por bloque es de 400"); return; }
                    MessageBox.Show("De la lista seleccionada, ya estan matriculados en este periodo: "+matriculados.Count+" \n Por matricular en este periodo: "+guardar.Count+" \n Total: "+marcados.Count,"Información - Solicitud de Matricula");
                    if (guardar.Count > 0)
                    {
                        guardar[0].IdUsuarioReg = this.usuario.IdUsuario;
                        Recursos.Save save = new Recursos.Save();
                        save.guardar = guardar;
                        save.idPeriodo = periodo.IdPeriodo;
                        if (save.ShowDialog() == DialogResult.OK)
                        {
                            if (MessageBox.Show(guardar.Count + " Consumidores Matriculados en el Periodo " + periodo.Descripcion + "!!!  \n \n ¿Desea realizar otra Matricula?", "Matricula Completa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                this.Close();
                            }
                        }

                        
                    }
                }
            }
        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            consumidores = _mConsumidor.ListarConsumidores(((Periodo)cmbPeriodos.SelectedItem).IdPeriodo, ((Grupo)cmbGrupos.SelectedItem).IdGrupo, ((Area)cmbAreas.SelectedItem).IdArea);
            Listar();
        }
    }
}
