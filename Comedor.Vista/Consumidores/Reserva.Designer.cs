namespace Comedor.Vista.Consumidores
{
    partial class Reserva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reserva));
            this.rbnotros = new System.Windows.Forms.RadioButton();
            this.rbnsalud = new System.Windows.Forms.RadioButton();
            this.rbntrabajo = new System.Windows.Forms.RadioButton();
            this.rbnestudio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtotros = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbncena = new System.Windows.Forms.CheckBox();
            this.rbnalmuerzo = new System.Windows.Forms.CheckBox();
            this.rbndesayuno = new System.Windows.Forms.CheckBox();
            this.rbnreserva = new System.Windows.Forms.RadioButton();
            this.rbnbolsa = new System.Windows.Forms.RadioButton();
            this.dtpfecha = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btneliminar = new System.Windows.Forms.Button();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReserva = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnenviar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReserva)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbnotros
            // 
            this.rbnotros.AutoSize = true;
            this.rbnotros.Checked = true;
            this.rbnotros.Location = new System.Drawing.Point(266, 64);
            this.rbnotros.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnotros.Name = "rbnotros";
            this.rbnotros.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbnotros.Size = new System.Drawing.Size(67, 25);
            this.rbnotros.TabIndex = 0;
            this.rbnotros.TabStop = true;
            this.rbnotros.Text = "Otros";
            this.rbnotros.UseVisualStyleBackColor = true;
            this.rbnotros.CheckedChanged += new System.EventHandler(this.rbnotros_CheckedChanged);
            // 
            // rbnsalud
            // 
            this.rbnsalud.AutoSize = true;
            this.rbnsalud.Location = new System.Drawing.Point(104, 27);
            this.rbnsalud.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnsalud.Name = "rbnsalud";
            this.rbnsalud.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbnsalud.Size = new System.Drawing.Size(67, 25);
            this.rbnsalud.TabIndex = 1;
            this.rbnsalud.Text = "Salud";
            this.rbnsalud.UseVisualStyleBackColor = true;
            // 
            // rbntrabajo
            // 
            this.rbntrabajo.AutoSize = true;
            this.rbntrabajo.Location = new System.Drawing.Point(90, 64);
            this.rbntrabajo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbntrabajo.Name = "rbntrabajo";
            this.rbntrabajo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbntrabajo.Size = new System.Drawing.Size(80, 25);
            this.rbntrabajo.TabIndex = 2;
            this.rbntrabajo.Text = "Trabajo";
            this.rbntrabajo.UseVisualStyleBackColor = true;
            // 
            // rbnestudio
            // 
            this.rbnestudio.AutoSize = true;
            this.rbnestudio.Location = new System.Drawing.Point(255, 27);
            this.rbnestudio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnestudio.Name = "rbnestudio";
            this.rbnestudio.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbnestudio.Size = new System.Drawing.Size(79, 25);
            this.rbnestudio.TabIndex = 3;
            this.rbnestudio.Text = "Estudio";
            this.rbnestudio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtotros);
            this.groupBox1.Controls.Add(this.rbnsalud);
            this.groupBox1.Controls.Add(this.rbnotros);
            this.groupBox1.Controls.Add(this.rbntrabajo);
            this.groupBox1.Controls.Add(this.rbnestudio);
            this.groupBox1.Location = new System.Drawing.Point(14, 60);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(634, 113);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MOTIVO:";
            // 
            // txtotros
            // 
            this.txtotros.Location = new System.Drawing.Point(366, 64);
            this.txtotros.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtotros.Name = "txtotros";
            this.txtotros.Size = new System.Drawing.Size(204, 29);
            this.txtotros.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbncena);
            this.groupBox2.Controls.Add(this.rbnalmuerzo);
            this.groupBox2.Controls.Add(this.rbndesayuno);
            this.groupBox2.Controls.Add(this.rbnreserva);
            this.groupBox2.Controls.Add(this.rbnbolsa);
            this.groupBox2.Location = new System.Drawing.Point(14, 210);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(634, 97);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // rbncena
            // 
            this.rbncena.AutoSize = true;
            this.rbncena.Location = new System.Drawing.Point(415, 59);
            this.rbncena.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbncena.Name = "rbncena";
            this.rbncena.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbncena.Size = new System.Drawing.Size(64, 25);
            this.rbncena.TabIndex = 12;
            this.rbncena.Text = "Cena";
            this.rbncena.UseVisualStyleBackColor = true;
            // 
            // rbnalmuerzo
            // 
            this.rbnalmuerzo.AutoSize = true;
            this.rbnalmuerzo.Checked = true;
            this.rbnalmuerzo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbnalmuerzo.Location = new System.Drawing.Point(245, 59);
            this.rbnalmuerzo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnalmuerzo.Name = "rbnalmuerzo";
            this.rbnalmuerzo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbnalmuerzo.Size = new System.Drawing.Size(96, 25);
            this.rbnalmuerzo.TabIndex = 5;
            this.rbnalmuerzo.Text = "Almuerzo";
            this.rbnalmuerzo.UseVisualStyleBackColor = true;
            // 
            // rbndesayuno
            // 
            this.rbndesayuno.AutoSize = true;
            this.rbndesayuno.Location = new System.Drawing.Point(73, 59);
            this.rbndesayuno.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbndesayuno.Name = "rbndesayuno";
            this.rbndesayuno.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbndesayuno.Size = new System.Drawing.Size(98, 25);
            this.rbndesayuno.TabIndex = 4;
            this.rbndesayuno.Text = "Desayuno";
            this.rbndesayuno.UseVisualStyleBackColor = true;
            // 
            // rbnreserva
            // 
            this.rbnreserva.AutoSize = true;
            this.rbnreserva.Checked = true;
            this.rbnreserva.Location = new System.Drawing.Point(86, 24);
            this.rbnreserva.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnreserva.Name = "rbnreserva";
            this.rbnreserva.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbnreserva.Size = new System.Drawing.Size(83, 25);
            this.rbnreserva.TabIndex = 1;
            this.rbnreserva.TabStop = true;
            this.rbnreserva.Text = "Reserva";
            this.rbnreserva.UseVisualStyleBackColor = true;
            // 
            // rbnbolsa
            // 
            this.rbnbolsa.AutoSize = true;
            this.rbnbolsa.Location = new System.Drawing.Point(270, 24);
            this.rbnbolsa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnbolsa.Name = "rbnbolsa";
            this.rbnbolsa.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbnbolsa.Size = new System.Drawing.Size(65, 25);
            this.rbnbolsa.TabIndex = 3;
            this.rbnbolsa.Text = "Bolsa";
            this.rbnbolsa.UseVisualStyleBackColor = true;
            // 
            // dtpfecha
            // 
            this.dtpfecha.Location = new System.Drawing.Point(185, 183);
            this.dtpfecha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpfecha.Name = "dtpfecha";
            this.dtpfecha.Size = new System.Drawing.Size(298, 29);
            this.dtpfecha.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btneliminar);
            this.panel1.Controls.Add(this.btnbuscar);
            this.panel1.Controls.Add(this.txtcodigo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(14, 317);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 53);
            this.panel1.TabIndex = 7;
            // 
            // btneliminar
            // 
            this.btneliminar.Image = ((System.Drawing.Image)(resources.GetObject("btneliminar.Image")));
            this.btneliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btneliminar.Location = new System.Drawing.Point(494, 8);
            this.btneliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(92, 37);
            this.btneliminar.TabIndex = 3;
            this.btneliminar.Text = "Quitar";
            this.btneliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btneliminar.UseVisualStyleBackColor = true;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // btnbuscar
            // 
            this.btnbuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnbuscar.Image")));
            this.btnbuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbuscar.Location = new System.Drawing.Point(366, 8);
            this.btnbuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(92, 37);
            this.btnbuscar.TabIndex = 2;
            this.btnbuscar.Text = "Buscar";
            this.btnbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnbuscar.UseVisualStyleBackColor = true;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // txtcodigo
            // 
            this.txtcodigo.Location = new System.Drawing.Point(140, 8);
            this.txtcodigo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtcodigo.MaxLength = 3;
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(126, 29);
            this.txtcodigo.TabIndex = 1;
            this.txtcodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcodigo_KeyPress);
            this.txtcodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtcodigo_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "CODIGO:";
            // 
            // dgvReserva
            // 
            this.dgvReserva.BackgroundColor = System.Drawing.Color.White;
            this.dgvReserva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReserva.Location = new System.Drawing.Point(14, 380);
            this.dgvReserva.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvReserva.Name = "dgvReserva";
            this.dgvReserva.Size = new System.Drawing.Size(634, 284);
            this.dgvReserva.TabIndex = 8;
            this.dgvReserva.SelectionChanged += new System.EventHandler(this.dgvReserva_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 193);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "FECHA:";
            // 
            // btnenviar
            // 
            this.btnenviar.Image = ((System.Drawing.Image)(resources.GetObject("btnenviar.Image")));
            this.btnenviar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnenviar.Location = new System.Drawing.Point(555, 674);
            this.btnenviar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnenviar.Name = "btnenviar";
            this.btnenviar.Size = new System.Drawing.Size(93, 37);
            this.btnenviar.TabIndex = 10;
            this.btnenviar.Text = "Enviar";
            this.btnenviar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnenviar.UseVisualStyleBackColor = true;
            this.btnenviar.Click += new System.EventHandler(this.btnenviar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(217, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 21);
            this.label3.TabIndex = 11;
            this.label3.Text = "RESIDENCIA UNIVERSITARIA";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(-4, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(683, 40);
            this.panel2.TabIndex = 12;
            // 
            // Reserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(677, 719);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnenviar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvReserva);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtpfecha);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI Symbol", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Reserva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reserva";
            this.Load += new System.EventHandler(this.Reserva_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReserva)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbnotros;
        private System.Windows.Forms.RadioButton rbnsalud;
        private System.Windows.Forms.RadioButton rbntrabajo;
        private System.Windows.Forms.RadioButton rbnestudio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbnreserva;
        private System.Windows.Forms.RadioButton rbnbolsa;
        private System.Windows.Forms.DateTimePicker dtpfecha;
        private System.Windows.Forms.TextBox txtotros;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnbuscar;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvReserva;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnenviar;
        private System.Windows.Forms.CheckBox rbncena;
        private System.Windows.Forms.CheckBox rbnalmuerzo;
        private System.Windows.Forms.CheckBox rbndesayuno;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
    }
}