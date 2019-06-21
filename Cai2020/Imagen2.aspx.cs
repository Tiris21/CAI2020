using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;

namespace Cai2020
{
    public partial class Imagen2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bitmap mapabit = new Bitmap(200, 100);
            Graphics lienzo;
            int rAng ;
            Font fuente1;
            SolidBrush pincel1;
            string rFnt;
            try
            {
                lienzo = Graphics.FromImage(mapabit);
                int nro;
                Random r = new Random();
                nro = r.Next(0, 9);
                rAng = r.Next(0, 180);

                fuente1 = new Font("Arial", 50);
                //SolidBrush pincel1 = new SolidBrush(Color.Red);
                rFnt="Arial";
                //rotamos el numero
                //fuente1 = CreateRotatedFont(rFnt, rAng);
                pincel1 = new SolidBrush(Color.Red);

                lienzo.DrawString(nro.ToString(), fuente1, pincel1, 20, 20);
                //Dibujar lineas
                for (int f = 1; f <= 10; f++)
                {
                    int x1 = r.Next(1, 200);
                    int y1 = r.Next(1, 80);
                    int x2 = r.Next(1, 200);
                    int y2 = r.Next(1, 80);
                    Pen lapiz1 = new Pen(Color.FromArgb(r.Next(1, 255), r.Next(1, 255), r.Next(1, 255)));
                    lienzo.DrawLine(lapiz1, x1, y1, x2, y2);
                }
                Session["captcha"] = nro.ToString();
                mapabit.Save(Response.OutputStream, ImageFormat.Gif);
            }
            catch (Exception ex)
            {
                string r = ex.ToString();
            }
        }

        //Font CreateRotatedFont(string fontname, int angleInDegrees)
        //{
        //    LogFont logf = new Microsoft.WindowsCE.Forms.LogFont();

        //    // Create graphics object for the form, and obtain
        //    // the current DPI value at design time. In this case,
        //    // only the vertical resolution is petinent, so the DpiY
        //    // property is used. 

        //    Graphics g = CreateGraphics();
        //    // Scale an 18-point font for current screen vertical DPI.
        //    logf.Height = (int)(-18f * g.DpiY / curDPI);

        //    // Convert specified rotation angle to tenths of degrees.  
        //    logf.Escapement = angleInDegrees * 10;

        //    // Orientation is the same as Escapement in mobile platforms.
        //    logf.Orientation = logf.Escapement;

        //    logf.FaceName = fontname;

        //    // Set LogFont enumerations.
        //    logf.CharSet = LogFontCharSet.Default;
        //    logf.OutPrecision = LogFontPrecision.Default;
        //    logf.ClipPrecision = LogFontClipPrecision.Default;
        //    logf.Quality = LogFontQuality.ClearType;
        //    logf.PitchAndFamily = LogFontPitchAndFamily.Default;

        //    // Explicitly dispose any drawing objects created.
        //    g.Dispose();

        //    return Font.FromLogFont(logf);
        //}


    }
}