using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SQLajedrez
{
    public class SqlJugadores
    {
        ConexionSql Conexion = new ConexionSql();

        public int CargarNuevaPartida(string JugBlanco, string JugNegro)
        {
            
            List<SqlParameter> nombres = new List<SqlParameter>();
            nombres.Add(Conexion.CrearParametro("@blanco", JugBlanco));
            nombres.Add(Conexion.CrearParametro("@Negro", JugNegro));

            Conexion.Conectar();
            using (SqlCommand comando = new SqlCommand()) //Creo la tabla id de partida con sus jugadores
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Connection = Conexion.Conection;
                comando.CommandText = "pr_NuevaPartida";
                comando.Parameters.AddRange(nombres.ToArray());
                comando.ExecuteNonQuery();
            }
        
            DataTable dato = new DataTable();
            using (SqlCommand comando = new SqlCommand()) //Busco el id para crear la segunda tabla
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = Conexion.Conection;
                comando.CommandText = "Select Max(Id) From Jugadores";
                using (SqlDataAdapter DA = new SqlDataAdapter())
                {
                    DA.SelectCommand = comando;
                    DA.Fill(dato);
                }
            }

            int id = 0;
            foreach (DataRow fila in dato.Rows)
            {
                id = int.Parse(fila[0].ToString());
            }

            nombres = new List<SqlParameter>();
            nombres.Add(Conexion.CrearParametro("@id", id));
            nombres.Add(Conexion.CrearParametro("@estado", "F"));

            using (SqlCommand comando = new SqlCommand()) //Creo la segunda tabla que tiene el id de la partida y el estado (F si no termino V si termino)
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Connection = Conexion.Conection;
                comando.CommandText = "pr_EstadoDeNuevaPartida";
                comando.Parameters.AddRange(nombres.ToArray());
                comando.ExecuteNonQuery();
            }
            Conexion.Desconectar();
            return id;
        }

        public void Buscarpartida() { }

    }
}
