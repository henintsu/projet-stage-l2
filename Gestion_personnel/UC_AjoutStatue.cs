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
    public partial class UC_AjoutStatue : UserControl
    {
        Functions con;
        public UC_AjoutStatue()
        {
            InitializeComponent();
            con = new Functions();
            listerAjoutStatue();
            
        }

        private void listerAjoutStatue()
        {
            string Req = "Select * from TblStatue";
            dataStatue.DataSource = con.RecupererDonnees(Req);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAjoutP_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNomStatue.Text == "")
                {
                    lb1.Visible = true;
                }
                else
                {
                    string NomSt = txtNomStatue.Text;
                    string DescriptionSt = txtDescription.Text;
                    string Req = "insert into TblStatue values('{0}','{1}')";
                    Req = string.Format(Req, NomSt, DescriptionSt);
                    con.EnvoyerDonnees(Req);
                    listerAjoutStatue();

                    MessageBox.Show(" Ajout reussi !!!");

                    txtNomStatue.Text = "";
                    txtDescription.Text = "";

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnModifierP_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNomStatue.Text == "")
                {
                    lb1.Visible = true;
                }
                else
                {
                    string NomSt = txtNomStatue.Text;
                    string DescriptionSt = txtDescription.Text;
                    string Req = "update TblStatue set NomSt ='{0}' ,DescriptionSt ='{1}' where CodeStatue = {2}";
                    Req = string.Format(Req, NomSt, DescriptionSt,cle);
                    con.EnvoyerDonnees(Req);
                    listerAjoutStatue();

                    MessageBox.Show("Modificaton reussi !!!");

                    txtNomStatue.Text = "";
                    txtDescription.Text = "";

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        int cle = 0;
        private void dataStatue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dataStatue.Rows[e.RowIndex];
                    txtNomStatue.Text = selectedRow.Cells[1].Value.ToString();
                    txtDescription.Text = selectedRow.Cells[2].Value.ToString();

                    if (txtNomStatue.Text == "")
                    {
                        cle = 0;
                    }
                    else
                    {
                        cle = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                    }
                }

            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnSupP_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNomStatue.Text == "")
                {
                    lb1.Visible = true;
                }
                else
                {
                    
                    string Req = "Delete from TblAjoutPoste where CodeStatue = {0}";
                    Req = string.Format(Req, cle);
                    con.EnvoyerDonnees(Req);
                    listerAjoutStatue();

                    MessageBox.Show(" Suppression reussi !!!");

                    txtNomStatue.Text = "";
                    txtDescription.Text = "";

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Vérifier que la touche pressée est une lettre ou la touche de contrôle
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquer la saisie
            }
        }
    }
}
