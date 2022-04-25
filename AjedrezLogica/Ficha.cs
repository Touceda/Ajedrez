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


        public abstract bool ComprobarMovimiento(int x, int y); //DeMomentoNada
        public abstract bool Mover(int x, int y);
        

    }


    public class Peon:Ficha
    {

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
          
        }

        public override bool ComprobarMovimiento(int x, int y)
        {
            if (x <= 7 && x <= 0 && y <= 7 && y <= 0) 
            {
                return true;
            }
            return false;
        }

        public override bool Mover(int x, int y)
        {
            this.PosX = x;
            this.PosY = y;
            return true;
        }
    }


}
