using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataMaster;
using Dominio;
using Negocio;

namespace TP3_Soria
{
    public partial class frmIncripcion : System.Web.UI.Page
    {
        Datos datos = new Datos();
        NegocioCliente NegocioCliente = new NegocioCliente();
        NegocioVoucher NegocioVoucher = new NegocioVoucher();
        Cliente cliente = new Cliente();
        Voucher voucher = new Voucher();
        private bool Completed(string text)
        {
            return text.ToString().Trim() != "";
        }
        private Cliente BuildPerson()
        {
            cliente.DNI         = Convert.ToInt32(DNI.Text);
            cliente.nombre      = Nombre.Text;
            cliente.apellido    = Apellido.Text;
            cliente.email       = Email.Text;
            cliente.direccion   = Direccion.Text;
            cliente.ciudad      = Ciudad.Text;
            cliente.CP          = CP.Text;
            DateTime hoy    = DateTime.Now;

            cliente.fechaRegistro = hoy;   //"aaaa/mm/dd");  //Format(hoy.ToShortDateString(), "aaaa/mm/dd");
            return cliente;
        }
        private void SetPerson(Cliente cliente)
        {
            Nombre.Text     = cliente.nombre;
            Apellido.Text   = cliente.apellido;
            Email.Text      = cliente.email;
            Direccion.Text  = cliente.direccion;
            Ciudad.Text     = cliente.ciudad;
            CP.Text         = cliente.CP;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            voucher = (Voucher)Session["Voucher" + Session.SessionID];
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if ( Completed(DNI.Text) && Completed(Nombre.Text) && Completed(Apellido.Text) && Completed(Email.Text) && Completed(Direccion.Text) && Completed(Ciudad.Text) && Completed(CP.Text))
            {
                try
                {
                    cliente = BuildPerson();
                    Cliente aux = NegocioCliente.GetCliente(Convert.ToInt32(DNI.Text));
                    if ( aux.ID == 0)
                    {
                        NegocioCliente.Agregar(cliente);
                    }
                    cliente = NegocioCliente.GetCliente(Convert.ToInt32(cliente.DNI.ToString()));
                    voucher.CodeCliente = cliente.ID;
                    voucher.Estado = true;
                    DateTime hoy = DateTime.Now;
                    voucher.Fecha = hoy;
                    NegocioVoucher.Modificar(voucher);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }
        }

        protected void DNI_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (DNI.Text.Length > 8)
                {
                    DNI.Text = DNI.Text.Substring(0, 8);
                }
                if (NegocioCliente.GetID(Convert.ToInt32( DNI.Text)) != 0)
                {
                    cliente = NegocioCliente.GetCliente(Convert.ToInt32(DNI.Text));
                    SetPerson(cliente);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}