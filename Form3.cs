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
    public partial class Form3 : Form
    {
        ConsultValues products = new ConsultValues("Table");
        /*public int[] IdProduct;
        public string[] namesAr;
        public string[] quantidadeAr;
        public string[] unidadeAr;
        public string[] data_criacaoAr;*/
        public Form3()
        {
            InitializeComponent();
            showAllProducts();
        }

        private void showAllProducts()
        {
            for(int i = 0; i < products.namesAr.Length; i++)
            {
                ListViewItem lv = new ListViewItem(products.namesAr[i]);
                listView1.Items.Add(lv);
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new FormCadastrarProdutos();
            f.Show();
            

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
