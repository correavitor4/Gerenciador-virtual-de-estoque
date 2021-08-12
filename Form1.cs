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
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();
            openFormulary(new Form2());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            reduceLateralMenu();
        }


        

        

        

        private void button2_Click(object sender, EventArgs e)
        {

        }


        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0112) // WM_SYSCOMMAND
            {
                // Check your window state here
                if (m.WParam == new IntPtr(0xF030)) // Maximize event - SC_MAXIMIZE from Winuser.h
                {
                    // THe window is being maximized
                    
                    System.Diagnostics.Debug.WriteLine("Janela maximizada "+ splitContainer1.SplitterDistance);
                 

                }
            }
            base.WndProc(ref m);
        }


        #region "lateralMenu" 

        bool button1Reduced = false;
        bool button2Reduced = false;
        bool button3Reduced = false;
        bool button4Reduced = false;

        private void reduceLateralMenu()
        {

                //Verifica se o menu está em tamanho grande
                if (splitContainer1.SplitterDistance == 300)
                {
                    
                    splitContainer1.SplitterDistance = 75;
                    reduceButton1();
                    reduceButton2();
                    reduceButton3();
                    reduceButton4();

                }
                else
                {
                    splitContainer1.SplitterDistance = 300;
                    restoreButton1();
                    restoreButton2();
                    restoreButton3();
                    restoreButton4();
            }

            
        }

        private void reduceButton1()
        {
            button1.Text = "";
            //Bitmap b = new Bitmap("Resources\icon_products.png");
            var bmp = new Bitmap(Properties.Resources.icon_products);
            button1.BackgroundImage =bmp;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1Reduced = true;
        }

        private void restoreButton1()
        {
            button1.BackgroundImage = null;
            button1.Text = "PRODUTOS";
            button1Reduced = false;
        }

        private void reduceButton2()
        {
            button2.Text = "";
            //Bitmap b = new Bitmap("Resources\icon_products.png");
            var bmp = new Bitmap(Properties.Resources.store_icon);
            button2.BackgroundImage = bmp;
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2Reduced = true;
        }

        private void restoreButton2()
        {
            button2.BackgroundImage = null;
            button2.Text = "VENDAS";
            button2Reduced = false;
        }


        private void reduceButton3()
        {
            button3.Text = "";
            //Bitmap b = new Bitmap("Resources\icon_products.png");
            var bmp = new Bitmap(Properties.Resources.clients_icon);
            button3.BackgroundImage = bmp;
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3Reduced = true;
        }

        private void restoreButton3()
        {
            button3.BackgroundImage = null;
            button3.Text = "CLIENTES";
            button3Reduced = false;
        }

        private void reduceButton4()
        {
            button4.Text = "";
            //Bitmap b = new Bitmap("Resources\icon_products.png");
            var bmp = new Bitmap(Properties.Resources.providers_icon);
            button4.BackgroundImage = bmp;
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4Reduced = true;
        }

        private void restoreButton4()
        {
            button4.BackgroundImage = null;
            button4.Text = "FORNECEDORES";
            button4Reduced = false;
        }


        #endregion



        #region "button 1 events"
        private void button1_MouseHover(object sender, EventArgs e)
        {
            if (button1Reduced)
            {
                var bmp = new Bitmap(Properties.Resources.icon_products_mouse_hover);
                button1.BackgroundImage = bmp;
            }
            else
            {
                button1.BackColor = Color.FromArgb(93, 166, 166);
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (button1Reduced)
            {
                var bmp = new Bitmap(Properties.Resources.icon_products);
                button1.BackgroundImage = bmp;
            }
            else
            {
                button1.BackColor = Color.FromArgb(10, 115, 115);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        #endregion


        #region "button 3 events"
        private void button3_MouseHover(object sender, EventArgs e)
        {
            if (button3Reduced)
            {
                var bmp = new Bitmap(Properties.Resources.clients_icon_mouse_hover);
                button3.BackgroundImage = bmp;
            }
            else
            {
                button3.BackColor = Color.FromArgb(93, 166, 166);
            }
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            if (button3Reduced)
            {
                var bmp = new Bitmap(Properties.Resources.clients_icon);
                button3.BackgroundImage = bmp;
            }
            else
            {
                button3.BackColor = Color.FromArgb(10, 115, 115);
            }
        }
        #endregion

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void openFormulary(object formulary)
        {
            if (splitContainer2.Panel2.Controls.Count > 0)
            {
                splitContainer2.Panel2.Controls.RemoveAt(0);
            }
            
            Form f = formulary as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Add(f);
            splitContainer2.Panel2.Tag = f;
            f.Show();
            
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
