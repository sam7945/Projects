/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package calculateurfoncier;
import java.util.HashMap;
import java.util.Map;

/**
 *
 * @author Simon
 */
public class Donnees {
    int nbTotalLots;
    double superficieMaxLot;
    double valeurMaximaleLot;    
    Map<String, Integer> nbLotsParValeur;
    Map<String, Integer> nbLotsParType ;
    
    public Donnees() {
        nbTotalLots = 0;
        superficieMaxLot = 0;
        valeurMaximaleLot = 0;    
        nbLotsParValeur = new HashMap<>();
        nbLotsParType = new HashMap<>();
        }

    public int getNbTotalLots() {
        return nbTotalLots;
    }

    public void setNbTotalLots(int nbTotalLots) {
        this.nbTotalLots = nbTotalLots;
    }

    public double getSuperficieMaxLot() {
        return superficieMaxLot;
    }

    public void setSuperficieMaxLot(double superficieMaxLot) {
        this.superficieMaxLot = superficieMaxLot;
    }

    public double getValeurMaximaleLot() {
        return valeurMaximaleLot;
    }

    public void setValeurMaximaleLot(double valeurMaximaleLot) {
        this.valeurMaximaleLot = valeurMaximaleLot;
    }

    public Map<String, Integer> getNbLotsParValeur() {
        return nbLotsParValeur;
    }

    public void setNbLotsParValeur(Map<String, Integer> nbLotsParValeur) {
        this.nbLotsParValeur = nbLotsParValeur;
    }

    public Map<String, Integer> getNbLotsParType() {
        return nbLotsParType;
    }

    public void setNbLotsParType(Map<String, Integer> nbLotsParType) {
        this.nbLotsParType = nbLotsParType;
    }
}
