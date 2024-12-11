namespace Gestion_personnel
{
    partial class UC_AjoutStatue
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
            this.label5 = new System.Windows.Forms.Label();
            this.dataStatue = new System.Windows.Forms.DataGridView();
            this.btnSupP = new System.Windows.Forms.Button();
            this.btnModifierP = new System.Windows.Forms.Button();
            this.btnAjoutP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.txtNomStatue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataStatue)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 27);
            this.panel1.TabIndex = 49;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label5.Font = new System.Drawing.Font("Eras Medium ITC", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(86, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 15);
            this.label5.TabIndex = 62;
            this.label5.Text = "Liste des Statues";
            // 
            // dataStatue
            // 
            this.dataStatue.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataStatue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataStatue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataStatue.Location = new System.Drawing.Point(3, 310);
            this.dataStatue.Name = "dataStatue";
            this.dataStatue.Size = new System.Drawing.Size(290, 120);
            this.dataStatue.TabIndex = 61;
            this.dataStatue.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataStatue_CellContentClick);
            // 
            // btnSupP
            // 
            this.btnSupP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.btnSupP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupP.ForeColor = System.Drawing.Color.Black;
            this.btnSupP.Location = new System.Drawing.Point(208, 245);
            this.btnSupP.Name = "btnSupP";
            this.btnSupP.Size = new System.Drawing.Size(75, 23);
            this.btnSupP.TabIndex = 60;
            this.btnSupP.Text = "Supprimer";
            this.btnSupP.UseVisualStyleBackColor = true;
            this.btnSupP.Click += new System.EventHandler(this.btnSupP_Click);
            // 
            // btnModifierP
            // 
            this.btnModifierP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnModifierP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifierP.ForeColor = System.Drawing.Color.Black;
            this.btnModifierP.Location = new System.Drawing.Point(111, 245);
            this.btnModifierP.Name = "btnModifierP";
            this.btnModifierP.Size = new System.Drawing.Size(75, 23);
            this.btnModifierP.TabIndex = 59;
            this.btnModifierP.Text = "Modifier";
            this.btnModifierP.UseVisualStyleBackColor = true;
            this.btnModifierP.Click += new System.EventHandler(this.btnModifierP_Click);
            // 
            // btnAjoutP
            // 
            this.btnAjoutP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnAjoutP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjoutP.ForeColor = System.Drawing.Color.Black;
            this.btnAjoutP.Location = new System.Drawing.Point(11, 245);
            this.btnAjoutP.Name = "btnAjoutP";
            this.btnAjoutP.Size = new System.Drawing.Size(75, 23);
            this.btnAjoutP.TabIndex = 58;
            this.btnAjoutP.Text = "Ajouter";
            this.btnAjoutP.UseVisualStyleBackColor = true;
            this.btnAjoutP.Click += new System.EventHandler(this.btnAjoutP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Font = new System.Drawing.Font("Eras Medium ITC", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 21);
            this.label1.TabIndex = 57;
            this.label1.Text = "Statue des employées";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(8, 165);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(253, 67);
            this.txtDescription.TabIndex = 56;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Eras Medium ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 18);
            this.label4.TabIndex = 55;
            this.label4.Text = "Description";
            // 
            // lb1
            // 
            this.lb1.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.lb1.AutoSize = true;
            this.lb1.BackColor = System.Drawing.Color.Transparent;
            this.lb1.Font = new System.Drawing.Font("Eras Medium ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1.ForeColor = System.Drawing.Color.Red;
            this.lb1.Location = new System.Drawing.Point(19, 117);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(167, 14);
            this.lb1.TabIndex = 54;
            this.lb1.Text = "ce champ ne doit pas etre vide";
            this.lb1.Visible = false;
            // 
            // txtNomStatue
            // 
            this.txtNomStatue.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomStatue.Location = new System.Drawing.Point(14, 91);
            this.txtNomStatue.Name = "txtNomStatue";
            this.txtNomStatue.Size = new System.Drawing.Size(179, 23);
            this.txtNomStatue.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Eras Medium ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 18);
            this.label3.TabIndex = 52;
            this.label3.Text = "Nom du Statue ";
            // 
            // UC_AjoutStatue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataStatue);
            this.Controls.Add(this.btnSupP);
            this.Controls.Add(this.btnModifierP);
            this.Controls.Add(this.btnAjoutP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.txtNomStatue);
            this.Controls.Add(this.label3);
            this.Name = "UC_AjoutStatue";
            this.Size = new System.Drawing.Size(294, 434);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataStatue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataStatue;
        private System.Windows.Forms.Button btnSupP;
        private System.Windows.Forms.Button btnModifierP;
        private System.Windows.Forms.Button btnAjoutP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.TextBox txtNomStatue;
        private System.Windows.Forms.Label label3;
    }
}
