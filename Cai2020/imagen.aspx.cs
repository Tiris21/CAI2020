using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;

namespace Cai2020
{
    public partial class imagen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idazar;
            
            OracleDataReader miReader = null;
            //Initialize Oracle  connection.
            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["cai2020"].ConnectionString);
            try
            {
                Random rnd = new Random();
                int total_imgs = 200;
                idazar = rnd.Next(1, total_imgs);

                string sqlStmt = "Select ID_CAPTCHA,IMG,val from cap_int_TC_CAPTCHA where ID_CAPTCHA=" + idazar;

                // Establish a new OracleCommand
                con.Open();
                OracleCommand miComando = new OracleCommand(sqlStmt, con);
                OracleDataReader result = miComando.ExecuteReader(CommandBehavior.CloseConnection);
                if (result.Read())
                {
                    //Session["imagen"] = "No hubo error en oracle";
                    //guardo valor
                    HttpContext.Current.Session["captcha"] = result["val"].ToString();
                    //Response.BinaryWrite((byte[])miReader["IMG"]);
                    byte[] img = (byte[])result["IMG"];
                    MemoryStream str = new MemoryStream();
                    str.Write(img, 0, img.Length);
                    Bitmap bit = new Bitmap(str);
                    Response.ContentType = "image/jpeg";//Responder Img JPG
                    bit.Save(Response.OutputStream, ImageFormat.Jpeg);
                    bit.Dispose();
                }
                result.Dispose();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                string r = ex.ToString();
                miReader = null;
                //Session["imagen"] = ex.ToString();
                //Session["captcha"] = "";
            }
            finally
            {
                con.Close();
            }
            
        }

       
       
    }
}

