package calculateurfoncier;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import java.security.InvalidParameterException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.TimeZone;

/**
 * Terrain
 * <p>
 * V1
 * <p>
 * 2021-06-04
 *
 * @author sam79
 */
public class Terrain {

    private int typeTerrain; //Type du terrain
    private double prixM2Min; //Prix moyen minimum du terrain
    private double prixM2Max; //Prix moyen maximum du terrain
    private List<Lot> lotissements; //Liste des lotissements
    private static Terrain singleton; //Instance de terrain

    public static final String TYPETERRAIN = "type_terrain";
    public static final String PRIXM2MIN = "prix_m2_min";
    public static final String PRIXM2MAX = "prix_m2_max";

    public static final String[] NOMSPARAMÈTRESTERRAIN = {TYPETERRAIN, 
        PRIXM2MIN,PRIXM2MAX};

    public static final String DESCRIPTION = "description";
    public static final String NOMBREDROITSPASSAGE = "nombre_droits_passage";
    public static final String NOMBRESERVICES = "nombre_services";
    public static final String SUPERFICIE = "superficie";
    public static final String DATEMESURE = "date_mesure";

    public static final String[] NOMSPARAMÈTRESLOT = {DESCRIPTION, 
        NOMBREDROITSPASSAGE, NOMBRESERVICES, SUPERFICIE, DATEMESURE};

    public static int compteLots = 0;
    final int NOMBRELOTSMAXIMAL = 10;


    private Terrain(JSONObject json) throws Exception {
        this.typeTerrain = json.getInt(TYPETERRAIN);
        this.prixM2Min = getPrixM2Validation(json, PRIXM2MIN);
        this.prixM2Max = getPrixM2Validation(json, PRIXM2MAX);
        this.lotissements = ajoutLots(json);
    }

    /**
     * *
     * L'instance par défaut du terrain, il ne peut qu'accéder au contenue du
     * fichier entrée en paramètre.
     *
     * @return Retourne l'instance unique de Terrain.
     */
    public static Terrain InstanceTerrain() throws Exception {
        if (singleton == null) {
            JSONObject jsonObject = (JSONObject.fromObject(FileReader
                    .loadFileIntoString(CalculateurFoncier.fichierEntree,
                            CalculateurFoncier.ENCODAGE)));
            validationPropriétésJsonTerrain(jsonObject);
            singleton = new Terrain(jsonObject);
        }
        return singleton;
    }
    public static void Reinitialisation(){
        singleton = null;
    }
    
    
    private void verificationDescription(String description, List<Lot> lots)
            throws Exception {
        long count = lots.stream()
                .filter(lot -> lot.getDescription()
                .equals(description.trim()))
                .count();
        if (count > 0) {
            throw new Exception("La description: " + description
                    + " entrée n'est pas unique "
                    + "et se trouve déjà dans la liste des lots.");
        }

    }

    private double getPrixM2Validation(JSONObject json, String prixm2min)
            throws Exception {
        double nombre = Double.parseDouble(json.getString(prixm2min)
                .replaceAll("[$ ]", "")
                .replaceAll(",", "."));
        if (nombre < 0) {
            throw new Exception("La valeur est du prix ne doit pas être "
                    + "négative.");
        }

        return nombre;
    }

    private List<Lot> ajoutLots(JSONObject json) throws Exception {
        List<Lot> lotissements = new ArrayList<>();
        JSONArray lots = json.getJSONArray("lotissements");
        SimpleDateFormat formatDate = getSimpleDateFormatISO8601();

        if (lots.size() == 0) {
            throw new Exception("Il doit y avoir au moins un lot existant "
                    + "pour ce terrain.");
        }

        for (Object lot : lots) {

            if (lotissements.size() == NOMBRELOTSMAXIMAL) {
                throw new Exception("La limite maximale de "
                        + NOMBRELOTSMAXIMAL
                        + " lots autorisé sur le terrain est atteinte.");
            }
            ajoutLot(lotissements, formatDate, lot);
        }
        return lotissements;
    }

    private SimpleDateFormat getSimpleDateFormatISO8601() {
        TimeZone timeZone = TimeZone.getTimeZone("UTC");
        SimpleDateFormat formatDate = new SimpleDateFormat("yyyy-MM-dd");
        formatDate.setTimeZone(timeZone);
        return formatDate;
    }

    private void ajoutLot(List<Lot> lotissements, SimpleDateFormat formatDate,
            Object objetLot) throws Exception {
        JSONObject lot = JSONObject.fromObject(objetLot);
        compteLots++;
        validationPropriétésJsonLot(lot, compteLots);
        try {
            verificationDescription(lot.getString(DESCRIPTION), lotissements);
            Lot l = new Lot(lot.getString(DESCRIPTION),
                    lot.getInt(NOMBREDROITSPASSAGE),
                    lot.getInt(NOMBRESERVICES),
                    lot.getInt(SUPERFICIE),
                    formatDate.parse(lot.getString(DATEMESURE)));
            lotissements.add(l);
        } catch (ParseException e) {
            throw new Exception("Erreur lors de la tentative de "
                    + "convertion de la date de mesure: " + e.getMessage());
        }
    }

    public static void validationPropriétésJsonTerrain(JSONObject jsonObject)
            throws Exception {

        for (String parametre : NOMSPARAMÈTRESTERRAIN) {
            try {
                jsonObject.getString(parametre);
            } catch (Exception e) {
                throw new InvalidParameterException("Le parametre de terrain "
                        + "\"" + parametre + "\" "
                        + "n'existe pas dans le fichier d'entrée. "
                        + "Vérifiez son orthographe et/ou sa présence.");
            }
        }
    }

    public static void validationPropriétésJsonLot(JSONObject jsonObject, int i)
            throws Exception {

        for (String parametre : NOMSPARAMÈTRESLOT) {
            try {
                jsonObject.getString(parametre);
            } catch (Exception e) {
                throw new InvalidParameterException("Le parametre de lot "
                        + "\"" + parametre + "\" "
                        + "n'existe pas dans le fichier d'entrée "
                        + "pour le lot à la position \"" + i + "\"."
                        + "Vérifiez son orthographe et/ou sa présence.");
            }
        }
    }

    /**
     * @return Retourne le type de terrain.
     */
    public int getTypeTerrain() {
        return typeTerrain;
    }

    /**
     * @return Retourne le prix moyen minimum du terrain.
     */
    public double getPrixM2Min() {
        return prixM2Min;
    }

    /**
     * @return Retourne le prix moyen maximum du terrain.
     */
    public double getPrixM2Max() {
        return prixM2Max;
    }

    /**
     * @return Retourne la liste des lots sur le terrain.
     */
    public List<Lot> getLots() {
        return lotissements;
    }

}
