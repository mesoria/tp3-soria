using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMaster;
using Dominio;

namespace Negocio
{
    public class NegocioCliente
    {
        public List<Cliente> ListarClientes()
        {
            Datos datos = new Datos(); 
            List<Cliente> clientes = new List<Cliente>();
            Cliente aux;
            try
            {
                datos.SetearConsulta("Select Id, DNI, Nombre, Apellido, Email, Direccion, Ciudad, CodigoPostal, FechaRegistro from SORIA_TP3.dbo.CLIENTES");
                datos.AbrirConexion();
                datos.EjecutarConsulta();
                while (datos.Reader.Read())
                {
                    aux = new Cliente();
                    aux.ID              = (Int64)datos.Reader[0];
                    aux.DNI             = (Int32)datos.Reader[1];
                    aux.nombre          = (string)datos.Reader[2];
                    aux.apellido        = (string)datos.Reader[3];
                    aux.email           = (string)datos.Reader[4];
                    aux.direccion       = (string)datos.Reader[5];
                    aux.ciudad          = (string)datos.Reader[6];
                    aux.CP              = (string)datos.Reader[7];
                    aux.fechaRegistro   = (DateTime)datos.Reader[8];
                    clientes.Add(aux);
                }
                    return clientes;
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


        public void Agregar(Cliente cliente)
        {
            Datos datos = new Datos();
            try
            {
                if (this.GetID( Convert.ToInt32(cliente.DNI)) == 0)
                {
                    datos.SetearConsulta("insert into SORIA_TP3.dbo.CLIENTES (DNI,Nombre,Apellido,Email,Direccion,Ciudad,CodigoPostal,FechaRegistro) values (@DNI, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP, @FR)");
                    datos.Comando.Parameters.Clear();
                    datos.Comando.Parameters.AddWithValue("@DNI",       cliente.DNI.ToString());
                    datos.Comando.Parameters.AddWithValue("@Nombre",    cliente.nombre.ToString());
                    datos.Comando.Parameters.AddWithValue("@Apellido",  cliente.apellido.ToString());
                    datos.Comando.Parameters.AddWithValue("@Email",     cliente.email.ToString());
                    datos.Comando.Parameters.AddWithValue("@Direccion", cliente.direccion.ToString());
                    datos.Comando.Parameters.AddWithValue("@Ciudad",    cliente.ciudad.ToString());
                    datos.Comando.Parameters.AddWithValue("@CP",        cliente.CP.ToString());
                    datos.Comando.Parameters.AddWithValue("@FR",        cliente.fechaRegistro);
                    datos.AbrirConexion();
                    datos.EjecutarAccion();
                }
                else
                {
                    //ya existe una cliente con ese DNI. Deberia hacer un Trigger o un procedimiento almacenado. Mas por lo del voucher pero no se... Voy a lo "seguro".
                }
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
        public Int64 GetID(int DNI)
        {
            Datos datos = new Datos();
            try
            {
                datos.SetearConsulta("Select Id, DNI, Nombre, Apellido, Email, Direccion, Ciudad, CodigoPostal, FechaRegistro from SORIA_TP3.dbo.CLIENTES WHERE DNI=@DNI");
                datos.Comando.Parameters.Clear();
                datos.Comando.Parameters.AddWithValue("@DNI", DNI);
                datos.AbrirConexion();
                datos.EjecutarConsulta();
                while (datos.Reader.Read())
                {
                    return (Int64)datos.Reader[0];
                }
                return 0;
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
        public Cliente GetCliente(int DNI)
        {
            Datos datos = new Datos();
            try
            {
                datos.SetearConsulta("Select Id, DNI, Nombre, Apellido, Email, Direccion, Ciudad, CodigoPostal, FechaRegistro from SORIA_TP3.dbo.CLIENTES WHERE DNI=@DNI");
                datos.Comando.Parameters.Clear();
                datos.Comando.Parameters.AddWithValue("@DNI", DNI);
                datos.AbrirConexion();
                datos.EjecutarConsulta();
                Cliente cliente = new Cliente();
                while (datos.Reader.Read())
                {
                    cliente.ID          = (Int64)datos.Reader[0];
                    cliente.DNI         = (int)datos.Reader[1];
                    cliente.nombre      = (string)datos.Reader[2];
                    cliente.apellido    = (string)datos.Reader[3];
                    cliente.email       = (string)datos.Reader[4];
                    cliente.direccion   = (string)datos.Reader[5];
                    cliente.ciudad      = (string)datos.Reader[6];
                    cliente.CP          = (string)datos.Reader[7];
                    cliente.fechaRegistro = (DateTime)datos.Reader[8];
                }
                return cliente;
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


        public void Modificar(Cliente cliente)
        {
            Datos datos = new Datos();
            try
            {
                datos.SetearConsulta("update SORIA_TP3.dbo.CLIENTES Set DNI=@DNI, Nombre=@Nombre, Apellido=@Apellido, Email=@Email, " +
                    "Direccion=@Direccion, Ciudad=@Ciudad, CodigoPostal=@CP, FechaRegistro=FechaRegistro Where ID=" + cliente.ID);
                datos.Comando.Parameters.Clear();
                datos.Comando.Parameters.AddWithValue("@DNI",           cliente.DNI);
                datos.Comando.Parameters.AddWithValue("@Nombre",        cliente.nombre);
                datos.Comando.Parameters.AddWithValue("@Apellido",      cliente.apellido.ToString());
                datos.Comando.Parameters.AddWithValue("@Email",         cliente.email.ToString());
                datos.Comando.Parameters.AddWithValue("@Direccion",     cliente.direccion.ToString());
                datos.Comando.Parameters.AddWithValue("@Ciudad",        cliente.ciudad.ToString());
                datos.Comando.Parameters.AddWithValue("@CP",            cliente.CP.ToString());
                datos.Comando.Parameters.AddWithValue("@FechaRegistro", cliente.fechaRegistro);
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
                datos.SetearConsulta("delete from SORIA_TP3.dbo.CLIENTES where Id =" + id);
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
