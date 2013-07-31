namespace Comedor.Vista
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.subSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.menCons = new System.Windows.Forms.ToolStripMenuItem();
            this.subRegistro = new System.Windows.Forms.ToolStripMenuItem();
            this.subIncidencia = new System.Windows.Forms.ToolStripMenuItem();
            this.subControl = new System.Windows.Forms.ToolStripMenuItem();
            this.subMatricular = new System.Windows.Forms.ToolStripMenuItem();
            this.reservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.confirmacionRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.subRoles = new System.Windows.Forms.ToolStripMenuItem();
            this.subManUsarios = new System.Windows.Forms.ToolStripMenuItem();
            this.subAsignacion = new System.Windows.Forms.ToolStripMenuItem();
            this.menConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.subTurnos = new System.Windows.Forms.ToolStripMenuItem();
            this.subGrupos = new System.Windows.Forms.ToolStripMenuItem();
            this.menReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.subRepConsumidor = new System.Windows.Forms.ToolStripMenuItem();
            this.subRegistroporTurno = new System.Windows.Forms.ToolStripMenuItem();
            this.reservasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroPorConsumidorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incidenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Symbol", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menArchivo,
            this.menCons,
            this.menUsuarios,
            this.menConfig,
            this.menReportes});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(854, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menArchivo
            // 
            this.menArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subSalir});
            this.menArchivo.Name = "menArchivo";
            this.menArchivo.Size = new System.Drawing.Size(75, 25);
            this.menArchivo.Text = "Archivo";
            // 
            // subSalir
            // 
            this.subSalir.Name = "subSalir";
            this.subSalir.Size = new System.Drawing.Size(111, 26);
            this.subSalir.Text = "Salir";
            // 
            // menCons
            // 
            this.menCons.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subRegistro,
            this.subIncidencia,
            this.subControl,
            this.subMatricular,
            this.reservaToolStripMenuItem,
            this.confirmacionRToolStripMenuItem});
            this.menCons.Name = "menCons";
            this.menCons.Size = new System.Drawing.Size(123, 25);
            this.menCons.Text = "Consumidores";
            // 
            // subRegistro
            // 
            this.subRegistro.Name = "subRegistro";
            this.subRegistro.Size = new System.Drawing.Size(254, 26);
            this.subRegistro.Text = "Registro";
            this.subRegistro.Click += new System.EventHandler(this.subRegistro_Click);
            // 
            // subIncidencia
            // 
            this.subIncidencia.Name = "subIncidencia";
            this.subIncidencia.Size = new System.Drawing.Size(254, 26);
            this.subIncidencia.Text = "Incidencias";
            // 
            // subControl
            // 
            this.subControl.Name = "subControl";
            this.subControl.Size = new System.Drawing.Size(254, 26);
            this.subControl.Text = "Control";
            // 
            // subMatricular
            // 
            this.subMatricular.Name = "subMatricular";
            this.subMatricular.Size = new System.Drawing.Size(254, 26);
            this.subMatricular.Text = "Matricular";
            this.subMatricular.Click += new System.EventHandler(this.matricularToolStripMenuItem_Click);
            // 
            // reservaToolStripMenuItem
            // 
            this.reservaToolStripMenuItem.Name = "reservaToolStripMenuItem";
            this.reservaToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.reservaToolStripMenuItem.Text = "Reserva";
            this.reservaToolStripMenuItem.Click += new System.EventHandler(this.reservaToolStripMenuItem_Click);
            // 
            // confirmacionRToolStripMenuItem
            // 
            this.confirmacionRToolStripMenuItem.Name = "confirmacionRToolStripMenuItem";
            this.confirmacionRToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.confirmacionRToolStripMenuItem.Text = "Confirmación de Reserva";
            this.confirmacionRToolStripMenuItem.Click += new System.EventHandler(this.confirmacionRToolStripMenuItem_Click);
            // 
            // menUsuarios
            // 
            this.menUsuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subRoles,
            this.subManUsarios,
            this.subAsignacion});
            this.menUsuarios.Name = "menUsuarios";
            this.menUsuarios.Size = new System.Drawing.Size(83, 25);
            this.menUsuarios.Text = "Usuarios";
            // 
            // subRoles
            // 
            this.subRoles.Name = "subRoles";
            this.subRoles.Size = new System.Drawing.Size(272, 26);
            this.subRoles.Text = "Roles";
            this.subRoles.Click += new System.EventHandler(this.subRoles_Click);
            // 
            // subManUsarios
            // 
            this.subManUsarios.Name = "subManUsarios";
            this.subManUsarios.Size = new System.Drawing.Size(272, 26);
            this.subManUsarios.Text = "Mantenimiento de Usuarios";
            this.subManUsarios.Click += new System.EventHandler(this.subManUsarios_Click);
            // 
            // subAsignacion
            // 
            this.subAsignacion.Name = "subAsignacion";
            this.subAsignacion.Size = new System.Drawing.Size(272, 26);
            this.subAsignacion.Text = "Asignación";
            this.subAsignacion.Click += new System.EventHandler(this.subAsignacion_Click);
            // 
            // menConfig
            // 
            this.menConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subTurnos,
            this.subGrupos});
            this.menConfig.Name = "menConfig";
            this.menConfig.Size = new System.Drawing.Size(120, 25);
            this.menConfig.Text = "Configuración";
            // 
            // subTurnos
            // 
            this.subTurnos.Name = "subTurnos";
            this.subTurnos.Size = new System.Drawing.Size(131, 26);
            this.subTurnos.Text = "Turnos";
            this.subTurnos.Click += new System.EventHandler(this.subTurnos_Click);
            // 
            // subGrupos
            // 
            this.subGrupos.Name = "subGrupos";
            this.subGrupos.Size = new System.Drawing.Size(131, 26);
            this.subGrupos.Text = "Grupos";
            this.subGrupos.Click += new System.EventHandler(this.subGrupos_Click);
            // 
            // menReportes
            // 
            this.menReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subRepConsumidor,
            this.subRegistroporTurno,
            this.reservasToolStripMenuItem,
            this.registroPorConsumidorToolStripMenuItem,
            this.incidenciaToolStripMenuItem});
            this.menReportes.Name = "menReportes";
            this.menReportes.Size = new System.Drawing.Size(84, 25);
            this.menReportes.Text = "Reportes";
            // 
            // subRepConsumidor
            // 
            this.subRepConsumidor.Name = "subRepConsumidor";
            this.subRepConsumidor.Size = new System.Drawing.Size(256, 26);
            this.subRepConsumidor.Text = "Consumidor";
            this.subRepConsumidor.Click += new System.EventHandler(this.subRepConsumidor_Click);
            // 
            // subRegistroporTurno
            // 
            this.subRegistroporTurno.Name = "subRegistroporTurno";
            this.subRegistroporTurno.Size = new System.Drawing.Size(256, 26);
            this.subRegistroporTurno.Text = "Registro por Turno";
            this.subRegistroporTurno.Click += new System.EventHandler(this.subRegistroporTurno_Click);
            // 
            // reservasToolStripMenuItem
            // 
            this.reservasToolStripMenuItem.Name = "reservasToolStripMenuItem";
            this.reservasToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.reservasToolStripMenuItem.Text = "Reservas";
            this.reservasToolStripMenuItem.Click += new System.EventHandler(this.reservasToolStripMenuItem_Click);
            // 
            // registroPorConsumidorToolStripMenuItem
            // 
            this.registroPorConsumidorToolStripMenuItem.Name = "registroPorConsumidorToolStripMenuItem";
            this.registroPorConsumidorToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.registroPorConsumidorToolStripMenuItem.Text = "Registro por Consumidor";
            this.registroPorConsumidorToolStripMenuItem.Click += new System.EventHandler(this.registroPorConsumidorToolStripMenuItem_Click);
            // 
            // incidenciaToolStripMenuItem
            // 
            this.incidenciaToolStripMenuItem.Name = "incidenciaToolStripMenuItem";
            this.incidenciaToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.incidenciaToolStripMenuItem.Text = "Incidencia";
            this.incidenciaToolStripMenuItem.Click += new System.EventHandler(this.incidenciaToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Comedor.Vista.Properties.Resources.Fondo_Comedor___SC;
            this.ClientSize = new System.Drawing.Size(854, 470);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menArchivo;
        private System.Windows.Forms.ToolStripMenuItem subSalir;
        private System.Windows.Forms.ToolStripMenuItem menCons;
        private System.Windows.Forms.ToolStripMenuItem menUsuarios;
        private System.Windows.Forms.ToolStripMenuItem subRegistro;
        private System.Windows.Forms.ToolStripMenuItem subIncidencia;
        private System.Windows.Forms.ToolStripMenuItem subControl;
        private System.Windows.Forms.ToolStripMenuItem subRoles;
        private System.Windows.Forms.ToolStripMenuItem subManUsarios;
        private System.Windows.Forms.ToolStripMenuItem subAsignacion;
        private System.Windows.Forms.ToolStripMenuItem menConfig;
        private System.Windows.Forms.ToolStripMenuItem subTurnos;
        private System.Windows.Forms.ToolStripMenuItem subGrupos;
        private System.Windows.Forms.ToolStripMenuItem subMatricular;
        private System.Windows.Forms.ToolStripMenuItem reservaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menReportes;
        private System.Windows.Forms.ToolStripMenuItem subRepConsumidor;
        private System.Windows.Forms.ToolStripMenuItem subRegistroporTurno;
        private System.Windows.Forms.ToolStripMenuItem reservasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem confirmacionRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroPorConsumidorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incidenciaToolStripMenuItem;
    }
}

