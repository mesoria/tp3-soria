using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataMaster
{
    public class Datos
    {
        public SqlConnection Conexion { get; set; }
        public SqlCommand Comando { get; set; }
        public SqlDataReader Reader { get; set; }

        public Datos()
        {
            Conexion = new SqlConnection("data source=LAPTOP-4ROB6KSH\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi");
        }
        //setear consulta embebida.
        public void SetearConsulta(string consulta)
        {
            Comando = new SqlCommand();
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = consulta;
        }
        //setear consulta embebida con condicion.
        public void SetearConsulta(string consulta, int id)
        {
            Comando = new SqlCommand();
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = consulta + id.ToString();
        }

        //esto para luego...
        public void SetearSP(string sp)
        {
            Comando = new SqlCommand();
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.CommandText = sp;
        }

        public void AbrirConexion()
        {
            try
            {
                Conexion.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CerrarConexion()
        {
            try
            {
                Conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EjecutarAccion()
        {
            try
            {
                Comando.Connection = Conexion;
                Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int EjecutarAccionReturn()
        {
            try
            {
                Comando.Connection = Conexion;
                return (int)Comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EjecutarConsulta()
        {
            try
            {
                Comando.Connection = Conexion;
                Reader = Comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
