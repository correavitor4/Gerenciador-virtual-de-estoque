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
    public partial class FormCadastrarClientes : Form
    {
        public FormCadastrarClientes()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkRegistrationConditions())
            {


                ClassRegisterClients op = new ClassRegisterClients(textBox1.Text,textBox2.Text);
                System.Diagnostics.Debug.WriteLine(op.getMessage());
                MessageBox.Show("Cliente cadastrado com sucesso");
                
            }
        }


        private bool checkRegistrationConditions()
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Um ou mais campos não foram preenchidos");
                return false;
            }
        }
    }
}
