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
    public partial class FormEditClients : Form
    {
        int id;
        string name;
        string address;
        public FormEditClients(int id, string name, string address)
        {
            //atribui valores às variáves da classe
            this.id = id;
            this.name = name;
            this.address = address;

            InitializeComponent();
            loadListViewItems(null);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkRegistrationConditions())
            {
                ClassEditClients op = new ClassEditClients(this.id, textBox1.Text,textBox2.Text) ;
                System.Diagnostics.Debug.WriteLine(op.getMessage());
                MessageBox.Show("Dados de cliente editados com sucesso!");
                this.Close();
            }
        }


        private bool checkRegistrationConditions()
        {
            if(!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Um ou mais campos está vazio, e precisa ser preenchido!");
                return false;
            }
        }

        private void loadListViewItems(string name)
        {
            textBox1.Text = this.name;
            textBox2.Text = this.address;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
