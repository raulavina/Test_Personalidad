using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Trabajo3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            
            string texto = txtTexto.Text;
            string[] palabras;
            palabras = texto.Split(' ');
            int palAuditivas = 0;
            int palKinestesicas = 0;
            int palVisuales = 0;
            txtTexto.Clear();
            lbPalabras.Items.Clear();
            try
             {
               //ObtenerConexion.Conexion();
                for (int i = 0; i < palabras.Length; i++)
                {
                    lbPalabras.Items.Add(palabras[i]);

                    MySqlCommand consulta = new MySqlCommand("SELECT Palabras FROM `auditivo` WHERE Palabras LIKE '%" + palabras[i] + "%';", ObtenerConexion.Conexion());
                    MySqlDataReader resultado = consulta.ExecuteReader();
                    if (resultado.HasRows)
                    {
                        palAuditivas++;
                        //MessageBox.Show("Encontro una palabra en 'Auditivo'");
                    }

                    MySqlCommand consulta2 = new MySqlCommand("SELECT Palabras FROM `kinestesico` WHERE Palabras LIKE '%" + palabras[i] + "%';", ObtenerConexion.Conexion());
                    MySqlDataReader resultado2 = consulta2.ExecuteReader();
                    if (resultado2.HasRows)
                    {
                        palKinestesicas++;
                        //MessageBox.Show("Encontro una palabra en 'Kinestesica'");
                    }

                    MySqlCommand consulta3 = new MySqlCommand("SELECT Palabras FROM `visual` WHERE Palabras LIKE '%" + palabras[i] + "%';", ObtenerConexion.Conexion());
                    MySqlDataReader resultado3 = consulta3.ExecuteReader();
                    if (resultado3.HasRows)
                    {
                        palVisuales++;
                        //MessageBox.Show("Encontro una palabra en 'Visual'");
                    }

                    ObtenerConexion.Conexion().Close();
                }
                MessageBox.Show("Se detecto: \n" + palAuditivas + " palabras Auditivas\n"+
                    palKinestesicas + " palabras Kinestesicas\n" + palVisuales+" palabras Visuales",
                    "La oracion introducida tiene: " + palabras.Length + " palabras");

                if (palAuditivas>palVisuales && palAuditivas>palKinestesicas){
                    Auditivo resultadoAud = new Auditivo();
                    resultadoAud.ShowDialog();
                }
                if (palVisuales > palKinestesicas && palVisuales > palAuditivas) {
                    Visual resultadoVis = new Visual();
                    resultadoVis.ShowDialog();
                }
                if (palKinestesicas > palVisuales && palKinestesicas > palAuditivas) {
                    Kinestesico resultadoKin = new Kinestesico();
                    resultadoKin.ShowDialog();
                }
                

             }
          catch (MySqlException ex) { 
           MessageBox.Show(string.Concat(ex)); 
           }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Close();
        }

    }
}
