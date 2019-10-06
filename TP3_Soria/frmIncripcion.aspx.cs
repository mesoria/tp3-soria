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
        NegocioPersona negocioPersona = new NegocioPersona();
        Persona aux = new Persona();
        private bool Completed(string text)
        {
            return text.ToString().Trim() != "";
        }
        private Persona BuildPerson()
        {
            aux.nombre = Nombre.Text;
            aux.nombre = Apellido.Text;
            aux.nombre = DNI.Text;
            aux.nombre = Email.Text;
            aux.nombre = Direccion.Text;
            aux.nombre = Ciudad.Text;
            aux.nombre = CP.Text;
            DateTime hoy = DateTime.Now;

            aux.fechaRegistro = hoy;   //"aaaa/mm/dd");  //Format(hoy.ToShortDateString(), "aaaa/mm/dd");
            return aux;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if ( Completed(DNI.Text) && Completed(Nombre.Text) && Completed(Apellido.Text) && Completed(Email.Text) && Completed(Direccion.Text) && Completed(Ciudad.Text) && Completed(CP.Text))
            {
                aux = BuildPerson();
                negocioPersona.Agregar(aux);
            }
            else
            {

            }
        }

    }
}