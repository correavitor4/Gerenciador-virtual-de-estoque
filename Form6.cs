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
    public partial class Form6 : Form
    {
        ClassConsultSales sales = new ClassConsultSales();
        public Form6()
        {

            InitializeComponent();
                
            loadListViewItems();
        }

        private void loadListViewItems()
        {
            this.sales = new ClassConsultSales();
            //remove itens que já estavam na listView, para recarregá-los
            if (listView1.Items.Count > 0)
            {
                for(int i=listView1.Items.Count-1;i>=0; i--)
                {
                    listView1.Items.Remove(listView1.Items[i]);
                }
            }
        
            for(int i = 0; i < sales.productsSold.Length; i++)
            {
                string[] array = new string[3];
                
                array[0] = getClienteNameById(int.Parse(sales.clientId[i]));
                array[1] = sales.data[i];
                array[2] = sales.productsSold[i];

                ListViewItem lv = new ListViewItem(array);
                listView1.Items.Add(lv);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new Form7();
            
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private string getClienteNameById(int id)
        {
            ConsultClients op = new ConsultClients();

            for(int i = 0; i < op.names.Length; i++)
            {
                if(id == op.ids[i])
                {
                    return op.names[i];
                }
            }

            return "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string clientName = listView1.SelectedItems[0].SubItems[0].Text;
                int saleId = getSaleIdByClientName(clientName);

                string message =string.Format("Você quer mesmo excluir essa venda a {0}?",clientName);
                string caption = "A venda será excluída!!!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, caption, buttons);

                if(result == DialogResult.Yes)
                {
                    
                    ClassDeleteSale op = new ClassDeleteSale(saleId);
                    System.Diagnostics.Debug.WriteLine(op.getMessage());
                    loadListViewItems();

                }

            }
            else
            {
                MessageBox.Show("Primeiro selecione (na listBox) a venda que você quer excluir");
            }
        }

        private int getSaleIdByClientName(string clientName)
        {
            ConsultClients clients = new ConsultClients();
            for (int i = 0; i < sales.id.Length; i++)
            {
                if (getClienteNameById(int.Parse(sales.clientId[i]))==clientName)
                {
                    
                    return sales.id[i];

                }
            }

            return 0;
        }

        private int getClientIdByClientName(string clientName)
        {
            ConsultClients clients = new ConsultClients();
            for(int i = 0; i < clients.names.Length; i++)
            {
                if (clients.names[i] == clientName)
                {
                    
                    return clients.ids[i];
                    
                }
            }

            return 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadListViewItems();
        }
    }
}
