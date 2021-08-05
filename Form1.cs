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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void adjustLateralMenu()
        {
            if (splitContainer1.SplitterDistance == 300)
            {
                splitContainer1.SplitterDistance = 100;
            }
            else
            {
                splitContainer1.SplitterDistance = 300;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

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

    }
}
