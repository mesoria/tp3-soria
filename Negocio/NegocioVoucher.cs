using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMaster;
using Dominio;

namespace Negocio
{
    public class NegocioVoucher
    {
        public Voucher BuscarVouchers(string code)
        {
            Datos datos = new Datos();
            //List<Voucher> vouchers = new List<Voucher>();
            Voucher aux = new Voucher();
            try
            {
                datos.SetearConsulta("Select ID, CodigoVoucher, ESTADO, IDCLIENTE, IDPRODUCTO, FECHAREGISTRO from SORIA_TP3.dbo.VOUCHERS where CodigoVoucher= '" + code+"'");
                datos.AbrirConexion();
                datos.EjecutarConsulta();
                while (datos.Reader.Read())
                {
                    aux.ID      = (int)datos.Reader[0];
                    aux.Code    = (string)datos.Reader[1];
                    aux.Estado  = (bool)datos.Reader[2];
                    if (!Convert.IsDBNull(datos.Reader[3]))
                    {
                        aux.CodeCliente     = (Int64)datos.Reader[3];
                        aux.CodeProducto    = (Int64)datos.Reader[4];
                        aux.Fecha           = (DateTime)datos.Reader[5];
                    }
                    //vouchers.Add(aux);
                }
                return aux;
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
        public List<Voucher> ListarVouchers()
        {
            Datos datos = new Datos();
            List<Voucher> vouchers = new List<Voucher>();
            Voucher aux;
            try
            {
                datos.SetearConsulta("Select ID, CodigoVoucher, ESTADO, IDCLIENTE, IDPRODUCTO, FECHAREGISTRO from SORIA_TP3.dbo.VOUCHERS");
                datos.AbrirConexion();
                datos.EjecutarConsulta();
                while (datos.Reader.Read())
                {
                    aux = new Voucher();
                    aux.ID           = (int)datos.Reader[0];
                    aux.Code         = (string)datos.Reader[1];
                    aux.Estado       = (bool)datos.Reader[2];
                    if (!Convert.IsDBNull(datos.Reader[3]))
                    {
                        aux.CodeCliente  = (Int64)datos.Reader[3];
                        aux.CodeProducto = (Int64)datos.Reader[4];
                        aux.Fecha        = (DateTime)datos.Reader[5];
                    }

                    vouchers.Add(aux);
                }
                return vouchers;
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


        public void Agregar(Voucher voucher)
        {
            Datos datos = new Datos();
            try
            {
                datos.SetearConsulta("insert into SORIA_TP3.dbo.VOUCHERS values (@CODE, @CODIGOVOUCHER, @ESTADO, @IDCLIENTE, @IDPRODUCTOS, @FECHAREGISTRO)");
                datos.Comando.Parameters.Clear();
                datos.Comando.Parameters.AddWithValue("@CODE",          voucher.Code.ToString());
                datos.Comando.Parameters.AddWithValue("@CODIGOVOUCHER", voucher.Estado.ToString());
                datos.Comando.Parameters.AddWithValue("@ESTADO",        voucher.CodeCliente.ToString());
                datos.Comando.Parameters.AddWithValue("@IDCLIENTE",     voucher.CodeProducto.ToString());
                datos.Comando.Parameters.AddWithValue("@IDPRODUCTOS",   voucher.Fecha);
                datos.Comando.Parameters.AddWithValue("@FECHAREGISTRO", voucher.Fecha);
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

        public void Modificar(Voucher voucher)
        {
            Datos datos = new Datos();
            try
            {
                datos.SetearConsulta("update SORIA_TP3.VOUCHERS Set CODIGOVOUCHER=@Codigo, ESTADO=@Estado, IDCLIENTE=@IdCliente, IDPRODUCTOS=@IdProducto, FECHAREGISTRO=@FechaRegistro Where ID=" + voucher.ID);
                datos.Comando.Parameters.Clear();
                datos.Comando.Parameters.AddWithValue("@Codigo",        voucher.Code.ToString());
                datos.Comando.Parameters.AddWithValue("@Estado",        voucher.Estado.ToString());
                datos.Comando.Parameters.AddWithValue("@IdCliente",     voucher.CodeCliente.ToString());
                datos.Comando.Parameters.AddWithValue("@IdProducto",    voucher.CodeProducto.ToString());
                datos.Comando.Parameters.AddWithValue("@FechaRegistro", voucher.Fecha.ToString());
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
                datos.SetearConsulta("delete from SORIA_TP3.dbo.VOUCHERS where Id =" + id);
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
