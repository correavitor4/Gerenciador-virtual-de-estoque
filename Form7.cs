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
            
        }
    }
}
