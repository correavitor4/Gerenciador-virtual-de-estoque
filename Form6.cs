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
    }
}
