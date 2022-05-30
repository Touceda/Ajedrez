using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Net;

namespace SQLajedrez
{
    public class ConexionSql
    { 
        private SqlConnection conection;
        public SqlConnection Conection { get { return conection; } }
        private string sqlDirecction = @"Data Source=ELTOU;Initial Catalog=Ajedrez;Integrated Security=True";

        public SqlConnection Conectar()
        {
            //Evita crear una nueva conexion cunado ya tenemos una activa
            if (conection != null && conection.State == System.Data.ConnectionState.Open)
            {
                return conection;
            }

            conection = new SqlConnection();
            conection.ConnectionString = sqlDirecction;
            conection.Open();
            return conection;    
        }

        public SqlParameter CrearParametro(string tipo, string valor)
        {
            SqlParameter parametro = new SqlParameter(tipo, valor);
            parametro.SqlDbType = System.Data.SqlDbType.Text;
            return parametro;
        }
        public SqlParameter CrearParametro(string tipo, int valor)
        {
            SqlParameter parametro = new SqlParameter(tipo, valor);
            parametro.SqlDbType = System.Data.SqlDbType.Int;
            return parametro;
        }

        public void Desconectar()
        {
            conection.Close();
            conection.Dispose();
            GC.Collect();
        }
    }
   
}

/*private SqlConnection conection;
        public SqlConnection Conection { get { return conection; } }
        private string sqlDirecction = @"Data Source=DESKTOP-92N1E75;Initial Catalog=Ajedrez;Integrated Security=True";

        public SqlConnection Conectar()
        {
            //Evita crear una nueva conexion cunado ya tenemos una activa
            if (conection != null && conection.State == System.Data.ConnectionState.Open)
            {
                return conection;
            }

            conection = new SqlConnection();
            conection.ConnectionString = sqlDirecction;
            conection.Open();
            return conection;
        }

        public void Desconectar()
        {
            conection.Close();
            conection.Dispose();
            GC.Collect();
        }


        public SqlParameter CrearParametro(string tipo, string valor)
        {
            SqlParameter parametro = new SqlParameter(tipo, valor);
            parametro.SqlDbType = System.Data.SqlDbType.Text;
            return parametro;
        }
        public SqlParameter CrearParametro(string tipo, int valor)
        {
            SqlParameter parametro = new SqlParameter(tipo, valor);
            parametro.SqlDbType = System.Data.SqlDbType.Int;
            return parametro;
        }*/