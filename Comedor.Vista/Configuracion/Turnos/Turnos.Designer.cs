namespace Comedor.Vista.Configuracion
{
    partial class Turnos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbDia = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTiempo = new System.Windows.Forms.ComboBox();
            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnNuevoTurno = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbDia
            // 
            this.cmbDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDia.FormattingEnabled = true;
            this.cmbDia.Location = new System.Drawing.Point(92, 26);
            this.cmbDia.Name = "cmbDia";
            this.cmbDia.Size = new System.Drawing.Size(129, 21);
            this.cmbDia.TabIndex = 0;
            this.cmbDia.SelectedIndexChanged += new System.EventHandler(this.cmbDia_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Día:";
            // 
            // cmbTiempo
            // 
            this.cmbTiempo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTiempo.FormattingEnabled = true;
            this.cmbTiempo.Items.AddRange(new object[] {
            "Desayuno",
            "Almuerzo",
            "Cena",
            "Todos los tiempos"});
            this.cmbTiempo.Location = new System.Drawing.Point(274, 26);
            this.cmbTiempo.Name = "cmbTiempo";
            this.cmbTiempo.Size = new System.Drawing.Size(158, 21);
            this.cmbTiempo.TabIndex = 2;
            this.cmbTiempo.SelectedIndexChanged += new System.EventHandler(this.cmbTiempo_SelectedIndexChanged);
            // 
            // dgvTurnos
            // 
            this.dgvTurnos.BackgroundColor = System.Drawing.Color.White;
            this.dgvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnos.Location = new System.Drawing.Point(31, 78);
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.Size = new System.Drawing.Size(527, 268);
            this.dgvTurnos.TabIndex = 3;
            this.dgvTurnos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTurnos_CellClick);
            this.dgvTurnos.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTurnos_CellMouseEnter);
            this.dgvTurnos.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTurnos_CellMouseLeave);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(31, 346);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(527, 35);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(110, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Seleccionar Todo";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnNuevoTurno
            // 
            this.btnNuevoTurno.Location = new System.Drawing.Point(480, 19);
            this.btnNuevoTurno.Name = "btnNuevoTurno";
            this.btnNuevoTurno.Size = new System.Drawing.Size(77, 43);
            this.btnNuevoTurno.TabIndex = 5;
            this.btnNuevoTurno.Text = "Nuevo Turno";
            this.btnNuevoTurno.UseVisualStyleBackColor = true;
            this.btnNuevoTurno.Click += new System.EventHandler(this.btnNuevoTurno_Click);
            // 
            // Turnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(588, 409);
            this.Controls.Add(this.btnNuevoTurno);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvTurnos);
            this.Controls.Add(this.cmbTiempo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDia);
            this.MaximizeBox = false;
            this.Name = "Turnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turnos";
            this.Load += new System.EventHandler(this.Turnos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTiempo;
        private System.Windows.Forms.DataGridView dgvTurnos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnNuevoTurno;
    }
}