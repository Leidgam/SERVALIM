namespace Comedor.Vista.Usuarios
{
    partial class Asignacion
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvRolesAsig = new System.Windows.Forms.DataGridView();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.cmbUsuarios = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.dgvPrivAsig = new System.Windows.Forms.DataGridView();
            this.dgvPriv = new System.Windows.Forms.DataGridView();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRolesAsig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrivAsig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriv)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(697, 481);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.dgvRolesAsig);
            this.tabPage1.Controls.Add(this.dgvRoles);
            this.tabPage1.Controls.Add(this.cmbUsuarios);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(689, 455);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Usuarios";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(328, 161);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(38, 38);
            this.button4.TabIndex = 6;
            this.button4.Text = "<";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(328, 340);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(38, 38);
            this.button3.TabIndex = 5;
            this.button3.Text = "<<";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(328, 296);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(38, 38);
            this.button2.TabIndex = 4;
            this.button2.Text = ">>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(328, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvRolesAsig
            // 
            this.dgvRolesAsig.BackgroundColor = System.Drawing.Color.White;
            this.dgvRolesAsig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRolesAsig.Location = new System.Drawing.Point(395, 84);
            this.dgvRolesAsig.MultiSelect = false;
            this.dgvRolesAsig.Name = "dgvRolesAsig";
            this.dgvRolesAsig.Size = new System.Drawing.Size(268, 351);
            this.dgvRolesAsig.TabIndex = 2;
            // 
            // dgvRoles
            // 
            this.dgvRoles.BackgroundColor = System.Drawing.Color.White;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Location = new System.Drawing.Point(30, 84);
            this.dgvRoles.MultiSelect = false;
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.Size = new System.Drawing.Size(268, 351);
            this.dgvRoles.TabIndex = 1;
            // 
            // cmbUsuarios
            // 
            this.cmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuarios.FormattingEnabled = true;
            this.cmbUsuarios.Location = new System.Drawing.Point(202, 28);
            this.cmbUsuarios.Name = "cmbUsuarios";
            this.cmbUsuarios.Size = new System.Drawing.Size(288, 21);
            this.cmbUsuarios.TabIndex = 0;
            this.cmbUsuarios.SelectedIndexChanged += new System.EventHandler(this.cmbUsuarios_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.treeView2);
            this.tabPage2.Controls.Add(this.treeView1);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.button7);
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.dgvPrivAsig);
            this.tabPage2.Controls.Add(this.dgvPriv);
            this.tabPage2.Controls.Add(this.cmbRoles);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(689, 455);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Roles";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(668, 0);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(21, 21);
            this.treeView2.TabIndex = 15;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(21, 15);
            this.treeView1.TabIndex = 14;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(328, 161);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(38, 38);
            this.button5.TabIndex = 13;
            this.button5.Text = "<";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(328, 340);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(38, 38);
            this.button6.TabIndex = 12;
            this.button6.Text = "<<";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(328, 296);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(38, 38);
            this.button7.TabIndex = 11;
            this.button7.Text = ">>";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(328, 117);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(38, 38);
            this.button8.TabIndex = 10;
            this.button8.Text = ">";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // dgvPrivAsig
            // 
            this.dgvPrivAsig.BackgroundColor = System.Drawing.Color.White;
            this.dgvPrivAsig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrivAsig.Location = new System.Drawing.Point(390, 84);
            this.dgvPrivAsig.Name = "dgvPrivAsig";
            this.dgvPrivAsig.Size = new System.Drawing.Size(268, 351);
            this.dgvPrivAsig.TabIndex = 9;
            // 
            // dgvPriv
            // 
            this.dgvPriv.BackgroundColor = System.Drawing.Color.White;
            this.dgvPriv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPriv.Location = new System.Drawing.Point(43, 84);
            this.dgvPriv.Name = "dgvPriv";
            this.dgvPriv.Size = new System.Drawing.Size(268, 351);
            this.dgvPriv.TabIndex = 8;
            // 
            // cmbRoles
            // 
            this.cmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(197, 16);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(288, 21);
            this.cmbRoles.TabIndex = 7;
            this.cmbRoles.SelectedIndexChanged += new System.EventHandler(this.cmbRoles_SelectedIndexChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(328, 507);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(76, 35);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Asignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 554);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "Asignacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignacion";
            this.Load += new System.EventHandler(this.Asignacion_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRolesAsig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrivAsig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.ComboBox cmbUsuarios;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvRolesAsig;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.DataGridView dgvPrivAsig;
        private System.Windows.Forms.DataGridView dgvPriv;
        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView treeView2;
    }
}