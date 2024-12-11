using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace Gestion_personnel
{

    public partial class Uc_ : UserControl
    {
        // Déclarez les attributs de classe pour stocker les valeurs des champs de saisie
        Functions con;
        private DataTable dtPersonnel;
       

        public Uc_()
        {
            
            InitializeComponent();
            con = new Functions();
            listerPersonnel();
            RemplirePoste();
            RemplireStatue();
            // Ajouter l'événement "CellClick" au DataGridView
            tabListe.CellClick += tabListe_CellClick;


            tabListe.EnableHeadersVisualStyles = false;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.Red;
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font(tabListe.Font, FontStyle.Bold);

            tabListe.ColumnHeadersDefaultCellStyle = headerStyle;
        }
        

        private void listerPersonnel()
        {
            string Req = "select * from TblPersonnel";
            tabListe.DataSource = con.RecupererDonnees(Req);
            dtPersonnel = con.RecupererDonnees(Req);
            tabListe.DataSource = dtPersonnel;
            // Vérifier pour chaque enregistrement s'il a atteint la date de fin de congé
            foreach (DataRow row in dtPersonnel.Rows)
            {
                DateTime dateFinConge = Convert.ToDateTime(row["DatefinPers"]);
                DateTime dateActuelle = DateTime.Now;

                // Comparer les dates pour déterminer si le congé est terminé
                if (dateActuelle > dateFinConge)
                {
                    string nomPersonnel = row["NomPers"].ToString();
                    string message = $"Le congé de {nomPersonnel} est terminé.";
                    //MessageBox.Show(message, "Congé terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            tabListe.DataSource = dtPersonnel;
        }

        //recuperer la valeur 
        private void RemplirePoste()
        {
            string Req = "select * from TblAjoutPoste";
            DataTable dtPoste = con.RecupererDonnees(Req);
            comboposte.DisplayMember = "NomPoste";
            comboposte.ValueMember = "Id";
            comboposte.DataSource = dtPoste;

        }

        private void RemplireStatue()
        {
            string Req = "select * from TblStatue";
            DataTable dtStatue = con.RecupererDonnees(Req);
            combostatue.DisplayMember = "NomSt";
            combostatue.ValueMember = "CodeStatue";
            combostatue.DataSource = dtStatue;
        }


        private int ToInt32(string v)
        {
            throw new NotImplementedException();
        }

        int cle = 0;

        public IFormatProvider CodePers { get; private set; }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < tabListe.Rows.Count)
                {
                    DataGridViewRow selectedRow = tabListe.Rows[e.RowIndex];
                    txtid.Text = selectedRow.Cells[0].Value.ToString();
                    txtnom.Text = selectedRow.Cells[1].Value.ToString();
                    txtprenom.Text = selectedRow.Cells[2].Value.ToString();
                    txtadresse.Text = selectedRow.Cells[3].Value.ToString();
                    txttelephone.Text = selectedRow.Cells[4].Value.ToString();
                    txtemail.Text = selectedRow.Cells[5].Value.ToString();
                    txtcin.Text = selectedRow.Cells[6].Value.ToString();

                    // Pour le groupe de radio boutons, vous devez rechercher le bouton qui correspond à la valeur de la cellule
                    string sexe = selectedRow.Cells[7].Value.ToString();
                    foreach (RadioButton radioButton in groupBoxsexe.Controls.OfType<RadioButton>())
                    {
                        if (radioButton.Text == sexe)
                        {
                            radioButton.Checked = true;
                            break;
                        }
                    }

                    datenaiss.Text = selectedRow.Cells[8].Value.ToString();
                    combostatue.SelectedValue = selectedRow.Cells[9].Value;
                    comboposte.SelectedValue = selectedRow.Cells[10].Value;
                    txtSalaire.Text = selectedRow.Cells[11].Value.ToString(); 
                    datedebut.Text = selectedRow.Cells[12].Value.ToString();
                    datefin.Text = selectedRow.Cells[13].Value.ToString();
                    int imageColumnIndex = 14;

                    if (selectedRow.Cells[imageColumnIndex].Value != null)
                    {
                        // Convertir la valeur de la cellule (byte[]) en image et l'afficher dans le PictureBox pictureBox2.
                        byte[] imageData = (byte[])selectedRow.Cells[imageColumnIndex].Value;
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            pictureBox2.Image = Image.FromStream(ms);
                        }
                    }

                    if (txtnom.Text == "")
                    {
                        cle = 0;
                    }
                    else
                    {
                        cle = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private bool EstPersonnelExistant(string nom, string prenom, string cin)
        {
            try
            {
                // Utilisez la chaîne de connexion appropriée pour votre base de données
                using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\acer\Documents\TestDB.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    conn.Open();
                    string reqVerification = "SELECT COUNT(*) FROM TblPersonnel WHERE NomPers = @Nom AND PrenomPers = @Prenom AND CinPers = @Cin";
                    SqlCommand cmd = new SqlCommand(reqVerification, conn);
                    cmd.Parameters.AddWithValue("@Nom", nom);
                    cmd.Parameters.AddWithValue("@Prenom", prenom);
                    cmd.Parameters.AddWithValue("@Cin", cin);

                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de la vérification de l'existence du personnel : " + ex.Message);
                return false;
            }
        }

        private void btnenregistrer_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtnom.Text == "")
                {
                    MessageBox.Show("Remplir les champs svp !!!", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    string SexePers = groupBoxsexe.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(rb => rb.Checked)?.Text;

                    if (string.IsNullOrEmpty(SexePers))
                    {
                        MessageBox.Show("Veuillez sélectionner un sexe !", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        return;
                    }

                    string NomPers = txtnom.Text;
                    string PrenomPers = txtprenom.Text;
                    string AdressePers = txtadresse.Text;
                    string TelephonePers = txttelephone.Text;
                    string EmailPers = txtemail.Text;
                    string CinPers = txtcin.Text;
                    string DatenaissPers = datenaiss.Value.ToString("yyyy-MM-dd"); // Format de date attendu par la base de données
                    string StatuePers = combostatue.Text;
                    string PostePers = comboposte.Text;
                    string SalairePers = txtSalaire.Text;
                    string DatedebutPers = datedebut.Value.ToString("yyyy-MM-dd"); 
                    string DatefinPers = datefin.Value.ToString("yyyy-MM-dd"); 

                    byte[] imageData = null;

                    if (pictureBox2.Image != null)
                    {
                        pictureBox2.Image = new Bitmap(pictureBox2.Image);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            imageData = ms.ToArray();
                        }
                    }

                    // Vérifier si le personnel existe déjà
                    if (EstPersonnelExistant(NomPers, PrenomPers, CinPers))
                    {
                        MessageBox.Show("Cet employé est deja dans la base de donnée ,vous ne pouvez pas l'enregistrer une seconde fois.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string Req = "INSERT INTO TblPersonnel (NomPers, PrenomPers, AdressePers, TelephonePers, EmailPoste, CinPers, SexePers, DatenaissPers, StatuePers, PostePers, SalairePers, DatedebutPers, DatefinPers, ImagePers) " +
                                 "VALUES (@Nom, @Prenom, @Adresse, @Telephone, @Email, @Cin, @Sexe, @DateNaiss, @Statue, @Poste, @Salaire, @DateDebut, @DateFin, @ImagePers)";

                    int cnt = con.EnvoyerDonnees(Req, new Dictionary<string, object>
                        {
                            {"@Nom", NomPers},
                            {"@Prenom", PrenomPers},
                            {"@Adresse", AdressePers},
                            {"@Telephone", TelephonePers},
                            {"@Email", EmailPers},
                            {"@Cin", CinPers},
                            {"@Sexe", SexePers},
                            {"@DateNaiss", DatenaissPers},
                            {"@Statue", StatuePers},
                            {"@Poste", PostePers},
                            {"@Salaire", SalairePers},
                            {"@DateDebut", DatedebutPers},
                            {"@DateFin", DatefinPers},
                            {"@ImagePers", imageData}
                        });

                    if (cnt > 0)
                    {
                        listerPersonnel();
                        MessageBox.Show("Un personnel ajouté avec succès !!!");

                        // Réinitialiser les champs après l'ajout
                        txtid.Text = "";
                        txtnom.Text = "";
                        txtprenom.Text = "";
                        txtadresse.Text = "";
                        txttelephone.Text = "";
                        txtemail.Text = "";
                        txtcin.Text = "";
                        groupBoxsexe.Controls.OfType<RadioButton>().ToList().ForEach(rb => rb.Checked = false);
                        datenaiss.Text = "";
                        combostatue.Text = "";
                        comboposte.Text = "";
                        txtSalaire.Text = "";
                        datedebut.Text = "";
                        datefin.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Une erreur s'est produite lors de l'ajout du personnel !");
                    }

                    MettreAJourNombrePersonnel();
                }
                
               
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }


        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            uC_AjoutPoste1.Visible = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            uC_AjoutStatue1.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uC_AjoutStatue1_Load(object sender, EventArgs e)
        {

        }

        private void btnsupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifier d'abord si une ligne est sélectionnée dans le DataGridView
                if (tabListe.SelectedRows.Count > 0)
                {
                    // Récupérer la clé primaire de l'enregistrement sélectionné (dans la colonne 0)
                    int selectedRowIndex = tabListe.SelectedRows[0].Index;
                    int id = Convert.ToInt32(tabListe.Rows[selectedRowIndex].Cells[0].Value);

                    DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet enregistrement ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        
                        string Req = "DELETE FROM TblPersonnel WHERE CodePers = @Id";

                        // Exécuter la requête de suppression en utilisant la méthode EnvoyerDonnees de la classe Functions
                        int cnt = con.EnvoyerDonnees(Req, new Dictionary<string, object>
                {
                    {"@Id", id}
                });

                        if (cnt > 0)
                        {
                            // Actualiser le DataGridView pour afficher les enregistrements restants
                            listerPersonnel();

                            MessageBox.Show("Enregistrement supprimé avec succès !");
                            ReinitialiserChamps();
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

                MettreAJourNombrePersonnel();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message);
            }
        }

        private void ReinitialiserChamps()
        {
            txtid.Text = "";
            txtnom.Text = "";
            txtprenom.Text = "";
            txtadresse.Text = "";
            txttelephone.Text = "";
            txtemail.Text = "";
            txtcin.Text = "";
            groupBoxsexe.Controls.OfType<RadioButton>().ToList().ForEach(rb => rb.Checked = false);
            datenaiss.Text = "";
            combostatue.SelectedIndex = -1;
            comboposte.SelectedIndex = -1;
            txtSalaire.Text = "";
            datedebut.Text = "";
            datefin.Text = "";
            // Pour réinitialiser le PictureBox
            pictureBox2.Image = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // Filtre pour afficher uniquement les fichiers image
                    openFileDialog.Filter = "Fichiers image|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

                    // Afficher la boîte de dialogue
                    DialogResult result = openFileDialog.ShowDialog();

                    // Si l'utilisateur a sélectionné un fichier et a cliqué sur le bouton "Ouvrir"
                    if (result == DialogResult.OK)
                    {
                        // Obtenir le chemin complet du fichier sélectionné
                        string filePath = openFileDialog.FileName;

                        // Charger l'image dans le PictureBox
                        pictureBox2.Image = Image.FromFile(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors du chargement de l'image : " + ex.Message);
            }
        }

        private void btnmodifier_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifier d'abord si une ligne est sélectionnée dans le DataGridView
                if (tabListe.SelectedRows.Count > 0)
                {
                    // Récupérer la clé primaire de l'enregistrement sélectionné (dans la colonne 0)
                    int selectedRowIndex = tabListe.SelectedRows[0].Index;
                    int id = Convert.ToInt32(tabListe.Rows[selectedRowIndex].Cells[0].Value);

                    // Récupérer les nouvelles valeurs des champs
                    string SexePers = groupBoxsexe.Controls.OfType<RadioButton>()
                                        .FirstOrDefault(rb => rb.Checked)?.Text;
                    string NomPers = txtnom.Text;
                    string PrenomPers = txtprenom.Text;
                    string AdressePers = txtadresse.Text;
                    string TelephonePers = txttelephone.Text;
                    string EmailPers = txtemail.Text;
                    string CinPers = txtcin.Text;
                    string DatenaissPers = datenaiss.Value.ToString("yyyy-MM-dd");
                    string StatuePers = combostatue.Text;
                    string PostePers = comboposte.Text;
                    string SalairePers = txtSalaire.Text;
                    string DatedebutPers = datedebut.Value.ToString("yyyy-MM-dd");
                    string DatefinPers = datefin.Value.ToString("yyyy-MM-dd");

                    // Construire la requête SQL pour la mise à jour
                    string Req = "UPDATE TblPersonnel SET NomPers = @Nom, PrenomPers = @Prenom, AdressePers = @Adresse, TelephonePers = @Telephone, EmailPoste = @Email, CinPers = @Cin, SexePers = @Sexe, DatenaissPers = @DateNaiss, StatuePers = @Statue, PostePers = @Poste, SalairePers = @Salaire, DatedebutPers = @DateDebut, DatefinPers = @DateFin, ImagePers = @ImagePers " +
                                 "WHERE CodePers = @Id";

                    // Pour l'attribut "ImagePers", vous devez convertir l'image du PictureBox (pictureBox2.Image) en tableau d'octets (byte[])

                    byte[] imageData = null;
                    if (pictureBox2.Image != null)
                    {
                        pictureBox2.Image = new Bitmap(pictureBox2.Image);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            imageData = ms.ToArray();
                        }
                    }
                    // Exécuter la requête de mise à jour en utilisant la méthode EnvoyerDonnees de la classe Functions
                    int cnt = con.EnvoyerDonnees(Req, new Dictionary<string, object>
            {
                {"@Nom", NomPers},
                {"@Prenom", PrenomPers},
                {"@Adresse", AdressePers},
                {"@Telephone", TelephonePers},
                {"@Email", EmailPers},
                {"@Cin", CinPers},
                {"@Sexe", SexePers},
                {"@DateNaiss", DatenaissPers},
                {"@Statue", StatuePers},
                {"@Poste", PostePers},
                {"@Salaire", SalairePers},
                {"@DateDebut", DatedebutPers},
                {"@DateFin", DatefinPers},
                {"@ImagePers", imageData},
                {"@Id", id} // Clé primaire pour identifier l'enregistrement à mettre à jour
            });

                    if (cnt > 0)
                    {
                        listerPersonnel();
                        MessageBox.Show("Informations du personnel mises à jour avec succès !");
                        ReinitialiserChamps();
                    }
                    else
                    {
                        MessageBox.Show("Une erreur s'est produite lors de la mise à jour des informations du personnel !");
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

        private void btnannuler_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir annuler cet enregistrement ?", "Confirmation de l annulation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                ReinitialiserChamps();
            }

        }

        private void tabListe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = tabListe.Rows[e.RowIndex];
                    txtid.Text = selectedRow.Cells[0].Value.ToString();
                    txtnom.Text = selectedRow.Cells[1].Value.ToString();
                    txtprenom.Text = selectedRow.Cells[2].Value.ToString();
                    txtadresse.Text = selectedRow.Cells[3].Value.ToString();
                    txttelephone.Text = selectedRow.Cells[4].Value.ToString();
                    txtemail.Text = selectedRow.Cells[5].Value.ToString();
                    txtcin.Text = selectedRow.Cells[6].Value.ToString();

                    // Pour le groupe de radio boutons, vous devez rechercher le bouton qui correspond à la valeur de la cellule
                    string sexe = selectedRow.Cells[7].Value.ToString();
                    foreach (RadioButton radioButton in groupBoxsexe.Controls.OfType<RadioButton>())
                    {
                        if (radioButton.Text == sexe)
                        {
                            radioButton.Checked = true;
                            break;
                        }
                    }

                    datenaiss.Text = selectedRow.Cells[8].Value.ToString();
                    combostatue.Text = selectedRow.Cells[9].Value.ToString();
                    comboposte.Text = selectedRow.Cells[10].Value.ToString();
                    txtSalaire.Text = selectedRow.Cells[11].Value.ToString();
                    datedebut.Text = selectedRow.Cells[12].Value.ToString();
                    datefin.Text = selectedRow.Cells[13].Value.ToString();

                    // Vous pouvez également afficher l'image si vous le souhaitez
                    if (selectedRow.Cells[14].Value != null)
                    {
                        byte[] imageData = (byte[])selectedRow.Cells[14].Value;
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            pictureBox2.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pictureBox2.Image = null;
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
            RemplirePoste();
            RemplireStatue();
            MettreAJourNombrePersonnel();
        }

        private void txtrecherche_TextChanged(object sender, EventArgs e)
        {
            string recherche = txtrecherche.Text.Trim();

            if (string.IsNullOrWhiteSpace(recherche))
            {
                // La zone de texte de recherche est vide, afficher tous les enregistrements
                listerPersonnel();
            }
            else
            {
                RechercherPersonnel(recherche);
            }
        }

        private void RechercherPersonnel(string recherche)
        {
            try
            {
                string Req = "SELECT * FROM TblPersonnel WHERE " +
                      "NomPers LIKE @Recherche OR " +
                      "PrenomPers LIKE @Recherche OR " +
                      "AdressePers LIKE @Recherche OR " +
                      "TelephonePers LIKE @Recherche OR " +
                      "EmailPoste LIKE @Recherche OR " +
                      "CinPers LIKE @Recherche OR " +
                      "SexePers LIKE @Recherche OR " +
                      "DatenaissPers LIKE @Recherche OR " +
                      "StatuePers LIKE @Recherche OR " +
                      "PostePers LIKE @Recherche OR " +
                      "SalairePers LIKE @Recherche OR " +
                      "DatedebutPers LIKE @Recherche OR " +
                      "DatefinPers LIKE @Recherche OR " +
                      "CodePers LIKE @Recherche";

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters["@Recherche"] = "%" + recherche + "%";

                DataTable dataTable = con.RecupererDonnees(Req, parameters);
                tabListe.DataSource = dataTable;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Uc__KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtnom_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnom_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Vérifier que la touche pressée est une lettre ou la touche de contrôle
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquer la saisie
            }
        }

        private void txtprenom_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Vérifier que la touche pressée est une lettre ou la touche de contrôle
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquer la saisie
            }
        }

        private void comboposte_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemplirePoste();
            RemplireStatue();
        }

        private void txtSalaire_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Vérifier si le caractère n'est pas un chiffre et n'est pas une touche de contrôle
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquer la saisie du caractère
            }
        }

        private void txtcompte_Click(object sender, EventArgs e)
        {

        }
        public int nbrPerso()
        {
            string Req = "SELECT COUNT(*) as mombre FROM TblPersonnel";
            DataTable dt = con.RecupererDonnees(Req);

            if (dt.Rows.Count > 0)
            {
                int nombrePersonnel = Convert.ToInt32(dt.Rows[0]["mombre"]);
                return nombrePersonnel;
            }

            return 0;
        }

        public void MettreAJourNombrePersonnel()
        {
            int nombrePersonnel = nbrPerso();
            txtcompte.Text = nombrePersonnel.ToString();
        }

        private void txtprenom_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


