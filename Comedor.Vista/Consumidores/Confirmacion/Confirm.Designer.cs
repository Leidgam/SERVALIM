namespace Comedor.Vista.Consumidores.Confirmacion
{
    partial class Confirm
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
            this.dgvConsumidores = new System.Windows.Forms.DataGridView();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chbAll = new System.Windows.Forms.CheckBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumidores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConsumidores
            // 
            this.dgvConsumidores.BackgroundColor = System.Drawing.Color.White;
            this.dgvConsumidores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsumidores.Location = new System.Drawing.Point(12, 97);
            this.dgvConsumidores.Name = "dgvConsumidores";
            this.dgvConsumidores.Size = new System.Drawing.Size(1015, 418);
            this.dgvConsumidores.TabIndex = 0;
            this.dgvConsumidores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsumidores_CellClick);
            this.dgvConsumidores.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsumidores_CellMouseEnter);
            this.dgvConsumidores.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsumidores_CellMouseLeave);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(153, 37);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(528, 29);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(76, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre:";
            // 
            // chbAll
            // 
            this.chbAll.AutoSize = true;
            this.chbAll.BackColor = System.Drawing.Color.Transparent;
            this.chbAll.Location = new System.Drawing.Point(12, 521);
            this.chbAll.Name = "chbAll";
            this.chbAll.Size = new System.Drawing.Size(64, 25);
            this.chbAll.TabIndex = 3;
            this.chbAll.Text = "Todo";
            this.chbAll.UseVisualStyleBackColor = false;
            this.chbAll.CheckedChanged += new System.EventHandler(this.chbAll_CheckedChanged);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(457, 531);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(139, 40);
            this.btnConfirmar.TabIndex = 4;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Comedor.Vista.Properties.Resources.delete;
            this.pictureBox1.Location = new System.Drawing.Point(937, 533);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 24);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(863, 528);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Rechazar";
            // 
            // Confirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::Comedor.Vista.Properties.Resources.white_back;
            this.ClientSize = new System.Drawing.Size(1039, 583);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.chbAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.dgvConsumidores);
            this.Font = new System.Drawing.Font("Segoe UI Symbol", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Confirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmación de Reservas";
            this.Load += new System.EventHandler(this.Confirm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumidores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConsumidores;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbAll;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
    }
}