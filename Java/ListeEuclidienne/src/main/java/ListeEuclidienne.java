
import java.util.*;
import java.util.function.BiFunction;


/*
 * =======
 * Samuel Dextraze
 * Christophe Cloutier
 *
 *
 */


/**
 * <p>Cette classe est contenant homogène à taille variable.</p>
 *
 * <p>Une {@code ListeEuclidienne} est une liste doublement chainées construite en circuit : le premier chainon est
 * connecté au dernier.  Une autre propriété de cette liste est le comportement de la tête.  La tête (tête de lecture)
 * peut se déplacer (avancer) dans la liste.  Chaque appel à la méthode {@code avancer()} fait avancer la tête de
 * lecture d'un chainon (donc de un élément).  Au départ, la tête de lecture avance dans le circuit en sens
 * {@code HORAIRE}.  La méthode {@code inverser()} permet de changer la direction de la tête de lecture.</p>
 *
 * <p>Cette structure à deux objectifs important : </p>
 *
 * <p>1 - l'itérateur permet de tourner indéfiniment dans le circuit.</p>
 *
 * <p>2 - permet de faire une concaténation Euclédienne entre deux {@code ListeEuclidienne}.  Cette opération permet
 * disposer les éléments d'une liste à intervalle relativement régulier les uns des autres dans un espace discret.</p>
 *
 * @param <E> Le type des éléments du contenant.
 */
public class ListeEuclidienne<E> implements Iterable<E> {
    private Direction direction = Direction.HORAIRE;
    private Chainon debut;
    private Chainon fin;
    private int taille = 0;


    /**
     * <p>Type de donnée pour décrire la direction courante de la tête de lecture dans la liste.</p>
     */
    public enum Direction {
        HORAIRE,
        ANTIHORAIRE,
        ;
    }


    /**
     * <p>Un chainon privé pour la structure.</p>
     */
    private class Chainon {
        E element;
        Chainon precedent;
        Chainon suivant;

        public Chainon(E element, Chainon precedent, Chainon suivent) {
            this.element = element;
            this.precedent = precedent;
            this.suivant = suivent;
        }
    }


    /**
     * <p>Classe privé pour décrire l'itérateur sur la structure {@code ListeEuclidienne}.</p>
     *
     * <p>Un itérateur sur une {@code ListeEuclidienne} démarre à la position de la tête de lecture lors de la
     * construction de l'itérateur.  Cette itérateur va parcourir la liste dans la même direction que la tête de
     * lecture lors de la construction de l'itérateur.  Ensuite, si la tête de lecture change de direction, alors
     * l'itérateur ne change pas de direction.</p>
     *
     * <p>Un itérateur dans un circuit termine lorsqu'il n'y a plus d'élément dans la {@code ListeEuclidienne}.</p>
     */
    private class Iter implements Iterator<E> {
        Chainon courant;

        /**
         * <p>Constructeur pour l'itérateur.</p>
         *
         * <p>Un itérateur sur une {@code ListeEuclidienne} démarre à la position de la tête de lecture lors de la
         * construction de l'itérateur.  Cette itérateur va parcourir la liste dans la même direction que la tête de
         * lecture lors de la construction de l'itérateur.</p>
         */
        public Iter() {
            courant = debut;
        }


        /**
         * <p>Une {@code ListeEuclidienne} n'a pas de fin.  Donc l'itérateur tourne indéfiniment.  Le seul cas où
         * cette méthode retourne {@code false} est lorsque le lE est vide.</p>
         *
         * @return toujours {@code true}, sauf si le {@code ListeEuclidienne} est vide.
         */
        @Override
        public boolean hasNext() {
            return debut != null;
        }


        /**
         * <p>Retourne l'élément courant et avance l'itérateur au prochain élément.</p>
         *
         * <p>L'itérateur tourne toujours dans la même direction.  Cette direction est la même que la direction de
         * la tête de lecture lors de la création de l'itérateur.</p>
         *
         * @return l'élément courant.
         * @throws NoSuchElementException Lancé si la {@code ListeEuclidienne} est vide lors de l'appel.
         */
        @Override
        public E next() throws NoSuchElementException {
            E element = courant.element;
            if (direction == Direction.HORAIRE)
                courant = courant.suivant;
            else
                courant = courant.precedent;
            return element;
        }
    }


    /**
     * <p>Construit une {@code ListeEuclidienne} vide.</p>
     */
    public ListeEuclidienne() {
    }


    /**
     * <p>Construit {@code ListeEuclidienne} une contenant {@code n} éléments pareils.</p>
     *
     * @param n       Le nombre d'élément à ajouter.
     *                pré-condition : cette valeur ne doit pas être négative : $0 \le n$.
     * @param element L'élément ajoutés.
     */
    public ListeEuclidienne(int n, E element) {
        if (n > 0) {
            for (int i = 0; i < n; i++) {
                inserer(element);
            }
        }
    }


    /**
     * <p>Construit un itérateur à partir de l'état courant de la {@code ListeEuclidienne}.</p>
     *
     * @return
     */
    @Override
    public Iterator<E> iterator() {
        return new Iter();
    }


    /**
     * <p>Retourne l'élément pointé par la tête de lecture.</p>
     *
     * @return L'élément pointé par la tête de lecture.
     * @throws NoSuchElementException Lorsque la {@code ListeEuclidienne} est vide.
     */
    public E lire() throws NoSuchElementException {
        if (estVide())
            throw new NoSuchElementException();
        return debut.element;
    }


    /**
     * <p>retourne le nombre d'éléments qu'il y a dans la {@code ListeEuclidienne}.</p>
     *
     * @return le nombre d'éléments.
     */
    public int taille() {
        return this.taille;
    }


    /**
     * <p>Retourne la direction de rotation de la tête de lecture.</p>
     *
     * @return La direction de rotation.
     */
    public Direction getDirection() {
        return this.direction;
    }


    /**
     * <p>Ce prédicat nous dit si la {@code ListeEuclidienne} est vide.</p>
     *
     * @return {@code true} si la {@code ListeEuclidienne} ne contient pas d'élément, {@code false} sinon.
     */
    public boolean estVide() {
        return debut == null;
    }


    /**
     * <p>Écrit une valeur dans la case pointée par la tête de lecture.</p>
     *
     * <p>Cette écriture écrase l'ancienne valeur.  Cela ne change pas la taille de la structure.</p>
     *
     * @param element La nouvelle valeur à écrire.
     * @throws ListeVideException Lancé si la {@code ListeEuclidienne} est vide.
     */
    public void ecrire(E element) throws ListeVideException {
        if (estVide())
            throw new ListeVideException();
        debut.element = element;
    }


    /**
     * <p>Insere un élément dans la {@code ListeEuclidienne}.</p>
     *
     * <p>L'élément est ajouté à la tête de lecture $\RightArrow$ après l'insertion, la tête de lecture pointe sur
     * l'élément nouvellement inséré.  L'élément qui était pointé avant l'insertion est déplacé à la case suivante
     * selon la direction courante de la {@code ListeEuclidienne}.  C.à.d.  si l'insertion est suivit d'un appel à la
     * méthode {@code avancer}, alors la tete pointera sur l'ancien élément.
     * Cette méthode augmente la taille de la structure.</p>
     *
     * @param element Une référence sur l'élément à insérer.
     */
    public void inserer(E element) {
        if (estVide()) {
            debut = new Chainon(element, debut, debut);
            fin = debut;
            debut.precedent = fin;
            debut.suivant = fin;
        } else {
            if (getDirection() == Direction.HORAIRE) {
                Chainon temp = new Chainon(element, fin, debut);
                fin.suivant = temp;
                debut.precedent = temp;
                debut = debut.precedent;
            } else if (getDirection() == Direction.ANTIHORAIRE) {
                Chainon temp = new Chainon(element, debut, debut.suivant);
                debut.suivant.precedent = temp;
                debut.suivant = temp;
                debut = debut.suivant;
                fin = debut.precedent;
            }
        }
        taille++;
    }


    /**
     * <p>Avance la tête de lecture d'une case selon la direction de la structure.</p>
     *
     * @throws ListeVideException Lancé lorsque la {@code ListeEuclidienne} est vide.
     */
    public void avancer() throws ListeVideException {
        if (debut == null)
            throw new ListeVideException();
        if (this.direction == Direction.HORAIRE) {
            debut = debut.suivant;
            fin = fin.suivant;
        } else if (this.direction == Direction.ANTIHORAIRE) {
            debut = debut.precedent;
            fin = fin.precedent;
        }
    }


    /**
     * <p>Avance la tête de lecture de 'n' cases selon la direction de la structure.</p>
     *
     * @param n nombre de case que la tête de lecture va parcourir.
     *          pré-condition : cette valeur ne doit pas être négative : $0 \le n$.
     * @throws ListeVideException Lancé lorsque la {@code ListeEuclidienne} est vide.
     */
    public void avancer(int n) throws ListeVideException {
        if (n > 0) {
            for (int i = 0; i < n; i++) {
                avancer();
            }
        }
    }


    /**
     * <p>Change la direction de rotation de la tête de lecture.</p>
     */
    public void inverser() {
        if (direction == Direction.HORAIRE)
            direction = Direction.ANTIHORAIRE;
        else if (direction == Direction.ANTIHORAIRE)
            direction = Direction.HORAIRE;
    }


    /**
     * <p>Supprime une case de la {@code ListeEuclidienne}.</p>
     *
     * <p>Après la suppression, la tête de lecture pointe sur l'élément suivant la case supprimé selon la direction
     * de la structure.  La taille de la {@code ListeEuclidienne} est diminué de 1.</p>
     *
     * @throws ListeVideException Lancé lorsque la structure est vide.
     */
    public E supprimer() throws ListeVideException {
        if (estVide())
            throw new ListeVideException();
        Chainon retirer = debut;

        if (taille > 1) {
            if (getDirection() == Direction.HORAIRE) {
                fin.suivant = debut.suivant;
                debut.suivant.precedent = fin;
                debut = debut.suivant;
            } else if (getDirection() == Direction.ANTIHORAIRE) {
                fin.suivant = debut.suivant;
                debut.suivant.precedent = fin;
                debut = fin;
                fin = fin.precedent;
            }
        } else {
            debut = null;
        }
        taille--;

        return retirer.element;
    }


    /**
     * <p>Insére tout les éléments dans la {@code ListeEuclidienne}.</p>
     *
     * <p>Les éléments sont insérés dans la {@code ListeEuclidienne} avant la tête de lecture (selon la direction de
     * la tête de lecture).
     * Après l'insertion des éléments, la tête de lecture pointe au même endroit qu'elle pointait avant l'insertion.
     * Les éléments insérés sont dans le même ordre qu'ils étaient dans la {@code ListeEuclidienne} originale, selon la direction de la
     * tête de lecture dans la {@code ListeEuclidienne} originale.</p>
     *
     * <p>La liste en argument n'est pas modifié par cette opération.</p>
     *
     * @param liste La {@code ListeEuclidienne} contenant les éléments à insérer.  Cette liste n'est pas modifiée par
     *              l'opération.
     *              pré-condition : non {@code null}.
     */
    public void insererTout(ListeEuclidienne<E> liste) {
        if (!liste.estVide()) {
            liste.avancer();
            for (int i = 0; i < liste.taille(); i++) {
                inserer(liste.lire());
                liste.avancer();
            }
            int taille = taille() - liste.taille();
            avancer(taille - 1);
        }
    }


    /**
     * <p>Construit une {@code ListeEuclidienne} composé des résultats de l'application de la fonction de fusion aux
     * éléments des deux {@code ListeEuclidienne} en entrées.</p>
     *
     * <p>Les deux listes sont parcouru simultanément, élément à élément.  La fonction de fusion est utilisé pour
     * construire l'élément inséré dans la liste résultante.  Le parcour des deux listes continue jusqu'à ce que le
     * nombre voulus d'éléments dans la liste finale est été atteind.</p>
     *
     * <p>Exemple</p>
     *
     * <p>liste1 = [2, 4, 6, 8, 9]</p>
     *
     * <p>liste2 = [1, 0, 1, 0, 1]</p>
     *
     * <p>fusion = ( x, y ) -> x + y</p>
     *
     * <p>alors, la méthode retournera : </p>
     *
     * <p>[3, 4, 7, 8, 10]</p>
     *
     * @param liste1 La liste qui contient les éléments utilisés comme premier argument de la fonction {@code fusion}.
     *               pré-condition : non {@code null}.
     * @param liste2 La liste qui contient les éléments utilisés comme deuxième argument de la fonction {@code fusion}.
     *               pré-condition : non {@code null}.
     * @param n      Le nombre d'éléments voulus dans la liste finale.
     * @param fusion La fonction de fusion des éléments.
     *               pré-condition : non {@code null}.
     * @return Une {@code ListeEuclidienne} contenant les résultats de l'application de la fonction de {@code fusion}
     * aux éléments des {@code ListeEuclidienne} en entrées.
     */
    public static <E, F, G>
    ListeEuclidienne<G> zip(ListeEuclidienne<E> liste1,
                            ListeEuclidienne<F> liste2,
                            int n, BiFunction<E, F, G> fusion) {
        ListeEuclidienne<G> newList = new ListeEuclidienne<>();
        newList.inverser();
        int nbTourA = 0;
        int nbTourB = 0;
        for (int i = 0; i < n; i++) {
            newList.inserer(fusion.apply(liste1.lire(), liste2.lire()));
            liste1.avancer();
            liste2.avancer();
            nbTourA++;
            nbTourB++;
        }
        newList.inverser();
        newList.avancer();

        while (nbTourA % liste1.taille != 0) {
            liste1.avancer();
            nbTourA++;
        }
        while (nbTourB % liste2.taille != 0) {
            liste2.avancer();
            nbTourB++;
        }
        return newList;
    }


    //----------------------------------------------------------------------------
    // FIN DES MÉTHODES À ÉCRIRE DANS LE TP.
    // Les méthodes suivantes sont déjà écritent.
    // Elles vont fonctionner lorsque votre code sera écrit.


    /**
     * <p>Utilise l'algorithme de Bjorklund (basé sur l'algorithme d'Euclide) pour fusionner deux listes.</p>
     *
     * @param liste1
     * @param liste2
     * @param <E>
     * @return
     */
    public static <E>
    ListeEuclidienne<E> concatEuclidienne(ListeEuclidienne<E> liste1,
                                          ListeEuclidienne<E> liste2) {
        ListeEuclidienne<ListeEuclidienne<E>> temp1;
        ListeEuclidienne<ListeEuclidienne<E>> temp2;

        if (liste1.taille() < liste2.taille()) {
            temp2 = transformer(liste1);
            temp1 = transformer(liste2);
        } else {
            temp1 = transformer(liste1);
            temp2 = transformer(liste2);
        }

        while (0 != temp2.taille()) {
            ListeEuclidienne<ListeEuclidienne<E>> temp3 =
                    new ListeEuclidienne<>();

            while (!temp2.estVide()) {
                ListeEuclidienne<E> element = temp1.supprimer();
                element.insererTout(temp2.supprimer());
                temp3.inserer(element);
                temp3.avancer();
            }

            if (temp3.taille() < temp1.taille()) {
                temp2 = temp3;
            } else {
                temp2 = temp1;
                temp1 = temp3;
            }
        }

        ListeEuclidienne<E> resultat = extraire(temp1);

        return resultat;
    }


    private static <E>
    ListeEuclidienne<E> extraire(ListeEuclidienne<ListeEuclidienne<E>> temp1) {
        ListeEuclidienne<E> resultat = temp1.supprimer();
        while (!temp1.estVide()) {
            resultat.insererTout(temp1.supprimer());
        }
        return resultat;
    }


    private static <E>
    ListeEuclidienne<ListeEuclidienne<E>> transformer(ListeEuclidienne<E> liste) {
        ListeEuclidienne<ListeEuclidienne<E>> resultat = new ListeEuclidienne<>();

        for (int i = 0; i < liste.taille(); ++i) {
            resultat.inserer(new ListeEuclidienne<>());
            resultat.lire().inserer(liste.lire());
            liste.avancer();
            resultat.avancer();
        }

        return resultat;
    }


    /**
     * <p>Un petit {@code toString} pour le débuggage.</p>
     *
     * @return Une représentant 'XML' de l'état courant de la structure.
     */
    @Override
    public String toString() {
        String resultat = "<liste_euclidienne taille=\"";
        resultat += taille() + "\" direction=\"";
        resultat += getDirection().name().toLowerCase(Locale.ROOT) + "\">\n    [ ";

        Iterator<E> it = iterator();
        for (int i = 0; i < taille(); ++i) {
            if (0 != i) {
                resultat += ", ";
            }
            resultat += it.next();
        }

        resultat += " ]\n</liste_euclidienne>";

        return resultat;
    }
}
