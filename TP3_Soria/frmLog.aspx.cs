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
            string mensaje;
            if (Session["Error" + Session.SessionID] == null)
            {
                mensaje = "Ups, No deberías estar aquí.";
            }
            else if ((int)Session["Error" + Session.SessionID] == 0)
            {
                mensaje = (string)Session["Usuario" + Session.SessionID];
                mensaje = (string)Session["UsuarioCompletado" + Session.SessionID];
            }
            else
            {
                mensaje = (string)Session["Error" + Session.SessionID];
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Inscripcion.aspx");
        }
    }
}