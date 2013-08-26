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

namespace Comedor.Vista
{
    public partial class Principal : Form
    {
        #region constructor
        public Principal()
        {
            InitializeComponent();
        }
        #endregion

        #region declaraciones
        public Usuario usuario;
        #endregion

        #region metodos propios

        private void cargarPrivilegios()
        {
            //MENU ARCHIVO
            var verSalir = subSalir.Visible = usuario.validarPrivilegio("PRI0000004");

            menArchivo.Visible = (verSalir) & usuario.validarPrivilegio("PRI0000001");

            //MENU CONSUMIDORES
            var verRegistro = subRegistro.Visible = usuario.validarPrivilegio("PRI0000005");
            var verIncidencias = subIncidencia.Visible = false;
            var verControl = subControl.Visible = usuario.validarPrivilegio("PRI0000007");
            var verMatricula = subMatricular.Visible = usuario.validarPrivilegio("PRI0000021");
            var verConfirmarRes = confirmacionRToolStripMenuItem.Visible = usuario.validarPrivilegio("PRI0000031");

            menCons.Visible = (verRegistro || verIncidencias || verControl || verMatricula) && usuario.validarPrivilegio("PRI0000002");

            //MENU USARIOS
            var verRoles = subRoles.Visible = usuario.validarPrivilegio("PRI0000008");
            var verManUsu = subManUsarios.Visible = usuario.validarPrivilegio("PRI0000009");
            var verAsig = subAsignacion.Visible = usuario.validarPrivilegio("PRI0000010");

            menUsuarios.Visible = (verRoles || verManUsu || verAsig) && usuario.validarPrivilegio("PRI0000003");

            //MENU CONFIGURACION
            var verTurnos = subTurnos.Visible = usuario.validarPrivilegio("PRI0000013");
            var verGrupos = subGrupos.Visible = usuario.validarPrivilegio("PRI0000014");

            menConfig.Visible = (verTurnos || verGrupos) && usuario.validarPrivilegio("PRI0000012");

            //MENU REPORTES
            var verConsumidoresREp = subRepConsumidor.Visible = usuario.validarPrivilegio("PRI0000029");
            var verRgistroEntradaRep = subRegistroporTurno.Visible = usuario.validarPrivilegio("PRI0000030");
            var verReservasRep = reservasToolStripMenuItem.Visible = usuario.validarPrivilegio("PRI0000033");

            menReportes.Visible = (verConsumidoresREp || verRgistroEntradaRep || verReservasRep) && usuario.validarPrivilegio("PRI0000028");
        }
        #endregion

        #region eventos

        private void subAsignacion_Click(object sender, EventArgs e)
        {
            Usuarios.Asignacion form = new Usuarios.Asignacion();
            form.usuario = this.usuario;
            form.MdiParent = this;
            form.Show();
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            cargarPrivilegios();
        }

        private void subRegistro_Click(object sender, EventArgs e)
        {
            Consumidores.Registro form = new Consumidores.Registro();
            form.usuario = this.usuario;
            form.MdiParent = this;
            Consumidores.SelectPeriodo select = new Consumidores.SelectPeriodo();
            select.todos = true;
            if (select.ShowDialog() == DialogResult.OK)
            {
                form.periodo = select.getPeriodo();
                form.Show();
            }
            
        }

        private void subGrupos_Click(object sender, EventArgs e)
        {
            Configuracion.Grupos form = new Configuracion.Grupos();
            form.usuario = this.usuario;
            form.MdiParent = this;
            form.Show();
        }

        private void subTurnos_Click(object sender, EventArgs e)
        {
            Configuracion.Turnos form = new Configuracion.Turnos();
            form.usuario = this.usuario;
            form.MdiParent = this;
            form.Show();
        }

        private void matricularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consumidores.Matricular form = new Consumidores.Matricular();
            form.usuario = this.usuario;
            form.MdiParent = this;
            form.Show();
        }

        private void reservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consumidores.Reserva form = new Consumidores.Reserva();
            form.usuario = this.usuario;
            form.MdiParent = this;
            form.Show();
        }

        private void subManUsarios_Click(object sender, EventArgs e)
        {
            Usuarios.Mantenimiento form = new Usuarios.Mantenimiento();
            form.usuario = this.usuario;
            form.MdiParent = this;
            form.Show();
        }        

        private void subRoles_Click(object sender, EventArgs e)
        {
            Usuarios.Roles form = new Usuarios.Roles();
            form.usuario = this.usuario;
            form.MdiParent = this;
            form.Show();
        }


        #endregion

        private void subRepConsumidor_Click(object sender, EventArgs e)
        {
            frmConsumidor form = new frmConsumidor();
            form.MdiParent = this;
            form.Show();
        }

        private void subRegistroporTurno_Click(object sender, EventArgs e)
        {
            frmRegistroTurno form = new frmRegistroTurno();
            form.MdiParent = this;
            form.Show();
        }

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes.Reservas form = new Reportes.Reservas();
            form.usuario = this.usuario;
            form.MdiParent = this;
            form.Show();
        }

        private void confirmacionRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consumidores.Confirmacion.Confirm form = new Consumidores.Confirmacion.Confirm();
            form.usuario = this.usuario;
            form.MdiParent = this;
            form.Show();
        }

        private void registroPorConsumidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsumoPersona form = new frmConsumoPersona();
            form.MdiParent = this;
            form.Show();
        }

        private void incidenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIncidencia form = new frmIncidencia();
            form.usuario = this.usuario;
            form.MdiParent = this;
            form.Show();
        }

        private void subControl_Click(object sender, EventArgs e)
        {
            Consumidores.Bolsas.Control_Bolsas form = new Consumidores.Bolsas.Control_Bolsas();
            form.usuario = this.usuario;
            form.MdiParent = this;
            form.Show();
        }

        private void subSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        
        }













    }
}
