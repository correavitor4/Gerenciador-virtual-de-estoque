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
    public partial class FormSelectsProduct : Form
    {
        public string productName;
        public int productId;
        public string productUnity;
        public decimal productQuantity;

        ConsultValues products = new ConsultValues("Table");
        public FormSelectsProduct()
        {
            InitializeComponent();
            loadListViewItems();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                this.productName = listView1.SelectedItems[0].SubItems[0].Text;
                this.productId = returnIdByProductName(this.productName);
                this.productUnity = listView1.SelectedItems[0].SubItems[1].Text;
                this.productQuantity = decimal.Parse(listView1.SelectedItems[0].SubItems[2].Text);
                this.Close();
            }
        }

        private void loadListViewItems()
        {
            for(int i=0; i < products.namesAr.Length; i++)
            {
                string[] arr = new string[3];
                arr[0] = products.namesAr[i];
                arr[1] = products.unidadeAr[i];
                arr[2] = products.quantidadeAr[i];

                ListViewItem item = new ListViewItem(arr);
                listView1.Items.Add(item);

             }
        }
        private int returnIdByProductName(string name)
        {
            for(int i = 0; i < products.namesAr.Length; i++)
            {
                if (products.namesAr[i] == name)

                {
                    return products.IdProduct[i];
                }
            }
            return 0;
        }
    }
}
