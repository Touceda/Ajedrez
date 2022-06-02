using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SQLajedrez
{
    public class SqlMovimientos
    {

        ConexionSql Conexion = new ConexionSql();

        public void CargarMovimiento(int id, int movimientonum, string movimiento)
        {

            List<SqlParameter> nombres = new List<SqlParameter>();
            nombres.Add(Conexion.CrearParametro("@id", id));
            nombres.Add(Conexion.CrearParametro("@movimientonum", movimientonum));
            nombres.Add(Conexion.CrearParametro("@movimiento", movimiento));
           

            Conexion.Conectar();
            using (SqlCommand comando = new SqlCommand()) //Creo la tabla id de partida con sus jugadores
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Connection = Conexion.Conection;
                comando.CommandText = "pr_CargarMovimiento";
                comando.Parameters.AddRange(nombres.ToArray());
                comando.ExecuteNonQuery();
            }
        }
    }
}
