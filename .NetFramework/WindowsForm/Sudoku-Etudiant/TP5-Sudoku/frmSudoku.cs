using mnemoTIC.Programmation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP5_Sudoku
{

    /// <summary>
    /// Auteur: Hugo St-Louis
    /// Description:
    /// Date: 24/11/2014
    /// </summary>
    public partial class frmGrilleSudoku : Form
    {
        //Variables membres
        private int _iValeurSelectionnee = 0;
        private DateTime _dtTempsDepart = new DateTime(0,0);

        //Constante
        public const int CASE_VIDE = -1;
        public const int NB_MEILLEUR_POINTAGE = 10;

        public const string FICHIER_GRILLE_DEBUTANT = "Données\\Sudoku-Debutant.txt";
        public const string FICHIER_GRILLE_INTERMEDIAIRE = "Données\\Sudoku-Intermediaire.txt";
        public const string FICHIER_GRILLE_EXPERT = "Données\\Sudoku-Expert.txt";
        public const string FICHIER_GRILLE_SOLUTION_DEBUTANT = "Données\\Sudoku-DebutantSolution.txt";
        public const string FICHIER_MEILLEUR_POINTAGE = "Données\\MeilleursResultats.txt";


        /// <summary>
        /// Auteur: Hugo St-Louis
        /// Description: Constructeur qui initalise les composants de la fenêtre.
        /// Date: 24/11/2014
        /// </summary>
        public frmGrilleSudoku()
        {
            int iValeur = 1;

            InitializeComponent();

            //Initialise le composant visual array pour la sélection des chiffres.
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    vaChoixNumero[i, j] = iValeur;
                    iValeur++;
                }
            //Sélectionne le premier chiffre
            vaChoixNumero[0, 0] = vaChoixNumero[0, 0] + 18;
            _iValeurSelectionnee = 1;

            //Sélectionne le niveau de difficulté Débutant
            cboNiveau.SelectedIndex = 0;
            //Vide la grille de sudoku
            InitialiseGrilleSudoku();
            vaGrilleSudoku.Enabled = false;
        }

        /// <summary>
        /// Auteur: Hugo St-Louis
        /// Description: Modifier l'image et la référence vers le chiffre sélectionné.
        /// Date: 24/11/2014
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vaChoixNumero_CellMouseClick(object sender, VisualArrays.CellMouseEventArgs e)
        {
            if ((_iValeurSelectionnee - 1) != (vaChoixNumero[e.Row, e.Column] - 1) % 9)
            {
                vaChoixNumero[e.Row, e.Column] = vaChoixNumero[e.Row, e.Column] + 9;

                int iAncienneligne = (_iValeurSelectionnee - 1) / 3;
                int iAncienneColonne = (_iValeurSelectionnee - 1) % 3;

                if ((iAncienneligne != e.Row || iAncienneColonne != e.Column) &&
                    vaChoixNumero[iAncienneligne, iAncienneColonne] >= 18)
                    vaChoixNumero[iAncienneligne, iAncienneColonne] = vaChoixNumero[iAncienneligne, iAncienneColonne] - 18;

                _iValeurSelectionnee = vaChoixNumero[e.Row, e.Column] - 18;
            }
        }

        /// <summary>
        /// Auteur: Hugo St-Louis
        /// Description: Modifier l'image lorsque le curseur de la souris est par dessus l'image d'un chiffre.
        /// Date: 24/11/2014
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vaChoixNumero_CellMouseEnter(object sender, VisualArrays.CellEventArgs e)
        {
            if (vaChoixNumero[e.Row, e.Column] <= 18)
                vaChoixNumero[e.Row, e.Column] = vaChoixNumero[e.Row, e.Column] + 9;
        }

        /// <summary>
        /// Auteur: Hugo St-Louis
        /// Description:
        /// Date: 24/11/2014
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vaChoixNumero_CellMouseLeave(object sender, VisualArrays.CellEventArgs e)
        {
            if (vaChoixNumero[e.Row, e.Column] <= 18)
                vaChoixNumero[e.Row, e.Column] = vaChoixNumero[e.Row, e.Column] - 9;
        }

        /// <summary>
        /// Auteur: Hugo St-Louis
        /// Description: Modifie la cellule cliqué avec le chiffre sélectionné si elle est vide. 
        /// Si l'utilisateur clique sur une cellule avec le bouton droit, la cellule est vidée.
        /// Date: 24/11/2014
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vaGrilleSudoku_CellMouseClick(object sender, VisualArrays.CellMouseEventArgs e)
        {
            if (vaGrilleSudoku.GetCellEnabled(e.Row, e.Column))
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    vaGrilleSudoku[e.Row, e.Column] = _iValeurSelectionnee;
                else // Clic-droit de la souris
                    vaGrilleSudoku[e.Row, e.Column] = CASE_VIDE; // Vider la case.
            }
        }

        /// <summary>
        /// Auteur: Hugo St-Louis
        /// Description: Permet de quitter l'application lorsque l'utilisateur clique sur le bouton Quitter
        /// Date: 24/11/2014
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		/// <summary>
		/// Auteur: Hugo St-Louis
		/// Description: Permet d'initialiser la grille de jeu à une valeur vide.
		/// Date: 24/11/2014
		/// </summary>
		private void InitialiseGrilleSudoku()
		{
            for (int iLigne = 0; iLigne < 9; iLigne++)
            {
                for (int iColonne = 0; iColonne < 9; iColonne++)
                {
                    vaGrilleSudoku[iLigne, iColonne] = CASE_VIDE; //initialise toute les case à -1.
                }
            }
		}

		/// <summary>
		/// Auteur: Hugo St-Louis
		/// Description: Affiche les 10 meilleurs résultats 
		/// Date: 24/11/2014
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnMeilleursResultats_Click(object sender, EventArgs e)
        {
            AfficherMeilleursResultats();
        }

        /// <summary>
        /// Auteur: Hugo St-Louis
        /// Description: Affiche les 10 meilleurs pointage du jeu.
        /// Date: 24/11/2014
        /// </summary>
        private void AfficherMeilleursResultats()
        {
            StreamReader FichierEntrant = null;

            FichierEntrant = new StreamReader(FICHIER_MEILLEUR_POINTAGE);

            MessageBox.Show("Prénom" + "\tNom" + "\tNiveau" + "\tTemp" + "\r\n" + FichierEntrant);

            FichierEntrant.Close();
        }

        /// <summary>
        /// Auteur:      Hugo St-Louis
        /// Description: Valide la grille de sudoku. Si l'utilisateur à réussi 
        ///              le sudoku, un message est affiché, le temps arrête et on essait d'ajouter 
        ///              ce temps aux meilleurs pointages.
        /// Date:        24/11/2014
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValider_Click(object sender, EventArgs e)
        {

            ValiderGrille();
            tmrTemps.Stop();
            if (ValiderGrille())
            {
                MessageBox.Show("Félicitation, vous avez réussi.", "Gagnant");
                AjouterMeilleurPointage();
            }
            else
            {
                MessageBox.Show("CE N'EST PAS BON!!!","Perdant");
            }
            
        }

        /// <summary>
        /// Auteur:      Hugo St-Louis
        /// Description: Permet de vérifier si le temps de la partie fait partie des 10 meilleurs 
        ///              pointage. Si C'est le cas, le nouveau pointage est insérer dans la liste, 
        ///              affiché à l'écran et sauvegarder dans le fichier.
        /// Date:        24/11/2014
        /// </summary>
        private void AjouterMeilleurPointage()
        {
            StreamReader FichierEntrant = null;
            StreamWriter FichierÉcrit = null;
            string sNom = "";
            string sPrénom = "";
            string sDifficulté = "";
            string sTemp = "";
            string sLigne = "";
            string[] asTemps = null;
            string sLigne1 = "";
            string[] asTemps1 = null;
            string sRésultatActuel = "";
            string[] asRésultatActuel = null;

            sPrénom = Formulaires.DemanderValeur("Donnez votre Prénom", "Prénom");
            sNom = Formulaires.DemanderValeur("Donnez votre nom", "Nom");
            sTemp = lblTemps.Text;
            sDifficulté = cboNiveau.SelectedItem.ToString();

            List<string> Résultat = new List<string>();

            Résultat.Add(sPrénom + "," + sNom + "," + sDifficulté + "," + sTemp);

            File.AppendAllText(FICHIER_MEILLEUR_POINTAGE, Résultat.ToString());

            FichierEntrant = new StreamReader(FICHIER_MEILLEUR_POINTAGE);
            
            while (!FichierEntrant.EndOfStream)
            {
                sLigne = FichierEntrant.ReadLine();
                asTemps = sLigne.Split(',');
                Résultat.Add(sLigne);
            }
            for (int iLigne1 = 0; iLigne1 < Résultat.Count; iLigne1++)
            {
                sLigne1 = Résultat[iLigne1];
                asTemps1 = sLigne1.Split(',');

                for (int iLigne = 0; iLigne < Résultat.Count; iLigne++)
                {
                    sLigne = Résultat[iLigne];
                    asTemps = sLigne.Split(',');

                    if (DateTime.Parse(asTemps[3]) < DateTime.Parse(asTemps1[3]) && iLigne1 != 0 && iLigne != iLigne1)
                    {
                        Résultat.Insert(iLigne - 1, Résultat[(iLigne - 1)]);
                        Résultat.Insert(iLigne1 + 1, Résultat[iLigne1]);
                    }
                }
            }
            FichierEntrant.Close();

            FichierÉcrit = new StreamWriter(FICHIER_MEILLEUR_POINTAGE);

            for (int iLigne = 0; iLigne < Résultat.Count; iLigne++)
            {
                FichierÉcrit.WriteLine(Résultat[iLigne].ToString());
                FichierÉcrit.Flush();
            }

            FichierÉcrit.Close();

            //if (FichierEntrant.EndOfStream)
            //{
            //    Résultat.Insert(0, asRésultatActuel.ToString());
            //}
            //if (FichierEntrant != null)
            //{
            //    for (int iLigne = 0; iLigne < Résultat.Count; iLigne++)
            //    {
            //        sLigne = FichierEntrant.ReadLine();
            //        asTemps = sLigne.Split(',');
            //
            //        if (int.Parse(asRésultatActuel[3]) < int.Parse(asTemps[3]))
            //        {
            //            Résultat.Insert(iLigne, asRésultatActuel.ToString());
            //        }
            //    }
            //}




        }

        /// <summary>
        /// Auteur:      Hugo St-Louis
        /// Description: Valide la grille sudoku. Il faut valider que chaque ligne, colonne et région de 
        ///              la grille possèdent des chiffres différents de 1 à 9.
        /// Date:        24/11/2014
        /// </summary>
        /// <returns>Vrai si la grille est valide, faux autrement</returns>
        private bool ValiderGrille()
        {
            int iIdentique = 0;
            
            for (int iLigne = 0; iLigne < vaGrilleSudoku.RowCount;)
            {
                for (int iColonne = 0; iColonne < vaGrilleSudoku.ColumnCount;)
                {
                    ValiderRegion(iLigne, iColonne);
                    iColonne += 3;
                }
                iLigne += 3;
            }
            for (int iLigne = 0; iLigne < vaGrilleSudoku.RowCount; iLigne++)
            {
                for (int iColonne = 0; iColonne < vaGrilleSudoku.ColumnCount; iColonne++)
                {
                    for (int iColonne2 = 0; iColonne2 < vaGrilleSudoku.ColumnCount; iColonne2++)
                    {
                        if (vaGrilleSudoku[iLigne,iColonne] == vaGrilleSudoku[iLigne,iColonne2])
                        {
                            iIdentique++;
                        }
                    }
                    if (iIdentique > 1 || iIdentique < 1)
                    {
                        return false;
                    }
                    iIdentique = 0;
                }
            }
            for (int iColonne = 0; iColonne < vaGrilleSudoku.RowCount; iColonne++)
            {
                for (int iLigne = 0; iLigne < vaGrilleSudoku.ColumnCount; iLigne++)
                {
                    for (int iLigne2 = 0; iLigne2 < vaGrilleSudoku.ColumnCount; iLigne2++)
                    {
                        if (vaGrilleSudoku[iLigne, iColonne] == vaGrilleSudoku[iLigne2, iColonne])
                        {
                            iIdentique++;
                        }
                    }
                    if (iIdentique > 1 || iIdentique < 1)
                    {
                        return false;
                    }
                    iIdentique = 0;
                }
            }
            for (int iLigne = 0; iLigne < vaGrilleSudoku.RowCount; iLigne++)
            {
                for (int iColonne = 0; iColonne < vaGrilleSudoku.ColumnCount; iColonne++)
                {
                    if (vaGrilleSudoku[iLigne, iColonne] == -1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Auteur:      Hugo St-Louis
        /// Description: Valide une région (3X3) de la grille sudoku. Pour qu'une région soit valide, il 
        ///              faut qu'il y ait 9 chiffres différents dans la région.
        /// Date:        24/11/2014
        /// </summary>
        /// <param name="iDebutX"></param>
        /// <param name="iDebutY"></param>
        /// <returns></returns>
        private bool ValiderRegion(int iDebutX, int iDebutY)
        {
            int iIdentique = 0;

            for (iDebutX = 0; iDebutX < 3; iDebutX++)
            {
                for ( iDebutY = 0; iDebutY < 3; iDebutY++)
                {
                    for (int iRechercheX = 0; iRechercheX < 3; iRechercheX++)
                    {
                        for (int iRechercheY = 0; iRechercheY < 3; iRechercheY++)
                        {
                            if (vaGrilleSudoku[iRechercheX,iRechercheY] == vaGrilleSudoku[iDebutX,iDebutY])
                            {
                                iIdentique++;
                            }
                        }
                    
                        if (iIdentique > 1 || iIdentique < 1)
                        {
                            return false;
                        }
                        iIdentique = 0;
                    }
                }
            }
			return true;
        }


        /// <summary>
        /// Auteur:      Hugo St-Louis
        /// Description: Charger une grille sudoku à partir d'un fichier en fonction du niveau: 
        ///              débutant, intermédiaire, expert ou une solution.
        /// Date:        24/11/2014
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNouvellePartie_Click(object sender, EventArgs e)
        {
            tmrTemps.Start(); //Démarre le timer
            if (cboNiveau.SelectedItem.Equals("Débutant"))
            {
                ChargerGrilleSudoku(FICHIER_GRILLE_DEBUTANT); //charge le fichier débutant
            }
            else if (cboNiveau.SelectedItem.Equals("Intermédiaire"))
            {
                ChargerGrilleSudoku(FICHIER_GRILLE_INTERMEDIAIRE); //charge le fichier Intermédiaire
            }
            else if (cboNiveau.SelectedItem.Equals("Expert"))
            {
                ChargerGrilleSudoku(FICHIER_GRILLE_EXPERT); //charge le fichier Expert
            }
            vaGrilleSudoku.Enabled = true;
            btnValider.Enabled = true;
            _dtTempsDepart = new DateTime(0, 0);
        }

        /// <summary>
        /// Auteur:      Hugo St-Louis
        /// Description: Charger la grille de sudoku à partir du fichier passé en paramètre. 
        ///              Si une case est vide, il faut permettre à l'utilisateur d'entrer une valeur en rendant cette 
        ///              cellule "Enabled" (vaGrilleSudoku.SetCellEnabled(iLigne, iColonne, true);), autrement la désactiver.
        /// Date:        24/11/2014
        /// </summary>
        /// <param name="fichier"></param>
        private void ChargerGrilleSudoku(string fichier)
        {

            StreamReader FichierEntrant = null; 
            string sLigne = "";
            string[] asNombres = null;

            FichierEntrant = new StreamReader(fichier);//ouverture du fichier sélectionné.

            
            for (int iLigne = 0; iLigne < 9; iLigne++) //Fait dérouller le tableau ligne par ligne
            {
                sLigne = FichierEntrant.ReadLine(); //prend la ligne pour la modifier
                asNombres = sLigne.Split(','); //enlève les virgules et sépare les chiffres.

                for (int iColonne = 0; iColonne < 9; iColonne++) //lit colonne par colonne
                {
                    vaGrilleSudoku[iLigne, iColonne] = int.Parse(asNombres[iColonne]); //insère le chiffre dans sa zone respective.
                    vaGrilleSudoku.Update(); //met le tableau à jour chiffre par chiffre
                    if (vaGrilleSudoku[iLigne,iColonne] == -1) 
                    {
                        vaGrilleSudoku.SetCellEnabled(iLigne, iColonne, true); //permet à la cellule d'être modifié
                        vaGrilleSudoku.SetCellReadOnly(iLigne, iColonne, false); //retire le read-only, si il l'a.
                    }
                    else if (vaGrilleSudoku[iLigne,iColonne] != -1)
                    {
                        vaGrilleSudoku.SetCellEnabled(iLigne, iColonne, false); //empêche la cellule d'être modifié
                        vaGrilleSudoku.SetCellReadOnly(iLigne, iColonne, true); //met la cellule en read-only
                    }
                }
            }

            FichierEntrant.Close();
        }

        /// <summary>
        /// Auteur: Hugo St-Louis
        /// Description: À chaque seconde, modifie le temps de résolution du sudoku
        /// Date: 24/11/2014
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrTemps_Tick(object sender, EventArgs e)
        {
            _dtTempsDepart = _dtTempsDepart.AddSeconds(+1); //ajoute une seconde à chaque seconde
            lblTemps.Text = _dtTempsDepart.ToString("mm:ss"); //met le timer en minute,seconde
        } 
    }
}
