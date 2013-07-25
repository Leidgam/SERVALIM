namespace Comedor.Vista.Acceso
{
    partial class Logueo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logueo));
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLogueo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassw = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(54, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "www.servicoalimentacion.com";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Bradley Hand ITC", 15.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(50, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 26);
            this.label5.TabIndex = 17;
            this.label5.Text = "ALIMENTACION";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Bradley Hand ITC", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(83, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 26);
            this.label4.TabIndex = 16;
            this.label4.Text = "SERVICIO";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            this.label4.DoubleClick += new System.EventHandler(this.label4_DoubleClick);
            // 
            // btnLogueo
            // 
            this.btnLogueo.BackColor = System.Drawing.Color.Black;
            this.btnLogueo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogueo.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnLogueo.Location = new System.Drawing.Point(101, 212);
            this.btnLogueo.Name = "btnLogueo";
            this.btnLogueo.Size = new System.Drawing.Size(75, 23);
            this.btnLogueo.TabIndex = 15;
            this.btnLogueo.Text = "Loguear";
            this.btnLogueo.UseVisualStyleBackColor = false;
            this.btnLogueo.Click += new System.EventHandler(this.btnLogueo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label3.Location = new System.Drawing.Point(11, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Bienvenido, por favor ingrese su usuario y contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Location = new System.Drawing.Point(11, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "CONTRASEÑA:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Location = new System.Drawing.Point(36, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "USUARIO:";
            // 
            // txtPassw
            // 
            this.txtPassw.Location = new System.Drawing.Point(101, 166);
            this.txtPassw.Name = "txtPassw";
            this.txtPassw.Size = new System.Drawing.Size(116, 20);
            this.txtPassw.TabIndex = 11;
            this.txtPassw.UseSystemPasswordChar = true;
            // 
            // txtLogin
            // 
            this.txtLogin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLogin.Location = new System.Drawing.Point(101, 137);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(116, 20);
            this.txtLogin.TabIndex = 10;
            // 
            // Logueo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(283, 307);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLogueo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassw);
            this.Controls.Add(this.txtLogin);
            this.Name = "Logueo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logueo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLogueo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassw;
        private System.Windows.Forms.TextBox txtLogin;
    }
}