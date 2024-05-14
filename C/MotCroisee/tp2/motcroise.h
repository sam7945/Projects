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
   char caractere;   // Caract�re
   boolean biffer;   // Boolean: Trouv� dans la grille?
};

typedef struct Grille grille;
struct Grille
{
   char* mot_cacher;                         // Mot cach� de la grille
   lettre grille[LARGEUR][HAUTEUR];   // Grille de lettre
};

typedef struct Mot mot;
struct Mot {
   char* mot;          // String mot
   int longeur;        // Longueur du mot 
   boolean trouver;    // Mot trouv�?
   mot* suivant;// Mot suivant de la liste chain�
};

typedef struct MotCroise mot_croise;
struct MotCroise {
   mot* sommet_mot_croise;   // Sommet de la liste chain�
   grille grille;            // Grille du mot crois�
};

/**
 * Prend un nom de fichier et l'ouvre
 *
 * @param fichier_nom   Le nom du fichier
 * @return              Le fichier ouvert et pr�t � �tre lu
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
 * @param fichier    Fichier � lire
 * @param mot_croise struct MotCroise* pr�initialis�(initialiser_mot_croiser())
 * @return           La struct MotCroise* peupl�
 */
mot_croise* peupler_mot_croise(FILE* fichier, mot_croise* mot_croise);


/**
 * Ferme le fichier sp�cifi�
 *
 * @param fichier  Fichier � fermer
 */
void fermer_fichier(FILE* fichier);



/**
 * R�soud le mot crois� avec les informations collect�es
 *
 * @param mot_croise    MotCroise contenant la grille et les mots list�s a
 *                      rechercher
 * @return              La solution du mot crois�
 */
char* resoudre_mot_croise(mot_croise* mot_croise);


#endif 