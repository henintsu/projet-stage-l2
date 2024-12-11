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
    public partial class CrudForm : Form
    {
        Functions con;  
        public CrudForm()
        {
            InitializeComponent();
            con = new Functions();
            ListerPers();
        }

        private void ListerPers()
        {
            string Req = "Select * from personne ";
            dataliste.DataSource = con.RecupererDonnees(Req);
        }
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtnom.Text == "" || txtprenom.Text == "" )
                {
                    MessageBox.Show("remplir les champs svp !!!");
                }
                else
                {

                    string nompers = txtnom.Text;
                    string prenompers = txtprenom.Text;
                    string Req = "insert into personne values({0},'{1}')";
                    Req = string.Format(Req, nompers, prenompers);
                    con.EnvoyerDonnees(Req);
                    ListerPers();
                    MessageBox.Show("ajout reussi !!!");
                    txtnom.Text = "";
                    txtprenom.Text = "";

                }
            }

            catch (Exeption Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        int cle = 0;

        private void dataliste_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtnom.Text = dataliste.SelectedRows[0].Cells[2].Value.ToString();
            txtprenom.Text = dataliste.SelectedRows[0].Cells[3].Value.ToString();


            if (txtnom.Text == "")
            {
                cle = 0;
            }
            else
            {
                cle = ToInt32(dataliste.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private int ToInt32(string v)
        {
            throw new NotImplementedException();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            
        }

        private void CrudForm_Load(object sender, EventArgs e)
        {

        }
    }
}
