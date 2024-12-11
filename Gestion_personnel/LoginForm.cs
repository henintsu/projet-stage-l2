using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gestion_personnel
{
    public partial class loginForm : Form
    {
        private string connectionString = "your_connect";

        public loginForm()
        {
            InitializeComponent();
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
             if (TxtName.Text == "")
            {
                panelNom.Visible = false;
            }
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
             if (TxtPassword.Text == "")
            {
                panelpass.Visible = false;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult resultat = MessageBox.Show("Voulez vous vraiment quitter ce page ?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultat == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (TxtName.Text == "" || TxtPassword.Text == "")
            {
                MessageBox.Show(" Information Incomplet , Verifier svp !");
            }

            else if (TxtName.Text == "user" && TxtPassword.Text == "password")
            {
                Menu Obj = new Menu();
                Obj.Show();
                this.Hide();
            }

            else
            {
                if (TxtName.Text != "user")
                {
                    panelNom.Visible = true;
                }

                if (TxtPassword.Text != "password")
                {
                    panelpass.Visible = true;

                }
            }
                }

        private void TxtName_Click(object sender, EventArgs e)
        {
            TxtName.SelectAll(); 
        }

        private void TxtPassword_Click(object sender, EventArgs e)
        {
            TxtPassword.SelectAll();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnCnx.ForeColor = Color.Black;
        }

        private void btnCnx_MouseLeave(object sender, EventArgs e)
        {
            btnCnx.ForeColor = Color.White;
        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if(TxtPassword.PasswordChar == '*')
    {
                // Afficher le mot de passe
                TxtPassword.PasswordChar = '\0'; // Caractère nul affiche le texte brut
            }
            else
            {
                        // Masquer le mot de passe
                        TxtPassword.PasswordChar = '*'; // Caractère d'astérisque masque le texte
                    }
        }
    }
}
