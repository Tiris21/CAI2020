using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;

namespace Cai2020
{
    public partial class Default_cat : System.Web.UI.Page
    {
        #region web Services GetContent
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string GetContent(string contextKey)
        {
            //return "<strong>" + contextKey + "</strong>";
            return "";
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string oradb1 = ConfigurationManager.AppSettings["cai2020"];
                OracleConnection conn1 = new OracleConnection(); // C#
                conn1.ConnectionString = oradb1.ToString();
                conn1.Open();
                try
                {
                    OracleCommand miComando1 = new OracleCommand();
                    miComando1.Connection = conn1;
                    miComando1.CommandText = "insert into CAP_INT_TH_BITACORA_CAT (USUARIO) VALUES ('" + HttpContext.Current.Session["UserName"].ToString() + "')";
                    miComando1.CommandType = CommandType.Text;
                    int i = miComando1.ExecuteNonQuery();
                    miComando1.Dispose();
                }
                catch (Exception e1)
                {
                    HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                }
                finally
                {
                    conn1.Dispose();
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_qr_viv.Text) && string.IsNullOrEmpty(tb_contra_viv.Text))
            {
                if (string.IsNullOrEmpty(tb_etiqueta.Text))
                {
                    if (string.IsNullOrEmpty(tb_entidad.Text) || string.IsNullOrEmpty(tb_municipio.Text) || string.IsNullOrEmpty(tb_localidad.Text) || string.IsNullOrEmpty(tb_calle.Text) || string.IsNullOrEmpty(tb_numext.Text) || string.IsNullOrEmpty(tb_numint.Text) || string.IsNullOrEmpty(tb_colonia.Text))
                    {
                        Label17.Text = "Aviso";
                        Label10.Text = "No debe dejar los campos vacios para continuar";
                        programmaticModalPopup.Show();
                    }
                    else
                    {
                        string oradb = ConfigurationManager.AppSettings["cai2020"];
                        OracleConnection conn = new OracleConnection(); // C#
                        conn.ConnectionString = oradb.ToString();
                        try
                        {
                            conn.Open();
                            OracleCommand cmd1 = new OracleCommand();
                            cmd1.Connection = conn;
                            cmd1.CommandText = "SELECT USUARIO,ACTIVO FROM CAP_INT_TH_CAT WHERE ACTIVO IS NULL ";
                            cmd1.CommandType = CommandType.Text;
                            OracleDataReader dr1 = cmd1.ExecuteReader();
                            if (dr1.Read())
                            {
                                Session["qr_viv"] = dr1["USUARIO"].ToString();
                                string oradb4 = ConfigurationManager.AppSettings["cai2020"];
                                OracleConnection conn4 = new OracleConnection(); // C#
                                conn4.ConnectionString = oradb4.ToString();
                                conn4.Open();
                                try
                                {
                                    OracleCommand miComando = new OracleCommand();
                                    miComando.Connection = conn4;
                                    miComando.CommandText = "update CAP_INT_TH_CAT set ACTIVO = '1' where USUARIO = :usr";
                                    miComando.CommandType = CommandType.Text;
                                    miComando.Parameters.Add("usr", OracleDbType.NVarchar2);
                                    miComando.Parameters["usr"].Value = dr1["USUARIO"].ToString();
                                    int k = miComando.ExecuteNonQuery();
                                    miComando.Dispose();
                                }
                                catch (Exception e1)
                                {
                                    HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                                }
                                finally
                                {
                                    conn4.Dispose();
                                }
                                string oradb41 = ConfigurationManager.AppSettings["cai2020"];
                                OracleConnection conn41 = new OracleConnection(); // C#
                                conn41.ConnectionString = oradb41.ToString();
                                conn41.Open();
                                try
                                {
                                    OracleCommand miComando1 = new OracleCommand();
                                    miComando1.Connection = conn41;
                                    miComando1.CommandText = "insert into CAP_INT_TH_INGRESO_CAT (USUARIO,ENTIDAD,MUNICIPIO,LOCALIDAD,COLONIA,CALLE,NOINT,NOEXT,QR_CAT) values ('" + HttpContext.Current.Session["UserName"].ToString() + "',:entidad,:municipio,:localidad,:colonia,:calle,:noint,:noext,:qrcat)";
                                    miComando1.CommandType = CommandType.Text;
                                    miComando1.Parameters.Add("entidad", OracleDbType.NVarchar2);
                                    miComando1.Parameters["entidad"].Value = tb_entidad.Text;
                                    miComando1.Parameters.Add("municipio", OracleDbType.NVarchar2);
                                    miComando1.Parameters["municipio"].Value = tb_municipio.Text;
                                    miComando1.Parameters.Add("localidad", OracleDbType.NVarchar2);
                                    miComando1.Parameters["localidad"].Value = tb_localidad.Text;
                                    miComando1.Parameters.Add("colonia", OracleDbType.NVarchar2);
                                    miComando1.Parameters["colonia"].Value = tb_colonia.Text;
                                    miComando1.Parameters.Add("calle", OracleDbType.NVarchar2);
                                    miComando1.Parameters["calle"].Value = tb_calle.Text;
                                    miComando1.Parameters.Add("noint", OracleDbType.NVarchar2);
                                    miComando1.Parameters["noint"].Value = tb_numext.Text;
                                    miComando1.Parameters.Add("noext", OracleDbType.NVarchar2);
                                    miComando1.Parameters["noext"].Value = tb_numint.Text;
                                    miComando1.Parameters.Add("qrcat", OracleDbType.NVarchar2);
                                    miComando1.Parameters["qrcat"].Value = dr1["USUARIO"].ToString();
                                    int k1 = miComando1.ExecuteNonQuery();
                                    miComando1.Dispose();
                                }
                                catch (Exception e1)
                                {
                                    HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                                }
                                finally
                                {
                                    conn41.Dispose();
                                }
                            }
                            dr1.Dispose();
                            cmd1.Dispose();
                            conn.Dispose();
                            Response.Redirect("CuestionarioVivienda.aspx");
                        }
                        catch (Exception e1)
                        {
                            HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                            conn.Dispose();
                        }
                        finally
                        {
                            
                        }
                    }
                }
                else
                {
                    string oradb = ConfigurationManager.AppSettings["cai2020"];
                    OracleConnection conn = new OracleConnection(); // C#
                    conn.ConnectionString = oradb.ToString();
                    int op1 = 0;
                    try
                    {
                        conn.Open();
                        //EVALUAR SI YA SE TIENEN REGISTROS GUARDADOS LA LISTA
                        OracleCommand cmd1 = new OracleCommand();
                        cmd1.Connection = conn;
                        OracleParameter myParam1 = cmd1.CreateParameter();
                        myParam1.OracleDbType = OracleDbType.NVarchar2;
                        myParam1.Value = tb_etiqueta.Text;
                        myParam1.ParameterName = "usr";
                        cmd1.Parameters.Add(myParam1);
                        cmd1.CommandText = "SELECT QR_VIV FROM CAP_INT_TH_LLENADO where QR_VIV = :usr";
                        cmd1.CommandType = CommandType.Text;
                        OracleDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            Label17.Text = "Aviso";
                            Label10.Text = "Esa etiqueta ya contiene cuestionario registrado";
                            programmaticModalPopup.Show();
                        }
                        else
                        {
                            OracleCommand cmd2 = new OracleCommand();
                            cmd2.Connection = conn;
                            OracleParameter myParam3 = cmd2.CreateParameter();
                            myParam3.OracleDbType = OracleDbType.NVarchar2;
                            myParam3.Value = tb_etiqueta.Text;
                            myParam3.ParameterName = "usr";
                            cmd2.Parameters.Add(myParam3);
                            cmd2.CommandText = "SELECT USUARIO FROM CAP_INT_TH_ETIQUETA where USUARIO = :usr";
                            cmd2.CommandType = CommandType.Text;
                            OracleDataReader dr2 = cmd2.ExecuteReader();
                            if (dr2.Read())
                            {
                                Session["qr_viv"] = dr2["USUARIO"].ToString();
                                string oradb41 = ConfigurationManager.AppSettings["cai2020"];
                                OracleConnection conn41 = new OracleConnection(); // C#
                                conn41.ConnectionString = oradb41.ToString();
                                conn41.Open();
                                try
                                {
                                    OracleCommand miComando1 = new OracleCommand();
                                    miComando1.Connection = conn41;
                                    miComando1.CommandText = "insert into CAP_INT_TH_INGRESO_CAT (USUARIO,ETIQUETA) values ('" + HttpContext.Current.Session["UserName"].ToString() + "',:etiqueta)";
                                    miComando1.CommandType = CommandType.Text;
                                    miComando1.Parameters.Add("etiqueta", OracleDbType.NVarchar2);
                                    miComando1.Parameters["etiqueta"].Value = dr2["USUARIO"].ToString();
                                    int k1 = miComando1.ExecuteNonQuery();
                                    miComando1.Dispose();
                                }
                                catch (Exception e1)
                                {
                                    HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                                }
                                finally
                                {
                                    conn41.Dispose();
                                }
                                op1 = 1;
                            }
                            else
                            {
                                Label17.Text = "Aviso";
                                Label10.Text = "Código de etiqueta no valido";
                                programmaticModalPopup.Show();
                            }
                            dr2.Dispose();
                            cmd2.Dispose();
                        }
                        dr1.Dispose();
                        cmd1.Dispose();

                    }
                    catch (Exception e1)
                    {
                        HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                    }
                    finally
                    {
                        conn.Dispose();
                    }
                    if (op1 == 1)
                    {
                        Response.Redirect("CuestionarioVivienda.aspx");
                    }
                }
            }
            else
            {
                string oradb = ConfigurationManager.AppSettings["cai2020"];
                OracleConnection conn = new OracleConnection(); // C#
                conn.ConnectionString = oradb.ToString();
                int op = 0;
                try
                {
                    conn.Open();
                    //EVALUAR SI YA SE TIENEN REGISTROS GUARDADOS LA LISTA
                    OracleCommand cmd1 = new OracleCommand();
                    cmd1.Connection = conn;
                    OracleParameter myParam1 = cmd1.CreateParameter();
                    myParam1.OracleDbType = OracleDbType.NVarchar2;
                    myParam1.Value = tb_qr_viv.Text;
                    myParam1.ParameterName = "usr";
                    cmd1.Parameters.Add(myParam1);
                    cmd1.CommandText = "SELECT QR_VIV FROM CAP_INT_TH_LLENADO where QR_VIV = :usr";
                    cmd1.CommandType = CommandType.Text;
                    OracleDataReader dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        Label17.Text = "Aviso";
                        Label10.Text = "Esa clave de invitación ya contiene cuestionario registrado";
                        programmaticModalPopup.Show();
                    }
                    else
                    {
                        OracleCommand cmd2 = new OracleCommand();
                        cmd2.Connection = conn;
                        OracleParameter myParam3 = cmd2.CreateParameter();
                        myParam3.OracleDbType = OracleDbType.NVarchar2;
                        myParam3.Value = tb_qr_viv.Text;
                        myParam3.ParameterName = "usr";
                        cmd2.Parameters.Add(myParam3);
                        OracleParameter myParam4 = cmd2.CreateParameter();
                        myParam4.OracleDbType = OracleDbType.NVarchar2;
                        myParam4.Value = tb_contra_viv.Text;
                        myParam4.ParameterName = "contra";
                        cmd2.Parameters.Add(myParam4);
                        cmd2.CommandText = "SELECT USUARIO,CONTRASENA FROM CAP_INT_TC_USUARIO where USUARIO = :usr and CONTRASENA = :contra";
                        cmd2.CommandType = CommandType.Text;
                        OracleDataReader dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                        {
                            Session["qr_viv"] = dr2["USUARIO"].ToString();
                            string oradb41 = ConfigurationManager.AppSettings["cai2020"];
                            OracleConnection conn41 = new OracleConnection(); // C#
                            conn41.ConnectionString = oradb41.ToString();
                            conn41.Open();
                            try
                            {
                                OracleCommand miComando1 = new OracleCommand();
                                miComando1.Connection = conn41;
                                miComando1.CommandText = "insert into CAP_INT_TH_INGRESO_CAT (USUARIO,QR_VIV) values ('" + HttpContext.Current.Session["UserName"].ToString() + "',:qrviv)";
                                miComando1.CommandType = CommandType.Text;
                                miComando1.Parameters.Add("qrviv", OracleDbType.NVarchar2);
                                miComando1.Parameters["qrviv"].Value = dr2["USUARIO"].ToString();
                                int k1 = miComando1.ExecuteNonQuery();
                                miComando1.Dispose();
                            }
                            catch (Exception e1)
                            {
                                HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                            }
                            finally
                            {
                                conn41.Dispose();
                            }
                            op = 1;
                        }
                        else
                        {
                            Label17.Text = "Aviso";
                            Label10.Text = "Usuario o contraseña de invitación incorrectos";
                            programmaticModalPopup.Show();
                        }
                        dr2.Dispose();
                        cmd2.Dispose();
                    }
                    dr1.Dispose();
                    cmd1.Dispose();
                }
                catch (Exception e1)
                {
                    HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                }
                finally
                {
                    conn.Dispose();
                }
                if (op == 1)
                {
                    Response.Redirect("CuestionarioVivienda.aspx");
                }
            }
        }
    }
}