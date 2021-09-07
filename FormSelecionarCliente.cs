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
    public partial class FormSelecionarCliente : Form
    {
        public string selectedClientName;
        public int selectedClientId;
        ConsultClients clients = new ConsultClients();
        public FormSelecionarCliente()
        {
            InitializeComponent();
            loadListViewItems();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                this.selectedClientName = listView1.SelectedItems[0].Text;
                this.selectedClientId = returnClientIdByName();
                this.Close();
            }
        }

        private void loadListViewItems()
        {
            foreach(string name in clients.names)
            {
                
                listView1.Items.Add(name);
            }
        }

        private int returnClientIdByName()
        {
            for(int i = 0; i < clients.names.Length; i++)
            {
                if (clients.names[i] == listView1.SelectedItems[0].Text)
                {
                    return clients.ids[i];
                }
            }
            return 0;
        }
    }
}
