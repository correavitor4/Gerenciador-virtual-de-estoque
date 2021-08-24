using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciador_vitural_de_estoque
{
    public partial class Form4 : Form
    {
        ConsultValues products = new ConsultValues("Table");
        public Form4(int id)
        {
            InitializeComponent();
            loadInicialValuesInTextBoxes(id);
            
        }

        private void loadInicialValuesInTextBoxes(int id)
        {
            for(int i = 0; i < products.namesAr.Length; i++)
            {
                if(id == products.IdProduct[i])
                {
                    textBox1.Text = products.namesAr[i];
                    textBox2.Text = products.unidadeAr[i];
                }
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
