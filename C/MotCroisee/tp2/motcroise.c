#include "motcroise.h"

#pragma warning(disable:4996)

// Fonctions auxilliaires
// -------------------


/**
* Créer un objet Mot* et l'ajoute au sommet de la liste chainé de MotCroise
* 
* @param nouveau_string Mot sous format string
* @param longeur        Longueur du nouveau_string
* @param mot_croise     Mot croise avec grille
* 
*/
void allouer_nouveau_sommet(char* nouveau_string, int longueur, mot_croise* mot_croise) {
   mot* nouveau_mot = malloc(sizeof(mot));
   if (nouveau_mot) {
      nouveau_mot->longeur = longueur;
      nouveau_mot->trouver = false;
      nouveau_mot->mot = nouveau_string;
      nouveau_mot->suivant = mot_croise->sommet_mot_croise;
      mot_croise->sommet_mot_croise = nouveau_mot;
   }
}

/**
* Ajoute le mot de la ligne dans la liste des mots a chercher
* 
* @param ligne       Ligne contenant le mot à ajouté
* @param mot_croise  Mot croise
*/
void ajouter_ligne_mots(char* ligne, mot_croise* mot_croise) {
   int longueur_mot = 0;
   while (ligne[longueur_mot] != '\n' && ligne[longueur_mot] != '\0')
      longueur_mot++;
   char* mot = (char*)malloc((longueur_mot+1 * sizeof(char)));
   if (mot) {
      for (int i = 0; i < longueur_mot; i++)
         mot[i] = ligne[i];
      mot[longueur_mot] = '\0';
      allouer_nouveau_sommet(mot, longueur_mot, mot_croise);
   }
}

/**
* Ajoute les caractères de la ligne dans la grille du mot croise
* 
* @param ligne       Ligne contenant les caractères(sans espace) à mettre dans la grille
* @param position    Numéro de la ligne 0-11 de haut en bas
* @param mot_croise  Mot croise
*/
void ajouter_ligne_grille(char* ligne, int position, mot_croise* mot_croise) {
   int i = 0;
   int position_caractere = 0;
   while (ligne[i] != '\n') {
      if (isalnum(ligne[i])) {
         mot_croise->grille.grille[position][position_caractere].caractere = ligne[i];
         mot_croise->grille.grille[position][position_caractere].biffer = false;
         position_caractere++;
      }
      i++;
   }
}

/**
* Biffe les lettre dans le mot croise correspondant au mot
* 
* @param sommet         Sommet actuel(mot actuel) de la liste des mots
* @param mot_croise     Mot croise 
* @param x              Coordonnée x de la première lettre du mot
* @param y              Coordonnée y de la première lettre du mot
* @param changement_x   Direction en x à apporter lors de la recherche (+1(gauche), 0(même ligne) ou -1(droite))
* @param changement_y   Direction en y à apporter lors de la recherche (+1(bas), 0(même colonne) ou -1(haut))
*/
void biffer_mot(mot* sommet, mot_croise* mot_croise, int x, int y, int changement_x, int changement_y) {
   int diff_x = 0;
   int diff_y = 0;
   for (int position = 0; position < sommet->longeur; position++) {
      mot_croise->grille.grille[y + diff_y][x + diff_x].biffer = true;
      diff_x += changement_x;
      diff_y += changement_y;
   }
   sommet->trouver = true;
}

/**
* Choisi dans quel direction biffer un mot 
*
* @param sommet         Sommet actuel(mot actuel) de la liste des mots
* @param mot_croise     Mot croise
* @param x              Coordonnée x de la première lettre du mot
* @param y              Coordonnée y de la première lettre du mot
* @param verticale      Position (Horizontale:false, Verticale:true) du mot
* @param haut           Position (bas:false, haut:true) du mot
*/
void biffer_direction(mot* sommet, mot_croise* mot_croise, int x, int y, boolean verticale, boolean haut) {
   if (verticale == true && haut == true)
      biffer_mot(sommet, mot_croise, x, y, 0, -1);
   else if (verticale == true && haut == false)
      biffer_mot(sommet, mot_croise, x, y, 0, 1);
   else if (verticale == false && haut == true)
      biffer_mot(sommet, mot_croise, x, y, -1, 0);
   else if (verticale == false && haut == false)
      biffer_mot(sommet, mot_croise, x, y, 1, 0);
}

/**
* Vérifie si le mot à partir de coordonnées x,y se trouve vers le haut par rapport ces dernières
*
* @param sommet         Sommet actuel(mot actuel) de la liste des mots
* @param mot_croise     Mot croise
* @param x              Coordonnée x de la première lettre du mot
* @param y              Coordonnée y de la première lettre du mot
*/
void verifier_haut(mot* sommet, mot_croise* mot_croise, int x, int y) {
   int position = 0;
   while (sommet->longeur > position && sommet->mot[position] == mot_croise->grille.grille[y - position][x].caractere) {
      position++;
   }
   if (position == sommet->longeur)
      biffer_direction(sommet, mot_croise, x, y, true, true);
}

/**
* Vérifie si le mot à partir de coordonnées x,y se trouve vers le bas par rapport ces dernières
*
* @param sommet         Sommet actuel(mot actuel) de la liste des mots
* @param mot_croise     Mot croise
* @param x              Coordonnée x de la première lettre du mot
* @param y              Coordonnée y de la première lettre du mot
*/
void verifier_bas(mot* sommet, mot_croise* mot_croise, int x, int y) {
   int position = 0;
   while (sommet->longeur > position && sommet->mot[position] == mot_croise->grille.grille[y + position][x].caractere) {
      position++;
   }
   if (position == sommet->longeur)
      biffer_direction(sommet, mot_croise, x, y, true, false);
}

/**
* Vérifie si le mot est vers le haut ou le bas 
* 
* @param sommet         Sommet actuel(mot actuel) de la liste des mots
* @param mot_croise     Mot croise
* @param x              Coordonnée x de la première lettre du mot
* @param y              Coordonnée y de la première lettre du mot
*/
void verifier_verticale(mot* sommet, mot_croise* mot_croise, int x, int y) {
   if ((sommet->longeur - 1) <= y)
      verifier_haut(sommet, mot_croise, x, y);
   if ((sommet->longeur + (y - 1)) < HAUTEUR)
      verifier_bas(sommet, mot_croise, x, y);
}

/**
* Vérifie si le mot à partir de coordonnées x,y se trouve vers la gauche par rapport ces dernières
*
* @param sommet         Sommet actuel(mot actuel) de la liste des mots
* @param mot_croise     Mot croise
* @param x              Coordonnée x de la première lettre du mot
* @param y              Coordonnée y de la première lettre du mot
*/
void verifier_gauche(mot* sommet, mot_croise* mot_croise, int x, int y) {
   int position = 0;
   while (sommet->longeur > position && sommet->mot[position] == mot_croise->grille.grille[y][x - position].caractere) {
      position++;
   }
   if (position == sommet->longeur)
      biffer_direction(sommet, mot_croise, x, y, false, true);
}

/**
* Vérifie si le mot à partir de coordonnées x,y se trouve vers la gauche par rapport ces dernières
*
* @param sommet         Sommet actuel(mot actuel) de la liste des mots
* @param mot_croise     Mot croise
* @param x              Coordonnée x de la première lettre du mot
* @param y              Coordonnée y de la première lettre du mot
*/
void verifier_droite(mot* sommet, mot_croise* mot_croise, int x, int y) {
   int position = 0;
   while (sommet->longeur > position && sommet->mot[position] == mot_croise->grille.grille[y][x + position].caractere) {
      position++;
   }
   if (position == sommet->longeur)
      biffer_direction(sommet, mot_croise, x, y, false, false);
}
/**
* Vérifie si le mot est vers la gauche ou la droite
*
* @param sommet         Sommet actuel(mot actuel) de la liste des mots
* @param mot_croise     Mot croise
* @param x              Coordonnée x de la première lettre du mot
* @param y              Coordonnée y de la première lettre du mot
*/
void verifier_horizontal(mot* sommet, mot_croise* mot_croise, int x, int y) {
   if ((sommet->longeur - 1) <= x)
      verifier_gauche(sommet, mot_croise, x, y);
   if ((sommet->longeur + (x - 1)) < LARGEUR)
      verifier_droite(sommet, mot_croise, x, y);
}

/**
* Vérifie dans quel direction il est possible que le mot soit par rapport aux coordonnés de la première lettre
*
* @param sommet         Sommet actuel(mot actuel) de la liste des mots
* @param mot_croise     Mot croise
* @param x              Coordonnée x de la première lettre du mot
* @param y              Coordonnée y de la première lettre du mot
*/
void verifier_mot(mot* sommet, mot_croise* mot_croise, int x, int y) {
   if (((sommet->longeur - 1) <= y || ((sommet->longeur + (y - 1)) < HAUTEUR)) && sommet->trouver == false)
      verifier_verticale(sommet, mot_croise, x, y);
   if (((sommet->longeur - 1) <= x || ((sommet->longeur + (x - 1)) < LARGEUR)) && sommet->trouver == false)
      verifier_horizontal(sommet, mot_croise, x, y);

}

/**
* Vérifie chaques lettres de la grille pour y trouver une occurence de la première lettre du mot, 
* puis vérifie si le mot s'y trouve
*
* @param sommet         Sommet actuel(mot actuel) de la liste des mots
* @param mot_croise     Mot croise
*/
void verifier_lettres(mot* sommet, mot_croise* mot_croise) {
   for (int x = 0; x < LARGEUR; x++) {
      for (int y = 0; y < HAUTEUR; y++) {
         if (mot_croise->grille.grille[y][x].caractere == sommet->mot[0] && sommet->trouver == false)
            verifier_mot(sommet, mot_croise, x, y);
      }
   }
}

/**
* Trouve toutes les lettres non biffés et les ajoutes dans le mot 
*
* @param mot_croise     Mot croise
* @param mot            Mot string à remplir
*/
void rechercher_grille(mot_croise* mot_croise, char* mot) {
   int position = 0;
   for (int x = 0; x < LARGEUR; x++) {
      for (int y = 0; y < HAUTEUR; y++) {
         if (mot_croise->grille.grille[x][y].biffer == false) {
            mot[position] = mot_croise->grille.grille[x][y].caractere;
            position++;
         }
      }
   }
   mot[position] = '\0';
}

/**
* Récupère la longueur total du mot caché avec la grille résolue
*
* @param mot_croise     Mot croise
*/
int recuperer_longeur_mot_cacher(mot_croise* mot_croise) {
   int longueur_mot = 0;
   for (int x = 0; x < LARGEUR; x++) {
      for (int y = 0; y < HAUTEUR; y++) {
         if (mot_croise->grille.grille[y][x].biffer == false)
            longueur_mot++;
      }
   }
   return longueur_mot;
}

/**
* Récupère le mot caché
*
* @param mot_croise     Mot croise
*/
char* recuperer_mot_cacher(mot_croise* mot_croise) {
   int longueur_mot = recuperer_longeur_mot_cacher(mot_croise);
   char* mot = malloc(longueur_mot * sizeof(char));
   rechercher_grille(mot_croise, mot);
   return mot;
}

// Implémentation
// --------------


FILE* ouvrir_fichier(char* fichier_nom) {
   FILE* fichier = fopen(fichier_nom, "r");
   return fichier;
}

mot_croise* initialiser_mot_croiser() {
   mot_croise* mot = (mot_croise*)malloc(sizeof(mot_croise));
   if(mot)
      mot->sommet_mot_croise = NULL;
   return mot;
}

void fermer_fichier(FILE* fichier) {
   if (fichier)
      fclose(fichier);
}

mot_croise* peupler_mot_croise(FILE* fichier, mot_croise* mot_croise) {
   char sortie[TAILLEBUFFER];
   int ligne = 0;
   while (fgets(sortie, TAILLEBUFFER, fichier)) {
      if (ligne < HAUTEUR)
         ajouter_ligne_grille(sortie, ligne, mot_croise);
      else if (ligne > HAUTEUR)
         ajouter_ligne_mots(sortie, mot_croise);
      ligne++;
   };
   return mot_croise;
}

char* resoudre_mot_croise(mot_croise* mot_croise) {
   mot* sommet = mot_croise->sommet_mot_croise;
   while (sommet) {
      verifier_lettres(sommet, mot_croise);
      sommet = sommet->suivant;
   }
   char* mot_cacher = recuperer_mot_cacher(mot_croise);
   mot_croise->grille.mot_cacher = mot_cacher;
   return mot_cacher;
}


