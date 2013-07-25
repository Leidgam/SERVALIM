namespace Comedor.Vista.Consumidores.Incidencias
{
    partial class Incidencias
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
            this.dgvIncidencias = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidencias)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvIncidencias
            // 
            this.dgvIncidencias.BackgroundColor = System.Drawing.Color.White;
            this.dgvIncidencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncidencias.Location = new System.Drawing.Point(12, 52);
            this.dgvIncidencias.Name = "dgvIncidencias";
            this.dgvIncidencias.Size = new System.Drawing.Size(442, 150);
            this.dgvIncidencias.TabIndex = 0;
            this.dgvIncidencias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIncidencias_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMotivo);
            this.groupBox1.Location = new System.Drawing.Point(12, 208);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 83);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Descripción:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(6, 19);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(430, 58);
            this.txtMotivo.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(36, 16);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(52, 21);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(370, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "Nueva";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Incidencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(461, 303);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvIncidencias);
            this.Font = new System.Drawing.Font("Segoe UI Symbol", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Incidencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Incidencias";
            this.Load += new System.EventHandler(this.Incidencias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidencias)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIncidencias;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button button1;
    }
}