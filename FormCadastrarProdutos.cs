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
        //Variável de gambiarra para comparação em laço de repeticão na função registerThisOperation()
        private string nameP;

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
                    registerThisOperation();
                    
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
            this.nameP = textBox1.Text;
            string productName = textBox1.Text;

            string unity = textBox2.Text;
            
            

            ClassRegisterProduct registro = new ClassRegisterProduct(productName,unity);

            registro.getMessage();

            MessageBox.Show("Produto cadastrado com sucesso");
            this.Close();
            
            
        }

        private void registerThisOperation()
        {
            //É preciso consultar o banco para pegar o ID do produto recém criado
            ConsultValues p = new ConsultValues("Table");
            int idOfProduct=0;
            //Esse laço de repeticão preenche a variável idOfProduct
            System.Diagnostics.Debug.WriteLine(textBox1.Text);
            for(int i = 0; i < p.namesAr.Length; i++)
            {
                if (p.namesAr[i] ==nameP)
                {
                    idOfProduct = p.IdProduct[i];
                }
            }

            
            string operationType = "Cadastro";
            string relatory = "Produto cadastrado com sucesso no Banco de Dados";
            string description = string.Format("{0} cadastrado com a unidade '{1}'",textBox1.Text,textBox2.Text);
            

            ClassRegisterOperation op = new ClassRegisterOperation(idOfProduct, operationType, description,relatory);
        }
    }
}
