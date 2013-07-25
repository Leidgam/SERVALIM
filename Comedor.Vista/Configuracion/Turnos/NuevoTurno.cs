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
    public partial class NuevoTurno : Form
    {

        #region constructor
        public NuevoTurno()
        {
            InitializeComponent();
        }
        #endregion

        #region declaraciones
        public Usuario usuario;
        public List<DIA> dias;

        public bool editar;
        public TURNO editTurno;

        m_Turno _mTurno = new m_Turno();
        #endregion

        #region metodos propios

        public void Iniciar()
        {
            cargarDias();
            cmbTiempo.SelectedIndex = 0;

            if (editar)
            {
                btnCrear.Text = "Guardar";
                foreach (DIA item in cmbDias.Items)
                {
                    if (item.IdDia.Equals(editTurno.Dia.IdDia))
                    {
                        cmbDias.SelectedItem = item;
                    }
                }
                cmbDias.Enabled = false;
                cmbTiempo.SelectedIndex = editTurno.DesAlmCen - 1;
                cmbTiempo.Enabled = false;

                dtpHoraInicio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, editTurno.HoraInicio.Hours, editTurno.HoraInicio.Minutes, editTurno.HoraInicio.Seconds);

                dtpHoraFin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, editTurno.HoraFin.Hours, editTurno.HoraFin.Minutes, editTurno.HoraFin.Seconds);
            }
        }

        public void cargarDias()
        {
            if (dias.Count > 7)
            {
                this.dias.RemoveAt(7);
            }
            cmbDias.DataSource = this.dias;
            cmbDias.DisplayMember = "Nombre";
            
        }

        private void CrearTurno()
        {
            TURNO turno = new TURNO();
            turno.Dia = (DIA)cmbDias.SelectedItem;
            turno.DesAlmCen = cmbTiempo.SelectedIndex + 1;
            turno.HoraInicio = dtpHoraInicio.Value.TimeOfDay;
            turno.HoraFin = dtpHoraFin.Value.TimeOfDay;
            turno.IdUsuario = this.usuario.IdUsuario;

            _mTurno.crearTurno(turno);
        }

        private void ModificarTurno()
        {
            
            editTurno.HoraInicio = dtpHoraInicio.Value.TimeOfDay;
            editTurno.HoraFin = dtpHoraFin.Value.TimeOfDay;
            editTurno.IdUsuarioMod = this.usuario.IdUsuario;

            _mTurno.ModificarTurno(editTurno);
        }

        private bool validar()
        {
            if (dtpHoraFin.Value.TimeOfDay <= dtpHoraInicio.Value.TimeOfDay || (dtpHoraFin.Value.TimeOfDay-dtpHoraInicio.Value.TimeOfDay)>new TimeSpan(8,0,0))
            {
                MessageBox.Show("Intervalo de tiempo no permitido");
                return false;
            }
            return true;
        }

        #endregion

        #region eventos

        private void NuevoTurno_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (editar)
                {
                    ModificarTurno();

                }
                else
                {
                    CrearTurno();
                }
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

        

       
        
    }
}
