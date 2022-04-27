using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezLogica
{
    public class Juego
    {
        public Jugador JugadorBlanco; //Configurar para que sea el Blanco ??????????????????????????????????
        public Jugador JugadorNegro;//Configurar para que sea el negro ???????????????????????????
        public bool BlackTurn;
        private EspacioTablero[,] tablero;
        public EspacioTablero[,] MiTablero { get { return tablero; }set { tablero = value; } }
        public string HayGanador = "no";


        public Juego()
        {
            JugadorBlanco = new Jugador("Nicolas",false);//Modificar a la capa de consola, pasar nombre y quien es blanco
            JugadorNegro = new Jugador("Bautista", true);//Modificar a la capa de consola, pasar nombre y quien es blanco
            BlackTurn = false;
            this.MiTablero = Tablero.ActualizarTablero(JugadorBlanco.MisFichas,JugadorNegro.MisFichas);
        }



        public bool ComprobarFichaConsola(string ficha)
        {
            int x;
            int y;


            x = int.Parse(ficha[0].ToString());

            y = Tablero.ConvertStringToInt(ficha[1].ToString());

            if (y == -1)
            {
                return false;
            }

            Ficha fichaSeleccionada = MiTablero[x, y].MiFicha;

            if (fichaSeleccionada == null) //Si no hay ficha en la posicion devuelvo falso para reiniciar el tablero
            {
                return false;
            }

            if (BlackTurn)
            {
                JugadorNegro.FichaSeleccionada = fichaSeleccionada;
                return JugadorNegro.SeleccionarFicha();
            }
            else
            {
                JugadorBlanco.FichaSeleccionada = fichaSeleccionada;
                return JugadorBlanco.SeleccionarFicha();
            }
        } //Compruebo que seleccione una ficha de forma correcta

        public bool ComprobarMovimientoConsola(string ficha)
        {
            int x;
            int y;


            x = int.Parse(ficha[0].ToString());
            y = Tablero.ConvertStringToInt(ficha[1].ToString());

            if (y == -1)  
            {
                return false;
            }

            bool isTrue;
            if (BlackTurn)
            {
               isTrue = JugadorNegro.MoverFicha(x,y,JugadorBlanco.MisFichas);
                if (isTrue && JugadorNegro.comificha)
                {
                    Ficha fichaMuerta = JugadorNegro.UltimaFichaComida;
                    JugadorNegro.comificha = false;
                    JugadorBlanco.MatarFicha(fichaMuerta);

                }
            }
            else
            {
                isTrue = JugadorBlanco.MoverFicha(x,y,JugadorNegro.MisFichas);
                if (isTrue && JugadorBlanco.comificha)
                {
                    Ficha fichaMuerta = JugadorBlanco.UltimaFichaComida;
                    JugadorBlanco.comificha = false;
                    JugadorNegro.MatarFicha(fichaMuerta);
                }           
            }



            if (isTrue)
            {
                MiTablero = Tablero.ActualizarTablero(JugadorBlanco.MisFichas, JugadorNegro.MisFichas);
                BlackTurn = !BlackTurn;
            }

            return isTrue;
        } //Compruebo si el movimineto es correcto






    }
}

