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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new FormCadastrarClientes();
            f.Show();
        }
    }
}
