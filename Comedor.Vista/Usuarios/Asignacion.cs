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
using Comedor.Modelo.Auxiliares;

namespace Comedor.Vista.Usuarios
{
    public partial class Asignacion : Form
    {
        #region constructor
        public Asignacion()
        {
            InitializeComponent();
            iniciar();
        }
        #endregion

        #region declaraciones

        //MANEJOS
        m_Usuario _mUsuario = new m_Usuario();
        m_roles _mRoles = new m_roles();

        //USUARIO
        public Usuario usuario;

        //Usuario-Roles
        List<Usuario> usuarios;
        

        //Roles-Privilegios
        List<ROL> roles;
        List<Privilegio> privilegios;

        //Cambios a Guardar
        List<cambioAsignacion> cambios = new List<cambioAsignacion>();
        #endregion

        #region metodos propios

        private void iniciar()
        {
            cargarBD();
            cargarUsuarios();
            cargarRoles();
            arreglarDGV();
            cmbUsuarios.SelectedIndex = 0;
            cmbRoles.SelectedIndex = 0;
            ListarPrilegios();
            ListarRoles();
            cargarPrivs();
        }

        private void cargarBD()
        {
            usuarios = _mUsuario.ListarUsuarios();
            roles = _mRoles.ListarRoles();
            privilegios = _mRoles.ListarPrivilegios();
        }

        private void cargarUsuarios()
        {
            cmbUsuarios.DataSource = this.usuarios;
            cmbUsuarios.DisplayMember = "Login";
        }

        private void cargarRoles()
        {
            cmbRoles.DataSource = this.roles;
            cmbRoles.DisplayMember = "Titulo1";
        }

        private void ArreglaDataView(DataGridView dgv, String titulo)
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
            column.HeaderText = titulo;
            column.DataPropertyName = "titulo";
            column.Width = 260;
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
            dgv.ReadOnly = true;

        }

        private void arreglarDGV()
        {
            ArreglaDataView(dgvRoles, "Roles");
            ArreglaDataView(dgvRolesAsig, "Roles Asignados");
            ArreglaDataView(dgvPriv, "Privilegios");
            ArreglaDataView(dgvPrivAsig, "Privilegios Asignados");
        }

        private void ListarRoles()
        {
            Usuario usu = (Usuario)cmbUsuarios.SelectedItem;
            
            dgvRoles.Rows.Clear();
            dgvRolesAsig.Rows.Clear();


            foreach (ROL item in this.roles)
            {
                if (usuarioTiene(usu.roles, item.IdRol))
                {
                    int n = dgvRolesAsig.Rows.Add();
                    dgvRolesAsig.Rows[n].Cells[0].Value = item.IdRol;
                    dgvRolesAsig.Rows[n].Cells[1].Value = item.Titulo1;

                }
                else
                {
                    int n = dgvRoles.Rows.Add();
                    dgvRoles.Rows[n].Cells[0].Value = item.IdRol;
                    dgvRoles.Rows[n].Cells[1].Value = item.Titulo1;
                }
                
            }
            dgvRoles.RowHeadersVisible = false;
            dgvRolesAsig.RowHeadersVisible = false;
        }

        private void ListarPrilegios()
        {
            ROL rol = (ROL)cmbRoles.SelectedItem;

            dgvPriv.Rows.Clear();
            dgvPrivAsig.Rows.Clear();


            foreach (Privilegio item in this.privilegios)
            {
                if (rolTiene(rol.privilegios, item.IdPrivilegio))
                {
                    int n = dgvPrivAsig.Rows.Add();
                    dgvPrivAsig.Rows[n].Cells[0].Value = item.IdPrivilegio;
                    dgvPrivAsig.Rows[n].Cells[1].Value = item.Titulo;

                }
                else
                {
                    int n = dgvPriv.Rows.Add();
                    dgvPriv.Rows[n].Cells[0].Value = item.IdPrivilegio;
                    dgvPriv.Rows[n].Cells[1].Value = item.Titulo;
                }

            }
            dgvPriv.RowHeadersVisible = false;
            dgvPrivAsig.RowHeadersVisible = false;
        }

        private void cargarNodos(String idPadre, TreeNode nodePadre)
        {
             ROL rol = (ROL)cmbRoles.SelectedItem;
            List<Privilegio> privs = new List<Privilegio>();
            foreach (Privilegio item in privilegios)
            {
                if (item.PrivilegioSup.IdPrivilegio.Equals(idPadre) && (rolTiene(rol.privilegios, item.IdPrivilegio)==false))
                {
                    privs.Add(item);
                }
            }
        
        // Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
            foreach (Privilegio item in privs)
            {
                TreeNode nuevoNodo = new TreeNode();
                nuevoNodo.Text = item.Titulo;

                // si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
                // del primer nivel que no dependen de otro nodo.
                if (nodePadre == null)
                {
                    treeView1.Nodes.Add(nuevoNodo);
                }
                // se añade el nuevo nodo al nodo padre.
                else
                {
                    nodePadre.Nodes.Add(nuevoNodo);
                }

                // Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.

                cargarNodos(item.IdPrivilegio, nuevoNodo);
            }    
        }
        private void cargarPrivs()
        {
            treeView1.Nodes.Clear();
            treeView2.Nodes.Clear();

            cargarNodos("", null);
            cargarNodosAsignados("", null);
        }

        private void cargarNodosAsignados(String idPadre, TreeNode nodePadre)
        {
            ROL rol = (ROL)cmbRoles.SelectedItem;
            List<Privilegio> privs = new List<Privilegio>();
            foreach (Privilegio item in privilegios)
            {
                if (item.PrivilegioSup.IdPrivilegio.Equals(idPadre) && (rolTiene(rol.privilegios, item.IdPrivilegio)))
                {
                    privs.Add(item);
                }
            }

            // Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
            foreach (Privilegio item in privs)
            {
                TreeNode nuevoNodo = new TreeNode();
                nuevoNodo.Text = item.Titulo;

                // si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
                // del primer nivel que no dependen de otro nodo.
                if (nodePadre == null)
                {
                    treeView2.Nodes.Add(nuevoNodo);
                }
                // se añade el nuevo nodo al nodo padre.
                else
                {
                    nodePadre.Nodes.Add(nuevoNodo);
                }

                // Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.

                cargarNodosAsignados(item.IdPrivilegio, nuevoNodo);
            }
        }

        private bool usuarioTiene(List<Usuario_Rol> roles, String idRol)
        {
            foreach (Usuario_Rol item in roles)
            {
                if (item.Rol.IdRol.Equals(idRol))
                {
                    return true;
                }
            }
            return false;
        }

        private bool rolTiene(List<Rol_Privilegio> privilegios, String idPrivilegio)
        {
            foreach (Rol_Privilegio item in privilegios)
            {
                if (item.Privilegio.IdPrivilegio.Equals(idPrivilegio))
                {
                    return true;
                }
            }
            return false;
        }


        private void  AsignarUsuario_Rol(String idRol)
        {
            foreach (ROL item in this.roles)
            {
                if (item.IdRol.Equals(idRol))
                {
                    Usuario u = (Usuario)cmbUsuarios.SelectedItem;
                    foreach (Usuario usu in this.usuarios)
                    {
                        if (u.IdUsuario.Equals(usu.IdUsuario))
                        {
                            Usuario_Rol usuRol = new Usuario_Rol();
                            usuRol.Rol = item;
                            usu.roles.Add(usuRol);

                            cambioAsignacion cambio = new cambioAsignacion();
                            cambio.usuario = true;
                            cambio.agregar = true;
                            cambio.idUsuario = usu.IdUsuario;
                            cambio.idRol = item.IdRol;

                            cambios.Add(cambio);
                            return;
                        }
                    }
                }
            }
        }

        private void QuitarUsuario_Rol(String idRol)
        {

         Usuario u = (Usuario)cmbUsuarios.SelectedItem;
         foreach (Usuario usu in this.usuarios)
         {           
             if (u.IdUsuario.Equals(usu.IdUsuario))
             {
                 foreach (Usuario_Rol item in usu.roles)
                 {
                     if (item.Rol.IdRol.Equals(idRol))
                     {
                         cambioAsignacion cambio = new cambioAsignacion();
                         cambio.usuario = true;
                         cambio.agregar = false;
                         cambio.quitar = true;
                         cambio.idUsuario = usu.IdUsuario;
                         cambio.idRol = item.Rol.IdRol;
                         usu.roles.Remove(item);
                         cambios.Add(cambio);
                         return;
                     }
                 }
                 
             }

         }
            
        }

        private void AsignarRol_Privilegio(String idPrivilegio)
        {
            foreach (Privilegio item in this.privilegios)
            {
                if (item.IdPrivilegio.Equals(idPrivilegio))
                {
                    ROL r = (ROL)cmbRoles.SelectedItem;
                    foreach (ROL rol in this.roles)
                    {
                        if (r.IdRol.Equals(rol.IdRol))
                        {
                            Rol_Privilegio rolPriv = new Rol_Privilegio();
                            rolPriv.Privilegio = item;
                            rol.privilegios.Add(rolPriv);

                            cambioAsignacion cambio = new cambioAsignacion();
                            cambio.usuario = false;
                            cambio.rol = true;
                            cambio.agregar = true;
                            cambio.idRol = rol.IdRol;
                            cambio.idPrivilegio = item.IdPrivilegio;

                            cambios.Add(cambio);
                            return;
                        }
                    }
                }
            }
        }

        private void QuitarRol_Privilegio(String idPrivilegio)
        {

            ROL r = (ROL)cmbRoles.SelectedItem;
            foreach (ROL rol in this.roles)
            {
                if (r.IdRol.Equals(rol.IdRol))
                {
                    foreach (Rol_Privilegio item in rol.privilegios)
                    {
                        if (item.Privilegio.IdPrivilegio.Equals(idPrivilegio))
                        {
                            cambioAsignacion cambio = new cambioAsignacion();
                            cambio.usuario = false;
                            cambio.rol = true;
                            cambio.agregar = false;
                            cambio.quitar = true;
                            cambio.idRol = rol.IdRol;
                            cambio.idPrivilegio = item.Privilegio.IdPrivilegio;
                            rol.privilegios.Remove(item);
                            cambios.Add(cambio);
                            return;
                        }
                    }

                }

            }

        }

        #endregion       

        #region eventos

        //Al Iniciar
        private void Asignacion_Load(object sender, EventArgs e)
        {

            
        }

        //Botones asignacion Usuario-Rol
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvRoles.Rows.Count > 0)
            {
                AsignarUsuario_Rol(dgvRoles[0, dgvRoles.CurrentRow.Index].Value.ToString());
                ListarRoles();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dgvRolesAsig.Rows.Count > 0)
            {
                QuitarUsuario_Rol(dgvRolesAsig[0, dgvRolesAsig.CurrentRow.Index].Value.ToString());
                ListarRoles();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvRoles.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in dgvRoles.Rows)
                {
                    AsignarUsuario_Rol(dgvRoles[0, item.Index].Value.ToString());
                }      
                ListarRoles();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvRolesAsig.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in dgvRolesAsig.Rows)
                {
                    QuitarUsuario_Rol(dgvRolesAsig[0, item.Index].Value.ToString());
                }
                ListarRoles();
            }
        }


        //Boton guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _mUsuario.Asignar(this.cambios);
            MessageBox.Show("Cambios Guardados");
            this.Close();
        }

        //Botones asingacion Rol-Privilegio
        private void button8_Click(object sender, EventArgs e)
        {
            if (dgvPriv.Rows.Count > 0)
            {
                AsignarRol_Privilegio(dgvPriv[0, dgvPriv.CurrentRow.Index].Value.ToString());
                ListarPrilegios();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dgvPrivAsig.Rows.Count > 0)
            {
                QuitarRol_Privilegio(dgvPrivAsig[0, dgvPrivAsig.CurrentRow.Index].Value.ToString());
                ListarPrilegios();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dgvPriv.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in dgvPriv.Rows)
                {
                    AsignarRol_Privilegio(dgvPriv[0, item.Index].Value.ToString());
                }
                ListarPrilegios();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dgvPrivAsig.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in dgvPrivAsig.Rows)
                {
                    QuitarRol_Privilegio(dgvPrivAsig[0, item.Index].Value.ToString());
                }
                ListarPrilegios();
            }
        }

        //Cambio combos
        private void cmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUsuarios.SelectedIndex >= 0 && dgvRoles.Columns.Count > 0)
            {
                ListarRoles();
            }
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedIndex >= 0 && dgvPriv.Columns.Count > 0)
            {
                ListarPrilegios();
                cargarPrivs();
            }
        }

        #endregion

   

        

    }
}
