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
        NegocioCliente negocioCliente = new NegocioCliente();
        Cliente aux = new Cliente();
        private bool Completed(string text)
        {
            return text.ToString().Trim() != "";
        }
        private Cliente BuildPerson()
        {
            aux.DNI         = Convert.ToInt32(DNI.Text);
            aux.nombre      = Nombre.Text;
            aux.apellido    = Apellido.Text;
            aux.email       = Email.Text;
            aux.direccion   = Direccion.Text;
            aux.ciudad      = Ciudad.Text;
            aux.CP          = CP.Text;
            DateTime hoy    = DateTime.Now;

            aux.fechaRegistro = hoy;   //"aaaa/mm/dd");  //Format(hoy.ToShortDateString(), "aaaa/mm/dd");
            return aux;
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

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if ( Completed(DNI.Text) && Completed(Nombre.Text) && Completed(Apellido.Text) && Completed(Email.Text) && Completed(Direccion.Text) && Completed(Ciudad.Text) && Completed(CP.Text))
            {
                try
                {
                    aux = BuildPerson();
                    negocioCliente.Agregar(aux);
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
                
                if (negocioCliente.GetID(Convert.ToInt32( DNI.Text)) != 0)
                {
                    aux = negocioCliente.GetCliente(Convert.ToInt32(DNI.Text));
                    SetPerson(aux);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}