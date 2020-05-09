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
                S.Silla = textBox1.Text;
                S.Estado = textBox2.Text;
                msj= S.Registrar_Silla();

                MessageBox.Show(msj);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void Registrar_Load(object sender, EventArgs e)
        {
            List<string> Sillas = S.ListadoSillas();
            string Item;

            for (int i = 0; i < Sillas.Count(); i++)
            {
                Item = Sillas[i];
                comboBox1.Items.Add(Item);
            }
            
        }
    }
}
