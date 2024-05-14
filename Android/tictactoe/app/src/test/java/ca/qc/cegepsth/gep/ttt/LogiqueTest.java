package ca.qc.cegepsth.gep.ttt;

import org.junit.Assert;
import org.junit.Test;
import org.junit.*;

/**
 * @author sdenis@cegepsth.qc.ca
 * <p>
 * Jeu de tests pour valider la detection des
 * - parties gagnantes et parties nulles
 * - Positions invalides
 */
public class LogiqueTest implements EvenementsTTT {

    Logique jeu;
    Joueur gagnant;
    Joueur tour;
    boolean matchNul;
    boolean dejaOccuppe;



    @Override
    public void auTourDe(Joueur joueur) {
        tour=joueur;
    }

    @Override
    public void aGagne(Joueur joueur) {
        gagnant=joueur;
    }

    @Override
    public void cartePleine() {
        if(gagnant==null) matchNul=true;
    }

    @Override
    public void positionDejaOccuppee() {
        dejaOccuppe=true;
    }

    /**
     * Utilitaire pour jouer une séquence à deux joueurs.
     *
     * Ne peut être utilisé contre un robot/AI car la réponse
     * de l'adversaire n'est pas déterministe si on ne connait
     * pas l'implémentation.
     *
     * @param sequence positions à jouer
     */
    private void joueSequence(int... sequence) {
        for (int position : sequence) {
            try {
                jeu.jouePosition(position);
            } catch (PositionInvalide positionInvalide) {
                Assert.fail("Position invalide");
            }
        }
    }

    @Before
    public void setUp() {
        // reinitialiser le jeu
        tour = Joueur.X;
        jeu = new Logique(this,tour);
        gagnant=null;
        matchNul = false;
        dejaOccuppe=false;
    }

    @Test
    public void getJoueur() {
        try {
            jeu.jouePosition(1);
            Assert.assertEquals(jeu.getJoueur(1),Joueur.X);
        } catch (PositionInvalide positionInvalide) {
            Assert.fail("Position invalide");
        }
    }

    @Test
    public void verticale1() {
        joueSequence(1, 2, 4, 5, 7);
        Assert.assertEquals(gagnant, Joueur.X);
    }

    @Test
    public void verticale2() {
        joueSequence(2, 3, 5, 6, 8);
        Assert.assertEquals(gagnant, Joueur.X);
    }

    @Test
    public void verticale3() {
        joueSequence(3, 1, 6, 5, 9);
        Assert.assertEquals(gagnant, Joueur.X);
    }

    @Test
    public void horizontal1() {
        joueSequence(1, 4, 2, 5, 3);
        Assert.assertEquals(gagnant, Joueur.X);
    }

    @Test
    public void horizontal2() {
        joueSequence(4, 1, 5, 2, 6);
        Assert.assertEquals(gagnant, Joueur.X);
    }

    @Test
    public void horizontal3() {
        joueSequence(7, 4, 8, 5, 9);
        Assert.assertEquals(gagnant, Joueur.X);
    }

    @Test
    public void diagonale1() {
        joueSequence(1, 2, 5, 3, 9);
        Assert.assertEquals(gagnant, Joueur.X);
    }

    @Test
    public void diagonale2() {
        joueSequence(3, 2, 5, 1, 7);
        Assert.assertEquals(gagnant, Joueur.X);
    }

    @Test
    public void matchNul() {
        joueSequence(1,2,5,9,3,7,8,4,6);
        Assert.assertTrue(matchNul);
    }
}