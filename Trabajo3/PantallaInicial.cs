using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo3
{
    public partial class PantallaInicial : Form
    {
        public PantallaInicial()
        {
            InitializeComponent();
        }

        private void PantallaInicial_Load(object sender, EventArgs e)
        {
            //ObtenerConexion.Conexion();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 pantallatest = new Form1();
            pantallatest.ShowDialog();
            this.Show();
        }

        private void btnIntro_Click(object sender, EventArgs e)
        {
            this.Hide();
            acerca intro = new acerca();
            intro.ShowDialog();
            this.Show();
        }

        private void btnacerca_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nosotros acerca = new Nosotros();
            acerca.ShowDialog();
            this.Show();
        }
    }
}