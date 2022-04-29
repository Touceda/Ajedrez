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
        private bool whiteturn;
        public bool WhiteTurn { get { return whiteturn; } } /*set { whiteturn = value; } }*/
        private EspacioTablero[,] tablero;
        public EspacioTablero[,] MiTablero { get { return tablero; }set { tablero = value; } }
        public string HayGanador = "no";


        public Juego()
        {
            JugadorBlanco = new Jugador("Nicolas",false);//Modificar a la capa de consola, pasar nombre y quien es blanco
            JugadorNegro = new Jugador("Bautista", true);//Modificar a la capa de consola, pasar nombre y quien es blanco
            whiteturn = true;
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

            //Ficha fichaSeleccionada = MiTablero[x, y].MiFicha;

            //if (fichaSeleccionada == null) //Si no hay ficha en la posicion devuelvo falso para reiniciar el tablero
            //{
            //    return false;
            //}

            if (this.WhiteTurn)
            {
                return JugadorBlanco.SeleccionarFicha(x, y);
            }
            else
            {
                return JugadorNegro.SeleccionarFicha(x, y);
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
            if (this.WhiteTurn)
            {
                isTrue = JugadorBlanco.MoverFicha(x, y, JugadorNegro.MisFichas,this.MiTablero);
                ComprobarSiComiFicha(isTrue);
            }
            else
            {
                isTrue = JugadorNegro.MoverFicha(x, y, JugadorBlanco.MisFichas,this.MiTablero);
                ComprobarSiComiFicha(isTrue);
            }



            if (isTrue)
            {
                MiTablero = Tablero.ActualizarTablero(JugadorBlanco.MisFichas, JugadorNegro.MisFichas);
                this.whiteturn = !whiteturn;
            }

            return isTrue;
        } //Compruebo si el movimineto es correcto

        private void ComprobarSiComiFicha(bool movimientoRealizado)
        {
            if (this.WhiteTurn)
            {

                if (movimientoRealizado && JugadorBlanco.comiFicha)
                {
                    Ficha fichaMuerta = JugadorBlanco.UltimaFichaComida;
                    JugadorBlanco.comiFicha = false;
                    JugadorNegro.MatarFicha(fichaMuerta);
                }
            }

            if (WhiteTurn == false)
            {
                if (movimientoRealizado && JugadorNegro.comiFicha)
                {
                    Ficha fichaMuerta = JugadorNegro.UltimaFichaComida;
                    JugadorNegro.comiFicha = false;
                    JugadorBlanco.MatarFicha(fichaMuerta);

                }
            }
        }




    }
}

