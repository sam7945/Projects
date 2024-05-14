package ca.qc.cegepsth.gep.ttt;
/**
 *
 * @author Stephane
 */
public abstract class Modele implements ActionsTTT{

    // Etat de la grille de jeu, null si vide
    Joueur  A1,A2,A3,
            B1,B2,B3,
            C1,C2,C3;

    Joueur joueurActif;

    EvenementsTTT interfaceUtilisateur;

    Modele(EvenementsTTT interfaceUtilisateur, Joueur joueurActif){
        this.interfaceUtilisateur = interfaceUtilisateur;
        this.joueurActif = joueurActif;
    }


}