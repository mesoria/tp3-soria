using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMaster;
using Dominio;

namespace Negocio
{
    public class NegocioPersona
    {
        public List<Persona> ListarPersonas()
        {
            Datos datos = new Datos(); 
            List<Persona> personas = new List<Persona>();
            Persona aux;
            try
            {
                datos.SetearConsulta("Select Id, DNI, Nombre, Apellido, Email, Direccion, Ciudad, CodigoPostal, FechaRegistro from PERSONAS");
                datos.AbrirConexion();
                datos.EjecutarConsulta();
                while (datos.Reader.Read())
                {
                    aux = new Persona();
                    aux.ID              = (Int32)datos.Reader[0];
                    aux.DNI             = (string)datos.Reader[1];
                    aux.nombre          = (string)datos.Reader[2];
                    aux.apellido        = (string)datos.Reader[3];
                    aux.email           = (string)datos.Reader[4];
                    aux.direccion       = (string)datos.Reader[5];
                    aux.ciudad          = (string)datos.Reader[6];
                    aux.CP              = (string)datos.Reader[7];
                    aux.fechaRegistro   = (DateTime)datos.Reader[8];
                    personas.Add(aux);
                }
                    return personas;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }


        public void Agregar(Persona persona)
        {
            Datos datos = new Datos();
            try
            {
                datos.SetearConsulta("insert into PERSONAS values (@DNI, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CodigoPostal, @FechaRegistro)");
                datos.Comando.Parameters.Clear();
                datos.Comando.Parameters.AddWithValue("@Codigo", persona.DNI.ToString());
                datos.Comando.Parameters.AddWithValue("@Nombre", persona.nombre.ToString());
                datos.Comando.Parameters.AddWithValue("@Apellido", persona.apellido.ToString());
                datos.Comando.Parameters.AddWithValue("@Email", persona.email.ToString());
                datos.Comando.Parameters.AddWithValue("@Direccion", persona.direccion.ToString());
                datos.Comando.Parameters.AddWithValue("@Ciudad", persona.ciudad.ToString());
                datos.Comando.Parameters.AddWithValue("@CodigoPostal", persona.CP.ToString());
                datos.Comando.Parameters.AddWithValue("@FechaRegistro", persona.fechaRegistro);
                datos.AbrirConexion();
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        
        public void Modificar(Persona persona)
        {
            Datos datos = new Datos();
            try
            {
                datos.SetearConsulta("update PERSONAS Set DNI=@DNI, Nombre=@Nombre, Apellido=@Apellido, Email=@Email, " +
                    "Direccion=@Direccion, Ciudad=@Ciudad, CodigoPostal=@CP, FechaRegistro=FechaRegistro Where ID=" + persona.ID);
                datos.Comando.Parameters.Clear();
                datos.Comando.Parameters.AddWithValue("@DNI",       persona.DNI.ToString());
                datos.Comando.Parameters.AddWithValue("@Nombre",    persona.nombre.ToString());
                datos.Comando.Parameters.AddWithValue("@Apellido",  persona.apellido.ToString());
                datos.Comando.Parameters.AddWithValue("@Email",     persona.email.ToString());
                datos.Comando.Parameters.AddWithValue("@Direccion", persona.direccion.ToString());
                datos.Comando.Parameters.AddWithValue("@Ciudad",    persona.ciudad.ToString());
                datos.Comando.Parameters.AddWithValue("@CP",        persona.CP.ToString());
                datos.Comando.Parameters.AddWithValue("@FechaRegistro", persona.fechaRegistro);
                datos.AbrirConexion();
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        
        public void Eliminar(int id)
        {
            Datos datos = new Datos();
            try
            {
                datos.SetearConsulta("delete from PERSONAS where Id =" + id);
                datos.AbrirConexion();
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
