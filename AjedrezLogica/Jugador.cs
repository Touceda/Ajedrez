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
        List<Ficha> FichasMuertas = new List<Ficha>();
        public List<Ficha> MisFichasMuertas { get { return FichasMuertas; } }

        private Ficha fichaseleccionada;
        public Ficha FichaSeleccionada { get { return fichaseleccionada; } set { fichaseleccionada = value; } }

        public Jugador(string pNombre, bool pIsblack)
        {
            this.Nombre = pNombre;
            this.isblack = pIsblack;

            if (this.IsBlack)
            {
                CrearFichas();
            }
            else
            {
                CrearFichas();
            }
            
        }

        public Ficha UltimaFichaComida;
        public bool comificha = false;

        public void JugarTurno()//nada de momento
        { 
        
        
        
        
        
        }

        public bool SeleccionarFicha()
        {
            foreach (var f in MisFichas)
            {
                if (f == fichaseleccionada) 
                {
                    return true;
                }
            }
            return false;
        }

        public bool MoverFicha(int x, int y, List<Ficha> fichasEnemigas)
        {
            bool moviFicha = false;
            foreach (var f in MisFichas) // Busco la ficha
            {
                if (f == fichaseleccionada) //La selecciono
                {
                    if (f.MoverFicha(x, y, fichasEnemigas)) //La muevo, si da true se movio con exito, si da false no se movio
                    {
                        moviFicha = true;
                        if (f.comi)//Si se movio, compruebo si comio o no
                        {
                            f.comi = false;
                            this.comificha = true;
                            UltimaFichaComida = f.FichaEnemigaComida;
                        }
                        
                    }                                    
                }
            }
            return moviFicha;
        }



        public void MatarFicha(Ficha FichaMuerta)
        {
            Fichas.Remove(FichaMuerta);
            FichasMuertas.Add(FichaMuerta);       
        }

        public void CrearFichas()
        {
            if (isblack)
            {
                Fichas.Add(new Peon(6, 0, "N"));
                Fichas.Add(new Peon(6, 1, "N"));
                Fichas.Add(new Peon(6, 2, "N"));
                Fichas.Add(new Peon(6, 3, "N"));
                Fichas.Add(new Peon(6, 4, "N"));
                Fichas.Add(new Peon(6, 5, "N"));
                Fichas.Add(new Peon(6, 6, "N"));
                Fichas.Add(new Peon(6, 7, "N"));
                return;
            }

            Fichas.Add(new Peon(1, 0, "B"));
            Fichas.Add(new Peon(1, 1, "B"));
            Fichas.Add(new Peon(1, 2, "B"));
            Fichas.Add(new Peon(1, 3, "B"));
            Fichas.Add(new Peon(1, 4, "B"));
            Fichas.Add(new Peon(1, 5, "B"));
            Fichas.Add(new Peon(1, 6, "B"));
            Fichas.Add(new Peon(1, 7, "B"));
        }
    }
}
