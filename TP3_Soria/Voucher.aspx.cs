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
        int prodSeleccionado;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ( Request.QueryString["idprd"] == null )
                {
                    //por si accede a la pagina con el link
                    Session["Error" + Session.SessionID] = "Ups, Aún no has seleccionado un producto.";
                    Response.Redirect("/frmLog.aspx");
                }
                prodSeleccionado = Convert.ToInt32(Request.QueryString["idprd"]);
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
                    if( !voucher.Estado )
                    {
                        voucher.CodeProducto = producto.ID;
                        Session["Voucher" + Session.SessionID] = voucher;
                        Response.Redirect("/Inscripcion.aspx");
                    }
                    else
                    {

                        //El voucher existe pero esta usado.
                        Session["Error" + Session.SessionID] = "Ups, Este Voucher ya fue ingresado.";
                        Response.Redirect("frmLog.aspx");
                    }
                }
                else
                {
                    Session["Error" + Session.SessionID] = "Ups, Este código de Voucher no existe.";
                    Response.Redirect("frmLog.aspx");
                    /*
                    lblModalTitle.Text = "Voucher no encontrado";
                    lblModalBody.Text = "El código " + code + " ingresado no corresponde a un voucher válido, existente o disponible.";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                    Response.Redirect("/Premios.aspx");//No existe ese voucher.
                    */
                }
            }
            catch (Exception ex)
            {
                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("frmLog.aspx");
            }
        }
    }
}