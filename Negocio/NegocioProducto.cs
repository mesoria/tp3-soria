using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMaster;
using Dominio;

namespace Negocio
{
    public class NegocioProducto
    {
        public List<Producto> ListarProductos()
        {
            Datos datos             = new Datos();
            List<Producto> lista    = new List<Producto>();
            Producto aux;
            try
            {
                datos.SetearConsulta("Select ID, Titulo, Descripcion, URLImagen from PRODUCTOS");
                datos.AbrirConexion();
                datos.EjecutarConsulta();
                while (datos.Reader.Read())
                {
                    aux             = new Producto();
                    aux.ID          = (Int64)datos.Reader[0];
                    aux.titulo      = (string)datos.Reader[1];
                    aux.descripcion = (string)datos.Reader[2];
                    aux.URLImagen   = (string)datos.Reader[3];
                    
                    lista.Add(aux);
                }
                return lista;
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


        public void Agregar(Producto producto)
        {
            Datos datos = new Datos();
            try
            {
                datos.SetearConsulta("insert into SORIA_TP3.dbo.PRODUCTOS (Titulo, Descripcion, URLImagen) values (@Titulo, @Descripcion, @URLImagen)");
                datos.Comando.Parameters.Clear();
                datos.Comando.Parameters.AddWithValue("@Titulo",        producto.titulo.ToString());
                datos.Comando.Parameters.AddWithValue("@Descripcion",   producto.descripcion.ToString());
                datos.Comando.Parameters.AddWithValue("@URLImagen",     producto.URLImagen.ToString());
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

        public void Modificar(Producto producto)
        {
            Datos datos = new Datos();
            try
            {
                datos.SetearConsulta("update SORIA_TP3.dbo.PRODUCTOS Set Titulo=@Nombre, Descripcion=@Descripcion, URLImagen=@Imagen Where Id=" + producto.ID);
                datos.Comando.Parameters.Clear();
                datos.Comando.Parameters.AddWithValue("@Titulo",        producto.titulo.ToString());
                datos.Comando.Parameters.AddWithValue("@Descripcion",   producto.descripcion.ToString());
                datos.Comando.Parameters.AddWithValue("@URLImagen",     producto.URLImagen.ToString());
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
                datos.SetearConsulta("delete from SORIA_TP3.dbo.PRODUCTOS where Id =" + id);
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
