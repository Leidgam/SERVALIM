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
using System.Globalization;



namespace Comedor.Vista.Reportes
{
    public partial class Print_Reservas : Form
    {


        #region declaraciones
        private Reserv.DataSet5 reporte;
        public List<RESERVA> reservas;

        public DataGridView lista;
        //Parametros
        public DateTime date = DateTime.Today;
        public String tipoReserva;
        public String tiempoComidas;
        public String Residencia;
        #endregion

        public Print_Reservas()
        {
            InitializeComponent();
        }

    

        public void cargar()
        {
            rvReservas.LocalReport.ReportEmbeddedResource = "Comedor.Vista.Reportes.Reserv.rptReserva.rdlc";
            rvReservas.LocalReport.EnableExternalImages = true;
            rvReservas.LocalReport.DataSources.Clear();
            llenarDatos();
          /*  String exeFolder = Path.GetDirectoryName(Application.ExecutablePath);
            String imgPath = Path.Combine(exeFolder, "Imagenes/figueri.bmp");

            var file = new Uri(imgPath);*/
            List<ReportParameter> parameters = new List<ReportParameter>();
           // ReportParameter path = new ReportParameter("path", file.AbsoluteUri);
           
            ReportParameter tipoReser = new ReportParameter("TipoReserva", tipoReserva);
            ReportParameter tiempoComida = new ReportParameter("TiempoComida", tiempoComidas);
            ReportParameter Resi = new ReportParameter("Residencia", Residencia);
            String dia = date.Date.ToString("dddd", new CultureInfo("es-ES"));
            String dos = (dia.Substring(0, 1)).ToUpper()+ dia.Substring(1);
            ReportParameter pdia = new ReportParameter("dia", dos);

            
            parameters.Add(tipoReser);
            parameters.Add(tiempoComida);
            parameters.Add(Resi);
            parameters.Add(pdia);

          //  ReportParameter fecha = new ReportParameter("fecha", date.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("es-ES")));
           // parameters.Add(fecha);
            //rvReservas.LocalReport.SetParameters(parameters);
            //  rvKardex.LocalReport.SubreportProcessing += DemoSubreportProcessingEventHandler;
            rvReservas.LocalReport.DataSources.Add(new ReportDataSource("DataSet5", (DataTable)reporte.Reserva));

            rvReservas.SetDisplayMode(DisplayMode.PrintLayout);
        }

        public void llenarDatos()
        {
            reporte = new Reserv.DataSet5();
         int f=1;
            foreach (DataGridViewRow item in lista.Rows)
            {
                DataRow filaRes = reporte.Reserva.NewReservaRow();

                filaRes["No"] = item.Cells[1].Value.ToString();
                filaRes["Nombre"] = item.Cells[2].Value.ToString()+", "+item.Cells[3].Value.ToString();
                filaRes["Fecha"] = item.Cells[5].Value.ToString();
                filaRes["Dia"] = item.Cells[6].Value.ToString();
                filaRes["Comida"] = item.Cells[7].Value.ToString();
                filaRes["Servicio"] = item.Cells[8].Value.ToString();
                filaRes["Horario"] = item.Cells[10].Value.ToString();
                filaRes["Horario"] = item.Cells[9].Value.ToString();

                reporte.Reserva.Rows.Add(filaRes);
                reporte.Reserva.AcceptChanges();
                f++;
            }

        }

        private void Print_Reservas_Load(object sender, EventArgs e)
        {
            cargar();
            this.rvReservas.RefreshReport();
        }

    }
}
