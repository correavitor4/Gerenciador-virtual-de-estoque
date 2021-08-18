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
    public partial class Form2 : Form
    {

        //instancia classes de Consultar Valores
        ConsultValues consultProducts = new ConsultValues("Table");
        ConsultValues consultOperations = new ConsultValues("operations");

        public Form2()
        {
            InitializeComponent();
            loadListViewProducts();
            //System.Diagnostics.Debug.WriteLine(consultOperations.tipoOperacao);
            loadListViewOperations();
            listBox1.Text = null;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Carrega lista do listView
        private void loadListViewProducts()
        {

            

            for (var i = 0; i < consultProducts.namesAr.Length; i++)
            {
                string[] arr = new string[4];
                arr[0] = consultProducts.namesAr[i];
                arr[1] = consultProducts.quantidadeAr[i];
                arr[2] = consultProducts.unidadeAr[i];
                arr[3] = consultProducts.data_criacaoAr[i].ToString();

                ListViewItem item = new ListViewItem(arr);

                listView1.Items.Add(item);

            }

            System.Diagnostics.Debug.WriteLine(consultProducts.getMessage());

        }

        private void loadListViewOperations()
        {
            
            for (var i = 0; i < consultOperations.tipoOperacao.Length; i++)
            {
                int idP = returnProductNameByIdInTableProducts(consultOperations.fkProduct[i]);
                

                string[] arr = new string[5];
                arr[0] = consultProducts.namesAr[idP].ToString();
                arr[1] = consultOperations.tipoOperacao[i];
                arr[2] = consultOperations.descricao[i];
                arr[3] = consultOperations.dataOperacao[i].ToString();
                arr[4] = consultOperations.relatorio[i];

                ListViewItem item = new ListViewItem(arr);
                listView2.Items.Add(item);
            }

            System.Diagnostics.Debug.WriteLine(consultOperations.getMessage());
        }


        private int returnProductNameByIdInTableProducts(int idFk)
        {
            for(var i = 0; i < consultProducts.namesAr.Length; i++)
            {
                if (idFk == consultProducts.IdProduct[i])
                {
                    return consultProducts.IdProduct[i];
                }
            }

            return 0;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #region 'textBox1 e listBox1'
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(textBox1.Text) == false)
            {
                
                for (var i = 0; i < this.consultProducts.namesAr.Length; i++)
                {
                    updateListBox();
                    
                    if (consultProducts.namesAr[i].StartsWith(textBox1.Text,StringComparison.CurrentCultureIgnoreCase) && !existsInListBox1(consultProducts.namesAr[i])){
                        listBox1.Items.Add(consultProducts.namesAr[i]);
                    }

                }
            }

            else
            {
                updateListBox();
                for (var i = 0; i < listBox1.Items.Count; i++)
                {
                    listBox1.Items.Remove(listBox1.Items[i]);
                }
                //Não me pergunte o porquê dessa linha
                listBox1.Items.Remove(listBox1.Items[0]);
                
               
            }
        }

        private bool existsInListBox1(string word)
        {
            
            for(var i = 0; i < listBox1.Items.Count; i++)
            {
                if (word.ToString() == listBox1.Items[i].ToString())
                {
                    return true;
                }
            }
            return false;
        }

        private bool startsWithInListBox(string word)
        {
            if (word.StartsWith(textBox1.Text, StringComparison.CurrentCultureIgnoreCase)){
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private void updateListBox()
        {

            //startsWithInListBox(textBox1.Text);
            for(var i = 0; i < listBox1.Items.Count; i++)
            {
                if (!startsWithInListBox(listBox1.Items[i].ToString()))
                {
                    listBox1.Items.Remove(listBox1.Items[i]);
                }
                
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string itemSelecionado = listBox1.SelectedItem.ToString();
                
            }

        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new Form3();
            f.Show();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
