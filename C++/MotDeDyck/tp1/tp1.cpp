#include <stdio.h>
#include <string.h>
#include <ctype.h>
#include <errno.h>

/**
 * Ce programme sert à prendre un mot de dyck en paramètre ou passé en fichier
 * et à le renvoyer sous forme de graph ou à renvoyé l'information demandé
 * en argument.
 *
 * @author Samuel Dextraze
 *
 */

#pragma warning(disable:4996)

#define TAILLE_MOT 40
#define TAILLEBUF 100
#define USAGE "\
Usage: %s [HEIGHT,AREA] <LETTER 1> <LETTER 2> <WORD>\n\
\n\
Draws on an ASCII path of dycks word. The dycks word is provided on stdin and\n\
the result is printed on stdout. The length of the word must not exceed 40 characters.\n\
\n\
If no argument is provided, the program prints this help and exit.\n\
\n\
Program parameters :\n\
  HEIGHT                    Optional parameter to calculate the height of the\n\
                            path under the word of dyck.\n\
  AREA                      Optional parameter to calculate the height of\n\
                            the path under the word of dyck.\n\
  LETTER 1, LETTER 2        Define the alphabet of the word.\n\
  WORD                      Word of dyck to draw.\n\
  "

typedef enum { false, true } boolean;
typedef enum
{
   OK = 0,
   ERREUR_ARGUMENTS_INVALIDES = 1,
   ERREUR_DONNEES_INVALIDES = 2,
   ERREUR_MOT_TROP_LONG = 3,
   ERREUR_LETTRE_INTERDITE = 4,
   ERREUR_MOT_NON_EQUILIBRE = 5
} Statut;

typedef struct
{
   char mot[TAILLE_MOT]; //Le mot saisi
   char haut;            //Caractere ascendant
   char bas;             //Caractere descendant
   int statut;
   int longeurMot;
   int hauteur;
   int hauteurCourante;
   int aire;
   boolean affAire;
   boolean affHauteur;


} MotDeDyck;



/**
 * Prend le mot sous forme de texte et le convertie sous forme haut(/), bas(\).
 *
 * @param tableauMots 	Mot de dyck sous forme de texte
 * @param newTableau 	Pointeur vers le nouveau texte qui servira au print
 * @param taille 		Taille du mot de dyck
 * @param motPlus 		Caractère de haut du mot de dyck
 * @param motMoin 		Caractère de bas du mot de dyck
 */
void motVersTableau1D(char* tableauMots, char* newTableau, int taille, char motPlus) {
   for (int i = 0; i < taille; i++) {
      newTableau[i] = (tableauMots[i] == motPlus) ? '/' : '\\';
   }

}

/**
 * Prend un le tableau 1D contenant les symboles haut(/) bas(\) du mot de
 * dyck et le convertie en 2D
 *
 * @param tableau 		Tableau des caractères / et \
 * @param tableau2D 	Tableau 2D pré-initialisé
 * @param tailleX 		Longeur total du mot (max 40)
 * @param tailleY 		Hauteur maximal du mot
 */
void unDVersTableau2D(char* tableau, char tableau2D[TAILLE_MOT][TAILLE_MOT], int tailleX, int tailleY) {
   int y = 0;
   for (int i = 0; i < tailleX; i++) {
      if (i == 0) {
         tableau2D[y][i] = '/';
      }
      else if (i == tailleX - 1) {
         tableau2D[0][i] = '\\';
      }
      else {
         if (tableau[i - 1] == tableau[i]) {
            y = (tableau[i] == '/') ? y + 1 : y - 1;
         }
         if (y >= 0) {
            tableau2D[y][i] = tableau[i];
         }
      }
   }
   for (int y = 0; y < tailleY; y++) {
      for (int x = 0; x < tailleX; x++) {
         if (tableau2D[y][x] == '\0') {
            tableau2D[y][x] = '*';
         }
      }
   }
}

/**
 * Affiche le manuel
 *
 * @param nomProgramme Le nom du programme à mettre dans le man
 */
void afficherMan(char* nomProgramme) {
   printf(USAGE, nomProgramme);
}

/**
 * Initialisé un MotDeDyck avec les valeur par défaut
 *
 * @return MotDeDyck
 */
MotDeDyck nouveauMot() {
   MotDeDyck mot; {
      mot.statut = OK,
         mot.hauteur = 0,
         mot.hauteurCourante = 0,
         mot.longeurMot = 0,
         mot.aire = 0,
         mot.haut = '\0',
         mot.affAire = false,
         mot.affHauteur = false,
         mot.bas = '\0';
   };
   return mot;
}

/**
 * Initialise un tableau 2D de taille spécifique
 *
 * @param tableau Tableau à initialiser
 */
void initTableau2D(char tableau[TAILLE_MOT][TAILLE_MOT]) {
   for (int i = 0; i < TAILLE_MOT; i++) {
      for (int j = 0; j < TAILLE_MOT; j++) {
         tableau[i][j] = '\0';
      }

   }

}

/**
 * Prend un MotDeDyck avec des données remplis et validées et imprime un graph,
 * l'aire ou la hauteur de ce dernier
 *
 * @param mot 	Mot remplis et pré-validé
 */
void printResultat(MotDeDyck mot) {
   char newTableau[TAILLE_MOT];
   char tableau2D[TAILLE_MOT][TAILLE_MOT];
   initTableau2D(tableau2D);
   if (mot.affAire == true) {
      printf("%i", mot.aire);
   }
   else if (mot.affHauteur == true) {
      printf("%i", mot.hauteur);
   }
   else {
      motVersTableau1D(mot.mot, newTableau, mot.longeurMot, mot.haut);
      unDVersTableau2D(newTableau, tableau2D, mot.longeurMot, mot.hauteur);
      char out[TAILLE_MOT * TAILLE_MOT] = "";
      int pos = 0;
      for (int y = mot.hauteur - 1; y >= 0; y--)
      {
         for (int x = 0; x < mot.longeurMot; x++)
         {
            out[pos] = tableau2D[y][x];
            pos++;
         }
         out[pos] = '\n';
         pos++;
      }
      for (int i = 0; i < pos; i++)
      {
         printf("%c", out[i]);
      }
   }
}

/**
 * Imprime dans stdout l'erreur envoyé en paramètre
 *
 * @param statut	Type d'erreur
 */
void printErreur(int statut) {
   switch (statut)
   {
   case ERREUR_ARGUMENTS_INVALIDES:
      fprintf(stderr, "argument invalide\n");
      break;
   case ERREUR_DONNEES_INVALIDES:
      fprintf(stderr, "donnees invalides\n");
      break;
   case ERREUR_MOT_TROP_LONG:
      fprintf(stderr, "mot trop long\n");
      break;
   case ERREUR_LETTRE_INTERDITE:
      fprintf(stderr, "lettre interdite\n");
      break;
   case ERREUR_MOT_NON_EQUILIBRE:
      fprintf(stderr, "mot non equilibre\n");
      break;
   default:
      break;
   }
}

/**
 * Prend une variable MotDeDyck ainsi que les paramètre requis dépendament
 * de quel façon les données ont été mises dans les paramètres
 *
 * @param mot 				Mot de dyck initialisé
 * @param lettre1 			Lettre de haut ou NULL
 * @param lettre2 			Lettre de bas ou NULL
 * @param lettresMot 		Mot sans ses paramètres haut et bas, ou NULL
 * @param contenueFichier	Contenue d'un fichier extrait ou NULL
 * @return MotDeDyck
 */
MotDeDyck extraireMotFichier(MotDeDyck mot, char* lettre1, char* lettre2, char* lettresMot, char* contenueFichier) {
   boolean espaceMot = false;
   char caracter;
   int posHaut = 0;
   int posBas = 0;

   int posActuel = 0;
   int hauteurMax = 0;
   int posDansMot = 0;

   do
   {
      if (contenueFichier != NULL) {
         caracter = contenueFichier[posActuel];
      }
      else if (lettre1 == NULL || lettre2 == NULL || lettresMot == NULL)
         caracter = fgetc(stdin);
      else {
         if (mot.haut == '\0' && mot.bas == '\0') {
            mot.haut = *lettre1;
            mot.bas = *lettre2;
         }
         caracter = lettresMot[(posDansMot)];
      }
      if (caracter != '\t' && caracter != '\n' && caracter != EOF && caracter != '\0') {
         if (caracter != ' ') {
            if (mot.haut == '\0') {
               mot.haut = caracter;
               posHaut = posActuel;
               if (isalnum(mot.haut) == 0)
                  mot.statut = ERREUR_DONNEES_INVALIDES;
            }
            else if (mot.bas == '\0') {
               mot.bas = caracter;
               posBas = posActuel;
               if (posBas == posHaut + 1 || isalnum(mot.bas) == 0)
                  mot.statut = ERREUR_DONNEES_INVALIDES;
            }
            else {
               mot.mot[posDansMot] = caracter;
               posDansMot = posDansMot + 1;
               int compareMots = (mot.haut == mot.bas) ? 0 : 1;

               if (espaceMot || compareMots == 0) {
                  mot.statut = ERREUR_DONNEES_INVALIDES;
               }
               else if (posDansMot > (TAILLE_MOT)) {
                  mot.statut = ERREUR_MOT_TROP_LONG;
               }
               else if (caracter == mot.haut) {
                  if (mot.hauteurCourante > 0)
                     mot.aire = mot.aire + (mot.hauteurCourante - 1);

                  mot.hauteurCourante = mot.hauteurCourante + 1;
                  if (hauteurMax < mot.hauteurCourante)
                     hauteurMax = mot.hauteurCourante;
               }
               else if (caracter == mot.bas) {
                  if (mot.hauteurCourante - 1 > 0)
                     mot.aire = mot.aire + (mot.hauteurCourante);

                  mot.hauteurCourante = mot.hauteurCourante - 1;
                  mot.aire = mot.aire + 1;
                  if (mot.hauteurCourante < 0)
                     mot.statut = ERREUR_MOT_NON_EQUILIBRE;
               }
               else {
                  mot.statut = ERREUR_LETTRE_INTERDITE;
               }
            }
         }
         else if (caracter == ' ' && (posDansMot) > 0) {
            espaceMot = true;
         }
         posActuel = posActuel + 1;
      }
   } while (caracter != EOF && mot.statut == OK && caracter != '\0' && caracter != '\n');
   mot.hauteur = hauteurMax;
   mot.longeurMot = posDansMot;
   return mot;
}

/**
 * Vérifie si les paramètres envoyé sont valides
 *
 * @param lettre1 		Première lettre du MotDeDyck
 * @param lettre2  		Deuxième lettre du MotDeDyck
 * @param motComplet 	Mot de dyck
 * @return boolean
 */
boolean verificationParams(char* lettre1, char* lettre2, char* motComplet) {
   if (lettre1[0] != '\0' && lettre1[1] == '\0' && isalnum(lettre1[0]) != 0)
      if (lettre2[0] != '\0' && lettre2[1] == '\0' && isalnum(lettre2[0]) != 0)
         if (motComplet[0] != '\0')
            return true;
   return false;
}

/**
 * Prend les arguments passés en commande et renvoie le mot en fonction.
 *
 * @param mot	MotDeDyck initialisé
 * @param argc 	Nombre d'argument passé en paramètre
 * @param argv 	Arguments passés en paramètre
 * @return MotDeDyck
 */
MotDeDyck extraireMotArgs(MotDeDyck mot, int argc, char** argv) {
   char* lettre1;
   char* lettre2;
   char* motComplet;
   if (argc == 4) {
      lettre1 = argv[1];
      lettre2 = argv[2];
      motComplet = argv[3];
   }
   else {
      lettre1 = argv[2];
      lettre2 = argv[3];
      motComplet = argv[4];
   }
   if (verificationParams(lettre1, lettre2, motComplet) == true)
      mot = extraireMotFichier(mot, lettre1, lettre2, motComplet, NULL);
   else
      mot.statut = ERREUR_DONNEES_INVALIDES;
   return mot;
}


/**
 * Prend certains paramètres et determine si les données peuvent faire un motdedyck
 * ou s'il faut afficher le manuel
 *
 * @param mot 				Mot initialisé servant a stocker les données
 * @param argv 				Arguments passés en commande
 * @param contenueFichier 	Contenue du fichier contenant les données du MotDeDyck
 * @return MotDeDyck
 */
MotDeDyck extractionFichier(MotDeDyck mot, char** argv, char* contenueFichier) {
   int bufferSize = fseek(stdin, 0, SEEK_END);
   int bufferSize2 = ftell(stdin);
   if (bufferSize <= 0 && bufferSize2 <= 0 && contenueFichier == NULL) {
      afficherMan(argv[0]);
   }
   else {
      rewind(stdin);
      mot = extraireMotFichier(mot, '\0', '\0', '\0', contenueFichier);
   }
   return mot;
}


/**
 * Ouvre le fichier envoyé en paramètre, retourne
 * le fichier sous format texte ou NULL, s'il y a une erreur.
 *
 * @param buffer 		Pointeur de char vers lequel sera stocker le texte
 * @param fichierNom 	Nom du fichier à lire
 * @return char*: Texte contenue dans le fichier ou NULL
 */
char* ouvertureFichier(char* buffer, char* fichierNom) {
   FILE* fichier = fopen(fichierNom, "r");
   if (fichier == NULL) {
      buffer = NULL;
   }
   else {
      while (fgets(buffer, TAILLEBUF, fichier) != NULL) {};
      if (fclose(fichier) == EOF) {}
   }
   return buffer;
}
/**
 * Détermine quel est la manières par laquel ont été passé les paramètres
 * dans la commande et lance l'extraction du mot en fonction des arguments
 *
 * @param mot 	Variable MotDeDyck dans lequel sera placé le mot
 * @param argc  Nombre d'arguments passé en paramètre
 * @param argv 	Argument(s) passé(s) en paramètre
 * @return Retourne un motDeDyck
 */
MotDeDyck choixTypeExtraction(MotDeDyck mot, int argc, char** argv) {
   if (argc > 1) {
      if (argc == 4) {
         mot = extraireMotArgs(mot, argc, argv);
      }
      else if (argc == 5 || argc == 2 || argc == 3) {
         char* argument = argv[1];
         char* contenue = NULL;
         if (argc == 2 || argc == 3) {
            char buffer[TAILLEBUF + 1];
            contenue = ouvertureFichier(buffer, argv[argc - 1]);
         }

         if (((strcmp("aire", argument) != 0 && strcmp("hauteur", argument) != 0) && contenue == NULL) || (argc > 3 && argc != 5))
            mot.statut = ERREUR_ARGUMENTS_INVALIDES;
         else if (strcmp("aire", argument) == 0)
            mot.affAire = true;
         else if (strcmp("hauteur", argument) == 0)
            mot.affHauteur = true;


         if (argc == 5) {
            mot = extraireMotArgs(mot, argc, argv);
         }
         else {
            mot = extractionFichier(mot, argv, contenue);
         }
      }
   }
   else {
      mot = extractionFichier(mot, argv, NULL);
   }
   return mot;
}

/**
 * Classe main de MotDeDyck
 *
 * @param argc Nombre d'argument
 * @param argv Arguments
 * @return int
 */
int main(int argc, char** argv) {
   MotDeDyck mot = nouveauMot();

   mot = choixTypeExtraction(mot, argc, argv);

   if (mot.statut == OK && mot.hauteurCourante != 0)
      mot.statut = ERREUR_MOT_NON_EQUILIBRE;

   if (mot.statut != OK) {
      printErreur(mot.statut);
   }
   else {
      printResultat(mot);
   }

   return 0;
}