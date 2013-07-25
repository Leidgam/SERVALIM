using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comedor.Modelo.Entidades;
using Comedor.Modelo;
using Microsoft.Reporting.WinForms;
using System.IO;


namespace Comedor.Vista.Reportes
{
    public partial class PrintReportConsumidorPersona : Form
    {
        public List<ConsumidorTurno> ListConsumidor;
        public consumidor cons;

        
        private DataSet3 reporte;

        public DataSet3 Reporte
        {
            get { return reporte; }
            set { reporte = value; }
        }
        
        public PrintReportConsumidorPersona()
        {
            InitializeComponent();
        }

        private void PrintReportConsumidorPersona_Load(object sender, EventArgs e)
        {
            rvReporte.LocalReport.ReportEmbeddedResource = "Comedor.Vista.Reportes.Report3.rdlc";
            rvReporte.LocalReport.EnableExternalImages = true;
            rvReporte.LocalReport.DataSources.Clear();
            llenarDatos();
            //String exeFolder = Path.GetDirectoryName(Application.ExecutablePath);
          //  String imgPath = Path.Combine(exeFolder, "D:/Comedor2.0/Fotos/" + cons.Persona.IdPersona + ".jpg");
            
        //    var file = new Uri(imgPath);
            List<ReportParameter> parameters = new List<ReportParameter>();
      //      ReportParameter path = new ReportParameter("Path", file.AbsoluteUri);
            ReportParameter CodUniv = new ReportParameter("CodUniv", cons.CodUniversitario);
            ReportParameter Apellidos= new ReportParameter("Apellido", cons.Persona.Apellidos);
            ReportParameter Nombres = new ReportParameter("Nombre", cons.Persona.PrimerNombre+" "+cons.Persona.SegundoNombre);
            ReportParameter Residecia = new ReportParameter("Area", cons.Area.Nombre);
            ReportParameter Facultad = new ReportParameter("Facultad", cons.EAP.Facultad.Nombre);
            ReportParameter eap = new ReportParameter("EAP", cons.EAP.Nombre);
            ReportParameter foto = new ReportParameter("Foto", "D:/Comedor2.0/Fotos/"+cons.Persona.IdPersona+".jpg");
            ReportParameter fechaactual = new ReportParameter("fechaactual", DateTime.Now.ToString());

          //  parameters.Add(path);
            parameters.Add(CodUniv);
            parameters.Add(Apellidos);
            parameters.Add(Nombres);
            parameters.Add(Residecia);
            parameters.Add(Facultad);
            parameters.Add(eap);
            parameters.Add(foto);
            parameters.Add(fechaactual);

            rvReporte.LocalReport.SetParameters(parameters);
            //  rvReporte.LocalReport.SubreportProcessing += DemoSubreportProcessingEventHandler;
            rvReporte.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", (DataTable)reporte.Persona));

            rvReporte.SetDisplayMode(DisplayMode.PrintLayout);


            this.rvReporte.RefreshReport();
        }

        public void llenarDatos()
        {
            reporte = new DataSet3();
            int i = 1;

            foreach (ConsumidorTurno item in this.ListConsumidor)
            {
                DataRow filaCon = reporte.Persona.NewPersonaRow();

                filaCon["Numero"] = i++;
                filaCon["Fecha"] = item.Fecha.Date.ToString("d");
                filaCon["Dia"] = item.Fecha.ToString("dddd", new System.Globalization.CultureInfo("es-ES"));

                if (item.Turno.DesAlmCen == 1) { filaCon["Comida"] = "Desayuno"; }
                if (item.Turno.DesAlmCen == 2) { filaCon["Comida"] = "Almuerzo"; }
                if (item.Turno.DesAlmCen == 3) { filaCon["Comida"] = "Cena"; }


                if (item.Hora.Hour.ToString() == "0") { filaCon["Hora"] = "-"; }
                else { filaCon["Hora"] = item.Hora.ToLongTimeString(); }
                

                if (item.Estado == 1)
                {
                    filaCon["Asistencia"] = "Si";
                }
                else
                {
                    filaCon["Asistencia"] = "No";
                }
                filaCon["Foto"] ="D:/Comedor2.0/Fotos/"+cons.Persona.IdPersona+".jpg"; 
                reporte.Persona.Rows.Add(filaCon);
                reporte.Persona.AcceptChanges();
            }
        }
    }
}
