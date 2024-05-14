using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Tp4
{
    public partial class frmTp4 : Form
    {
        #region variables globales
        //variables globales
        Random _rnd = new Random();
        int[] _aiGrosseurTableau = null;
        int _iGrosseurTableau = 0;
        int _iTour = 1;
        int _iBouton = 0;
        bool _bBouton1 = false;
        bool _bBouton2 = false;
        bool _bBouton3 = false;
        bool _bBouton4 = false;
        int _BoutonAppuyer = 0;
        int _iPoint = 0;
        int _iRecord = 0;
        int _iErreur = 0;
        string sAnimation = "En cours d'animation.";
        string sTourJoueur = "Veuillez choisir la bonne couleur.";
        string sErreur = "Mauvaise couleur entrée.";
        #endregion

        #region Constructeur

        
        /// <summary>
        /// Auteur:Samuel Dextraze
        /// Description:Tp4
        /// Date:2017/11/12
        /// </summary>
        public frmTp4()
        {
            InitializeComponent();
        }
        #endregion

        #region Tableau

        
        /// <summary>
        /// Auteur:Samuel Dextraze
        /// Description: Fabrication et remplissage du tableau.
        /// Date:2017/11/14
        /// </summary>
        private void FaireTableau()
        {
            //grosseur du tableau
            _iGrosseurTableau = 255;
            _aiGrosseurTableau = new int[_iGrosseurTableau];

            //remplissage du tableau entre les chiffre 1 et 4.
            for (int iIndex = 0; iIndex < _aiGrosseurTableau.Length; iIndex++)
            {
                _aiGrosseurTableau[iIndex] = _rnd.Next(1, 5);
            }
        }
        #endregion

        #region Animation

        
        /// <summary>
        /// Auteur: Samuel Dextraze
        /// Description: Affiche l'ordre des couleurs à sélectionner.
        /// Date: 2017/11/14
        /// </summary>
        //Affiche la couleur
        private void AffichageCouleur()
        {
            tssl1.Text = sAnimation;
            statusStrip1.Update();
            for (int iIndex = 0; iIndex < _iTour; iIndex++)
            {
                if (_aiGrosseurTableau[iIndex] == 1)
                {
                    btn1.BackColor = Color.Black;
                    btn1.ForeColor = Color.White;
                    btn1.Refresh();
                    Thread.Sleep(1000);
                    btn1.BackColor = Color.Green;
                    btn1.ForeColor = Color.Black;
                    btn1.Refresh();
                    Thread.Sleep(100);
                }
                if (_aiGrosseurTableau[iIndex] == 2)
                {
                    btn2.BackColor = Color.Black;
                    btn2.ForeColor = Color.White;
                    btn2.Refresh();
                    Thread.Sleep(1000);
                    btn2.BackColor = Color.Red;
                    btn2.ForeColor = Color.Black;
                    btn2.Refresh();
                    Thread.Sleep(100);
                }
                if (_aiGrosseurTableau[iIndex] == 3)
                {
                    btn3.BackColor = Color.Black;
                    btn3.ForeColor = Color.White;
                    btn3.Refresh();
                    Thread.Sleep(1000);
                    btn3.BackColor = Color.Yellow;
                    btn3.ForeColor = Color.Black;
                    btn3.Refresh();
                    Thread.Sleep(100);
                }
                if (_aiGrosseurTableau[iIndex] == 4)
                {
                    btn4.BackColor = Color.Black;
                    btn4.ForeColor = Color.White;
                    btn4.Refresh();
                    Thread.Sleep(1000);
                    btn4.BackColor = Color.Cyan;
                    btn4.ForeColor = Color.Black;
                    btn4.Refresh();
                    Thread.Sleep(100);
                }
            }
            tssl1.Text = sTourJoueur;
            statusStrip1.Update();
        }
        #endregion

        #region Vérification
        /// <summary>
        /// Auteur: Samuel Dextraze
        /// Description: Vérification des boutons choisies par le joueur.
        /// Date:2017/11/14
        /// </summary>
        private void ChoixBouton()
        {
            for (int iIndex = 0; iIndex < 1; iIndex++)
            {
                if (_bBouton1 == true || _bBouton2 == true || _bBouton3 == true || _bBouton4 == true)
                {
                    if (_aiGrosseurTableau[_BoutonAppuyer] == _iBouton) 
                    {
                        _bBouton1 = false;
                        _bBouton2 = false;
                        _bBouton3 = false;
                        _bBouton4 = false;
                        _BoutonAppuyer++; //Affirme qu'un bouton a été appuyé.

                        if (_iTour == _BoutonAppuyer) //Vérifie si le nombre de fois qu'un bouton a été appuyé correspond au nombre de bouton à appuyer.
                        {
                            _iTour++;
                            _iPoint++;
                            txtPoint.Text =_iPoint.ToString();
                            txtPoint.Update();
                            AffichageCouleur();
                            _BoutonAppuyer = 0;
                        }

                        else // Fait sortir de la boucle si il y a un ou plusieurs autres boutons à appuyers.
                        {
                            break;
                        }
                    }
                    if (_iPoint > _iRecord) //Fait monter le record si le nombre de point est plus élevé que ce dernier.
                    {
                        _iRecord = _iPoint;
                        txtRecord.Text = _iRecord.ToString();
                        txtRecord.Update();
                    }
                    else if (_aiGrosseurTableau[iIndex] != _iBouton) //Envoie un message d'erreur si le bouton appuyé n'est pas le bon.
                    {
                        tssl1.Text = sErreur;
                        statusStrip1.Update();
                        MessageBox.Show("Erreur!: Mauvaise couleur.", "Erreur");
                        _iPoint = 0;
                        txtPoint.Text = _iPoint.ToString();
                        txtPoint.Update();
                        _iErreur++;
                        txtErreur.Text = _iErreur.ToString();
                        txtErreur.Update();
                        _iTour = 1;
                        FaireTableau();
                        AffichageCouleur();
                    }
                }
            }
        }
        #endregion

        #region Bouton
        /// <summary>
        /// Auteur:Samuel Dextraze
        /// Description: Bouton Démarage et arrêt.
        /// Date:2017/11/14
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDémarrer_Click(object sender, EventArgs e)
        {
            if (btnDémarrer.Text == "Arrêter") // Bouton pour redémarrer le jeu.
            {
                _iTour = 1;
                txtErreur.Text = 0.ToString();
                txtErreur.Update();
                _iPoint = 0;
                txtPoint.Text = 0.ToString();
                txtPoint.Update();
                FaireTableau();
                AffichageCouleur();
            }
            if (btnDémarrer.Text == "&Démarrer") //Bouton pour démarrer le jeu et changer le texte du bouton à "Arrêter".
            {
                tssl1.Text = sAnimation.ToString();
                FaireTableau();
                AffichageCouleur();
                btnDémarrer.Text = "Arrêter";
                txtErreur.Text = 0.ToString();
                txtPoint.Text = 0.ToString();
            }
        }
        
        /// <summary>
        /// Auteur:Samuel Dextraze
        /// Description: Bouton 1
        /// Date:2017/11/14
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1_Click(object sender, EventArgs e)
        {
            // Bouton 1
            _iBouton = 1;
            _bBouton1 = true;
            ChoixBouton();
        }
        /// <summary>
        /// Auteur:Samuel Dextraze
        /// Description: Bouton 2
        /// Date:2017/11/14
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn2_Click(object sender, EventArgs e)
        {
            // Bouton 2
            _iBouton = 2;
            _bBouton2 = true;
            ChoixBouton();
        }
        /// <summary>
        /// Auteur:Samuel Dextraze
        /// Description: Bouton 3
        /// Date:2017/11/14
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn3_Click(object sender, EventArgs e)
        {
            // Bouton 3
            _iBouton = 3;
            _bBouton3 = true;
            ChoixBouton();
        }
        /// <summary>
        /// Auteur:Samuel Dextraze
        /// Description: Bouton 4
        /// Date:2017/11/14
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn4_Click(object sender, EventArgs e)
        {
            // Bouton 4
            _iBouton = 4;
            _bBouton4 = true;
            ChoixBouton();
        }
        #endregion
    }   
}
