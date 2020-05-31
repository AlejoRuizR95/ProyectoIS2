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
    public partial class Reservar : Form
    {

        ClsSala S = new ClsSala();
        public Reservar()
        {
            InitializeComponent();
        }

        private void Listar_Load(object sender, EventArgs e)
        {
            List<string> Peliculas = S.ListadoPeliculas();
            string Item;

            for (int i = 0; i < Peliculas.Count(); i++)
            {
                Item = Peliculas[i];
                comboBox1.Items.Add(Item);
            }
            

            //Pintar Celdas
            PintarCeldas();




        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Seleccion;
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            Seleccion = Convert.ToString(comboBox1.SelectedItem);
            List<string> Fechas = S.LeerFechas(Seleccion);
            string Item;
            for (int i = 0; i < Fechas.Count(); i++)
            {
                Item = Fechas[i].Substring(0, 10);
                comboBox2.Items.Add(Item);
            }

        }

      

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {   
            //Cargar Valores de las peliculas y horarios
            string Seleccion1 ="";
            string Seleccion2="";
            comboBox3.Items.Clear();
            //comboBox3.Text = "";
            Seleccion1 = Convert.ToString(comboBox1.SelectedItem);
            Seleccion2 = Convert.ToString(comboBox2.SelectedItem);
            
            List<string> Fechas = S.LeerHoras(Seleccion1,Seleccion2);
            string Item;
            for (int i = 0; i < Fechas.Count(); i++)
            {
                Item = Fechas[i];
                comboBox3.Items.Add(Item);
            }

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inicio ini = new Inicio();
            this.Hide();
            ini.Show();
        }

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Fila = dataGridView1.CurrentCell.RowIndex + 1;
            string Columna = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].HeaderText;            
            int Dato = Int32.Parse(Convert.ToString(dataGridView1.CurrentCell.Value));       
            string msj = "";
            try
            {
                string Sala = S.LeerId(comboBox1.Text, comboBox2.Text, comboBox3.Text);
                S.Columna = Columna;
                S.Fila = Fila;
                S.Dato = Dato;
                S.Tabla = Sala;

                msj = S.Registrar_Silla();

                if (msj == "La silla se reservo correctamente")
                {
                    listFactura.Items.Add(S.Calcular_Pago());
                    txtTotal.Text = S.acumFactura.ToString();
                }
                

                

                MessageBox.Show(msj);                
                DataTable dt = S.ListadoSala(Sala);
                dataGridView1.DataSource = dt;
                PintarCeldas();

                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void PintarCeldas() {

            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                for (int y = 1; y < dataGridView1.Columns.Count; y++)
                {
                    if (Convert.ToString(dataGridView1.Rows[x].Cells[y].Value) == "1")
                    {
                        dataGridView1.Rows[x].Cells[y].Style.BackColor = Color.Red;
                        dataGridView1.Rows[x].Cells[y].Style.ForeColor = Color.Transparent;
                    }
                    if (Convert.ToString(dataGridView1.Rows[x].Cells[y].Value) == "0")
                    {
                        dataGridView1.Rows[x].Cells[y].Style.BackColor = Color.Green;
                        dataGridView1.Rows[x].Cells[y].Style.ForeColor = Color.Transparent;
                    }
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Sala = S.LeerId(comboBox1.Text, comboBox2.Text, comboBox3.Text);
              
            labelSala.Text = Sala;
            DataTable dt = S.ListadoSala(Sala);
            dataGridView1.DataSource = dt;
            PintarCeldas();
            S.Fecha = comboBox2.Text;
            S.Hora = comboBox3.Text;




        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevFact_Click(object sender, EventArgs e)
        {
            S.acumFactura = 0;
            listFactura.Items.Clear();
            txtTotal.Text="";
        }
    }
}
