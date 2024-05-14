package calculateurfoncier;

import net.sf.json.JSONObject;

import java.io.IOException;
import java.util.List;
import java.util.regex.*;  

/**
 * @author sam79
 */
public class CalculateurFoncier {

    public static String fichierEntree;
    public static String fichierSortie;
    public static String optionExecution = "";
    public static final String ENCODAGE = "UTF-8";

    private static Terrain terrain;
    private static List<Lot> lots;
    private static TerrainSortie terrainSortie;
    private static Statistiques statistiques = new Statistiques();
   
    public static void main(String[] args) throws Exception {
        try{
        initialisationVariables(args);
        switch (optionExecution) {
            default -> CalculateurFoncier();
            case "-S" -> Historique.affichageHistorique(
                    Historique.FIC_HISTORIQUE);
            case "-SR" -> Historique.réinitialisation(
                    Historique.FIC_HISTORIQUE);
            }
        }catch (Exception e) {
            ecritureMessageErreur( e.getMessage());
        }
        
    }
    private static void CalculateurFoncier() throws Exception {
        try {
            for (int i=0; i < lots.size(); i++){
                String descriptionLot = lots.get(i).getDescription();

                double montantServices = CalculServices.calculServices(
                        terrain, lots.get(i));
                double valeurTerrain = ValeurFonciere.calculValeurTerrain(
                        terrain, lots.get(i));
                double montantPassages =
                        DroitsPassage.coutPassage(terrain, lots.get(i), 
                                valeurTerrain);

                terrainSortie.ajoutLots(
                        new LotSortie( descriptionLot , montantServices +
                                        montantPassages + valeurTerrain));
                    }

                FileWriter.saveStringIntoFile(
                        fichierSortie,terrainSortie.toString());
                
                
                statistiques = Statistiques.sommeStatistiques();
                Historique.MAJHistorique(
                        statistiques,Historique.FIC_HISTORIQUE);
                Historique.écrireJsonHistorique(
                        Historique.FIC_HISTORIQUE);
        } catch (Exception e) {
            ecritureMessageErreur( e.getMessage());
        }
    }

    private static void initialisationVariables(String[] args)
            throws Exception {
        if (TypeExecution(args[0])){
            initialisationVariablesAvecOption(args);
        }
        else { 
            initialisationVariablesNormales(args);
        }
    }

    private static void initialisationVariablesNormales(String[] args) 
            throws Exception {
        fichierEntree = args[0];
        fichierSortie = args[1];
        terrain = Terrain.InstanceTerrain();
        lots = terrain.getLots();
        terrainSortie = TerrainSortie.InstanceTerrain();
    }

    private static void initialisationVariablesAvecOption(String[] args) 
            throws Exception {
        optionExecution = args[0];
        validationOptionExecution(optionExecution);
    }

    private static void ecritureMessageErreur(String message)
            throws IOException {
        JSONObject messageErreur = new JSONObject();
        messageErreur.put("message",message);
        if(fichierSortie==null){
            System.out.println(message);
        }
        else{    
            FileWriter.saveStringIntoFile(
                    fichierSortie,messageErreur.toString());
                }
    }
    
    private static void validationOptionExecution(String optionExecution) 
            throws Exception {
        if ("".equals(optionExecution) ||
                "-S".equals(optionExecution) ||
                "-SR".equals(optionExecution)){
            //Ne rien faire
        }
        else{
            throw new Exception("Option d'entrée incorrect:\n"
            + "Sans options: Exécution normale\n"
            + "-S: Affiche les statistiques\n"
            + "-SR: Réinitialise les statistique");
        }
    }

    private static boolean TypeExecution(String arg) {
        return Pattern.matches("-\\w*", arg);
    }
}
