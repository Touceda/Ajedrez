using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezLogica
{
    public class Ficha
    {
        private string nombre;
        public string Nombre { get { return nombre; } set { nombre = value; } }
        private string color;
        public string Color { get { return color; } set { color = value; } }
        private int x;
        public int PosX { get { return x; } set { x = value; } }
        private int y;
        public int PosY { get { return y; } set { y = value; } }



        public Ficha(int x, int y, string pColor)
        {
            this.PosX = x;
            this.PosY = y;
            this.color = pColor;
        }

    }


    public class Peon:Ficha
    {

        //public string nombre = "PB";
        //private int x;
        //public int PosX { get { return x; } set { x = value; } }
        //private int y;
        //public int PosY { get { return y; } set { y = value; } }



        public Peon(int x, int y, string color) : base(x, y, color)
        {
            this.PosX = x;
            this.PosY = y;
            this.Color = color;
            this.Nombre = "P" + color.ToString();
        }


    }


}
