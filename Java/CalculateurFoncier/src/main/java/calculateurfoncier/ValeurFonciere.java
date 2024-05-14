/**
 * ValeurFonciere
 * 
 * V1
 * 
 * 2021-06-04
 * 
 * @author Yvan
 */
package calculateurfoncier;

/**
 * Cette classe permet de calculer la valeur fonciere d'un terrain en fonction 
 * du montant de la valeur par lot, du montant des droits de passage et du 
 * montant pour les services.
 *
 * @author Yvan
 */
public class ValeurFonciere {

    private static double superficie;               //superficie du lot
    private static double prixMin;                  //prix minimum du lot
    private static double prixMax;                  //prix maximum du lot
    private static int type;

    /***
     * Calcul la valeur du terrain du lot par rapport à sa superficie.
     * @param posLot La position du lot dans la liste de lot du terrain.
     * @return cout le prix du terrain.
     */
    public static double calculValeurTerrain(Terrain terrain, Lot lot)
            throws Exception {
        superficie = lot.getSuperficie();
        type = terrain.getTypeTerrain();
        prixMin = terrain.getPrixM2Min();
        prixMax = terrain.getPrixM2Max();
        
        validationTypeTerrain(type);
        validationSuperficieLot(superficie);
        
        double cout = getCoutTerrain(type, prixMin, prixMax, superficie);
        return cout;
    }

    private static double getCoutTerrain(int typeTerrain, double prixMin, double
            prixMax, double superficie) {
        double cout = 0.0d;
        switch (type) {
            case 0:
                cout = superficie * prixMin;
                break;
            case 1:
                cout = superficie * ((prixMax + prixMin) / 2);
                break;
            case 2:
                cout = superficie * prixMax;
                break;
        }
        return cout;
    }
    
    public static void validationTypeTerrain(
            int typeTerrain) 
            throws Exception {
        if (typeTerrain < 0 || typeTerrain > 2) {
            throw new Exception(
                    "Erreur. Le type de terrain doit prendre la valeur"
                            + " 0, 1 ou 2, "
            );
        }
    }

    public static void validationSuperficieLot(
            double superficieLot) 
            throws Exception {
        if (superficieLot < 0 || superficieLot > 50000) {
            throw new Exception(
                    "La superficie ne peut pas être négative et "
                    + "ne peut pas être supérieure à 50000 m2, "
            );
        }
    } 
}
