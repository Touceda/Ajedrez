using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQLajedrez
{
    public class SqlJugadores
    {
        ConexionSql Conexion = new ConexionSql();

        public void CargarNuevaPartida(string JugBlanco, string JugNegro)
        {
            List<SqlParameter> nombres = new List<SqlParameter>();
            nombres.Add(Conexion.CrearParametro())

            Conexion.Conectar();
            using (SqlCommand comando = new SqlCommand())
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Connection = Conexion.Conection;
                comando.CommandText = "InsertarJugadores";
                comando.Parameters.AddRange(nombres.ToArray());
                comando.ExecuteNonQuery();
            }
            Conexion.Desconectar();

        }


    }
}
