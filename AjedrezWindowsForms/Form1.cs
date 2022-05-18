using AjedrezLogica;
namespace AjedrezWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        Juego Juego = new Juego();
        Bitmap [] ImagenesFichas;
        Bitmap CuadroBlanco = new Bitmap(Properties.Resources.CuadroBlanco, 100, 100);
        Bitmap CuadroNegro = new Bitmap(Properties.Resources.CuadroNegro, 100, 100);
        Brush pen = new SolidBrush(Color.SaddleBrown);

        private void Form1_Load(object sender, EventArgs e)
        {
            fichaSeleccionada = false;
            ImagenesFichas = CrearImagenes();
            //Este codigo es para el refresh mas suave
            SetStyle(ControlStyles.UserPaint
              | ControlStyles.OptimizedDoubleBuffer
              | ControlStyles.AllPaintingInWmPaint, true);
        }

        private Bitmap[] CrearImagenes()
        {
            Bitmap[] imagenes = new Bitmap[12];

            imagenes[0] = new Bitmap(Properties.Resources.PeonBlanco, 100, 100);
            imagenes[1] = new Bitmap(Properties.Resources.PeonNegro, 100, 100);
            imagenes[2] = new Bitmap(Properties.Resources.TorreBlanco, 100, 100);
            imagenes[3] = new Bitmap(Properties.Resources.TorreNegro, 100, 100);
            imagenes[4] = new Bitmap(Properties.Resources.CaballoBlanco, 100, 100);
            imagenes[5] = new Bitmap(Properties.Resources.CaballoNegro, 100, 100);
            imagenes[6] = new Bitmap(Properties.Resources.AlfilBlanco, 100, 100);
            imagenes[7] = new Bitmap(Properties.Resources.AlfilNegro, 100, 100);
            imagenes[8] = new Bitmap(Properties.Resources.ReinaBlanco, 100, 100);
            imagenes[9] = new Bitmap(Properties.Resources.ReinaNegro, 100, 100);
            imagenes[10] = new Bitmap(Properties.Resources.ReyBlanco, 100, 100);
            imagenes[11] = new Bitmap(Properties.Resources.ReyNegro, 100, 100);

            return imagenes;
        }
       
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            ImprimirTablero(g);
        }

        private void ImprimirTablero(Graphics g)
        {
           
            bool CambioColor = true;

            g.FillRectangle(pen, new Rectangle(90, 90, 820, 820));
            //g.DrawLine(pen, new Point(99,99), new Point(99,900));

            for (int x = 100; x < 900; x += 100) 
            {
                for (int y = 100; y < 900; y += 100)
                {
                    if (CambioColor)
                    {
                        g.DrawImage(CuadroBlanco, new Point(x, y));
                    }
                    else
                    {
                        g.DrawImage(CuadroNegro, new Point(x, y));
                    }
                    CambioColor = !CambioColor;
                }
                CambioColor = !CambioColor;
            }
            ImprimirFichas(g);
        }

        private void ImprimirFichas(Graphics g)
        {
            int x = 0;
            int y = 0;


            foreach (var ficha in this.Juego.JugadorBlanco.MisFichas)
            {
                if (ficha.EnMovimiento == true)
                {
                    g.DrawImage(ImagenesFichas[ficha.IdImagen], new Point(mouseX-50, mouseY-50));
                }
                else
                {
                    x = 100 * ficha.PosX;
                    y = 100 * ficha.PosY;

                    x += 100;
                    y += 100;
                    g.DrawImage(ImagenesFichas[ficha.IdImagen], new Point(y, x));
                }              
            }

            foreach (var ficha in this.Juego.JugadorNegro.MisFichas)
            {

                if (ficha.EnMovimiento == true)
                {
                    g.DrawImage(ImagenesFichas[ficha.IdImagen], new Point(mouseX - 50, mouseY - 50));
                }
                else
                {
                    x = 100 * ficha.PosX;
                    y = 100 * ficha.PosY;

                    x += 100;
                    y += 100;
                    g.DrawImage(ImagenesFichas[ficha.IdImagen], new Point(y, x));
                }
            }


        }

        bool fichaSeleccionada;
        int XmouseSelect, YmouseSelect;

        private void TimerGame_Tick(object sender, EventArgs e)
        {
            label1.Text = mouseX.ToString() + "   " + mouseY.ToString();

            if (fichaSeleccionada)
            {
                SeleccionarFicha();
            }
            
            


            Refresh();
        }

        Ficha fichaSelect;
        private void SeleccionarFicha()
        {
            fichaSeleccionada = false;
            //Busco la coordenada
            int x = BuscarPos(this.XmouseSelect);
            int y = BuscarPos(this.YmouseSelect);



            if (Juego.HayGanador == "no") 
            {
               
                if (this.Juego.ComprobarFichaWForms(x, y))
                {
                    if (this.Juego.WhiteTurn)
                    {
                        fichaSelect = this.Juego.JugadorBlanco.FichaSeleccionada;
                        this.Juego.JugadorBlanco.ActualizarFichaEnMovimiento(true);
                    }
                    else
                    {
                        fichaSelect = this.Juego.JugadorNegro.FichaSeleccionada;
                        this.Juego.JugadorNegro.ActualizarFichaEnMovimiento(true);
                    }                                   
                }
            }

            //while (Juego.HayGanador == "no") { SeleccionarFicha(); }

            //if (Juego.HayGanador == "Blanco")
            //{
            //    Console.Write("Ganador" + Juego.JugadorBlanco.Nombre.ToString() + " Jugador Blanco");
            //}
            //else
            //{
            //    Console.Write("Ganador" + Juego.JugadorNegro.Nombre.ToString() + " Jugador Negro");
            //}

        }

        private int BuscarPos(int Posicion)
        {
            if (Posicion >= 100 && Posicion <= 200)
            {
                return 0;
            }

            if (Posicion >= 200 && Posicion <= 300)
            {
                return 1;
            }

            if (Posicion >= 300 && Posicion <= 400)
            {
                return 2;
            }

            if (Posicion >= 400 && Posicion <= 500)
            {
                return 3;
            }

            if (Posicion >= 500 && Posicion <= 600)
            {
                return 4;
            }

            if (Posicion >= 600 && Posicion <= 700)
            {
                return 5;
            }

            if (Posicion >= 700 && Posicion <= 800)
            {
                return 6;
            }

            if (Posicion >= 800 && Posicion <= 900)
            {
                return 7;
            }

            return -1;
        }


        #region Detecta el click y la posicion del mouse
        int mouseX, mouseY;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //Por la forma que se dibuja el tablero, tengo que invertir los ejes x e y 
            XmouseSelect = e.Y;
            YmouseSelect = e.X;
            fichaSeleccionada = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.Juego.WhiteTurn)
            {
                this.Juego.JugadorBlanco.ActualizarFichaEnMovimiento(false);
            }
            else
            {
                this.Juego.JugadorNegro.ActualizarFichaEnMovimiento(false);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }
        #endregion //Mouse
    }
}