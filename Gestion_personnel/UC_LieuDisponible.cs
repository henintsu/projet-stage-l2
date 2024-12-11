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
    public partial class UC_LieuDisponible : UserControl
    {
        Functions con;
        public UC_LieuDisponible()
        {
            InitializeComponent();
            con = new Functions();
            ListerAjoutLieu();

            dataLieuAffectation.CellClick += dataLieuAffectation_CellContentClick;
            dataLieuAffectation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataLieuAffectation.EnableHeadersVisualStyles = false;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.Red;
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font(dataLieuAffectation.Font, FontStyle.Bold);

            dataLieuAffectation.ColumnHeadersDefaultCellStyle = headerStyle;

        }

        private void ListerAjoutLieu()
        {
            string Req = "Select * from TblAjoutLieu";
            dataLieuAffectation.DataSource = con.RecupererDonnees(Req);
        }

        private void UC_LieuDisponible_Load(object sender, EventArgs e)
        {

        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLieu.Text == "")
                {
                    //lb1.Visible = true;
                }
                else
                {
                    string Lieu = txtLieu.Text;
                    string Une = ComboUne.SelectedItem.ToString();
                    string Req = "insert into TblAjoutLieu values('{0}','{1}')";
                    Req = string.Format(Req, Lieu, Une);
                    con.EnvoyerDonnees(Req);
                    ListerAjoutLieu();

                    MessageBox.Show("Lieu  Ajouter avec succée !!!");

                    effacerchamps();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void effacerchamps()
        {
            txtLieu.Text = "";
            ComboUne.Text = "";
        }

        int cle = 0;
        private void dataLieuAffectation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dataLieuAffectation.Rows[e.RowIndex];
                    txtIdLieu.Text = selectedRow.Cells[0].Value.ToString();
                    txtLieu.Text = selectedRow.Cells[1].Value.ToString();
                    ComboUne.Text = selectedRow.Cells[2].Value.ToString();

                    if (txtLieu.Text == "")
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

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLieu.Text == "")
                {
                    //lb1.Visible = true;
                }
                else
                {
                    string Lieu = txtLieu.Text;
                    string Une = ComboUne.SelectedItem.ToString();
                    string Req = "update TblAjoutlIEU set Lieu ='{0}' ,Une ='{1}' where  IdLieu= {2}";
                    Req = string.Format(Req, Lieu, Une, cle);
                    con.EnvoyerDonnees(Req);
                    ListerAjoutLieu();

                    MessageBox.Show("Lieu  a jour  avec succée !!!");
                    txtIdLieu.Text = "";
                    effacerchamps();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLieu.Text == "")
                {
                    //lb1.Visible = true;
                }
                else
                {
                    string Req = "Delete from TblAjoutLieu where IdLieu = {0}";
                    Req = string.Format(Req, cle);
                    con.EnvoyerDonnees(Req);
                    ListerAjoutLieu();

                    MessageBox.Show("Lieu Supprimer  avec succée !!!");
                    txtIdLieu.Text = "";
                    effacerchamps();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
           
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir annuler cet enregistrement ?", "Confirmation de l annulation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                txtIdLieu.Text = "";
                effacerchamps();
            }
            
        }
    }
}
