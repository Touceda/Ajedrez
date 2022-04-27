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
        public bool comi;




        public abstract bool MoverFicha(int x, int y, List<Ficha> FichasEnemigas);
        public abstract bool ComprobarMovimiento(); //DeMomentoNada
        public abstract void Mover();
        

    }


    public class Peon:Ficha
    {
        string[] PosiblesMovimientos;
        
        private bool firstmovement = true;
        //public string nombre = "PB";
        //private int x;
        //public int PosX { get { return x; } set { x = value; } }
        //private int y;
        //public int PosY { get { return y; } set { y = value; } }



        public Peon(int pX, int pY, string pColor)
        {
            this.PosX = pX;
            this.PosY = pY;
            this.Nombre = "P" + pColor.ToString();
            this.Color = pColor;
            this.comi = false;
            CalcularMovimientosPosibles();
        }

        private void CalcularMovimientosPosibles() //Calculo todos los movimientos posibles
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





        List<Ficha> FichasEnemigas;
        int movaX;
        int movaY;

        public override bool MoverFicha(int x, int y, List<Ficha> Fichasenemigas)
        {
            this.FichasEnemigas = Fichasenemigas;
            this.movaX = x;
            this.movaY = y;

            return ComprobarMovimiento(); //Si el movimiento es correcto Muevo

        }

        public override bool ComprobarMovimiento()
        {
            bool MovimientoEsPosible = false;
            if (movaX < 0 || movaX > 7 || movaY < 0 || movaY > 7) //Si se cumple alguna condicion, significa que salgo del tablero, Reinicio Movimiento
            {
                return false;
            }

            MovimientoEsPosible = MovimientoComprobado();

            if (MovimientoEsPosible) //Realizo el movimiento
            {
                Mover();
            }

            return MovimientoEsPosible;
        }

        private bool MovimientoComprobado() //Busco si mi movimiento esta dentro de los posibles
        {
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

        private bool ComprobarSiComi()
        {
            foreach (var ficha in FichasEnemigas)
            {
                if (ficha.PosX == movaX && ficha.PosY == movaY) 
                {
                    this.comi = true;
                    FichaEnemigaComida = ficha;
                    return true;
                }
            }

            return false;
        }
        private bool ComprobarSiNoComi()
        {
            foreach (var ficha in FichasEnemigas)
            {
                if (ficha.PosX == movaX && ficha.PosY == movaY)
                {
                    return false; //No puedo comer
                }
            }
            return true; //No comi a nadie
        }

        public override void Mover()
        {
            this.PosX = movaX;
            this.PosY = movaY;
            CalcularMovimientosPosibles();
        }

       
    }


}
