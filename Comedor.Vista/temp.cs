using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comedor.Control;
using Comedor.Modelo;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Comedor.Vista
{
    public class temp
    {

        conexion conn = new conexion();
        List<EAP> escuelas = new List<EAP>();
        m_consumidor consumidores = new m_consumidor();
        List<consumidor> allcons;

        public temp()
        {
            //m_EAP me = new m_EAP();
            //escuelas = me.ListarAllEAP();
        }

        public void GuardarFoto1(Image img, String idPersona)
        {

            img.Save(@"\\CONTROLALIMENTA\Fotos\" + idPersona + ".jpg", ImageFormat.Jpeg);
            
        }

        public void empezar()
        {
            string query = "select * from TEMP";
            // Create a SqlCommand object and pass the constructor the connection string and the query string.
            conn.open();
            SqlCommand queryCommand = new SqlCommand(query, conn.get());
            // Use the above SqlCommand object to create a SqlDataReader object.
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();

            // Create a DataTable object to hold all the data returned by the query.
            DataTable dataTable = new DataTable();
            empezar555();
            // Use the DataTable.Load(SqlDataReader) function to put the results of the query into a DataTable.
            dataTable.Load(queryCommandReader);
            m_consumidor mc = new m_consumidor();
            foreach (DataRow item in dataTable.Rows)
            {
                consumidor cons = new consumidor();
                cons.Persona = new Persona();
                cons.CodUniversitario = (item[0].ToString()).Trim();
                string[] hola = (item[1].ToString()).Split(',');
                cons.Persona.Nombres = hola[1];
                cons.Persona.Paterno = hola[0];
                cons.Persona.Materno = "Pendiente";
                cons.Persona.TipoDNI = 0;
                cons.Persona.DNI = "00000000";
                cons.Persona.FechaNac = new DateTime(2000, 1, 1);
                cons.Persona.Pais = new Pais();
                cons.Persona.Pais.IdPais = "177";
                cons.Persona.Departamento = new Departamento();
                cons.Persona.Departamento.IdDepartamento = "2911";
                cons.Persona.Distrito = "Ñaña";
                cons.IdUsuarioReg = "US00000001";
                cons.EAP = new EAP();
                cons.EAP.IdEAP = "019";
                cons.Ciclo = 1;
                cons.Grupo = new Grupo();
                cons.Grupo.IdGrupo = "GR00000001";
                cons.Area = new Area();
                cons.Area.IdArea = "004";

                Consumidor_Periodo cp = new Consumidor_Periodo();
                cp.Periodo = new Periodo();
                cp.Periodo.IdPeriodo = "003";
                cp.Contrato = 0;
                cp.AutoAsig = true;
                cons.periodos.Add(cp);

                String idPersona = consumidores.AgregarConsumidor(cons);

                String anterior = getIperAnte(cons.CodUniversitario);
                if (anterior == null)
                {
                }
                else
                {
                    Image foto;
                    try
                    {
                        using (FileStream stream = new FileStream(@"E:\FotosAnt\" + anterior + ".jpg", FileMode.Open, FileAccess.Read))
                        {
                            foto = Image.FromStream(stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        foto = null;
                    }
                    if (foto != null)
                    {
                        GuardarFoto(idPersona, foto);
                    }
                    else
                    {
                        GuardarFoto(idPersona, Image.FromStream(new FileStream(@"E:\FotosAnt\PR00000024.jpg",FileMode.Open, FileAccess.Read)));
                    }
                }
            }
        }

        public void empezar1()
        {
            List<consumidor> listaTEMP2 = new List<consumidor>();
            string query = "select * from TEMP2";
            // Create a SqlCommand object and pass the constructor the connection string and the query string.
            conn.open();
            SqlCommand queryCommand = new SqlCommand(query, conn.get());
            // Use the above SqlCommand object to create a SqlDataReader object.
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();

            // Create a DataTable object to hold all the data returned by the query.
            DataTable dataTable = new DataTable();

            // Use the DataTable.Load(SqlDataReader) function to put the results of the query into a DataTable.
            dataTable.Load(queryCommandReader);
            m_consumidor mc = new m_consumidor();
            foreach (DataRow item in dataTable.Rows)
            {
                consumidor cons = new consumidor();
                int año = int.Parse(item[0].ToString());
                cons.Ciclo = (año * 2);
                cons.EAP = new EAP();
                cons.EAP.IdEAP = item[1].ToString();
                cons.Persona = new Persona();
             
                cons.Persona.Paterno = item[2].ToString();
                cons.Persona.Materno = item[3].ToString();
                cons.Persona.Nombres = item[4].ToString();
                cons.CodUniversitario = (item[5].ToString()).Trim();
                cons.Area = new Area();
                cons.Area.IdArea = "007";
                Comedor.Modelo.Auxiliares.cambioConsumidor cambio = new Modelo.Auxiliares.cambioConsumidor();
                cambio.contacto= true;
                cambio.agregar = true;
                Contacto cont = new Contacto();
                cont.Valor = item[7].ToString();
                cont.Tipo = 1;
                cont.Descripcion = "Implementación DIGUESI";
                cambio.contact = cont;

                cons.cambios.Add(cambio);

                  Comedor.Modelo.Auxiliares.cambioConsumidor cambio2 = new Modelo.Auxiliares.cambioConsumidor();
                cambio2.contacto= true;
                cambio2.agregar = true;
                Contacto cont2 = new Contacto();
                cont2.Valor = item[8].ToString();
                cont2.Tipo = 2;
                cont2.Descripcion = "Implementación DIGUESI";
                cambio2.contact = cont;

                cons.cambios.Add(cambio);

                cons.Persona.TipoDNI = 1;
                cons.Persona.DNI = item[9].ToString();
                cons.Persona.FechaNac = DateTime.Parse(item[11].ToString());
                cons.Persona.Pais = new Pais();
                cons.Persona.Pais.IdPais = "177";
                cons.Persona.Departamento = new Departamento();
                cons.Persona.Departamento.IdDepartamento = "2911";
                cons.Persona.Distrito = item[16].ToString();
                cons.IdUsuarioReg = "US00000001";
                cons.Grupo = new Grupo();
                cons.Grupo.IdGrupo = "GR00000001";
                listaTEMP2.Add(cons);


            }

             string query2 = "SELECT Persona.IdPersona, CONSUMIDOR.IdConsumidor, CONSUMIDOR.CodUniversitario FROM Persona INNER JOIN CONSUMIDOR ON Persona.IdPersona = CONSUMIDOR.IdPersona";
            // Create a SqlCommand object and pass the constructor the connection string and the query string.
            conn.open();
            SqlCommand queryCommand2 = new SqlCommand(query2, conn.get());
            // Use the above SqlCommand object to create a SqlDataReader object.
            SqlDataReader queryCommandReader2 = queryCommand2.ExecuteReader();

            // Create a DataTable object to hold all the data returned by the query.
            DataTable dataTable2 = new DataTable();
        
            // Use the DataTable.Load(SqlDataReader) function to put the results of the query into a DataTable.
            dataTable2.Load(queryCommandReader2);
            int todos = 0;
            foreach (DataRow item in dataTable2.Rows)
            {
                bool t = buscarSus(listaTEMP2, item[2].ToString(), item[0].ToString(), item[1].ToString());
                if (t)
                {
                    todos++;
                }
            }
            MessageBox.Show(todos+"");

        }
        m_consumidor _mConsumidor = new m_consumidor();
        private bool buscarSus(List<consumidor> lista, String codUniversitario, String idPersona, string idConsumidor)
        {
            foreach (consumidor item in lista)
            {
                if (item.CodUniversitario.Equals(codUniversitario) || item.CodUniversitario == codUniversitario)
                {
                    item.Persona.IdPersona = idPersona;
                    item.IdConsumidor = idConsumidor;
                    _mConsumidor.Editar(item);
                    return true;
                }
            }

            return false;
        }

        public void empezar43()
        {
            string query = "SELECT CONSUMIDOR.CodUniversitario, Persona.IdPersona FROM Persona INNER JOIN CONSUMIDOR ON Persona.IdPersona = CONSUMIDOR.IdPersona";
            // Create a SqlCommand object and pass the constructor the connection string and the query string.
            conn.open();
            SqlCommand queryCommand = new SqlCommand(query, conn.get());
            // Use the above SqlCommand object to create a SqlDataReader object.
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();

            // Create a DataTable object to hold all the data returned by the query.
            DataTable dataTable = new DataTable();

            // Use the DataTable.Load(SqlDataReader) function to put the results of the query into a DataTable.
            dataTable.Load(queryCommandReader);
            m_consumidor mc = new m_consumidor();
            foreach (DataRow item in dataTable.Rows)
            {
                Image img = DownloadImage("https://webapp.upeu.edu.pe/fotodb/0380201221873.jpg");
                GuardarFoto1(img, item[1].ToString());
            }
        }

        List<string[]> lista = new List<string[]>();

        public void empezar555()
        {
        
            string query = "SELECT UNIV, idPers FROM TEMP_FOTOS";
            conn.open();
            SqlCommand queryCommand = new SqlCommand(query, conn.get());
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(queryCommandReader);
            foreach (DataRow item in dataTable.Rows)
            {
                string[] registro = new string[2];
                registro[0] = item[0].ToString();
                registro[1] = item[1].ToString();
                lista.Add(registro);
            }
            
            string query2 = "SELECT Persona.IdPersona, CONSUMIDOR.CodUniversitario FROM CONSUMIDOR INNER JOIN Persona ON CONSUMIDOR.IdPersona = Persona.IdPersona";
            SqlCommand queryCommand2 = new SqlCommand(query2, conn.get());
            SqlDataReader queryCommandReader2 = queryCommand2.ExecuteReader();
            DataTable dataTable2 = new DataTable();
            dataTable2.Load(queryCommandReader2);
            foreach (DataRow item in dataTable2.Rows)
            {
                String anterior = getIperAnte(item[1].ToString());
                if (anterior == null)
                {
                }
                else
                {
                    Image foto;
                    try
                    {
                        using (FileStream stream = new FileStream(@"E:\FotosAnt\" + anterior + ".jpg", FileMode.Open, FileAccess.Read))
                        {
                            foto = Image.FromStream(stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        foto = null;
                    }
                    if (foto != null)
                    {
                        GuardarFoto(item[0].ToString(),foto);
                    }
                }
            }
        }

        private void GuardarFoto(String nombre, Image img)
        {

            if (System.IO.File.Exists(@"\\CONTROLALIMENTA\Fotos\" + nombre + ".jpg"))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(@"\\CONTROLALIMENTA\Fotos\" + nombre + ".jpg");
                }
                catch (System.IO.IOException e)
                {

                }
            }

            try
            {
                Image foto = ResizeImage(img, 420, 500);
                foto.Save(@"\\CONTROLALIMENTA\Fotos\" + nombre + ".jpg", ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {

            }

        }

        public static Image ResizeImage(Image srcImage, int newWidth, int newHeight)
        {

            using (Bitmap imagenBitmap =
               new Bitmap(newWidth, newHeight, PixelFormat.Format32bppRgb))
            {
                imagenBitmap.SetResolution(
                   Convert.ToInt32(srcImage.HorizontalResolution),
                   Convert.ToInt32(srcImage.HorizontalResolution));

                using (Graphics imagenGraphics =
                        Graphics.FromImage(imagenBitmap))
                {
                    imagenGraphics.SmoothingMode =
                       SmoothingMode.AntiAlias;
                    imagenGraphics.InterpolationMode =
                       InterpolationMode.HighQualityBicubic;
                    imagenGraphics.PixelOffsetMode =
                       PixelOffsetMode.HighQuality;
                    imagenGraphics.DrawImage(srcImage,
                       new Rectangle(0, 0, newWidth, newHeight),
                       new Rectangle(0, 0, srcImage.Width, srcImage.Height),
                       GraphicsUnit.Pixel);
                    MemoryStream imagenMemoryStream = new MemoryStream();
                    imagenBitmap.Save(imagenMemoryStream, ImageFormat.Jpeg);
                    srcImage = Image.FromStream(imagenMemoryStream);
                }
            }
            return srcImage;
        }

        public string getIperAnte(string codUniv)
        {
            foreach (string[] item in lista)
            {
                if (item[0] == codUniv)
                {
                    return item[1];
                }
            }
            return null;
        }

        public String getIdEscuela(String nombre)
        {
            foreach (EAP item in escuelas)
            {
                if (item.Nombre == nombre)
                {
                    return item.IdEAP;
                }
            }
            return "003";
        }

        public byte[] getFoto(Image foto)
        {
            MemoryStream ms = new MemoryStream();
            foto.Save(ms, foto.RawFormat);
            //pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imagen = ms.GetBuffer();
            return imagen;
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public Image DownloadImage(string _URL)
        {

            Image _tmpImage = null;

            try
            {
                // Open a connection

                System.Net.HttpWebRequest _HttpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(_URL);

                _HttpWebRequest.AllowWriteStreamBuffering = true;

                // You can also specify additional header values like the user agent or the referer: (Optional)
                _HttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
                _HttpWebRequest.Referer = "http://www.google.com/";
                // set timeout for 20 seconds (Optional)

                _HttpWebRequest.Timeout = 20000;

                // Request response:

                System.Net.WebResponse _WebResponse = _HttpWebRequest.GetResponse();

                // Open data stream:

                System.IO.Stream _WebStream = _WebResponse.GetResponseStream();

                // convert webstream to image
                _tmpImage = Image.FromStream(_WebStream);
                // Cleanup
                _WebResponse.Close();
                _WebResponse.Close();
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
                return null;
            }
            return _tmpImage;
        }

    }
}
