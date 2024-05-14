package ca.qc.cegepsth.gep.ttt;

/**
 *
 * @author Samuel Dextraze
 */
public class Logique extends Modele {

    private boolean gagné = false;
    private boolean cartePleine = false;
    Logique(EvenementsTTT interfaceUtilisateur, Joueur joueurActif) {
        super(interfaceUtilisateur, joueurActif);
    }

    @Override
    public Joueur getJoueur(int position) throws PositionInvalide {
        switch (position)
        {
            case 1:
                return A1;
            case 2:
                return A2;
            case 3:
                return A3;
            case 4:
                return B1;
            case 5:
                return B2;
            case 6:
                return B3;
            case 7:
                return C1;
            case 8:
                return C2;
            case 9:
                return C3;
            default:
                return null;
        }
    }

    @Override
    public void jouePosition(int position) throws PositionInvalide {

        switch (position) {
            case 1:
                if (this.A1 == null) { //vérifie si la case est occupé
                    this.A1 = this.joueurActif;
                    this.verification(this.joueurActif); // vérifie si le joueur actif à fait une combinaison gagnante avant le changement
                    if (this.joueurActif == Joueur.O && !gagné) // Si le joueur actif n'a pas gagné, il change
                        this.joueurActif = Joueur.X;
                    else if (!gagné)
                        this.joueurActif = Joueur.O;
                } else
                    this.interfaceUtilisateur.positionDejaOccuppee(); //si la position est prise
                break;
            case 2:
                if (this.A2 == null) {
                    this.A2 = this.joueurActif;
                    this.verification(this.joueurActif);
                    if (this.joueurActif == Joueur.O && !gagné)
                        this.joueurActif = Joueur.X;
                    else if (!gagné)
                        this.joueurActif = Joueur.O;
                } else
                    this.interfaceUtilisateur.positionDejaOccuppee();
                break;
            case 3:
                if (this.A3 == null) {
                    this.A3 = this.joueurActif;
                    this.verification(this.joueurActif);
                    if (this.joueurActif == Joueur.O && !gagné)
                        this.joueurActif = Joueur.X;
                    else if (!gagné)
                        this.joueurActif = Joueur.O;
                } else
                    this.interfaceUtilisateur.positionDejaOccuppee();
                break;
            case 4:
                if (this.B1 == null) {
                    this.B1 = this.joueurActif;
                    this.verification(this.joueurActif);
                    if (this.joueurActif == Joueur.O && !gagné)
                        this.joueurActif = Joueur.X;
                    else if (!gagné)
                        this.joueurActif = Joueur.O;
                } else
                    this.interfaceUtilisateur.positionDejaOccuppee();
                break;
            case 5:
                if (this.B2 == null) {
                    this.B2 = this.joueurActif;
                    this.verification(this.joueurActif);
                    if (this.joueurActif == Joueur.O && !gagné)
                        this.joueurActif = Joueur.X;
                    else if (!gagné)
                        this.joueurActif = Joueur.O;
                } else
                    this.interfaceUtilisateur.positionDejaOccuppee();
                break;
            case 6:
                if (this.B3 == null) {
                    this.B3 = this.joueurActif;
                    this.verification(this.joueurActif);
                    if (this.joueurActif == Joueur.O && !gagné)
                        this.joueurActif = Joueur.X;
                    else if (!gagné)
                        this.joueurActif = Joueur.O;
                } else
                    this.interfaceUtilisateur.positionDejaOccuppee();
                break;
            case 7:
                if (this.C1 == null) {
                    this.C1 = this.joueurActif;
                    this.verification(this.joueurActif);
                    if (this.joueurActif == Joueur.O && !gagné)
                        this.joueurActif = Joueur.X;
                    else if (!gagné)
                        this.joueurActif = Joueur.O;
                } else
                    this.interfaceUtilisateur.positionDejaOccuppee();
                break;
            case 8:
                if (this.C2 == null) {
                    this.C2 = this.joueurActif;
                    this.verification(this.joueurActif);
                    if (this.joueurActif == Joueur.O && !gagné)
                        this.joueurActif = Joueur.X;
                    else if (!gagné)
                        this.joueurActif = Joueur.O;
                } else
                    this.interfaceUtilisateur.positionDejaOccuppee();
                break;
            case 9:
                if (this.C3 == null) {
                    this.C3 = this.joueurActif;
                    this.verification(this.joueurActif);
                    if (this.joueurActif == Joueur.O && !gagné)
                        this.joueurActif = Joueur.X;
                    else if (!gagné)
                        this.joueurActif = Joueur.O;
                } else
                    this.interfaceUtilisateur.positionDejaOccuppee();
                break;
            default:
                throw new PositionInvalide();
        }

        if(gagné) // si le joueur actif gagne
        {
            this.interfaceUtilisateur.aGagne(this.joueurActif);
        }
        //Si le match est null
        else if(this.A1 != null && this.A2 != null && this.A3 != null
                && this.B1 != null && this.B2 != null && this.B3 != null
                && this.C1 != null && this.C2 != null && this.C3 != null )
        {
            cartePleine = true;
            interfaceUtilisateur.cartePleine();
        }
        else
            this.interfaceUtilisateur.auTourDe(joueurActif); //changement de joueur
    }
    /**
     * Permet de vérifier si le joueur actuel a fait une combinaison gagnante
     *
     * @param Joueur X ou O
     */
    private void verification(Joueur joueur)
    {
        //Vérification pour l'horizontale
        if (this.A1 == joueur && this.A2 == joueur && this.A3 == joueur)
            gagné = true;
        if (this.B1 == joueur && this.B2 == joueur && this.B3 == joueur)
            gagné = true;
        if (this.C1 == joueur && this.C2 == joueur && this.C3 == joueur)
            gagné = true;

        //Vérification pour la verticale
        if (this.A1 == joueur && this.B1 == joueur && this.C1 == joueur)
            gagné = true;
        if (this.A2 == joueur && this.B2 == joueur && this.C2 == joueur)
            gagné = true;
        if (this.A3 == joueur && this.B3 == joueur && this.C3 == joueur)
            gagné = true;

        //vérification pour les diagonales
        if (this.A1 == joueur && this.B2 == joueur && this.C3 == joueur)
            gagné = true;
        if (this.A3 == joueur && this.B2 == joueur && this.C1 == joueur)
            gagné = true;
    }
    /**
     * Permet de réinitialiser la grille de jeu lors d'une nouvelle partie
     */
    public void reset()
    {
        this.A1 = null;
        this.A2 = null;
        this.A3 = null;
        this.B1 = null;
        this.B2 = null;
        this.B3 = null;
        this.C1 = null;
        this.C2 = null;
        this.C3 = null;
        joueurActif = Joueur.O;
        gagné =false;
        cartePleine = false;
    }
}