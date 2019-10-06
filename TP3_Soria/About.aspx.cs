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
        public List<Producto> Productos{ get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                NegocioVoucher negocioV = new NegocioVoucher();
                grid.DataSource = negocioV.ListarVouchers();
                grid.DataBind();
                NegocioProducto negocioP = new NegocioProducto();
                Productos = negocioP.ListarProductos();
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
                NegocioVoucher negocioVoucher = new NegocioVoucher();
                var code = CodigoVoucher.Value;
                Voucher voucher = negocioVoucher.BuscarVouchers(code);
                if (voucher.Code != null)
                {
                    Response.Redirect("/frmIncripcion.aspx");
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