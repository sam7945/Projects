import org.junit.jupiter.api.Test;

import java.util.Iterator;
import java.util.NoSuchElementException;

import static org.junit.jupiter.api.Assertions.*;

class ListeEuclidienneTest {

    // estVide
    @Test
    void estVide1() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        assertTrue( c.estVide() );
    }

    // inserer, estVide
    @Test
    void inserer1Element() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );

        assertFalse( c.estVide() );
    }

    // taille
    @Test
    void taille0() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        assertEquals( 0, c.taille() );
    }

    // inserer, taille
    @Test
    void inserer2Elements() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );
        c.inserer( 10 );

        assertEquals( 2, c.taille() );
    }

    // inserer, taille
    @Test
    void inserer5Elements() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );
        c.inserer( 10 );
        c.inserer( 10 );
        c.inserer( 10 );
        c.inserer( 10 );

        assertEquals( 5, c.taille() );
    }

    @Test
    void lireLanceException() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        assertThrows( NoSuchElementException.class, () -> c.lire() );
    }

    @Test
    void lireNeLancePasException() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );

        assertDoesNotThrow( () -> c.lire() );
    }

    @Test
    void lire1element() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );

        assertEquals( 10, c.lire() );
    }

    @Test
    void lire2elements() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );
        c.inserer( 11 );

        assertEquals( 11, c.lire() );
    }

    @Test
    void lire5elements() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );
        c.inserer( 11 );
        c.inserer( 12 );
        c.inserer( 13 );
        c.inserer( 14 );

        assertEquals( 14, c.lire() );
    }

    @Test
    void avancerLanceException() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        assertThrows( ListeVideException.class, () -> c.avancer() );
    }

    @Test
    void avancerNeLancePasException() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );

        assertDoesNotThrow( () -> c.avancer() );
    }

    @Test
    void avancer1element() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );

        c.avancer();
        assertEquals( 10, c.lire() );
        c.avancer();
        assertEquals( 10, c.lire() );
        c.avancer();
        assertEquals( 10, c.lire() );
    }

    @Test
    void avancer2elements() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );
        c.inserer( 11 );

        c.avancer();
        assertEquals( 10, c.lire() );
        c.avancer();
        assertEquals( 11, c.lire() );
        c.avancer();
        assertEquals( 10, c.lire() );
        c.avancer();
        assertEquals( 11, c.lire() );
    }

    @Test
    void avancer3elements() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );
        c.inserer( 11 );
        c.inserer( 12 );

        c.avancer();
        assertEquals( 11, c.lire() );
        c.avancer();
        assertEquals( 10, c.lire() );
        c.avancer();
        assertEquals( 12, c.lire() );
        c.avancer();
        assertEquals( 11, c.lire() );
    }

    @Test
    void insererAvancer3elements() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );
        assertEquals( 10, c.lire() );

        c.inserer( 11 );
        assertEquals( 11, c.lire() );
        c.avancer();
        assertEquals( 10, c.lire() );

        c.inserer( 12 );
        assertEquals( 12, c.lire() );

        c.avancer();
        assertEquals( 10, c.lire() );
        c.avancer();
        assertEquals( 11, c.lire() );
        c.avancer();
        assertEquals( 12, c.lire() );
    }

    @Test
    void getDirection() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        assertEquals( ListeEuclidienne.Direction.HORAIRE, c.getDirection() );
    }

    @Test
    void getDirectionInsererLire() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );
        c.lire();

        assertEquals( ListeEuclidienne.Direction.HORAIRE, c.getDirection() );
    }

    @Test
    void getDirectionInsererAvancer() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );
        c.avancer();

        assertEquals( ListeEuclidienne.Direction.HORAIRE, c.getDirection() );
    }

    @Test
    void inverser() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inverser();

        assertEquals( ListeEuclidienne.Direction.ANTIHORAIRE, c.getDirection() );
    }

    @Test
    void inverserDouble() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inverser();
        c.inverser();

        assertEquals( ListeEuclidienne.Direction.HORAIRE, c.getDirection() );
    }

    @Test
    void ecrireLanceException() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        assertThrows( ListeVideException.class, () -> c.ecrire( 10 ) );
    }

    @Test
    void ecrireNeLancePasException() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );

        assertDoesNotThrow( () -> c.ecrire( 20 ) );
    }

    @Test
    void ecrire1case() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );
        c.ecrire( 20 );

        assertEquals( 20, c.lire() );
        assertEquals( 1, c.taille() );
        assertEquals(ListeEuclidienne.Direction.HORAIRE, c.getDirection() );
    }

    @Test
    void ecrire2case() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );
        c.ecrire( 20 );
        c.inserer( 11 );
        c.ecrire( 21 );

        assertEquals( 21, c.lire() );
        c.avancer();
        assertEquals( 20, c.lire() );
    }

    @Test
    void ecrire3fois2case() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );
        c.ecrire( 20 );
        c.inserer( 11 );
        c.ecrire( 21 );
        c.avancer();
        c.ecrire( 22 );

        assertEquals( 22, c.lire() );
        c.avancer();
        assertEquals( 21, c.lire() );
    }

    @Test
    void supprimerLanceException() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        assertThrows( ListeVideException.class, () -> c.supprimer() );
    }

    @Test
    void supprimerNeLancePasException() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );

        assertDoesNotThrow( () -> c.supprimer() );
    }

    @Test
    void supprimer1vers0() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );
        c.supprimer();

        assertTrue( c.estVide() );
    }

    @Test
    void supprimer2vers1() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );
        c.inserer( 11 );
        c.supprimer();

        assertEquals( 1, c.taille() );
        assertEquals( 10, c.lire() );
    }

    @Test
    void supprimer2vers0() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );
        c.inserer( 11 );
        c.supprimer();
        c.supprimer();

        assertTrue( c.estVide() );
    }

    @Test
    void supprimer3vers2() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );
        c.inserer( 11 );
        c.inserer( 12 );

        c.supprimer();

        assertEquals( 2, c.taille() );
        assertEquals( 11, c.lire() );
        c.avancer();
        assertEquals( 10, c.lire() );
    }

    @Test
    void supprimer3vers1() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );
        c.inserer( 11 );
        c.inserer( 12 );

        c.supprimer();
        assertEquals( 11, c.lire() );

        c.supprimer();
        assertEquals( 10, c.lire() );
    }

    @Test
    void supprimerinverse3vers1() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inverser();

        c.inserer( 10 );
        c.inserer( 11 );
        c.inserer( 12 );

        c.supprimer();
        assertEquals( 11, c.lire() );

        c.supprimer();
        assertEquals( 10, c.lire() );

        assertEquals( ListeEuclidienne.Direction.ANTIHORAIRE, c.getDirection() );
    }

    @Test
    void constN0null() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>( 0, null );

        assertTrue( c.estVide() );
    }

    @Test
    void constN1() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>( 1, 10 );

        assertEquals( 1, c.taille() );
        assertEquals( 10, c.lire() );
        assertEquals( ListeEuclidienne.Direction.HORAIRE, c.getDirection() );
    }

    @Test
    void constN5() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>( 5, 10 );

        assertEquals( 5, c.taille() );
        assertEquals( 10, c.lire() );
        assertEquals( ListeEuclidienne.Direction.HORAIRE, c.getDirection() );
    }

    @Test
    void insererTout_0_0() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();
        ListeEuclidienne<Integer> c2 = new ListeEuclidienne<>();

        c.insererTout( c2 );

        assertTrue( c.estVide() );
        assertTrue( c2.estVide() );
    }

    @Test
    void insererTout_2_0() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );
        c.inserer( 11 );

        ListeEuclidienne<Integer> c2 = new ListeEuclidienne<>();

        c.insererTout( c2 );

        assertEquals( 2, c.taille() );
        assertEquals( 11, c.lire() );
        c.avancer();
        assertEquals( 10, c.lire() );

        assertTrue( c2.estVide() );
    }

    @Test
    void insererTout_0_2() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();
        ListeEuclidienne<Integer> c2 = new ListeEuclidienne<>();

        c2.inserer( 10 );
        c2.inserer( 11 );

        c.insererTout( c2 );

        assertEquals( 2, c.taille() );
        assertEquals( 11, c.lire() );
        c.avancer();
        assertEquals( 10, c.lire() );

        assertEquals( 2, c2.taille() );
    }

    @Test
    void insererTout_3_2() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 12 );
        c.inserer( 11 );
        c.inserer( 10 );

        ListeEuclidienne<Integer> c2 = new ListeEuclidienne<>();

        c2.inserer( 16 );
        c2.inserer( 15 );

        c.insererTout( c2 );

        assertEquals( 5, c.taille() );
        assertEquals( 10, c.lire() );
        c.avancer();
        assertEquals( 11, c.lire() );
        c.avancer();
        assertEquals( 12, c.lire() );
        c.avancer();
        assertEquals( 15, c.lire() );
        c.avancer();
        assertEquals( 16, c.lire() );

        assertEquals( 2, c2.taille() );
    }

    @Test
    void insererTout_3_2i() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 12 );
        c.inserer( 11 );
        c.inserer( 10 );
        c.inverser();

        ListeEuclidienne<Integer> c2 = new ListeEuclidienne<>();

        c2.inserer( 16 );
        c2.inserer( 15 );

        c.insererTout( c2 );

        assertEquals( 5, c.taille() );
        assertEquals( 10, c.lire() );
        c.avancer();
        assertEquals( 12, c.lire() );
        c.avancer();
        assertEquals( 11, c.lire() );
        c.avancer();
        assertEquals( 15, c.lire() );
        c.avancer();
        assertEquals( 16, c.lire() );

        assertEquals( 2, c2.taille() );
    }

    @Test
    void zip_3_3() {
        ListeEuclidienne<Integer> c1 = new ListeEuclidienne<>();

        c1.inserer( 10 );
        c1.inserer( 11 );
        c1.inserer( 12 );

        ListeEuclidienne<Integer> c2 = new ListeEuclidienne<>();

        c2.inserer( 1 );
        c2.inserer( 2 );
        c2.inserer( 3 );

        ListeEuclidienne<Integer> cr = ListeEuclidienne.zip( c1, c2, 3, ( x, y ) -> x + y );

        assertEquals( 3, cr.taille() );
        assertEquals( 15, cr.lire() );
        cr.avancer();
        assertEquals( 13, cr.lire() );
        cr.avancer();
        assertEquals( 11, cr.lire() );

        assertEquals( 3, c1.taille() );
        assertEquals( 12, c1.lire() );
        c1.avancer();
        assertEquals( 11, c1.lire() );
        c1.avancer();
        assertEquals( 10, c1.lire() );

        assertEquals( 3, c2.taille() );
        assertEquals( 3, c2.lire() );
        c2.avancer();
        assertEquals( 2, c2.lire() );
        c2.avancer();
        assertEquals( 1, c2.lire() );
    }

    @Test
    void zip_3_3_1() {
        ListeEuclidienne<Integer> c1 = new ListeEuclidienne<>();

        c1.inserer( 10 );
        c1.inserer( 11 );
        c1.inserer( 12 );

        ListeEuclidienne<Integer> c2 = new ListeEuclidienne<>();

        c2.inserer( 1 );
        c2.inserer( 2 );
        c2.inserer( 3 );

        ListeEuclidienne<Integer> cr = ListeEuclidienne.zip( c1, c2, 1, ( x, y ) -> x - y );

        assertEquals( 1, cr.taille() );
        assertEquals( 9, cr.lire() );

        assertEquals( 3, c1.taille() );
        assertEquals( 12, c1.lire() );
        c1.avancer();
        assertEquals( 11, c1.lire() );
        c1.avancer();
        assertEquals( 10, c1.lire() );

        assertEquals( 3, c2.taille() );
        assertEquals( 3, c2.lire() );
        c2.avancer();
        assertEquals( 2, c2.lire() );
        c2.avancer();
        assertEquals( 1, c2.lire() );
    }

    @Test
    void zip_3_1() {
        ListeEuclidienne<Integer> c1 = new ListeEuclidienne<>();

        c1.inserer( 10 );
        c1.inserer( 11 );
        c1.inserer( 12 );

        ListeEuclidienne<Integer> c2 = new ListeEuclidienne<>();

        c2.inserer( 1 );

        ListeEuclidienne<Integer> cr = ListeEuclidienne.zip( c1, c2, 3, ( x, y ) -> x + y );

        assertEquals( 3, cr.taille() );
        assertEquals( 13, cr.lire() );
        cr.avancer();
        assertEquals( 12, cr.lire() );
        cr.avancer();
        assertEquals( 11, cr.lire() );

        assertEquals( 3, c1.taille() );
        assertEquals( 12, c1.lire() );
        c1.avancer();
        assertEquals( 11, c1.lire() );
        c1.avancer();
        assertEquals( 10, c1.lire() );

        assertEquals( 1, c2.taille() );
        assertEquals( 1, c2.lire() );
    }

    @Test
    void zip_1_3() {
        ListeEuclidienne<Integer> c1 = new ListeEuclidienne<>();

        c1.inserer( 10 );

        ListeEuclidienne<Integer> c2 = new ListeEuclidienne<>();

        c2.inserer( 1 );
        c2.inserer( 2 );
        c2.inserer( 3 );

        ListeEuclidienne<Integer> cr = ListeEuclidienne.zip( c1, c2, 3, ( x, y ) -> x + y );

        assertEquals( 3, cr.taille() );
        assertEquals( 13, cr.lire() );
        cr.avancer();
        assertEquals( 12, cr.lire() );
        cr.avancer();
        assertEquals( 11, cr.lire() );

        assertEquals( 1, c1.taille() );
        assertEquals( 10, c1.lire() );

        assertEquals( 3, c2.taille() );
        assertEquals( 3, c2.lire() );
        c2.avancer();
        assertEquals( 2, c2.lire() );
        c2.avancer();
        assertEquals( 1, c2.lire() );
    }

    @Test
    void iter0() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        Iterator<Integer> it = c.iterator();

        assertFalse( it.hasNext() );
    }

    @Test
    void iter1() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );

        Iterator<Integer> it = c.iterator();

        for( int i = 0; i < 5; ++ i ) {
            assertTrue( it.hasNext() );
            assertEquals( 10, it.next() );
        }
    }

    @Test
    void iter3() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );
        c.inserer( 11 );
        c.inserer( 12 );

        Iterator<Integer> it = c.iterator();

        assertEquals( 12, it.next() );
        assertEquals( 11, it.next() );
        assertEquals( 10, it.next() );
        assertEquals( 12, it.next() );
        assertEquals( 11, it.next() );
        assertEquals( 10, it.next() );
    }

    @Test
    void iter3r() {
        ListeEuclidienne<Integer> c = new ListeEuclidienne<>();

        c.inserer( 10 );
        c.inserer( 11 );
        c.inserer( 12 );
        c.inverser();

        Iterator<Integer> it = c.iterator();

        assertEquals( 12, it.next() );
        assertEquals( 10, it.next() );
        assertEquals( 11, it.next() );
        assertEquals( 12, it.next() );
        assertEquals( 10, it.next() );
        assertEquals( 11, it.next() );
    }
}