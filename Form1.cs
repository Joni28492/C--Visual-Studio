using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace despertador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            reloj.Text = DateTime.Now.ToLongTimeString();



            if (txtAlarma.Text == reloj.Text)
            {
                //visibilidad del reloj 
                imgReloj.Visible = true;
                Detener.Enabled = true;
            }

        }

        private void Detener_Click(object sender, EventArgs e)
        {
            imgReloj.Visible = false;
            Detener.Enabled = false;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            //parpadeo

            if (Detener.Enabled == true)
            {
                if (imgReloj.Visible == true)
                    imgReloj.Visible = false;
                else
                    imgReloj.Visible = true;
            }

        }
    }
}
