namespace TP5_Sudoku
{
    partial class frmGrilleSudoku
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrilleSudoku));
            this.vaGrilleSudoku = new VisualArrays.VisualIntArray();
            this.vaChoixNumero = new VisualArrays.VisualIntArray();
            this.imgLstBouton = new System.Windows.Forms.ImageList(this.components);
            this.lblTemps = new System.Windows.Forms.Label();
            this.lblEtiquetteTemps = new System.Windows.Forms.Label();
            this.btnValider = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.btnMeilleursResultats = new System.Windows.Forms.Button();
            this.btnNouvellePartie = new System.Windows.Forms.Button();
            this.gbNouvellePartie = new System.Windows.Forms.GroupBox();
            this.cboNiveau = new System.Windows.Forms.ComboBox();
            this.tmrTemps = new System.Windows.Forms.Timer(this.components);
            this.gbNouvellePartie.SuspendLayout();
            this.SuspendLayout();
            // 
            // vaGrilleSudoku
            // 
            this.vaGrilleSudoku.BackColor = System.Drawing.Color.Transparent;
            this.vaGrilleSudoku.BackgroundImage = global::TP5_Sudoku.Properties.Resources.FondGrille1;
            this.vaGrilleSudoku.CellAppearance.BackgroundColor = System.Drawing.Color.Transparent;
            this.vaGrilleSudoku.CellAppearance.Border = new System.Windows.Forms.Padding(20);
            this.vaGrilleSudoku.CellAppearance.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Bold);
            this.vaGrilleSudoku.CellAppearance.TextColor = System.Drawing.Color.Black;
            this.vaGrilleSudoku.CellSize = new System.Drawing.Size(55, 54);
            this.vaGrilleSudoku.ColumnCount = 9;
            this.vaGrilleSudoku.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vaGrilleSudoku.GridAppearance.Color = System.Drawing.Color.Transparent;
            this.vaGrilleSudoku.Location = new System.Drawing.Point(12, 12);
            this.vaGrilleSudoku.Name = "vaGrilleSudoku";
            this.vaGrilleSudoku.RowCount = 9;
            this.vaGrilleSudoku.RowHeader.ForeColor = System.Drawing.Color.White;
            this.vaGrilleSudoku.Size = new System.Drawing.Size(545, 536);
            this.vaGrilleSudoku.SpecialValueAppearance.Font = new System.Drawing.Font("Arial", 25F);
            this.vaGrilleSudoku.TabIndex = 2;
            this.vaGrilleSudoku.CellMouseClick += new System.EventHandler<VisualArrays.CellMouseEventArgs>(this.vaGrilleSudoku_CellMouseClick);
            // 
            // vaChoixNumero
            // 
            this.vaChoixNumero.BackColor = System.Drawing.Color.Transparent;
            this.vaChoixNumero.CellAppearance.BackgroundColor = System.Drawing.Color.Transparent;
            this.vaChoixNumero.CellAppearance.Font = new System.Drawing.Font("Arial", 33F, System.Drawing.FontStyle.Bold);
            this.vaChoixNumero.CellAppearance.Image = global::TP5_Sudoku.Properties.Resources.ButtonUnchecked;
            this.vaChoixNumero.CellAppearance.ImageList = this.imgLstBouton;
            this.vaChoixNumero.CellSize = new System.Drawing.Size(90, 90);
            this.vaChoixNumero.Location = new System.Drawing.Point(580, 12);
            this.vaChoixNumero.Name = "vaChoixNumero";
            this.vaChoixNumero.RowHeader.ForeColor = System.Drawing.Color.White;
            this.vaChoixNumero.Size = new System.Drawing.Size(290, 290);
            this.vaChoixNumero.SpecialValue = 0;
            this.vaChoixNumero.SpecialValueAppearance.Image = global::TP5_Sudoku.Properties.Resources.ButtonChecked;
            this.vaChoixNumero.TabIndex = 3;
            this.vaChoixNumero.View = VisualArrays.enuIntView.ImageList;
            this.vaChoixNumero.CellMouseClick += new System.EventHandler<VisualArrays.CellMouseEventArgs>(this.vaChoixNumero_CellMouseClick);
            this.vaChoixNumero.CellMouseEnter += new System.EventHandler<VisualArrays.CellEventArgs>(this.vaChoixNumero_CellMouseEnter);
            this.vaChoixNumero.CellMouseLeave += new System.EventHandler<VisualArrays.CellEventArgs>(this.vaChoixNumero_CellMouseLeave);
            // 
            // imgLstBouton
            // 
            this.imgLstBouton.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstBouton.ImageStream")));
            this.imgLstBouton.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLstBouton.Images.SetKeyName(0, "ButtonUnchecked.png");
            this.imgLstBouton.Images.SetKeyName(1, "ButtonUnchecked1.png");
            this.imgLstBouton.Images.SetKeyName(2, "ButtonUnchecked2.png");
            this.imgLstBouton.Images.SetKeyName(3, "ButtonUnchecked3.png");
            this.imgLstBouton.Images.SetKeyName(4, "ButtonUnchecked4.png");
            this.imgLstBouton.Images.SetKeyName(5, "ButtonUnchecked5.png");
            this.imgLstBouton.Images.SetKeyName(6, "ButtonUnchecked6.png");
            this.imgLstBouton.Images.SetKeyName(7, "ButtonUnchecked7.png");
            this.imgLstBouton.Images.SetKeyName(8, "ButtonUnchecked8.png");
            this.imgLstBouton.Images.SetKeyName(9, "ButtonUnchecked9.png");
            this.imgLstBouton.Images.SetKeyName(10, "ButtonHighlighted1.png");
            this.imgLstBouton.Images.SetKeyName(11, "ButtonHighlighted2.png");
            this.imgLstBouton.Images.SetKeyName(12, "ButtonHighlighted3.png");
            this.imgLstBouton.Images.SetKeyName(13, "ButtonHighlighted4.png");
            this.imgLstBouton.Images.SetKeyName(14, "ButtonHighlighted5.png");
            this.imgLstBouton.Images.SetKeyName(15, "ButtonHighlighted6.png");
            this.imgLstBouton.Images.SetKeyName(16, "ButtonHighlighted7.png");
            this.imgLstBouton.Images.SetKeyName(17, "ButtonHighlighted8.png");
            this.imgLstBouton.Images.SetKeyName(18, "ButtonHighlighted9.png");
            this.imgLstBouton.Images.SetKeyName(19, "ButtonChecked1.png");
            this.imgLstBouton.Images.SetKeyName(20, "ButtonChecked2.png");
            this.imgLstBouton.Images.SetKeyName(21, "ButtonChecked3.png");
            this.imgLstBouton.Images.SetKeyName(22, "ButtonChecked4.png");
            this.imgLstBouton.Images.SetKeyName(23, "ButtonChecked5.png");
            this.imgLstBouton.Images.SetKeyName(24, "ButtonChecked6.png");
            this.imgLstBouton.Images.SetKeyName(25, "ButtonChecked7.png");
            this.imgLstBouton.Images.SetKeyName(26, "ButtonChecked8.png");
            this.imgLstBouton.Images.SetKeyName(27, "ButtonChecked9.png");
            // 
            // lblTemps
            // 
            this.lblTemps.AutoSize = true;
            this.lblTemps.BackColor = System.Drawing.Color.Transparent;
            this.lblTemps.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemps.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTemps.Location = new System.Drawing.Point(756, 332);
            this.lblTemps.Name = "lblTemps";
            this.lblTemps.Size = new System.Drawing.Size(124, 46);
            this.lblTemps.TabIndex = 4;
            this.lblTemps.Text = "00:00";
            // 
            // lblEtiquetteTemps
            // 
            this.lblEtiquetteTemps.AutoSize = true;
            this.lblEtiquetteTemps.BackColor = System.Drawing.Color.Transparent;
            this.lblEtiquetteTemps.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtiquetteTemps.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEtiquetteTemps.Location = new System.Drawing.Point(588, 332);
            this.lblEtiquetteTemps.Name = "lblEtiquetteTemps";
            this.lblEtiquetteTemps.Size = new System.Drawing.Size(170, 46);
            this.lblEtiquetteTemps.TabIndex = 5;
            this.lblEtiquetteTemps.Text = "Temps :";
            // 
            // btnValider
            // 
            this.btnValider.Enabled = false;
            this.btnValider.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnValider.Location = new System.Drawing.Point(572, 512);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(95, 36);
            this.btnValider.TabIndex = 7;
            this.btnValider.Text = "&Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnQuitter.Location = new System.Drawing.Point(774, 512);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(95, 36);
            this.btnQuitter.TabIndex = 8;
            this.btnQuitter.Text = "&Quitter";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // btnMeilleursResultats
            // 
            this.btnMeilleursResultats.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMeilleursResultats.Location = new System.Drawing.Point(673, 512);
            this.btnMeilleursResultats.Name = "btnMeilleursResultats";
            this.btnMeilleursResultats.Size = new System.Drawing.Size(95, 36);
            this.btnMeilleursResultats.TabIndex = 9;
            this.btnMeilleursResultats.Text = "Meilleurs Résultat";
            this.btnMeilleursResultats.UseVisualStyleBackColor = true;
            this.btnMeilleursResultats.Click += new System.EventHandler(this.btnMeilleursResultats_Click);
            // 
            // btnNouvellePartie
            // 
            this.btnNouvellePartie.BackColor = System.Drawing.SystemColors.Control;
            this.btnNouvellePartie.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNouvellePartie.Location = new System.Drawing.Point(13, 19);
            this.btnNouvellePartie.Name = "btnNouvellePartie";
            this.btnNouvellePartie.Size = new System.Drawing.Size(109, 43);
            this.btnNouvellePartie.TabIndex = 12;
            this.btnNouvellePartie.Text = "Nouvelle Partie";
            this.btnNouvellePartie.UseVisualStyleBackColor = false;
            this.btnNouvellePartie.Click += new System.EventHandler(this.btnNouvellePartie_Click);
            // 
            // gbNouvellePartie
            // 
            this.gbNouvellePartie.BackColor = System.Drawing.Color.Transparent;
            this.gbNouvellePartie.Controls.Add(this.cboNiveau);
            this.gbNouvellePartie.Controls.Add(this.btnNouvellePartie);
            this.gbNouvellePartie.Location = new System.Drawing.Point(567, 390);
            this.gbNouvellePartie.Name = "gbNouvellePartie";
            this.gbNouvellePartie.Size = new System.Drawing.Size(314, 79);
            this.gbNouvellePartie.TabIndex = 13;
            this.gbNouvellePartie.TabStop = false;
            this.gbNouvellePartie.Text = "Nouvelle partie";
            // 
            // cboNiveau
            // 
            this.cboNiveau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNiveau.FormattingEnabled = true;
            this.cboNiveau.Items.AddRange(new object[] {
            "Débutant",
            "Intermédiaire",
            "Expert",
            "Solution - Débutant"});
            this.cboNiveau.Location = new System.Drawing.Point(128, 31);
            this.cboNiveau.Name = "cboNiveau";
            this.cboNiveau.Size = new System.Drawing.Size(164, 21);
            this.cboNiveau.TabIndex = 13;
            // 
            // tmrTemps
            // 
            this.tmrTemps.Interval = 1000;
            this.tmrTemps.Tick += new System.EventHandler(this.tmrTemps_Tick);
            // 
            // frmGrilleSudoku
            // 
            this.AcceptButton = this.btnValider;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TP5_Sudoku.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(897, 568);
            this.Controls.Add(this.gbNouvellePartie);
            this.Controls.Add(this.btnMeilleursResultats);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.lblEtiquetteTemps);
            this.Controls.Add(this.lblTemps);
            this.Controls.Add(this.vaChoixNumero);
            this.Controls.Add(this.vaGrilleSudoku);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGrilleSudoku";
            this.Text = "Sudoku";
            this.gbNouvellePartie.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VisualArrays.VisualIntArray vaGrilleSudoku;
        private VisualArrays.VisualIntArray vaChoixNumero;
        private System.Windows.Forms.Label lblTemps;
        private System.Windows.Forms.Label lblEtiquetteTemps;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Button btnMeilleursResultats;
        private System.Windows.Forms.ImageList imgLstBouton;
        private System.Windows.Forms.Button btnNouvellePartie;
        private System.Windows.Forms.GroupBox gbNouvellePartie;
        private System.Windows.Forms.ComboBox cboNiveau;
        private System.Windows.Forms.Timer tmrTemps;


    }
}

