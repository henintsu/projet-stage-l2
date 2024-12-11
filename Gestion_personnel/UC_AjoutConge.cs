using System;
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
    public partial class UC_AjoutConge : UserControl
    {
        Functions con;
        public UC_AjoutConge()
        {
            InitializeComponent();
            con = new Functions();
            listerAjoutConge();
            txtIdConge.ReadOnly = true;
        }

        private void listerAjoutConge()
        {
            string Req = "Select * from TblAjoutConge";
            dataConge.DataSource = con.RecupererDonnees(Req);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtAjConge_TextChanged(object sender, EventArgs e)
        {
            lb1.Visible = false;
        }

        private void btnAjoutC_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAjConge.Text == "")
                {
                    lb1.Visible = true;
                }
                else
                {
                    string Caracteristique = txtAjConge.Text;
                    string Req = "insert into TblAjoutConge values('{0}')";
                    Req = string.Format(Req, Caracteristique);
                    con.EnvoyerDonnees(Req);
                    listerAjoutConge();

                    MessageBox.Show("caracteristique Ajouter !!!");

                    txtAjConge.Text = "";
                    
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        int cle = 0;
        private void dataConge_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataConge.Rows[e.RowIndex];
                txtIdConge.Text = selectedRow.Cells[0].Value.ToString();
                txtAjConge.Text = selectedRow.Cells[1].Value.ToString();

                if (txtIdConge.Text == "")
                {
                    cle = 0;
                }
                else
                {
                    cle = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                }
            }
        }

        private void btnModifierC_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAjConge.Text == "")
                {
                    lb1.Visible = true;
                }
                else
                {
                    string Caracteristique = txtAjConge.Text;
                    string Req = "update TblAjoutConge set Caracteristique ='{0}' where Id = {1}";
                    Req = string.Format(Req,Caracteristique,cle);
                    con.EnvoyerDonnees(Req);
                    listerAjoutConge();

                    MessageBox.Show("Modification Reussi !!!");
                    txtIdConge.Text = "";
                    txtAjConge.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnSupC_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAjConge.Text == "")
                {
                    lb1.Visible = true;
                }
                else
                {
                    string Req = "delete from TblAjoutConge where Id = {0}";
                    Req = string.Format(Req, cle);
                    con.EnvoyerDonnees(Req);
                    listerAjoutConge();

                    MessageBox.Show("Suppression Reussi !!!");
                    txtIdConge.Text = "";
                    txtAjConge.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void txtAjConge_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Vérifier que la touche pressée est une lettre ou la touche de contrôle
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquer la saisie
            }
        }

        private void txtIdConge_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIdConge_MouseHover(object sender, EventArgs e)
        {
            label5.Visible = true;
        }

        private void txtIdConge_MouseLeave(object sender, EventArgs e)
        {
            label5.Visible = false;
        }
    }
}
