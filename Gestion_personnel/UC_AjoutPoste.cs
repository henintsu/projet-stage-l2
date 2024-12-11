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
    public partial class UC_AjoutPoste : UserControl
    {
        Functions con;
        public UC_AjoutPoste()
        {
            InitializeComponent();
            con = new Functions();
            listerAjoutPoste();
            txtIdPoste.ReadOnly = true;
        }

        private void listerAjoutPoste()
        {
            string Req = "Select * from TblAjoutPoste";
            dataPoste.DataSource = con.RecupererDonnees(Req);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtNomPoste_TextChanged(object sender, EventArgs e)
        {
            lb1.Visible = false;
        }

        private void btnAjoutP_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNomPoste.Text == "")
                {
                    lb1.Visible = true;
                }
                else
                {
                    string NomPoste  = txtNomPoste.Text;
                    string CaracteristiquePoste = txtDescription.Text;
                    string Req = "insert into TblAjoutPoste values('{0}','{1}')";
                    Req = string.Format(Req, NomPoste, CaracteristiquePoste);
                    con.EnvoyerDonnees(Req);
                    listerAjoutPoste();

                    MessageBox.Show("Poste Ajouter avec succès !!!");

                    txtNomPoste.Text = "";
                    txtDescription.Text = "";

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        int cle = 0;
        private void dataPoste_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dataPoste.Rows[e.RowIndex];
                    txtIdPoste.Text = selectedRow.Cells[0].Value.ToString();
                    txtNomPoste.Text = selectedRow.Cells[1].Value.ToString();
                    txtDescription.Text = selectedRow.Cells[2].Value.ToString();

                    if (txtIdPoste.Text == "")
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

        private void btnModifierP_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNomPoste.Text == "")
                {
                    lb1.Visible = true;
                }
                else
                {
                    string NomPoste = txtNomPoste.Text;
                    string CaracteristiquePoste = txtDescription.Text;
                    string Req = "update TblAjoutPoste set NomPoste ='{0}' ,CaracteristiquePoste ='{1}' where Id = {2}";
                    Req = string.Format(Req, NomPoste, CaracteristiquePoste ,cle);
                    con.EnvoyerDonnees(Req);
                    listerAjoutPoste();

                    MessageBox.Show("Modification Reussi !!!");
                    txtIdPoste.Text = "";
                    txtNomPoste.Text = "";
                    txtDescription.Text = "";

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
                if (txtNomPoste.Text == "")
                {
                    lb1.Visible = true;
                }
                else
                {
                    //string NomPoste = txtNomPoste.Text;
                    //string Caracteristique = txtDescription.Text;
                    string Req = "Delete from TblAjoutPoste where Id = {0}";
                    Req = string.Format(Req,cle);
                    con.EnvoyerDonnees(Req);
                    listerAjoutPoste();

                    MessageBox.Show("Suppression Reussi !!!");
                    txtIdPoste.Text = "";
                    txtNomPoste.Text = "";
                    txtDescription.Text = "";

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void txtNomPoste_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Vérifier que la touche pressée est une lettre ou la touche de contrôle
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquer la saisie

            }
        }
    }
}
