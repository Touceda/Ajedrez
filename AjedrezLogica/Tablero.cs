using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezLogica
{
    class Tablero
    {


        public static EspacioTablero[,] ActualizarTablero(List<Ficha> JugadorBlanco, List<Ficha> JugadorNegro)
        {
            EspacioTablero[,] tablero = new EspacioTablero[8, 8];

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    tablero[x, y] = new EspacioTablero(x, y);
                }
            }

            foreach (var ficha in JugadorBlanco)
            {
                tablero[ficha.PosX, ficha.PosY].MiFicha = ficha;
                tablero[ficha.PosX, ficha.PosY].IsOcuped = true;
            }

            foreach (var ficha in JugadorNegro)
            {
                tablero[ficha.PosX, ficha.PosY].MiFicha = ficha;
                tablero[ficha.PosX, ficha.PosY].IsOcuped = true;
            }

            return tablero;
        }

        public static int ConvertStringToInt(string yCordenada)
        {
            int y;
            switch (yCordenada)
            {
                case "A": { y = 0; break; }
                case "a": { y = 0; break; }
                case "B": { y = 1; break; }
                case "b": { y = 1; break; }
                case "C": { y = 2; break; }
                case "c": { y = 2; break; }
                case "D": { y = 3; break; }
                case "d": { y = 3; break; }
                case "E": { y = 4; break; }
                case "e": { y = 4; break; }
                case "F": { y = 5; break; }
                case "f": { y = 5; break; }
                case "G": { y = 6; break; }
                case "g": { y = 6; break; }
                case "H": { y = 7; break; }
                case "h": { y = 7; break; }
                default: return -1;
            }
            return y;
        }

        public static int BuscarPosition(int Posicion)
        {
            if (Posicion >= 100 && Posicion <= 200)
            {
                return 0;
            }

            if (Posicion >= 200 && Posicion <= 300)
            {
                return 1;
            }

            if (Posicion >= 300 && Posicion <= 400)
            {
                return 2;
            }

            if (Posicion >= 400 && Posicion <= 500)
            {
                return 3;
            }

            if (Posicion >= 500 && Posicion <= 600)
            {
                return 4;
            }

            if (Posicion >= 600 && Posicion <= 700)
            {
                return 5;
            }

            if (Posicion >= 700 && Posicion <= 800)
            {
                return 6;
            }

            if (Posicion >= 800 && Posicion <= 900)
            {
                return 7;
            }

            return -1;
        }
    }
}
