namespace Gestion_personnel
{
    partial class UC_AjoutPoste
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtIdPoste = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.txtNomPoste = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSupP = new System.Windows.Forms.Button();
            this.btnModifierP = new System.Windows.Forms.Button();
            this.btnAjoutP = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dataPoste = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPoste)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 27);
            this.panel1.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(261, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtIdPoste
            // 
            this.txtIdPoste.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdPoste.Location = new System.Drawing.Point(14, 77);
            this.txtIdPoste.Name = "txtIdPoste";
            this.txtIdPoste.Size = new System.Drawing.Size(83, 23);
            this.txtIdPoste.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Eras Medium ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "Identifiant";
            // 
            // lb1
            // 
            this.lb1.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.lb1.AutoSize = true;
            this.lb1.BackColor = System.Drawing.Color.Transparent;
            this.lb1.Font = new System.Drawing.Font("Eras Medium ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1.ForeColor = System.Drawing.Color.Red;
            this.lb1.Location = new System.Drawing.Point(19, 159);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(167, 14);
            this.lb1.TabIndex = 40;
            this.lb1.Text = "ce champ ne doit pas etre vide";
            this.lb1.Visible = false;
            // 
            // txtNomPoste
            // 
            this.txtNomPoste.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomPoste.Location = new System.Drawing.Point(14, 133);
            this.txtNomPoste.Name = "txtNomPoste";
            this.txtNomPoste.Size = new System.Drawing.Size(179, 23);
            this.txtNomPoste.TabIndex = 39;
            this.txtNomPoste.TextChanged += new System.EventHandler(this.txtNomPoste_TextChanged);
            this.txtNomPoste.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNomPoste_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Eras Medium ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 18);
            this.label3.TabIndex = 38;
            this.label3.Text = "Nom du poste a Ajouter";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(14, 199);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(253, 23);
            this.txtDescription.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Eras Medium ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 18);
            this.label4.TabIndex = 41;
            this.label4.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Font = new System.Drawing.Font("Eras Medium ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 19);
            this.label1.TabIndex = 43;
            this.label1.Text = "Ajouter un nouveau Poste";
            // 
            // btnSupP
            // 
            this.btnSupP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.btnSupP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupP.ForeColor = System.Drawing.Color.Black;
            this.btnSupP.Location = new System.Drawing.Point(208, 240);
            this.btnSupP.Name = "btnSupP";
            this.btnSupP.Size = new System.Drawing.Size(75, 23);
            this.btnSupP.TabIndex = 46;
            this.btnSupP.Text = "Supprimer";
            this.btnSupP.UseVisualStyleBackColor = true;
            this.btnSupP.Click += new System.EventHandler(this.btnSupP_Click);
            // 
            // btnModifierP
            // 
            this.btnModifierP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnModifierP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifierP.ForeColor = System.Drawing.Color.Black;
            this.btnModifierP.Location = new System.Drawing.Point(111, 240);
            this.btnModifierP.Name = "btnModifierP";
            this.btnModifierP.Size = new System.Drawing.Size(75, 23);
            this.btnModifierP.TabIndex = 45;
            this.btnModifierP.Text = "Modifier";
            this.btnModifierP.UseVisualStyleBackColor = true;
            this.btnModifierP.Click += new System.EventHandler(this.btnModifierP_Click);
            // 
            // btnAjoutP
            // 
            this.btnAjoutP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnAjoutP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjoutP.ForeColor = System.Drawing.Color.Black;
            this.btnAjoutP.Location = new System.Drawing.Point(11, 240);
            this.btnAjoutP.Name = "btnAjoutP";
            this.btnAjoutP.Size = new System.Drawing.Size(75, 23);
            this.btnAjoutP.TabIndex = 44;
            this.btnAjoutP.Text = "Ajouter";
            this.btnAjoutP.UseVisualStyleBackColor = true;
            this.btnAjoutP.Click += new System.EventHandler(this.btnAjoutP_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label5.Font = new System.Drawing.Font("Eras Medium ITC", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(86, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 48;
            this.label5.Text = "Liste des Postes";
            // 
            // dataPoste
            // 
            this.dataPoste.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.dataPoste.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataPoste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPoste.Location = new System.Drawing.Point(3, 305);
            this.dataPoste.Name = "dataPoste";
            this.dataPoste.Size = new System.Drawing.Size(290, 120);
            this.dataPoste.TabIndex = 47;
            this.dataPoste.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataPoste_CellContentClick);
            // 
            // UC_AjoutPoste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataPoste);
            this.Controls.Add(this.btnSupP);
            this.Controls.Add(this.btnModifierP);
            this.Controls.Add(this.btnAjoutP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.txtNomPoste);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIdPoste);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "UC_AjoutPoste";
            this.Size = new System.Drawing.Size(294, 434);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataPoste)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtIdPoste;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.TextBox txtNomPoste;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSupP;
        private System.Windows.Forms.Button btnModifierP;
        private System.Windows.Forms.Button btnAjoutP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataPoste;
    }
}
