namespace Comedor.Vista
{
    partial class PrintRegTurno
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
            this.rvReporteTurno = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvReporteTurno
            // 
            this.rvReporteTurno.AutoSize = true;
            this.rvReporteTurno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvReporteTurno.Location = new System.Drawing.Point(0, 0);
            this.rvReporteTurno.Name = "rvReporteTurno";
            this.rvReporteTurno.Size = new System.Drawing.Size(923, 523);
            this.rvReporteTurno.TabIndex = 0;
            this.rvReporteTurno.Load += new System.EventHandler(this.rvReporteTurno_Load);
            // 
            // PrintRegTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 523);
            this.Controls.Add(this.rvReporteTurno);
            this.Name = "PrintRegTurno";
            this.Text = "PrintRegTurno";
            this.Load += new System.EventHandler(this.PrintRegTurno_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvReporteTurno;

    }
}