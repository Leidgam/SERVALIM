namespace Comedor.Vista.Consumidores.Bolsas
{
    partial class Control_Bolsas
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
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chbOcacional = new System.Windows.Forms.CheckBox();
            this.chbPermanente = new System.Windows.Forms.CheckBox();
            this.cmbEAP = new System.Windows.Forms.ComboBox();
            this.cmbAreas = new System.Windows.Forms.ComboBox();
            this.cmbGrupos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chbCena = new System.Windows.Forms.CheckBox();
            this.chbAlmuerzo = new System.Windows.Forms.CheckBox();
            this.chbDesayuno = new System.Windows.Forms.CheckBox();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.rdbDesHas = new System.Windows.Forms.RadioButton();
            this.rdbUnica = new System.Windows.Forms.RadioButton();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.chbTodo = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvReservas
            // 
            this.dgvReservas.BackgroundColor = System.Drawing.Color.White;
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservas.Location = new System.Drawing.Point(12, 162);
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.Size = new System.Drawing.Size(972, 319);
            this.dgvReservas.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.chbOcacional);
            this.groupBox1.Controls.Add(this.chbPermanente);
            this.groupBox1.Controls.Add(this.cmbEAP);
            this.groupBox1.Controls.Add(this.cmbAreas);
            this.groupBox1.Controls.Add(this.cmbGrupos);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chbCena);
            this.groupBox1.Controls.Add(this.chbAlmuerzo);
            this.groupBox1.Controls.Add(this.chbDesayuno);
            this.groupBox1.Controls.Add(this.lblHasta);
            this.groupBox1.Controls.Add(this.lblDesde);
            this.groupBox1.Controls.Add(this.dtpHasta);
            this.groupBox1.Controls.Add(this.dtpDesde);
            this.groupBox1.Controls.Add(this.rdbDesHas);
            this.groupBox1.Controls.Add(this.rdbUnica);
            this.groupBox1.Controls.Add(this.shapeContainer1);
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(976, 140);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(870, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Buscar:";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chbOcacional
            // 
            this.chbOcacional.AutoSize = true;
            this.chbOcacional.Checked = true;
            this.chbOcacional.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOcacional.Location = new System.Drawing.Point(409, 74);
            this.chbOcacional.Name = "chbOcacional";
            this.chbOcacional.Size = new System.Drawing.Size(74, 17);
            this.chbOcacional.TabIndex = 19;
            this.chbOcacional.Text = "Ocacional";
            this.chbOcacional.UseVisualStyleBackColor = true;
            // 
            // chbPermanente
            // 
            this.chbPermanente.AutoSize = true;
            this.chbPermanente.Checked = true;
            this.chbPermanente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbPermanente.Location = new System.Drawing.Point(409, 43);
            this.chbPermanente.Name = "chbPermanente";
            this.chbPermanente.Size = new System.Drawing.Size(83, 17);
            this.chbPermanente.TabIndex = 18;
            this.chbPermanente.Text = "Permanente";
            this.chbPermanente.UseVisualStyleBackColor = true;
            // 
            // cmbEAP
            // 
            this.cmbEAP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEAP.FormattingEnabled = true;
            this.cmbEAP.Location = new System.Drawing.Point(575, 96);
            this.cmbEAP.Name = "cmbEAP";
            this.cmbEAP.Size = new System.Drawing.Size(277, 21);
            this.cmbEAP.TabIndex = 17;
            // 
            // cmbAreas
            // 
            this.cmbAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAreas.FormattingEnabled = true;
            this.cmbAreas.Location = new System.Drawing.Point(575, 61);
            this.cmbAreas.Name = "cmbAreas";
            this.cmbAreas.Size = new System.Drawing.Size(277, 21);
            this.cmbAreas.TabIndex = 16;
            // 
            // cmbGrupos
            // 
            this.cmbGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrupos.FormattingEnabled = true;
            this.cmbGrupos.Location = new System.Drawing.Point(575, 26);
            this.cmbGrupos.Name = "cmbGrupos";
            this.cmbGrupos.Size = new System.Drawing.Size(277, 21);
            this.cmbGrupos.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(529, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "EAP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(528, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Área:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(521, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Grupo:";
            // 
            // chbCena
            // 
            this.chbCena.AutoSize = true;
            this.chbCena.Checked = true;
            this.chbCena.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCena.Location = new System.Drawing.Point(303, 96);
            this.chbCena.Name = "chbCena";
            this.chbCena.Size = new System.Drawing.Size(51, 17);
            this.chbCena.TabIndex = 9;
            this.chbCena.Text = "Cena";
            this.chbCena.UseVisualStyleBackColor = true;
            // 
            // chbAlmuerzo
            // 
            this.chbAlmuerzo.AutoSize = true;
            this.chbAlmuerzo.Checked = true;
            this.chbAlmuerzo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAlmuerzo.Location = new System.Drawing.Point(303, 65);
            this.chbAlmuerzo.Name = "chbAlmuerzo";
            this.chbAlmuerzo.Size = new System.Drawing.Size(69, 17);
            this.chbAlmuerzo.TabIndex = 8;
            this.chbAlmuerzo.Text = "Almuerzo";
            this.chbAlmuerzo.UseVisualStyleBackColor = true;
            // 
            // chbDesayuno
            // 
            this.chbDesayuno.AutoSize = true;
            this.chbDesayuno.Checked = true;
            this.chbDesayuno.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDesayuno.Location = new System.Drawing.Point(303, 34);
            this.chbDesayuno.Name = "chbDesayuno";
            this.chbDesayuno.Size = new System.Drawing.Size(74, 17);
            this.chbDesayuno.TabIndex = 7;
            this.chbDesayuno.Text = "Desayuno";
            this.chbDesayuno.UseVisualStyleBackColor = true;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(10, 106);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 5;
            this.lblHasta.Text = "Hasta:";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(10, 71);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(40, 13);
            this.lblDesde.TabIndex = 4;
            this.lblDesde.Text = "Fecha:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(69, 100);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 3;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(69, 65);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 2;
            // 
            // rdbDesHas
            // 
            this.rdbDesHas.AutoSize = true;
            this.rdbDesHas.Location = new System.Drawing.Point(145, 25);
            this.rdbDesHas.Name = "rdbDesHas";
            this.rdbDesHas.Size = new System.Drawing.Size(93, 17);
            this.rdbDesHas.TabIndex = 1;
            this.rdbDesHas.TabStop = true;
            this.rdbDesHas.Text = "Desde - Hasta";
            this.rdbDesHas.UseVisualStyleBackColor = true;
            // 
            // rdbUnica
            // 
            this.rdbUnica.AutoSize = true;
            this.rdbUnica.Location = new System.Drawing.Point(14, 25);
            this.rdbUnica.Name = "rdbUnica";
            this.rdbUnica.Size = new System.Drawing.Size(86, 17);
            this.rdbUnica.TabIndex = 0;
            this.rdbUnica.Text = "Fecha Única";
            this.rdbUnica.UseVisualStyleBackColor = true;
            this.rdbUnica.CheckedChanged += new System.EventHandler(this.rdbUnica_CheckedChanged);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(4, 18);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape4,
            this.lineShape3,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(968, 117);
            this.shapeContainer1.TabIndex = 6;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape4
            // 
            this.lineShape4.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = 496;
            this.lineShape4.X2 = 496;
            this.lineShape4.Y1 = -3;
            this.lineShape4.Y2 = 97;
            // 
            // lineShape3
            // 
            this.lineShape3.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 389;
            this.lineShape3.X2 = 389;
            this.lineShape3.Y1 = -5;
            this.lineShape3.Y2 = 95;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 284;
            this.lineShape1.X2 = 284;
            this.lineShape1.Y1 = 0;
            this.lineShape1.Y2 = 100;
            // 
            // chbTodo
            // 
            this.chbTodo.AutoSize = true;
            this.chbTodo.BackColor = System.Drawing.Color.Transparent;
            this.chbTodo.Location = new System.Drawing.Point(13, 489);
            this.chbTodo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chbTodo.Name = "chbTodo";
            this.chbTodo.Size = new System.Drawing.Size(51, 17);
            this.chbTodo.TabIndex = 5;
            this.chbTodo.Text = "Todo";
            this.chbTodo.UseVisualStyleBackColor = false;
            this.chbTodo.CheckedChanged += new System.EventHandler(this.chbTodo_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(443, 489);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 48);
            this.button2.TabIndex = 6;
            this.button2.Text = "Entregar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Control_Bolsas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Comedor.Vista.Properties.Resources.white_back;
            this.ClientSize = new System.Drawing.Size(1009, 540);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chbTodo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvReservas);
            this.MaximizeBox = false;
            this.Name = "Control_Bolsas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control Bolsas";
            this.Load += new System.EventHandler(this.Control_Bolsas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chbOcacional;
        private System.Windows.Forms.CheckBox chbPermanente;
        private System.Windows.Forms.ComboBox cmbEAP;
        private System.Windows.Forms.ComboBox cmbAreas;
        private System.Windows.Forms.ComboBox cmbGrupos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbCena;
        private System.Windows.Forms.CheckBox chbAlmuerzo;
        private System.Windows.Forms.CheckBox chbDesayuno;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.RadioButton rdbDesHas;
        private System.Windows.Forms.RadioButton rdbUnica;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape4;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.CheckBox chbTodo;
        private System.Windows.Forms.Button button2;
    }
}