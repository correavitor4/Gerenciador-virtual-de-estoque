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
    public partial class Form5 : Form
    {

        ConsultValues products = new ConsultValues("Table");
        public Form5()
        {
            InitializeComponent();
            loadItems();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            decrementQuantity();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void loadItems()
        {
            for(int i = 0; i < products.namesAr.Length; i++)
            {
                ListViewItem item = new ListViewItem(products.namesAr[i]);
                listView1.Items.Add(item);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string nameItem = listView1.SelectedItems[0].Text;
                int idProduct = returnProductIdByProductName(nameItem);

                showItemDetailsOnLeftContainer(idProduct);
            }
            

        }
        private int returnProductIdByProductName(string name)
        {
            for(int i = 0; i < products.namesAr.Length; i++)
            {
                if (products.namesAr[i]==name)
                {
                    return products.IdProduct[i];
                }
            }
            return 0;
        }


        private void showItemDetailsOnLeftContainer(int idItem)
        {
            for(int i = 0; i < products.namesAr.Length; i++)
            {
                if (products.IdProduct[i] == idItem)
                {
                    textBox1.Text = products.quantidadeAr[i];
                    label1.Text = products.namesAr[i];
                    label4.Text = products.unidadeAr[i];
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            incrementQuantity();
        }

        private void incrementQuantity()
        {
            decimal quantity = decimal.Parse(textBox1.Text);
            if (checkTheConditionsToChangeQuantity(quantity + 1))
            {
                quantity += 1;
                textBox1.Text = quantity.ToString();
            }
            
        }

        private void decrementQuantity()
        {
            
            decimal quantity = decimal.Parse(textBox1.Text);
            if (checkTheConditionsToChangeQuantity(quantity - 1))
            {
                quantity -= 1;
                textBox1.Text = quantity.ToString();
            }
                
            
        }

        private void changeQuantity()
        {
            if (checkTheConditionsToChangeQuantity(decimal.Parse(textBox1.Text)))
            {
                decimal quantity = decimal.Parse(textBox1.Text);
                string productName = listView1.SelectedItems[0].Text;
                int productId = returnProductIdByProductName(productName);
                ClassChangeQuantityOfProduct op = new ClassChangeQuantityOfProduct(productId, quantity);

            }
        }

        //nextValue corresponde ao novo valor que está tentando ser usado
        private bool checkTheConditionsToChangeQuantity(decimal nextValue)
        {
            if (!(listView1.SelectedItems.Count > 0))
            {
                MessageBox.Show("Nenhum produto selecionado");
                return false;
            }

            if (nextValue < 0)
            {
                MessageBox.Show("O valor não pode ser menor do que zero");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            changeQuantity();
        }
    }
}
