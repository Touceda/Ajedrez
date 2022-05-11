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
            LoopGame();
        }


        private void LoopGame()
        {
            while (Juego.HayGanador == "no") { SeleccionarFicha(); }

            Console.Clear();
            if (Juego.HayGanador == "Blanco") 
            {
                Console.Write("Ganador" + Juego.JugadorBlanco.Nombre.ToString() + " Jugador Blanco");
            }
            else
            {
                Console.Write("Ganador" + Juego.JugadorNegro.Nombre.ToString() + " Jugador Negro");
            }
            
        }



        public void TurnoDe()
        {
        

            if (this.Juego.WhiteTurn)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Turno De:  " + this.Juego.JugadorBlanco.Nombre.ToString());
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Turno De:  " + this.Juego.JugadorNegro.Nombre.ToString());
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public void ImprimirTablero(EspacioTablero[,] tab)
        {
            Console.Clear();

            TurnoDe();
       
            int xSelect = -1;
            int ySelect = -1;
            bool cambiocolor = true;
            var tabaux = tab;
            Console.ForegroundColor = ConsoleColor.Red; //Cambio color
            Console.WriteLine("██  A   B   C   D   E   F   G   H"); //██
            Console.WriteLine();



            if (Juego.FichaSeleccionada != "0") 
            {
                xSelect = int.Parse(Juego.FichaSeleccionada[0].ToString());
                ySelect = int.Parse(Juego.FichaSeleccionada[1].ToString());
            }

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
                        Console.Write(tabaux[x, y].nombre+"  ");
                    }
                    else
                    {
                        //Console.OutputEncoding = System.Text.Encoding.Unicode;
                        //Console.WriteLine("♙ \xU+265F");
                        
                        if (tabaux[x, y].MiFicha.Color == "B") 
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            if (xSelect == x && ySelect == y) { Console.ForegroundColor = ConsoleColor.Yellow; }
                            Console.Write(tabaux[x, y].MiFicha.Nombre[0] + "B  ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            if (xSelect == x && ySelect == y) { Console.ForegroundColor = ConsoleColor.Yellow; }
                            Console.Write(tabaux[x, y].MiFicha.Nombre[0] + "N  ");
                        }
                        
                    }
                    
                    
                }
                Console.WriteLine();
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
                Console.WriteLine("Ejemplo De Formato ''3B''");
                Console.WriteLine("Seleccione la ficha para mover: ");
                ficha = Console.ReadLine();
                ficha = ficha[0].ToString() + ficha[1].ToString();
                string fichaSelect = "";

                if (this.Juego.ComprobarFichaConsola(ficha))
                {
                    if (this.Juego.WhiteTurn)
                    {
                        fichaSelect = this.Juego.JugadorBlanco.FichaSeleccionada.Nombre.ToString() + " Blanco";                       
                    }
                    else
                    {
                        fichaSelect = this.Juego.JugadorNegro.FichaSeleccionada.Nombre.ToString() + " Negro";
                    }

                    AdondeMover(ficha, fichaSelect);
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

        public void ErrorReinicioDeSeleccion()
        {
            Console.Clear();
            Console.WriteLine("Error al seleccionar ficha, Precione Enter para reiniciar Turno");
            Console.ReadLine();
            ImprimirTablero(this.Juego.MiTablero);
            SeleccionarFicha();
        }

        public void AdondeMover(string ficha,string fichaselect)
        {
            try
            {                
                Console.Clear();
                ImprimirTablero(Juego.MiTablero);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Ficha Seleccionada:  " + fichaselect + "    Escriba ''ESC'' Para seleccionar otra ficha.");
                Console.WriteLine("Seleccione a donde se quiere mover: ");
                string moverficha = Console.ReadLine();
                if (moverficha == "ESC" || moverficha == "esc" || moverficha == "Esc") 
                {
                    Juego.ReinicarFicha();
                    ImprimirTablero(Juego.MiTablero);
                    return;
                }
                moverficha = moverficha[0].ToString() + moverficha[1].ToString();


                if (this.Juego.ComprobarMovimientoConsola(moverficha))
                {
                    if (Juego.ComprobarCambioDeFicha())
                    {
                        CambioDeFicha();
                    }                 
                    Juego.CambioDeTruno();
                    ImprimirTablero(Juego.MiTablero);
                }
                else
                {
                    ErrorReinicioDeMovimiento(ficha,fichaselect);
                }


            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Error al Mover la ficha, Precione Enter para reiniciar Turno");
                Console.ReadLine();
                ImprimirTablero(this.Juego.MiTablero);
                AdondeMover(ficha,fichaselect);
            }
        }//Selecciono el movimiento y veo si esta bien

        public void CambioDeFicha()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Peon Llego al limite, Elegir ficha para remplazarla");
                Console.WriteLine();
                Console.WriteLine("1 : Torre");
                Console.WriteLine("2 : Caballo");
                Console.WriteLine("3 : Alfil");
                Console.WriteLine("4 : Reina");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Seleccione numero del 1 al 4 y precione ENTER :   ");
                switch (Console.ReadLine()[0].ToString())
                {
                    case "1": { Juego.CambiarPeon("Torre"); break; }
                    case "2": { Juego.CambiarPeon("Caballo"); break; }
                    case "3": { Juego.CambiarPeon("Alfil"); break; }
                    case "4": { Juego.CambiarPeon("Reina"); break; }
                    default: { CambioDeFicha(); break; }
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Ocurrio un error, Precione ENTER y vuelva a seleccionar ficha de remplazo");
                Console.ReadLine();
                CambioDeFicha();               
            }       
        }

        public void ErrorReinicioDeMovimiento(string ficha, string fichaselect)
        {
            Console.Clear();
            Console.WriteLine("Error al Mover ficha, Precione Enter para reiniciar Movimiento");
            Console.ReadLine();
            AdondeMover(ficha,fichaselect);
        }












    }
}
