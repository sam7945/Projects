using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP3__SamuelDextraze_
{
    public partial class frmTP3 : Form
    {
        /// <summary>
        /// Auteur: Samuel Dextraze
        /// Description: TP3
        /// Date: 2017/10/17
        /// </summary>
        public frmTP3()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Auteur: Samuel Dextraze
        /// Description: TP3
        /// Date: 2017/10/17
        /// </summary>
        private void btnMàj_Click(object sender, EventArgs e)
        {
            //Déclaration des variables
            int iNbCaractère = 0;
            int iNbMot = 0;
            int iNbMaj = 0;
            int iNbMin = 0;
            int iNbCon = 0;
            int iNbVoy = 0;
            string sLongMot = "";
            string sTexte = "";

            //Mise à jours
            sTexte = txtTexte.Text;
            iNbCaractère = (sTexte.Length);


            for (int icompte = 0; icompte < sTexte.Length; icompte++)
            {
                if (char.IsUpper(sTexte[icompte])) iNbMaj++; //Nombre de Majuscules

                if (char.IsLower(sTexte[icompte])) iNbMin++; //Nombre de minuscules

                if (char.IsLetter(sTexte[icompte]) && (      
                     sTexte.ToLower()[icompte] == ('à') ||
                     sTexte.ToLower()[icompte] == ('â') ||
                     sTexte.ToLower()[icompte] == ('é') ||
                     sTexte.ToLower()[icompte] == ('è') ||
                     sTexte.ToLower()[icompte] == ('ê') ||
                     sTexte.ToLower()[icompte] == ('ë') ||
                     sTexte.ToLower()[icompte] == ('ï') ||
                     sTexte.ToLower()[icompte] == ('î') ||
                     sTexte.ToLower()[icompte] == ('ù') ||
                     sTexte.ToLower()[icompte] == ('û') ||
                     sTexte.ToLower()[icompte] == ('ô') ||
                     sTexte.ToLower()[icompte] == ('a') ||
                     sTexte.ToLower()[icompte] == ('e') ||
                     sTexte.ToLower()[icompte] == ('i') ||
                     sTexte.ToLower()[icompte] == ('o') ||
                     sTexte.ToLower()[icompte] == ('u') ||
                     sTexte.ToLower()[icompte] == ('y'))) iNbVoy++; //Nombre de voyelles

                else if (char.IsLetter(sTexte[icompte]) &&
                     sTexte.ToLower()[icompte] == ('b') ||
                     sTexte.ToLower()[icompte] == ('c') ||
                     sTexte.ToLower()[icompte] == ('d') ||
                     sTexte.ToLower()[icompte] == ('f') ||
                     sTexte.ToLower()[icompte] == ('g') ||
                     sTexte.ToLower()[icompte] == ('h') ||
                     sTexte.ToLower()[icompte] == ('i') ||
                     sTexte.ToLower()[icompte] == ('j') ||
                     sTexte.ToLower()[icompte] == ('k') ||
                     sTexte.ToLower()[icompte] == ('l') ||
                     sTexte.ToLower()[icompte] == ('m') ||
                     sTexte.ToLower()[icompte] == ('n') ||
                     sTexte.ToLower()[icompte] == ('p') ||
                     sTexte.ToLower()[icompte] == ('q') ||
                     sTexte.ToLower()[icompte] == ('r') ||
                     sTexte.ToLower()[icompte] == ('s') ||
                     sTexte.ToLower()[icompte] == ('t') ||
                     sTexte.ToLower()[icompte] == ('v') ||
                     sTexte.ToLower()[icompte] == ('w') ||
                     sTexte.ToLower()[icompte] == ('x') ||
                     sTexte.ToLower()[icompte] == ('z')) iNbCon++; //Nombre de Consonnes

                if (sTexte[icompte] == (' ') ||
                    sTexte[icompte] == (':') ||
                    sTexte[icompte] == ('\'') ||
                    sTexte[icompte] == ('.') ||
                    sTexte[icompte] == ('/') ||
                    sTexte[icompte] == ('\"') ||
                    sTexte == ("\r\n") ||
                    sTexte[icompte] == ('\t')) iNbMot++; //Nombre de mots

                string[] mots = sTexte.Split(new[] { " ",",","'",".","\r\n" }, StringSplitOptions.None); // Mot le plus long(Soluce d'internet)
                int compteur = 0;
                foreach (String s in mots)
                {
                    if (s.Length > compteur)
                    {
                        sLongMot = s;
                        compteur = s.Length;
                    }
                }
            }
            //Assignation des variables string aux textbox
            txtCaractère.Text = iNbCaractère.ToString();
            txtMinuscule.Text = (iNbMin).ToString();
            txtMajuscule.Text = (iNbMaj).ToString();
            txtVoyelle.Text = (iNbVoy).ToString();
            txtConsonne.Text = (iNbCon).ToString();
            txtMot.Text = (iNbMot).ToString();
            txtLong.Text = sLongMot;
        }
        /// <summary>
        /// Auteur: Samuel Dextraze
        /// Description: TP3
        /// Date: 2017/10/17
        /// </summary>
        private void EffText_Click(object sender, EventArgs e)
        {
            //Réinitialisation
            txtTexte.Text = "";
            txtCaractère.Text = "";
            txtMinuscule.Text = "";
            txtMajuscule.Text = "";
            txtVoyelle.Text = "";
            txtConsonne.Text = "";
            txtMot.Text = "";
            txtLong.Text = "";
            txtSortie.Text = "";
            cmbInverse.Text = "";
            txtRecherche.Text = "";
            txtRemplace1.Text = "";
            txtRemplace2.Text = "";
            txtMasque1.Text = "";
            txtMasque2.Text = "";
            optEspace.Checked = true;
        }
        /// <summary>
        /// Auteur: Samuel Dextraze
        /// Description: TP3
        /// Date: 2017/10/17
        /// </summary>
        private void ExeAction_Click(object sender, EventArgs e)
        {
            //Assignation de variables
            string sReverse = "";
            string sTexte = txtTexte.Text;
            string sTexteMinMaj = "";
            string sMin = "";
            string sMaj = "";
            string sRecherche = "";
            bool bOccurance = false;
            int iNbOccurance = 0;
            string[] sRechercher;
            string[] sPalindrôme ;
            sRecherche = txtRecherche.Text;
            string sSortie = "";
            string sMotInverse = "";
            string sLettre = "";
            string sMasc = txtMasque1.Text;

            //Retirer les espaces
            if (optEspace.Checked)
            {
                for (int iCompte = 0; iCompte < sTexte.Length; iCompte++) //Avance dans le texte caractère par caractère
            
                    if ( char.IsSeparator(sTexte[iCompte]))
                    { 
                        sTexte = sTexte.Replace(" ", ""); //Remplacement des espaces par rien
                    }
                txtSortie.Text = sTexte;
            }
            //Inverse
            if (optInverse.Checked)
            {
                if (cmbInverse.SelectedItem.Equals("La casse")) //Inverse les majuscules et minuscules
                {
                    
                     for (int iCompte1 = 0; iCompte1 < sTexte.Length; iCompte1++)//Circule dans le texte un caractère a la fois
                    {
                        if (char.IsUpper(sTexte[iCompte1]) || char.IsSeparator(sTexte[iCompte1]) || char.IsPunctuation(sTexte[iCompte1]) || 
                            char.IsNumber(sTexte[iCompte1])) //Conditions pour conversion Majuscule-Minuscule
                        {
                            sMin = (sTexte[iCompte1]).ToString().ToLower();
                            sTexteMinMaj += sMin;
                            continue;//Retour au for
                        }
                        else if (char.IsLower(sTexte[iCompte1]))//Conditions pour conversion Minuscule-Majuscule
                        { 
                            sMaj = (sTexte[iCompte1]).ToString().ToUpper();
                            sTexteMinMaj += sMaj;
                            continue;//Retour au for
                        }
                    }
                    txtSortie.Text = sTexteMinMaj;
                }
                if (cmbInverse.SelectedItem.Equals("Le texte"))//Inversion de texte (Premier caractère = dernier caractère)
                {
                    for (int iCompte2 = sTexte.Length-1; iCompte2 >= 0; iCompte2--) //Lecture du texte à l'envers
                    {
                        sReverse = sReverse + sTexte[iCompte2]; //Assignation des caractères un a la fois de la fin au debut
                    }
                    txtSortie.Text = sReverse;
                }
            }
            if (optRecherche.Checked) //Recherche du nombre d'occurance
            {
                sRechercher = sTexte.Split(' ', '\'','.', ',',':','\n','\r'); //Séparation des mots du texte
                for (int iCompte3 = 0; iCompte3 < sRechercher.Length; iCompte3++)
                {
                    bOccurance = sRechercher[iCompte3].ToLower().Equals(sRecherche.ToLower()); //recherche des occurances entre chaques mots
                        if (bOccurance == true)
                        {
                         iNbOccurance++;
                        }
                }
                    txtSortie.Text = "Le nombre d'occurances trouvé pour le mot " +"\""+sRecherche +"\" est: "+ iNbOccurance;
            }
            if (optPalindromes.Checked)//Recherche de palindrome
            {

                sPalindrôme = sTexte.Split(' ', '\'', '.', ',', ':', '\n', '\r');

                for (int iCompte4 = 0; iCompte4 < sPalindrôme.Length; iCompte4++) //lecture mots par mots
                {
                    string sMot = sPalindrôme[iCompte4];

                    for (int iCompte4_1 = sMot.Length-1; iCompte4_1 >= 0; iCompte4_1--) //lecture des mots à l'envers
                    {
                        sMotInverse = sMotInverse + sMot[iCompte4_1];
                    }
                        if (sMot.Equals(sMotInverse)) //Comparaison entre les 2 versions du mot et condition si vrai ou faux
                        {
                            sSortie += sMot + ",";
                            txtSortie.Text = string.Format("Le(s) palindrome(s) est/sont: {0}", sSortie);
                        }   
                }
            }

            if (optRemplace.Checked) //Remplacement de mot
            {
                txtSortie.Text = txtTexte.Text.Replace(txtRemplace1.Text, txtRemplace2.Text); //rehcerche du mot et remplacement
            }
            if (optMasque.Checked) //Masque des caractères soécifiés
            {

                for (int iCompte5 = 0; iCompte5 < sMasc.Length; iCompte5++) //Prendre un caractère à la fois du textbox de remplacement 1
                {
                    sLettre = sMasc[iCompte5].ToString();
                
                    for (int iCompte5_1 = 0; iCompte5_1 < sTexte.Length; iCompte5_1++)// Avec le caractère choisi dans la texbox de remplacement 2, remplacé les caractères correspondant à la 1.
                    {
                        if ((sTexte[iCompte5_1]).ToString() == sLettre && (sTexte[iCompte5_1]).ToString() != txtMasque2.Text)
                        {
                            sTexte = sTexte.Replace((sTexte[iCompte5_1]).ToString(),txtMasque2.Text);
                        }

                    }
                }
                txtSortie.Text = sTexte;
            }

        }
        /// <summary>
        /// Auteur: Samuel Dextraze
        /// Description: TP3 (Ajout grace à la matière apprise mardi)
        /// Date: 2017/10/25
        /// </summary>
        //Vérrouille les cases si les "radio button" ne sont pas appuyés.        
        private void optInverse_Check(object sender, EventArgs e)
        {
            if (optInverse.Checked) 
            {
                cmbInverse.Enabled = true;
            }
            else
            {
                cmbInverse.Enabled = false;
                cmbInverse.Text = null;
            }
        }

        private void optRecherche_Check(object sender, EventArgs e)
        {
            if (optRecherche.Checked)
            {
                txtRecherche.Enabled = true;
            }
            else
            {
                txtRecherche.Enabled = false;
                txtRecherche.Text = "";
            }
        }

        private void optRemplace_Check(object sender, EventArgs e)
        {
            if (optRemplace.Checked)
            {
                txtRemplace1.Enabled = true;
                txtRemplace2.Enabled = true;
            }
            else
            {
                txtRemplace1.Enabled = false;
                txtRemplace1.Text = "";
                txtRemplace2.Enabled = false;
                txtRemplace2.Text = "";
            }
        }

        private void optMasque_Check(object sender, EventArgs e)
        {
            if (optMasque.Checked)
            {
                txtMasque1.Enabled = true;
                txtMasque2.Enabled = true;
            }
            else
            {
                txtMasque1.Enabled = false;
                txtMasque1.Text = "";
                txtMasque2.Enabled = false;
                txtMasque2.Text = "";
            }
        }
    }
}
