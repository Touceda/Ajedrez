using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezLogica
{
    public class EspacioTablero
    {
        public string nombre;

        bool isocuped;
        public bool IsOcuped { get { return isocuped; } set { isocuped = value; } }
        Ficha ficha;
        public Ficha MiFicha { get { return ficha; } set { ficha = value; } }
        private int x;
        public int PosX { get { return x; } }
        private int y;
        public int PosY { get { return y; } }

        public EspacioTablero(int pX, int pY)
        {
            this.x = pX;
            this.y = pY;
            this.MiFicha = null;
            this.isocuped = false;

            string letra = "";
            switch (PosY)
            {
                case 0: { letra = "A"; break; }
                case 1: { letra = "B"; break; }
                case 2: { letra = "C"; break; }
                case 3: { letra = "D"; break; }
                case 4: { letra = "E"; break; }
                case 5: { letra = "F"; break; }
                case 6: { letra = "G"; break; }
                case 7: { letra = "H"; break; }

                default:
                    letra = "Error";
                    break;
            }
            this.nombre = x.ToString() + letra.ToString();
            this.nombre = "██"; //Probando 
            
        }

    
    }
}
