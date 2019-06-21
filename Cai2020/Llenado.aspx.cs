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
    public partial class Llenado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string oradb = ConfigurationManager.AppSettings["cai2020"];
            OracleConnection conn = new OracleConnection(); // C#
            conn.ConnectionString = oradb.ToString();
            try
            {
                int h = 0;
                int m = 0;
                int c = 0;
                string tiempo = "";
                conn.Open();
                OracleCommand cmd1 = new OracleCommand();
                cmd1.Connection = conn;
                cmd1.CommandText = "select sexo from CAP_INT_TR_PERSONA where qr_viv = '" + HttpContext.Current.Session["qr_viv"].ToString() + "'";
                cmd1.CommandType = CommandType.Text;
                OracleDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    if (dr1["SEXO"].ToString() == "1")
                    {
                        h++;
                    }
                    if (dr1["SEXO"].ToString() == "3")
                    {
                        m++;
                    }
                }
                dr1.Dispose();
                cmd1.Dispose();
                OracleCommand cmd2 = new OracleCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "select NVL(TOTCUART,0) AS CUARTOS from CAP_INT_TR_VIVIENDA where qr_viv = '" + HttpContext.Current.Session["qr_viv"].ToString() + "'";
                cmd2.CommandType = CommandType.Text;
                OracleDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                        c = Convert.ToInt32(dr2[0].ToString());
                }
                dr2.Dispose();
                cmd2.Dispose();
                OracleCommand cmd3 = new OracleCommand();
                cmd3.Connection = conn;
                cmd3.CommandText = "select FECHA from CAP_INT_TH_LLENADO where qr_viv = '" + HttpContext.Current.Session["qr_viv"].ToString() + "'";
                cmd3.CommandType = CommandType.Text;
                OracleDataReader dr3 = cmd3.ExecuteReader();
                while (dr3.Read())
                {
                    tiempo = dr3["FECHA"].ToString();
                }
                dr3.Dispose();
                cmd3.Dispose();
                string nuevaUrl = string.Format("Acuse.aspx?id={0}&num_cuartos={1}&hombres={2}&mujeres={3}", HttpContext.Current.Session["qr_viv"].ToString() + tiempo.Substring(0,2).ToString() + tiempo.Substring(3, 2).ToString() + tiempo.Substring(11, 2).ToString() + tiempo.Substring(14, 2).ToString() + tiempo.Substring(17, 2).ToString(), c, h, m);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function () {window.open('" + nuevaUrl + "','_self');});", true);
            }
            catch (Exception e1)
            {
                HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
            }
            finally
            {
                conn.Dispose();
            }
        }
    }
}