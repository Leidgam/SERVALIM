﻿namespace Comedor.Vista.Reportes
{
    partial class PrintReportConsumidorPersona
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
            this.rvReporte = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvReporte
            // 
            this.rvReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvReporte.Location = new System.Drawing.Point(0, 0);
            this.rvReporte.Name = "rvReporte";
            this.rvReporte.Size = new System.Drawing.Size(599, 346);
            this.rvReporte.TabIndex = 0;
            // 
            // PrintReportConsumidorPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 346);
            this.Controls.Add(this.rvReporte);
            this.Name = "PrintReportConsumidorPersona";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir Reporte";
            this.Load += new System.EventHandler(this.PrintReportConsumidorPersona_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvReporte;
    }
}