﻿
namespace TP5
{
    /// <summary>
    /// Classe de constantes de l'application.
    /// </summary>
    public static class CstApplication
    {
        public static int NOMBRE_BITS_Y;
        //Taille maximale de l'interface de dessin.
        public const int TAILLEDESSINY = 64;
        public const int TAILLEDESSINX = 64;
        //Constante d'apprentissage pour le perceptron
        public const double CONSTANTEAPPRENTISSAGE = 0.01;
        //Critère de convergence pour le perceptron.
        public const int MAXITERATION = 20;
        public const int POURCENTCONVERGENCE = 96;

        //Taille du trait lors du dessin.
        public const int LARGEURTRAIT = 4;
        public const int HAUTEURTRAIT = 4;

        //Valeur vrai ou fausse pour le perceptron
        public const int VRAI = 1;
        public const int FAUX = -1;

        //Code d'erreur (pas nécessaire).
        public const int ERREUR = -1;
        public const int OK = 0;

        //Nombre maximale de permutation pour répartir les échantillons(pas nécessaire).
        public const int MAXPERMUTATION = 6000;

    }
}
