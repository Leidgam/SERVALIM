using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comedor.Modelo;
using Microsoft.Reporting.WinForms;

namespace Comedor.Vista.Reportes
{
    public partial class PrintReportConsumidor : Form
    {
        public List<Consumidor_Periodo> ListConsumidor;

        public int CantidadTotal;
        public String periodo;
        public String area;
        public String grupo;
        public String facultad;
        public String escuela;
        public String ciclo;

        
        private DataSet2 reporte;

        public DataSet2 Reporte
        {
            get { return reporte; }
            set { reporte = value; }
        }

        public PrintReportConsumidor()
        {
            InitializeComponent();
        }

        private void PrintReportConsumidor_Load(object sender, EventArgs e)
        {

            rvReporteConsumidor.LocalReport.ReportEmbeddedResource = "Comedor.Vista.Reportes.Report2.rdlc";
            rvReporteConsumidor.LocalReport.EnableExternalImages = true;
            rvReporteConsumidor.LocalReport.DataSources.Clear();
            llenarDatos();
            List<ReportParameter> parameters = new List<ReportParameter>();
            ReportParameter fechaactual = new ReportParameter("fechaactual", DateTime.Now.ToString());
            ReportParameter CantTotal = new ReportParameter("total", this.CantidadTotal.ToString());
            ReportParameter Periodo = new ReportParameter("periodo", this.periodo);
            ReportParameter Area = new ReportParameter("area", this.area);
            ReportParameter Grupo = new ReportParameter("grupo", this.grupo);
            ReportParameter Facultad = new ReportParameter("facultad", this.facultad);
            ReportParameter Escuela = new ReportParameter("escuela", this.escuela);
            ReportParameter Ciclo = new ReportParameter("ciclo", this.ciclo);

            parameters.Add(fechaactual);
            parameters.Add(CantTotal);
            parameters.Add(Periodo);
            parameters.Add(Area);
            parameters.Add(Grupo);
            parameters.Add(Facultad);
            parameters.Add(Escuela);
            parameters.Add(Ciclo);

            rvReporteConsumidor.LocalReport.SetParameters(parameters);
            rvReporteConsumidor.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", (DataTable)reporte.Consumidor));
            rvReporteConsumidor.SetDisplayMode(DisplayMode.PrintLayout);
            this.rvReporteConsumidor.RefreshReport();
        }

        public void llenarDatos()
        {
            reporte = new DataSet2();
            int i = 1;

            foreach (Consumidor_Periodo item in this.ListConsumidor)
            {
                DataRow filaCon = reporte.Consumidor.NewConsumidorRow();

                filaCon["Numero"] = i++;
                filaCon["Codigo"] = item.Codigo;
                filaCon["Nombres"] = item.Consumidor.Persona.Nombres ;
                filaCon["Apellidos"] = item.Consumidor.Persona.Paterno + " " + item.Consumidor.Persona.Materno;
                MessageBox.Show(item.Consumidor.Persona.Paterno);
                if (item.Consumidor.CodUniversitario == " " || item.Consumidor.CodUniversitario == "" || item.Consumidor.CodUniversitario == null)
                {
                    filaCon["CodUniv"] = "-";
                }
                else
                {
                    filaCon["CodUniv"] = item.Consumidor.CodUniversitario;
                }
                   
                reporte.Consumidor.Rows.Add(filaCon);
                reporte.Consumidor.AcceptChanges();
            }

        }
    }
}
