namespace TP3__SamuelDextraze_
{
    partial class frmTP3
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpEntrer = new System.Windows.Forms.GroupBox();
            this.txtLong = new System.Windows.Forms.TextBox();
            this.txtMot = new System.Windows.Forms.TextBox();
            this.txtVoyelle = new System.Windows.Forms.TextBox();
            this.txtConsonne = new System.Windows.Forms.TextBox();
            this.txtMinuscule = new System.Windows.Forms.TextBox();
            this.txtMajuscule = new System.Windows.Forms.TextBox();
            this.txtCaractère = new System.Windows.Forms.TextBox();
            this.btnEfface = new System.Windows.Forms.Button();
            this.btnMàj = new System.Windows.Forms.Button();
            this.lblLong = new System.Windows.Forms.Label();
            this.lblMot = new System.Windows.Forms.Label();
            this.lblVoyelle = new System.Windows.Forms.Label();
            this.lblConsonne = new System.Windows.Forms.Label();
            this.lblMinuscule = new System.Windows.Forms.Label();
            this.lblMajuscule = new System.Windows.Forms.Label();
            this.lblCaractère = new System.Windows.Forms.Label();
            this.lblStatistique = new System.Windows.Forms.Label();
            this.txtTexte = new System.Windows.Forms.TextBox();
            this.grpSortie = new System.Windows.Forms.GroupBox();
            this.txtMasque2 = new System.Windows.Forms.TextBox();
            this.lblMasque = new System.Windows.Forms.Label();
            this.txtMasque1 = new System.Windows.Forms.TextBox();
            this.lblRemplace = new System.Windows.Forms.Label();
            this.txtRemplace2 = new System.Windows.Forms.TextBox();
            this.txtRemplace1 = new System.Windows.Forms.TextBox();
            this.cmbInverse = new System.Windows.Forms.ComboBox();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.optMasque = new System.Windows.Forms.RadioButton();
            this.optRemplace = new System.Windows.Forms.RadioButton();
            this.optPalindromes = new System.Windows.Forms.RadioButton();
            this.optRecherche = new System.Windows.Forms.RadioButton();
            this.optInverse = new System.Windows.Forms.RadioButton();
            this.btnAction = new System.Windows.Forms.Button();
            this.optEspace = new System.Windows.Forms.RadioButton();
            this.txtSortie = new System.Windows.Forms.TextBox();
            this.grpEntrer.SuspendLayout();
            this.grpSortie.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpEntrer
            // 
            this.grpEntrer.Controls.Add(this.txtLong);
            this.grpEntrer.Controls.Add(this.txtMot);
            this.grpEntrer.Controls.Add(this.txtVoyelle);
            this.grpEntrer.Controls.Add(this.txtConsonne);
            this.grpEntrer.Controls.Add(this.txtMinuscule);
            this.grpEntrer.Controls.Add(this.txtMajuscule);
            this.grpEntrer.Controls.Add(this.txtCaractère);
            this.grpEntrer.Controls.Add(this.btnEfface);
            this.grpEntrer.Controls.Add(this.btnMàj);
            this.grpEntrer.Controls.Add(this.lblLong);
            this.grpEntrer.Controls.Add(this.lblMot);
            this.grpEntrer.Controls.Add(this.lblVoyelle);
            this.grpEntrer.Controls.Add(this.lblConsonne);
            this.grpEntrer.Controls.Add(this.lblMinuscule);
            this.grpEntrer.Controls.Add(this.lblMajuscule);
            this.grpEntrer.Controls.Add(this.lblCaractère);
            this.grpEntrer.Controls.Add(this.lblStatistique);
            this.grpEntrer.Controls.Add(this.txtTexte);
            this.grpEntrer.Location = new System.Drawing.Point(12, 12);
            this.grpEntrer.Name = "grpEntrer";
            this.grpEntrer.Size = new System.Drawing.Size(374, 543);
            this.grpEntrer.TabIndex = 0;
            this.grpEntrer.TabStop = false;
            this.grpEntrer.Text = "Entrez/Copiez votre texte ici:";
            // 
            // txtLong
            // 
            this.txtLong.Location = new System.Drawing.Point(158, 443);
            this.txtLong.Name = "txtLong";
            this.txtLong.ReadOnly = true;
            this.txtLong.Size = new System.Drawing.Size(210, 20);
            this.txtLong.TabIndex = 16;
            this.txtLong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMot
            // 
            this.txtMot.Location = new System.Drawing.Point(158, 416);
            this.txtMot.Name = "txtMot";
            this.txtMot.ReadOnly = true;
            this.txtMot.Size = new System.Drawing.Size(210, 20);
            this.txtMot.TabIndex = 15;
            this.txtMot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtVoyelle
            // 
            this.txtVoyelle.Location = new System.Drawing.Point(158, 388);
            this.txtVoyelle.Name = "txtVoyelle";
            this.txtVoyelle.ReadOnly = true;
            this.txtVoyelle.Size = new System.Drawing.Size(210, 20);
            this.txtVoyelle.TabIndex = 14;
            this.txtVoyelle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtConsonne
            // 
            this.txtConsonne.Location = new System.Drawing.Point(158, 362);
            this.txtConsonne.Name = "txtConsonne";
            this.txtConsonne.ReadOnly = true;
            this.txtConsonne.Size = new System.Drawing.Size(210, 20);
            this.txtConsonne.TabIndex = 13;
            this.txtConsonne.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMinuscule
            // 
            this.txtMinuscule.Location = new System.Drawing.Point(158, 336);
            this.txtMinuscule.Name = "txtMinuscule";
            this.txtMinuscule.ReadOnly = true;
            this.txtMinuscule.Size = new System.Drawing.Size(210, 20);
            this.txtMinuscule.TabIndex = 12;
            this.txtMinuscule.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMajuscule
            // 
            this.txtMajuscule.Location = new System.Drawing.Point(158, 308);
            this.txtMajuscule.Name = "txtMajuscule";
            this.txtMajuscule.ReadOnly = true;
            this.txtMajuscule.Size = new System.Drawing.Size(210, 20);
            this.txtMajuscule.TabIndex = 11;
            this.txtMajuscule.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCaractère
            // 
            this.txtCaractère.Location = new System.Drawing.Point(158, 281);
            this.txtCaractère.Name = "txtCaractère";
            this.txtCaractère.ReadOnly = true;
            this.txtCaractère.Size = new System.Drawing.Size(210, 20);
            this.txtCaractère.TabIndex = 10;
            this.txtCaractère.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnEfface
            // 
            this.btnEfface.Location = new System.Drawing.Point(9, 505);
            this.btnEfface.Name = "btnEfface";
            this.btnEfface.Size = new System.Drawing.Size(359, 23);
            this.btnEfface.TabIndex = 0;
            this.btnEfface.Text = "&Effacer les textes";
            this.btnEfface.UseVisualStyleBackColor = true;
            this.btnEfface.Click += new System.EventHandler(this.EffText_Click);
            // 
            // btnMàj
            // 
            this.btnMàj.Location = new System.Drawing.Point(9, 478);
            this.btnMàj.Name = "btnMàj";
            this.btnMàj.Size = new System.Drawing.Size(359, 23);
            this.btnMàj.TabIndex = 9;
            this.btnMàj.Text = "&Mettre à jour";
            this.btnMàj.UseVisualStyleBackColor = true;
            this.btnMàj.Click += new System.EventHandler(this.btnMàj_Click);
            // 
            // lblLong
            // 
            this.lblLong.AutoSize = true;
            this.lblLong.Location = new System.Drawing.Point(6, 450);
            this.lblLong.Name = "lblLong";
            this.lblLong.Size = new System.Drawing.Size(103, 13);
            this.lblLong.TabIndex = 8;
            this.lblLong.Text = "Le mots le plus long:";
            // 
            // lblMot
            // 
            this.lblMot.AutoSize = true;
            this.lblMot.Location = new System.Drawing.Point(6, 423);
            this.lblMot.Name = "lblMot";
            this.lblMot.Size = new System.Drawing.Size(87, 13);
            this.lblMot.TabIndex = 7;
            this.lblMot.Text = "Nombre de mots:";
            // 
            // lblVoyelle
            // 
            this.lblVoyelle.AutoSize = true;
            this.lblVoyelle.Location = new System.Drawing.Point(6, 395);
            this.lblVoyelle.Name = "lblVoyelle";
            this.lblVoyelle.Size = new System.Drawing.Size(103, 13);
            this.lblVoyelle.TabIndex = 6;
            this.lblVoyelle.Text = "Nombre de voyelles:";
            // 
            // lblConsonne
            // 
            this.lblConsonne.AutoSize = true;
            this.lblConsonne.Location = new System.Drawing.Point(6, 368);
            this.lblConsonne.Name = "lblConsonne";
            this.lblConsonne.Size = new System.Drawing.Size(117, 13);
            this.lblConsonne.TabIndex = 5;
            this.lblConsonne.Text = "Nombre de consonnes:";
            // 
            // lblMinuscule
            // 
            this.lblMinuscule.AutoSize = true;
            this.lblMinuscule.Location = new System.Drawing.Point(6, 341);
            this.lblMinuscule.Name = "lblMinuscule";
            this.lblMinuscule.Size = new System.Drawing.Size(117, 13);
            this.lblMinuscule.TabIndex = 4;
            this.lblMinuscule.Text = "Nombre de minuscules:";
            // 
            // lblMajuscule
            // 
            this.lblMajuscule.AutoSize = true;
            this.lblMajuscule.Location = new System.Drawing.Point(6, 315);
            this.lblMajuscule.Name = "lblMajuscule";
            this.lblMajuscule.Size = new System.Drawing.Size(117, 13);
            this.lblMajuscule.TabIndex = 3;
            this.lblMajuscule.Text = "Nombre de majuscules:";
            // 
            // lblCaractère
            // 
            this.lblCaractère.AutoSize = true;
            this.lblCaractère.Location = new System.Drawing.Point(6, 288);
            this.lblCaractère.Name = "lblCaractère";
            this.lblCaractère.Size = new System.Drawing.Size(115, 13);
            this.lblCaractère.TabIndex = 2;
            this.lblCaractère.Text = "Nombre de caractères:";
            // 
            // lblStatistique
            // 
            this.lblStatistique.AutoSize = true;
            this.lblStatistique.Location = new System.Drawing.Point(6, 264);
            this.lblStatistique.Name = "lblStatistique";
            this.lblStatistique.Size = new System.Drawing.Size(59, 13);
            this.lblStatistique.TabIndex = 1;
            this.lblStatistique.Text = "Statistique:";
            // 
            // txtTexte
            // 
            this.txtTexte.Location = new System.Drawing.Point(3, 16);
            this.txtTexte.Multiline = true;
            this.txtTexte.Name = "txtTexte";
            this.txtTexte.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTexte.Size = new System.Drawing.Size(365, 245);
            this.txtTexte.TabIndex = 0;
            // 
            // grpSortie
            // 
            this.grpSortie.Controls.Add(this.txtMasque2);
            this.grpSortie.Controls.Add(this.lblMasque);
            this.grpSortie.Controls.Add(this.txtMasque1);
            this.grpSortie.Controls.Add(this.lblRemplace);
            this.grpSortie.Controls.Add(this.txtRemplace2);
            this.grpSortie.Controls.Add(this.txtRemplace1);
            this.grpSortie.Controls.Add(this.cmbInverse);
            this.grpSortie.Controls.Add(this.txtRecherche);
            this.grpSortie.Controls.Add(this.optMasque);
            this.grpSortie.Controls.Add(this.optRemplace);
            this.grpSortie.Controls.Add(this.optPalindromes);
            this.grpSortie.Controls.Add(this.optRecherche);
            this.grpSortie.Controls.Add(this.optInverse);
            this.grpSortie.Controls.Add(this.btnAction);
            this.grpSortie.Controls.Add(this.optEspace);
            this.grpSortie.Controls.Add(this.txtSortie);
            this.grpSortie.Location = new System.Drawing.Point(392, 12);
            this.grpSortie.Name = "grpSortie";
            this.grpSortie.Size = new System.Drawing.Size(355, 543);
            this.grpSortie.TabIndex = 1;
            this.grpSortie.TabStop = false;
            this.grpSortie.Text = "Résultat des actions sur le texte:";
            // 
            // txtMasque2
            // 
            this.txtMasque2.Enabled = false;
            this.txtMasque2.Location = new System.Drawing.Point(275, 413);
            this.txtMasque2.Name = "txtMasque2";
            this.txtMasque2.Size = new System.Drawing.Size(56, 20);
            this.txtMasque2.TabIndex = 31;
            // 
            // lblMasque
            // 
            this.lblMasque.AutoSize = true;
            this.lblMasque.Location = new System.Drawing.Point(219, 420);
            this.lblMasque.Name = "lblMasque";
            this.lblMasque.Size = new System.Drawing.Size(22, 13);
            this.lblMasque.TabIndex = 30;
            this.lblMasque.Text = "par";
            // 
            // txtMasque1
            // 
            this.txtMasque1.Enabled = false;
            this.txtMasque1.Location = new System.Drawing.Point(123, 413);
            this.txtMasque1.Name = "txtMasque1";
            this.txtMasque1.Size = new System.Drawing.Size(75, 20);
            this.txtMasque1.TabIndex = 29;
            // 
            // lblRemplace
            // 
            this.lblRemplace.AutoSize = true;
            this.lblRemplace.Location = new System.Drawing.Point(219, 392);
            this.lblRemplace.Name = "lblRemplace";
            this.lblRemplace.Size = new System.Drawing.Size(22, 13);
            this.lblRemplace.TabIndex = 17;
            this.lblRemplace.Text = "par";
            // 
            // txtRemplace2
            // 
            this.txtRemplace2.Enabled = false;
            this.txtRemplace2.Location = new System.Drawing.Point(275, 385);
            this.txtRemplace2.Name = "txtRemplace2";
            this.txtRemplace2.Size = new System.Drawing.Size(74, 20);
            this.txtRemplace2.TabIndex = 28;
            // 
            // txtRemplace1
            // 
            this.txtRemplace1.Enabled = false;
            this.txtRemplace1.Location = new System.Drawing.Point(123, 385);
            this.txtRemplace1.Name = "txtRemplace1";
            this.txtRemplace1.Size = new System.Drawing.Size(75, 20);
            this.txtRemplace1.TabIndex = 27;
            // 
            // cmbInverse
            // 
            this.cmbInverse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInverse.Enabled = false;
            this.cmbInverse.Items.AddRange(new object[] {
            "La casse",
            "Le texte"});
            this.cmbInverse.Location = new System.Drawing.Point(198, 304);
            this.cmbInverse.Name = "cmbInverse";
            this.cmbInverse.Size = new System.Drawing.Size(151, 21);
            this.cmbInverse.TabIndex = 26;
            // 
            // txtRecherche
            // 
            this.txtRecherche.Enabled = false;
            this.txtRecherche.Location = new System.Drawing.Point(198, 333);
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(151, 20);
            this.txtRecherche.TabIndex = 25;
            // 
            // optMasque
            // 
            this.optMasque.AutoSize = true;
            this.optMasque.Location = new System.Drawing.Point(6, 416);
            this.optMasque.Name = "optMasque";
            this.optMasque.Size = new System.Drawing.Size(103, 17);
            this.optMasque.TabIndex = 24;
            this.optMasque.Text = "Masquer les car.";
            this.optMasque.UseVisualStyleBackColor = true;
            this.optMasque.CheckedChanged += new System.EventHandler(this.optMasque_Check);
            // 
            // optRemplace
            // 
            this.optRemplace.AutoSize = true;
            this.optRemplace.Location = new System.Drawing.Point(6, 388);
            this.optRemplace.Name = "optRemplace";
            this.optRemplace.Size = new System.Drawing.Size(76, 17);
            this.optRemplace.TabIndex = 23;
            this.optRemplace.Text = "Remplacer";
            this.optRemplace.UseVisualStyleBackColor = true;
            this.optRemplace.CheckedChanged += new System.EventHandler(this.optRemplace_Check);
            // 
            // optPalindromes
            // 
            this.optPalindromes.AutoSize = true;
            this.optPalindromes.Location = new System.Drawing.Point(6, 362);
            this.optPalindromes.Name = "optPalindromes";
            this.optPalindromes.Size = new System.Drawing.Size(137, 17);
            this.optPalindromes.TabIndex = 22;
            this.optPalindromes.Text = "Trouver les palindromes";
            this.optPalindromes.UseVisualStyleBackColor = true;
            // 
            // optRecherche
            // 
            this.optRecherche.AutoSize = true;
            this.optRecherche.Location = new System.Drawing.Point(6, 336);
            this.optRecherche.Name = "optRecherche";
            this.optRecherche.Size = new System.Drawing.Size(81, 17);
            this.optRecherche.TabIndex = 21;
            this.optRecherche.Text = "Rechercher";
            this.optRecherche.UseVisualStyleBackColor = true;
            this.optRecherche.CheckedChanged += new System.EventHandler(this.optRecherche_Check);
            // 
            // optInverse
            // 
            this.optInverse.AutoSize = true;
            this.optInverse.Location = new System.Drawing.Point(6, 308);
            this.optInverse.Name = "optInverse";
            this.optInverse.Size = new System.Drawing.Size(63, 17);
            this.optInverse.TabIndex = 20;
            this.optInverse.Text = "Inverser";
            this.optInverse.UseVisualStyleBackColor = true;
            this.optInverse.CheckedChanged += new System.EventHandler(this.optInverse_Check);
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(6, 478);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(343, 50);
            this.btnAction.TabIndex = 19;
            this.btnAction.Text = "Exécuter action";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.ExeAction_Click);
            // 
            // optEspace
            // 
            this.optEspace.AutoSize = true;
            this.optEspace.Checked = true;
            this.optEspace.Location = new System.Drawing.Point(6, 281);
            this.optEspace.Name = "optEspace";
            this.optEspace.Size = new System.Drawing.Size(138, 17);
            this.optEspace.TabIndex = 18;
            this.optEspace.TabStop = true;
            this.optEspace.Text = "Retirer tous les espaces";
            this.optEspace.UseVisualStyleBackColor = true;
            // 
            // txtSortie
            // 
            this.txtSortie.Location = new System.Drawing.Point(6, 19);
            this.txtSortie.Multiline = true;
            this.txtSortie.Name = "txtSortie";
            this.txtSortie.ReadOnly = true;
            this.txtSortie.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSortie.Size = new System.Drawing.Size(343, 242);
            this.txtSortie.TabIndex = 17;
            // 
            // frmTP3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 567);
            this.Controls.Add(this.grpSortie);
            this.Controls.Add(this.grpEntrer);
            this.Name = "frmTP3";
            this.Text = "Form1";
            this.grpEntrer.ResumeLayout(false);
            this.grpEntrer.PerformLayout();
            this.grpSortie.ResumeLayout(false);
            this.grpSortie.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpEntrer;
        private System.Windows.Forms.Label lblCaractère;
        private System.Windows.Forms.Label lblStatistique;
        private System.Windows.Forms.TextBox txtTexte;
        private System.Windows.Forms.GroupBox grpSortie;
        private System.Windows.Forms.TextBox txtLong;
        private System.Windows.Forms.TextBox txtMot;
        private System.Windows.Forms.TextBox txtVoyelle;
        private System.Windows.Forms.TextBox txtConsonne;
        private System.Windows.Forms.TextBox txtMinuscule;
        private System.Windows.Forms.TextBox txtMajuscule;
        private System.Windows.Forms.TextBox txtCaractère;
        private System.Windows.Forms.Button btnEfface;
        private System.Windows.Forms.Button btnMàj;
        private System.Windows.Forms.Label lblLong;
        private System.Windows.Forms.Label lblMot;
        private System.Windows.Forms.Label lblVoyelle;
        private System.Windows.Forms.Label lblConsonne;
        private System.Windows.Forms.Label lblMinuscule;
        private System.Windows.Forms.Label lblMajuscule;
        private System.Windows.Forms.TextBox txtSortie;
        private System.Windows.Forms.RadioButton optMasque;
        private System.Windows.Forms.RadioButton optRemplace;
        private System.Windows.Forms.RadioButton optPalindromes;
        private System.Windows.Forms.RadioButton optRecherche;
        private System.Windows.Forms.RadioButton optInverse;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.RadioButton optEspace;
        private System.Windows.Forms.TextBox txtMasque2;
        private System.Windows.Forms.Label lblMasque;
        private System.Windows.Forms.TextBox txtMasque1;
        private System.Windows.Forms.Label lblRemplace;
        private System.Windows.Forms.TextBox txtRemplace2;
        private System.Windows.Forms.TextBox txtRemplace1;
        private System.Windows.Forms.ComboBox cmbInverse;
        private System.Windows.Forms.TextBox txtRecherche;
    }
}

