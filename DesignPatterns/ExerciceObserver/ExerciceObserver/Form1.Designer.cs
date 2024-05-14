namespace ExerciceObserver
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
            this.btnNotifier = new System.Windows.Forms.Button();
            this.txtResultat = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.chkTempete = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnNotifier
            // 
            this.btnNotifier.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnNotifier.Location = new System.Drawing.Point(12, 12);
            this.btnNotifier.Name = "btnNotifier";
            this.btnNotifier.Size = new System.Drawing.Size(183, 60);
            this.btnNotifier.TabIndex = 0;
            this.btnNotifier.Text = "Notifier";
            this.btnNotifier.UseVisualStyleBackColor = true;
            this.btnNotifier.Click += new System.EventHandler(this.btnNotifier_Click);
            // 
            // txtResultat
            // 
            this.txtResultat.Location = new System.Drawing.Point(12, 109);
            this.txtResultat.Multiline = true;
            this.txtResultat.Name = "txtResultat";
            this.txtResultat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultat.Size = new System.Drawing.Size(776, 329);
            this.txtResultat.TabIndex = 1;
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(299, 13);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(100, 20);
            this.txtPrenom.TabIndex = 2;
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(299, 51);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(100, 20);
            this.txtNom.TabIndex = 3;
            // 
            // chkTempete
            // 
            this.chkTempete.AutoSize = true;
            this.chkTempete.Location = new System.Drawing.Point(448, 13);
            this.chkTempete.Name = "chkTempete";
            this.chkTempete.Size = new System.Drawing.Size(68, 17);
            this.chkTempete.TabIndex = 4;
            this.chkTempete.Text = "Tempête";
            this.chkTempete.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chkTempete);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.txtResultat);
            this.Controls.Add(this.btnNotifier);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNotifier;
        private System.Windows.Forms.TextBox txtResultat;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.CheckBox chkTempete;
    }
}

