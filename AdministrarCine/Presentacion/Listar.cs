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
    public partial class Listar : Form
    {

        ClsSala S = new ClsSala();
        public Listar()
        {
            InitializeComponent();
        }

        private void Listar_Load(object sender, EventArgs e)
        {
            List<string> Sillas = S.ListadoPeliculas();
            string Item;

            for (int i = 0; i < Sillas.Count(); i++)
            {
                Item = Sillas[i];
                comboBox1.Items.Add(Item);
            }
            DataTable dt = S.ListadoSala();
            dataGridView1.DataSource = dt;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //dataGridView1.AutoResizeColumns();
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Seleccion;
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            Seleccion = Convert.ToString(comboBox1.SelectedItem);
            List<string> Fechas = S.LeerProgramacion(Seleccion);
            string Item;
            for (int i = 0; i < Fechas.Count(); i++)
            {
                Item = Fechas[i];
                comboBox2.Items.Add(Item);
            }

        }

      

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Seleccion1;
            string Seleccion2;
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            Seleccion1 = Convert.ToString(comboBox1.SelectedItem);
            Seleccion2 = Convert.ToString(comboBox2.SelectedItem);
            List<string> Fechas = S.LeerProgramacion(Seleccion1,Seleccion2);
            string Item;
            for (int i = 0; i < Fechas.Count(); i++)
            {
                Item = Fechas[i];
                comboBox3.Items.Add(Item);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //MessageBox.Show("Valor 1:" + valor1 +" Valor 2:" + valor2);


            

            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                for (int y = 0; y < dataGridView1.Columns.Count; y++)
                {
                    if (Convert.ToString(dataGridView1.Rows[x].Cells[y].Value) == "True")
                    {
                        dataGridView1.Rows[x].Cells[y].Style.BackColor = Color.Red;
                        dataGridView1.Rows[x].Cells[y].Style.ForeColor = Color.Red;
                    }
                    if (Convert.ToString(dataGridView1.Rows[x].Cells[y].Value) == "False")
                    {
                        dataGridView1.Rows[x].Cells[y].Style.BackColor = Color.Green;
                        dataGridView1.Rows[x].Cells[y].Style.ForeColor = Color.Green;
                    }
                }
            }





        }
    }
}
