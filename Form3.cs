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
    public partial class Form3 : Form
    {
        ConsultValues products = new ConsultValues("Table");
        /*public int[] IdProduct;
        public string[] namesAr;
        public string[] quantidadeAr;
        public string[] unidadeAr;
        public string[] data_criacaoAr;*/

        private string nameOfDeletedProduct="";

        public Form3()
        {
            InitializeComponent();
            showAllProducts();
        }

        private void showAllProducts()
        {
            for(int i = 0; i < products.namesAr.Length; i++)
            {
                ListViewItem lv = new ListViewItem(products.namesAr[i]);
                listView1.Items.Add(lv);
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new FormCadastrarProdutos();
            f.Show();
            

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Você deve selecionar o produto que quer editar. A seleção é feita na lista à esquerda");
            }
            else
            {

                string selectedProductName = listView1.Items[listView1.SelectedIndices[0]].SubItems[0].Text;
                int id = getProductIdByName(selectedProductName);

                Form f = new Form4(id);
                f.Show();
            }
        }

        private int getProductIdByName(string name)
        {
            for(int i =0; i < products.namesAr.Length; i++)
            {
                if(name == products.namesAr[i])
                {
                    return products.IdProduct[i];
                }
            }

            return 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttonsMB = MessageBoxButtons.YesNo;
            string message = "O produto será removido";
            string caption = "Tens certeza de que queres remover este produto?";
            DialogResult result;

            result = MessageBox.Show(message,caption, buttonsMB);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //É preciso antes remover todas as operações do produto, caso contrário, haverá conflitos de fk
                removeProductsOperations();
                removeProduct();
                //registerThisOperation();
            }


        }

       private void removeProduct()
        {
            string nameProduct = listView1.SelectedItems[0].Text;
            this.nameOfDeletedProduct = nameProduct;
            //System.Diagnostics.Debug.WriteLine(nameProduct);
            int id = returnProductIdByProductName(nameProduct);

            ClassRemoveProduct rp = new ClassRemoveProduct(id);

            System.Diagnostics.Debug.WriteLine(rp.getMessage());
        }
        
        private void removeProductsOperations()
        {
            string nameProduct = listView1.SelectedItems[0].Text;
            //System.Diagnostics.Debug.WriteLine(nameProduct);
            int id = returnProductIdByProductName(nameProduct);

            ClassRemoveOperation op = new ClassRemoveOperation(id);
            op.getMessage();
            
        }

        //Comentado até haver necessidade de utilizar
        /*private void registerThisOperation()
        {
            string nameProduct =this.nameOfDeletedProduct;
            //System.Diagnostics.Debug.WriteLine(nameProduct);
            int id = null;
            string operationType = "Remoção de cadastro de produto";
            string description = string.Format("O produto {0} foi removido dos cadastros",nameProduct);
            string relatory = "As operações do produto que antecedem suas remoção foram permanentemente removidas do banco de dados ";

            ClassRegisterOperation op = new ClassRegisterOperation(id, operationType, description, relatory);
            System.Diagnostics.Debug.WriteLine(op.getMessage());
        }*/
        
        private int returnProductIdByProductName(string name)
        {
            for(int i = 0; i < products.namesAr.Length; i++)
            {
                if (name == products.namesAr[i])
                {
                    return products.IdProduct[i];
                }
            }

            return 0;
        }
    }
}
