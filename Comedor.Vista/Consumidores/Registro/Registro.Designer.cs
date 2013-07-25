namespace Comedor.Vista.Consumidores
{
    partial class Registro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registro));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnFoto = new System.Windows.Forms.Button();
            this.btnReservas = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvConsumidores = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumidores)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.btnFoto);
            this.groupBox1.Controls.Add(this.btnReservas);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(680, 87);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEdit.Location = new System.Drawing.Point(313, 23);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(81, 59);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Editar";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminar.Location = new System.Drawing.Point(580, 23);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(81, 59);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnFoto
            // 
            this.btnFoto.BackColor = System.Drawing.Color.Transparent;
            this.btnFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFoto.FlatAppearance.BorderSize = 0;
            this.btnFoto.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnFoto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFoto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFoto.Image = ((System.Drawing.Image)(resources.GetObject("btnFoto.Image")));
            this.btnFoto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFoto.Location = new System.Drawing.Point(491, 23);
            this.btnFoto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFoto.Name = "btnFoto";
            this.btnFoto.Size = new System.Drawing.Size(81, 59);
            this.btnFoto.TabIndex = 2;
            this.btnFoto.Text = "Ver Foto";
            this.btnFoto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFoto.UseVisualStyleBackColor = false;
            this.btnFoto.Click += new System.EventHandler(this.btnFoto_Click);
            // 
            // btnReservas
            // 
            this.btnReservas.BackColor = System.Drawing.Color.Transparent;
            this.btnReservas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReservas.FlatAppearance.BorderSize = 0;
            this.btnReservas.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnReservas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReservas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReservas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservas.Image = ((System.Drawing.Image)(resources.GetObject("btnReservas.Image")));
            this.btnReservas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReservas.Location = new System.Drawing.Point(402, 23);
            this.btnReservas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReservas.Name = "btnReservas";
            this.btnReservas.Size = new System.Drawing.Size(81, 59);
            this.btnReservas.TabIndex = 1;
            this.btnReservas.Text = "Horario";
            this.btnReservas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReservas.UseVisualStyleBackColor = false;
            this.btnReservas.Click += new System.EventHandler(this.btnReservas_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.Transparent;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevo.Location = new System.Drawing.Point(13, 23);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(81, 59);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dgvConsumidores
            // 
            this.dgvConsumidores.BackgroundColor = System.Drawing.Color.White;
            this.dgvConsumidores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsumidores.Location = new System.Drawing.Point(8, 22);
            this.dgvConsumidores.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvConsumidores.Name = "dgvConsumidores";
            this.dgvConsumidores.Size = new System.Drawing.Size(664, 368);
            this.dgvConsumidores.TabIndex = 1;
            this.dgvConsumidores.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsumidores_CellDoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtNombre);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtCodigo);
            this.groupBox3.Location = new System.Drawing.Point(13, 111);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(680, 78);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtro";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(350, 31);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(322, 29);
            this.txtNombre.TabIndex = 8;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nombre y Apellidos:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(91, 31);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(83, 29);
            this.txtCodigo.TabIndex = 5;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvConsumidores);
            this.groupBox2.Location = new System.Drawing.Point(13, 199);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(680, 396);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista";
            // 
            // Registro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 601);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Segoe UI Symbol", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Registro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro";
            this.Load += new System.EventHandler(this.Registro_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumidores)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReservas;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvConsumidores;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnFoto;
        private System.Windows.Forms.Button btnEdit;
    }
}