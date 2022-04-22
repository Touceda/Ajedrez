using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezLogica
{
    public class Juego
    {
        Jugador jugador1;
        Jugador jugador2;
        private EspacioTablero[,] tablero;
        public EspacioTablero[,] MiTablero { get { return tablero; }set { tablero = value; } }


        public Juego()
        {
            jugador1 = new Jugador("Nicolas",false);//Modificar a la capa de consola, pasar nombre y quien es blanco
            jugador2 = new Jugador("Bautista", true);//Modificar a la capa de consola, pasar nombre y quien es blanco
            this.MiTablero = Tablero.CrearTablero();
            this.MiTablero = Tablero.RellenarTablero(this.MiTablero,jugador1.MisFichas,jugador2.MisFichas);
        }
   
        
    







    }
}

