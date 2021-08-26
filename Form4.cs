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
        ClassEditProduct edit ;

        private string oldName;
        private string oldUnity;
        private int IdOfProduct;

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
                    this.oldName = products.namesAr[i];
                    this.oldUnity = products.unidadeAr[i];
                    this.IdOfProduct = products.IdProduct[i];

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
            if(textBox1.Text==oldName && textBox2.Text == oldUnity)
            {
                MessageBox.Show("Você não alterou alterou nada!");
                this.Close();

            }
            else
            {
                if (textBox2.Text.Length > 10)
                {
                    MessageBox.Show("O campo de unidade deve ter 10 caracteres ou menos");
                }
                else
                {
                    //sub-rotinas que registram a modificação do produto e a operação feita nas tabelas 'Table' e 'operations'
                    editThisProduct();
                    
                    registerThisOperation();

                    this.Close();
                }
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editThisProduct()
        {
            this.edit = new ClassEditProduct(this.IdOfProduct, textBox1.Text, textBox2.Text);
        }


        private void registerThisOperation()
        {
            int type=0;
            /*
            type 
                1-alteração no nome do produto
                2-alteração no nome da unidade
                3-alteração em ambos
            */
            if(textBox1.Text==oldName && textBox2.Text == oldUnity)
            {
                type = 3;
            }
            else
            {
                if (textBox1.Text != oldName)
                {
                    type = 1;
                }
                if(textBox2.Text != oldUnity)
                {
                    type = 2;
                }
            }

           
            int idOfProduct = this.IdOfProduct;
            string relatory = null;
            string description;
            string operationType = "Alteração de dados de cadastro de produto";

            switch (type)
            {
                case 1:
                    description = string.Format("Nome do produto atualizado para {0}. O antigo nome era {1}",textBox1.Text,oldName);
                    break;
                case 2:
                    description = string.Format("Unidade alterada para {0}. A antiga era {1}", textBox2.Text, oldUnity);
                    break;
                default:
                    description = string.Format("Nome e unidade alterados para, respectivamente, {0} e {1}", textBox1.Text, textBox2.Text);
                    break;
            }

            ClassRegisterOperation op = new ClassRegisterOperation(idOfProduct,operationType,description,relatory);

        }

    }
}
