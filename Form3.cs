﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Você deve selecionar o produto que quer editar. A seleção é feita na lista à esquerda");
            }
            else
            {

                string selectedProductName = listView1.Items[listView1.SelectedIndices[0]].SubItems[0].Text;
                int id = getProductIdByName(selectedProductName);

                Form f = new Form4(id);
                f.Show();
            }
        }

        private int getProductIdByName(string name)
        {
            for(int i =0; i < products.namesAr.Length; i++)
            {
                if(name == products.namesAr[i])
                {
                    return products.IdProduct[i];
                }
            }

            return 0;
        }
    }
}
