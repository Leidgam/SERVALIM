namespace Comedor.Vista.Reportes
{
    partial class PrintReportConsumidor
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
            this.rvReporteConsumidor = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvReporteConsumidor
            // 
            this.rvReporteConsumidor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvReporteConsumidor.Location = new System.Drawing.Point(0, 0);
            this.rvReporteConsumidor.Name = "rvReporteConsumidor";
            this.rvReporteConsumidor.Size = new System.Drawing.Size(602, 447);
            this.rvReporteConsumidor.TabIndex = 0;
            // 
            // PrintReportConsumidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 447);
            this.Controls.Add(this.rvReporteConsumidor);
            this.Name = "PrintReportConsumidor";
            this.Text = "PrintReportConsumidor";
            this.Load += new System.EventHandler(this.PrintReportConsumidor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvReporteConsumidor;
    }
}