using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using SQLajedrez;

namespace AjedrezWindowsForms
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        Form Juego;

        private void btbNewGame_Click(object sender, EventArgs e)
        {
            Juego = new Jugadores();
            Juego.ShowDialog();
            this.Close();

        }

        private void btbContinuarPartida_Click(object sender, EventArgs e)
        {
            SqlPartidaJugada PartidaEmpezada = new SqlPartidaJugada();
            try
            {
                int x = int.Parse(Interaction.InputBox("Cual es su ID de partida?", "Titulo"));

                if (PartidaEmpezada.ValidarPartidaExistente(x))
                {
                    Juego = new Form1(x, "a", "b", true);
                    Juego.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Esta partida no existe o ya esta finalizada, Podes utilizar el mismo Id para ver la repeticion");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un Error con su ID de partida, Por favor vuelva a intentar");
            }
        }

        private void btbVerPartida_Click(object sender, EventArgs e)
        {
            //SqlPartidaJugada PartidaEmpezada = new SqlPartidaJugada();
            //try
            //{
            //    var x = Interaction.InputBox("Cual es su ID de partida?", "Titulo");
            //    if (PartidaEmpezada.ValidarPartidaExistente())
            //    {

            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Ocurrio un Error con su ID de partida, Por favor vuelva a intentar");      
            //}           
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
