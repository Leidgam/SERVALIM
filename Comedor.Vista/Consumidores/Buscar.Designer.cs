namespace Comedor.Vista.Consumidores
{
    partial class Buscar
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreApellido = new System.Windows.Forms.TextBox();
            this.cmbarea = new System.Windows.Forms.ComboBox();
            this.cmbgrupo = new System.Windows.Forms.ComboBox();
            this.dgvConsumidor = new System.Windows.Forms.DataGridView();
            this.rbnSelectTodo = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnaceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumidor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alumno:";
            // 
            // txtNombreApellido
            // 
            this.txtNombreApellido.Location = new System.Drawing.Point(94, 19);
            this.txtNombreApellido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNombreApellido.Name = "txtNombreApellido";
            this.txtNombreApellido.Size = new System.Drawing.Size(504, 29);
            this.txtNombreApellido.TabIndex = 1;
            this.txtNombreApellido.TextChanged += new System.EventHandler(this.txtNombreApellido_TextChanged);
            // 
            // cmbarea
            // 
            this.cmbarea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbarea.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbarea.FormattingEnabled = true;
            this.cmbarea.Location = new System.Drawing.Point(94, 61);
            this.cmbarea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbarea.Name = "cmbarea";
            this.cmbarea.Size = new System.Drawing.Size(212, 29);
            this.cmbarea.TabIndex = 2;
            // 
            // cmbgrupo
            // 
            this.cmbgrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbgrupo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbgrupo.FormattingEnabled = true;
            this.cmbgrupo.Location = new System.Drawing.Point(399, 61);
            this.cmbgrupo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbgrupo.Name = "cmbgrupo";
            this.cmbgrupo.Size = new System.Drawing.Size(199, 29);
            this.cmbgrupo.TabIndex = 3;
            // 
            // dgvConsumidor
            // 
            this.dgvConsumidor.BackgroundColor = System.Drawing.Color.White;
            this.dgvConsumidor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsumidor.Location = new System.Drawing.Point(27, 100);
            this.dgvConsumidor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvConsumidor.Name = "dgvConsumidor";
            this.dgvConsumidor.Size = new System.Drawing.Size(594, 343);
            this.dgvConsumidor.TabIndex = 4;
            // 
            // rbnSelectTodo
            // 
            this.rbnSelectTodo.AutoSize = true;
            this.rbnSelectTodo.Location = new System.Drawing.Point(27, 453);
            this.rbnSelectTodo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnSelectTodo.Name = "rbnSelectTodo";
            this.rbnSelectTodo.Size = new System.Drawing.Size(147, 25);
            this.rbnSelectTodo.TabIndex = 5;
            this.rbnSelectTodo.Text = "Seleccionar Todo";
            this.rbnSelectTodo.UseVisualStyleBackColor = true;
            this.rbnSelectTodo.CheckedChanged += new System.EventHandler(this.rbnSelectTodo_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Area:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Grupo:";
            // 
            // btnaceptar
            // 
            this.btnaceptar.Location = new System.Drawing.Point(509, 453);
            this.btnaceptar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnaceptar.Name = "btnaceptar";
            this.btnaceptar.Size = new System.Drawing.Size(112, 37);
            this.btnaceptar.TabIndex = 8;
            this.btnaceptar.Text = "Aceptar";
            this.btnaceptar.UseVisualStyleBackColor = true;
            this.btnaceptar.Click += new System.EventHandler(this.btnaceptar_Click);
            // 
            // Buscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(634, 503);
            this.Controls.Add(this.btnaceptar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbnSelectTodo);
            this.Controls.Add(this.dgvConsumidor);
            this.Controls.Add(this.cmbgrupo);
            this.Controls.Add(this.cmbarea);
            this.Controls.Add(this.txtNombreApellido);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI Symbol", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Buscar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar";
            this.Load += new System.EventHandler(this.Buscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumidor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreApellido;
        private System.Windows.Forms.ComboBox cmbarea;
        private System.Windows.Forms.ComboBox cmbgrupo;
        private System.Windows.Forms.DataGridView dgvConsumidor;
        private System.Windows.Forms.CheckBox rbnSelectTodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnaceptar;
    }
}