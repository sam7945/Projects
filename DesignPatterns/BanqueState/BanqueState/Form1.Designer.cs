namespace BanqueState
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
            this.btnDepot = new System.Windows.Forms.Button();
            this.btnRetrait = new System.Windows.Forms.Button();
            this.txtMontant = new System.Windows.Forms.TextBox();
            this.txtResultat = new System.Windows.Forms.TextBox();
            this.lblMontant = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDepot
            // 
            this.btnDepot.Location = new System.Drawing.Point(232, 33);
            this.btnDepot.Name = "btnDepot";
            this.btnDepot.Size = new System.Drawing.Size(154, 23);
            this.btnDepot.TabIndex = 0;
            this.btnDepot.Text = "Depot";
            this.btnDepot.UseVisualStyleBackColor = true;
            this.btnDepot.Click += new System.EventHandler(this.btnDepot_Click);
            // 
            // btnRetrait
            // 
            this.btnRetrait.Location = new System.Drawing.Point(392, 33);
            this.btnRetrait.Name = "btnRetrait";
            this.btnRetrait.Size = new System.Drawing.Size(154, 23);
            this.btnRetrait.TabIndex = 1;
            this.btnRetrait.Text = "Retrait";
            this.btnRetrait.UseVisualStyleBackColor = true;
            this.btnRetrait.Click += new System.EventHandler(this.btnRetrait_Click);
            // 
            // txtMontant
            // 
            this.txtMontant.Location = new System.Drawing.Point(82, 35);
            this.txtMontant.Name = "txtMontant";
            this.txtMontant.Size = new System.Drawing.Size(144, 20);
            this.txtMontant.TabIndex = 2;
            // 
            // txtResultat
            // 
            this.txtResultat.Location = new System.Drawing.Point(12, 85);
            this.txtResultat.Multiline = true;
            this.txtResultat.Name = "txtResultat";
            this.txtResultat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultat.Size = new System.Drawing.Size(534, 310);
            this.txtResultat.TabIndex = 3;
            // 
            // lblMontant
            // 
            this.lblMontant.AutoSize = true;
            this.lblMontant.Location = new System.Drawing.Point(27, 39);
            this.lblMontant.Name = "lblMontant";
            this.lblMontant.Size = new System.Drawing.Size(49, 13);
            this.lblMontant.TabIndex = 4;
            this.lblMontant.Text = "Montant:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 407);
            this.Controls.Add(this.lblMontant);
            this.Controls.Add(this.txtResultat);
            this.Controls.Add(this.txtMontant);
            this.Controls.Add(this.btnRetrait);
            this.Controls.Add(this.btnDepot);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDepot;
        private System.Windows.Forms.Button btnRetrait;
        private System.Windows.Forms.TextBox txtMontant;
        private System.Windows.Forms.TextBox txtResultat;
        private System.Windows.Forms.Label lblMontant;
    }
}

