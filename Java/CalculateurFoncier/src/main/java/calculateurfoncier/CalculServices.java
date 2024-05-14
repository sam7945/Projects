package calculateurfoncier;

/**
 * CalculsServices
 *
 * V2
 *
 * 2021-07-12
 *
 * @author slepaget
 */
public class CalculServices {

    private static final int NOMBRE_SERVICES_BASE = 2;

    public static double calculServices(Terrain terrain, Lot lot)
            throws Exception {

        int typeTerrain = terrain.getTypeTerrain();
        int nombreServices = lot.getNombreServices();
        double superficieLot = lot.getSuperficie();
        String descriptionLot = lot.getDescription();

        double montantServices;

        validationTypeTerrain(typeTerrain, descriptionLot);
        validationNombreServices(nombreServices, descriptionLot);
        validationSuperficieLot(superficieLot, descriptionLot);

        montantServices = valeurServiceSelonSurface(superficieLot, typeTerrain);
        montantServices = montantServicesSelonNombreServices(
                montantServices, nombreServices, NOMBRE_SERVICES_BASE);
        montantServices = valeurServiceMaximale(montantServices, typeTerrain);

        return montantServices;
    }

    private static double valeurServiceSelonSurface(
            double surfaceLot, int typeTerrain) {
        double valeurService = 0;

        switch (typeTerrain) {
            case 0 ->
                valeurService = valeurSiAgricole();
            case 1 ->
                valeurService = valeurSiResidentiel(surfaceLot);
            case 2 ->
                valeurService = valeurSiCommercial(surfaceLot);
        }
        return valeurService;
    }

    private static double valeurSiAgricole() {
        double valeurService;
        valeurService = 0;
        return valeurService;
    }

    private static double valeurSiCommercial(double surfaceLot) {
        double valeurService;
        if (surfaceLot <= 500) {
            valeurService = 500;
        } else {
            valeurService = 1500;
        }
        return valeurService;
    }

    private static double valeurSiResidentiel(double surfaceLot) {
        double valeurService;
        if (surfaceLot <= 500) {
            valeurService = 0;
        } else if (surfaceLot <= 10000) {
            valeurService = 500;
        } else {
            valeurService = 1000;
        }
        return valeurService;
    }

    private static double valeurServiceMaximale(double valeurServ, int type) {
        if (valeurServ > 5000 && type == 2) {
            valeurServ = 5000;
        }
        return valeurServ;
    }

    private static double montantServicesSelonNombreServices(
            double valeurService, int nombreServices, int nombreServicesBase) {
        return (valeurService * (nombreServices + nombreServicesBase));
    }

    public static void validationNombreServices(
            int nombreServices, String descriptionLot)
            throws Exception {
        if (nombreServices < 0 || nombreServices > 5) {
            throw new Exception(
                    "Le nombre de services doit être entre "
                    + "0 et 5 inclusivement, "
                    + "Valeur du \'" + descriptionLot + "\' = " + nombreServices
            );
        }
    }

    public static void validationTypeTerrain(
            int typeTerrain, String descriptionLot)
            throws Exception {
        if (typeTerrain < 0 || typeTerrain > 2) {
            throw new Exception(
                    "Le type de terrain doit prendre la valeur 0, 1 ou 2, "
                    + "Valeur du \'" + descriptionLot + "\' = " + typeTerrain
            );
        }
    }

    public static void validationSuperficieLot(
            double superficieLot, String descriptionLot)
            throws Exception {
        if (superficieLot < 0 || superficieLot > 50000) {
            throw new Exception(
                    "La superficie ne peut pas être négative et "
                    + "ne peut pas être supérieure à 50000 m2, "
                    + "Valeur du \'" + descriptionLot + "\' = " + superficieLot
            );
        }
    }
}
