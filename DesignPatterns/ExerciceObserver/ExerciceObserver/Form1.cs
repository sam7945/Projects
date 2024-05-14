using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExerciceObserver
{
    public partial class Form1 : Form
    {
        private Etudiant _etudiant;
        public Form1()
        {
            InitializeComponent();
            _etudiant = new Etudiant();
            EtudiantVrai e1 = new EtudiantVrai(_etudiant, txtResultat);
            EtudiantVrai e2 = new EtudiantVrai(_etudiant, txtResultat);
            EtudiantVrai e3 = new EtudiantVrai(_etudiant, txtResultat);
            _etudiant.Ajouter(e1);
            _etudiant.Ajouter(e2);
            _etudiant.Ajouter(e3);
        }

        private void btnNotifier_Click(object sender, EventArgs e)
        {
            _etudiant.Prenom = txtPrenom.Text;
            _etudiant.Nom = txtNom.Text;
            if (chkTempete.Checked)
                _etudiant.Tempete = true;
            else
                _etudiant.Tempete = false;
        }
    }
}
