package calculateurfoncier;

/**
 * LotSortie
 *
 * V1
 *
 * 2021-06-04
 *
 * @author sam79
 */
public class LotSortie {
    private final String DESCRIPTION; //Description du lot
    private final double VALEUR_LOT; //Valeur du lot


    public LotSortie(String description, double valeurLot) {
        this.DESCRIPTION = description;
        this.VALEUR_LOT = valeurLot;
    }


    public String getDescription() {
        return DESCRIPTION;
    }

    public double getValeurLot() {
        return VALEUR_LOT;
    }

    /**
     * Modifie le toString de base pour le retourné en format Json.
     *
     * @return Retourne le string de l'objet LotSortie en format Json.
     */
    @Override
    public String toString() {
        return "{" +
                "\"description\":\""+this.DESCRIPTION+"\"," +
                "\"valeur_par_lot\":\""+ String.format("%.2f",
                                    Calculs.Arrondir(this.VALEUR_LOT))
                .replaceAll(",",".") +" $\"" +
                "},";
    }
}
