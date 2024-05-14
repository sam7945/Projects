package calculateurfoncier;

import java.io.IOException;
import java.util.HashMap;
import java.util.Map;
import net.sf.json.JSONObject;
import java.io.File;

public class Historique {

    public static final String FIC_HISTORIQUE = "historique.json";
    static Historique historique = new Historique();

    private static final String NOMBRE_TOTAL_LOTS
            = "nombre_total_lots";
    private static final String NOMBRE_LOTS_PAR_VALEUR
            = "nombre_lots_par_valeur";
    private static final String NOMBRE_LOTS_PAR_TYPE
            = "nombre_lots_par_type_terrain";
    private static final String SUPERFICIE_MAX
            = "superficie_maximale_pour_un_lot";
    private static final String VALEUR_MAX
            = "valeur_par_lot_maximale";
    private static final String MOINS_1K
            = "De moins de 1000$: ";
    private static final String ENTRE_1K_10K
            = "Entre 1000 et 10000$: ";
    private static final String PLUS_10K
            = "De plus de 10000$: ";

    private static Donnees donneesHistorique;
    private static Donnees donneesStatistiques;
    private static Donnees donneesnouveau;

    public static Donnees MAJHistorique(
            Statistiques statistiques, String filename)
            throws Exception {
        créerJsonSiInexistant(filename);
        donneesHistorique = new Donnees();
        donneesStatistiques = new Donnees();
        donneesnouveau = new Donnees();
        
        HistoriqueGetDonnées(getJsonHistorique(filename));
        statistiqueGetDonnées(statistiques);

        donneesnouveau.setNbTotalLots(
                donneesStatistiques.nbTotalLots
                + donneesHistorique.nbTotalLots);

        donneesnouveau.setSuperficieMaxLot(
                prendreLePlusGrand(
                        donneesHistorique.superficieMaxLot,
                        donneesStatistiques.superficieMaxLot));

        donneesnouveau.setValeurMaximaleLot(
                prendreLePlusGrand(
                        donneesHistorique.valeurMaximaleLot,
                        donneesStatistiques.valeurMaximaleLot));

        donneesnouveau.setNbLotsParValeur(
                additionnerMap(
                        donneesHistorique.nbLotsParValeur,
                        donneesStatistiques.nbLotsParValeur));

        donneesnouveau.setNbLotsParType(
                additionnerMap(
                        donneesHistorique.nbLotsParType,
                        donneesStatistiques.nbLotsParType));

        return donneesnouveau;
    }

    public static void réinitialisation(String filename) throws IOException {
        File fichier = new File(filename);
        fichier.delete();
        créerJsonSiInexistant(filename);
        System.out.println("Le fichier de statistique à été réinitialialisé");
    }

    public static void affichageHistorique(String filename) throws IOException {
        créerJsonSiInexistant(filename);
        System.out.println(getJsonHistorique(filename).toString(4));

    }

    private static Map<String, Integer> additionnerMap(
            Map<String, Integer> map1,
            Map<String, Integer> map2) {

        for (String key : map2.keySet()) {
            try {
                int value1 = map1.get(key);
                int value2 = map2.get(key);
                map1.put(key, value1 + value2);
            } catch (NullPointerException e) {
                int value2 = map2.get(key);
                map1.put(key, value2);
            }
        }
        return map1;
    }

    private static double prendreLePlusGrand(double valeur1, double valeur2) {
        if (valeur1 < valeur2) {
            return valeur2;
        } else {
            return valeur1;
        }
    }

    private static JSONObject créationJsonHistorique() {
        JSONObject jsonHistorique = new JSONObject();
        jsonHistorique.accumulate(NOMBRE_TOTAL_LOTS, 0);
        jsonHistorique.accumulate(NOMBRE_LOTS_PAR_VALEUR, new HashMap<>());
        jsonHistorique.accumulate(NOMBRE_LOTS_PAR_TYPE, new HashMap<>());
        jsonHistorique.accumulate(SUPERFICIE_MAX, 0);
        jsonHistorique.accumulate(VALEUR_MAX, 0);
        return jsonHistorique;
    }

    private static JSONObject getJsonHistorique(String filename) 
            throws IOException {
        String jsonHistorique = FileReader.loadFileIntoString(
                filename, CalculateurFoncier.ENCODAGE);

        return JSONObject.fromObject(jsonHistorique);
    }

    private static void créerJsonSiInexistant(String filename) 
            throws IOException {
        try {
            getJsonHistorique(filename);
        } catch (IOException e) {
            JSONObject jsonHistorique = créationJsonHistorique();
            FileWriter.saveStringIntoFile(filename,
                    jsonHistorique.toString());
        }
    }

    public static void écrireJsonHistorique(String filename) 
            throws IOException {

        JSONObject jsonHistorique = new JSONObject();
        jsonHistorique.accumulate(NOMBRE_TOTAL_LOTS,
                donneesnouveau.getNbTotalLots());

        jsonHistorique.accumulate(NOMBRE_LOTS_PAR_VALEUR,
                creerJsonMap(donneesnouveau.getNbLotsParValeur()));

        jsonHistorique.accumulate(NOMBRE_LOTS_PAR_TYPE,
                creerJsonMap(donneesnouveau.getNbLotsParType()));

        jsonHistorique.accumulate(SUPERFICIE_MAX,
                donneesnouveau.getSuperficieMaxLot());

        jsonHistorique.accumulate(VALEUR_MAX,
                Calculs.Arrondir(donneesnouveau.getValeurMaximaleLot()));

        FileWriter.saveStringIntoFile(filename,
                jsonHistorique.toString());
    }

    private static void statistiqueNombreLotParValeur(Statistiques statistiques)
            throws Exception {

        donneesStatistiques.getNbLotsParValeur().put(
                MOINS_1K, statistiques.nombreLot1000);
        
        donneesStatistiques.getNbLotsParValeur().put(
                ENTRE_1K_10K, statistiques.nombreLot100000);
        
        donneesStatistiques.getNbLotsParValeur().put(
                PLUS_10K, statistiques.nombreLot100000plus);
    }

    private static void statistiqueNombreLotParType(Statistiques statistiques)
            throws Exception {
        int typeTerrain = statistiques.typeTerrain;
        String type = "Type " + typeTerrain + ": ";
        donneesStatistiques.getNbLotsParType().put(
                type, statistiques.totalLots);
    }

    private static void statistiqueGetDonnées(Statistiques statistiques)
            throws Exception {

        donneesStatistiques.setNbTotalLots(
                statistiques.totalLots);
        
        donneesStatistiques.setSuperficieMaxLot(
                statistiques.superficieMaximaleLot);
        
        donneesStatistiques.setValeurMaximaleLot(
                statistiques.valeurMaximaleLot);
        
        statistiqueNombreLotParType(statistiques);
        statistiqueNombreLotParValeur(statistiques);
    }

    private static void HistoriqueGetDonnées(JSONObject vieuxHistorique) {

        donneesHistorique.setNbTotalLots(
                vieuxHistorique.getInt(NOMBRE_TOTAL_LOTS));

        donneesHistorique.setNbLotsParValeur(
                (Map<String, Integer>) vieuxHistorique.get(
                        NOMBRE_LOTS_PAR_VALEUR));

        donneesHistorique.setNbLotsParType(
                (Map<String, Integer>) vieuxHistorique.get(
                        NOMBRE_LOTS_PAR_TYPE));

        donneesHistorique.setSuperficieMaxLot(
                vieuxHistorique.getDouble(SUPERFICIE_MAX));

        donneesHistorique.setValeurMaximaleLot(
                vieuxHistorique.getDouble(VALEUR_MAX));
    }

    private static JSONObject creerJsonMap(Map<String, Integer> variable) {
        JSONObject jsonMap = new JSONObject();
        for (Map.Entry<String, Integer> entry : variable.entrySet()) {
            jsonMap.accumulate(entry.getKey(), entry.getValue());
        }
        return jsonMap;
    }
}
