namespace Comedor.Vista
{
    partial class frmConsumidor
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
            this.cmbPeriodo = new System.Windows.Forms.ComboBox();
            this.cmbEAP = new System.Windows.Forms.ComboBox();
            this.cmbGrupo = new System.Windows.Forms.ComboBox();
            this.cmbFacultad = new System.Windows.Forms.ComboBox();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblperiodo = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCiclo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.dgvConsumidor = new System.Windows.Forms.DataGridView();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumidor)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPeriodo
            // 
            this.cmbPeriodo.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodo.FormattingEnabled = true;
            this.cmbPeriodo.Location = new System.Drawing.Point(129, 31);
            this.cmbPeriodo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPeriodo.Name = "cmbPeriodo";
            this.cmbPeriodo.Size = new System.Drawing.Size(183, 29);
            this.cmbPeriodo.TabIndex = 2;
            // 
            // cmbEAP
            // 
            this.cmbEAP.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cmbEAP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEAP.FormattingEnabled = true;
            this.cmbEAP.Location = new System.Drawing.Point(517, 70);
            this.cmbEAP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbEAP.Name = "cmbEAP";
            this.cmbEAP.Size = new System.Drawing.Size(401, 29);
            this.cmbEAP.TabIndex = 3;
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cmbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrupo.FormattingEnabled = true;
            this.cmbGrupo.Location = new System.Drawing.Point(839, 32);
            this.cmbGrupo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.Size = new System.Drawing.Size(217, 29);
            this.cmbGrupo.TabIndex = 4;
            // 
            // cmbFacultad
            // 
            this.cmbFacultad.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cmbFacultad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFacultad.FormattingEnabled = true;
            this.cmbFacultad.Location = new System.Drawing.Point(129, 70);
            this.cmbFacultad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbFacultad.Name = "cmbFacultad";
            this.cmbFacultad.Size = new System.Drawing.Size(313, 29);
            this.cmbFacultad.TabIndex = 5;
            this.cmbFacultad.SelectedIndexChanged += new System.EventHandler(this.cmbFacultad_SelectedIndexChanged);
            // 
            // cmbArea
            // 
            this.cmbArea.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(432, 31);
            this.cmbArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(288, 29);
            this.cmbArea.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblperiodo);
            this.groupBox1.Controls.Add(this.btnImprimir);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbCiclo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbEAP);
            this.groupBox1.Controls.Add(this.cmbFacultad);
            this.groupBox1.Controls.Add(this.cmbArea);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbPeriodo);
            this.groupBox1.Controls.Add(this.cmbGrupo);
            this.groupBox1.Controls.Add(this.shapeContainer1);
            this.groupBox1.Location = new System.Drawing.Point(13, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1075, 192);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTRO";
            // 
            // lblperiodo
            // 
            this.lblperiodo.AutoSize = true;
            this.lblperiodo.Location = new System.Drawing.Point(134, 34);
            this.lblperiodo.Name = "lblperiodo";
            this.lblperiodo.Size = new System.Drawing.Size(81, 21);
            this.lblperiodo.TabIndex = 21;
            this.lblperiodo.Text = "lblperiodo";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::Comedor.Vista.Properties.Resources.printer;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.Location = new System.Drawing.Point(941, 127);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(115, 51);
            this.btnImprimir.TabIndex = 11;
            this.btnImprimir.Text = "IMPRIMIR";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Comedor.Vista.Properties.Resources.search_male_user;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(822, 127);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(106, 51);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(376, 139);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(407, 29);
            this.txtNombre.TabIndex = 19;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(250, 142);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 21);
            this.label8.TabIndex = 18;
            this.label8.Text = "CONSUMIDOR:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(129, 139);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(98, 29);
            this.textBox1.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 142);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 21);
            this.label7.TabIndex = 16;
            this.label7.Text = "CODIGO:";
            // 
            // cmbCiclo
            // 
            this.cmbCiclo.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cmbCiclo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCiclo.FormattingEnabled = true;
            this.cmbCiclo.Items.AddRange(new object[] {
            "Todos",
            "I",
            "II",
            "III",
            "IV",
            "V",
            "VI",
            "VII",
            "VIII",
            "IX",
            "X"});
            this.cmbCiclo.Location = new System.Drawing.Point(987, 70);
            this.cmbCiclo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbCiclo.Name = "cmbCiclo";
            this.cmbCiclo.Size = new System.Drawing.Size(69, 29);
            this.cmbCiclo.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(926, 73);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 21);
            this.label6.TabIndex = 13;
            this.label6.Text = "CICLO:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(463, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "E.A.P:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "AREA:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(765, 35);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "GRUPO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "FACULTAD:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "PERIODO:";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(4, 27);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1067, 160);
            this.shapeContainer1.TabIndex = 20;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.Silver;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 19;
            this.lineShape1.X2 = 1042;
            this.lineShape1.Y1 = 91;
            this.lineShape1.Y2 = 91;
            // 
            // dgvConsumidor
            // 
            this.dgvConsumidor.BackgroundColor = System.Drawing.Color.White;
            this.dgvConsumidor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsumidor.Location = new System.Drawing.Point(17, 207);
            this.dgvConsumidor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvConsumidor.Name = "dgvConsumidor";
            this.dgvConsumidor.Size = new System.Drawing.Size(1067, 433);
            this.dgvConsumidor.TabIndex = 8;
            this.dgvConsumidor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsumidor_CellContentClick);
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(953, 648);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(116, 29);
            this.txtTotal.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(882, 651);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 21);
            this.label9.TabIndex = 10;
            this.label9.Text = "TOTAL:";
            // 
            // frmConsumidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1104, 692);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.dgvConsumidor);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Segoe UI Symbol", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmConsumidor";
            this.Text = "frmConsumidor";
            this.Load += new System.EventHandler(this.frmConsumidor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumidor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPeriodo;
        private System.Windows.Forms.ComboBox cmbEAP;
        private System.Windows.Forms.ComboBox cmbGrupo;
        private System.Windows.Forms.ComboBox cmbFacultad;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCiclo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvConsumidor;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblperiodo;
    }
}