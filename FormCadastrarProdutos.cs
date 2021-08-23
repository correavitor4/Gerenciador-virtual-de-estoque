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
    public partial class FormCadastrarProdutos : Form
    {
        public FormCadastrarProdutos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //verifica se o usuário preencheu corretamente
            if (checkRegistrationConditions())
            {
                //sub-rotina que registra o produto
                if (textBox2.Text.Length > 10)
                {
                    MessageBox.Show("A unidade deve ter menos de 10 letras");
                }
                else
                {
                    registerProduct();
                    
                }
                
            }
            else
            {
                MessageBox.Show("Você deixou um campo vazio");
            }
        }

        private bool checkRegistrationConditions()
        {
            if (textBox1.Text == null || textBox1.Text=="" || textBox1.Text==string.Empty)
            {
                return false;
            }
            if (textBox2.Text == null || textBox2.Text == "" || textBox2.Text == string.Empty)
            {
                return false;
            }
            
            return true;
        }

        private void registerProduct()
        {
            string productName = textBox1.Text;

            string unity = textBox2.Text;
            
            

            ClassRegisterProduct registro = new ClassRegisterProduct(productName,unity);

            registro.getMessage();

            MessageBox.Show("Produto cadastrado com sucesso");
            this.Close();
            
            
        }

        
    }
}
