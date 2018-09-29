using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoDisparos
{
    public partial class Form1 : Form
    {
        private int velocidad = 1;
        private bool direccionIzq;

        public string LblMarcador
        {
            set { lblMarcador.Text = value; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            lblMarcador.Text = "asceroid Invaders!";
            //nuevoAsceroide();
        }

        public void NuevaPartida()
        {

            velocidad = 1;
            nuevoAsceroide();
        }


        private void nuevoAsceroide()
        {
            pbAsceroide.Image = Properties.Resources.asceriode;
            Random r = new Random(DateTime.Now.Millisecond);
            pbAsceroide.Left=r.Next(0, panel1.Width - pbAsceroide.Width);
            pbAsceroide.Top = -pbAsceroide.Height;
            if (pbAsceroide.Left / 2 == 0)
                direccionIzq = true;
            else direccionIzq = false;
            timerMisiles.Enabled = true;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    pbNave.Left-=10;
                break;

                case Keys.Right:
                    pbNave.Left+=10;
                break;

                case Keys.Space:
                    disparo();
                break;

            }
        }

        private void disparo()
        {
            PictureBox pbDisparo = new PictureBox();
            pbDisparo.Name = "pbDisparo";
            pbDisparo.Image = Properties.Resources.misil;
            pbDisparo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbDisparo.Height = 80;
            pbDisparo.Width = 15;
            pbDisparo.Left = pbNave.Left + pbNave.Width / 2;
            pbDisparo.Top = pbNave.Top;
            panel1.Controls.Add(pbDisparo);
        }

        private void timerMisiles_Tick(object sender, EventArgs e)
        {
            //Actualizamos los misiles
            foreach (Control c in panel1.Controls)
            {
                
                if (c.Name == "pbDisparo")
                {
                    //Avanzamos la posicion
                    c.Top -= 5;
                    //Comprobamos impactos
                    if (c.Bounds.IntersectsWith(pbAsceroide.Bounds)) impacto(c);
                }

            }

            //Avanzamos el asceroide
            //if es aleatorio
            if (direccionIzq)
            {
                pbAsceroide.Top += velocidad;
                pbAsceroide.Left -= velocidad;

                if (pbAsceroide.Left <= 0) direccionIzq = false;


            }
            else//sentido contrario
            {
                pbAsceroide.Top += velocidad;
                pbAsceroide.Left += velocidad;

                if (pbAsceroide.Left >= panel1.Width-pbAsceroide.Width)
                    direccionIzq = true;
                

            }
            
        }

        private void impacto(Control c)
        {
            c.Visible = false;
            pbAsceroide.Image = Properties.Resources.explosion;
            timerExplosion.Start();
            velocidad++;

        }

        private void timerExplosion_Tick(object sender, EventArgs e)
        {
            nuevoAsceroide();
            timerExplosion.Stop();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuevaPartidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevaPartidaForm f = new NuevaPartidaForm(this);
            f.Show();

        }

        private void reiniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
