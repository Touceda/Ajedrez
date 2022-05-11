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

        private string fichaSeleccionada;
        public string FichaSeleccionada { get { return fichaSeleccionada; } }

        public void ReinicarFicha() { this.fichaSeleccionada = "0"; }


        public Juego()
        {
            JugadorBlanco = new Jugador("Nicolas",false);//Modificar a la capa de consola, pasar nombre y quien es blanco
            JugadorNegro = new Jugador("Bautista", true);//Modificar a la capa de consola, pasar nombre y quien es blanco
            whiteturn = true;
            this.MiTablero = Tablero.ActualizarTablero(JugadorBlanco.MisFichas,JugadorNegro.MisFichas);
            this.fichaSeleccionada = "0";
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

            this.fichaSeleccionada = x.ToString() + y.ToString();

            if (this.WhiteTurn)
            {
                if (JugadorBlanco.SeleccionarFicha(x, y))
                {
                    return true;
                }
                this.fichaSeleccionada = "0";
                return false;
            }
            else
            {
                if (JugadorNegro.SeleccionarFicha(x, y))
                {
                    return true;
                }
                this.fichaSeleccionada = "0";
                return false;
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

            return isTrue;
        } //Compruebo si el movimineto es correcto

        public void CambioDeTruno()
        {
            MiTablero = Tablero.ActualizarTablero(JugadorBlanco.MisFichas, JugadorNegro.MisFichas);
            this.whiteturn = !whiteturn;
        }

        public bool ComprobarCambioDeFicha() //Caso de que peon este en el limite del tablero
        {
            if (this.WhiteTurn)
            {
                if (JugadorBlanco.cambioPeon)
                {
                    return true;
                }
            }
            else
            {
                if (JugadorNegro.cambioPeon)
                {
                    return true;
                }
            }
            return false;
        }

        public void CambiarPeon(string ficha)
        {
            if (this.WhiteTurn)
            {
                JugadorBlanco.CambiarPeon(ficha);
            }
            else
            {
                JugadorNegro.CambiarPeon(ficha);
            }
        }

        private void ComprobarSiComiFicha(bool movimientoRealizado)
        {
            if (this.WhiteTurn)
            {

                if (movimientoRealizado && JugadorBlanco.comiFicha)
                {
                    Ficha fichaMuerta = JugadorBlanco.UltimaFichaComida;
                    JugadorBlanco.comiFicha = false;
                    JugadorNegro.MatarFicha(fichaMuerta);
                    if (fichaMuerta is Rey)
                    {
                        this.HayGanador = "Blanco";
                    }
                }
            }

            if (WhiteTurn == false)
            {
                if (movimientoRealizado && JugadorNegro.comiFicha)
                {
                    Ficha fichaMuerta = JugadorNegro.UltimaFichaComida;
                    JugadorNegro.comiFicha = false;
                    JugadorBlanco.MatarFicha(fichaMuerta);
                    if (fichaMuerta is Rey)
                    {
                        this.HayGanador = "Negro";
                    }
                }
            }
        }




    }
}

