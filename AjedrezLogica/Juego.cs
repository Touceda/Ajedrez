using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezLogica
{
    public class Juego
    {
        public Jugador jugador1; //Configurar para que sea el Blanco ??????????????????????????????????
        public Jugador jugador2;//Configurar para que sea el negro ???????????????????????????
        public bool BlackTurn;
        private EspacioTablero[,] tablero;
        public EspacioTablero[,] MiTablero { get { return tablero; }set { tablero = value; } }


        public Juego()
        {
            jugador1 = new Jugador("Nicolas",false);//Modificar a la capa de consola, pasar nombre y quien es blanco
            jugador2 = new Jugador("Bautista", true);//Modificar a la capa de consola, pasar nombre y quien es blanco
            BlackTurn = false;
            this.MiTablero = Tablero.ActualizarTablero(jugador1.MisFichas,jugador2.MisFichas);
        }



        public bool ComprobarFichaConsola(string ficha)
        {
            int x;
            int y;


            x = int.Parse(ficha[0].ToString());

            y = Tablero.ConvertStringToInt(ficha[1].ToString());

            if (y == -1)
            {
                return false;
            }

            Ficha fichaSeleccionada = MiTablero[x, y].MiFicha;

            if (fichaSeleccionada == null) //Si no hay ficha en la posicion devuelvo falso para reiniciar el tablero
            {
                return false;
            }

            if (BlackTurn)
            {
                jugador2.FichaSeleccionada = fichaSeleccionada;
                return jugador2.SeleccionarFicha();
            }
            else
            {
                jugador1.FichaSeleccionada = fichaSeleccionada;
                return jugador1.SeleccionarFicha();
            }
        }

        public bool ComprobarMovimientoConsola(string ficha)
        {
            int x;
            int y;


            x = int.Parse(ficha[0].ToString());
            y = Tablero.ConvertStringToInt(ficha[1].ToString());

            if (y == -1)  
            {
                return false;
            }

            bool isTrue;
            if (BlackTurn)
            {
               isTrue = jugador2.MoverFicha(x,y);
            }
            else
            {
                isTrue = jugador1.MoverFicha(x,y);
            }

            if (isTrue)
            {
                MiTablero = Tablero.ActualizarTablero(jugador1.MisFichas, jugador2.MisFichas);
                BlackTurn = !BlackTurn;
            }

            return isTrue;
        }






    }
}

