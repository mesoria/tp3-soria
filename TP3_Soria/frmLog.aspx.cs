using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP3_Soria
{
    public partial class frmLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            /*
            if (!IsPostBack)
            {
                try
                {
                    var session = Session["Error" + Session.SessionID];
                    if ( session == null)
                    {
                        logInfo.Text = "Ups, No deberías estar aquí.";
                    }
                    else if ( session.ToString() == "0")
                    {
                        logInfo.Text = Session["Usuario" + Session.SessionID].ToString();
                        logInfo.Text = Session["UsuarioCompletado" + Session.SessionID].ToString();
                    }
                    else
                    {
                        logInfo.Text = Session["Error" + Session.SessionID].ToString();
                    }
                }
                catch (Exception ex)
                {
                    Session["Error" + Session.SessionID] = ex;
                    Response.Redirect("/Premios.aspx");
                }
            }
            */
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Premios.aspx");
        }
    }
}