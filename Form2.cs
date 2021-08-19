﻿using System;
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


        #region "listview's"

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
                int idP = returnProductNameIndexByIdInTableProducts(consultOperations.fkProduct[i]);
                

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


        private int returnProductNameIndexByIdInTableProducts(int idFk)
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


        private string returnProductNameByIdInTableProducts(int idFk)
        {
            for (var i = 0; i < consultProducts.namesAr.Length; i++)
            {
                if (idFk == consultProducts.IdProduct[i])
                {

                    
                    return consultProducts.namesAr[i];
                }
            }

            return null;
        }

        /*
        private int returnOperationIdByProductId(int idp)
        {
            for(int i = 0; i < consultProducts.IdProduct.Length; i++)
            {
                if (consultProducts.IdProduct[i] == idp)
                {

                }
            }
        }
        */

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        

        

        #endregion

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

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if(listView1.SelectedItems.Count != 0)
            {
                //string selectedItemNamePreFormated = listView1.SelectedItems[0].SubItems[0].Text;
                //estava acrescentando ListViewSubItem: {nome}, então fiz a formatação da string para purificá-la
                string selectedItemName = listView1.SelectedItems[0].SubItems[0].Text;

                

                System.Diagnostics.Debug.WriteLine(selectedItemName);
                
                int productId = returnIdProductByProductName(selectedItemName);
                System.Diagnostics.Debug.WriteLine(productId);
                showOperationsByProductsFkInListView2(productId);
            }
            
            



        }

        private int returnIdProductByProductName(string name)
        {
            for (var i = 0; i < consultProducts.namesAr.Length; i++)
            {
                //System.Diagnostics.Debug.WriteLine(consultProducts.namesAr[i]);
                if (consultProducts.namesAr[i] == name)
                {
                    System.Diagnostics.Debug.WriteLine(consultProducts.IdProduct[i]);
                    return consultProducts.IdProduct[i];
                }
            }

            return 0;
        }

        private void showOperationsByProductsFkInListView2(int fk)
        {

            //remove itens do listView2 para adicionar novos
            for(int i = listView2.Items.Count-1; i >= 0; i--)
            {
                listView2.Items.Remove(listView2.Items[i]);
            }
            
            /////////////////////////////////////////

            //Salva o nome do produto selecionado nessa variável (fiz antes do 'for' para poupar processamento desnecessário)
            string productName = returnProductNameByIdInTableProducts(fk);
            for (var i=0;i< consultOperations.tipoOperacao.Length; i++)
            {
                if (consultOperations.fkProduct[i] == fk)
                {
                    System.Diagnostics.Debug.WriteLine("chegou");

                    string[] arr = new string[5];
                    arr[0] = productName;
                    arr[1] = consultOperations.tipoOperacao[i];
                    arr[2] = consultOperations.descricao[i];
                    arr[3] = consultOperations.dataOperacao[i];
                    arr[4] = consultOperations.relatorio[i];

                    ListViewItem item = new ListViewItem(arr);
                    listView2.Items.Add(item);
                        
                }
            }
        }

        

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new Form3();
            f.Show();
        }

        
    }
}
