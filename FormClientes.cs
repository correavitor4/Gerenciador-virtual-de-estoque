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
    public partial class FormClientes : Form
    {
        ConsultClients clients = new ConsultClients();

        public FormClientes()
        {
            InitializeComponent();

            System.Diagnostics.Debug.WriteLine(clients.getMessage());
            loadListViewItems();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        #region 'listViews'
        private void loadListViewItems()
        {
            //limpa os itens anteriores, caso haja algum
            if (listView1.Items.Count > 0)
            {
                for (int i = listView1.Items.Count - 1; i >= 0; i--)
                {
                    listView1.Items.Remove(listView1.Items[i]);
                }
                this.clients = new ConsultClients();
                System.Diagnostics.Debug.WriteLine(clients.getMessage());
            }


            for(int i = 0; i < clients.names.Length; i++)
            {
                string[] arr = new string[3];
                arr[0] = clients.names[i];
                arr[1] = clients.addresses[i];
                arr[2] = clients.dates[i];

                ListViewItem item = new ListViewItem(arr);
                listView1.Items.Add(item);
            }
        }

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {

            clearListBox1();
            string text = textBox1.Text;

            if (!string.IsNullOrEmpty((text)))
            {
                if (searchInClients(text) != null)
                {

                    updateListBox1(searchInClients(text));
                }
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new FormCadastrarClientes();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadListViewItems();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private string[] searchInClients(string text)
        {
            List<string> resultList = new List<string>();
            for(int i = 0; i < clients.names.Length; i++)
            {
                if (clients.names[i].StartsWith(text, StringComparison.CurrentCultureIgnoreCase))
                {
                    resultList.Add(clients.names[i]);
                } 
            }
            

            if (resultList.Count == 0)
            {
                return null;
            }
            else
            {
                return resultList.ToArray();
            }
        }

        private void updateListBox1(string[] names)
        {
            
            for(int i = 0; i < names.Length; i++)
            {
                listBox1.Items.Add(names[i]);
            }
        }

        private void clearListBox1()
        {
            if (listBox1.Items.Count > 0)
            {
                for (int i = listBox1.Items.Count - 1; i >= 0; i--)
                {
                    listBox1.Items.Remove(listBox1.Items[i]);
                }
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id;
            string name;
            string address;
            if (listBox1.SelectedItems.Count > 0)
            {
                id = returnIdByClientName(listBox1.SelectedItem.ToString());
                name = listBox1.SelectedItem.ToString();
                address = returnClientAddressByName(name);
                Form f = new FormEditClients(id,name,address);
                f.Show();
            }
            else
            {
                MessageBox.Show("Selecione antes o cliente que você quer editar");
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private int returnIdByClientName(string text)
        {
            for(int i = 0; i < clients.names.Length; i++)
            {
                if(text == clients.names[i])
                {
                    return clients.ids[i];
                }
            }

            return 0;
        }

        private string returnClientAddressByName(string name)
        {
            for(int i = 0; i < clients.addresses.Length; i++)
            {
                if(name == clients.names[i])
                {
                    return clients.addresses[i];
                }
            }
            return null;
        }
    }
}
