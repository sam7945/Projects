package ca.qc.cegepsth.gep.ttt;

import java.util.Scanner;

public class TTT implements EvenementsTTT {

    private static TTT ttt;
    private static Logique logique;
    private static boolean gagné = false;
    private static boolean cartePleine = false;

    public static void main(String[] args) {
        ttt = new TTT();
        logique = new Logique(ttt, Joueur.O);
        ttt.auTourDe(logique.joueurActif);

        do {

            Scanner sc = new Scanner(System.in);
            int Position;

            Position = sc.nextInt();

            try {
                logique.jouePosition(Position);
            } catch (PositionInvalide positionInvalide) {
                System.out.println("Cette position n'est pas valide, entrez une position entre 1 et 9!");
            }

        } while (!gagné && !cartePleine);

    }

    //Ce sont des prints(Toast)
    @Override
    public void auTourDe(Joueur joueur) {
        ttt.faireCarte();
        System.out.println("C'est au tour de " + joueur);
    }

    @Override
    public void aGagne(Joueur joueur) {
        ttt.faireCarte();
        gagné = true;
        System.out.println("Le gagnant est joueur " + joueur);
    }

    @Override
    public void cartePleine() {
        cartePleine = true;
        ttt.faireCarte();
        System.out.println("La carte est pleine et il n'y a aucun gagnant!");
    }

    @Override
    public void positionDejaOccuppee() {
        System.out.println("Cette position est déjà occuper!");
    }

    public void faireCarte() {
        System.out.println(logique.A1 + "   |   " + logique.A2 + "  |   " + logique.A3);
        System.out.println("----------------------------");
        System.out.println(logique.B1 + "   |   " + logique.B2 + "  |   " + logique.B3);
        System.out.println("----------------------------");
        System.out.println(logique.C1 + "   |   " + logique.C2 + "  |   " + logique.C3);
    }
}