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
        

        public Form2()
        {
            InitializeComponent();
            loadListViewItems();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loadListViewItems()
        {
            ConsultValues consult = new ConsultValues("Products");

            /*foreach(var item in consult.namesAr)
            {
                System.Diagnostics.Debug.WriteLine(item);
            }*/

            System.Diagnostics.Debug.WriteLine(consult.getMessage());

        }

        

        
    }
}