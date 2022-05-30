using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLajedrez;

namespace AjedrezWindowsForms
{
    public partial class Jugadores : Form
    {
        SqlJugadores JugadoresSQL = new SqlJugadores();

        public Jugadores()
        {
            InitializeComponent();
            
        }

        Form1 Juego;
        private void Jugadores_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                if (txtNegro.Text.Length >= 3 && txtBlanco.Text.Length >= 3 && txtBlanco.Text != txtNegro.Text)
                {
                    JugadoresSQL.CargarNuevaPartida(txtBlanco.Text, txtNegro.Text);
                    Juego = new Form1(txtBlanco.Text.ToString(), txtNegro.Text.ToString());
                    Juego.ShowDialog();
                    this.Close();
                }
                else
                {
                    lblError.Text = "Nombre Incorrecto, Revisar que tenga 3 o mas digitos y no se repiran los mismos";
                }
               

            }
            catch (Exception)
            {
                MessageBox.Show("Problemas de Sql");
                throw;
            }

        }
    }
}
