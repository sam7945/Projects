#include "motcroise.h"

/**
 * Affiche la solution du mot croise
 *
 * @param nom_fichier   Nom du fichier contenant la grille de mot croise et ses
 * mots à rechercher
 * @param mot_croise    Objet MotCroise pré-initialisé
 */
void afficher_solution_mot_cacher(char* nom_fichier, mot_croise* mot_croise) {
   FILE* fichier = ouvrir_fichier(nom_fichier);
   if (fichier) {
      mot_croise = peupler_mot_croise(fichier, mot_croise);
      fermer_fichier(fichier);
      char* mot_cacher = resoudre_mot_croise(mot_croise);
      fprintf(stdout, "%s", mot_cacher);
   }
   else
      fprintf(stdout, "Nom de fichier invalide!");
}



int main(int argc, char** argv) {
   if (argc == 2) {
      char* nom_fichier = argv[1];
      mot_croise* mot_croise = initialiser_mot_croiser();
      afficher_solution_mot_cacher(nom_fichier, mot_croise);
   }
   else {
      fprintf(stderr, "Nombre d'argument invalide!");
   }
   return 0;
}