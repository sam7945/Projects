namespace Tp4
{
    partial class frmTp4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTp4));
            this.lblRecord = new System.Windows.Forms.Label();
            this.txtRecord = new System.Windows.Forms.TextBox();
            this.txtPoint = new System.Windows.Forms.TextBox();
            this.lblPoint = new System.Windows.Forms.Label();
            this.lblErreur = new System.Windows.Forms.Label();
            this.txtErreur = new System.Windows.Forms.TextBox();
            this.btnParamètres = new System.Windows.Forms.Button();
            this.btnDémarrer = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.Location = new System.Drawing.Point(275, 9);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(61, 18);
            this.lblRecord.TabIndex = 0;
            this.lblRecord.Text = "Record:";
            // 
            // txtRecord
            // 
            this.txtRecord.Location = new System.Drawing.Point(266, 30);
            this.txtRecord.Name = "txtRecord";
            this.txtRecord.ReadOnly = true;
            this.txtRecord.Size = new System.Drawing.Size(100, 20);
            this.txtRecord.TabIndex = 1;
            this.txtRecord.Text = "0";
            this.txtRecord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPoint
            // 
            this.txtPoint.Location = new System.Drawing.Point(266, 79);
            this.txtPoint.Name = "txtPoint";
            this.txtPoint.ReadOnly = true;
            this.txtPoint.Size = new System.Drawing.Size(100, 20);
            this.txtPoint.TabIndex = 2;
            this.txtPoint.Text = "0";
            this.txtPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoint.Location = new System.Drawing.Point(275, 54);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(70, 18);
            this.lblPoint.TabIndex = 3;
            this.lblPoint.Text = "Pointage:";
            // 
            // lblErreur
            // 
            this.lblErreur.AutoSize = true;
            this.lblErreur.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErreur.Location = new System.Drawing.Point(275, 102);
            this.lblErreur.Name = "lblErreur";
            this.lblErreur.Size = new System.Drawing.Size(61, 18);
            this.lblErreur.TabIndex = 4;
            this.lblErreur.Text = "Erreurs:";
            // 
            // txtErreur
            // 
            this.txtErreur.Location = new System.Drawing.Point(266, 123);
            this.txtErreur.Name = "txtErreur";
            this.txtErreur.ReadOnly = true;
            this.txtErreur.Size = new System.Drawing.Size(100, 20);
            this.txtErreur.TabIndex = 5;
            this.txtErreur.Text = "0";
            this.txtErreur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnParamètres
            // 
            this.btnParamètres.Location = new System.Drawing.Point(266, 149);
            this.btnParamètres.Name = "btnParamètres";
            this.btnParamètres.Size = new System.Drawing.Size(100, 23);
            this.btnParamètres.TabIndex = 6;
            this.btnParamètres.Text = "&Paramètres";
            this.btnParamètres.UseVisualStyleBackColor = true;
            // 
            // btnDémarrer
            // 
            this.btnDémarrer.Location = new System.Drawing.Point(266, 178);
            this.btnDémarrer.Name = "btnDémarrer";
            this.btnDémarrer.Size = new System.Drawing.Size(100, 23);
            this.btnDémarrer.TabIndex = 7;
            this.btnDémarrer.Text = "&Démarrer";
            this.btnDémarrer.UseVisualStyleBackColor = true;
            this.btnDémarrer.Click += new System.EventHandler(this.btnDémarrer_Click);
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.Green;
            this.btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Location = new System.Drawing.Point(4, 9);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(121, 99);
            this.btn1.TabIndex = 8;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.Red;
            this.btn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.Location = new System.Drawing.Point(131, 9);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(118, 98);
            this.btn2.TabIndex = 9;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.Yellow;
            this.btn3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.Location = new System.Drawing.Point(4, 114);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(121, 96);
            this.btn3.TabIndex = 10;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = false;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.Color.Cyan;
            this.btn4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.Location = new System.Drawing.Point(131, 114);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(118, 96);
            this.btn4.TabIndex = 11;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = false;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 213);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(377, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl1
            // 
            this.tssl1.Name = "tssl1";
            this.tssl1.Size = new System.Drawing.Size(245, 17);
            this.tssl1.Text = "Cliquer sur Démarrer pour commencer le jeu.";
            // 
            // frmTp4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 235);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btnDémarrer);
            this.Controls.Add(this.btnParamètres);
            this.Controls.Add(this.txtErreur);
            this.Controls.Add(this.lblErreur);
            this.Controls.Add(this.lblPoint);
            this.Controls.Add(this.txtPoint);
            this.Controls.Add(this.txtRecord);
            this.Controls.Add(this.lblRecord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTp4";
            this.Text = "Jeu de Simon";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.TextBox txtRecord;
        private System.Windows.Forms.TextBox txtPoint;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.Label lblErreur;
        private System.Windows.Forms.TextBox txtErreur;
        private System.Windows.Forms.Button btnParamètres;
        private System.Windows.Forms.Button btnDémarrer;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl1;
    }
}

