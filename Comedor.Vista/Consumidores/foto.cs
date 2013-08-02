using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Drawing.Imaging;

namespace Comedor.Vista.Consumidores
{
    public partial class foto : Form
    {
        public foto()
        {
            InitializeComponent();
        }
        public String idPersona;
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

        private void foto_Load(object sender, EventArgs e)
        {
            try
            {
                Image foto;
                using (FileStream stream = new FileStream(@"\\192.168.102.18\Fotos\" + idPersona + ".jpg", FileMode.Open, FileAccess.Read))
                {
                    foto = Image.FromStream(stream);
                }

                Image ima = ResizeImage(foto, pictureBox1.Width, pictureBox1.Height);

                pictureBox1.Image = ima;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
