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
    public partial class About : Page
    {
        private readonly NegocioVoucher NegocioVoucher = new NegocioVoucher();
        private readonly NegocioProducto NegocioP = new NegocioProducto();
        public List<Producto> Productos{ get; set; }
        public Producto producto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var prodSeleccionado = Convert.ToInt32(Request.QueryString["idprd"]);
                Productos = NegocioP.ListarProductos();
                producto  = Productos.Find(J => J.ID == prodSeleccionado);

                //grid.DataSource = NegocioVoucher.ListarVouchers();
                //grid.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void ValidarVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                var code = CodigoVoucher.Value;
                Voucher voucher = NegocioVoucher.BuscarVouchers(code);
                if (voucher.Code != null)
                {
                    Response.Redirect("/Inscripcion.aspx");
                }
                else
                {
                    Response.Redirect("/Default.aspx");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}