package calculateurfoncier;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import java.time.LocalDate;
import java.time.Period;
import java.time.ZoneId;
import java.util.Date;
import java.util.List;

public class Observation {
    private static JSONArray observations;
    private static Observation observation;
    private static Terrain terrain;
    private static List<Lot> lots;
    private static TerrainSortie terrainSortie;
    private static List<LotSortie> lotSorties;

    private Observation() throws Exception {
        observations = new JSONArray();
        terrain = Terrain.InstanceTerrain();
        lots = terrain.getLots();

        terrainSortie = TerrainSortie.InstanceTerrain();
        lotSorties = terrainSortie.getLotissements();
    }

    public static Observation Observations() throws Exception {
        if (observation == null)
            observation = new Observation();
        return observation;
    }

    public String recuperationObservations() {
        verificationObservations();
        if (observations.size() == 0)
            return "";
        JSONObject observation = new JSONObject();
        observation.put("observations", observations);
        String retourJson = observation.toString();
        return retourJson.substring(1,retourJson.length()-1);
    }

    private static void verificationObservations() {
        verificationTerrain();
        verificationLots();
        verificationDateLots();
    }

    private static void verificationTerrain() {
        if (terrainSortie.getTaxeMunicipale() > 1000.00)
            observations.add("Deux versements seront nécessaire afin de payer"+
                    " la taxe municipale.");
        if (terrainSortie.getTaxeScolaire() > 500.00)
            observations.add("Deux versements seront nécessaire afin de payer"+
                    " la taxe scolaire.");
        if (terrainSortie.getValeurFoncièreTotale() > 300000.00)
            observations.add("La valeur foncière totale dépasse 300000.00$.");
        if (terrain.getPrixM2Max() > (terrain.getPrixM2Min() * 2))
            observations.add("La valeur du prix maximum au mètre carée ne " +
                    "doit pas dépasser 2 fois la valeur du prix minimum.");

    }

    private static void verificationLots() {
        for (LotSortie lot : lotSorties) {
            if (lot.getValeurLot() > 45000.00)
                observations.add("La valeur du lot " + lot.getDescription() +
                        " est trop cher.");
        }
        for (Lot lot : lots) {
            if (lot.getSuperficie() > 45000)
                observations.add("Le lot " + lot.getDescription() + " a une " +
                        "superficie trop élevé.");
        }
    }

    private static void verificationDateLots() {
        Date dateMax = lots.stream().map(Lot::getDateMesure)
                .max(Date::compareTo).get();
        Date dateMin = lots.stream().map(Lot::getDateMesure)
                .min(Date::compareTo).get();
        LocalDate maximum = dateMax.toInstant().atZone(ZoneId.systemDefault())
                .toLocalDate();
        LocalDate minimum = dateMin.toInstant().atZone(ZoneId.systemDefault())
                .toLocalDate();
        int ecartMois = Period.between(minimum, maximum).getMonths();
        int ecartAnnee = Period.between(minimum, maximum).getYears();
        if (ecartMois >= 6 || ecartAnnee > 0)
            observations.add("L'écart des dates maximales et minimales entre "+
                    "les dates de mesure des lots doit être inférieure à 6 " +
                    "mois.");

    }
    public void reinitialisationObservations(){
        observations = new JSONArray();
    }


}
