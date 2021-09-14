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
    public partial class Form7 : Form
    {

        

        //Informações do cliente
        int clientId;
        string clientName;



        //Informações do produtos
        List<string> productsNameList = new List<string>();
        List<string> productsIdList = new List<string>();
        List<string> productsUnity = new List<string>();
        List<string> productsPricePerUnity = new List<string>();
        List<string> productsQuantity = new List<string>();
        List<string> productsTotalPrice = new List<string>();
        string provisionalName;
        string provisionalUnity;
        decimal provisionalQuantity;
        int provisionalId;



        public Form7()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new FormSelecionarCliente();
            //Diferentemente do Form.Show(), o Form.showDialog() aguarda até quie formulário aberto seja devidamente preenchido, para depois continuar a execução do código
            f.ShowDialog();
            this.clientId = f.selectedClientId;
            this.clientName = f.selectedClientName;
            textBox1.Text = this.clientName;


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new FormSelectsProduct();
            f.ShowDialog();

            this.provisionalName = f.productName;
            this.provisionalQuantity = f.productQuantity;
            this.provisionalUnity = f.productUnity;
            
            this.provisionalId = f.productId;

            textBox2.Text = this.provisionalName;
            textBox3.Text = "0";
            textBox4.Text = "0,00R$";
            label2.Text = string.Format("Preço p/{0}", provisionalUnity);

            label3.Text = string.Format("Em estoque: {0}{1}", provisionalQuantity, provisionalUnity);
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            addNewProduct();
            loadProductsList();
        }

        private void loadProductsList()
        {
            for(int i = 0;i< this.productsNameList.Count; i++)
            {
                string[] array = new string[5];
                array[0] = this.productsNameList[i];
                array[1] = this.productsPricePerUnity[i];
                array[2] = this.productsQuantity[i];
                array[3] = this.productsQuantity[i];
                array[4] = this.productsTotalPrice[i];

                ListViewItem lv = new ListViewItem(array);

                listView1.Items.Add(lv);



            }

            
            

        }

        private void addNewProduct()
        {
            string productName = this.provisionalName;
            decimal productQuantity = decimal.Parse(textBox3.Text);
            double productPricePerUnity = double.Parse(textBox4.Text.Replace("R$",""));
            double totalPrice = productPricePerUnity*double.Parse(productQuantity.ToString());

            this.productsNameList.Add(productName);
            this.productsQuantity.Add(productQuantity.ToString());
            this.productsIdList.Add(getProductIdByName(productName));
            this.productsQuantity.Add(productQuantity.ToString());
            this.productsTotalPrice.Add(totalPrice.ToString());
            this.productsPricePerUnity.Add(productPricePerUnity.ToString());
            this.productsUnity.Add(productQuantity.ToString());



             
        }

        private string getProductIdByName(string name)
        {
            ConsultValues product = new ConsultValues("Table");
            for(int i = 0; i < product.namesAr.Length; i++)
            {
                if (product.namesAr[i] == name)
                {
                    return product.IdProduct[i].ToString();
                }
            }
            return "0";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        /*private void formatUnity()
        {
            string u = this.provisionalUnity;
            List<char> formatedCharList = new List<char>();
            for(int i = 0; i < u.Length; i++)
            {
                if (!char.IsWhiteSpace(u[i]))
                {
                    formatedCharList.Add(u[i]);
                }
            }

            this.provisionalUnity = formatedCharList.ToArray().ToString();
        }*/
    }
}
