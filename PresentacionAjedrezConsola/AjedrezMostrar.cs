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
            SeleccionarFicha();
        }

        public void TurnoDe()
        {
        

            if (this.Juego.BlackTurn)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Turno De:  " +this.Juego.jugador2.Nombre.ToString());
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Turno De:  " +this.Juego.jugador1.Nombre.ToString());
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public void ImprimirTablero(EspacioTablero[,] tab)
        {
            Console.Clear();

            TurnoDe();
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
        

        public void SeleccionarFicha()
        {
            try
            {
                string ficha = "";
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Ejemplo 3B");
                Console.WriteLine("Seleccione la ficha para mover: ");
                ficha = Console.ReadLine();
                ficha = ficha[0].ToString() + ficha[1].ToString();


                if (this.Juego.ComprobarFichaConsola(ficha))
                {
                    AdondeMover(ficha);
                }
                else
                {
                    ErrorReinicioDeSeleccion();
                }

                
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Error al seleccionar ficha, Precione Enter para reiniciar Turno");
                Console.ReadLine();
                ImprimirTablero(this.Juego.MiTablero);
                SeleccionarFicha();
            }
            
        } //Selecciono la ficha y compruebo que este bien

        public void AdondeMover(string ficha)
        {
            try
            {
                Console.Clear();
                ImprimirTablero(Juego.MiTablero);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Ficha Seleccionada:  " + ficha.ToString());
                Console.WriteLine("Seleccione a donde se quiere mover: ");
                string moverficha = Console.ReadLine();
                moverficha = moverficha[0].ToString() + moverficha[1].ToString();


                if (this.Juego.ComprobarMovimientoConsola(moverficha))
                {
                    ImprimirTablero(Juego.MiTablero);
                }
                else
                {
                    ErrorReinicioDeMovimiento(ficha);
                }


            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Error al Mover la ficha, Precione Enter para reiniciar Turno");
                Console.ReadLine();
                ImprimirTablero(this.Juego.MiTablero);
                SeleccionarFicha();
            }

        }//Selecciono el movimiento y veo si esta bien


        public void ErrorReinicioDeSeleccion()
        {
            Console.Clear();
            Console.WriteLine("Error al seleccionar ficha, Precione Enter para reiniciar Turno");
            Console.ReadLine();
            ImprimirTablero(this.Juego.MiTablero);
            SeleccionarFicha();
        }
        public void ErrorReinicioDeMovimiento(string ficha)
        {
            Console.Clear();
            Console.WriteLine("Error al Mover ficha, Precione Enter para reiniciar Movimiento");
            AdondeMover(ficha);
        }


    


     
        


    }
}
