/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package calculateurfoncier;

/**
 * DroitsPassage
 * 
 * V1
 * 
 * 2021-06-03
 * 
 * @author Flewis07
 */
public class DroitsPassage {

    
    public static double coutPassage(Terrain terrain, Lot lot, double valeurLot) 
            throws Exception {
        int typeTerrain = terrain.getTypeTerrain();
        int nbrDroits = lot.getNombreDroitsPassage();
        double coutPassage = 0;
        
        if (nbrDroits >= 0 && nbrDroits <= 10){
            coutPassage = getCoutPassageParTerrain(valeurLot, typeTerrain,
                    nbrDroits);
        }else {
            throw new Exception("message: Le nombre de droits de passage est" + 
                                    " supérieur à 10.");   
        }
            return coutPassage;    
        }

    private static double getCoutPassageParTerrain(double valeurLot,
                            int typeTerrain, int nbrDroits) throws Exception {
        double coutPassage;
        switch (typeTerrain) {
            case 0:
                coutPassage = 500 - (nbrDroits * ((5 / 100.0) * valeurLot));
                break;
            case 1:
                coutPassage = 500 - (nbrDroits * ((10 / 100.0) * valeurLot));
                break;
            case 2:
                coutPassage = 500 - (nbrDroits * ((15 / 100.0) * valeurLot));
                break;
            default:
                throw new Exception("message: Le type de terrain doit etre " +
                                    "de valeur 0, 1 ou 2");
        }
        return coutPassage;
    }

}
        

