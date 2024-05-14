namespace TP5
{
    partial class UserControlTest
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOk = new System.Windows.Forms.Button();
            this.txtResultat = new System.Windows.Forms.TextBox();
            this.grpDessinEntrainement = new System.Windows.Forms.GroupBox();
            this.ucDessin = new TP5.ucZoneDessin();
            this.grpDessinEntrainement.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(135, 41);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(113, 64);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtResultat
            // 
            this.txtResultat.Location = new System.Drawing.Point(14, 137);
            this.txtResultat.Multiline = true;
            this.txtResultat.Name = "txtResultat";
            this.txtResultat.Size = new System.Drawing.Size(234, 135);
            this.txtResultat.TabIndex = 9;
            // 
            // grpDessinEntrainement
            // 
            this.grpDessinEntrainement.Controls.Add(this.ucDessin);
            this.grpDessinEntrainement.Location = new System.Drawing.Point(14, 12);
            this.grpDessinEntrainement.Name = "grpDessinEntrainement";
            this.grpDessinEntrainement.Size = new System.Drawing.Size(99, 119);
            this.grpDessinEntrainement.TabIndex = 8;
            this.grpDessinEntrainement.TabStop = false;
            this.grpDessinEntrainement.Text = "Zone de dessin";
            // 
            // ucDessin
            // 
            this.ucDessin.BackColor = System.Drawing.Color.White;
            this.ucDessin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucDessin.Location = new System.Drawing.Point(15, 29);
            this.ucDessin.Name = "ucDessin";
            this.ucDessin.Size = new System.Drawing.Size(64, 64);
            this.ucDessin.TabIndex = 0;
            // 
            // UserControlTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtResultat);
            this.Controls.Add(this.grpDessinEntrainement);
            this.Name = "UserControlTest";
            this.Size = new System.Drawing.Size(265, 289);
            this.grpDessinEntrainement.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtResultat;
        private System.Windows.Forms.GroupBox grpDessinEntrainement;
        private ucZoneDessin ucDessin;
    }
}
