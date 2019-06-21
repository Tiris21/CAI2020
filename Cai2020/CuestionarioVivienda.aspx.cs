using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;
using System.Xml;

namespace Cai2020
{
    public partial class CuestionarioVivienda : System.Web.UI.Page
    {
        //public static int cuenta;
        //public static int op;
        public static int[] regreso = new int[21];
        #region web Services GetContent
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string GetContent(string contextKey)
        {
            //return "<strong>" + contextKey + "</strong>";
            return "";
        }
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string GetContent2(string contextKey)
        {
            //return "<strong>" + contextKey + "</strong>";
            return "";
        }
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string GetContent3(string contextKey)
        {
            //return "<strong>" + contextKey + "</strong>";
            return "";
        }
        #endregion        
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (HttpContext.Current.Session["testigo"].ToString() == "1")
            //{
            //    Response.Redirect("Index.aspx");
            //}
            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["testigo"].ToString() == "1")
                {
                    Response.Redirect("Index.aspx");
                }
                if (HttpContext.Current.Session["qr_viv"] == null)
                {
                    Response.Redirect("Index.aspx");
                }
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ExpiresAbsolute = DateTime.Now.AddMonths(-1);
                //cuenta = 0;
                HttpContext.Current.Session["cuenta"] = "0";
                //op = 0;
                HttpContext.Current.Session["op"] = "0";
                //HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                //regreso[0] = 0;
                int j = 0;
                foreach (int i in regreso)
                {
                    regreso[j] = 0;
                    j++;
                }
                RadioButtonList1.Items[0].Text = "";
                RadioButtonList1.Items[1].Text = "";
                RadioButtonList2.Items[0].Text = "";
                RadioButtonList2.Items[1].Text = "";
                RadioButtonList3.Items[0].Text = "";
                RadioButtonList3.Items[1].Text = "";
                //ayuda01a.Attributes["data-content"] = leer_xml(Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString()));
                ayuda01a.Attributes["data-content"] = leer_xml(0);
                //Button1.Attributes["data-content"] = leer_xml(Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString()));
                Guardar(6);
                string oradb = ConfigurationManager.AppSettings["cai2020"];
                OracleConnection conn = new OracleConnection(); // C#
                conn.ConnectionString = oradb.ToString();
                try
                {
                    conn.Open();
                    OracleCommand cmd2 = new OracleCommand();
                    cmd2.Connection = conn;
                    OracleParameter myParam = cmd2.CreateParameter();
                    myParam.OracleDbType = OracleDbType.NVarchar2;
                    myParam.Value = Session["Id_inm"].ToString();
                    myParam.ParameterName = "inm";
                    cmd2.Parameters.Add(myParam);
                    cmd2.CommandText = "SELECT A.ID_INM, A.NOMVIAL, A.NUM_EXT, A.NUM_INT, B.NOM_MUN, C.DESCRIP, D.NOM_LOC FROM CAP_INT_TR_INMUEBLE A LEFT JOIN CAP_INT_TC_MUNICIPIO_2010 B ON A.MUN = B.CVE_MUN AND A.ENT = B.CVE_ENT LEFT JOIN CAP_INT_TC_ENTIDAD C ON A.ENT = C.ENT LEFT JOIN CAP_INT_TC_LOC_HAB_2010 D ON A.MUN = D.CVE_MUN AND A.ENT = D.CVE_ENT AND A.LOC = D.CVE_LOC where A.ID_INM = :inm";
                    cmd2.CommandType = CommandType.Text;
                    OracleDataReader dr2 = cmd2.ExecuteReader();
                    if (dr2.Read())
                    {
                        lb_calle.Text = dr2["NOMVIAL"].ToString().ToUpper();
                        lb_numext.Text = dr2["NUM_EXT"].ToString().ToUpper();
                        lb_numint.Text = dr2["NUM_INT"].ToString().ToUpper();
                        //lb_colonia.Text = dr2["USUARIO"].ToString();
                        lb_localidad.Text = dr2["NOM_LOC"].ToString().ToUpper();
                        lb_municipio.Text = dr2["NOM_MUN"].ToString().ToUpper();
                        lb_entidad.Text = dr2["DESCRIP"].ToString().ToUpper();
                        tb_calle.Text = dr2["NOMVIAL"].ToString().ToUpper();
                        tb_numext.Text = dr2["NUM_EXT"].ToString().ToUpper();
                        tb_numint.Text = dr2["NUM_INT"].ToString().ToUpper();
                        //lb_colonia.Text = dr2["USUARIO"].ToString();
                        tb_localidad.Text = dr2["NOM_LOC"].ToString().ToUpper();
                        tb_municipio.Text = dr2["NOM_MUN"].ToString().ToUpper();
                        tb_entidad.Text = dr2["DESCRIP"].ToString().ToUpper();
                    }
                    dr2.Dispose();
                    cmd2.Dispose();
                    //EVALUAR SI YA SE TIENEN REGISTROS GUARDADOS
                    OracleCommand cmd3 = new OracleCommand();
                    cmd3.Connection = conn;
                    OracleParameter myParam3 = cmd3.CreateParameter();
                    myParam3.OracleDbType = OracleDbType.NVarchar2;
                    myParam3.Value = HttpContext.Current.Session["qr_viv"].ToString();
                    myParam3.ParameterName = "qr";
                    cmd3.Parameters.Add(myParam3);
                    cmd3.CommandText = "SELECT QR_VIV FROM CAP_INT_TR_VIVIENDA where QR_VIV = :qr";
                    cmd3.CommandType = CommandType.Text;
                    OracleDataReader dr3 = cmd3.ExecuteReader();
                    if (dr3.Read())
                    {
                        Response.Redirect("CuestionarioPersona.aspx");
                    }
                    dr3.Dispose();
                    cmd3.Dispose();
                }
                catch (Exception e1)
                {
                    HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                }
                finally
                {
                    conn.Dispose();
                }
                Avance_barra(0);

            }
            if (HttpContext.Current.Session["cuenta"].ToString() == "0")
            {
                //abrecom2(Page);
                Image100.ImageUrl = "Images/Clase_De_Vivienda.jpg";
                abrecom4a(Page);
                abrecom3e(Page);
                //cierracom100(Page);
                //abrecom4q2(Page);
            }
            //mensaje(Page, "abrir ventana");
        }

        protected void Transfer_(string url)
        {
            foreach (string key_ in ViewState.Keys)
            {
                if (Session[key_] == null)
                {
                    Session.Add(key_, ViewState[key_]);
                }
                else
                    Session[key_] = ViewState[key_];
            }

            Server.Transfer(url);
        }
        void Avance_barra(int inicio)
        {
                double porcentaje=0;
                int total_preg = 15;
                //cuenta = Int32.Parse(Session["pregunta_act"].ToString()) + 1;
                porcentaje = Math.Round((1.0/ total_preg) *100,2);
                porcentaje = (porcentaje) * (1 + Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString())); //5 = (1 / int total_preg)*100
                barra.Attributes["aria-valuenow"] = porcentaje.ToString();
                barra.Attributes["style"] = "width:" + porcentaje + "%";
                avance.Text = "Pregunta: " + (1 + Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString())) + " de " + total_preg;
                ////Session["pregunta_act"] = (1+ cuenta);
                //if (porcentaje >= 100)
                //{
                //    barra.InnerHtml = "Completo!";
                //}
                //else
                //{
                //    barra.InnerHtml = "";
                //}
                if (inicio > 0)
                {
                    barra1.Attributes["aria-valuenow"] = porcentaje.ToString();
                    barra1.Attributes["style"] = "width:" + porcentaje + "%";
                    avance1.Text = "Pregunta: " + (1 + Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString())) + " de " + total_preg;
                    ////Session["pregunta_act"] = cuenta;
                    //if (porcentaje >= 100)
                    //{
                    //    barra1.InnerHtml = "Completo!";
                    //}
                    //else
                    //{
                    //    barra1.InnerHtml = "";
                    //}
                }

        }
        

        protected string leer_xml(int numAyuda)
        {
            string txtAyuda = "";//"<div><b>Ejemplo usando un div interno</b> - content</div>";
            //XmlTextReader reader = new XmlTextReader("ayudas.xml");
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(MapPath("~/App_data/ayudas.xml"));

                XmlNodeList xAyudas = xDoc.GetElementsByTagName("Ayudas");
                XmlNodeList xLista = ((XmlElement)xAyudas[0]).GetElementsByTagName("ayuda");

                foreach (XmlElement nodo in xLista)
                {
                    if (Int32.Parse(nodo.GetAttribute("id")) == numAyuda)
                    {
                        //txtAyuda = nodo.GetAttribute("descrip");
                        txtAyuda = nodo.InnerText;  
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                string r = ex.ToString();
            }
            return txtAyuda;
        }
        protected void mensaje(System.Web.UI.Page pagina, string aviso)
        {
            //mensaje_error.InnerHtml = "<strong>" + aviso + "</strong>";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { openModal(); });", true);
            
            string codigo;
            codigo = "<script language='JavaScript'>alert('" + aviso + "');</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Avisar"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Avisar", codigo);
            }
        }
        protected void cierracom100(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec100');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com100"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com100", codigo);
            }
        }
        protected void cierracom2(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec002');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com2"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com2", codigo);
            }
        }
        protected void cierracom2a(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec002a');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com2a"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com2a", codigo);
            }
        }
        protected void cierracom3(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec003');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com3"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com3", codigo);
            }
        }
        protected void cierracom4(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4", codigo);
            }
        }
        protected void cierracom4q(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004q');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4q"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4q", codigo);
            }
        }
        protected void cierracom4q2(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004q2');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4q2"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4q2", codigo);
            }
        }
        protected void cierracom4b(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004b');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4b"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4b", codigo);
            }
        }
        protected void cierracom4c(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004C');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4c"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4c", codigo);
            }
        }
        protected void cierracom4r(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004R');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4r"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4r", codigo);
            }
        }
        protected void cierracom4s(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004S');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4s"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4s", codigo);
            }
        }
        protected void cierracom4s1(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004S1');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4s1"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4s1", codigo);
            }
        }
        protected void cierracom4s2(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004S2');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4s2"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4s2", codigo);
            }
        }
        protected void cierracom5(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec005');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com5"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com5", codigo);
            }
        }

        protected void cierracom6(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec006');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com6"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com6", codigo);
            }
        }

        protected void cierracom7(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec007');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com7"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com7", codigo);
            }
        }

        protected void cierracom8(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec008');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com8"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com8", codigo);
            }
        }

        protected void cierracom9(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec009');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com9"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com9", codigo);
            }
        }

        protected void cierracom10(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec010');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com10"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com10", codigo);
            }
        }

        protected void cierracom11(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec011');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com11"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com11", codigo);
            }
        }

        protected void cierracom12(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec012');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com12"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com12", codigo);
            }
        }

        protected void cierracom13(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec013');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com13"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com13", codigo);
            }
        }

        protected void cierracom14(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec014');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com14"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com14", codigo);
            }
        }

        protected void cierracom15(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec015');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com15"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com15", codigo);
            }
        }

        protected void cierracom16(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec016');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com16"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com16", codigo);
            }
        }

        protected void cierracom17(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec017');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com17"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com17", codigo);
            }
        }

        protected void cierracom18(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec018');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com18"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com18", codigo);
            }
        }

        protected void cierrabot1(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('MainContent_atras01');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close bot1"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close bot1", codigo);
            }
        }
        protected void cierracom3a(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec003A');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com3a"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com3a", codigo);
            }
        }
        protected void cierracom3b(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec003B');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com3b"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com3b", codigo);
            }
        }
        protected void cierracom3c(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec003B');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com3c"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com3c", codigo);
            }
        }
        protected void cierracom3d(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec003D');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com3d"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com3d", codigo);
            }
        }
        protected void cierracom3e(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec003E');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com3e"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com3e", codigo);
            }
        }
        protected void cierracom3f(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec003F');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com3f"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com3f", codigo);
            }
        }
        protected void cierracom4a(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004A');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4a"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4a", codigo);
            }
        }
        protected void abrecom100(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec100');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com100"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com100", codigo);
            }
        }
        protected void abrecom2(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec002');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com2"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com2", codigo);
            }
        }
        protected void abrecom2a(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec002a');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com2a"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com2a", codigo);
            }
        }
        protected void abrecom3(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec003');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com3"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com3", codigo);
            }
        }
        protected void abrecom4(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4", codigo);
            }
        }
        protected void abrecom4b(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004B');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4b"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4b", codigo);
            }
        }
        protected void abrecom4q(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004q');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4q"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4q", codigo);
            }
        }
        protected void abrecom4q2(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004q2');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4q2"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4q2", codigo);
            }
        }
        protected void abrecom4r(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004R');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4r"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4r", codigo);
            }
        }
        protected void abrecom4s(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004S');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4s"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4s", codigo);
            }
        }
        protected void abrecom4s1(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004S1');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4s1"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4s1", codigo);
            }
        }
        protected void abrecom4s2(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004S2');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4s2"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4s2", codigo);
            }
        }
        protected void abrecom5(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec005');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com5"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com5", codigo);
            }
        }

        protected void abrecom6(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec006');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com6"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com6", codigo);
            }
        }

        protected void abrecom7(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec007');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com7"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com7", codigo);
            }
        }

        protected void abrecom8(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec008');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com8"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com8", codigo);
            }
        }

        protected void abrecom9(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec009');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com9"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com9", codigo);
            }
        }

        protected void abrecom10(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec010');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com10"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com10", codigo);
            }
        }

        protected void abrecom11(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec011');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com11"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com11", codigo);
            }
        }

        protected void abrecom12(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec012');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com12"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com12", codigo);
            }
        }

        protected void abrecom13(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec013');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com13"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com13", codigo);
            }
        }

        protected void abrecom14(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec014');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com14"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com14", codigo);
            }
        }

        protected void abrecom15(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec015');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com15"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com15", codigo);
            }
        }

        protected void abrecom16(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec016');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com16"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com16", codigo);
            }
        }

        protected void abrecom17(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec017');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com17"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com17", codigo);
            }
        }

        protected void abrecom18(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec018');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com18"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com18", codigo);
            }
        }

        protected void abrebot1(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('MainContent_atras01');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open bot1"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open bot1", codigo);
            }
        }

        protected void abrecom3a(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec003A');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com3a"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com3a", codigo);
            }
        }

        protected void abrecom3b(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec003B');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com3b"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com3b", codigo);
            }
        }

        protected void abrecom3c(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec003C');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com3c"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com3c", codigo);
            }
        }

        protected void abrecom3d(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec003D');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com3d"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com3d", codigo);
            }
        }

        protected void abrecom3e(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec003E');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com3e"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com3e", codigo);
            }
        }

        protected void abrecom3f(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec003F');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com3f"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com3f", codigo);
            }
        }

        protected void abrecom4a(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004A');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4a"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4a", codigo);
            }
        }
        protected void abrecom4c(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004C');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4c"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4c", codigo);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //cierracom2(Page);
            //cierracom3(Page);
            cierracom4(Page);
            cierracom5(Page);
            cierracom6(Page);
            cierracom7(Page);
            cierracom8(Page);
            cierracom9(Page);
            cierracom10(Page);
            cierracom11(Page);
            cierracom12(Page);
            cierracom13(Page);
            cierracom14(Page);
            cierracom15(Page);
            cierracom16(Page);
            cierracom17(Page);
            cierracom18(Page);
            abrecom2(Page);
            abrecom3(Page);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //cierracom2(Page);
            //cierracom3(Page);
            cierracom4(Page);
            cierracom5(Page);
            cierracom6(Page);
            cierracom7(Page);
            cierracom8(Page);
            cierracom9(Page);
            cierracom10(Page);
            cierracom11(Page);
            cierracom12(Page);
            cierracom13(Page);
            cierracom14(Page);
            cierracom15(Page);
            cierracom16(Page);
            cierracom17(Page);
            cierracom18(Page);
            abrecom2(Page);
            abrecom3(Page);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            cierracom2(Page);
            cierracom3(Page);
            cierracom4(Page);
            cierracom5(Page);
            cierracom6(Page);
            cierracom7(Page);
            cierracom8(Page);
            cierracom9(Page);
            cierracom10(Page);
            cierracom11(Page);
            cierracom12(Page);
            cierracom13(Page);
            cierracom14(Page);
            cierracom15(Page);
            cierracom16(Page);
            cierracom17(Page);
            cierracom18(Page);
            abrecom4(Page);
            abrecom5(Page);
        }

        protected void atras01_Click(object sender, EventArgs e)
        {
            int cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            cuenta -= 1;
            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            //if (cuenta == 2 && (radioZ12.Checked == true || radioZ14.Checked == true))
            cierracom4q2(Page);
            ayuda01a.Attributes["data-content"] = leer_xml(4);
            abrecom100(Page);
            //if (cuenta == 2 && radioZ14.Checked == true)
            //{
            //    cuenta = 1;
            //    HttpContext.Current.Session["cuenta"] = cuenta.ToString();
            //    cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            //}
            switch (cuenta)
            {
                case 1:
                    if (RadioButtonList2.SelectedIndex == 1 && regreso[0] == 2)
                    {
                        cuenta = 0;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        ayuda01a.Attributes["data-content"] = leer_xml(0);
                        cierracom2(Page);
                        cierracom3(Page);
                        cierracom3a(Page);
                        cierracom3b(Page);
                        cierracom3c(Page);
                        cierracom3d(Page);
                        cierracom3e(Page);
                        cierracom3f(Page);
                        cierracom4(Page);
                        cierracom4a(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom7(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom14(Page);
                        cierracom15(Page);
                        cierracom16(Page);
                        cierracom17(Page);
                        cierracom18(Page);
                        abrecom4a(Page);
                        abrecom3e(Page);
                        cierrabot1(Page);
                    }
                    else
                    {
                        cuenta = 1;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        ayuda01a.Attributes["data-content"] = leer_xml(1);
                        cierracom2(Page);
                        cierracom3(Page);
                        cierracom3a(Page);
                        cierracom3b(Page);
                        cierracom3c(Page);
                        cierracom3d(Page);
                        cierracom3e(Page);
                        cierracom3f(Page);
                        cierracom4(Page);
                        cierracom4a(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom7(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom14(Page);
                        cierracom15(Page);
                        cierracom16(Page);
                        cierracom17(Page);
                        cierracom18(Page);
                        abrecom4a(Page);
                        abrecom3c(Page);
                        abrebot1(Page);
                        tb_I031.BackColor = System.Drawing.Color.LightSteelBlue;
                        tb_I031.Focus();
                    }
                    break;
                case 2:
                    cuenta = 2;
                    HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                    cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                    ayuda01a.Attributes["data-content"] = leer_xml(2);
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom3a(Page);
                    cierracom3b(Page);
                    cierracom3c(Page);
                    cierracom3d(Page);
                    cierracom3e(Page);
                    cierracom3f(Page);
                    cierracom4(Page);
                    cierracom4a(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom15(Page);
                    cierracom16(Page);
                    cierracom17(Page);
                    cierracom18(Page);
                    abrecom4a(Page);
                    abrecom3(Page);
                    abrebot1(Page);
                    break;
                case 3:
                    if (RadioButtonList2.SelectedIndex == 1 && regreso[0] == 2)
                    {
                        cuenta = 3;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        ayuda01a.Attributes["data-content"] = leer_xml(3);
                        cierracom2(Page);
                        cierracom3(Page);
                        cierracom3a(Page);
                        cierracom3b(Page);
                        cierracom3c(Page);
                        cierracom3d(Page);
                        cierracom3e(Page);
                        cierracom3f(Page);
                        cierracom4(Page);
                        cierracom4a(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom7(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom14(Page);
                        cierracom15(Page);
                        cierracom16(Page);
                        cierracom17(Page);
                        cierracom18(Page);
                        abrecom4a(Page);
                        abrecom3f(Page);
                        abrebot1(Page);
                    }
                    else
                    {
                        cuenta = 2;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        ayuda01a.Attributes["data-content"] = leer_xml(2);
                        cierracom2(Page);
                        cierracom3(Page);
                        cierracom3a(Page);
                        cierracom3b(Page);
                        cierracom3c(Page);
                        cierracom3d(Page);
                        cierracom3e(Page);
                        cierracom3f(Page);
                        cierracom4(Page);
                        cierracom4a(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom7(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom14(Page);
                        cierracom15(Page);
                        cierracom16(Page);
                        cierracom17(Page);
                        cierracom18(Page);
                        abrecom4a(Page);
                        abrecom3(Page);
                        abrebot1(Page);
                    }
                    break;
                case 4:
                    cuenta = 4;
                    HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                    cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                    Button1.Attributes["data-content"] = leer_xml(4);
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom3a(Page);
                    cierracom3b(Page);
                    cierracom3c(Page);
                    cierracom3d(Page);
                    cierracom3e(Page);
                    cierracom3f(Page);
                    cierracom4(Page);
                    cierracom4a(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom15(Page);
                    cierracom16(Page);
                    cierracom17(Page);
                    cierracom18(Page);
                    abrecom4(Page);
                    abrecom5(Page);
                    abrebot1(Page);
                    break;
                case 5:
                    cuenta = 5;
                    HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                    cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                    Button1.Attributes["data-content"] = leer_xml(5);
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom3a(Page);
                    cierracom3b(Page);
                    cierracom3c(Page);
                    cierracom3d(Page);
                    cierracom3e(Page);
                    cierracom3f(Page);
                    cierracom4(Page);
                    cierracom4a(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom15(Page);
                    cierracom16(Page);
                    cierracom17(Page);
                    cierracom18(Page);
                    abrecom4(Page);
                    abrecom6(Page);
                    abrebot1(Page);
                    tb_Ie21.BackColor = System.Drawing.Color.LightSteelBlue;
                    tb_Ie21.Focus();
                    break;
                case 6:
                    cuenta = 6;
                    HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                    cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                    Button1.Attributes["data-content"] = leer_xml(6);
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom3a(Page);
                    cierracom3b(Page);
                    cierracom3c(Page);
                    cierracom3d(Page);
                    cierracom3e(Page);
                    cierracom3f(Page);
                    cierracom4(Page);
                    cierracom4a(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom15(Page);
                    cierracom16(Page);
                    cierracom17(Page);
                    cierracom18(Page);
                    abrecom4(Page);
                    abrecom7(Page);
                    abrebot1(Page);
                    tb_Ie31.BackColor = System.Drawing.Color.LightSteelBlue;
                    tb_Ie31.Focus();
                    break;
                case 7:
                    cuenta = 7;
                    HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                    cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                    Button1.Attributes["data-content"] = leer_xml(7);
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom3a(Page);
                    cierracom3b(Page);
                    cierracom3c(Page);
                    cierracom3d(Page);
                    cierracom3e(Page);
                    cierracom3f(Page);
                    cierracom4(Page);
                    cierracom4a(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom15(Page);
                    cierracom16(Page);
                    cierracom17(Page);
                    cierracom18(Page);
                    abrecom4(Page);
                    abrecom8(Page);
                    abrebot1(Page);
                    break;
                case 8:
                    cuenta = 8;
                    HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                    cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                    Button1.Attributes["data-content"] = leer_xml(8);
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom3a(Page);
                    cierracom3b(Page);
                    cierracom3c(Page);
                    cierracom3d(Page);
                    cierracom3e(Page);
                    cierracom3f(Page);
                    cierracom4(Page);
                    cierracom4a(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom15(Page);
                    cierracom16(Page);
                    cierracom17(Page);
                    cierracom18(Page);
                    abrecom4(Page);
                    abrecom9(Page);
                    abrebot1(Page);
                    break;
                case 9:
                    if (radioC3.Checked == true)
                    {
                        cuenta = 8;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        Button1.Attributes["data-content"] = leer_xml(8);
                        cierracom2(Page);
                        cierracom3(Page);
                        cierracom3a(Page);
                        cierracom3b(Page);
                        cierracom3c(Page);
                        cierracom3d(Page);
                        cierracom3e(Page);
                        cierracom3f(Page);
                        cierracom4(Page);
                        cierracom4a(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom7(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom14(Page);
                        cierracom15(Page);
                        cierracom16(Page);
                        cierracom17(Page);
                        cierracom18(Page);
                        abrecom4(Page);
                        abrecom9(Page);
                        abrebot1(Page);
                    }
                    else
                    {
                        cuenta = 9;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        Button1.Attributes["data-content"] = leer_xml(9);
                        cierracom2(Page);
                        cierracom3(Page);
                        cierracom3a(Page);
                        cierracom3b(Page);
                        cierracom3c(Page);
                        cierracom3d(Page);
                        cierracom3e(Page);
                        cierracom3f(Page);
                        cierracom4(Page);
                        cierracom4a(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom7(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom14(Page);
                        cierracom15(Page);
                        cierracom16(Page);
                        cierracom17(Page);
                        cierracom18(Page);
                        abrecom4(Page);
                        abrecom10(Page);
                        abrebot1(Page);
                    }
                    break;
                case 10:
                    if (radioC3.Checked == true)
                    {
                        cuenta = 10;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        Button1.Attributes["data-content"] = leer_xml(10);
                        cierracom2(Page);
                        cierracom3(Page);
                        cierracom3a(Page);
                        cierracom3b(Page);
                        cierracom3c(Page);
                        cierracom3d(Page);
                        cierracom3e(Page);
                        cierracom3f(Page);
                        cierracom4(Page);
                        cierracom4a(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom7(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom14(Page);
                        cierracom15(Page);
                        cierracom16(Page);
                        cierracom17(Page);
                        cierracom18(Page);
                        abrecom4(Page);
                        abrecom11(Page);
                        abrebot1(Page);
                    }
                    else
                    {
                        cuenta = 9;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        Button1.Attributes["data-content"] = leer_xml(9);
                        cierracom2(Page);
                        cierracom3(Page);
                        cierracom3a(Page);
                        cierracom3b(Page);
                        cierracom3c(Page);
                        cierracom3d(Page);
                        cierracom3e(Page);
                        cierracom3f(Page);
                        cierracom4(Page);
                        cierracom4a(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom7(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom14(Page);
                        cierracom15(Page);
                        cierracom16(Page);
                        cierracom17(Page);
                        cierracom18(Page);
                        abrecom4(Page);
                        abrecom10(Page);
                        abrebot1(Page);
                    }
                    break;
                case 11:
                    cuenta = 11;
                    HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                    cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                    Button1.Attributes["data-content"] = leer_xml(11);
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom3a(Page);
                    cierracom3b(Page);
                    cierracom3c(Page);
                    cierracom3d(Page);
                    cierracom3e(Page);
                    cierracom3f(Page);
                    cierracom4(Page);
                    cierracom4a(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom15(Page);
                    cierracom16(Page);
                    cierracom17(Page);
                    cierracom18(Page);
                    abrecom4(Page);
                    abrecom14(Page);
                    abrebot1(Page);
                    break;
                case 12:
                    if (radioG3.Checked != true)
                    {
                        cuenta = 12;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        Button1.Attributes["data-content"] = leer_xml(12);
                        cierracom2(Page);
                        cierracom3(Page);
                        cierracom3a(Page);
                        cierracom3b(Page);
                        cierracom3c(Page);
                        cierracom3d(Page);
                        cierracom3e(Page);
                        cierracom3f(Page);
                        cierracom4(Page);
                        cierracom4a(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom7(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom14(Page);
                        cierracom15(Page);
                        cierracom16(Page);
                        cierracom17(Page);
                        cierracom18(Page);
                        abrecom4(Page);
                        abrecom15(Page);
                        abrebot1(Page);
                    }
                    else
                    {
                        cuenta = 11;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        Button1.Attributes["data-content"] = leer_xml(11);
                        cierracom2(Page);
                        cierracom3(Page);
                        cierracom3a(Page);
                        cierracom3b(Page);
                        cierracom3c(Page);
                        cierracom3d(Page);
                        cierracom3e(Page);
                        cierracom3f(Page);
                        cierracom4(Page);
                        cierracom4a(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom7(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom14(Page);
                        cierracom15(Page);
                        cierracom16(Page);
                        cierracom17(Page);
                        cierracom18(Page);
                        abrecom4(Page);
                        abrecom14(Page);
                        abrebot1(Page);
                    }
                    break;
                case 13:
                    cuenta = 13;
                    HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                    cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                    Button1.Attributes["data-content"] = leer_xml(13);
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom3a(Page);
                    cierracom3b(Page);
                    cierracom3c(Page);
                    cierracom3d(Page);
                    cierracom3e(Page);
                    cierracom3f(Page);
                    cierracom4(Page);
                    cierracom4a(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom15(Page);
                    cierracom16(Page);
                    cierracom17(Page);
                    cierracom18(Page);
                    abrecom4(Page);
                    abrecom16(Page);
                    abrebot1(Page);
                    break;
                //case 14:
                //    cuenta = 14;
                //    HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                //    cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                //    cierracom2(Page);
                //    cierracom3(Page);
                //    cierracom3a(Page);
                //    cierracom3b(Page);
                //    cierracom3c(Page);
                //    cierracom3d(Page);
                //    cierracom3e(Page);
                //    cierracom3f(Page);
                //    cierracom4(Page);
                //    cierracom4a(Page);
                //    cierracom5(Page);
                //    cierracom6(Page);
                //    cierracom7(Page);
                //    cierracom8(Page);
                //    cierracom9(Page);
                //    cierracom10(Page);
                //    cierracom11(Page);
                //    cierracom12(Page);
                //    cierracom13(Page);
                //    cierracom14(Page);
                //    cierracom15(Page);
                //    cierracom16(Page);
                //    cierracom17(Page);
                //    cierracom18(Page);
                //    abrecom4(Page);
                //    abrecom17(Page);
                //    abrebot1(Page);
                //    break;
                case 14:
                    cuenta = 14;
                    HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                    cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                    Button1.Attributes["data-content"] = leer_xml(14);
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom3a(Page);
                    cierracom3b(Page);
                    cierracom3c(Page);
                    cierracom3d(Page);
                    cierracom3e(Page);
                    cierracom3f(Page);
                    cierracom4(Page);
                    cierracom4a(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom15(Page);
                    cierracom16(Page);
                    cierracom17(Page);
                    cierracom18(Page);
                    abrecom4(Page);
                    abrecom18(Page);
                    abrebot1(Page);
                    break;
                default:
                    //cuenta = 14;
                    if (cuenta == -1)
                    {
                        cuenta = 14;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        Button1.Attributes["data-content"] = leer_xml(14);
                        cierracom2(Page);
                        cierracom3(Page);
                        cierracom3a(Page);
                        cierracom3b(Page);
                        cierracom3c(Page);
                        cierracom3d(Page);
                        cierracom3e(Page);
                        cierracom3f(Page);
                        cierracom4(Page);
                        cierracom4a(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom7(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom14(Page);
                        cierracom15(Page);
                        cierracom16(Page);
                        cierracom17(Page);
                        cierracom18(Page);
                        abrecom4(Page);
                        abrecom18(Page);
                        abrebot1(Page);
                    }
                    else
                    {
                        cuenta = 0;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        ayuda01a.Attributes["data-content"] = leer_xml(0);
                        cierracom2(Page);
                        cierracom3(Page);
                        cierracom3a(Page);
                        cierracom3b(Page);
                        cierracom3c(Page);
                        cierracom3d(Page);
                        cierracom3e(Page);
                        cierracom3f(Page);
                        cierracom4(Page);
                        cierracom4a(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom7(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom14(Page);
                        cierracom15(Page);
                        cierracom16(Page);
                        cierracom17(Page);
                        cierracom18(Page);
                        cierrabot1(Page);
                        abrecom4a(Page);
                        abrecom3e(Page);
                        break;
                    }
                    break;
            }
            //ayuda01a.Attributes["data-content"] = leer_xml(cuenta);
            //Button1.Attributes["data-content"] = leer_xml(cuenta);
            Avance_barra(1);
        }

        protected void ayuda01_Click(object sender, EventArgs e)
        {
            //cierracom2(Page);
            //cierracom3(Page);
            cierracom4(Page);
            cierracom5(Page);
            cierracom6(Page);
            cierracom7(Page);
            cierracom8(Page);
            cierracom9(Page);
            cierracom10(Page);
            cierracom11(Page);
            cierracom12(Page);
            cierracom13(Page);
            cierracom14(Page);
            cierracom15(Page);
            cierracom16(Page);
            cierracom17(Page);
            cierracom18(Page);
            abrecom2(Page);
            abrecom3(Page);
        }

        protected void adelante01_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["qr_viv"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            int cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            cuenta += 1;
            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            //cierracom4q2(Page);
            ayuda01a.Attributes["data-content"] = leer_xml(4);
            abrecom100(Page);
            Label10.Text = "No proporcionó respuesta a esta pregunta";
            if (RadioButtonList2.Items[0].Selected == false && RadioButtonList2.Items[1].Selected == false && regreso[0] == 0)
            {
                cuenta = 0;
                HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                regreso[0] = 0;
                ayuda01a.Attributes["data-content"] = leer_xml(0);
                programmaticModalPopup.Show();
                //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                //abrecom2(Page);
                abrecom4a(Page);
                abrecom3e(Page);
                cierrabot1(Page);
            }
            //else if (RadioButtonList1.SelectedIndex == 1 && HttpContext.Current.Session["op"].ToString() == "0")
            //{
            //    RadioButtonList1.SelectedIndex = 1;
            //    cuenta = 0;
            //    HttpContext.Current.Session["cuenta"] = cuenta.ToString();
            //    cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            //    HttpContext.Current.Session["op"] = "1";
            //    cierracom2(Page);
            //    cierracom3(Page);
            //    cierracom3a(Page);
            //    cierracom3b(Page);
            //    cierracom3c(Page);
            //    cierracom3d(Page);
            //    cierracom3e(Page);
            //    cierracom3f(Page);
            //    cierracom4(Page);
            //    //cierracom4a(Page);
            //    cierracom5(Page);
            //    cierracom6(Page);
            //    cierracom7(Page);
            //    cierracom8(Page);
            //    cierracom9(Page);
            //    cierracom10(Page);
            //    cierracom11(Page);
            //    cierracom12(Page);
            //    cierracom13(Page);
            //    cierracom14(Page);
            //    cierracom15(Page);
            //    cierracom16(Page);
            //    cierracom17(Page);
            //    cierracom18(Page);
            //    abrecom2a(Page);
            //    abrecom4a(Page);
            //    abrecom3a(Page);
            //    tb_calle.BackColor = System.Drawing.Color.LightSteelBlue;
            //    tb_calle.Focus();
            //    cierrabot1(Page);
            //    //}
            //}
            else if (RadioButtonList2.SelectedIndex == 1 && regreso[0] != 2)
            {
                cuenta = 2;
                regreso[0] = 2;
                ayuda01a.Attributes["data-content"] = leer_xml(2);
                HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                cierracom2(Page);
                cierracom3(Page);
                cierracom3a(Page);
                cierracom3b(Page);
                cierracom3c(Page);
                cierracom3d(Page);
                cierracom3e(Page);
                cierracom3f(Page);
                cierracom4(Page);
                //cierracom4a(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom7(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom14(Page);
                cierracom15(Page);
                cierracom16(Page);
                cierracom17(Page);
                cierracom18(Page);
                abrecom4a(Page);
                abrecom3(Page);
                abrebot1(Page);
                Avance_barra(1);
            }
            //else if (radioZ13.Checked == true || radioZ21.Checked == true || radioZ22.Checked == true)
            //{
            //    if (radioZ13.Checked == true)
            //    {
            //        cierracom2(Page);
            //        cierracom3(Page);
            //        cierracom3a(Page);
            //        cierracom3b(Page);
            //        cierracom3c(Page);
            //        cierracom3d(Page);
            //        cierracom3e(Page);
            //        cierracom3f(Page);
            //        cierracom4(Page);
            //        cierracom4a(Page);
            //        cierracom5(Page);
            //        cierracom6(Page);
            //        cierracom7(Page);
            //        cierracom8(Page);
            //        cierracom9(Page);
            //        cierracom10(Page);
            //        cierracom11(Page);
            //        cierracom12(Page);
            //        cierracom13(Page);
            //        cierracom14(Page);
            //        cierracom15(Page);
            //        cierracom16(Page);
            //        cierracom17(Page);
            //        cierracom18(Page);
            //        cierracom100(Page);
            //        //abrecom4a(Page);
            //        abrecom4r(Page);
            //        //abrecom3b(Page);
            //        cierrabot1(Page);
            //    }
            //}
            else
            {
                switch (cuenta)
                {
                    case 1:
                        if (RadioButtonList2.SelectedIndex == 0)
                        {
                            cuenta = 1;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            ayuda01a.Attributes["data-content"] = leer_xml(1);
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            //cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4a(Page);
                            abrecom3c(Page);
                            abrebot1(Page);
                            tb_I031.BackColor = System.Drawing.Color.LightSteelBlue;
                            tb_I031.Focus();
                        }
                        else
                        {
                            cuenta = 2;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            ayuda01a.Attributes["data-content"] = leer_xml(2);
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            //cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4a(Page);
                            abrecom3(Page);
                            abrebot1(Page);
                        }
                        break;
                    case 2:
                        if (tb_I031.Text == "" && regreso[1] == 0)
                        {
                            cuenta = 1;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            ayuda01a.Attributes["data-content"] = leer_xml(1);
                            regreso[1] = 1;
                            programmaticModalPopup.Show();
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4a(Page);
                            abrecom3c(Page);
                            abrebot1(Page);
                            tb_I031.BackColor = System.Drawing.Color.LightSteelBlue;
                            tb_I031.Focus();
                        }
                        else
                        {
                            cuenta = 2;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            ayuda01a.Attributes["data-content"] = leer_xml(2);
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            //cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4a(Page);
                            abrecom3(Page);
                            abrebot1(Page);
                        }
                        break;
                    case 3:
                        if (radioA1.Checked == false && radioA2.Checked == false && radioA3.Checked == false && radioA4.Checked == false && radioA5.Checked == false && radioA6.Checked == false && radioA7.Checked == false && regreso[2] == 0)
                        {
                            cuenta = 2;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            regreso[2] = 0;
                            ayuda01a.Attributes["data-content"] = leer_xml(2);
                            programmaticModalPopup.Show();
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            //cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4a(Page);
                            abrecom3(Page);
                            abrebot1(Page);
                        }
                        else if (RadioButtonList2.SelectedIndex == 1 && regreso[0] == 2)
                        {
                            if (radioA6.Checked == true)
                            {
                                HttpContext.Current.Session["testigo"] = "1";
                                Guardar(4);
                                cierracom100(Page);
                                Image1.ImageUrl = "Images/Cortinilla4.JPG";
                                programmaticModalPopup2.Show();
                                cierramodal(Page);
                            }
                            else if (radioA7.Checked == true)
                            {
                                HttpContext.Current.Session["testigo"] = "1";
                                Guardar(5);
                                cierracom100(Page);
                                Image1.ImageUrl = "Images/Cortinilla4.JPG";
                                programmaticModalPopup2.Show();
                                cierramodal(Page);
                            }
                            else
                            {
                                cuenta = 3;
                                HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                                cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                                ayuda01a.Attributes["data-content"] = leer_xml(3);
                                cierracom2(Page);
                                cierracom3(Page);
                                cierracom3a(Page);
                                cierracom3b(Page);
                                cierracom3c(Page);
                                cierracom3d(Page);
                                cierracom3e(Page);
                                cierracom3f(Page);
                                cierracom4(Page);
                                cierracom4a(Page);
                                cierracom5(Page);
                                cierracom6(Page);
                                cierracom7(Page);
                                cierracom8(Page);
                                cierracom9(Page);
                                cierracom10(Page);
                                cierracom11(Page);
                                cierracom12(Page);
                                cierracom13(Page);
                                cierracom14(Page);
                                cierracom15(Page);
                                cierracom16(Page);
                                cierracom17(Page);
                                cierracom18(Page);
                                abrecom4a(Page);
                                abrecom3f(Page);
                                abrebot1(Page);
                            }
                        }
                        else if (radioA7.Checked == true)
                        {
                            Guardar(8);
                            Response.Redirect("CuestionarioPersona.aspx");
                            //Transfer_("CuestionarioPersona.aspx");
                        }
                        else
                        {
                            cuenta = 3;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            ayuda01a.Attributes["data-content"] = leer_xml(3);
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            cierracom100(Page);
                            cierrabot1(Page);
                            abrecom4q2(Page);
                        }
                        break;
                    case 4:
                        if (radioZ21.Checked == false && radioZ22.Checked == false && regreso[3] == 0)
                        {
                            cuenta = 3;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            regreso[3] = 1;
                            ayuda01a.Attributes["data-content"] = leer_xml(3);
                            programmaticModalPopup.Show();
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4a(Page);
                            abrecom3f(Page);
                            abrebot1(Page);
                        }
                        else if (RadioButtonList2.SelectedIndex == 1 && regreso[0] == 2)
                        {
                            if (radioZ21.Checked == true)
                            {
                                Guardar(2);
                            }
                            else if (radioZ22.Checked == true)
                            {
                                Guardar(3);
                            }
                            cierracom100(Page);
                            abrecom4s2(Page);
                            //HttpContext.Current.Session["testigo"] = "1";
                            //cierracom100(Page);
                            //Image1.ImageUrl = "Images/Cortinilla4.JPG";
                            //programmaticModalPopup2.Show();
                            //cierramodal(Page);
                        }
                        else
                        {
                            cuenta = 3;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            ayuda01a.Attributes["data-content"] = leer_xml(3);
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            cierracom100(Page);
                            cierrabot1(Page);
                            abrecom4q2(Page);
                        }
                        break;
                    case 5:
                        if (radioB1.Checked == false && radioB2.Checked == false && radioB3.Checked == false && regreso[5] == 0)
                        {
                            cuenta = 4;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            regreso[5] = 1;
                            Button1.Attributes["data-content"] = leer_xml(4);
                            programmaticModalPopup.Show();
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom5(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            cuenta = 5;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            Button1.Attributes["data-content"] = leer_xml(5);
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom6(Page);
                            abrebot1(Page);
                            tb_Ie21.BackColor = System.Drawing.Color.LightSteelBlue;
                            tb_Ie21.Focus();
                        }
                        break;
                    case 6:
                        if (tb_Ie21.Text == "" && regreso[6] == 0)
                        {
                            cuenta = 5;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            regreso[6] = 1;
                            Button1.Attributes["data-content"] = leer_xml(5);
                            programmaticModalPopup.Show();
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom6(Page);
                            abrebot1(Page);
                            tb_Ie21.BackColor = System.Drawing.Color.LightSteelBlue;
                            tb_Ie21.Focus();
                        }
                        else
                        {
                            cuenta = 6;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            Button1.Attributes["data-content"] = leer_xml(6);
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom7(Page);
                            abrebot1(Page);
                            tb_Ie31.BackColor = System.Drawing.Color.LightSteelBlue;
                            tb_Ie31.Focus();
                        }
                        break;
                    case 7:
                        if (tb_Ie31.Text == "" && regreso[7] == 0)
                        {
                            cuenta = 6;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            regreso[7] = 1;
                            Button1.Attributes["data-content"] = leer_xml(6);
                            programmaticModalPopup.Show();
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom7(Page);
                            abrebot1(Page);
                            tb_Ie31.BackColor = System.Drawing.Color.LightSteelBlue;
                            tb_Ie31.Focus();
                        }
                        else if (tb_Ie31.Text == "0")
                        {
                            cuenta = 6;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            Button1.Attributes["data-content"] = leer_xml(6);
                            Label10.Text = "El valor debe ser mayor a 0";
                            programmaticModalPopup.Show();
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom7(Page);
                            abrebot1(Page);
                            regreso[7] = 0;
                            tb_Ie31.Text = "";
                            tb_Ie31.BackColor = System.Drawing.Color.LightSteelBlue;
                            tb_Ie31.Focus();
                        }
                        else if (Convert.ToInt32(string.IsNullOrEmpty(tb_Ie21.Text) ? tb_Ie21.Text = "0" : tb_Ie21.Text) > Convert.ToInt32(string.IsNullOrEmpty(tb_Ie31.Text) ? tb_Ie31.Text = "0" : tb_Ie31.Text))
                        {
                            cuenta = 5;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            Button1.Attributes["data-content"] = leer_xml(5);
                            regreso[7] = 1;
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            cierracom100(Page);
                            abrecom4s1(Page);
                        }
                        else
                        {
                            cuenta = 7;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            Button1.Attributes["data-content"] = leer_xml(7);
                            HttpContext.Current.Session["mio"] = Convert.ToInt32(string.IsNullOrEmpty(tb_Ie31.Text) ? tb_Ie31.Text = "0" : tb_Ie31.Text);
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom8(Page);
                            abrebot1(Page);
                        }
                        break;
                    case 8:
                        if (RadioButtonList3.SelectedIndex <= -1 && regreso[8] == 0)
                        {
                            cuenta = 7;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            regreso[8] = 1;
                            Button1.Attributes["data-content"] = leer_xml(7);
                            programmaticModalPopup.Show();
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom8(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            cuenta = 8;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            Button1.Attributes["data-content"] = leer_xml(8);
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom9(Page);
                            abrebot1(Page);
                        }
                        break;
                    case 9:
                        if (radioC1.Checked == false && radioC2.Checked == false && radioC3.Checked == false && regreso[9] == 0)
                        {
                            cuenta = 8;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            regreso[9] = 1;
                            Button1.Attributes["data-content"] = leer_xml(8);
                            programmaticModalPopup.Show();
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom9(Page);
                            abrebot1(Page);
                        }
                        else if (radioC3.Checked != true)
                        {
                            cuenta = 9;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            Button1.Attributes["data-content"] = leer_xml(9);
                            radioE1.Checked = false;
                            radioE2.Checked = false;
                            radioE3.Checked = false;
                            radioE4.Checked = false;
                            radioE5.Checked = false;
                            radioE6.Checked = false;
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom10(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            cuenta = 10;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            Button1.Attributes["data-content"] = leer_xml(10);
                            radioD1.Checked = false;
                            radioD2.Checked = false;
                            radioD3.Checked = false;
                            radioD4.Checked = false;
                            radioD5.Checked = false;
                            radioD6.Checked = false;
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom11(Page);
                            abrebot1(Page);
                        }
                        break;
                    case 10:
                        if (radioD1.Checked == false && radioD2.Checked == false && radioD3.Checked == false && radioD4.Checked == false && radioD5.Checked == false && radioD6.Checked == false && regreso[10] == 0)
                        {
                            cuenta = 9;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            regreso[10] = 1;
                            Button1.Attributes["data-content"] = leer_xml(9);
                            //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                            programmaticModalPopup.Show();
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom10(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            cuenta = 11;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            Button1.Attributes["data-content"] = leer_xml(11);
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom14(Page);
                            abrebot1(Page);
                        }
                        break;
                    case 11:
                        if (radioE1.Checked == false && radioE2.Checked == false && radioE3.Checked == false && radioE4.Checked == false && radioE5.Checked == false && radioE6.Checked == false && regreso[11] == 0)
                        {
                            cuenta = 10;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            regreso[11] = 1;
                            Button1.Attributes["data-content"] = leer_xml(10);
                            programmaticModalPopup.Show();
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom11(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            cuenta = 11;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            Button1.Attributes["data-content"] = leer_xml(11);
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom14(Page);
                            abrebot1(Page);
                        }
                        break;
                    case 12:
                        if (radioG1.Checked == false && radioG2.Checked == false && radioG3.Checked == false && regreso[13] == 0)
                        {
                            cuenta = 11;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            regreso[13] = 1;
                            Button1.Attributes["data-content"] = leer_xml(11);
                            //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                            programmaticModalPopup.Show();
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom14(Page);
                            abrebot1(Page);
                        }
                        else if (radioG3.Checked != true)
                        {
                            cuenta = 12;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            Button1.Attributes["data-content"] = leer_xml(12);
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom15(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            cuenta = 13;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            Button1.Attributes["data-content"] = leer_xml(13);
                            radioH1.Checked = false;
                            radioH2.Checked = false;
                            radioH3.Checked = false;
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom16(Page);
                            abrebot1(Page);
                        }
                        break;
                    case 13:
                        if (radioH1.Checked == false && radioH2.Checked == false && radioH3.Checked == false && regreso[14] == 0)
                        {
                            cuenta = 12;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            regreso[14] = 1;
                            Button1.Attributes["data-content"] = leer_xml(12);
                            programmaticModalPopup.Show();
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom15(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            cuenta = 13;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            Button1.Attributes["data-content"] = leer_xml(13);
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom16(Page);
                            abrebot1(Page);
                        }
                        break;
                    case 14:
                        if (radioI1.Checked == false && radioI2.Checked == false && radioI3.Checked == false && radioI4.Checked == false && radioI5.Checked == false && regreso[15] == 0)
                        {
                            cuenta = 13;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            regreso[15] = 1;
                            Button1.Attributes["data-content"] = leer_xml(13);
                            programmaticModalPopup.Show();
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom16(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            cuenta = 14;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            Button1.Attributes["data-content"] = leer_xml(14);
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom18(Page);
                            abrebot1(Page);
                        }
                        break;
                    //case 15:
                    //    if (radioJ1.Checked == false && radioJ2.Checked == false && radioJ3.Checked == false && radioJ4.Checked == false && radioJ5.Checked == false && radioJ6.Checked == false && regreso[16] == 0)
                    //    {
                    //        cuenta = 14;
                    //        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                    //        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                    //        regreso[16] = 1;
                    //        programmaticModalPopup.Show();
                    //        cierracom2(Page);
                    //        cierracom3(Page);
                    //        cierracom3a(Page);
                    //        cierracom3b(Page);
                    //        cierracom3c(Page);
                    //        cierracom3d(Page);
                    //        cierracom3e(Page);
                    //        cierracom3f(Page);
                    //        cierracom4(Page);
                    //        cierracom4a(Page);
                    //        cierracom5(Page);
                    //        cierracom6(Page);
                    //        cierracom7(Page);
                    //        cierracom8(Page);
                    //        cierracom9(Page);
                    //        cierracom10(Page);
                    //        cierracom11(Page);
                    //        cierracom12(Page);
                    //        cierracom13(Page);
                    //        cierracom14(Page);
                    //        cierracom15(Page);
                    //        cierracom16(Page);
                    //        cierracom17(Page);
                    //        cierracom18(Page);
                    //        abrecom4(Page);
                    //        abrecom17(Page);
                    //        abrebot1(Page);
                    //    }
                    //    else
                    //    {
                    //        cuenta = 15;
                    //        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                    //        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                    //        cierracom2(Page);
                    //        cierracom3(Page);
                    //        cierracom3a(Page);
                    //        cierracom3b(Page);
                    //        cierracom3c(Page);
                    //        cierracom3d(Page);
                    //        cierracom3e(Page);
                    //        cierracom3f(Page);
                    //        cierracom4(Page);
                    //        cierracom4a(Page);
                    //        cierracom5(Page);
                    //        cierracom6(Page);
                    //        cierracom7(Page);
                    //        cierracom8(Page);
                    //        cierracom9(Page);
                    //        cierracom10(Page);
                    //        cierracom11(Page);
                    //        cierracom12(Page);
                    //        cierracom13(Page);
                    //        cierracom14(Page);
                    //        cierracom15(Page);
                    //        cierracom16(Page);
                    //        cierracom17(Page);
                    //        cierracom18(Page);
                    //        abrecom4(Page);
                    //        abrecom18(Page);
                    //        abrebot1(Page);
                    //    }
                    //    break;
                    case 15:
                        if (((radioZA1.Checked == false && radioZA2.Checked == false) || (radioZB1.Checked == false && radioZB2.Checked == false) || (radioZC1.Checked == false && radioZC2.Checked == false) || (radioZD1.Checked == false && radioZD2.Checked == false) || (radioZE1.Checked == false && radioZE2.Checked == false) || (radioZF1.Checked == false && radioZF2.Checked == false) || (radioZG1.Checked == false && radioZG2.Checked == false) || (radioZH1.Checked == false && radioZH2.Checked == false) || (radioZI1.Checked == false && radioZI2.Checked == false) || (radioZJ1.Checked == false && radioZJ2.Checked == false) || (radioZK1.Checked == false && radioZK2.Checked == false) || (radioZL1.Checked == false && radioZL2.Checked == false)) && regreso[17] == 0)
                        {
                            //if (radioZA1.Checked != true || radioZA2.Checked != true || radioZB1.Checked != true || radioZB2.Checked != true || radioZC1.Checked != true || radioZC2.Checked != true || radioZD1.Checked != true || radioZD2.Checked != true || radioZE1.Checked != true || radioZE2.Checked != true || radioZF1.Checked != true || radioZF2.Checked != true || radioZG1.Checked != true || radioZG2.Checked != true || radioZH1.Checked != true || radioZH2.Checked != true || radioZI1.Checked != true || radioZI2.Checked != true || radioZJ1.Checked != true || radioZJ2.Checked != false || radioZK1.Checked != true || radioZK2.Checked != true || radioZL1.Checked != true || radioZL2.Checked != true)
                            //{
                            cuenta = 14;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            regreso[17] = 1;
                            Button1.Attributes["data-content"] = leer_xml(14);
                            programmaticModalPopup.Show();
                            cierracom2(Page);
                            cierracom3(Page);
                            cierracom3a(Page);
                            cierracom3b(Page);
                            cierracom3c(Page);
                            cierracom3d(Page);
                            cierracom3e(Page);
                            cierracom3f(Page);
                            cierracom4(Page);
                            cierracom4a(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom7(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom14(Page);
                            cierracom15(Page);
                            cierracom16(Page);
                            cierracom17(Page);
                            cierracom18(Page);
                            abrecom4(Page);
                            abrecom18(Page);
                            abrebot1(Page);
                            //}
                            //else
                            //{
                            //    Response.Redirect("CuestionarioPersona.aspx");
                            //}
                        }
                        else
                        {
                            Guardar(7);
                            Response.Redirect("CuestionarioPersona.aspx");
                            //Transfer_("CuestionarioPersona.aspx");
                        }
                        break;
                    default:
                        cuenta = 0;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        ayuda01a.Attributes["data-content"] = leer_xml(0);
                        cierracom2(Page);
                        cierracom3(Page);
                        cierracom3a(Page);
                        cierracom3b(Page);
                        cierracom3c(Page);
                        cierracom3d(Page);
                        cierracom3e(Page);
                        cierracom3f(Page);
                        cierracom4(Page);
                        cierracom4a(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom7(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom14(Page);
                        cierracom15(Page);
                        cierracom16(Page);
                        cierracom17(Page);
                        cierracom18(Page);
                        cierracom4q2(Page);
                        abrecom4a(Page);
                        abrecom3e(Page);
                        abrecom100(Page);
                        cierrabot1(Page);
                        break;
                }
                //ayuda01a.Attributes["data-content"] = leer_xml(cuenta);
                //Button1.Attributes["data-content"] = leer_xml(cuenta);
                Avance_barra(1);
            }
        }
        protected void Personas_Click(object sender, EventArgs e)
        {
            Guardar(7);
            Response.Redirect("CuestionarioPersona.aspx");
            //Transfer_("CuestionarioPersona.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {

        }
        protected void cierramodal(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>setTimeout(function () {$find('programmaticModalPopupBehavior2').hide(); window.open('http://www.inegi.org.mx/est/contenidos/proyectos/ccpv/default.aspx','_self');}, 4000);</script>";
            //string nuevaUrl = string.Format("Reporte.aspx?id={0}&num_cuartos={1}&hombres={2}&mujeres={3}&nom_imagen={4}", "AIRQBD" + DateTime.Today.ToString("ddMM") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00"), 1, 3, 4, "r02_002");
            ////+DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00")
            //string codigo = "<script language='JavaScript'>setTimeout(function () {window.open('" + nuevaUrl + "','_self');}, 4000);</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open moda"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open moda", codigo);
            }
        }
        protected void Si01_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Default.aspx");
            HttpContext.Current.Session["testigo"] = "1";
            cierracom100(Page);
            Image1.ImageUrl = "Images/Cortinilla4.JPG";
            programmaticModalPopup2.Show();
            cierramodal(Page);
        }
        protected void No01_Click(object sender, EventArgs e)
        {
            int cuenta = 1;
            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            cierracom2(Page);
            cierracom3(Page);
            cierracom3a(Page);
            cierracom3b(Page);
            cierracom3c(Page);
            cierracom3d(Page);
            cierracom3e(Page);
            cierracom3f(Page);
            cierracom4(Page);
            //cierracom4a(Page);
            cierracom5(Page);
            cierracom6(Page);
            cierracom7(Page);
            cierracom8(Page);
            cierracom9(Page);
            cierracom10(Page);
            cierracom11(Page);
            cierracom12(Page);
            cierracom13(Page);
            cierracom14(Page);
            cierracom15(Page);
            cierracom16(Page);
            cierracom17(Page);
            cierracom18(Page);
            abrecom4a(Page);
            abrecom3b(Page);
            abrebot1(Page);
        }
        protected void Si02_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Default.aspx");
            HttpContext.Current.Session["testigo"] = "1";
            cierracom100(Page);
            Image1.ImageUrl = "Images/Cortinilla4.JPG";
            programmaticModalPopup2.Show();
            cierramodal(Page);
        }
        protected void No02_Click(object sender, EventArgs e)
        {
            int cuenta = 4;
            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            cierracom2(Page);
            cierracom3(Page);
            cierracom3a(Page);
            cierracom3b(Page);
            cierracom3c(Page);
            cierracom3d(Page);
            cierracom3e(Page);
            cierracom3f(Page);
            cierracom4(Page);
            cierracom4a(Page);
            cierracom5(Page);
            cierracom6(Page);
            cierracom7(Page);
            cierracom8(Page);
            cierracom9(Page);
            cierracom10(Page);
            cierracom11(Page);
            cierracom12(Page);
            cierracom13(Page);
            cierracom14(Page);
            cierracom15(Page);
            cierracom16(Page);
            cierracom17(Page);
            cierracom18(Page);
            abrecom4a(Page);
            abrecom3e(Page);
            //abrebot1(Page);
        }
        protected void Si03_Click(object sender, EventArgs e)
        {
            int cuenta = 5;
            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            cierracom2(Page);
            cierracom3(Page);
            cierracom3a(Page);
            cierracom3b(Page);
            cierracom3c(Page);
            cierracom3d(Page);
            cierracom3e(Page);
            cierracom3f(Page);
            cierracom4(Page);
            cierracom4a(Page);
            cierracom5(Page);
            cierracom6(Page);
            cierracom7(Page);
            cierracom8(Page);
            cierracom9(Page);
            cierracom10(Page);
            cierracom11(Page);
            cierracom12(Page);
            cierracom13(Page);
            cierracom14(Page);
            cierracom15(Page);
            cierracom16(Page);
            cierracom17(Page);
            cierracom18(Page);
            abrecom4(Page);
            abrecom6(Page);
            abrebot1(Page);
            tb_Ie21.BackColor = System.Drawing.Color.LightSteelBlue;
            tb_Ie21.Focus();
        }

        protected void Si04_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["testigo"] = "1";
            cierracom100(Page);
            Image1.ImageUrl = "Images/Cortinilla4.JPG";
            programmaticModalPopup2.Show();
            cierramodal(Page);
        }

        protected void adelante02_Click(object sender, EventArgs e)
        {
            //int cuenta = 6;
            //HttpContext.Current.Session["cuenta"] = cuenta.ToString();
            //cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            //cierracom2(Page);
            //cierracom3(Page);
            //cierracom3a(Page);
            //cierracom3b(Page);
            //cierracom3c(Page);
            //cierracom3d(Page);
            //cierracom3e(Page);
            //cierracom3f(Page);
            //cierracom4(Page);
            //cierracom4a(Page);
            //cierracom5(Page);
            //cierracom6(Page);
            //cierracom7(Page);
            //cierracom8(Page);
            //cierracom9(Page);
            //cierracom10(Page);
            //cierracom11(Page);
            //cierracom12(Page);
            //cierracom13(Page);
            //cierracom14(Page);
            //cierracom15(Page);
            //cierracom16(Page);
            //cierracom17(Page);
            //cierracom18(Page);
            //abrecom4(Page);
            //abrecom3(Page);
            //abrebot1(Page);
            //Avance_barra(1);
            int cuenta = 4;
            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            cierracom2(Page);
            cierracom3(Page);
            cierracom3a(Page);
            cierracom3b(Page);
            cierracom3c(Page);
            cierracom3d(Page);
            cierracom3e(Page);
            cierracom3f(Page);
            cierracom4(Page);
            cierracom4a(Page);
            cierracom5(Page);
            cierracom6(Page);
            cierracom7(Page);
            cierracom8(Page);
            cierracom9(Page);
            cierracom10(Page);
            cierracom11(Page);
            cierracom12(Page);
            cierracom13(Page);
            cierracom14(Page);
            cierracom15(Page);
            cierracom16(Page);
            cierracom17(Page);
            cierracom18(Page);
            cierracom4q2(Page);
            abrecom4(Page);
            abrecom5(Page);
            abrecom100(Page);
            abrebot1(Page);
            Avance_barra(1);
            Button1.Attributes["data-content"] = leer_xml(4);
        }
        protected void atras02_Click(object sender, EventArgs e)
        {
            int cuenta = 4;
            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            cierracom2(Page);
            cierracom3(Page);
            cierracom3a(Page);
            cierracom3b(Page);
            cierracom3c(Page);
            cierracom3d(Page);
            cierracom3e(Page);
            cierracom3f(Page);
            cierracom4(Page);
            cierracom4a(Page);
            cierracom5(Page);
            cierracom6(Page);
            cierracom7(Page);
            cierracom8(Page);
            cierracom9(Page);
            cierracom10(Page);
            cierracom11(Page);
            cierracom12(Page);
            cierracom13(Page);
            cierracom14(Page);
            cierracom15(Page);
            cierracom16(Page);
            cierracom17(Page);
            cierracom18(Page);
            abrecom4a(Page);
            abrecom3e(Page);
            abrebot1(Page);
            Avance_barra(1);
        }

        protected void ImageButton101_Click(object sender, ImageClickEventArgs e)
        {
            ayuda_modal.InnerHtml = leer_xml(1);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(1); });", true);
        }

        void Guardar(int modo)
        {
            switch (modo)
            {
                case 1:
                    OracleDataReader miReader = null;
                    string valor = "";
                    string oradb = ConfigurationManager.AppSettings["cai2020"];
                    OracleConnection conn = new OracleConnection(); // C#
                    conn.ConnectionString = oradb.ToString();
                    conn.Open();
                    try
                    {
                        OracleCommand miComando = new OracleCommand("SP_CPV20_INT", conn);
                        miComando.CommandType = CommandType.StoredProcedure;
                        //Envio 2 parametros
                        miComando.Parameters.Add("P_QR_VIV", OracleDbType.NVarchar2);
                        miComando.Parameters["P_QR_VIV"].Value = HttpContext.Current.Session["qr_viv"].ToString();
                        miComando.Parameters.Add("P_RES_DOM", OracleDbType.Int32);
                        if (RadioButtonList2.Items[0].Selected == true)
                        {
                            miComando.Parameters["P_RES_DOM"].Value = 1;
                        }
                        else if (RadioButtonList2.Items[1].Selected == true)
                        {
                            miComando.Parameters["P_RES_DOM"].Value = 3;
                        }
                        else
                        {
                            miComando.Parameters["P_RES_DOM"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_VIV_DOM", OracleDbType.Int32);
                        if (tb_I031.Text != "")
                        {
                            miComando.Parameters["P_VIV_DOM"].Value = Convert.ToInt32(tb_I031.Text);
                        }
                        else
                        {
                            miComando.Parameters["P_VIV_DOM"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_CLAVIVP", OracleDbType.Int32);
                        if (radioA1.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 1;
                        }
                        else if (radioA2.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 2;
                        }
                        else if (radioA3.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 3;
                        }
                        else if (radioA4.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 4;
                        }
                        else if (radioA5.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 5;
                        }
                        else if (radioA6.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 6;
                        }
                        else if (radioA7.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 7;
                        }
                        else
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_MOT_NOHAB", OracleDbType.Int32);
                        if (radioZ21.Checked == true)
                        {
                            miComando.Parameters["P_MOT_NOHAB"].Value = 1;
                        }
                        else if (radioZ22.Checked == true)
                        {
                            miComando.Parameters["P_MOT_NOHAB"].Value = 2;
                        }
                        else
                        {
                            miComando.Parameters["P_MOT_NOHAB"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_PISOS", OracleDbType.Int32);
                        if (radioB1.Checked == true)
                        {
                            miComando.Parameters["P_PISOS"].Value = 1;
                        }
                        else if (radioB2.Checked == true)
                        {
                            miComando.Parameters["P_PISOS"].Value = 2;
                        }
                        else if (radioB3.Checked == true)
                        {
                            miComando.Parameters["P_PISOS"].Value = 3;
                        }
                        else
                        {
                            miComando.Parameters["P_PISOS"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_CUADORM", OracleDbType.Int32);
                        if (tb_Ie21.Text != "")
                        {
                            miComando.Parameters["P_CUADORM"].Value = Convert.ToInt32(tb_Ie21.Text);
                        }
                        else
                        {
                            miComando.Parameters["P_CUADORM"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_TOTCUART", OracleDbType.Int32);
                        if (tb_Ie31.Text != "")
                        {
                            miComando.Parameters["P_TOTCUART"].Value = Convert.ToInt32(tb_Ie31.Text);
                        }
                        else
                        {
                            miComando.Parameters["P_TOTCUART"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_ELECTRICIDAD", OracleDbType.Int32);
                        if (RadioButtonList3.Items[0].Selected == true)
                        {
                            miComando.Parameters["P_ELECTRICIDAD"].Value = 1;
                        }
                        else if (RadioButtonList3.Items[1].Selected == true)
                        {
                            miComando.Parameters["P_ELECTRICIDAD"].Value = 3;
                        }
                        else
                        {
                            miComando.Parameters["P_ELECTRICIDAD"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_AGUA_ENTUBADA", OracleDbType.Int32);
                        if (radioC1.Checked == true)
                        {
                            miComando.Parameters["P_AGUA_ENTUBADA"].Value = 1;
                        }
                        else if (radioC2.Checked == true)
                        {
                            miComando.Parameters["P_AGUA_ENTUBADA"].Value = 2;
                        }
                        else if (radioC3.Checked == true)
                        {
                            miComando.Parameters["P_AGUA_ENTUBADA"].Value = 3;
                        }
                        else
                        {
                            miComando.Parameters["P_AGUA_ENTUBADA"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_ABA_AGUA", OracleDbType.Int32);
                        if (radioD1.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA"].Value = 1;
                        }
                        else if (radioD2.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA"].Value = 2;
                        }
                        else if (radioD3.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA"].Value = 3;
                        }
                        else if (radioD4.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA"].Value = 4;
                        }
                        else if (radioD5.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA"].Value = 5;
                        }
                        else if (radioD6.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA"].Value = 6;
                        }
                        else
                        {
                            miComando.Parameters["P_ABA_AGUA"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_ABA_AGUA_NO_ENTUBADA", OracleDbType.Int32);
                        if (radioE1.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA_NO_ENTUBADA"].Value = 1;
                        }
                        else if (radioE2.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA_NO_ENTUBADA"].Value = 2;
                        }
                        else if (radioE3.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA_NO_ENTUBADA"].Value = 3;
                        }
                        else if (radioE4.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA_NO_ENTUBADA"].Value = 4;
                        }
                        else if (radioE5.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA_NO_ENTUBADA"].Value = 5;
                        }
                        else if (radioE6.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA_NO_ENTUBADA"].Value = 6;
                        }
                        else
                        {
                            miComando.Parameters["P_ABA_AGUA_NO_ENTUBADA"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_SERSAN", OracleDbType.Int32);
                        if (radioG1.Checked == true)
                        {
                            miComando.Parameters["P_SERSAN"].Value = 1;
                        }
                        else if (radioG2.Checked == true)
                        {
                            miComando.Parameters["P_SERSAN"].Value = 2;
                        }
                        else if (radioG3.Checked == true)
                        {
                            miComando.Parameters["P_SERSANA"].Value = 3;
                        }
                        else
                        {
                            miComando.Parameters["P_SERSAN"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_CONAGUA", OracleDbType.Int32);
                        if (radioH1.Checked == true)
                        {
                            miComando.Parameters["P_CONAGUA"].Value = 1;
                        }
                        else if (radioH2.Checked == true)
                        {
                            miComando.Parameters["P_CONAGUA"].Value = 2;
                        }
                        else if (radioH3.Checked == true)
                        {
                            miComando.Parameters["P_CONAGUA"].Value = 3;
                        }
                        else
                        {
                            miComando.Parameters["P_CONAGUA"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_DRENAJE", OracleDbType.Int32);
                        if (radioI1.Checked == true)
                        {
                            miComando.Parameters["P_DRENAJE"].Value = 1;
                        }
                        else if (radioI2.Checked == true)
                        {
                            miComando.Parameters["P_DRENAJE"].Value = 2;
                        }
                        else if (radioI3.Checked == true)
                        {
                            miComando.Parameters["P_DRENAJE"].Value = 3;
                        }
                        else if (radioI4.Checked == true)
                        {
                            miComando.Parameters["P_DRENAJE"].Value = 4;
                        }
                        else if (radioI5.Checked == true)
                        {
                            miComando.Parameters["P_DRENAJE"].Value = 5;
                        }
                        else
                        {
                            miComando.Parameters["P_DRENAJE"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_REFRIGERADOR", OracleDbType.Int32);
                        if (radioZA1.Checked == true)
                        {
                            miComando.Parameters["P_REFRIGERADOR"].Value = 1;
                        }
                        else if (radioZA2.Checked == true)
                        {
                            miComando.Parameters["P_REFRIGERADOR"].Value = 2;
                        }
                        else
                        {
                            miComando.Parameters["P_REFRIGERADOR"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_LAVADORA", OracleDbType.Int32);
                        if (radioZB1.Checked == true)
                        {
                            miComando.Parameters["P_LAVADORA"].Value = 3;
                        }
                        else if (radioZB2.Checked == true)
                        {
                            miComando.Parameters["P_LAVADORA"].Value = 4;
                        }
                        else
                        {
                            miComando.Parameters["P_LAVADORA"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_HORNO", OracleDbType.Int32);
                        if (radioZC1.Checked == true)
                        {
                            miComando.Parameters["P_HORNO"].Value = 5;
                        }
                        else if (radioZC2.Checked == true)
                        {
                            miComando.Parameters["P_HORNO"].Value = 6;
                        }
                        else
                        {
                            miComando.Parameters["P_HORNO"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_AUTOPROP", OracleDbType.Int32);
                        if (radioZD1.Checked == true)
                        {
                            miComando.Parameters["P_AUTOPROP"].Value = 7;
                        }
                        else if (radioZD2.Checked == true)
                        {
                            miComando.Parameters["P_AUTOPROP"].Value = 8;
                        }
                        else
                        {
                            miComando.Parameters["P_AUTOPROP"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_RADIO", OracleDbType.Int32);
                        if (radioZE1.Checked == true)
                        {
                            miComando.Parameters["P_RADIO"].Value = 1;
                        }
                        else if (radioZE2.Checked == true)
                        {
                            miComando.Parameters["P_RADIO"].Value = 2;
                        }
                        else
                        {
                            miComando.Parameters["P_RADIO"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_TELEVISOR", OracleDbType.Int32);
                        if (radioZF1.Checked == true)
                        {
                            miComando.Parameters["P_TELEVISOR"].Value = 3;
                        }
                        else if (radioZF2.Checked == true)
                        {
                            miComando.Parameters["P_TELEVISOR"].Value = 4;
                        }
                        else
                        {
                            miComando.Parameters["P_TELEVISOR"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_TELEVISOR_PP", OracleDbType.Int32);
                        if (radioZG1.Checked == true)
                        {
                            miComando.Parameters["P_TELEVISOR_PP"].Value = 5;
                        }
                        else if (radioZG2.Checked == true)
                        {
                            miComando.Parameters["P_TELEVISOR_PP"].Value = 6;
                        }
                        else
                        {
                            miComando.Parameters["P_TELEVISOR_PP"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_COMPUTADORA", OracleDbType.Int32);
                        if (radioZH1.Checked == true)
                        {
                            miComando.Parameters["P_COMPUTADORA"].Value = 7;
                        }
                        else if (radioZH2.Checked == true)
                        {
                            miComando.Parameters["P_COMPUTADORA"].Value = 8;
                        }
                        else
                        {
                            miComando.Parameters["P_COMPUTADORA"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_TELEFONO", OracleDbType.Int32);
                        if (radioZI1.Checked == true)
                        {
                            miComando.Parameters["P_TELEFONO"].Value = 1;
                        }
                        else if (radioZI2.Checked == true)
                        {
                            miComando.Parameters["P_TELEFONO"].Value = 2;
                        }
                        else
                        {
                            miComando.Parameters["P_TELEFONO"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_CELULAR", OracleDbType.Int32);
                        if (radioZJ1.Checked == true)
                        {
                            miComando.Parameters["P_CELULAR"].Value = 3;
                        }
                        else if (radioZJ2.Checked == true)
                        {
                            miComando.Parameters["P_CELULAR"].Value = 4;
                        }
                        else
                        {
                            miComando.Parameters["P_CELULAR"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_INTERNET", OracleDbType.Int32);
                        if (radioZK1.Checked == true)
                        {
                            miComando.Parameters["P_INTERNET"].Value = 5;
                        }
                        else if (radioZK2.Checked == true)
                        {
                            miComando.Parameters["P_INTERNET"].Value = 6;
                        }
                        else
                        {
                            miComando.Parameters["P_INTERNET"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_SERV_TV_PAGA", OracleDbType.Int32);
                        if (radioZL1.Checked == true)
                        {
                            miComando.Parameters["P_SERV_TV_PAGA"].Value = 7;
                        }
                        else if (radioZL2.Checked == true)
                        {
                            miComando.Parameters["P_SERV_TV_PAGA"].Value = 8;
                        }
                        else
                        {
                            miComando.Parameters["P_SERV_TV_PAGA"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_MEDCAP", OracleDbType.Int32);
                        if (HttpContext.Current.Session["qr_viv"].ToString().Substring(0, 1) == "A")
                        {
                            miComando.Parameters["P_MEDCAP"].Value = 6;
                        }
                        else
                        {
                            miComando.Parameters["P_MEDCAP"].Value = 4;
                        }
                        miComando.Parameters.Add("p_ban", OracleDbType.NVarchar2);
                        miComando.Parameters["p_ban"].Direction = ParameterDirection.Output;
                        miComando.Parameters["p_ban"].Size = 100;
                        miReader = miComando.ExecuteReader(CommandBehavior.CloseConnection);
                        valor = miComando.Parameters["p_ban"].Value.ToString();
                        miReader = null;
                        miComando.Dispose();
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

                    break;
                case 2:
                    string oradb1 = ConfigurationManager.AppSettings["cai2020"];
                    OracleConnection conn1 = new OracleConnection(); // C#
                    conn1.ConnectionString = oradb1.ToString();
                    conn1.Open();
                    try
                    {
                        OracleCommand miComando = new OracleCommand();
                        miComando.Connection = conn1;
                        miComando.CommandText = "insert into CAP_INT_TR_VIVIENDA (QR_VIV,RES_DOM,VIV_DOM,CLAVIVP,MOT_NOHAB,MEDCAP) VALUES (:P_QR_VIV,:P_RES_DOM,:P_VIV_DOM,:P_CLAVIVP,:P_MOT_NOHAB,:P_MEDCAP)";
                        miComando.CommandType = CommandType.Text;
                        //Envio 2 parametros
                        miComando.Parameters.Add("P_QR_VIV", OracleDbType.NVarchar2);
                        miComando.Parameters["P_QR_VIV"].Value = HttpContext.Current.Session["qr_viv"].ToString();
                        miComando.Parameters.Add("P_RES_DOM", OracleDbType.Int32);
                        if (RadioButtonList2.Items[0].Selected == true)
                        {
                            miComando.Parameters["P_RES_DOM"].Value = 1;
                        }
                        else if (RadioButtonList2.Items[1].Selected == true)
                        {
                            miComando.Parameters["P_RES_DOM"].Value = 3;
                        }
                        else
                        {
                            miComando.Parameters["P_RES_DOM"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_VIV_DOM", OracleDbType.Int32);
                        if (tb_I031.Text != "")
                        {
                            miComando.Parameters["P_VIV_DOM"].Value = Convert.ToInt32(tb_I031.Text);
                        }
                        else
                        {
                            miComando.Parameters["P_VIV_DOM"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_CLAVIVP", OracleDbType.Int32);
                        if (radioA1.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 1;
                        }
                        else if (radioA2.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 2;
                        }
                        else if (radioA3.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 3;
                        }
                        else if (radioA4.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 4;
                        }
                        else if (radioA5.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 5;
                        }
                        else if (radioA6.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 6;
                        }
                        else if (radioA7.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 7;
                        }
                        else
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_MOT_NOHAB", OracleDbType.Int32);
                        if (radioZ21.Checked == true)
                        {
                            miComando.Parameters["P_MOT_NOHAB"].Value = 1;
                        }
                        else if (radioZ22.Checked == true)
                        {
                            miComando.Parameters["P_MOT_NOHAB"].Value = 2;
                        }
                        else
                        {
                            miComando.Parameters["P_MOT_NOHAB"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_MEDCAP", OracleDbType.Int32);
                        if (HttpContext.Current.Session["qr_viv"].ToString().Substring(0,1) == "A")
                        {
                            miComando.Parameters["P_MEDCAP"].Value = 6;
                        }
                        else
                        {
                            miComando.Parameters["P_MEDCAP"].Value = 4;
                        }
                        int j = miComando.ExecuteNonQuery();
                        miComando.Dispose();
                        OracleCommand cmd3 = new OracleCommand();
                        cmd3.Connection = conn1;
                        cmd3.CommandText = "insert into CAP_INT_TH_LLENADO (QR_VIV,RES_VIS) VALUES ('" + HttpContext.Current.Session["qr_viv"].ToString() + "','34')";
                        cmd3.CommandType = CommandType.Text;
                        int k = cmd3.ExecuteNonQuery();
                        cmd3.Dispose();
                    }
                    catch (Exception e1)
                    {
                        HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                    }
                    finally
                    {
                        conn1.Dispose();
                    }
                    break;
                case 3:
                    string oradb2 = ConfigurationManager.AppSettings["cai2020"];
                    OracleConnection conn2 = new OracleConnection(); // C#
                    conn2.ConnectionString = oradb2.ToString();
                    conn2.Open();
                    try
                    {
                        OracleCommand miComando = new OracleCommand();
                        miComando.Connection = conn2;
                        miComando.CommandText = "insert into CAP_INT_TR_VIVIENDA (QR_VIV,RES_DOM,VIV_DOM,CLAVIVP,MOT_NOHAB,MEDCAP) VALUES (:P_QR_VIV,:P_RES_DOM,:P_VIV_DOM,:P_CLAVIVP,:P_MOT_NOHAB,:P_MEDCAP)";
                        miComando.CommandType = CommandType.Text;
                        //Envio 2 parametros
                        miComando.Parameters.Add("P_QR_VIV", OracleDbType.NVarchar2);
                        miComando.Parameters["P_QR_VIV"].Value = HttpContext.Current.Session["qr_viv"].ToString();
                        miComando.Parameters.Add("P_RES_DOM", OracleDbType.Int32);
                        if (RadioButtonList2.Items[0].Selected == true)
                        {
                            miComando.Parameters["P_RES_DOM"].Value = 1;
                        }
                        else if (RadioButtonList2.Items[1].Selected == true)
                        {
                            miComando.Parameters["P_RES_DOM"].Value = 3;
                        }
                        else
                        {
                            miComando.Parameters["P_RES_DOM"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_VIV_DOM", OracleDbType.Int32);
                        if (tb_I031.Text != "")
                        {
                            miComando.Parameters["P_VIV_DOM"].Value = Convert.ToInt32(tb_I031.Text);
                        }
                        else
                        {
                            miComando.Parameters["P_VIV_DOM"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_CLAVIVP", OracleDbType.Int32);
                        if (radioA1.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 1;
                        }
                        else if (radioA2.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 2;
                        }
                        else if (radioA3.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 3;
                        }
                        else if (radioA4.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 4;
                        }
                        else if (radioA5.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 5;
                        }
                        else if (radioA6.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 6;
                        }
                        else if (radioA7.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 7;
                        }
                        else
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_MOT_NOHAB", OracleDbType.Int32);
                        if (radioZ21.Checked == true)
                        {
                            miComando.Parameters["P_MOT_NOHAB"].Value = 1;
                        }
                        else if (radioZ22.Checked == true)
                        {
                            miComando.Parameters["P_MOT_NOHAB"].Value = 2;
                        }
                        else
                        {
                            miComando.Parameters["P_MOT_NOHAB"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_MEDCAP", OracleDbType.Int32);
                        if (HttpContext.Current.Session["qr_viv"].ToString().Substring(0, 1) == "A")
                        {
                            miComando.Parameters["P_MEDCAP"].Value = 6;
                        }
                        else
                        {
                            miComando.Parameters["P_MEDCAP"].Value = 4;
                        }
                        int j = miComando.ExecuteNonQuery();
                        miComando.Dispose();
                        OracleCommand cmd3 = new OracleCommand();
                        cmd3.Connection = conn2;
                        cmd3.CommandText = "insert into CAP_INT_TH_LLENADO (QR_VIV,RES_VIS) VALUES ('" + HttpContext.Current.Session["qr_viv"].ToString() + "','33')";
                        cmd3.CommandType = CommandType.Text;
                        int k = cmd3.ExecuteNonQuery();
                        cmd3.Dispose();
                    }
                    catch (Exception e1)
                    {
                        HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                    }
                    finally
                    {
                        conn2.Dispose();
                    }
                    break;
                case 4:
                    string oradb3 = ConfigurationManager.AppSettings["cai2020"];
                    OracleConnection conn3 = new OracleConnection(); // C#
                    conn3.ConnectionString = oradb3.ToString();
                    conn3.Open();
                    try
                    {
                        OracleCommand miComando = new OracleCommand();
                        miComando.Connection = conn3;
                        miComando.CommandText = "insert into CAP_INT_TR_VIVIENDA (QR_VIV,RES_DOM,VIV_DOM,CLAVIVP,MOT_NOHAB,MEDCAP) VALUES (:P_QR_VIV,:P_RES_DOM,:P_VIV_DOM,:P_CLAVIVP,:P_MOT_NOHAB,:P_MEDCAP)";
                        miComando.CommandType = CommandType.Text;
                        //Envio 2 parametros
                        miComando.Parameters.Add("P_QR_VIV", OracleDbType.NVarchar2);
                        miComando.Parameters["P_QR_VIV"].Value = HttpContext.Current.Session["qr_viv"].ToString();
                        miComando.Parameters.Add("P_RES_DOM", OracleDbType.Int32);
                        if (RadioButtonList2.Items[0].Selected == true)
                        {
                            miComando.Parameters["P_RES_DOM"].Value = 1;
                        }
                        else if (RadioButtonList2.Items[1].Selected == true)
                        {
                            miComando.Parameters["P_RES_DOM"].Value = 3;
                        }
                        else
                        {
                            miComando.Parameters["P_RES_DOM"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_VIV_DOM", OracleDbType.Int32);
                        if (tb_I031.Text != "")
                        {
                            miComando.Parameters["P_VIV_DOM"].Value = Convert.ToInt32(tb_I031.Text);
                        }
                        else
                        {
                            miComando.Parameters["P_VIV_DOM"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_CLAVIVP", OracleDbType.Int32);
                        if (radioA1.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 1;
                        }
                        else if (radioA2.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 2;
                        }
                        else if (radioA3.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 3;
                        }
                        else if (radioA4.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 4;
                        }
                        else if (radioA5.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 5;
                        }
                        else if (radioA6.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 6;
                        }
                        else if (radioA7.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 7;
                        }
                        else
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_MOT_NOHAB", OracleDbType.Int32);
                        if (radioZ21.Checked == true)
                        {
                            miComando.Parameters["P_MOT_NOHAB"].Value = 1;
                        }
                        else if (radioZ22.Checked == true)
                        {
                            miComando.Parameters["P_MOT_NOHAB"].Value = 2;
                        }
                        else
                        {
                            miComando.Parameters["P_MOT_NOHAB"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_MEDCAP", OracleDbType.Int32);
                        if (HttpContext.Current.Session["qr_viv"].ToString().Substring(0, 1) == "A")
                        {
                            miComando.Parameters["P_MEDCAP"].Value = 6;
                        }
                        else
                        {
                            miComando.Parameters["P_MEDCAP"].Value = 4;
                        }
                        int j = miComando.ExecuteNonQuery();
                        miComando.Dispose();
                        OracleCommand cmd3 = new OracleCommand();
                        cmd3.Connection = conn3;
                        cmd3.CommandText = "insert into CAP_INT_TH_LLENADO (QR_VIV,RES_VIS) VALUES ('" + HttpContext.Current.Session["qr_viv"].ToString() + "','36')";
                        cmd3.CommandType = CommandType.Text;
                        int k = cmd3.ExecuteNonQuery();
                        cmd3.Dispose();
                    }
                    catch (Exception e1)
                    {
                        HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                    }
                    finally
                    {
                        conn3.Dispose();
                    }
                    break;
                case 5:
                    string oradb4 = ConfigurationManager.AppSettings["cai2020"];
                    OracleConnection conn4 = new OracleConnection(); // C#
                    conn4.ConnectionString = oradb4.ToString();
                    conn4.Open();
                    try
                    {
                        OracleCommand miComando = new OracleCommand();
                        miComando.Connection = conn4;
                        miComando.CommandText = "insert into CAP_INT_TR_VIVIENDA (QR_VIV,RES_DOM,VIV_DOM,CLAVIVP,MOT_NOHAB,MEDCAP) VALUES (:P_QR_VIV,:P_RES_DOM,:P_VIV_DOM,:P_CLAVIVP,:P_MOT_NOHAB,:P_MEDCAP)";
                        miComando.CommandType = CommandType.Text;
                        //Envio 2 parametros
                        miComando.Parameters.Add("P_QR_VIV", OracleDbType.NVarchar2);
                        miComando.Parameters["P_QR_VIV"].Value = HttpContext.Current.Session["qr_viv"].ToString();
                        miComando.Parameters.Add("P_RES_DOM", OracleDbType.Int32);
                        if (RadioButtonList2.Items[0].Selected == true)
                        {
                            miComando.Parameters["P_RES_DOM"].Value = 1;
                        }
                        else if (RadioButtonList2.Items[1].Selected == true)
                        {
                            miComando.Parameters["P_RES_DOM"].Value = 3;
                        }
                        else
                        {
                            miComando.Parameters["P_RES_DOM"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_VIV_DOM", OracleDbType.Int32);
                        if (tb_I031.Text != "")
                        {
                            miComando.Parameters["P_VIV_DOM"].Value = Convert.ToInt32(tb_I031.Text);
                        }
                        else
                        {
                            miComando.Parameters["P_VIV_DOM"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_CLAVIVP", OracleDbType.Int32);
                        if (radioA1.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 1;
                        }
                        else if (radioA2.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 2;
                        }
                        else if (radioA3.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 3;
                        }
                        else if (radioA4.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 4;
                        }
                        else if (radioA5.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 5;
                        }
                        else if (radioA6.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 6;
                        }
                        else if (radioA7.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 7;
                        }
                        else
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_MOT_NOHAB", OracleDbType.Int32);
                        if (radioZ21.Checked == true)
                        {
                            miComando.Parameters["P_MOT_NOHAB"].Value = 1;
                        }
                        else if (radioZ22.Checked == true)
                        {
                            miComando.Parameters["P_MOT_NOHAB"].Value = 2;
                        }
                        else
                        {
                            miComando.Parameters["P_MOT_NOHAB"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_MEDCAP", OracleDbType.Int32);
                        if (HttpContext.Current.Session["qr_viv"].ToString().Substring(0, 1) == "A")
                        {
                            miComando.Parameters["P_MEDCAP"].Value = 6;
                        }
                        else
                        {
                            miComando.Parameters["P_MEDCAP"].Value = 4;
                        }
                        int j = miComando.ExecuteNonQuery();
                        miComando.Dispose();
                        OracleCommand cmd3 = new OracleCommand();
                        cmd3.Connection = conn4;
                        cmd3.CommandText = "insert into CAP_INT_TH_LLENADO (QR_VIV,RES_VIS) VALUES ('" + HttpContext.Current.Session["qr_viv"].ToString() + "','35')";
                        cmd3.CommandType = CommandType.Text;
                        int k = cmd3.ExecuteNonQuery();
                        cmd3.Dispose();
                    }
                    catch (Exception e1)
                    {
                        HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                    }
                    finally
                    {
                        conn4.Dispose();
                    }
                    break;
                case 6:
                    string oradb5 = ConfigurationManager.AppSettings["cai2020"];
                    OracleConnection conn5 = new OracleConnection(); // C#
                    conn5.ConnectionString = oradb5.ToString();
                    conn5.Open();
                    try
                    {
                        OracleCommand cmd3 = new OracleCommand();
                        cmd3.Connection = conn5;
                        cmd3.CommandText = "insert into CAP_INT_TH_BITACORA (QR_VIV,ACCESO) VALUES ('" + HttpContext.Current.Session["qr_viv"].ToString() + "','" + HttpContext.Current.Session["movil"] + "')";
                        cmd3.CommandType = CommandType.Text;
                        int k = cmd3.ExecuteNonQuery();
                        cmd3.Dispose();
                    }
                    catch (Exception e1)
                    {
                        HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                    }
                    finally
                    {
                        conn5.Dispose();
                    }
                    break;
                case 7:
                    string oradb6 = ConfigurationManager.AppSettings["cai2020"];
                    OracleConnection conn6 = new OracleConnection(); // C#
                    conn6.ConnectionString = oradb6.ToString();
                    conn6.Open();
                    try
                    {
                        OracleCommand miComando = new OracleCommand();
                        miComando.Connection = conn6;
                        miComando.CommandText = "insert into CAP_INT_TR_VIVIENDA (QR_VIV,RES_DOM,VIV_DOM,CLAVIVP,MOT_NOHAB,PISOS,CUADORM,TOTCUART,ELECTRICIDAD,AGUA_ENTUBADA,ABA_AGUA,ABA_AGUA_NO_ENTUBADA,SERSAN,CONAGUA,DRENAJE,REFRIGERADOR,LAVADORA,HORNO,AUTOPROP,RADIO,TELEVISOR,TELEVISOR_PP,COMPUTADORA,TELEFONO,CELULAR,INTERNET,SERV_TV_PAGA,MEDCAP) VALUES (:P_QR_VIV,:P_RES_DOM,:P_VIV_DOM,:P_CLAVIVP,:P_MOT_NOHAB,:P_PISOS,:P_CUADORM,:P_TOTCUART,:P_ELECTRICIDAD,:P_AGUA_ENTUBADA,:P_ABA_AGUA,:P_ABA_AGUA_NO_ENTUBADA,:P_SERSAN,:P_CONAGUA,:P_DRENAJE,:P_REFRIGERADOR,:P_LAVADORA,:P_HORNO,:P_AUTOPROP,:P_RADIO,:P_TELEVISOR,:P_TELEVISOR_PP,:P_COMPUTADORA,:P_TELEFONO,:P_CELULAR,:P_INTERNET,:P_SERV_TV_PAGA,:P_MEDCAP)";
                        miComando.CommandType = CommandType.Text;
                        //Envio 2 parametros
                        miComando.Parameters.Add("P_QR_VIV", OracleDbType.NVarchar2);
                        miComando.Parameters["P_QR_VIV"].Value = HttpContext.Current.Session["qr_viv"].ToString();
                        miComando.Parameters.Add("P_RES_DOM", OracleDbType.Int32);
                        if (RadioButtonList2.Items[0].Selected == true)
                        {
                            miComando.Parameters["P_RES_DOM"].Value = 1;
                        }
                        else if (RadioButtonList2.Items[1].Selected == true)
                        {
                            miComando.Parameters["P_RES_DOM"].Value = 3;
                        }
                        else
                        {
                            miComando.Parameters["P_RES_DOM"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_VIV_DOM", OracleDbType.Int32);
                        if (tb_I031.Text != "")
                        {
                            miComando.Parameters["P_VIV_DOM"].Value = Convert.ToInt32(tb_I031.Text);
                        }
                        else
                        {
                            miComando.Parameters["P_VIV_DOM"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_CLAVIVP", OracleDbType.Int32);
                        if (radioA1.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 1;
                        }
                        else if (radioA2.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 2;
                        }
                        else if (radioA3.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 3;
                        }
                        else if (radioA4.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 4;
                        }
                        else if (radioA5.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 5;
                        }
                        else if (radioA6.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 6;
                        }
                        else if (radioA7.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 7;
                        }
                        else
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_MOT_NOHAB", OracleDbType.Int32);
                        if (radioZ21.Checked == true)
                        {
                            miComando.Parameters["P_MOT_NOHAB"].Value = 1;
                        }
                        else if (radioZ22.Checked == true)
                        {
                            miComando.Parameters["P_MOT_NOHAB"].Value = 2;
                        }
                        else
                        {
                            miComando.Parameters["P_MOT_NOHAB"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_PISOS", OracleDbType.Int32);
                        if (radioB1.Checked == true)
                        {
                            miComando.Parameters["P_PISOS"].Value = 1;
                        }
                        else if (radioB2.Checked == true)
                        {
                            miComando.Parameters["P_PISOS"].Value = 2;
                        }
                        else if (radioB3.Checked == true)
                        {
                            miComando.Parameters["P_PISOS"].Value = 3;
                        }
                        else
                        {
                            miComando.Parameters["P_PISOS"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_CUADORM", OracleDbType.Int32);
                        if (tb_Ie21.Text != "")
                        {
                            miComando.Parameters["P_CUADORM"].Value = Convert.ToInt32(tb_Ie21.Text);
                        }
                        else
                        {
                            miComando.Parameters["P_CUADORM"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_TOTCUART", OracleDbType.Int32);
                        if (tb_Ie31.Text != "")
                        {
                            miComando.Parameters["P_TOTCUART"].Value = Convert.ToInt32(tb_Ie31.Text);
                        }
                        else
                        {
                            miComando.Parameters["P_TOTCUART"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_ELECTRICIDAD", OracleDbType.Int32);
                        if (RadioButtonList3.Items[0].Selected == true)
                        {
                            miComando.Parameters["P_ELECTRICIDAD"].Value = 1;
                        }
                        else if (RadioButtonList3.Items[1].Selected == true)
                        {
                            miComando.Parameters["P_ELECTRICIDAD"].Value = 3;
                        }
                        else
                        {
                            miComando.Parameters["P_ELECTRICIDAD"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_AGUA_ENTUBADA", OracleDbType.Int32);
                        if (radioC1.Checked == true)
                        {
                            miComando.Parameters["P_AGUA_ENTUBADA"].Value = 1;
                        }
                        else if (radioC2.Checked == true)
                        {
                            miComando.Parameters["P_AGUA_ENTUBADA"].Value = 2;
                        }
                        else if (radioC3.Checked == true)
                        {
                            miComando.Parameters["P_AGUA_ENTUBADA"].Value = 3;
                        }
                        else
                        {
                            miComando.Parameters["P_AGUA_ENTUBADA"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_ABA_AGUA", OracleDbType.Int32);
                        if (radioD1.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA"].Value = 1;
                        }
                        else if (radioD2.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA"].Value = 2;
                        }
                        else if (radioD3.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA"].Value = 3;
                        }
                        else if (radioD4.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA"].Value = 4;
                        }
                        else if (radioD5.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA"].Value = 5;
                        }
                        else if (radioD6.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA"].Value = 6;
                        }
                        else
                        {
                            miComando.Parameters["P_ABA_AGUA"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_ABA_AGUA_NO_ENTUBADA", OracleDbType.Int32);
                        if (radioE1.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA_NO_ENTUBADA"].Value = 1;
                        }
                        else if (radioE2.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA_NO_ENTUBADA"].Value = 2;
                        }
                        else if (radioE3.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA_NO_ENTUBADA"].Value = 3;
                        }
                        else if (radioE4.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA_NO_ENTUBADA"].Value = 4;
                        }
                        else if (radioE5.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA_NO_ENTUBADA"].Value = 5;
                        }
                        else if (radioE6.Checked == true)
                        {
                            miComando.Parameters["P_ABA_AGUA_NO_ENTUBADA"].Value = 6;
                        }
                        else
                        {
                            miComando.Parameters["P_ABA_AGUA_NO_ENTUBADA"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_SERSAN", OracleDbType.Int32);
                        if (radioG1.Checked == true)
                        {
                            miComando.Parameters["P_SERSAN"].Value = 1;
                        }
                        else if (radioG2.Checked == true)
                        {
                            miComando.Parameters["P_SERSAN"].Value = 2;
                        }
                        else if (radioG3.Checked == true)
                        {
                            miComando.Parameters["P_SERSAN"].Value = 3;
                        }
                        else
                        {
                            miComando.Parameters["P_SERSAN"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_CONAGUA", OracleDbType.Int32);
                        if (radioH1.Checked == true)
                        {
                            miComando.Parameters["P_CONAGUA"].Value = 1;
                        }
                        else if (radioH2.Checked == true)
                        {
                            miComando.Parameters["P_CONAGUA"].Value = 2;
                        }
                        else if (radioH3.Checked == true)
                        {
                            miComando.Parameters["P_CONAGUA"].Value = 3;
                        }
                        else
                        {
                            miComando.Parameters["P_CONAGUA"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_DRENAJE", OracleDbType.Int32);
                        if (radioI1.Checked == true)
                        {
                            miComando.Parameters["P_DRENAJE"].Value = 1;
                        }
                        else if (radioI2.Checked == true)
                        {
                            miComando.Parameters["P_DRENAJE"].Value = 2;
                        }
                        else if (radioI3.Checked == true)
                        {
                            miComando.Parameters["P_DRENAJE"].Value = 3;
                        }
                        else if (radioI4.Checked == true)
                        {
                            miComando.Parameters["P_DRENAJE"].Value = 4;
                        }
                        else if (radioI5.Checked == true)
                        {
                            miComando.Parameters["P_DRENAJE"].Value = 5;
                        }
                        else
                        {
                            miComando.Parameters["P_DRENAJE"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_REFRIGERADOR", OracleDbType.Int32);
                        if (radioZA1.Checked == true)
                        {
                            miComando.Parameters["P_REFRIGERADOR"].Value = 1;
                        }
                        else if (radioZA2.Checked == true)
                        {
                            miComando.Parameters["P_REFRIGERADOR"].Value = 2;
                        }
                        else
                        {
                            miComando.Parameters["P_REFRIGERADOR"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_LAVADORA", OracleDbType.Int32);
                        if (radioZB1.Checked == true)
                        {
                            miComando.Parameters["P_LAVADORA"].Value = 3;
                        }
                        else if (radioZB2.Checked == true)
                        {
                            miComando.Parameters["P_LAVADORA"].Value = 4;
                        }
                        else
                        {
                            miComando.Parameters["P_LAVADORA"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_HORNO", OracleDbType.Int32);
                        if (radioZC1.Checked == true)
                        {
                            miComando.Parameters["P_HORNO"].Value = 5;
                        }
                        else if (radioZC2.Checked == true)
                        {
                            miComando.Parameters["P_HORNO"].Value = 6;
                        }
                        else
                        {
                            miComando.Parameters["P_HORNO"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_AUTOPROP", OracleDbType.Int32);
                        if (radioZD1.Checked == true)
                        {
                            miComando.Parameters["P_AUTOPROP"].Value = 7;
                        }
                        else if (radioZD2.Checked == true)
                        {
                            miComando.Parameters["P_AUTOPROP"].Value = 8;
                        }
                        else
                        {
                            miComando.Parameters["P_AUTOPROP"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_RADIO", OracleDbType.Int32);
                        if (radioZE1.Checked == true)
                        {
                            miComando.Parameters["P_RADIO"].Value = 1;
                        }
                        else if (radioZE2.Checked == true)
                        {
                            miComando.Parameters["P_RADIO"].Value = 2;
                        }
                        else
                        {
                            miComando.Parameters["P_RADIO"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_TELEVISOR", OracleDbType.Int32);
                        if (radioZF1.Checked == true)
                        {
                            miComando.Parameters["P_TELEVISOR"].Value = 3;
                        }
                        else if (radioZF2.Checked == true)
                        {
                            miComando.Parameters["P_TELEVISOR"].Value = 4;
                        }
                        else
                        {
                            miComando.Parameters["P_TELEVISOR"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_TELEVISOR_PP", OracleDbType.Int32);
                        if (radioZG1.Checked == true)
                        {
                            miComando.Parameters["P_TELEVISOR_PP"].Value = 5;
                        }
                        else if (radioZG2.Checked == true)
                        {
                            miComando.Parameters["P_TELEVISOR_PP"].Value = 6;
                        }
                        else
                        {
                            miComando.Parameters["P_TELEVISOR_PP"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_COMPUTADORA", OracleDbType.Int32);
                        if (radioZH1.Checked == true)
                        {
                            miComando.Parameters["P_COMPUTADORA"].Value = 7;
                        }
                        else if (radioZH2.Checked == true)
                        {
                            miComando.Parameters["P_COMPUTADORA"].Value = 8;
                        }
                        else
                        {
                            miComando.Parameters["P_COMPUTADORA"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_TELEFONO", OracleDbType.Int32);
                        if (radioZI1.Checked == true)
                        {
                            miComando.Parameters["P_TELEFONO"].Value = 1;
                        }
                        else if (radioZI2.Checked == true)
                        {
                            miComando.Parameters["P_TELEFONO"].Value = 2;
                        }
                        else
                        {
                            miComando.Parameters["P_TELEFONO"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_CELULAR", OracleDbType.Int32);
                        if (radioZJ1.Checked == true)
                        {
                            miComando.Parameters["P_CELULAR"].Value = 3;
                        }
                        else if (radioZJ2.Checked == true)
                        {
                            miComando.Parameters["P_CELULAR"].Value = 4;
                        }
                        else
                        {
                            miComando.Parameters["P_CELULAR"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_INTERNET", OracleDbType.Int32);
                        if (radioZK1.Checked == true)
                        {
                            miComando.Parameters["P_INTERNET"].Value = 5;
                        }
                        else if (radioZK2.Checked == true)
                        {
                            miComando.Parameters["P_INTERNET"].Value = 6;
                        }
                        else
                        {
                            miComando.Parameters["P_INTERNET"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_SERV_TV_PAGA", OracleDbType.Int32);
                        if (radioZL1.Checked == true)
                        {
                            miComando.Parameters["P_SERV_TV_PAGA"].Value = 7;
                        }
                        else if (radioZL2.Checked == true)
                        {
                            miComando.Parameters["P_SERV_TV_PAGA"].Value = 8;
                        }
                        else
                        {
                            miComando.Parameters["P_SERV_TV_PAGA"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_MEDCAP", OracleDbType.Int32);
                        if (HttpContext.Current.Session["qr_viv"].ToString().Substring(0, 1) == "A")
                        {
                            miComando.Parameters["P_MEDCAP"].Value = 6;
                        }
                        else
                        {
                            miComando.Parameters["P_MEDCAP"].Value = 4;
                        }
                        int k = miComando.ExecuteNonQuery();
                        miComando.Dispose();
                    }
                    catch (Exception e1)
                    {
                        HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                    }
                    finally
                    {
                        conn6.Dispose();
                    }

                    break;
                case 8:
                    string oradb7 = ConfigurationManager.AppSettings["cai2020"];
                    OracleConnection conn7 = new OracleConnection(); // C#
                    conn7.ConnectionString = oradb7.ToString();
                    conn7.Open();
                    try
                    {
                        OracleCommand miComando = new OracleCommand();
                        miComando.Connection = conn7;
                        miComando.CommandText = "insert into CAP_INT_TR_VIVIENDA (QR_VIV,RES_DOM,VIV_DOM,CLAVIVP,MOT_NOHAB,MEDCAP) VALUES (:P_QR_VIV,:P_RES_DOM,:P_VIV_DOM,:P_CLAVIVP,:P_MOT_NOHAB,:P_MEDCAP)";
                        miComando.CommandType = CommandType.Text;
                        //Envio 2 parametros
                        miComando.Parameters.Add("P_QR_VIV", OracleDbType.NVarchar2);
                        miComando.Parameters["P_QR_VIV"].Value = HttpContext.Current.Session["qr_viv"].ToString();
                        miComando.Parameters.Add("P_RES_DOM", OracleDbType.Int32);
                        if (RadioButtonList2.Items[0].Selected == true)
                        {
                            miComando.Parameters["P_RES_DOM"].Value = 1;
                        }
                        else if (RadioButtonList2.Items[1].Selected == true)
                        {
                            miComando.Parameters["P_RES_DOM"].Value = 3;
                        }
                        else
                        {
                            miComando.Parameters["P_RES_DOM"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_VIV_DOM", OracleDbType.Int32);
                        if (tb_I031.Text != "")
                        {
                            miComando.Parameters["P_VIV_DOM"].Value = Convert.ToInt32(tb_I031.Text);
                        }
                        else
                        {
                            miComando.Parameters["P_VIV_DOM"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_CLAVIVP", OracleDbType.Int32);
                        if (radioA1.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 1;
                        }
                        else if (radioA2.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 2;
                        }
                        else if (radioA3.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 3;
                        }
                        else if (radioA4.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 4;
                        }
                        else if (radioA5.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 5;
                        }
                        else if (radioA6.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 6;
                        }
                        else if (radioA7.Checked == true)
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = 7;
                        }
                        else
                        {
                            miComando.Parameters["P_CLAVIVP"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_MOT_NOHAB", OracleDbType.Int32);
                        if (radioZ21.Checked == true)
                        {
                            miComando.Parameters["P_MOT_NOHAB"].Value = 1;
                        }
                        else if (radioZ22.Checked == true)
                        {
                            miComando.Parameters["P_MOT_NOHAB"].Value = 2;
                        }
                        else
                        {
                            miComando.Parameters["P_MOT_NOHAB"].Value = DBNull.Value;
                        }
                        miComando.Parameters.Add("P_MEDCAP", OracleDbType.Int32);
                        if (HttpContext.Current.Session["qr_viv"].ToString().Substring(0, 1) == "A")
                        {
                            miComando.Parameters["P_MEDCAP"].Value = 6;
                        }
                        else
                        {
                            miComando.Parameters["P_MEDCAP"].Value = 4;
                        }
                        int j = miComando.ExecuteNonQuery();
                        miComando.Dispose();
                    }
                    catch (Exception e1)
                    {
                        HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                    }
                    finally
                    {
                        conn7.Dispose();
                    }
                    break;
            }
        }
    }
}