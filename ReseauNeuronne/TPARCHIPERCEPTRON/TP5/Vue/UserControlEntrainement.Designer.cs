namespace TP5
{
    partial class UserControlEntrainement
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
            this.grpEntrainement = new System.Windows.Forms.GroupBox();
            this.lblValeurEntraine = new System.Windows.Forms.Label();
            this.txtValeurEntrainee = new System.Windows.Forms.TextBox();
            this.btnEntrainement = new System.Windows.Forms.Button();
            this.grpDessinEntrainement = new System.Windows.Forms.GroupBox();
            this.btnEffacer = new System.Windows.Forms.Button();
            this.ucDessin = new TP5.ucZoneDessin();
            this.grpEntrainement.SuspendLayout();
            this.grpDessinEntrainement.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpEntrainement
            // 
            this.grpEntrainement.Controls.Add(this.lblValeurEntraine);
            this.grpEntrainement.Controls.Add(this.txtValeurEntrainee);
            this.grpEntrainement.Controls.Add(this.btnEntrainement);
            this.grpEntrainement.Location = new System.Drawing.Point(202, 16);
            this.grpEntrainement.Name = "grpEntrainement";
            this.grpEntrainement.Size = new System.Drawing.Size(235, 138);
            this.grpEntrainement.TabIndex = 8;
            this.grpEntrainement.TabStop = false;
            this.grpEntrainement.Text = "Entrainement";
            // 
            // lblValeurEntraine
            // 
            this.lblValeurEntraine.AutoSize = true;
            this.lblValeurEntraine.Location = new System.Drawing.Point(7, 40);
            this.lblValeurEntraine.Name = "lblValeurEntraine";
            this.lblValeurEntraine.Size = new System.Drawing.Size(90, 13);
            this.lblValeurEntraine.TabIndex = 3;
            this.lblValeurEntraine.Text = "Valeur entrainée :";
            // 
            // txtValeurEntrainee
            // 
            this.txtValeurEntrainee.Location = new System.Drawing.Point(103, 37);
            this.txtValeurEntrainee.Name = "txtValeurEntrainee";
            this.txtValeurEntrainee.Size = new System.Drawing.Size(100, 20);
            this.txtValeurEntrainee.TabIndex = 2;
            // 
            // btnEntrainement
            // 
            this.btnEntrainement.Location = new System.Drawing.Point(10, 63);
            this.btnEntrainement.Name = "btnEntrainement";
            this.btnEntrainement.Size = new System.Drawing.Size(106, 47);
            this.btnEntrainement.TabIndex = 1;
            this.btnEntrainement.Text = "Entrainement";
            this.btnEntrainement.UseVisualStyleBackColor = true;
            this.btnEntrainement.Click += new System.EventHandler(this.btnEntrainement_Click);
            // 
            // grpDessinEntrainement
            // 
            this.grpDessinEntrainement.Controls.Add(this.btnEffacer);
            this.grpDessinEntrainement.Controls.Add(this.ucDessin);
            this.grpDessinEntrainement.Location = new System.Drawing.Point(16, 16);
            this.grpDessinEntrainement.Name = "grpDessinEntrainement";
            this.grpDessinEntrainement.Size = new System.Drawing.Size(180, 138);
            this.grpDessinEntrainement.TabIndex = 7;
            this.grpDessinEntrainement.TabStop = false;
            this.grpDessinEntrainement.Text = "Zone de dessin";
            // 
            // btnEffacer
            // 
            this.btnEffacer.Location = new System.Drawing.Point(76, 36);
            this.btnEffacer.Name = "btnEffacer";
            this.btnEffacer.Size = new System.Drawing.Size(75, 23);
            this.btnEffacer.TabIndex = 1;
            this.btnEffacer.Text = "Effacer";
            this.btnEffacer.UseVisualStyleBackColor = true;
            this.btnEffacer.Click += new System.EventHandler(this.btnEffacer_Click);
            // 
            // ucDessin
            // 
            this.ucDessin.BackColor = System.Drawing.Color.White;
            this.ucDessin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucDessin.Location = new System.Drawing.Point(6, 36);
            this.ucDessin.Name = "ucDessin";
            this.ucDessin.Size = new System.Drawing.Size(64, 64);
            this.ucDessin.TabIndex = 0;
            // 
            // UserControlEntrainement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpEntrainement);
            this.Controls.Add(this.grpDessinEntrainement);
            this.Name = "UserControlEntrainement";
            this.Size = new System.Drawing.Size(455, 173);
            this.grpEntrainement.ResumeLayout(false);
            this.grpEntrainement.PerformLayout();
            this.grpDessinEntrainement.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpEntrainement;
        private System.Windows.Forms.Label lblValeurEntraine;
        private System.Windows.Forms.TextBox txtValeurEntrainee;
        private System.Windows.Forms.Button btnEntrainement;
        private System.Windows.Forms.GroupBox grpDessinEntrainement;
        private System.Windows.Forms.Button btnEffacer;
        private ucZoneDessin ucDessin;
    }
}
