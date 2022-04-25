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


    }
}
