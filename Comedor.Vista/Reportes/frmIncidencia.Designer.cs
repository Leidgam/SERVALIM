namespace Comedor.Vista
{
    partial class frmIncidencia
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
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvRegistro = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmbGravedadUno = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbGravedadDe = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbGravedadHasta = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.rbnUnafecha = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbnGravedadHasta = new System.Windows.Forms.RadioButton();
            this.rbmGravedadDe = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpFechaUno = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.rbnDesdeHasta = new System.Windows.Forms.RadioButton();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lblnombre = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistro)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(569, 213);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(108, 37);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dgvRegistro
            // 
            this.dgvRegistro.BackgroundColor = System.Drawing.Color.White;
            this.dgvRegistro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistro.Location = new System.Drawing.Point(18, 271);
            this.dgvRegistro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvRegistro.Name = "dgvRegistro";
            this.dgvRegistro.Size = new System.Drawing.Size(783, 296);
            this.dgvRegistro.TabIndex = 3;
            this.dgvRegistro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegistro_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.rbnUnafecha);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.rbnDesdeHasta);
            this.groupBox1.Controls.Add(this.shapeContainer1);
            this.groupBox1.Location = new System.Drawing.Point(18, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.groupBox1.Size = new System.Drawing.Size(783, 138);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(493, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 21);
            this.label9.TabIndex = 56;
            this.label9.Text = "GRAVEDAD:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 21);
            this.label8.TabIndex = 55;
            this.label8.Text = "FECHA:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cmbGravedadUno);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(523, 53);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(214, 38);
            this.panel5.TabIndex = 54;
            // 
            // cmbGravedadUno
            // 
            this.cmbGravedadUno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGravedadUno.FormattingEnabled = true;
            this.cmbGravedadUno.Items.AddRange(new object[] {
            "Todos",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbGravedadUno.Location = new System.Drawing.Point(76, 5);
            this.cmbGravedadUno.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbGravedadUno.Name = "cmbGravedadUno";
            this.cmbGravedadUno.Size = new System.Drawing.Size(120, 29);
            this.cmbGravedadUno.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 21);
            this.label4.TabIndex = 16;
            this.label4.Text = "DE:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.cmbGravedadDe);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cmbGravedadHasta);
            this.panel3.Location = new System.Drawing.Point(523, 91);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(214, 81);
            this.panel3.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 8);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 21);
            this.label7.TabIndex = 19;
            this.label7.Text = "DE:";
            // 
            // cmbGravedadDe
            // 
            this.cmbGravedadDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGravedadDe.FormattingEnabled = true;
            this.cmbGravedadDe.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbGravedadDe.Location = new System.Drawing.Point(76, 5);
            this.cmbGravedadDe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbGravedadDe.Name = "cmbGravedadDe";
            this.cmbGravedadDe.Size = new System.Drawing.Size(120, 29);
            this.cmbGravedadDe.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 45);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 21);
            this.label5.TabIndex = 17;
            this.label5.Text = "HASTA:";
            // 
            // cmbGravedadHasta
            // 
            this.cmbGravedadHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGravedadHasta.FormattingEnabled = true;
            this.cmbGravedadHasta.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbGravedadHasta.Location = new System.Drawing.Point(76, 42);
            this.cmbGravedadHasta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbGravedadHasta.Name = "cmbGravedadHasta";
            this.cmbGravedadHasta.Size = new System.Drawing.Size(120, 29);
            this.cmbGravedadHasta.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpFechaInicio);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpFechaFin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(15, 99);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 71);
            this.panel1.TabIndex = 5;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(92, 5);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(301, 29);
            this.dtpFechaInicio.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "FIN:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(91, 39);
            this.dtpFechaFin.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(301, 29);
            this.dtpFechaFin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "INICIO:";
            // 
            // rbnUnafecha
            // 
            this.rbnUnafecha.AutoSize = true;
            this.rbnUnafecha.Checked = true;
            this.rbnUnafecha.Location = new System.Drawing.Point(127, 20);
            this.rbnUnafecha.Margin = new System.Windows.Forms.Padding(9, 13, 9, 13);
            this.rbnUnafecha.Name = "rbnUnafecha";
            this.rbnUnafecha.Size = new System.Drawing.Size(100, 25);
            this.rbnUnafecha.TabIndex = 6;
            this.rbnUnafecha.TabStop = true;
            this.rbnUnafecha.Text = "Una Fecha";
            this.rbnUnafecha.UseVisualStyleBackColor = true;
            this.rbnUnafecha.CheckedChanged += new System.EventHandler(this.rbnUnafecha_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rbnGravedadHasta);
            this.panel4.Controls.Add(this.rbmGravedadDe);
            this.panel4.Location = new System.Drawing.Point(594, 15);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(173, 38);
            this.panel4.TabIndex = 53;
            // 
            // rbnGravedadHasta
            // 
            this.rbnGravedadHasta.AutoSize = true;
            this.rbnGravedadHasta.Location = new System.Drawing.Point(66, 7);
            this.rbnGravedadHasta.Margin = new System.Windows.Forms.Padding(9, 13, 9, 13);
            this.rbnGravedadHasta.Name = "rbnGravedadHasta";
            this.rbnGravedadHasta.Size = new System.Drawing.Size(89, 25);
            this.rbnGravedadHasta.TabIndex = 12;
            this.rbnGravedadHasta.Text = "Intervalo";
            this.rbnGravedadHasta.UseVisualStyleBackColor = true;
            this.rbnGravedadHasta.CheckedChanged += new System.EventHandler(this.rbnGravedadHasta_CheckedChanged);
            // 
            // rbmGravedadDe
            // 
            this.rbmGravedadDe.AutoSize = true;
            this.rbmGravedadDe.Checked = true;
            this.rbmGravedadDe.Location = new System.Drawing.Point(9, 8);
            this.rbmGravedadDe.Margin = new System.Windows.Forms.Padding(9, 13, 9, 13);
            this.rbmGravedadDe.Name = "rbmGravedadDe";
            this.rbmGravedadDe.Size = new System.Drawing.Size(56, 25);
            this.rbmGravedadDe.TabIndex = 11;
            this.rbmGravedadDe.TabStop = true;
            this.rbmGravedadDe.Text = "Una";
            this.rbmGravedadDe.UseVisualStyleBackColor = true;
            this.rbmGravedadDe.CheckedChanged += new System.EventHandler(this.rbmGravedadDe_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpFechaUno);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(15, 53);
            this.panel2.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(411, 47);
            this.panel2.TabIndex = 10;
            // 
            // dtpFechaUno
            // 
            this.dtpFechaUno.Location = new System.Drawing.Point(92, 9);
            this.dtpFechaUno.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.dtpFechaUno.Name = "dtpFechaUno";
            this.dtpFechaUno.Size = new System.Drawing.Size(301, 29);
            this.dtpFechaUno.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "DE:";
            // 
            // rbnDesdeHasta
            // 
            this.rbnDesdeHasta.AutoSize = true;
            this.rbnDesdeHasta.Location = new System.Drawing.Point(245, 20);
            this.rbnDesdeHasta.Margin = new System.Windows.Forms.Padding(9, 13, 9, 13);
            this.rbnDesdeHasta.Name = "rbnDesdeHasta";
            this.rbnDesdeHasta.Size = new System.Drawing.Size(123, 25);
            this.rbnDesdeHasta.TabIndex = 7;
            this.rbnDesdeHasta.Text = "Desdes-Hasta";
            this.rbnDesdeHasta.UseVisualStyleBackColor = true;
            this.rbnDesdeHasta.CheckedChanged += new System.EventHandler(this.rbnDesdeHasta_CheckedChanged);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(6, 30);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(771, 100);
            this.shapeContainer1.TabIndex = 57;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 459;
            this.lineShape1.X2 = 459;
            this.lineShape1.Y1 = -16;
            this.lineShape1.Y2 = 116;
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.BackColor = System.Drawing.Color.Transparent;
            this.lblnombre.Location = new System.Drawing.Point(251, 174);
            this.lblnombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(100, 21);
            this.lblnombre.TabIndex = 49;
            this.lblnombre.Text = "APELL-NOM:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(132, 171);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtCodigo.MaxLength = 3;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(92, 29);
            this.txtCodigo.TabIndex = 48;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(47, 174);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 21);
            this.label6.TabIndex = 47;
            this.label6.Text = "CODIGO:";
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(361, 171);
            this.txtnombre.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtnombre.MaxLength = 3;
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(328, 29);
            this.txtnombre.TabIndex = 50;
            this.txtnombre.TextChanged += new System.EventHandler(this.txtnombre_TextChanged);
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.BackColor = System.Drawing.Color.White;
            this.txtdescripcion.Enabled = false;
            this.txtdescripcion.Font = new System.Drawing.Font("Bradley Hand ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescripcion.Location = new System.Drawing.Point(197, 577);
            this.txtdescripcion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtdescripcion.Multiline = true;
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(458, 54);
            this.txtdescripcion.TabIndex = 52;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(64, 579);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 21);
            this.label10.TabIndex = 53;
            this.label10.Text = "DESCRIPCION:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Comedor.Vista.Properties.Resources.search_male_user;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(455, 213);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(108, 37);
            this.btnBuscar.TabIndex = 51;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::Comedor.Vista.Properties.Resources.delete1;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(687, 213);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(108, 37);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "QUITAR";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmIncidencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Comedor.Vista.Properties.Resources.white_back;
            this.ClientSize = new System.Drawing.Size(816, 652);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtdescripcion);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.lblnombre);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvRegistro);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNuevo);
            this.Font = new System.Drawing.Font("Segoe UI Symbol", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmIncidencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Incidencia";
            this.Load += new System.EventHandler(this.frmIncidencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistro)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvRegistro;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbmGravedadDe;
        private System.Windows.Forms.RadioButton rbnGravedadHasta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbnUnafecha;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpFechaUno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbnDesdeHasta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbGravedadHasta;
        private System.Windows.Forms.ComboBox cmbGravedadUno;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbGravedadDe;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label label10;
    }
}