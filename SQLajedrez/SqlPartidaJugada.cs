using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SQLajedrez
{
    public class SqlPartidaJugada
    {
        ConexionSql Conexion = new ConexionSql();

        public bool ValidarPartidaExistente(int id)
        {
            SqlParameter idParameter = new SqlParameter();
            idParameter = Conexion.CrearParametro("@id", id);

            DataTable Tab = new DataTable();
            string Estado = "";

            Conexion.Conectar();
            using (SqlCommand comando = new SqlCommand()) //Creo la tabla id de partida con sus jugadores
            {

                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = Conexion.Conection;
                comando.Parameters.Add(idParameter);
                comando.CommandText = "select PartidaFinalizada from EstadoPartida where IdPartida = @id";
                using (SqlDataAdapter DA = new SqlDataAdapter())
                {
                    DA.SelectCommand = comando; //Le paso el procAlmacenado y la conexion al comando
                    DA.Fill(Tab); //Ejecuto comando y le paso la tabla para rellenar
                }

                foreach (DataRow item in Tab.Rows)
                {
                    Estado = item[0].ToString();
                }

            }

            if (Estado == "F")
            {
                return true;
            }

            if (Estado == "V")
            {
                return false;
            }

            return false;
        }

        public DataTable ObtenerMovimientos(int id)
        {
            DataTable TablaDeMovimientos = new DataTable();
            SqlParameter idParameter = Conexion.CrearParametro("@id", id);

            Conexion.Conectar();
            using (SqlCommand comando = new SqlCommand()) //Creo la tabla id de partida con sus jugadores
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = Conexion.Conection;
                comando.Parameters.Add(idParameter);
                comando.CommandText = "select Movimiento from Movimientos where IdMovimientos = @id";
                using (SqlDataAdapter DA = new SqlDataAdapter())
                {
                    DA.SelectCommand = comando; //Le paso el procAlmacenado y la conexion al comando
                    DA.Fill(TablaDeMovimientos); //Ejecuto comando y le paso la tabla para rellenar
                }
                return TablaDeMovimientos;
            }



        }
    }
}
