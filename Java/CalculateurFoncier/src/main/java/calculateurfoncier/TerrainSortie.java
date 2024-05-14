package calculateurfoncier;

import java.util.ArrayList;
import java.util.List;

/**
 * TerrainSortie
 *
 * V1
 *
 * 2021-06-04
 *
 * @author sam79
 */
public class TerrainSortie {
    private double valeurFonciereTotale; //Valeur foncière totale du terrain
    private double taxeScolaire; //Taxe scolaire du terrain
    private double taxeMunicipale; //Taxe municipale du terrain
    private List<LotSortie> lotissements; //Liste des lotissements du terrain
    private static TerrainSortie singleton; //Instance du Terrain

    public static final double MONTANTFIXE = 733.77d;

    private TerrainSortie() throws Exception {
        this.valeurFonciereTotale = 0.0d;
        this.taxeMunicipale = 0.0d;
        this.taxeScolaire = 0.0d;
        this.lotissements = new ArrayList<>();
    }

    /***
     * Cette méthode prend l'objet lot et l'ajoute à la liste des lots du
     * terrain.
     * @return Retourne la liste des lots du terrain.
     */
    public void ajoutLots(LotSortie lot) {
        lotissements.add(lot);
        MiseAJourValeurFonciere();
    }

    private void MiseAJourValeurFonciere() {
        valeurFonciereTotale = 0;
        for (LotSortie lot : lotissements) {
            valeurFonciereTotale += lot.getValeurLot();
        }
        valeurFonciereTotale += MONTANTFIXE;

        MiseAJourTaxeScolaire();
        MiseAJourTaxeMunicipale();
    }

    private void MiseAJourTaxeMunicipale() {
        taxeMunicipale = (valeurFonciereTotale * 0.025);
    }


    private void MiseAJourTaxeScolaire() {
        taxeScolaire = (valeurFonciereTotale * 0.012);
    }

    /***
     * L'instance par défaut du terrain, il ne peut qu'accéder au contenue du
     * fichier entrée en paramètre.
     * @return Retourne l'instance unique de l'objet TerrainSortie.
     */
    public static TerrainSortie InstanceTerrain() throws Exception {
        if (singleton == null) {
            singleton = new TerrainSortie();
        }
        return singleton;
    }
    public static void Reinitialisation(){
        singleton = null;
    }
    
    public double getValeurFoncièreTotale() {
        return valeurFonciereTotale;
    }


    public double getTaxeScolaire() {
        return taxeScolaire;
    }

    public double getTaxeMunicipale() {
        return taxeMunicipale;
    }

    public List<LotSortie> getLotissements() {
        return lotissements;
    }

    /**
     * Modifie le toString de base pour le retourné en format Json.
     *
     * @return Retourne le string de l'objet TerrainSortie en format Json.
     */
    @Override
    public String toString() {
        String lotissementString = "";
        for (LotSortie lot : lotissements) {
            lotissementString += lot.toString();
        }
        
        int index = lotissementString.lastIndexOf(",");
        if (index != -1) {
            lotissementString = lotissementString.substring(0, index);
        }

        String observations = RecuperationStringObservation();

        return "{" +
                "\"valeur_fonciere_totale\":\"" + 
                String.format("%.2f", Calculs.Arrondir(
                        this.valeurFonciereTotale))
                        .replaceAll(",",".") +
                " $\", " + "\"taxe_scolaire\":\"" + 
                String.format("%.2f", Calculs.Arrondir(this.taxeScolaire))
                        .replaceAll(",",".") +
                " $\"," + "\"taxe_municipale\":\"" + 
                String.format("%.2f", Calculs.Arrondir(this.taxeMunicipale))
                        .replaceAll(",",".") +
                " $\"," + "\"lotissements\":[" + lotissementString + "]"
                +observations+"}";
    }


    private String RecuperationStringObservation() {
        String observations = "";
        try {
            observations = Observation.Observations()
                    .recuperationObservations();
        } catch (Exception e) {
            e.printStackTrace();
        }

        if(observations != "")
            observations = "," + observations;
        return observations;
    }
}
