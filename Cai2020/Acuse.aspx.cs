using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acuse
{
    public partial class Acuse : System.Web.UI.Page
    {
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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string num_cuartos = Request.QueryString["num_cuartos"];
            string hombres = Request.QueryString["hombres"];
            string mujeres = Request.QueryString["mujeres"];
                        
            lbfecha.Text = string.Format("{0} de {1} de {2}", DateTime.Now.ToString("d "), DateTime.Now.ToString("MMMM"), DateTime.Now.ToString("yyyy"));

            lbfolio.Text = id;
            lbcuartos.Text = num_cuartos;
            lbhombres.Text = hombres;
            lbmujeres.Text = mujeres;
        }
    }
}