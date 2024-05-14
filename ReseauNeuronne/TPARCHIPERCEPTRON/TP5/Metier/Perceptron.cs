using System;
using System.Collections;
using System.Collections.Generic;

namespace TP5.Metier
{
    /// <summary>
    /// Classe du perceptron. Permet de faire l'apprentissage automatique sur un échantillon d'apprentissage. 
    /// </summary>
    public class Perceptron :IPerceptron
    {
        private double _cstApprentissage;
        private double[] _poidsSyn;
        private string _reponse = "?";

        public string Reponse
        {
            get { return _reponse; }
        }

        /// <summary>
        /// Constructeur de la classe. Crée un perceptron pour une réponse(caractère) qu'on veut identifier le pattern(modèle)
        /// </summary>
        /// <param name="reponse">La classe que défini le perceptron</param>
        public Perceptron(string reponse)
        {
            _cstApprentissage = CstApplication.CONSTANTEAPPRENTISSAGE;
            _reponse = reponse;
        }

        /// <summary>
        /// Faire l'apprentissage sur un ensemble de coordonnées. Ces coordonnées sont les coordonnées de tous les caractères analysés. 
        /// </summary>
        /// <param name="lstCoord">La liste de coordonnées pour les caractères à analysés.</param>
        /// <returns>Les paramètres de la console</returns>
        public string Entrainement(List<ICoordDessin> lstCoord)
        {
            if (lstCoord.Count < 1)
                return "Les coordonnées sont vides";

            Random r = new Random();

            double pourcentErreur;
            double erreurRelative;
            int nbReponse = lstCoord.Count;
            int nbErreurs = 0;
            int resultatEstime;
            int nbAttributs = lstCoord[0].BitArrayDessin.Count;
            int[] reponses = new int[nbReponse];
            int indiceRep = 0;
            int nbIteration = 0;
            string resultat = "";

            foreach (ICoordDessin c in lstCoord)
            {
                reponses[indiceRep] = _reponse == c.Reponse ? CstApplication.VRAI : CstApplication.FAUX;
                indiceRep++;
            }

            _poidsSyn = new double[nbAttributs];
            for (int i = 0; i < nbAttributs; i++)
                _poidsSyn[i] = r.NextDouble();

            do
            {
                nbErreurs = 0;
                int indexReponse = 0;
                foreach (ICoordDessin c in lstCoord)
                {
                    resultatEstime = ValeurEstime(_poidsSyn, c.BitArrayDessin);
                    if (resultatEstime != reponses[indexReponse])
                    {
                        erreurRelative = reponses[indexReponse] - resultatEstime;
                        _poidsSyn[0] += _cstApprentissage * erreurRelative;
                        for (int j = 1; j < nbAttributs; j++)
                            _poidsSyn[j] += _cstApprentissage * erreurRelative * (c.BitArrayDessin[j - 1] == true ? (double)CstApplication.VRAI : (double)CstApplication.FAUX);
                        nbErreurs++;
                    }
                    indexReponse++;
                }
                pourcentErreur = (nbReponse - (double)nbErreurs) / (double)nbReponse * 100;
                resultat += "\n\r Le taux de succès est de" + pourcentErreur + " %. pour " + _reponse + "\n\r";
                nbIteration++;
            }
            while (nbErreurs != 0 && pourcentErreur < CstApplication.POURCENTCONVERGENCE && nbIteration < CstApplication.MAXITERATION);

            return resultat;
        }

        /// <summary>
        /// Calcul la valeur(vrai ou faux) pour un les coordonnées d'un caractère. Permet au perceptron d'évaluer la valeur de vérité.
        /// </summary>
        /// <param name="vecteurSyn">Les poids synaptiques du perceptron</param>
        /// <param name="entree">Le vecteur de bit correspondant aux couleurs du caractère</param>
        /// <returns>Vrai ou faux</returns>
        public int ValeurEstime(double[] vecteurSyn, BitArray entree)
        {
            double sum = vecteurSyn[0];
            for (int i = 1; i < vecteurSyn.Length; i++)
                sum += vecteurSyn[i] * (entree[i - 1] == true ? (double)CstApplication.VRAI : (double)CstApplication.FAUX);
            return (sum >= 0) ? CstApplication.VRAI : CstApplication.FAUX;
        }

        /// <summary>
        /// Interroge la neuronnes pour un ensembles des coordonnées(d'un caractère).
        /// </summary>
        /// <param name="coord"></param>
        /// <returns></returns>
        public bool TesterNeurone(ICoordDessin coord)
        {
            int resultatEstime = ValeurEstime(_poidsSyn, coord.BitArrayDessin);
            return resultatEstime == CstApplication.VRAI ? true : false;
        }

    }
}
