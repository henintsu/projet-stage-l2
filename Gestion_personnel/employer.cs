﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_personnel
{
    public partial class employer : UserControl
    {
        public employer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Uc_ tab = new Uc_();
            tab.Show();
            this.Hide();

           
        }
    }
}
