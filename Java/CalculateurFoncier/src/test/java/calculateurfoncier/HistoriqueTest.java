/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package calculateurfoncier;

import java.io.File;
import java.io.IOException;
import java.util.HashMap;
import java.util.Map;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.Test;
import static org.junit.Assert.*;
import org.junit.BeforeClass;

/**
 *
 * @author Simon
 */
public class HistoriqueTest {
    private static String testFilePath = 
            "src\\test\\java\\calculateurfoncier\\";
    private static final String FIC_HISTORIQUE_TEST = 
            testFilePath+ "historiqueTest.json";
    static Statistiques statistiques = new Statistiques();
    
    public HistoriqueTest() {
    }
    
    @BeforeClass
    public static void setUpClass() {
       File file = new File(FIC_HISTORIQUE_TEST); 
       if(file.delete()){
       }
    }
    
    @AfterClass
    public static void tearDownClass() {
       
    }
    
    @Before
    public void setUp() throws Exception {
        statistiques = mockStatistique();
        File file = new File(FIC_HISTORIQUE_TEST); 
        if(file.delete()){
        }
    }
    @After
    public void tearDown() {
        statistiques = new Statistiques();
        File file = new File(FIC_HISTORIQUE_TEST); 
        if(file.delete()){
       }
    }
    @Test
    public void testReinitialisation() throws Exception {
        System.out.println("reinitialisation");
        Historique.réinitialisation(FIC_HISTORIQUE_TEST);
        File file = new File(FIC_HISTORIQUE_TEST);
        assertNotNull(file);
    }
    
    @Test
    public void testReinitialisationErreur() throws Exception {
        System.out.println("reinitialisationErreur");
              File file = new File(FIC_HISTORIQUE_TEST); 
        if(file.delete()){
        }
        Historique.réinitialisation(FIC_HISTORIQUE_TEST);
               File file2 = new File(FIC_HISTORIQUE_TEST);
        assertNotNull(file2);
    }

    @Test
    public void testAffichageHistorique() throws Exception {
        System.out.println("affichageHistorique");
        Historique.affichageHistorique(FIC_HISTORIQUE_TEST);
        File file = new File(FIC_HISTORIQUE_TEST);
        assertNotNull(file);

    }

    public static Statistiques mockStatistique() throws Exception {
        statistiques.setTotalLots(12);
        statistiques.setTypeTerrain(2);
        statistiques.setNombreLot1000(3);
        statistiques.setNombreLot100000(4);
        statistiques.setNombreLot100000plus(5);
        statistiques.setSuperficieMaximaleLot(6);
        statistiques.setValeurMaximaleLot(7);
        return statistiques;
    }

    @Test
    public void testMAJHistorique_NbTotalLots() throws Exception {
        System.out.println("MAJHistorique");
        Donnees donnee = Historique.MAJHistorique(
                statistiques,FIC_HISTORIQUE_TEST);

        int expResult = 12;

        int result = donnee.getNbTotalLots();

        assertEquals(expResult, result);
    }
    
    @Test
    public void testMAJHistorique_NbLotsParType() throws Exception {
        System.out.println("MAJHistorique");
        Donnees donnee = Historique.MAJHistorique(
                statistiques,FIC_HISTORIQUE_TEST);

        Map<String, Integer> expResult = new HashMap<>();
        expResult.put("Type 2: ", 12);

        Map<String, Integer> result = donnee.getNbLotsParType();

        assertEquals(expResult, result);
    }
    
    @Test
    public void testMAJHistorique_NbLotsParValeur() throws Exception {
        System.out.println("MAJHistorique");
        Donnees donnee = Historique.MAJHistorique(
                statistiques,FIC_HISTORIQUE_TEST);

        Map<String, Integer> expResult = new HashMap<>();
        expResult.put("De moins de 1000$: ", 3);
        expResult.put("Entre 1000 et 10000$: ", 4);
        expResult.put("De plus de 10000$: ", 5);

        Map<String, Integer> result = donnee.getNbLotsParValeur();

        assertEquals(expResult, result);
    }

    @Test
    public void testMAJHistorique_ValeurMaximaleLot() throws Exception {
        System.out.println("MAJHistorique");
        Donnees donnee = Historique.MAJHistorique(
                statistiques,FIC_HISTORIQUE_TEST);

        double expResult = 7.0;

        double result = donnee.getValeurMaximaleLot();

        assertEquals(expResult, result,0.0);
    }
    
    @Test
    public void testMAJHistorique_SuperficieMaxLot() throws Exception {
        System.out.println("MAJHistorique");

        Donnees donnee = Historique.MAJHistorique(
                statistiques,FIC_HISTORIQUE_TEST);

        double expResult = 6;

        double result = donnee.getSuperficieMaxLot();

        assertEquals(expResult, result,0.0);
    }


}
