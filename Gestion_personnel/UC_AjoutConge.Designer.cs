namespace Gestion_personnel
{
    partial class UC_AjoutConge
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
            this.label4 = new System.Windows.Forms.Label();
            this.dataConge = new System.Windows.Forms.DataGridView();
            this.btnSupC = new System.Windows.Forms.Button();
            this.btnModifierC = new System.Windows.Forms.Button();
            this.btnAjoutC = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAjConge = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdConge = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataConge)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 27);
            this.panel1.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(259, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label4.Font = new System.Drawing.Font("Eras Medium ITC", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(90, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "Liste des congées";
            // 
            // dataConge
            // 
            this.dataConge.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataConge.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataConge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataConge.Location = new System.Drawing.Point(12, 283);
            this.dataConge.Name = "dataConge";
            this.dataConge.Size = new System.Drawing.Size(272, 131);
            this.dataConge.TabIndex = 23;
            this.dataConge.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataConge_CellContentClick);
            // 
            // btnSupC
            // 
            this.btnSupC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.btnSupC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupC.ForeColor = System.Drawing.Color.Black;
            this.btnSupC.Location = new System.Drawing.Point(209, 215);
            this.btnSupC.Name = "btnSupC";
            this.btnSupC.Size = new System.Drawing.Size(75, 23);
            this.btnSupC.TabIndex = 22;
            this.btnSupC.Text = "Supprimer";
            this.btnSupC.UseVisualStyleBackColor = true;
            this.btnSupC.Click += new System.EventHandler(this.btnSupC_Click);
            // 
            // btnModifierC
            // 
            this.btnModifierC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnModifierC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifierC.ForeColor = System.Drawing.Color.Black;
            this.btnModifierC.Location = new System.Drawing.Point(112, 215);
            this.btnModifierC.Name = "btnModifierC";
            this.btnModifierC.Size = new System.Drawing.Size(75, 23);
            this.btnModifierC.TabIndex = 21;
            this.btnModifierC.Text = "Modifier";
            this.btnModifierC.UseVisualStyleBackColor = true;
            this.btnModifierC.Click += new System.EventHandler(this.btnModifierC_Click);
            // 
            // btnAjoutC
            // 
            this.btnAjoutC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnAjoutC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjoutC.ForeColor = System.Drawing.Color.Black;
            this.btnAjoutC.Location = new System.Drawing.Point(12, 215);
            this.btnAjoutC.Name = "btnAjoutC";
            this.btnAjoutC.Size = new System.Drawing.Size(75, 23);
            this.btnAjoutC.TabIndex = 20;
            this.btnAjoutC.Text = "Ajouter";
            this.btnAjoutC.UseVisualStyleBackColor = true;
            this.btnAjoutC.Click += new System.EventHandler(this.btnAjoutC_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label3.Font = new System.Drawing.Font("Eras Medium ITC", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 21);
            this.label3.TabIndex = 19;
            this.label3.Text = "Ajouter un motif de congé";
            // 
            // txtAjConge
            // 
            this.txtAjConge.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAjConge.Location = new System.Drawing.Point(33, 148);
            this.txtAjConge.Name = "txtAjConge";
            this.txtAjConge.Size = new System.Drawing.Size(154, 23);
            this.txtAjConge.TabIndex = 18;
            this.txtAjConge.TextChanged += new System.EventHandler(this.txtAjConge_TextChanged);
            this.txtAjConge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAjConge_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Eras Medium ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Motif du Conge";
            // 
            // txtIdConge
            // 
            this.txtIdConge.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdConge.Location = new System.Drawing.Point(33, 90);
            this.txtIdConge.Name = "txtIdConge";
            this.txtIdConge.Size = new System.Drawing.Size(113, 23);
            this.txtIdConge.TabIndex = 16;
            this.txtIdConge.TextChanged += new System.EventHandler(this.txtIdConge_TextChanged);
            this.txtIdConge.MouseLeave += new System.EventHandler(this.txtIdConge_MouseLeave);
            this.txtIdConge.MouseHover += new System.EventHandler(this.txtIdConge_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Eras Medium ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Identifiant";
            // 
            // lb1
            // 
            this.lb1.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.lb1.AutoSize = true;
            this.lb1.BackColor = System.Drawing.Color.Transparent;
            this.lb1.Font = new System.Drawing.Font("Eras Medium ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1.ForeColor = System.Drawing.Color.Red;
            this.lb1.Location = new System.Drawing.Point(37, 175);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(167, 14);
            this.lb1.TabIndex = 38;
            this.lb1.Text = "ce champ ne doit pas etre vide";
            this.lb1.Visible = false;
            // 
            // label5
            // 
            this.label5.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Eras Medium ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(158, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 19);
            this.label5.TabIndex = 39;
            this.label5.Text = "Automatique";
            this.label5.Visible = false;
            // 
            // UC_AjoutConge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataConge);
            this.Controls.Add(this.btnSupC);
            this.Controls.Add(this.btnModifierC);
            this.Controls.Add(this.btnAjoutC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAjConge);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIdConge);
            this.Controls.Add(this.label2);
            this.Name = "UC_AjoutConge";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(294, 418);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataConge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataConge;
        private System.Windows.Forms.Button btnSupC;
        private System.Windows.Forms.Button btnModifierC;
        private System.Windows.Forms.Button btnAjoutC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAjConge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdConge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Label label5;
    }
}
