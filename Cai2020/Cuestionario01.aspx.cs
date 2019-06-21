using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cai2020
{
    public partial class Cuestionario01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(Button1);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ExpiresAbsolute = DateTime.Now.AddMonths(-1);
            if (!IsPostBack)
            {
                Tbxoper01.BackColor = System.Drawing.Color.LightSteelBlue;
                Tbxoper01.Focus();
            }
        }
    }
}