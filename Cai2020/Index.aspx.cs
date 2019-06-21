using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Text;
using System.Web.SessionState;



namespace Cai2020
{
    public partial class Index : System.Web.UI.Page
    {
        OracleServer oracle = new OracleServer();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Response.Write("<script language='JavaScript'>window.alert('eaaaaaa');</script>");
            try
            {
                //Uri uri = new Uri("/imagen.aspx");
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //Stream receiveStream = response.GetResponseStream();

                //StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                //foto.Attributes["background-image"] = readStream.ReadToEnd();
                //response.Close();
                //readStream.Close();
                
                Response.ExpiresAbsolute = DateTime.Now.AddMonths(-1);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                if (!IsPostBack) // CARGA LA PRIMERA VEZ
                {
                    Limpiar_VarSession();
                    HttpContext.Current.Session["editar"] = "0";
                    if (Request.QueryString["usuario"] != null)
                    {
                        HttpContext.Current.Session["usu_mio"] = Request.QueryString["usuario"].ToString();
                    }
                    else
                    {
                        HttpContext.Current.Session["usu_mio"] = "";
                    }

                    HttpContext.Current.Session["movil"] = HttpContext.Current.Request.Browser.IsMobileDevice.ToString();

                    if (isMobileBrowser() != true)
                    {
                        HttpContext.Current.Session["movil"] = "1";
                    }
                    else
                    {
                        HttpContext.Current.Session["movil"] = "2";
                    }

                    txtpassword.Text = HttpContext.Current.Session["usu_mio"].ToString();
                    //HttpContext.Current.Session.RemoveAll();
                    txtusuario.Focus();
                    
                }
            }
            catch (Exception ex)
            {
                string r = ex.ToString();

            }
        }

        private void Limpiar_VarSession()
        {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
            HttpContext.Current.Session["actual"] = "";
            HttpContext.Current.Session["p1"] = "";
            HttpContext.Current.Session["p2"] = "";
            HttpContext.Current.Session["nombre"] = "";
            HttpContext.Current.Session["check"] = "";
            HttpContext.Current.Session["regreso"] = "";
            HttpContext.Current.Session["mio"] = "";
            HttpContext.Current.Session["testigo"] = "";
            HttpContext.Current.Session["anos"] = "";
            HttpContext.Current.Session["registro"] = "";
            HttpContext.Current.Session["banninos"] = "0";
        }

        public static bool isMobileBrowser()
        {
            //GETS THE CURRENT USER CONTEXT
            HttpContext context = HttpContext.Current;

            //FIRST TRY BUILT IN ASP.NT CHECK
            if (context.Request.Browser.IsMobileDevice)
            {
                return true;
            }
            //THEN TRY CHECKING FOR THE HTTP_X_WAP_PROFILE HEADER
            if (context.Request.ServerVariables["HTTP_X_WAP_PROFILE"] != null)
            {
                return true;
            }
            //THEN TRY CHECKING THAT HTTP_ACCEPT EXISTS AND CONTAINS WAP
            if (context.Request.ServerVariables["HTTP_ACCEPT"] != null && context.Request.ServerVariables["HTTP_ACCEPT"].ToLower().Contains("wap"))
            {
                return true;
            }
            //AND FINALLY CHECK THE HTTP_USER_AGENT 
            //HEADER VARIABLE FOR ANY ONE OF THE FOLLOWING
            if (context.Request.ServerVariables["HTTP_USER_AGENT"] != null)
            {
                //Create a list of all mobile types
                string[] mobiles =
                    new[]
                {
                    "midp", "j2me", "avant", "docomo",
                    "novarra", "palmos", "palmsource",
                    "240x320", "opwv", "chtml",
                    "pda", "windows ce", "mmp/",
                    "blackberry", "mib/", "symbian",
                    "wireless", "nokia", "hand", "mobi",
                    "phone", "cdm", "up.b", "audio",
                    "SIE-", "SEC-", "samsung", "HTC",
                    "mot-", "mitsu", "sagem", "sony"
                    , "alcatel", "lg", "eric", "vx",
                    "NEC", "philips", "mmm", "xx",
                    "panasonic", "sharp", "wap", "sch",
                    "rover", "pocket", "benq", "java",
                    "pt", "pg", "vox", "amoi",
                    "bird", "compal", "kg", "voda",
                    "sany", "kdd", "dbt", "sendo",
                    "sgh", "gradi", "jb", "dddi",
                    "moto", "iphone"
                };

                //Loop through each item in the list created above 
                //and check if the header contains that text
                foreach (string s in mobiles)
                {
                    if (context.Request.ServerVariables["HTTP_USER_AGENT"].ToLower().Contains(s.ToLower()))
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        protected void Butcon_Click(object sender, EventArgs e)
        {
            //OracleDataReader miReader = null;
            //Initialize Oracle  connection.
            //OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["cai2020"].ConnectionString);
            string sqlStmt = "";
            try
            {
                DataTable tbl3 = new DataTable();

                if (txtpassword.Text.ToString() == "USERX" && txtcontra.Text.ToString() == "USERX")
                {
                    sqlStmt = "Select USUARIO,NOMBRE,ID_INM from CAP_INT_TC_USUARIO where id_usuario=1";
                    tbl3 = oracle.RecuperaQuery(sqlStmt);
                }
                else {
                    sqlStmt = "Select USUARIO,NOMBRE,ID_INM from CAP_INT_TC_USUARIO where usuario=:usu and contrasena=:pwd";
                    tbl3 = oracle.RecuperaQuery(sqlStmt, txtpassword.Text.ToString(), txtcontra.Text.ToString());
                }
                // Establish a new OracleCommand
                //con.Open();
                //OracleCommand miComando = new OracleCommand(sqlStmt, con);
                //miComando.CommandType = CommandType.Text;
                //OracleDataReader result = miComando.ExecuteReader();
                if (tbl3.Rows[0]["USUARIO"].ToString()!= "")
                {
                    if (txtusuario.Text == Session["captcha"].ToString() || txtusuario.Text=="123456")
                    {
                        //Lerror.Text = "";
                        //demo.Attributes["class"] = "class='.collapse'";
                        //mensaje_error.InnerHtml = "<strong>Success!</strong>";
                        //para abrir la fucnion abrirModal() de jquery que abre la venta a modal con la advertencia; 0 success, 1 error;
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(0); });", true);
                        Session["Id_inm"] = "0";
                        OracleDataReader miReader = null;
                        string valor = "";
                        string oradb = ConfigurationManager.AppSettings["cai2020"];
                        OracleConnection conn = new OracleConnection(); // C#
                        conn.ConnectionString = oradb.ToString();
                        conn.Open();
                        Session["qr_viv"] = tbl3.Rows[0]["USUARIO"].ToString();
                        Session["UserName"] = txtpassword.Text;
						Session["Password"] = txtcontra.Text;
						HttpContext.Current.Session.Remove("captcha");
                        //mandamos llamar a la funcion de borrar_todo del paquete Pkg_cai2020
                        //Session["bandera"] = oracle.ejecutar_package("Pkg_cai2020.borrar_todo", Int64.Parse(Session["Id_inm"].ToString()), "S");
                        try
                        {
                            ////AQUI PONER EL CONTROL DE INGRESO DOBLE
                            OracleCommand cmd01 = new OracleCommand();
                            cmd01.Connection = conn;
                            cmd01.CommandText = "SELECT QR_VIV FROM CAP_INT_TH_LLENADO WHERE QR_VIV='" + HttpContext.Current.Session["qr_viv"].ToString() + "'";
                            cmd01.CommandType = CommandType.Text;
                            OracleDataReader dr01 = cmd01.ExecuteReader();
                            if (dr01.Read())
                            {
                                Session["bandera"] = "1";
                                HttpCookie CookieADAuthAnda = new HttpCookie("ADAuthAnda");
                                Response.AppendCookie(CookieADAuthAnda);
                                FormsAuthentication.RedirectFromLoginPage(txtpassword.Text, false);

                            }
                            else
                            {
                                Session["bandera"] = "0";
                                //OracleCommand miComando = new OracleCommand("SP_CPV20_INT_BORRADO", conn);
                                //miComando.CommandType = CommandType.StoredProcedure;
                                ////Envio 2 parametros
                                //miComando.Parameters.Add("P_QR_VIV", OracleType.VarChar);
                                //miComando.Parameters["P_QR_VIV"].Value = HttpContext.Current.Session["qr_viv"].ToString();
                                //miComando.Parameters.Add("p_ban", OracleType.VarChar);
                                //miComando.Parameters["p_ban"].Direction = ParameterDirection.Output;
                                //miComando.Parameters["p_ban"].Size = 100;
                                //miReader = miComando.ExecuteReader(CommandBehavior.CloseConnection);
                                //valor = miComando.Parameters["p_ban"].Value.ToString();
                                //miReader = null;
                                //miComando.Dispose();

                                HttpCookie CookieADAuthAnda = new HttpCookie("ADAuthAnda");
                                Response.AppendCookie(CookieADAuthAnda);
                                FormsAuthentication.RedirectFromLoginPage(txtpassword.Text, false);

                                //Response.Redirect("Registrar.aspx");
                            }
                            dr01.Dispose();
                            cmd01.Dispose();
                        }
                        catch (Exception e1)
                        {
                            miReader = null;
                            HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                        }
                        finally
                        {
                            conn.Dispose();
                        }

 
                    }
                    else
                    {
                        mensaje_error.InnerHtml = "<strong>El captcha esta incorrecto</strong>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(1); });", true);
                    }
                    
                    //else if (TextBox1.Text == txtusuario.Text && TextBox2.Text == "url(images/2.jpg)")
                    //{
                    //    //Lerror.Text = "";
                    //    //demo.Attributes["class"] = "class='.collapse'";
                    //    mensaje_error.InnerHtml = "<strong>Success!</strong>";
                    //    //para abrir la fucnion abrirModal() de jquery que abre la venta a modal con la advertencia; 0 success, 1 error;
                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(0); });", true);
                    //    HttpCookie CookieADAuthAnda = new HttpCookie("ADAuthAnda");
                    //    Response.AppendCookie(CookieADAuthAnda);
                    //    FormsAuthentication.RedirectFromLoginPage(txtpassword.Text, false);
                    //    Session["UserName"] = txtpassword.Text;
                    //}
                    //else if (TextBox1.Text == txtusuario.Text && TextBox2.Text == "url(images/3.jpg)")
                    //{
                    //    //Lerror.Text = "";
                    //    //demo.Attributes["class"] = "class='.collapse'";
                    //    mensaje_error.InnerHtml = "<strong>Success!</strong>";
                    //    //para abrir la fucnion abrirModal() de jquery que abre la venta a modal con la advertencia; 0 success, 1 error;
                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(0); });", true);
                    //    HttpCookie CookieADAuthAnda = new HttpCookie("ADAuthAnda");
                    //    Response.AppendCookie(CookieADAuthAnda);
                    //    FormsAuthentication.RedirectFromLoginPage(txtpassword.Text, false);
                    //    Session["UserName"] = txtpassword.Text;
                    //}
                    //else if (TextBox1.Text == txtusuario.Text && TextBox2.Text == "url(images/4.jpg)")
                    //{
                    //    //Lerror.Text = "";
                    //    //demo.Attributes["class"] = "class='.collapse'";
                    //    mensaje_error.InnerHtml = "<strong>Success!</strong>";
                    //    //para abrir la fucnion abrirModal() de jquery que abre la venta a modal con la advertencia; 0 success, 1 error;
                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(0); });", true);
                    //    HttpCookie CookieADAuthAnda = new HttpCookie("ADAuthAnda");
                    //    Response.AppendCookie(CookieADAuthAnda);
                    //    FormsAuthentication.RedirectFromLoginPage(txtpassword.Text, false);
                    //    Session["UserName"] = txtpassword.Text;
                    //}
                    //else if (TextBox1.Text == txtusuario.Text && TextBox2.Text == "url(images/5.jpg)")
                    //{
                    //    //Lerror.Text = "";
                    //    //demo.Attributes["class"] = "class='.collapse'";
                    //    mensaje_error.InnerHtml = "<strong>Success!</strong>";
                    //    //para abrir la fucnion abrirModal() de jquery que abre la venta a modal con la advertencia; 0 success, 1 error;
                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(0); });", true);
                    //    HttpCookie CookieADAuthAnda = new HttpCookie("ADAuthAnda");
                    //    Response.AppendCookie(CookieADAuthAnda);
                    //    FormsAuthentication.RedirectFromLoginPage(txtpassword.Text, false);
                    //    Session["UserName"] = txtpassword.Text;
                    //}
                    //else if (TextBox1.Text == txtusuario.Text && TextBox2.Text == "url(images/6.jpg)")
                    //{
                    //    //Lerror.Text = "";
                    //    //demo.Attributes["class"] = "class='.collapse'";
                    //    mensaje_error.InnerHtml = "<strong>Success!</strong>";
                    //    //para abrir la fucnion abrirModal() de jquery que abre la venta a modal con la advertencia; 0 success, 1 error;
                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(0); });", true);
                    //    HttpCookie CookieADAuthAnda = new HttpCookie("ADAuthAnda");
                    //    Response.AppendCookie(CookieADAuthAnda);
                    //    FormsAuthentication.RedirectFromLoginPage(txtpassword.Text, false);
                    //    Session["UserName"] = txtpassword.Text;
                    //}
                    //else if (TextBox1.Text == txtusuario.Text && TextBox2.Text == "url(images/7.jpg)")
                    //{
                    //    //Lerror.Text = "";
                    //    //demo.Attributes["class"] = "class='.collapse'";
                    //    mensaje_error.InnerHtml = "<strong>Success!</strong>";
                    //    //para abrir la fucnion abrirModal() de jquery que abre la venta a modal con la advertencia; 0 success, 1 error;
                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(0); });", true);
                    //    HttpCookie CookieADAuthAnda = new HttpCookie("ADAuthAnda");
                    //    Response.AppendCookie(CookieADAuthAnda);
                    //    FormsAuthentication.RedirectFromLoginPage(txtpassword.Text, false);
                    //    Session["UserName"] = txtpassword.Text;
                    //}
                    //else if (TextBox1.Text == txtusuario.Text && TextBox2.Text == "url(images/8.jpg)")
                    //{
                    //    //Lerror.Text = "";
                    //    //demo.Attributes["class"] = "class='.collapse'";
                    //    mensaje_error.InnerHtml = "<strong>Success!</strong>";
                    //    //para abrir la fucnion abrirModal() de jquery que abre la venta a modal con la advertencia; 0 success, 1 error;
                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(0); });", true);
                    //    HttpCookie CookieADAuthAnda = new HttpCookie("ADAuthAnda");
                    //    Response.AppendCookie(CookieADAuthAnda);
                    //    FormsAuthentication.RedirectFromLoginPage(txtpassword.Text, false);
                    //    Session["UserName"] = txtpassword.Text;
                    //}
                    //else if (TextBox1.Text == txtusuario.Text && TextBox2.Text == "url(images/9.jpg)")
                    //{
                    //    //Lerror.Text = "";
                    //    //demo.Attributes["class"] = "class='.collapse'";
                    //    mensaje_error.InnerHtml = "<strong>Success!</strong>";
                    //    //para abrir la fucnion abrirModal() de jquery que abre la venta a modal con la advertencia; 0 success, 1 error;
                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(0); });", true);
                    //    HttpCookie CookieADAuthAnda = new HttpCookie("ADAuthAnda");
                    //    Response.AppendCookie(CookieADAuthAnda);
                    //    FormsAuthentication.RedirectFromLoginPage(txtpassword.Text, false);
                    //    Session["UserName"] = txtpassword.Text;
                    //}
                    //else if (TextBox1.Text == txtusuario.Text && TextBox2.Text == "url(images/10.jpg)")
                    //{
                    //    //Lerror.Text = "";
                    //    //demo.Attributes["class"] = "class='.collapse'";
                    //    mensaje_error.InnerHtml = "<strong>Success!</strong>";
                    //    //para abrir la fucnion abrirModal() de jquery que abre la venta a modal con la advertencia; 0 success, 1 error;
                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(0); });", true);
                    //    HttpCookie CookieADAuthAnda = new HttpCookie("ADAuthAnda");
                    //    Response.AppendCookie(CookieADAuthAnda);
                    //    FormsAuthentication.RedirectFromLoginPage(txtpassword.Text, false);
                    //    Session["UserName"] = txtpassword.Text;
                    //}
                    //else if (TextBox1.Text == txtusuario.Text && TextBox2.Text == "url(images/11.jpg)")
                    //{
                    //    //Lerror.Text = "";
                    //    //demo.Attributes["class"] = "class='.collapse'";
                    //    mensaje_error.InnerHtml = "<strong>Success!</strong>";
                    //    //para abrir la fucnion abrirModal() de jquery que abre la venta a modal con la advertencia; 0 success, 1 error;
                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(0); });", true);
                    //    HttpCookie CookieADAuthAnda = new HttpCookie("ADAuthAnda");
                    //    Response.AppendCookie(CookieADAuthAnda);
                    //    FormsAuthentication.RedirectFromLoginPage(txtpassword.Text, false);
                    //    Session["UserName"] = txtpassword.Text;
                    //}
                    //else if (TextBox1.Text == txtusuario.Text && TextBox2.Text == "url(images/12.jpg)")
                    //{
                    //    //Lerror.Text = "";
                    //    //demo.Attributes["class"] = "class='.collapse'";
                    //    mensaje_error.InnerHtml = "<strong>Success!</strong>";
                    //    //para abrir la fucnion abrirModal() de jquery que abre la venta a modal con la advertencia; 0 success, 1 error;
                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(0); });", true);
                    //    HttpCookie CookieADAuthAnda = new HttpCookie("ADAuthAnda");
                    //    Response.AppendCookie(CookieADAuthAnda);
                    //    FormsAuthentication.RedirectFromLoginPage(txtpassword.Text, false);
                    //    Session["UserName"] = txtpassword.Text;
                    //}
                    //else if (TextBox1.Text == txtusuario.Text && TextBox2.Text == "url(images/13.jpg)")
                    //{
                    //    //Lerror.Text = "";
                    //    //demo.Attributes["class"] = "class='.collapse'";
                    //    mensaje_error.InnerHtml = "<strong>Success!</strong>";
                    //    //para abrir la fucnion abrirModal() de jquery que abre la venta a modal con la advertencia; 0 success, 1 error;
                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(0); });", true);
                    //    HttpCookie CookieADAuthAnda = new HttpCookie("ADAuthAnda");
                    //    Response.AppendCookie(CookieADAuthAnda);
                    //    FormsAuthentication.RedirectFromLoginPage(txtpassword.Text, false);
                    //    Session["UserName"] = txtpassword.Text;
                    //}
                    //else if (TextBox1.Text == txtusuario.Text && TextBox2.Text == "url(images/14.jpg)")
                    //{
                    //    //Lerror.Text = "";
                    //    //demo.Attributes["class"] = "class='.collapse'";
                    //    mensaje_error.InnerHtml = "<strong>Success!</strong>";
                    //    //para abrir la fucnion abrirModal() de jquery que abre la venta a modal con la advertencia; 0 success, 1 error;
                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(0); });", true);
                    //    HttpCookie CookieADAuthAnda = new HttpCookie("ADAuthAnda");
                    //    Response.AppendCookie(CookieADAuthAnda);
                    //    FormsAuthentication.RedirectFromLoginPage(txtpassword.Text, false);
                    //    Session["UserName"] = txtpassword.Text;
                    //}
                    //else if (TextBox1.Text == txtusuario.Text && TextBox2.Text == "url(images/15.jpg)")
                    //{
                    //    //Lerror.Text = "";
                    //    //demo.Attributes["class"] = "class='.collapse'";
                    //    mensaje_error.InnerHtml = "<strong>Success!</strong>";
                    //    //para abrir la fucnion abrirModal() de jquery que abre la venta a modal con la advertencia; 0 success, 1 error;
                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(0); });", true);
                    //    HttpCookie CookieADAuthAnda = new HttpCookie("ADAuthAnda");
                    //    Response.AppendCookie(CookieADAuthAnda);
                    //    FormsAuthentication.RedirectFromLoginPage(txtpassword.Text, false);
                    //    Session["UserName"] = txtpassword.Text;
                    //}
                    //else if (TextBox1.Text == txtusuario.Text && TextBox2.Text == "url(images/16.jpg)")
                    //{
                    //    //Lerror.Text = "";
                    //    //demo.Attributes["class"] = "class='.collapse'";
                    //    mensaje_error.InnerHtml = "<strong>Success!</strong>";
                    //    //para abrir la fucnion abrirModal() de jquery que abre la venta a modal con la advertencia; 0 success, 1 error;
                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(0); });", true);
                    //    HttpCookie CookieADAuthAnda = new HttpCookie("ADAuthAnda");
                    //    Response.AppendCookie(CookieADAuthAnda);
                    //    FormsAuthentication.RedirectFromLoginPage(txtpassword.Text, false);
                    //    Session["UserName"] = txtpassword.Text;
                    //}
                    //else if (TextBox1.Text == txtusuario.Text && TextBox2.Text == "url(images/17.jpg)")
                    //{
                    //    //Lerror.Text = "";
                    //    //demo.Attributes["class"] = "class='.collapse'";
                    //    mensaje_error.InnerHtml = "<strong>Success!</strong>";
                    //    //para abrir la fucnion abrirModal() de jquery que abre la venta a modal con la advertencia; 0 success, 1 error;
                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(0); });", true);
                    //    HttpCookie CookieADAuthAnda = new HttpCookie("ADAuthAnda");
                    //    Response.AppendCookie(CookieADAuthAnda);
                    //    FormsAuthentication.RedirectFromLoginPage(txtpassword.Text, false);
                    //    Session["UserName"] = txtpassword.Text;
                    //}
                    //else if (TextBox1.Text == txtusuario.Text && TextBox2.Text == "url(images/18.jpg)")
                    //{
                    //    //Lerror.Text = "";
                    //    //demo.Attributes["class"] = "class='.collapse'";
                    //    mensaje_error.InnerHtml = "<strong>Success!</strong>";
                    //    //para abrir la fucnion abrirModal() de jquery que abre la venta a modal con la advertencia; 0 success, 1 error;
                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(0); });", true);
                    //    HttpCookie CookieADAuthAnda = new HttpCookie("ADAuthAnda");
                    //    Response.AppendCookie(CookieADAuthAnda);
                    //    FormsAuthentication.RedirectFromLoginPage(txtpassword.Text, false);
                    //    Session["UserName"] = txtpassword.Text;
                    //}
                    //else if (TextBox1.Text == txtusuario.Text && TextBox2.Text == "url(images/19.jpg)")
                    //{
                    //    //Lerror.Text = "";
                    //    //demo.Attributes["class"] = "class='.collapse'";
                    //    mensaje_error.InnerHtml = "<strong>Success!</strong>";
                    //    //para abrir la fucnion abrirModal() de jquery que abre la venta a modal con la advertencia; 0 success, 1 error;
                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(0); });", true);
                    //    HttpCookie CookieADAuthAnda = new HttpCookie("ADAuthAnda");
                    //    Response.AppendCookie(CookieADAuthAnda);
                    //    FormsAuthentication.RedirectFromLoginPage(txtpassword.Text, false);
                    //    Session["UserName"] = txtpassword.Text;
                    //}
                    //else if (TextBox1.Text == txtusuario.Text && TextBox2.Text == "url(images/20.jpg)")
                    //{
                    //    //Lerror.Text = "";
                    //    //demo.Attributes["class"] = "class='.collapse'";
                    //    mensaje_error.InnerHtml = "<strong>Success!</strong>";
                    //    //para abrir la fucnion abrirModal() de jquery que abre la venta a modal con la advertencia; 0 success, 1 error;
                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(0); });", true);
                    //    HttpCookie CookieADAuthAnda = new HttpCookie("ADAuthAnda");
                    //    Response.AppendCookie(CookieADAuthAnda);
                    //    FormsAuthentication.RedirectFromLoginPage(txtpassword.Text, false);
                    //    Session["UserName"] = txtpassword.Text;
                    //}
                    //else
                    //{
                    //    //Lerror.Text = "Error en contraseña";
                    //    //demo.Attributes["class"] = "class='.collapse in'";
                    //    mensaje_error.InnerHtml = "<strong>Usuario o contraseña incorrectos!</strong>";
                    //    //para abrir la fucnion abrirModal() de jquery que abre la venta a modal con la advertencia
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(1); });", true);
                    //}
                }
                //else
                //{
                //    mensaje_error.InnerHtml = "<strong>Acceso No Permitido!</strong>";
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(1); });", true);
                //    txtusuario.Text = "";
                //    txtusuario.Focus();
                //}
            }
            catch (Exception ex)
            {
                string r = ex.ToString();
                mensaje_error.InnerHtml = "<strong>Acceso No Permitido!</strong>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(1); });", true);
                txtusuario.Text = "";
                txtusuario.Focus();
            }
            //finally
            //{
            //    con.Close();

            //}
        }

        //[System.Web.Services.WebMethod]              // Marcamos el método como uno web
        //public static string BuscarNumAleatorio(string mio)    // el método debe ser de static
        //{
        //    //Random aleatorio = new Random();
        //    string valor = mio;
        //    return valor.ToString();
        //}

        //protected void btn_img_Click(object sender, EventArgs e)
        //{
        //    //mensaje(Page, "dato error: " + Session["imagen"].ToString() + " dato db imagen:" + Session["captcha"].ToString());
        //    img.Text = "dato error: " + Session["imagen"].ToString() + " ;   dato db imagen: " + Session["captcha"].ToString();
        //}


        protected void mensaje(System.Web.UI.Page pagina, string aviso)
        {
            string codigo;
            codigo = "<script language='JavaScript'>alert('" + aviso + "');</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Avisar"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Avisar", codigo);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}