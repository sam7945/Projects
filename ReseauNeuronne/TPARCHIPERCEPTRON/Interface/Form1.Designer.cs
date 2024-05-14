namespace Interface
{
    partial class Form1
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
            this.userControlEntrainement1 = new TP5.UserControlEntrainement();
            this.userControlTest1 = new TP5.UserControlTest();
            this.SuspendLayout();
            // 
            // userControlEntrainement1
            // 
            this.userControlEntrainement1.ConstanteApprentissageEntrainement = 0.01D;
            this.userControlEntrainement1.EmplacementFichierEntrainement = "Train.dat";
            this.userControlEntrainement1.Location = new System.Drawing.Point(12, 12);
            this.userControlEntrainement1.Name = "userControlEntrainement1";
            this.userControlEntrainement1.NouveauFichierEntrainement = true;
            this.userControlEntrainement1.Size = new System.Drawing.Size(455, 173);
            this.userControlEntrainement1.TabIndex = 1;
            this.userControlEntrainement1.ButtonTrainClick += new TP5.UserControlEntrainement.TrainButtonClickHandler(this.userControlEntrainement1_ButtonTrainClick);
            this.userControlEntrainement1.ButtonEraseClick += new TP5.UserControlEntrainement.EraseButtonClickHandler(this.userControlEntrainement1_ButtonEraseClick);
            // 
            // userControlTest1
            // 
            this.userControlTest1.ConstanteApprentissageTest = 0.01D;
            this.userControlTest1.EmplacementFichierTest = "Train.dat";
            this.userControlTest1.Location = new System.Drawing.Point(473, 12);
            this.userControlTest1.ModePhraseTest = true;
            this.userControlTest1.Name = "userControlTest1";
            this.userControlTest1.Resultat = "";
            this.userControlTest1.Size = new System.Drawing.Size(265, 289);
            this.userControlTest1.TabIndex = 0;
            this.userControlTest1.ButtonOkClick += new TP5.UserControlTest.OkButtonClickHandler(this.userControlTest1_ButtonOkClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 303);
            this.Controls.Add(this.userControlEntrainement1);
            this.Controls.Add(this.userControlTest1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private TP5.UserControlTest userControlTest1;
        private TP5.UserControlEntrainement userControlEntrainement1;
    }
}

