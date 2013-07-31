namespace Comedor.Vista.Configuracion
{
    partial class Grupos
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
            this.dgvGrupos = new System.Windows.Forms.DataGridView();
            this.btnNuevoGrupo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGrupos
            // 
            this.dgvGrupos.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupos.Location = new System.Drawing.Point(18, 71);
            this.dgvGrupos.Name = "dgvGrupos";
            this.dgvGrupos.Size = new System.Drawing.Size(520, 284);
            this.dgvGrupos.TabIndex = 2;
            this.dgvGrupos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrupos_CellClick);
            this.dgvGrupos.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrupos_CellMouseEnter);
            this.dgvGrupos.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrupos_CellMouseLeave);
            // 
            // btnNuevoGrupo
            // 
            this.btnNuevoGrupo.Location = new System.Drawing.Point(443, 12);
            this.btnNuevoGrupo.Name = "btnNuevoGrupo";
            this.btnNuevoGrupo.Size = new System.Drawing.Size(95, 34);
            this.btnNuevoGrupo.TabIndex = 3;
            this.btnNuevoGrupo.Text = "Nuevo Grupo";
            this.btnNuevoGrupo.UseVisualStyleBackColor = true;
            this.btnNuevoGrupo.Click += new System.EventHandler(this.btnNuevoGrupo_Click);
            // 
            // Grupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::Comedor.Vista.Properties.Resources.white_back;
            this.ClientSize = new System.Drawing.Size(561, 385);
            this.Controls.Add(this.btnNuevoGrupo);
            this.Controls.Add(this.dgvGrupos);
            this.MaximizeBox = false;
            this.Name = "Grupos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupos";
            this.Load += new System.EventHandler(this.Grupos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGrupos;
        private System.Windows.Forms.Button btnNuevoGrupo;
    }
}