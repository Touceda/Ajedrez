using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AjedrezLogica;

namespace PresentacionAjedrezConsola
{
    public class AjedrezMostrar
    {
        private Juego Juego;

        public AjedrezMostrar()
        {
            Juego = new Juego();
            ImprimirTablero(Juego.MiTablero);
            Console.ReadLine();
        }


        public void ImprimirTablero(EspacioTablero[,] tab)
        {
            bool cambiocolor = true;
            var tabaux = tab;
            Console.ForegroundColor = ConsoleColor.Red; //Cambio color
            Console.WriteLine("    A   B   C   D   E   F   G   H"); //██
            Console.WriteLine();

            for (int x = 0; x < 8; x++) 
            {
                cambiocolor = !cambiocolor;
                Console.ForegroundColor = ConsoleColor.Red; //Cambio color
                Console.Write(x.ToString()+"  ") ;
                for (int y = 0; y < 8; y++)
                {
                   
                    if (cambiocolor)//Este if cambia el color para simular un tablero
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    cambiocolor = !cambiocolor;



                    if (tabaux[x, y].IsOcuped == false)
                    {
                        Console.Write(tabaux[x, y].nombre + "  ");
                    }
                    else
                    {
                        //Console.OutputEncoding = System.Text.Encoding.Unicode;
                        //Console.WriteLine("♙ \xU+265F");
                        
                        if (tabaux[x, y].MiFicha.Color == "B") 
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(tabaux[x, y].MiFicha.Nombre + "  ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write(tabaux[x, y].MiFicha.Nombre + "  ");
                        }
                        
                    }
                    
                    
                }
                Console.WriteLine();
            }

                
            










        }
    }
}
