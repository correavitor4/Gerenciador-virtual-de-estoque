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
        List<string> productsNameString = new List<string>();
        List<string> productsIdList = new List<string>();
        List<string> productsUnity = new List<string>();
        List<string> productsPrice = new List<string>();
        List<string> productsQuantity = new List<string>();
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
