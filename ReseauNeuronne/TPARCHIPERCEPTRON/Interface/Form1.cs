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

namespace Interface
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            //Créer un nouveau fichier d'entrainement après effacement
            if (userControlEntrainement1.NouveauFichierEntrainement == true)
            {
                try
                {
                    // vérifie si le fichier existe  
                    if (File.Exists(Path.Combine(userControlEntrainement1.EmplacementFichierEntrainement)))
                    {
                        // si le fichier est trouver l'efface 
                        File.Delete(Path.Combine(userControlEntrainement1.EmplacementFichierEntrainement));
                        Console.WriteLine("File deleted.");
                    }
                    else Console.WriteLine("File not found");
                }
                catch (IOException ioExp)
                {
                    Console.WriteLine(ioExp.Message);
                }
                //Créer le nouveau fichier
                if (!File.Exists(userControlEntrainement1.EmplacementFichierEntrainement))
                {
                    File.Create(userControlEntrainement1.EmplacementFichierEntrainement);
                }
                //Charge les données du fichier
                userControlEntrainement1.AnalyseEcriture.ChargerCoordonnees(userControlEntrainement1.EmplacementFichierEntrainement);
            }
            //Ouvre le fichier d'entrainement pour prendre les données
            else
            {
                //Créer un nouveau fichier si il n'y en a pas
                if (!File.Exists(userControlEntrainement1.EmplacementFichierEntrainement))
                {
                    File.Create(userControlEntrainement1.EmplacementFichierEntrainement);
                }
                //charge les coordonnées/perceptrons
                userControlEntrainement1.AnalyseEcriture.ChargerCoordonnees(userControlEntrainement1.EmplacementFichierEntrainement);
            }
        }
        /// <summary>
        /// Efface le dessin de l'entrainement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userControlEntrainement1_ButtonEraseClick(object sender, EventArgs e)
        {
            userControlEntrainement1.Dessin.EffacerDessin();
        }
        /// <summary>
        /// Entraine la valeur entrée dans le textbox avec le dessin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userControlEntrainement1_ButtonTrainClick(object sender, EventArgs e)
        {
            if (userControlEntrainement1.Valeur == "")
                MessageBox.Show("Vous devez entrer au moins une valeur à faire apprendre.");
            else
            {
                userControlEntrainement1.AnalyseEcriture.Entrainement(userControlEntrainement1.Dessin.Coordonnees, userControlEntrainement1.Valeur);
            }
        }
        /// <summary>
        /// Test le dessin correspondant pour trouver quel valeur il représente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userControlTest1_ButtonOkClick(object sender, EventArgs e)
        {
            if (userControlTest1.ModePhraseTest == true)
            {
                string result = userControlTest1.AnalyseEcriture.TesterPerceptron(userControlTest1.Dessin.Coordonnees);
                if (result == " ")
                {
                    userControlTest1.Resultat = "";
                }
                else
                {
                    userControlTest1.Resultat += result;
                }
            }
            else
            {
                userControlTest1.Resultat = userControlTest1.AnalyseEcriture.TesterPerceptron(userControlTest1.Dessin.Coordonnees);
            }
            userControlTest1.Dessin.EffacerDessin();
        }
        /// <summary>
        /// Sauvegarde des données lors de la fermeture de la form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            userControlEntrainement1.AnalyseEcriture.SauvegarderCoordonnees(userControlEntrainement1.EmplacementFichierEntrainement);
        }
    }
}
