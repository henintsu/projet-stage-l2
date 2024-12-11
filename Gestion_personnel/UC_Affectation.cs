using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Gestion_personnel
{
    public partial class UC_Affectation : UserControl
    {
        Functions con;
        public UC_Affectation()
        {
            InitializeComponent();
            con = new Functions();
            RemplireNom();
            listerAffectation();
            RemplireNmLieu();

            dataAffectation.CellClick += dataAffectation_CellContentClick;
            dataAffectation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataAffectation.EnableHeadersVisualStyles = false;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.Red;
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font(dataAffectation.Font, FontStyle.Bold);

            dataAffectation.ColumnHeadersDefaultCellStyle = headerStyle;

            txtIdAffectation.ReadOnly = true;
            txtIdPers.ReadOnly = true;
            txtPrenom.ReadOnly = true;
            txtPoste.ReadOnly = true;
            txtStatue.ReadOnly = true;
        }
        private void RemplireNom()
        {
            string Req = "select * from TblPersonnel";
            DataTable dataTable = con.RecupererDonnees(Req);

            // Tri du DataTable par la colonne "NomPers"
            DataView dataView = dataTable.DefaultView;
            dataView.Sort = "NomPers ASC";
            dataTable = dataView.ToTable();

            // Utilisation du DataTable trié comme source de données pour la ComboBox
            ComboNomPers.DisplayMember = "NomPers";
            ComboNomPers.ValueMember = "CodePers";
            ComboNomPers.DataSource = dataTable;
        }

        private void RemplireNmLieu()
        {
            string Req = "select * from TblAjoutLieu";
            comboLieuAffectation.DisplayMember = con.RecupererDonnees(Req).Columns["Lieu"].ToString();
            comboLieuAffectation.ValueMember = con.RecupererDonnees(Req).Columns["IdLieu"].ToString();
            comboLieuAffectation.DataSource = con.RecupererDonnees(Req);
        }

        private void listerAffectation()
        {
            string req = "SELECT TblAffectation.IdAffectation, TblAffectation.CodePers, TblAffectation.LieuAffectation, TblAffectation.DateAffectation, TblPersonnel.NomPers, TblPersonnel.PrenomPers, TblPersonnel.StatuePers, TblPersonnel.PostePers ,TblPersonnel.ImagePers FROM TblAffectation INNER JOIN TblPersonnel ON TblAffectation.CodePers = TblPersonnel.CodePers";
            dataAffectation.DataSource = con.RecupererDonnees(req);
        }


        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdPers.Text == "")
                {
                    MessageBox.Show("Remplir les champs svp !!!", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                int CodePers = int.Parse(txtIdPers.Text);

               

                string LieuAffectation = comboLieuAffectation.Text;
                string DateAffectation = dateAffectation.Value.ToString("yyyy-MM-dd"); // Format de date attendu par la base de données

                string Req = "insert into TblAffectation (CodePers, LieuAffectation, DateAffectation) values (@CodePers, @LieuAffectation, @DateAffectation)";

                int cnt = con.EnvoyerDonnees(Req, new Dictionary<string, object>
                        {
                            {"@CodePers", CodePers},
                            {"@LieuAffectation", LieuAffectation},
                            {"@DateAffectation", DateAffectation},
                            
                        });

                if (cnt > 0)
                {
                    // Appeler à nouveau la méthode pour mettre à jour les données affichées dans le DataGridView
                    listerAffectation();
                    MessageBox.Show("Un Affectation ajouté avec succès !!!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MettreAJourNombreAffectation();
                    // Réinitialiser les champs après l'ajout
                    effacerchamps();
                }
                else
                {
                    MessageBox.Show("Une erreur s'est produite lors de l'ajout du personnel !");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void effacerchamps()
        {
            txtIdAffectation.Text = "";
            txtIdPers.Text = "";
            comboLieuAffectation.SelectedIndex = -1;
            dateAffectation.Text = "";
            ComboNomPers.SelectedIndex = -1;
            ComboNomPers.SelectedIndex = -1;
            txtPrenom.Text = "";
            txtStatue.Text = "";
            txtPoste.Text = "";
            pictureBox2.Image = null;
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            RemplireNom();
            RemplireNmLieu();
            MettreAJourNombreAffectation();
        }

        private void dataAffectation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dataAffectation.Rows[e.RowIndex];
                    txtIdAffectation.Text = selectedRow.Cells[0].Value.ToString();
                    txtIdPers.Text = selectedRow.Cells[1].Value.ToString();
                    comboLieuAffectation.Text = selectedRow.Cells[2].Value.ToString();
                    dateAffectation.Text = selectedRow.Cells[3].Value.ToString();
                    ComboNomPers.Text = selectedRow.Cells[4].Value.ToString();
                    txtPrenom.Text = selectedRow.Cells[5].Value.ToString();
                    txtStatue.Text = selectedRow.Cells[6].Value.ToString();
                    txtPoste.Text = selectedRow.Cells[7].Value.ToString();
                    int imageColumnIndex = 8;

                    if (selectedRow.Cells[imageColumnIndex].Value != null)
                    {
                        // Convertir la valeur de la cellule (byte[]) en image et l'afficher dans le PictureBox pictureBox2.
                        byte[] imageData = (byte[])selectedRow.Cells[imageColumnIndex].Value;
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            pictureBox2.Image = Image.FromStream(ms);
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboNomPers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboNomPers.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)ComboNomPers.SelectedItem;
                string codePersonnel = selectedRow["CodePers"].ToString();
                RemplirAutresInformations(codePersonnel);
            }
        }

        private void RemplirAutresInformations(string codePersonnel)
        {
            // Effectuer une requête pour récupérer les autres informations du personnel
            string req = "SELECT PrenomPers, StatuePers, PostePers ,ImagePers FROM TblPersonnel WHERE CodePers = @CodePers";
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        {"@CodePers", codePersonnel}
    };
            DataTable dt = con.RecupererDonnees(req, parameters);

            if (dt.Rows.Count > 0)
            {
                // Afficher les autres informations dans les TextBox appropriées
                txtPrenom.Text = dt.Rows[0]["PrenomPers"].ToString();
                txtStatue.Text = dt.Rows[0]["StatuePers"].ToString();
                txtPoste.Text = dt.Rows[0]["PostePers"].ToString();
                txtIdPers.Text = codePersonnel;
                // Afficher l'image dans le PictureBox
                byte[] imageData = (byte[])dt.Rows[0]["ImagePers"];
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    pictureBox2.Image = Image.FromStream(ms);
                }
            }
            else
            {
                // Réinitialiser les TextBox si aucune information n'a été trouvée
                effacerchamps();
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string recherche = textBox8.Text.Trim();

            if (string.IsNullOrWhiteSpace(recherche))
            {
                // La zone de texte de recherche est vide, afficher tous les enregistrements
                listerAffectation();
            }
            else
            {
                RechercherAffectation(recherche);
            }
        }


               private void RechercherAffectation(string recherche)
        {
            try
            {
                string Req = "SELECT TblAffectation.IdAffectation, TblAffectation.CodePers, TblAffectation.LieuAffectation, TblAffectation.DateAffectation, " +
             "TblPersonnel.NomPers, TblPersonnel.PrenomPers, TblPersonnel.StatuePers, TblPersonnel.PostePers, TblPersonnel.ImagePers " +
             "FROM TblAffectation " +
             "INNER JOIN TblPersonnel ON TblAffectation.CodePers = TblPersonnel.CodePers " +
             "WHERE TblAffectation.IdAffectation LIKE @Recherche OR " +
             "TblAffectation.CodePers LIKE @Recherche OR " +
             "TblAffectation.LieuAffectation LIKE @Recherche OR " +
             "TblAffectation.DateAffectation LIKE @Recherche OR " +
             "TblPersonnel.NomPers LIKE @Recherche OR " +
             "TblPersonnel.PrenomPers LIKE @Recherche OR " +
             "TblPersonnel.StatuePers LIKE @Recherche OR " +
             "TblPersonnel.PostePers LIKE @Recherche";


                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters["@Recherche"] = "%" + recherche + "%";

                DataTable dataTable = con.RecupererDonnees(Req, parameters);
                dataAffectation.DataSource = dataTable;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifier d'abord si une ligne est sélectionnée dans le DataGridView
                if (dataAffectation.SelectedRows.Count > 0)
                {


                    // Récupérer la clé primaire de l'enregistrement sélectionné (dans la colonne 0)
                    int selectedRowIndex = dataAffectation.SelectedRows[0].Index;
                    int id = Convert.ToInt32(dataAffectation.Rows[selectedRowIndex].Cells[0].Value);

                    DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet enregistrement ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Construire la requête SQL pour la suppression
                        string Req = "DELETE FROM TblAffectation WHERE IdAffectation = @Id";

                        // Exécuter la requête de suppression en utilisant la méthode EnvoyerDonnees de la classe Functions
                        int cnt = con.EnvoyerDonnees(Req, new Dictionary<string, object>
                {
                    {"@Id", id}
                });

                        if (cnt > 0)
                        {
                            // Actualiser le DataGridView pour afficher les enregistrements restants
                            listerAffectation();

                            MessageBox.Show("Enregistrement supprimé avec succès !");
                            txtPrenom.Text = "";
                            txtStatue.Text = "";
                            txtPoste.Text = "";
                            effacerchamps();
                            MettreAJourNombreAffectation();
                        }
                        else
                        {
                            MessageBox.Show("Une erreur s'est produite lors de la suppression de l'enregistrement !");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner un enregistrement à supprimer !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir annuler cet enregistrement ?", "Confirmation de l annulation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                effacerchamps();
            }
            
        }

        private void btnActualiser_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        public int nbrPerso()
        {
            string Req = "SELECT COUNT(*) as mombre FROM TblAffectation";
            DataTable dt = con.RecupererDonnees(Req);

            if (dt.Rows.Count > 0)
            {
                int nombreAffectation = Convert.ToInt32(dt.Rows[0]["mombre"]);
                return nombreAffectation;
            }



            return 0;
        }

        public void MettreAJourNombreAffectation()
        {
            int nombreAffectation = nbrPerso();
            txtcompte.Text = nombreAffectation.ToString();

        }
    }

}
