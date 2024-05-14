#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#include <errno.h>

#ifndef MOT_CROISE_H
#define MOT_CROISE_H

#define HAUTEUR 12
#define LARGEUR 12
#define TAILLEBUFFER 50


// Type boolean : false, true
typedef enum { false, true } boolean;

typedef struct Lettre lettre;
struct Lettre
{
   char caractere;   // Caractère
   boolean biffer;   // Boolean: Trouvé dans la grille?
};

typedef struct Grille grille;
struct Grille
{
   char* mot_cacher;                         // Mot caché de la grille
   lettre grille[LARGEUR][HAUTEUR];   // Grille de lettre
};

typedef struct Mot mot;
struct Mot {
   char* mot;          // String mot
   int longeur;        // Longueur du mot 
   boolean trouver;    // Mot trouvé?
   mot* suivant;// Mot suivant de la liste chainé
};

typedef struct MotCroise mot_croise;
struct MotCroise {
   mot* sommet_mot_croise;   // Sommet de la liste chainé
   grille grille;            // Grille du mot croisé
};

/**
 * Prend un nom de fichier et l'ouvre
 *
 * @param fichier_nom   Le nom du fichier
 * @return              Le fichier ouvert et prêt à être lu
 */
FILE* ouvrir_fichier(char* fichier_nom);

/**
 * Initialise une structure MotCroise
 *
 * @return  Retourne une instance de struct MotCroise*
 */
mot_croise* initialiser_mot_croiser();

/**
 * Prend un fichier et peuple le contenue de mot_croise avec
 *
 * @param fichier    Fichier à lire
 * @param mot_croise struct MotCroise* préinitialisé(initialiser_mot_croiser())
 * @return           La struct MotCroise* peuplé
 */
mot_croise* peupler_mot_croise(FILE* fichier, mot_croise* mot_croise);


/**
 * Ferme le fichier spécifié
 *
 * @param fichier  Fichier à fermer
 */
void fermer_fichier(FILE* fichier);



/**
 * Résoud le mot croisé avec les informations collectées
 *
 * @param mot_croise    MotCroise contenant la grille et les mots listés a
 *                      rechercher
 * @return              La solution du mot croisé
 */
char* resoudre_mot_croise(mot_croise* mot_croise);


#endif 