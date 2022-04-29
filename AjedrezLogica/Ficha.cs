using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezLogica
{
    public abstract class Ficha
    {
        private string nombre;
        public string Nombre { get { return nombre; } set { nombre = value; } }
        private string color;
        public string Color { get { return color; } set { color = value; } }
        private int x;
        public int PosX { get { return x; } set { x = value; } }
        private int y;
        public int PosY { get { return y; } set { y = value; } }

        private Ficha fichaenemigacomida;
        public Ficha FichaEnemigaComida { get { return fichaenemigacomida; } set { fichaenemigacomida = value; } }

        private bool comificha;
        public bool ComiFicha { get { return comificha; } set { comificha = value; } }



        public abstract void CalcularMovimientosPosibles();
        public abstract bool MoverFicha(int x, int y, List<Ficha> FichasEnemigas, EspacioTablero[,] tab);
        public abstract bool ComprobarMovimiento(); //DeMomentoNada
        public abstract bool ComprobarSiComi();
        public abstract void Mover();
        

    }


    public class Peon:Ficha
    {
        private string[] PosiblesMovimientos;       
        private bool firstmovement = true;

        public Peon(int pX, int pY, string pColor)
        {
            this.PosX = pX;
            this.PosY = pY;
            this.Nombre = "P" + pColor.ToString();
            this.Color = pColor;
            this.ComiFicha = false;
            CalcularMovimientosPosibles();
        }

        public override void CalcularMovimientosPosibles() //Calculo todos los movimientos posibles
        {
            int posiblex = this.PosX;
            int posibley = this.PosY;

            string[] Movimientos = new string[4];

            if (this.Color == "B") //Blancas
            {
                //Primer Movimiento
                if (firstmovement == true)
                {
                    posiblex += 2;
                    Movimientos[0] = posiblex.ToString() + posibley.ToString();
                    firstmovement = false;
                }
                else
                {
                    posiblex += 2;
                    Movimientos[0] = "NoHayMovimiento";
                }

                //Movimiento Comun
                posiblex--;
                Movimientos[1] = posiblex.ToString() + posibley.ToString();

                //ComerFichas
                posibley++;
                Movimientos[2] = posiblex.ToString() + posibley.ToString();

                posibley--;
                posibley--;
                Movimientos[3] = posiblex.ToString() + posibley.ToString();
                PosiblesMovimientos = Movimientos;
                return;
            }


            //Negras
            //Primer Movimiento
            if (firstmovement == true) 
            {
                posiblex--;
                posiblex--;
                Movimientos[0] = posiblex.ToString() + posibley.ToString() ;
                firstmovement = false;
            }
            else
            {
                posiblex--;
                posiblex--;
                Movimientos[0] = "NoHayMovimiento";
            }

            //Movimiento Comun
            posiblex++;
            Movimientos[1] = posiblex.ToString() + posibley.ToString();

            //ComerFichas
            posibley++;
            Movimientos[2] = posiblex.ToString() + posibley.ToString();

            posibley--;
            posibley--;
            Movimientos[3] = posiblex.ToString() + posibley.ToString();

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
                    if (movaY != this.PosY) //Si me movi en Y, significa que tengo que comer si o si, si no me movi, paso a comprobar la x
                    {
                        return ComprobarSiComi();
                    }

                    if (movaX != this.PosX) //Si me movi en x,compruebo de no comer nada
                    {
                        return ComprobarSiNoComi();
                    }
                }
            }
            return false; //No se encontro movimiento 
        }



        //private bool ComprobarMovimientoNegras()
        //{
        //    string mov = movaX.ToString() + movaY.ToString();

        //    foreach (var pos in PosiblesMovimientos)
        //    {
        //        if (pos == mov)
        //        {
        //            if (movaY != this.PosY) //Si me movi en Y, significa que tengo que comer si o si, si no me movi, paso a comprobar la x
        //            {
        //                return ComprobarSiComi();
        //            }

        //            if (movaX != this.PosX) //Si me movi en x,compruebo de no comer nada
        //            {
        //                return ComprobarSiNoComi();
        //            }
        //        }
        //    }
        //    return false; //No se encontro movimiento 
        //    return true;
        //}

        public override bool ComprobarSiComi()
        {

            if (this.Tablero[movaX, movaY].IsOcuped) //Si hay una ficha en el tablero
            {
                if (this.Tablero[movaX, movaY].MiFicha.Color == this.Color) //Si es de mi mismo color, tiro error
                {
                    return false;
                }
                //Si no, sigo con el programa normal
            }
            else
            {
                return false;
            }


            foreach (var ficha in FichasEnemigas)
            {
                if (ficha.PosX == movaX && ficha.PosY == movaY) 
                {
                    this.ComiFicha = true;
                    FichaEnemigaComida = ficha;
                    return true;
                }
            }

            return false;
        }

        private bool ComprobarSiNoComi()
        {
            if (this.Tablero[movaX, movaY].IsOcuped) //Si hay una ficha en el tablero donde quiero moverme
            {
                return false; //No puedo comer
            }
           
            return true; //No como a nadie
        } //Metodo Especifico del peon

        public override void Mover()
        {
            this.PosX = movaX;
            this.PosY = movaY;
            CalcularMovimientosPosibles();
        }

       
    }


}
