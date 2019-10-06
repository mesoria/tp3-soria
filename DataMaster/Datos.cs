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
        public static string cadenaConexion = "data source=LAPTOP-4ROB6KSH\\SQLEXPRESS; initial catalog=TP_WEB; integrated security=sspi";
        private SqlCommand comando;
        private SqlConnection conexion;
        private SqlDataReader reader;

        public SqlDataReader Reader
        {
            get { return reader; }
        }
        public SqlCommand Comando
        {
            get { return comando; }
        }

        public Datos()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        //setear consulta embebida.
        public void SetearConsulta(string consulta)
        {
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        //setear consulta embebida con condicion.
        public void SetearConsulta(string consulta, int id)
        {
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta + id.ToString();
        }

        //esto para luego...
        public void SetearSP(string sp)//quería usarlo pero no llegué.
        {
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        public void AbrirConexion()
        {
            try
            {
                conexion.Open();
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
                conexion.Close();
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
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
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
                comando.Connection = conexion;
                return (int)comando.ExecuteScalar();
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
                comando.Connection = conexion;
                reader = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }









/*
    {
        public SqlConnection Conexion { get; set; }
        public SqlCommand Comando { get; set; }
        //public SqlDataReader Reader { get; set; }
        private SqlDataReader reader;

        public SqlDataReader Reader
        {
            get { return reader; }
        }

        public Datos()
        {
            Conexion = new SqlConnection("data source=LAPTOP-4ROB6KSH\\SQLEXPRESS; initial catalog=TP_WEB; integrated security=sspi");
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
                reader = Comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }*/
}
