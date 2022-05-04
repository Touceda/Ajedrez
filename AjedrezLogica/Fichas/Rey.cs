using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezLogica
{
    public class Rey : Ficha
    {

        private string[] PosiblesMovimientos;


        public Rey (int pX, int pY, string pColor)
        {
            this.PosX = pX;
            this.PosY = pY;
            this.Nombre = "R" + pColor.ToString();
            this.Color = pColor;
            this.ComiFicha = false;
            CalcularMovimientosPosibles();
        }

        public override void CalcularMovimientosPosibles() //Calculo todos los movimientos posibles
        {
            int posiblex = this.PosX;
            int posibley = this.PosY;
            // 0 0 0
            // 0 x 0
            // 0 0 0

            string[] Movimientos = new string[8];

            posiblex++;
            // 0 x 0
            // 0 0 0
            // 0 0 0
            Movimientos[0] = posiblex.ToString() + posibley.ToString();

           

            posibley++;
            // 0 0 x
            // 0 0 0
            // 0 0 0
            Movimientos[1] = posiblex.ToString() + posibley.ToString();

          

            posiblex--;
            // 0 0 0
            // 0 0 x
            // 0 0 0
            Movimientos[2] = posiblex.ToString() + posibley.ToString();

            posiblex--;
            // 0 0 0
            // 0 0 0
            // 0 0 x
            Movimientos[3] = posiblex.ToString() + posibley.ToString();

            posibley--;
            // 0 0 0
            // 0 0 0
            // 0 x 0
            Movimientos[4] = posiblex.ToString() + posibley.ToString();

            posibley--;
            // 0 0 0
            // 0 0 0
            // x 0 0
            Movimientos[5] = posiblex.ToString() + posibley.ToString();

            posiblex++;
            // 0 0 0
            // x 0 0
            // 0 0 0
            Movimientos[6] = posiblex.ToString() + posibley.ToString();

            posiblex++;
            // x 0 0
            // 0 0 0
            // 0 0 0
            Movimientos[7] = posiblex.ToString() + posibley.ToString();

            PosiblesMovimientos = Movimientos;
        }

        EspacioTablero[,] Tablero;
        List<Ficha> FichasEnemigas;
        int movaX;
        int movaY;

        public override bool MoverFicha(int x, int y, List<Ficha> Fichasenemigas, EspacioTablero[,] tab)
        {
            this.Tablero = tab;
            this.FichasEnemigas = Fichasenemigas;
            this.movaX = x;
            this.movaY = y;

            if (ComprobarMovimiento())//Compruebo si el movimiento es correcto
            {
                Mover();
                return true;
            }


            return false;
        }

        public override bool ComprobarMovimiento()
        {
            if (movaX < 0 || movaX > 7 || movaY < 0 || movaY > 7) //Si se cumple alguna condicion, significa que salgo del tablero, Reinicio Movimiento
            {
                return false;
            }

            string mov = movaX.ToString() + movaY.ToString();

            foreach (var pos in PosiblesMovimientos)
            {
                if (pos == mov)
                {
                   bool error = ComprobarSiComi();

                    if (error)
                    {
                        return false; //Ocurrio un error
                    }

                    return true;
             
                }
            }
            return false; //No se encontro movimiento 
        }


        public override bool ComprobarSiComi()
        {

            if (this.Tablero[movaX, movaY].IsOcuped) //Compruebo Si hay una ficha donde me quiero mover
            {
                if (this.Tablero[movaX, movaY].MiFicha.Color == this.Color) //Si es de mi mismo color, tiro error
                {
                    return true;
                }
                //Si no, sigo con el programa normal
            }
            else //Si no hay ficha, Descarto error y busqueda de ficha enemiga
            {
                return false;
            }


            foreach (var ficha in FichasEnemigas) //Busqueda de Ficha Enemiga
            {
                if (ficha.PosX == movaX && ficha.PosY == movaY)
                {
                    this.ComiFicha = true;
                    FichaEnemigaComida = ficha;
                    return false;
                }
            }
            return true;
        }


        public override void Mover()
        {
            this.PosX = movaX;
            this.PosY = movaY;
            CalcularMovimientosPosibles();
        }

    }
}
