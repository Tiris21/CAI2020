using System;
using System.Web;
using System.Web.UI.HtmlControls;


namespace Cai2020
{
    public partial class Mapas01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //se debe de cambiar el body para que se ejecute el codigo de cuestionarios dentro del Site.Master
            HtmlGenericControl body = this.Master.FindControl("body") as HtmlGenericControl;
            TextBox1.Text = "";
            body.Attributes.Add("onLoad", "medio();");
        }
    }
}