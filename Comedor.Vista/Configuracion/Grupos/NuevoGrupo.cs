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
    public partial class NuevoGrupo : Form
    {
        #region constructor
        public NuevoGrupo()
        {
            InitializeComponent();
        }
        #endregion

        #region declaraciones
        public Usuario usuario;
        m_Grupo _mGrupo = new m_Grupo();

        public bool editar = false;
        public Grupo grupoEdit;
        #endregion

        #region metodos propios

        private void AgregarGrupo()
        {
            Grupo grupo = new Grupo();
            grupo.Nombre = txtNombre.Text;
            grupo.Descripcion = txtDescripcion.Text;
            grupo.IdUsuario = this.usuario.IdUsuario;

            _mGrupo.agregarGrupo(grupo);
        }

        private void EditarGrupo()
        {
            grupoEdit.Nombre = txtNombre.Text;
            grupoEdit.Descripcion = txtDescripcion.Text;
            grupoEdit.IdUsuarioMod = this.usuario.IdUsuario;

            _mGrupo.editarGrupo(grupoEdit);
        }


        private void Iniciar()
        {

            if (editar)
            {
                txtNombre.Text = grupoEdit.Nombre;
                txtDescripcion.Text = grupoEdit.Descripcion;

                btnCrear.Text = "Guardar";
            }
        }

        private bool validar()
        {
            if (txtNombre.Text.Equals(""))
            {
                MessageBox.Show("Falta Nombre");
                return false;
            }
            return true;
        }

        #endregion
    
        #region eventos

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (editar)
                {
                    EditarGrupo();

                }
                else
                {
                    AgregarGrupo();
                }
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void NuevoGrupo_Load(object sender, EventArgs e)
        {
            Iniciar();
        }


        #endregion

        

      

    }
}
