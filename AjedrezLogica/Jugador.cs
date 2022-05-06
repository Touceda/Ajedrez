using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezLogica
{
    public class Jugador
    {
        string nombre;
        public string Nombre { get { return nombre; } set { nombre = value;} }

        bool isblack;
        public bool IsBlack { get { return isblack; } set { isblack = value; } }

        List<Ficha> Fichas = new List<Ficha> ();
        public List<Ficha> MisFichas { get { return Fichas; } }

        List<Ficha> fichasComidas = new List<Ficha>();
        public List<Ficha> FichasComidas { get { return fichasComidas; } }

        private Ficha fichaseleccionada;
        public Ficha FichaSeleccionada { get { return fichaseleccionada; } set { fichaseleccionada = value; } }

        public Jugador(string pNombre, bool pIsblack)
        {
            this.Nombre = pNombre;
            this.isblack = pIsblack;
            CrearFichas();      
        }
       
       
        public bool SeleccionarFicha(int x, int y)
        {
            foreach (var ficha in MisFichas)
            {
                if (ficha.PosX == x && ficha.PosY == y)  
                {
                    this.fichaseleccionada = ficha;
                    return true;
                }
            }
            return false;
        }

        public bool MoverFicha(int x, int y, List<Ficha> fichasEnemigas, EspacioTablero[,] tab)
        {
            bool moviFicha = false;
            foreach (var ficha in MisFichas) // recorro las fichas
            {
                if (ficha == fichaseleccionada) //Selecciono la ficha que se tiene que mover
                {
                    if (ficha.MoverFicha(x, y, fichasEnemigas,tab)) //La mando a mover, Si da true, Se movio, Si da false el movimiento no era correcto
                    {
                        moviFicha = true;
                        ComprobarSiComiFicha(ficha); //Si se movio compruebo si comi o no                        
                    }                                    
                }
            }
            return moviFicha;
        }

        public bool comiFicha = false;
        public Ficha UltimaFichaComida;
        private void ComprobarSiComiFicha(Ficha ficha)
        {
            if (ficha.ComiFicha)
            {
                ficha.ComiFicha = false;
                this.FichasComidas.Add(ficha.FichaEnemigaComida);
                this.comiFicha = true;
                this.UltimaFichaComida = ficha.FichaEnemigaComida;
            }
        }

        public void MatarFicha(Ficha FichaMuerta)
        {
            Fichas.Remove(FichaMuerta);
        }

        private void CrearFichas()
        {

            if (isblack)
            {
                //Fichas.Add(new Peon(6, 0, "N"));
                //Fichas.Add(new Peon(6, 1, "N"));
                //Fichas.Add(new Peon(6, 2, "N"));
                //Fichas.Add(new Peon(6, 3, "N"));
                //Fichas.Add(new Peon(6, 4, "N"));
                //Fichas.Add(new Peon(6, 5, "N"));
                //Fichas.Add(new Peon(6, 6, "N"));
                //Fichas.Add(new Peon(6, 7, "N"));

                //Fichas.Add(new Torre(0, 3, "N"));
                //Fichas.Add(new Torre(3, 3, "N"));

                Fichas.Add(new Caballo(0, 0, "N"));
                Fichas.Add(new Caballo(3, 4, "N"));

                //Fichas.Add(new Alfil(3, 3, "N"));
                //Fichas.Add(new Alfil(0, 0, "N"));

                //Fichas.Add(new Rey(7, 4, "N"));
                return;
            }


            //Fichas.Add(new Peon(1, 0, "B"));
            //Fichas.Add(new Peon(1, 1, "B"));
            //Fichas.Add(new Peon(1, 2, "B"));
            //Fichas.Add(new Peon(1, 3, "B"));
            //Fichas.Add(new Peon(1, 4, "B"));
            //Fichas.Add(new Peon(1, 5, "B"));
            //Fichas.Add(new Peon(1, 6, "B"));
            //Fichas.Add(new Peon(1, 7, "B"));

            //Fichas.Add(new Torre(0, 0, "B"));
            //Fichas.Add(new Torre(4, 4, "B"));

            Fichas.Add(new Caballo(7, 7, "B"));
            Fichas.Add(new Caballo(5, 3, "B"));

            //Fichas.Add(new Alfil(4, 4, "B"));
            //Fichas.Add(new Alfil(7, 4, "B"));

            //Fichas.Add(new Rey(0, 4, "B"));
        }
    }
}
