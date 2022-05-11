using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezLogica
{
    public class Torre : Ficha
    {

        private string[] PosiblesMovimientos;


        public Torre(int pX, int pY, string pColor)
        {
            this.PosX = pX;
            this.PosY = pY;
            this.Nombre = "Torre";
            this.Color = pColor;
            this.ComiFicha = false;
            CalcularMovimientosPosibles();
        }

        public override void CalcularMovimientosPosibles() //Calculo todos los movimientos posibles
        {
            int posiblex = this.PosX;
            int posibley = this.PosY;

            string[] Movimientos = new string[14];
            int indexMov = 0;

            //Calcular Movimientos Hacia arriba
            while (posiblex < 7 && posiblex >= 0)
            {
                posiblex++;
                Movimientos[indexMov] = posiblex.ToString() + posibley.ToString();
                indexMov++;
            }

            posiblex = this.PosX;
            //Calcular Movimientos hacia abajo
            while (posiblex > 0 && posiblex <= 7)
            {
                posiblex--;
                Movimientos[indexMov] = posiblex.ToString() + posibley.ToString();
                indexMov++;
            }

            posiblex = this.PosX;
            //Calcular Movimientos Hacia Derecha
            while (posibley < 7 && posibley >= 0)
            {
                posibley++;
                Movimientos[indexMov] = posiblex.ToString() + posibley.ToString();
                indexMov++;
            }

            posibley = this.PosY;
            //Calcular Movimientos hacia Izquierda
            while (posibley > 0 && posibley <= 7)
            {
                posibley--;
                Movimientos[indexMov] = posiblex.ToString() + posibley.ToString();
                indexMov++;
            }

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
            string mov = movaX.ToString() + movaY.ToString();

            foreach (var pos in PosiblesMovimientos)//Recorro los moviminetos a ver si es posible
            {
                if (pos == mov)
                {
                    bool error = ComprobarMovimientoIndividual();

                    if (error)
                    {
                        return false; //Ocurrio un error
                    }

                    return true;

                }
            }
            return false; //No se encontro movimiento 
        } 
       
        private bool ComprobarMovimientoIndividual()
        {
            int auxPosition;

            if (movaX > this.PosX) //Se ejecuta si el movimiento de la torre es hacia ARRIBA
            {
                auxPosition = this.PosX;

                auxPosition++;
                while (auxPosition != movaX) //Recorro Movimiento x Movimiento viendo que no pise nunguna ficha
                {
                    if (this.Tablero[auxPosition, this.PosY].IsOcuped) 
                    {
                        return true;
                    }
                    auxPosition++;
                }
               return ComprobarSiComi();
            }

            if (movaX < this.PosX) //Se ejecuta si el movimiento de la torre es hacia ABAJO
            {
                auxPosition = this.PosX;

                auxPosition--;
                while (auxPosition != movaX) //Recorro Movimiento x Movimiento viendo que no pise nunguna ficha
                {
                    if (this.Tablero[auxPosition, this.PosY].IsOcuped)
                    {
                        return true;
                    }
                    auxPosition--;
                }
                return ComprobarSiComi();
            }

            if (movaY > this.PosY) //Se ejecuta si el movimiento de la torre es hacia la DERECHA
            {
                auxPosition = this.PosY;

                auxPosition++;
                while (auxPosition != movaY) //Recorro Movimiento x Movimiento viendo que no pise nunguna ficha
                {
                    if (this.Tablero[this.PosX, auxPosition].IsOcuped)
                    {
                        return true;
                    }
                    auxPosition++;
                }
                return ComprobarSiComi();
            }

            if (movaY < this.PosY) //Se ejecuta si el movimiento de la torre es hacia la IZQUIERDA
            {
                auxPosition = this.PosY;

                auxPosition--;
                while (auxPosition != movaY) //Recorro Movimiento x Movimiento viendo que no pise nunguna ficha
                {
                    if (this.Tablero[this.PosX, auxPosition].IsOcuped)
                    {
                        return true;
                    }
                    auxPosition--;
                }
                return ComprobarSiComi();
            }
          
            return true;
        }

        public override bool ComprobarSiComi()
        {
            if (this.Tablero[movaX, movaY].IsOcuped) //Compruebo Si hay una ficha donde me quiero mover
            {
                if (this.Tablero[movaX, movaY].MiFicha.Color == this.Color) //Si es de mi mismo color, devuelvo error
                {
                    return true;
                }
                //Si no, sigo con el programa normal y paso a la busqueda de fichas enemigas
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
