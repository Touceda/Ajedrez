﻿using System;
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

        public Jugador(string pNombre, bool pIsblack)
        {
            this.Nombre = pNombre;
            this.isblack = pIsblack;

            if (this.IsBlack)
            {
                CrearFichasNegras();
            }
            else
            {
                CrearFichasBlancas();
            }
            
        }




        public void CrearFichasBlancas()
        {
            Fichas.Add(new Peon(1, 0, "B"));
            Fichas.Add(new Peon(1, 1, "B"));
            Fichas.Add(new Peon(1, 2, "B"));
            Fichas.Add(new Peon(1, 3, "B"));
            Fichas.Add(new Peon(1, 4, "B"));
            Fichas.Add(new Peon(1, 5, "B"));
            Fichas.Add(new Peon(1, 6, "B"));
            Fichas.Add(new Peon(1, 7, "B"));
        }

        public void CrearFichasNegras()
        {
            Fichas.Add(new Peon(6, 0, "N"));
            Fichas.Add(new Peon(6, 1, "N"));
            Fichas.Add(new Peon(6, 2, "N"));
            Fichas.Add(new Peon(6, 3, "N"));
            Fichas.Add(new Peon(6, 4, "N"));
            Fichas.Add(new Peon(6, 5, "N"));
            Fichas.Add(new Peon(6, 6, "N"));
            Fichas.Add(new Peon(6, 7, "N"));
        }
    }
}
