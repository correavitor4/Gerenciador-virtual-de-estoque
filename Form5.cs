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

        private string oldQuantity;

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
            for (int i = 0; i < products.namesAr.Length; i++)
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
            for (int i = 0; i < products.namesAr.Length; i++)
            {
                if (products.namesAr[i] == name)
                {
                    return products.IdProduct[i];
                }
            }
            return 0;
        }


        private void showItemDetailsOnLeftContainer(int idItem)
        {
            for (int i = 0; i < products.namesAr.Length; i++)
            {
                if (products.IdProduct[i] == idItem)
                {
                    textBox1.Text = products.quantidadeAr[i];
                    label1.Text = products.namesAr[i];
                    label4.Text = products.unidadeAr[i];
                    this.oldQuantity = products.quantidadeAr[i];
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
            //decimal number =decimal.Parse(textBox1.Text);
            //System.Diagnostics.Debug.WriteLine(number);
            if (checkTheConditionsToChangeQuantity(decimal.Parse(textBox1.Text)))
            {

                string quantity = textBox1.Text.Replace(',', '.');
                string productName = listView1.SelectedItems[0].Text;
                int productId = returnProductIdByProductName(productName);
                ClassChangeQuantityOfProduct op = new ClassChangeQuantityOfProduct(productId, quantity);
                System.Diagnostics.Debug.WriteLine(op.getMessage());
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

            //Verifica se há coerêcia no valor digitado
            if (checkCharactesOfTextBox(textBox1.Text))
            {
                changeQuantity();
                registerThisOperation();
                this.products = new ConsultValues("Table");
            }
            else
            {

                string oldValueForTextBox1 = "";
                for (int i = 0; i < products.namesAr.Length; i++)
                {
                    if (products.namesAr[i] == label1.Text)
                    {
                        oldValueForTextBox1 = products.quantidadeAr[i];
                    }
                }
                textBox1.Text = oldValueForTextBox1;
                MessageBox.Show("Caracteres da cadeia não são coerentes. Por favor, verifique e tente novamente (utilizar ponto, não vírgula)");
            }

        }

        private bool checkCharactesOfTextBox(string text)
        {
            bool pontoJaEncontrado = false;
            char[] c = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',' };
            for (int i = 0; i < text.Length; i++)
            {
                bool a = false;
                for (int j = 0; j < c.Length; j++)
                {
                    if (c[j] == text[i])
                    {
                        if (c[j] == ',')
                        {
                            if (pontoJaEncontrado == false)
                            {
                                pontoJaEncontrado = true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        //System.Diagnostics.Debug.WriteLine("encontrou");
                        a = true;
                    }

                }
                if (a == false)
                {
                    return false;
                }
            }

            return true;
        }


        private void registerThisOperation()
        {
            int id = returnProductIdByProductName(label1.Text);
            string operationType = "Modicação da quantidade em estoque";
            string description = string.Format("A quantidade do produto {0}foi alterada de {1} para {2}",label1.Text,this.oldQuantity,textBox1.Text);
            string relatory = null;
            ClassRegisterOperation op = new ClassRegisterOperation(id, operationType, description, relatory);
        }

        //função de gambiarra para formatar o número do textBox1 e convertê-lo para um decimal (já processado)

    }
}
