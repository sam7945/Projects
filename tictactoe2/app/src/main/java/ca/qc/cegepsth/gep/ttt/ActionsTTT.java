package ca.qc.cegepsth.gep.ttt;

/**
 *
 * @author Stéphane
 */
public interface ActionsTTT {

    /**
     * Permet de savoir quel joueur occupe une position de la grille de jeu
     *
     * @param position chiffre de 1 à 9
     * @return le Joueur qui occupe la case, null si libre
     * @throws PositionInvalide si le chiffre n'est pas entre 0 et 9
     */
    public Joueur getJoueur(int position) throws PositionInvalide;

    /**
     * Place le symbole du joueur actif dans la case spécifiée.
     *
     * @param position chiffre de 1 à 9
     * @throws PositionInvalide si la case est occuppée ou le chiffre est hors jeu
     */
    public void jouePosition(int position) throws PositionInvalide;

}
