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
using System.IO;
using Microsoft.Reporting.WinForms;
using Comedor.Control;

namespace Comedor.Vista
{
    public partial class PrintRegTurno : Form
    {
        public List<RegistroEntrada> ListRE;
        public String fechaInicio;
        public String fechaFin;
        public int SumaCantidad;

        private DataSet1 reporte;

        public DataSet1 Reporte
        {
            get { return reporte; }
            set { reporte = value; }
        }

        public PrintRegTurno()
        {
            InitializeComponent();
        }


        private void PrintRegTurno_Load(object sender, EventArgs e)
        {
            rvReporteTurno.LocalReport.ReportEmbeddedResource = "Comedor.Vista.Reportes.Report1.rdlc";
            rvReporteTurno.LocalReport.EnableExternalImages = true;
            rvReporteTurno.LocalReport.DataSources.Clear();
            llenarDatos();
         //   String exeFolder = Path.GetDirectoryName(Application.ExecutablePath);
         //   String imgPath = Path.Combine(exeFolder, "Imagenes/figueri.bmp");

         //   var file = new Uri(imgPath);
            List<ReportParameter> parameters = new List<ReportParameter>();
         //   ReportParameter path = new ReportParameter("Path", file.AbsoluteUri);
            ReportParameter fechaactual = new ReportParameter("fechaactual", DateTime.Now.ToString());
            ReportParameter fechaIn = new ReportParameter("FechaInicio", this.fechaInicio);
            ReportParameter fechaFn = new ReportParameter("FechaFin", this.fechaFin);
            ReportParameter CantTotal = new ReportParameter("CantidadTotal", this.SumaCantidad.ToString());
            
        //  parameters.Add(path);
            parameters.Add(fechaactual);
            parameters.Add(fechaIn);
            parameters.Add(fechaFn);
            parameters.Add(CantTotal);

            rvReporteTurno.LocalReport.SetParameters(parameters);
            //  rvReporteTurno.LocalReport.SubreportProcessing += DemoSubreportProcessingEventHandler;
            rvReporteTurno.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", (DataTable)reporte.Registro));

            rvReporteTurno.SetDisplayMode(DisplayMode.PrintLayout);

            this.rvReporteTurno.RefreshReport();
        }

        public void llenarDatos()
        {
            reporte = new DataSet1();
            int i = 1;
            foreach (RegistroEntrada item in this.ListRE)
            {
                DataRow filaReg = reporte.Registro.NewRegistroRow();

                filaReg["Numero"] = i++;
                filaReg["Fecha"] = item.FechaHora.Date.ToString("d");
                filaReg["Dia"] = item.FechaHora.ToString("dddd", new System.Globalization.CultureInfo("es-ES"));

                if (item.Turno.DesAlmCen == 1) { filaReg["DesAlmCen"] = "Desayuno"; }
                if (item.Turno.DesAlmCen == 2) { filaReg["DesAlmCen"] = "Almuerzo"; }
                if (item.Turno.DesAlmCen == 3) { filaReg["DesAlmCen"] = "Cena"; }

                m_consumidor mc = new m_consumidor();
                int total = mc.CantidadConsumidores(item.FechaHora.Date.ToString("d"), item.Turno.IdTurno);
                filaReg["Falta"] = (total - item.Estado).ToString();
                filaReg["Total"] = total.ToString();

                filaReg["Turno"] = item.Turno.Item;
                filaReg["Cantidad"] = item.Estado;
                reporte.Registro.Rows.Add(filaReg);
                reporte.Registro.AcceptChanges();
            }

        }

        private void rvReporteTurno_Load(object sender, EventArgs e)
        {

        }
    }
}
