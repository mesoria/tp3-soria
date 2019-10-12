using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP3_Soria
{
    public partial class Premios : System.Web.UI.Page
    {
        private readonly NegocioProducto NegocioProducto = new NegocioProducto();
        public List<Producto> Productos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Productos = NegocioProducto.ListarProductos();
                }
                catch (Exception ex)
                {
                    Session["Error" + Session.SessionID] = ex;
                    Response.Redirect("frmLog.aspx");
                }
            }
        }
    }
}