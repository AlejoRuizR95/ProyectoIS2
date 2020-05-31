using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocio;

namespace Presentacion
{
    public partial class Registrar : Form
    {
        ClsSala S = new ClsSala();
        public Registrar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msj = "";
            try
            {
              msj= S.Programar_Pelicula(Convert.ToString(comboBoxPelicula.SelectedItem), txtSala.Text, Calendar1.SelectionStart.ToString("dd\\/MM\\/yyyy"), txtHora.Text); 

                MessageBox.Show(msj);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void Registrar_Load(object sender, EventArgs e)
        {
            List<string> Sillas = S.ListadoPeliculas();
            string Item;

            for (int i = 0; i < Sillas.Count(); i++)
            {
                Item = Sillas[i];
                comboBoxPelicula.Items.Add(Item);
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Inicio ini = new Inicio();
            this.Hide();
            ini.Show();
        }
    }
}
