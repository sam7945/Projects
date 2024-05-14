package ca.qc.cegepsth.gep.ttt;


/**
 *
 * @author Stephane
 */
public interface EvenementsTTT {

    /**
     * Est appele pour signaler que le jeu est en attente d'une action du joueur specifie.
     *
     * @param joueur
     */
    public void auTourDe(Joueur joueur);

    /**
     * Est appele quand la partie est terminee par la victoire d'un joueur.
     *
     * @param joueur
     */
    public void aGagne(Joueur joueur) ;

    /**
     * Est appele quand la partie est terminee par un match nul.
     */
    public void cartePleine();

    /**
     * Est appele quand le joueur essaie de jouer sur une case occupee
     */
    public void positionDejaOccuppee();
}
