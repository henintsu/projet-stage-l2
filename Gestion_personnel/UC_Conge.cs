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
    public partial class UC_Conge : UserControl
    {
        
        Functions con;
        public UC_Conge()
        {
            DateTime dateT = DateTime.Now;
            InitializeComponent();
            con = new Functions();
            listerAjoutConge();
            RemplireConge();
            RemplireNom();
            dateDebutConge.Value = DateTime.Today;
            dateFinConge.Value = DateTime.Today;   // Initialise à la date du jour

            dataConge2.CellClick += dataConge2_CellContentClick;
            dataConge2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataConge2.EnableHeadersVisualStyles = false;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.Red;
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font(dataConge2.Font, FontStyle.Bold);

            dataConge2.ColumnHeadersDefaultCellStyle = headerStyle;

            txtIdConge.ReadOnly = true;
            txtIdPers.ReadOnly = true;
            txtPrenom.ReadOnly = true;
            txtPoste.ReadOnly = true;
            txtStatue.ReadOnly = true;
        }

        private void listerAjoutConge()
        {
            string req = "SELECT TblConge.IdConge, TblConge.CodePers, TblConge.CauseConge, TblConge.DatedebutConge, TblConge.DatefinConge, TblConge.NbrJourConge, TblPersonnel.NomPers, TblPersonnel.PrenomPers, TblPersonnel.StatuePers, TblPersonnel.PostePers,  TblPersonnel.ImagePers FROM TblConge INNER JOIN TblPersonnel ON TblConge.CodePers = TblPersonnel.CodePers";
            dataConge2.DataSource = con.RecupererDonnees(req);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            uC_AjoutConge1.Visible = true;
        }

        //recuperer la valeur
        private void RemplireConge()
        {
            string Req = "select * from TblAjoutConge";
            combocause.DisplayMember = con.RecupererDonnees(Req).Columns["Caracteristique"].ToString();
            combocause.ValueMember = con.RecupererDonnees(Req).Columns["Id"].ToString();
            combocause.DataSource = con.RecupererDonnees(Req);
        }

        //recuperer la valeur
        private void RemplireNom()
        {
            string Req = "select * from TblPersonnel";
            DataTable dataTable = con.RecupererDonnees(Req);

            // Tri alphabétique des données par le nom
            DataView dataView = dataTable.DefaultView;
            dataView.Sort = "NomPers ASC";

            ComboNomPers.DisplayMember = "NomPers";
            ComboNomPers.ValueMember = "CodePers";
            ComboNomPers.DataSource = dataView;
        }


        private void button4_Click(object sender, EventArgs e)
        {
           
            EffacerChamps();
        }

        public void EffacerChamps()
        {
            txtIdConge.Text = "";
            txtIdPers.Text = "";
            combocause.SelectedIndex = -1;
            dateDebutConge.Text = "";
            dateFinConge.Text = "";
            txtNbrJour.Text = "";
            ComboNomPers.SelectedIndex = -1;
            txtPoste.Text = "";
            txtPrenom.Text = "";
            txtStatue.Text = "";
            pictureBox2.Image = null;
        }
        public bool EstEmployeAffecteActif(int codePers)
        {
            string req = "SELECT COUNT(*) FROM TblAffectation WHERE CodePers = @CodePers AND DateAffectation <= GETDATE()";
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        {"@CodePers", codePers}
    };

            // Utiliser l'instance de la classe Functions pour appeler RecupererDonneesScalar
            Functions con = new Functions();
            int count = con.RecupererDonneesScalar(req, parameters);
            return count > 0;
        }


        private bool AUnCongeEnCours(int codePers)
        {
            string req = "SELECT COUNT(*) FROM TblConge WHERE CodePers = @CodePers AND DatefinConge >= GETDATE()";
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        {"@CodePers", codePers}
    };

            int count = (int)con.RecupererDonneesScalar(req, parameters);
            return count > 0;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdPers.Text == "")
                {
                    MessageBox.Show("Remplir les champs svp !!!");
                    return;
                }

                int CodePers = int.Parse(txtIdPers.Text);

                // Vérifier si le personnel a déjà un congé en cours
                bool aUnCongeEnCours = AUnCongeEnCours(CodePers);
                if (aUnCongeEnCours)
                {
                    MessageBox.Show("Le personnel a déjà un congé en cours.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Vérifier si le personnel est en affectation
                bool estEnAffectation = EstEmployeAffecteActif(CodePers);
                if (estEnAffectation)
                {
                    MessageBox.Show("Le personnel est en affectation et ne peut pas prendre de congé .");
                    return;
                }


                string CauseConge = combocause.Text;
                string DatedebutConge = dateDebutConge.Value.ToString("yyyy-MM-dd");
                int NbrJourConge = int.Parse(txtNbrJour.Text);

                if (NbrJourConge > 30)
                {
                    MessageBox.Show("Un employé ne peut pas prendre plus de 30 jours de congé en temps normal.");
                    return;
                }
               
                // Calculer la date de fin du congé en ajoutant le nombre de jours de congé à la date de début
                DateTime DatefinConge = dateDebutConge.Value.AddDays(NbrJourConge);


                string Req = "insert into TblConge(CodePers, CauseConge, DatedebutConge, DatefinConge, NbrJourConge) values (@CodePers, @CauseConge, @DatedebutConge,@DatefinConge, @NbrJourConge)";

                int cnt = con.EnvoyerDonnees(Req, new Dictionary<string, object>
                        {
                            {"@CodePers", CodePers},
                            {"@CauseConge", CauseConge},
                            {"@DatedebutConge", DatedebutConge},
                            {"@DatefinConge", DatefinConge},
                            {"@NbrJourConge", NbrJourConge},
                        });

                if (cnt > 0)
                {
                    listerAjoutConge();
                    MessageBox.Show("Un conge ajouté avec succès !!!");


                    MettreAJourNombreConge();
                    // Réinitialiser les champs après l'ajout
                    EffacerChamps();

                }
                else
                {
                    MessageBox.Show("Une erreur s'est produite lors de l'ajout du conge !");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        


        }
        private bool VerifierAffectation(int codePers)
        {
            string req = "SELECT COUNT(*) FROM TblAffectation WHERE CodePers = @CodePers";
            int count = con.RecupererDonneesScalar<int>(req, new Dictionary<string, object>
    {
        {"@CodePers", codePers}
    });

            return count > 0;
        }


        private void comboPrenomPers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataConge2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dataConge2.Rows[e.RowIndex];
                    txtIdConge.Text = selectedRow.Cells[0].Value.ToString();
                    txtIdPers.Text = selectedRow.Cells[1].Value.ToString();
                    combocause.Text = selectedRow.Cells[2].Value.ToString();
                    dateDebutConge.Text = selectedRow.Cells[3].Value.ToString();
                    dateFinConge.Text = selectedRow.Cells[4].Value.ToString();
                    txtNbrJour.Text = selectedRow.Cells[5].Value.ToString();
                    ComboNomPers.Text = selectedRow.Cells[6].Value.ToString();
                    txtPrenom.Text = selectedRow.Cells[7].Value.ToString();
                    txtStatue.Text = selectedRow.Cells[8].Value.ToString();
                    txtPoste.Text = selectedRow.Cells[9].Value.ToString();

                    // Supposons que la colonne d'image se trouve à l'index 14 (l'index est basé sur 0, donc 14 signifie la 15e colonne).
                    int imageColumnIndex = 10;

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

        private void button3_Click(object sender, EventArgs e)
        {
            RemplireNom();
            RemplireConge();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Afficher une boîte de dialogue pour permettre à l'utilisateur de sélectionner une image
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Définir les filtres de fichier pour afficher uniquement les images
                openFileDialog.Filter = "Fichiers d'images|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Tous les fichiers|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Charger l'image sélectionnée dans la PictureBox
                        pictureBox2.Image = new Bitmap(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        // Afficher un message en cas d'erreur lors du chargement de l'image
                        MessageBox.Show("Une erreur s'est produite lors du chargement de l'image : " + ex.Message);
                    }
                }
            }
        }

        private void ComboNomPers_SelectedIndexChanged(object sender, EventArgs e )
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
            string req = "SELECT PrenomPers, StatuePers, PostePers, ImagePers FROM TblPersonnel WHERE CodePers = @CodePers";
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
                EffacerChamps();
            }
        }


        private void LoadNomPersonnel()
        {
            string req = "SELECT NomPers, CodePers FROM TblPersonnel";
            DataTable dt = con.RecupererDonnees(req);

            // Assurez-vous que le ComboBox ne soit pas null et vide
            ComboNomPers.Items.Clear();

            // Parcourir les enregistrements pour remplir le ComboBox
            foreach (DataRow row in dt.Rows)
            {
                string nom = row["NomPers"].ToString();
                string codePersonnel = row["CodePers"].ToString();
                ComboNomPers.Items.Add(nom); // Ajouter le nom directement au ComboBox
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifier d'abord si une ligne est sélectionnée dans le DataGridView
                if (dataConge2.SelectedRows.Count > 0)
                {
                    // Récupérer la clé primaire de l'enregistrement sélectionné (dans la colonne 0)
                    int selectedRowIndex = dataConge2.SelectedRows[0].Index;
                    int id = Convert.ToInt32(dataConge2.Rows[selectedRowIndex].Cells[0].Value);

                    // Récupérer les nouvelles valeurs des champs
                    int CodePers = int.Parse(txtIdPers.Text);

                    string CauseConge = combocause.Text;
                    string DatedebutConge = dateDebutConge.Value.ToString("yyyy-MM-dd"); // Format de date attendu par la base de données
                    string DatefinConge = dateFinConge.Value.ToString("yyyy-MM-dd"); // Format de date attendu par la base de données
                    int NbrJourConge = int.Parse(txtNbrJour.Text);
                    
                    // Construire la requête SQL pour la mise à jour
                    string Req = "UPDATE TblConge SET CodePers = @IdPers, CauseConge = @Cause ,DatedebutConge = @Datedebut, DatefinConge = @Datefin, NbrJourConge = @NbrJourConge WHERE IdConge = @Id";

                    // Exécuter la requête de mise à jour en utilisant la méthode EnvoyerDonnees de la classe Functions
                    int cnt = con.EnvoyerDonnees(Req, new Dictionary<string, object>
                        {

                            {"@IdPers", CodePers},
                            {"@Cause", CauseConge},
                            {"@Datedebut", DatedebutConge},
                            {"@Datefin", DatefinConge},
                            {"@NbrJourConge", NbrJourConge},
                            {"@Id", id} // Clé primaire pour identifier l'enregistrement à mettre à jour

                        });


                    if (cnt > 0)
                    {
                        listerAjoutConge();
                        MessageBox.Show("Informations du conge mises à jour avec succès !");
                        txtPrenom.Text = "";
                        txtStatue.Text = "";
                        txtPoste.Text = "";
                        EffacerChamps();
                        MettreAJourNombreConge();
                    }
                    else
                    {
                        MessageBox.Show("Une erreur s'est produite lors de la mise à jour des informations du conge !");
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner un enregistrement à modifier !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message);
            }
        }

        private void btnsupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifier d'abord si une ligne est sélectionnée dans le DataGridView
                if (dataConge2.SelectedRows.Count > 0)
                {
                    // Récupérer la clé primaire de l'enregistrement sélectionné (dans la colonne 0)
                    int selectedRowIndex = dataConge2.SelectedRows[0].Index;
                    int id = Convert.ToInt32(dataConge2.Rows[selectedRowIndex].Cells[0].Value);

                    DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet enregistrement ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Construire la requête SQL pour la suppression
                        string Req = "DELETE FROM TblConge WHERE IdConge = @Id";

                        // Exécuter la requête de suppression en utilisant la méthode EnvoyerDonnees de la classe Functions
                        int cnt = con.EnvoyerDonnees(Req, new Dictionary<string, object>
                {
                    {"@Id", id}
                });

                        if (cnt > 0)
                        {
                            // Actualiser le DataGridView pour afficher les enregistrements restants
                            listerAjoutConge();

                            MessageBox.Show("Enregistrement supprimé avec succès !");
                            txtPrenom.Text = "";
                            txtStatue.Text = "";
                            txtPoste.Text = "";
                            EffacerChamps();
                            MettreAJourNombreConge();
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

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string recherche = textBox8.Text.Trim();

            if (string.IsNullOrWhiteSpace(recherche))
            {
                // La zone de texte de recherche est vide, afficher tous les enregistrements
                listerAjoutConge();
            }
            else
            {
                RechercherConge(recherche);
            }
        }

        private void RechercherConge(string recherche)
        {
            try
            {
                string Req = "SELECT TblConge.IdConge, TblConge.CodePers, TblConge.CauseConge, TblConge.DatedebutConge, TblConge.DatefinConge, TblConge.NbrJourConge, " +
             "TblPersonnel.NomPers, TblPersonnel.PrenomPers, TblPersonnel.StatuePers, TblPersonnel.PostePers, TblPersonnel.ImagePers " +
             "FROM TblConge " +
             "INNER JOIN TblPersonnel ON TblConge.CodePers = TblPersonnel.CodePers " +
             "WHERE TblConge.IdConge LIKE @Recherche OR " +
             "TblConge.CodePers LIKE @Recherche OR " +
             "TblConge.CauseConge LIKE @Recherche OR " +
             "TblConge.DatedebutConge LIKE @Recherche OR " +
             "TblConge.DatefinConge LIKE @Recherche OR " +
             "TblConge.NbrJourConge LIKE @Recherche OR " +
             "TblPersonnel.NomPers LIKE @Recherche OR " +
             "TblPersonnel.PrenomPers LIKE @Recherche OR " +
             "TblPersonnel.StatuePers LIKE @Recherche OR " +
             "TblPersonnel.PostePers LIKE @Recherche";

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters["@Recherche"] = "%" + recherche + "%";

                DataTable dataTable = con.RecupererDonnees(Req, parameters);
                dataConge2.DataSource = dataTable;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void combocause_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            RemplireNom();
            RemplireConge();
            MettreAJourNombreConge();
        }

        private void ComboNomPers_TextChanged(object sender, EventArgs e)
        {
            string recherche = ComboNomPers.Text;

            try
            {
                string req = "SELECT TblPersonnel.CodePers, TblPersonnel.NomPers FROM TblPersonnel WHERE TblPersonnel.NomPers LIKE @Recherche";

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters["@Recherche"] = "%" + recherche + "%";

                DataTable resultatsRecherche = con.RecupererDonnees(req, parameters);

                ComboNomPers.DataSource = resultatsRecherche;
                ComboNomPers.DisplayMember = "NomPers"; // Assurez-vous que "NomPers" est correct
                ComboNomPers.ValueMember = "CodePers"; // Assurez-vous que "CodePers" est correct

                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        public int nbrPerso()
        {
            string Req = "SELECT COUNT(*) as mombre FROM TblConge";
            DataTable dt = con.RecupererDonnees(Req);

            if (dt.Rows.Count > 0)
            {
                int nombreConge = Convert.ToInt32(dt.Rows[0]["mombre"]);
                return nombreConge;
            }

            

            return 0;
        }

        public void MettreAJourNombreConge()
        {
            int nombreConge = nbrPerso();
            txtcompte.Text = nombreConge.ToString();
           
        }
        
        private void date()
        {

            DateTime dateT = DateTime.Now; // Définir la date actuelle

            if (dateFinConge.Value.Date == dateT.Date)
            {
                MessageBox.Show("Le congé est terminé !");
            }

        }

        private void txtNbrJour_TextChanged(object sender, EventArgs e)
        {
            
        }

       
        private void txtNbrJour_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }

}

