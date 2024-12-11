using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Gestion_personnel

{
    
    public partial class Menu : Form
    {
       
        bool outilcollapsed;
        public Menu()
        {
            InitializeComponent();
            
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Reset()
        {
            
        }
            

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAgrandir_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            buttonAgrandir.Visible = false;
            buttonReduire.Location = buttonAgrandir.Location;
            buttonReduire.Visible = true;
        }

        private void buttonReduire_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            buttonAgrandir.Visible = true;
            buttonReduire.Visible = false;
        }

        private void buttonRetirer_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            personneltimer.Start();
            uc_1.BringToFront();
            p1.Visible = true;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = false;
            panel9.Visible = true;

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hometimer_Tick(object sender, EventArgs e)
        {
           
        }

        private void buttonAjout_Click(object sender, EventArgs e)
        {
            
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            outiltimer.Start();
            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = true;
            panel9.Visible = false;
        }

        private void outiltimer_Tick(object sender, EventArgs e)
        {
            if (outilcollapsed)
            {
                OutilContainer.Height += 10;

                if (OutilContainer.Height == OutilContainer.MaximumSize.Height)
                {
                    outilcollapsed = false;
                    outiltimer.Stop();
                }
            }

            else
            {
                OutilContainer.Height -= 10;
                if (OutilContainer.Height == OutilContainer.MinimumSize.Height)
                {
                    outilcollapsed = true;
                    outiltimer.Stop();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            uC_Conge1.BringToFront();
            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = true;
            p4.Visible = false;
            p5.Visible = false;
            panel9.Visible = true;
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            
            uC_Home1.BringToFront();
            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = false;
            panel9.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            uC_LieuDisponible1.BringToFront();
            p1.Visible = false;
            p2.Visible = true;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = false;
            panel9.Visible = true;
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            uC_Affectation1.BringToFront();
            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = true;
            p5.Visible = false;
            panel9.Visible = true;
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            DialogResult resultat = MessageBox.Show("Voulez vous vraiment vous deconnecter ?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultat == DialogResult.Yes)
            {
                loginForm Obj = new loginForm();
                Obj.Show();
                this.Hide();
            }

            
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            panelCompte.Visible = true;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            panelCompte.Visible = false;
        }
    }
}
