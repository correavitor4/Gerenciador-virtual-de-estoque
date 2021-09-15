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
            button4.Visible = false;
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

            System.Diagnostics.Debug.WriteLine(this.clientId);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new FormSelectsProduct();
            f.ShowDialog();

            if (!string.IsNullOrEmpty(f.productName))
            {
                this.provisionalName = f.productName;
                this.provisionalQuantity = f.productQuantity;
                this.provisionalUnity = f.productUnity;

                this.provisionalId = f.productId;

                textBox2.Text = this.provisionalName;
                textBox3.Text = "0";
                textBox4.Text = "0,00";
                label2.Text = string.Format("Preço p/{0}", provisionalUnity);

                label3.Text = string.Format("Em estoque: {0}{1}", provisionalQuantity, provisionalUnity);
                label1.Text = this.provisionalUnity.Replace(" ", "");
            }

            
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
            if (listView1.Items.Count > 0)
            {
                for(int i = listView1.Items.Count - 1; i >= 0; i--)
                {
                    listView1.Items.Remove(listView1.Items[i]);
                }
            }


            for(int i = 0;i< this.productsNameList.Count; i++)
            {
                string[] array = new string[5];
                array[0] = this.productsNameList[i];
                array[1] = this.productsPricePerUnity[i];
                array[2] = this.productsQuantity[i];
                array[3] = this.productsUnity[i];
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
            this.productsIdList.Add(getProductIdByName(productName));
            this.productsQuantity.Add(productQuantity.ToString());
            this.productsTotalPrice.Add(totalPrice.ToString());
            this.productsPricePerUnity.Add(productPricePerUnity.ToString());
            this.productsUnity.Add(this.provisionalUnity.ToString());



             
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
            if (textBox3.Text != null && textBox3.Text != string.Empty)
            {
                
                
                if (decimal.Parse(removeLetters(textBox3.Text)) <= this.provisionalQuantity)
                {
                    textBox3.Text = removeLetters(textBox3.Text) ;
                    

                }
                else
                {
                    MessageBox.Show("A quantidade a ser vendida não pode exceder a quantidade em estoque!!!");
                    
                }


            }
            else
            {
                textBox3.Text = string.Empty;
            }
            
        }

        private string removeLetters(string text)
        {
            string finalText ="";
            foreach(char item in text)
            {
                if (char.IsNumber(item) || item==','){
                    finalText += item;
                }
            }
            return finalText;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(textBox4.Text != null && textBox4.Text != string.Empty)
            {
                textBox4.Text = removeLetters(textBox4.Text) ;
            }
            else
            {
                textBox4.Text = string.Empty;
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            if (listView1.SelectedItems.Count > 0)
            {
                

                button4.Visible = true;
                
                
            }
            else
            {
                button4.Visible = false;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var productNameOfSelected = listView1.SelectedItems[0].SubItems[0].Text;
            for (int i = 0; i < this.productsNameList.Count; i++)
            {
                if(productNameOfSelected == productsNameList[i])
                {
                    this.productsNameList.Remove(this.productsNameList[i]);
                    this.productsIdList.Remove(this.productsIdList[i]);
                    this.productsUnity.Remove(this.productsUnity[i]);
                    this.productsPricePerUnity.Remove(this.productsPricePerUnity[i]);
                    this.productsQuantity.Remove(this.productsQuantity[i]);
                    this.productsTotalPrice.Remove(this.productsTotalPrice[i]);
                }
            }
            loadProductsList();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            //Verifica se há um cliente selecionado
            if (this.clientId != 0)
            {
                //Verifica se há produtos na listview1
                if (listView1.Items.Count > 0)
                {
                    completeSale();
                }
                else
                {
                    MessageBox.Show("Nenhum produto foi adicionado à venda");
                }
            }
            else
            {
                MessageBox.Show("nenhum cliente foi selecionado");
            }

            
            
        }

        private void completeSale()
        {
            string productsName = "";
            string clientName = this.clientName;
            int clientId = this.clientId;
            string productsSold = "";
            string productsSoldId = "";
            string productsSoldQuantity = "";
            string productsSoldUnity = "";
            string productsIndividualPrice = "";


            //Grava os valores na variáveis
            for(int i = 0; i < this.productsPricePerUnity.Count; i++)
            {
                
                   
                productsName += this.productsNameList[i]+",";
                productsSoldId += this.productsIdList[i] + ",";
                productsSoldUnity += this.productsUnity[i] + ",";
                    
                productsSoldQuantity+=this.productsQuantity[i] + ",";
                productsIndividualPrice += this.productsPricePerUnity[i] + ",";
                
                
            }
            
            ClassRegisterSale op = new ClassRegisterSale(clientName, productsSold, productsSoldId, productsSoldQuantity, productsSoldUnity, productsIndividualPrice, clientId);
            System.Diagnostics.Debug.WriteLine(op.getMessage());
            
            
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
