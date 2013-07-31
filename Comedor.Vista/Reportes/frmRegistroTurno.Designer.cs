namespace Comedor.Vista
{
    partial class frmRegistroTurno
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
            this.dtpfechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpfechafin = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTurno = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rbnalmuerzo = new System.Windows.Forms.CheckBox();
            this.rbncena = new System.Windows.Forms.CheckBox();
            this.rbndesayuno = new System.Windows.Forms.CheckBox();
            this.panelfecha = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpfecha = new System.Windows.Forms.DateTimePicker();
            this.rbnDesdeHasta = new System.Windows.Forms.RadioButton();
            this.rbnUnafecha = new System.Windows.Forms.RadioButton();
            this.panelperiodo = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape6 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape5 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.dgvRegistro = new System.Windows.Forms.DataGridView();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panelfecha.SuspendLayout();
            this.panelperiodo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistro)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpfechaInicio
            // 
            this.dtpfechaInicio.Location = new System.Drawing.Point(120, 5);
            this.dtpfechaInicio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpfechaInicio.Name = "dtpfechaInicio";
            this.dtpfechaInicio.Size = new System.Drawing.Size(298, 29);
            this.dtpfechaInicio.TabIndex = 0;
            // 
            // dtpfechafin
            // 
            this.dtpfechafin.Location = new System.Drawing.Point(120, 41);
            this.dtpfechafin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpfechafin.Name = "dtpfechafin";
            this.dtpfechafin.Size = new System.Drawing.Size(298, 29);
            this.dtpfechafin.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::Comedor.Vista.Properties.Resources.white_back;
            this.groupBox1.Controls.Add(this.cmbTurno);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rbnalmuerzo);
            this.groupBox1.Controls.Add(this.rbncena);
            this.groupBox1.Controls.Add(this.rbndesayuno);
            this.groupBox1.Controls.Add(this.panelfecha);
            this.groupBox1.Controls.Add(this.rbnDesdeHasta);
            this.groupBox1.Controls.Add(this.rbnUnafecha);
            this.groupBox1.Controls.Add(this.panelperiodo);
            this.groupBox1.Controls.Add(this.shapeContainer1);
            this.groupBox1.Location = new System.Drawing.Point(18, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(799, 148);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro Turno";
            // 
            // cmbTurno
            // 
            this.cmbTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTurno.FormattingEnabled = true;
            this.cmbTurno.Location = new System.Drawing.Point(543, 105);
            this.cmbTurno.Name = "cmbTurno";
            this.cmbTurno.Size = new System.Drawing.Size(93, 29);
            this.cmbTurno.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(469, 108);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 21);
            this.label5.TabIndex = 11;
            this.label5.Text = "TURNO:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(608, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "TIPO";
            // 
            // rbnalmuerzo
            // 
            this.rbnalmuerzo.AutoSize = true;
            this.rbnalmuerzo.BackColor = System.Drawing.Color.Transparent;
            this.rbnalmuerzo.Checked = true;
            this.rbnalmuerzo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbnalmuerzo.Location = new System.Drawing.Point(589, 59);
            this.rbnalmuerzo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnalmuerzo.Name = "rbnalmuerzo";
            this.rbnalmuerzo.Size = new System.Drawing.Size(96, 25);
            this.rbnalmuerzo.TabIndex = 6;
            this.rbnalmuerzo.Text = "Almuerzo";
            this.rbnalmuerzo.UseVisualStyleBackColor = false;
            // 
            // rbncena
            // 
            this.rbncena.AutoSize = true;
            this.rbncena.BackColor = System.Drawing.Color.Transparent;
            this.rbncena.Checked = true;
            this.rbncena.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbncena.Location = new System.Drawing.Point(707, 59);
            this.rbncena.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbncena.Name = "rbncena";
            this.rbncena.Size = new System.Drawing.Size(64, 25);
            this.rbncena.TabIndex = 5;
            this.rbncena.Text = "Cena";
            this.rbncena.UseVisualStyleBackColor = false;
            // 
            // rbndesayuno
            // 
            this.rbndesayuno.AutoSize = true;
            this.rbndesayuno.BackgroundImage = global::Comedor.Vista.Properties.Resources.white_back;
            this.rbndesayuno.Checked = true;
            this.rbndesayuno.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbndesayuno.Location = new System.Drawing.Point(473, 59);
            this.rbndesayuno.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbndesayuno.Name = "rbndesayuno";
            this.rbndesayuno.Size = new System.Drawing.Size(98, 25);
            this.rbndesayuno.TabIndex = 4;
            this.rbndesayuno.Text = "Desayuno";
            this.rbndesayuno.UseVisualStyleBackColor = true;
            // 
            // panelfecha
            // 
            this.panelfecha.BackgroundImage = global::Comedor.Vista.Properties.Resources.white_back;
            this.panelfecha.Controls.Add(this.label3);
            this.panelfecha.Controls.Add(this.dtpfecha);
            this.panelfecha.Location = new System.Drawing.Point(9, 59);
            this.panelfecha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelfecha.Name = "panelfecha";
            this.panelfecha.Size = new System.Drawing.Size(420, 42);
            this.panelfecha.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(33, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "FECHA:";
            // 
            // dtpfecha
            // 
            this.dtpfecha.Location = new System.Drawing.Point(120, 5);
            this.dtpfecha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpfecha.Name = "dtpfecha";
            this.dtpfecha.Size = new System.Drawing.Size(298, 29);
            this.dtpfecha.TabIndex = 4;
            // 
            // rbnDesdeHasta
            // 
            this.rbnDesdeHasta.AutoSize = true;
            this.rbnDesdeHasta.BackgroundImage = global::Comedor.Vista.Properties.Resources.white_back;
            this.rbnDesdeHasta.Location = new System.Drawing.Point(254, 27);
            this.rbnDesdeHasta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnDesdeHasta.Name = "rbnDesdeHasta";
            this.rbnDesdeHasta.Size = new System.Drawing.Size(123, 25);
            this.rbnDesdeHasta.TabIndex = 2;
            this.rbnDesdeHasta.Text = "Desdes-Hasta";
            this.rbnDesdeHasta.UseVisualStyleBackColor = true;
            this.rbnDesdeHasta.CheckedChanged += new System.EventHandler(this.rbnDesdeHasta_CheckedChanged);
            // 
            // rbnUnafecha
            // 
            this.rbnUnafecha.AutoSize = true;
            this.rbnUnafecha.BackgroundImage = global::Comedor.Vista.Properties.Resources.white_back;
            this.rbnUnafecha.Checked = true;
            this.rbnUnafecha.Location = new System.Drawing.Point(66, 27);
            this.rbnUnafecha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnUnafecha.Name = "rbnUnafecha";
            this.rbnUnafecha.Size = new System.Drawing.Size(100, 25);
            this.rbnUnafecha.TabIndex = 1;
            this.rbnUnafecha.TabStop = true;
            this.rbnUnafecha.Text = "Una Fecha";
            this.rbnUnafecha.UseVisualStyleBackColor = true;
            this.rbnUnafecha.CheckedChanged += new System.EventHandler(this.rbnUnafecha_CheckedChanged);
            // 
            // panelperiodo
            // 
            this.panelperiodo.BackgroundImage = global::Comedor.Vista.Properties.Resources.white_back;
            this.panelperiodo.Controls.Add(this.label2);
            this.panelperiodo.Controls.Add(this.label1);
            this.panelperiodo.Controls.Add(this.dtpfechaInicio);
            this.panelperiodo.Controls.Add(this.dtpfechafin);
            this.panelperiodo.Location = new System.Drawing.Point(9, 103);
            this.panelperiodo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelperiodo.Name = "panelperiodo";
            this.panelperiodo.Size = new System.Drawing.Size(420, 80);
            this.panelperiodo.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "HASTA:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(33, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "DESDE:";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(4, 27);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape6,
            this.lineShape5,
            this.lineShape4,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(791, 116);
            this.shapeContainer1.TabIndex = 9;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape6
            // 
            this.lineShape6.Name = "lineShape6";
            this.lineShape6.X1 = 459;
            this.lineShape6.X2 = 778;
            this.lineShape6.Y1 = 64;
            this.lineShape6.Y2 = 64;
            // 
            // lineShape5
            // 
            this.lineShape5.Name = "lineShape5";
            this.lineShape5.X1 = 459;
            this.lineShape5.X2 = 597;
            this.lineShape5.Y1 = 13;
            this.lineShape5.Y2 = 13;
            // 
            // lineShape4
            // 
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = 644;
            this.lineShape4.X2 = 782;
            this.lineShape4.Y1 = 15;
            this.lineShape4.Y2 = 15;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 445;
            this.lineShape1.X2 = 445;
            this.lineShape1.Y1 = -15;
            this.lineShape1.Y2 = 141;
            // 
            // dgvRegistro
            // 
            this.dgvRegistro.BackgroundColor = System.Drawing.Color.White;
            this.dgvRegistro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistro.Location = new System.Drawing.Point(13, 211);
            this.dgvRegistro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvRegistro.Name = "dgvRegistro";
            this.dgvRegistro.Size = new System.Drawing.Size(803, 317);
            this.dgvRegistro.TabIndex = 3;
            this.dgvRegistro.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvRegistro_MouseDoubleClick);
            // 
            // txttotal
            // 
            this.txttotal.Location = new System.Drawing.Point(643, 536);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(123, 29);
            this.txttotal.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(572, 539);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 21);
            this.label6.TabIndex = 8;
            this.label6.Text = "TOTAL:";
            // 
            // btnbuscar
            // 
            this.btnbuscar.Image = global::Comedor.Vista.Properties.Resources.search_page;
            this.btnbuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbuscar.Location = new System.Drawing.Point(576, 156);
            this.btnbuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(103, 45);
            this.btnbuscar.TabIndex = 6;
            this.btnbuscar.Text = "BUSCAR";
            this.btnbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnbuscar.UseVisualStyleBackColor = true;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::Comedor.Vista.Properties.Resources.printer;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.Location = new System.Drawing.Point(696, 156);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(121, 45);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "IMPRIMIR";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmRegistroTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::Comedor.Vista.Properties.Resources.white_back;
            this.ClientSize = new System.Drawing.Size(831, 576);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txttotal);
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.dgvRegistro);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI Symbol", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmRegistroTurno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REGISTRO DE ENTRADA POR TURNO";
            this.Load += new System.EventHandler(this.frmRegistroTurno_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelfecha.ResumeLayout(false);
            this.panelfecha.PerformLayout();
            this.panelperiodo.ResumeLayout(false);
            this.panelperiodo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpfechaInicio;
        private System.Windows.Forms.DateTimePicker dtpfechafin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox rbnalmuerzo;
        private System.Windows.Forms.CheckBox rbncena;
        private System.Windows.Forms.CheckBox rbndesayuno;
        private System.Windows.Forms.Panel panelfecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpfecha;
        private System.Windows.Forms.RadioButton rbnDesdeHasta;
        private System.Windows.Forms.RadioButton rbnUnafecha;
        private System.Windows.Forms.Panel panelperiodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.DataGridView dgvRegistro;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnbuscar;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape5;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape4;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTurno;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape6;
    }
}