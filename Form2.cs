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

        //instancia classe de Consultar Valores
        ConsultValues consult = new ConsultValues("Table");

        public Form2()
        {
            InitializeComponent();
            loadListViewItems();
            listBox1.Text = null;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Carrega lista do listView
        private void loadListViewItems()
        {
            


            for(var i = 0; i < consult.namesAr.Length; i++)
            {
                string[] arr = new string[4];
                arr[0] = consult.namesAr[i];
                arr[1] = consult.quantidadeAr[i];
                arr[2] = consult.unidadeAr[i];
                arr[3] = consult.data_criacaoAr[i].ToString();

                ListViewItem item = new ListViewItem(arr);

                listView1.Items.Add(item);

            }

            /*
            //Arrays que irão armazenas os dados
            string[] names;
            string[] quantidade;
            string[] unidade;
            string[] dataCriacao;


            
            //Declaração das listas que irão receber os valores
            List<string> namesList = new List<string>();
            List<string> quantidadeList = new List<string>();
            List<string> unidadeList = new List<string>();
            List<string> dataCriacaoList = new List<string>();



            //foreachs que irão preencher as listas com os dados puxados do banco
            foreach (var item in consult.namesAr)
            {
                namesList.Add(item.ToString());
            }

            foreach(var item in consult.quantidadeAr){
                quantidadeList.Add(item.ToString());
            }

            foreach (var item in consult.unidadeAr)
            {
                unidadeList.Add(item.ToString());
            }

            foreach (var item in consult.data_criacaoAr)
            {
                dataCriacaoList.Add(item.ToString());
            }


            //Preenchimento dos arrays string que irão armazenar os dados
            names =namesList.ToArray();
            unidade = unidadeList.ToArray();
            quantidade = quantidadeList.ToArray();
            dataCriacao = dataCriacaoList.ToArray();
            */


            


            

           
            System.Diagnostics.Debug.WriteLine(consult.getMessage());

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #region 'textBox1 e listBox1'
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(textBox1.Text) == false)
            {
                
                for (var i = 0; i < this.consult.namesAr.Length; i++)
                {
                    updateListBox();
                    
                    if (consult.namesAr[i].StartsWith(textBox1.Text,StringComparison.CurrentCultureIgnoreCase) && !existsInListBox1(consult.namesAr[i])){
                        listBox1.Items.Add(consult.namesAr[i]);
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
        #endregion
    }
}
