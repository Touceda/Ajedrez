using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezLogica
{
    static class Tablero
    {

        //Crea un tablero vacio con espacios
        public static EspacioTablero[,] CrearTablero()
        {
            EspacioTablero[,] tablero = new EspacioTablero[8, 8];

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    tablero[x, y] = new EspacioTablero(x, y);
                }
            }

            return tablero;
        }


        public static EspacioTablero[,] RellenarTablero(EspacioTablero[,] tablero, List<Ficha> JugadorBlanco, List<Ficha> JugadorNegro)
        {
            EspacioTablero[,] tab = tablero;

            foreach (var ficha in JugadorBlanco)
            {
                tab[ficha.PosX, ficha.PosY].MiFicha = ficha;
                tab[ficha.PosX, ficha.PosY].IsOcuped = true;
            }

            foreach (var ficha in JugadorNegro)
            {
                tab[ficha.PosX, ficha.PosY].MiFicha = ficha;
                tab[ficha.PosX, ficha.PosY].IsOcuped = true;
            }

            return tab;
        }




    }
}
