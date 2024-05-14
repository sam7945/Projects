package calculateurfoncier;

import java.util.ArrayList;
import java.util.List;
import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
//package calculateurfoncier;
/**
 *
 * @author Franck
 */
public class Statistiques {

    private static List<Lot> lots;
    private static Terrain terrain;
    private static List<LotSortie> lotsSortie;
    private static TerrainSortie terrainSortie;
    private final static Statistiques statistiques = new Statistiques();
    int totalLots;
    int typeTerrain;
    int nombreLot1000 = 0;
    int nombreLot100000 = 0;
    int nombreLot100000plus = 0;
    double superficieMaximaleLot;
    double valeurMaximaleLot;

    public static Statistiques sommeStatistiques() throws Exception {

        double valeurLot;
        terrain = Terrain.InstanceTerrain();
        lots = terrain.getLots();
        statistiques.typeTerrain = terrain.getTypeTerrain();
        statistiques.totalLots = totalLots();

        for (int i = 0; i < totalLots(); i++) {
            valeurLot = valeurLot(i);
            if (valeurLot < 1000) {
                statistiques.nombreLot1000 = statistiques.nombreLot1000 + 1;
            } else if (valeurLot >= 1000 && valeurLot <= 10000) {
                statistiques.nombreLot100000 = statistiques.nombreLot100000 + 1;
            } else if (valeurLot > 10000) {
                statistiques.nombreLot100000plus = statistiques.nombreLot100000plus + 1;
            }
        }

        statistiques.superficieMaximaleLot = superficieMaximaleLot();
        statistiques.valeurMaximaleLot = valeurMaximaleLot();

        return statistiques;

    }

    public void setTotalLots(int totalLots) {
        this.totalLots = totalLots;
    }

    public void setTypeTerrain(int typeTerrain) {
        this.typeTerrain = typeTerrain;
    }

    public void setNombreLot1000(int nombreLot1000) {
        this.nombreLot1000 = nombreLot1000;
    }

    public void setNombreLot100000(int nombreLot100000) {
        this.nombreLot100000 = nombreLot100000;
    }

    public void setNombreLot100000plus(int nombreLot100000plus) {
        this.nombreLot100000plus = nombreLot100000plus;
    }

    public void setSuperficieMaximaleLot(double superficieMaximaleLot) {
        this.superficieMaximaleLot = superficieMaximaleLot;
    }

    public void setValeurMaximaleLot(double valeurMaximaleLot) {
        this.valeurMaximaleLot = valeurMaximaleLot;
    }

    public static int totalLots() throws Exception {

        int nbrLots;

        terrain = Terrain.InstanceTerrain();
        lots = terrain.getLots();
        nbrLots = lots.size();

        return nbrLots;

    }

    public static double valeurLot(int position) throws Exception {
        
        terrainSortie = TerrainSortie.InstanceTerrain();
        lotsSortie = terrainSortie.getLotissements();

        double valeur = lotsSortie.get(position).getValeurLot();

        return valeur;
    }

    public static double superficieMaximaleLot() throws Exception {

        double superficieMax = 0;
        double superficieLot;
        terrain = Terrain.InstanceTerrain();
        lots = terrain.getLots();
        Lot nbrLot;

        for (int i = 0; i < lots.size(); i++) {
            nbrLot = lots.get(i);
            superficieLot = nbrLot.getSuperficie();
            if (superficieLot > superficieMax) {
                superficieMax = superficieLot;
            }
        }

        return superficieMax;
    }

    public static double valeurMaximaleLot() throws Exception {

        double valeurMax = 0;
        double valeurLot;
        terrain = Terrain.InstanceTerrain();
        lots = terrain.getLots();
        
        terrainSortie = TerrainSortie.InstanceTerrain();
        lotsSortie = terrainSortie.getLotissements();

        for (int i = 0; i < lotsSortie.size(); i++) {
            valeurLot = lotsSortie.get(i).getValeurLot();
            if (valeurLot > valeurMax) {
                valeurMax = valeurLot;
            }

        }
        return valeurMax;
    }
}
