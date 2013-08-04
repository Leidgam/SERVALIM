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

namespace Comedor.Vista.Acceso
{
    public partial class Logueo : Form
    {
        
        #region constructor
       
        public Logueo()
        {
            InitializeComponent();
        }

        #endregion

        #region declaraciones
        m_Usuario _mUsuario = new m_Usuario();
        #endregion

        #region metodos propios

        private void IniciarSesion(String login, String passw)
        {
            if (validar())
            {
                Usuario u = new Usuario();
                u.Login = login;
                u.Passw = passw;
                
                Usuario user = _mUsuario.Logeo(u);
                if (user == null)
                {
                    MessageBox.Show("Usuario y/o Contraseña Incorrecta");
                    return;
                }
                if (privConectar(user))
                {
                    Principal form = new Principal();
                    form.usuario = user;
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario Bloqueado");
                }
            }


        }

        private bool privConectar(Usuario usuario)
        {
            foreach (Usuario_Rol item in usuario.roles)
            {
                foreach (Rol_Privilegio priv in item.Rol.privilegios)
                {
                    if (priv.Privilegio.IdPrivilegio.Equals("PRI0000011"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool validar()
        {
            return true;
        }
        #endregion
        
        #region eventos

        private void btnLogueo_Click(object sender, EventArgs e)
        {
            IniciarSesion(txtLogin.Text, txtPassw.Text);
        }

        
        #endregion

        private void label4_DoubleClick(object sender, EventArgs e)
        {
          //  txtLogin.Text = " ";
           // txtPassw.Text = " ";
          //  IniciarSesion("blessed", "holaaa");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtPassw_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                IniciarSesion(txtLogin.Text, txtPassw.Text);
            }
        }
    }
}
